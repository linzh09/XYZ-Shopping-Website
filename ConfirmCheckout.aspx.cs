using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

//public partial class ConfirmCheckout : System.Web.UI.Page
public partial class ConfirmCheckout : MyBasePage
{
    public ConfirmCheckout()
    {
        requireSSL = true;
    }
    IDataAccount ida = GenericFactory<BusinessLayer, IDataAccount>.CreateInstance();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string uid = "";
            if (Session["CUSTOMERUSERID"] != null)
            {
                uid = (string)Session["CUSTOMERUSERID"];
                try
                {
                    //string sql = "SELECT * FROM  CustomerInfos WHERE UserID=" + uid;
                    //DataSet ds = DBFunctions.GetDataSetDB(sql);
                    DataSet ds = ida.GetDataSetDBFromCustomerInfosByUserID(uid);
                    lblFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    lblLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                    txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
                    txtZipcode.Text = ds.Tables[0].Rows[0]["Zipcode"].ToString();
                    txtCCNumber.Text = ds.Tables[0].Rows[0]["CCNumber"].ToString();
                    string cctype = ds.Tables[0].Rows[0]["CCType"].ToString();
                    switch (cctype)
                    {
                        case "Visa": ddlCCType.Items[0].Selected = true;
                            break;
                        case "MasterCard": ddlCCType.Items[1].Selected = true;
                            break;
                        case "AmericanExpress": ddlCCType.Items[2].Selected = true;
                            break;
                        case "Discover": ddlCCType.Items[3].Selected = true;
                            break;
                    }
                    txtExpiration.Text = ds.Tables[0].Rows[0]["CCExpiration"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                catch (Exception ex)
                {
                    lblStatus.Text = ex.Message;
                }

            }

            try
            {
                // add shipping and handling info to shopping cart
                if (Session["MYCART"] != null)
                {
                    Cart myCart = (Cart)Session["MYCART"];
                    CartRow row = new CartRow();
                    row.PID = "";  // shipping/handling has blank row id
                    row.PName = "Shipping/Handling";
                    row.Price = "8.75"; // later on get the price from database
                    // based on products and shipping address
                    row.Qty = "";		// count of how many to buy
                    // for shipping/handling row, it is blank

                    //  if shipping/handling exists in shopping cart, remove first, then add
                    //  with an updated total count
                    int cartRowCount = myCart.list.Count;
                    CartRow crow;
                    for (int i = 0; i < cartRowCount; i++)
                    {
                        crow = (CartRow)myCart.list[i];
                        if (crow.PID == row.PID)
                        {
                            myCart.list.RemoveAt(i);
                            break;
                        }
                    }
                    myCart.list.Add(row);  // add it at the end of shopping cart
                    //Cart.ShowCartTable(myCart, Table1, LabelTotal);
                }

                MyCCValidator.AcceptedCreditCardTypes = ddlCCType.SelectedValue;
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }


    }

    protected void btnUpdateInfo_Click(object sender, EventArgs e)
    {
        string uid = "";
        if (Page.IsValid)  // if no validation errors on the page
        {
            try
            {
                if (Session["CUSTOMERUSERID"] != null)
                {
                    uid = (string)Session["CUSTOMERUSERID"];

                    string addr2 = txtAddress.Text.Trim();
                    string city = txtCity.Text;
                    string state = txtState.Text;
                    string zipcode = txtZipcode.Text;
                    string email = txtEmail.Text;
                    string ccnum = txtCCNumber.Text;
                    string cctype = ddlCCType.SelectedItem.ToString();
                    string expir = txtExpiration.Text;
                    //string sql = "Update tblCustomerInfo set Address='" + addr2 + "' where UserID=" + uid; 
                    //string sql = "Update CustomerInfos set Address='" + addr2 + "'," +
                    //    "City='" + city + "',"
                    //    + "State='" + state + "',"
                    //    + "Zipcode='" + zipcode + "',"
                    //    + "Email='" + email + "',"
                    //    + "CCNumber='" + ccnum + "',"
                    //    + "CCType='" + cctype + "',"
                    //    + "CCExpiration='" + expir + "'" + "where UserID=" + uid;
                    //int rows = DBFunctions.GetNonQueryDB(sql);
                    int rows = ida.GetNonQueryDBFromCustomerInfos(addr2, city, state, zipcode, email, ccnum, cctype, expir, uid);
                    lblStatus.Text = "Update succeeded : status = " + rows.ToString();

                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }  // if page is valid

    }

    protected void btnConfirmCheckOut_Click(object sender, EventArgs e)
    {
        // Do credit card transaction with payment processor.
        // If return from card processing is Ok then
        // update inventory levels for products purchased.
        // Send email with products purchased and charges
        // and show a results page with purchase summary
        // else
        // indicate through results page the card problem

        Cart ct = (Cart)Session["MYCART"];

        SqlTransaction sqtr = null;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["XYZEVEDSN"].ConnectionString;
        con.Open();
        sqtr = con.BeginTransaction();
        int orderNum = 0;
        bool bOrderPlaceSuccess = false;
        double totalPrice = 0;
        int nQty = 0;      // total quantity of shipped items for shipping purposes
        try
        {
            //string sql0 = "SELECT MAX(OrderNo) AS MAXORDNO FROM Orders";
            //SqlCommand cmd0 = new SqlCommand(sql0, con);
            //cmd0.Transaction = sqtr;

            //object obj = cmd0.ExecuteScalar();
            object obj = ida.GetScalarDBFromOrders(sqtr, con);

            if (obj == null)
                orderNum = 1;
            else
            {
                if (obj.ToString() != "")
                    orderNum = int.Parse(obj.ToString()) + 1; // max record no.+1 in orders
                else
                    orderNum = 1;
            }
            string s = (string)Session["CUSTOMERUSERID"];
            int rows = ida.GetNonQueryDBFromOrders(sqtr, con, orderNum, s);
            //string sql1 = "INSERT INTO Orders (OrderNo,UserID, OrderDate) VALUES ("
            //    + orderNum.ToString() + ",'" + (string)Session["CUSTOMERUSERID"] + "','" +
            //    System.DateTime.Now.ToString() + "')";
            //SqlCommand cmd1 = new SqlCommand(sql1, con);
            //cmd1.Transaction = sqtr;
            //int rows = cmd1.ExecuteNonQuery();

            //---------process shopping cart entries for database update----
            double shippingPrice = 0;
            //string sql2 = "";
            //SqlCommand cmd2;
            foreach (CartRow cr in ct.list)
            {

                if (cr.PName != "Shipping/Handling")
                {
                    //sql2 = "INSERT INTO OrderDetails (OrderNo,ItemNo, ItemDesc, Qty, Price) VALUES ("
                    //    + orderNum.ToString() + "," + cr.PID +
                    //    ",'" + cr.PName.Replace("'", "''") + "'," +
                    //    cr.Qty + "," + cr.Price + ")";
                    //cmd2 = new SqlCommand(sql2, con);
                    //cmd2.Transaction = sqtr;

                    //rows = cmd2.ExecuteNonQuery();
                    rows = ida.GetNonQueryDBFromOrderDetails(sqtr, con, orderNum, cr);
                    totalPrice = totalPrice + double.Parse(cr.Price) * (double.Parse(cr.Qty));
                    nQty = nQty + int.Parse(cr.Qty);
                }
                else
                    shippingPrice = double.Parse(cr.Price);
            }

            // Calculate shipping based on sQty 
            // or for detailed shipping calculations, you may need
            // to query the shipping weight of each item and then decide
            // on shipping cost. 
            // shippingPrice = shippingPrice + detailed formula based on products purchased

            totalPrice = totalPrice + shippingPrice;

            //string sql3 = "UPDATE Orders SET TotalQty = " + nQty.ToString() + ", TotalCost = "
            //    + totalPrice.ToString() + " WHERE OrderNo = " + orderNum.ToString();
            //SqlCommand cmd3 = new SqlCommand(sql3, con);
            //cmd3.Transaction = sqtr;
            //rows = cmd3.ExecuteNonQuery();
            rows = ida.GetNonQueryDBUpdateOrders(sqtr, con, orderNum, totalPrice, nQty);
            sqtr.Commit();
            con.Close();
            Session["CUSTOMERORDERNUM"] = orderNum;
            bOrderPlaceSuccess = true;

        }
        catch (Exception ex1)
        {
            sqtr.Rollback();
            lblStatus.Text = ex1.Message;
        }
        finally
        {
            con.Close();
        }


        //-----------------Send Email for the products purchased---------------
        if (bOrderPlaceSuccess == true)
        {
            try
            {
                //string sql4 = "Select Email from tblCustomerInfo where UserID="
                //    + (string)Session["CUSTOMERUSERID"];
                //object obj = DBFunctions.GetScalarDB(sql4);
                string s = (string)Session["CUSTOMERUSERID"];
                object obj = ida.GetScalarDBFromtblCustomerInfo(s);
                string email = obj.ToString();

                System.Net.Mail.MailMessage msg =
                    new System.Net.Mail.MailMessage();

                msg.To.Add(email);
                msg.From = new System.Net.Mail.MailAddress("xyz@xyzshop.com");

                msg.Headers.Add("Reply-To", "xyzw@xyzshop.com");
                // reply will be sent to above address
                msg.Subject = "Your Order Number=" + orderNum.ToString() +
                    " with XYZ Shop";

                string msgbody = "<h3>Your Order Number=" + orderNum.ToString() + " with XYZ Shop</h3>";
                msgbody += "<table border=1>";
                msgbody += "<tr> <th> Item Number <th> Product Description <th> Quantity <th> Price/Item <th> Total</tr>";
                double rowtotal = 0.0;
                foreach (CartRow cr in ct.list)
                {
                    if (cr.PName != "Shipping/Handling")
                    {
                        rowtotal = double.Parse(cr.Price) * double.Parse(cr.Qty);
                        msgbody += "<tr> <td> " + cr.PID +
                        " <td> " + cr.PName +
                        " <td> " + cr.Qty + " <td> $" +
                            cr.Price + "<td> $" + rowtotal.ToString();

                    }
                    else
                        msgbody += " <tr><td><td><td><td>Shipping/Handling = <td>$" + cr.Price;
                }
                msgbody += " <tr><td><td><td><td><b>Total cost</b> = <td>$" + totalPrice.ToString() + "</tr>";
                msgbody += " </table><br>Please allow 2-3 days for delivery of above items <br>";
                msgbody += " <br><b>Thank you </b> for shopping with XYZ Shop ";
                //Response.Write(email+msgbody);

                msg.Body = msgbody;
                //SmtpMail.SmtpServer = "tennis";//"192.168.0.100";//"216.87.108.47"; // your SMTP server e.g., mail.bridgeport.edu
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("mail.bridgeport.edu");
                //new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["SMTPServer"]);//;"192.168.0.102" ;//"mail.bridgeport.edu"; // your SMTP server e.g., mail.bridgeport.edu

                msg.Priority = System.Net.Mail.MailPriority.High;
                smtp.Send(msg);
                lblStatus.Text = "Your email has been sent";
                Response.Redirect("Thankyou.aspx");
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Order was placed successfully.<br> " +
                    "However we could not send email to the " +
                "address you had provided. <br>" +
                    ex.Message;
            }
        }

    }
}


