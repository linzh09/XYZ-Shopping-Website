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

//public partial class Thankyou : System.Web.UI.Page
public partial class Thankyou : MyBasePage
{
    public Thankyou()
    {
        requireSSL = true;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            int orderNum = (int)Session["CUSTOMERORDERNUM"];
            Cart ct = (Cart)Session["MYCART"];

            string msgbody = "<h3> Thank you for your order with XYZ Shop </h3>";
            msgbody += "<b>Your Order Number=" + orderNum.ToString() + " with XYZ Shop</b><br>";
            msgbody += "<table border=1>";
            msgbody += "<tr> <th> Item Number <th> Product Description <th> Quantity <th> Price/Item <th> Total</tr>";
            double rowtotal = 0.0;
            double finalTotal = 0.0;
            foreach (CartRow cr in ct.list)
            {
                if (cr.PName != "Shipping/Handling")
                {
                    rowtotal = double.Parse(cr.Price) * double.Parse(cr.Qty);
                    finalTotal += rowtotal;
                    msgbody += "<tr> <td> " + cr.PID +
                        " <td> " + cr.PName +
                        " <td> " + cr.Qty + " <td> $" +
                        cr.Price + "<td> $" + rowtotal.ToString();

                }
                else
                {
                    msgbody += " <tr><td><td><td><td>Shipping/Handling = <td>$" + cr.Price;
                    finalTotal += double.Parse(cr.Price);
                }
            }

            msgbody += " <tr><td><td><td><td><b>Total cost</b> = <td>$" + finalTotal.ToString() + "</tr>";
            msgbody += " </table><br>Please allow 2-3 days for delivery of above items <br>";
            msgbody += " <br><b>Thank you </b> for shopping with XYZ Shop ";
            msgbody += " <br>A confirmation email has been sent to you with the above information";
            lblSummary.Text = msgbody;

            Session["MYCART"] = null;  // this shopping session is complete

        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }
}
