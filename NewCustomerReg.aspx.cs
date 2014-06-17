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

//public partial class NewCustomerReg : System.Web.UI.Page
public partial class NewCustomerReg : MyBasePage
{
    public NewCustomerReg()
    {
        requireSSL = true;
    }
    IDataAccount ida = GenericFactory<BusinessLayer, IDataAccount>.CreateInstance();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (Page.IsValid) // if no validation errors on the page
        {
            string CONNSTR = ConfigurationManager.ConnectionStrings["XYZEVEDSN"].ConnectionString;
            SqlConnection conn = new SqlConnection(CONNSTR);
            SqlTransaction sqtr = null;

             try
            {

                string unm = txtUsername.Text;
                string pwd = txtPW.Text;
                string pHint = txtPWHintQ.Text;
                string pAns = txtPWHintA.Text;
                conn.Open();
                sqtr = conn.BeginTransaction();
                // first check if the username selected by user already exists
                //string sqlcheck = "select * from Users where Username='" +
                //    unm + "'";
                //SqlCommand cmd = new SqlCommand(sqlcheck, conn);
                //cmd.Transaction = sqtr;
                // object obj = cmd.ExecuteScalar();
                object obj = ida.GetScalarDBFromUsersByUserID(sqtr, conn, unm);
                if (obj != null)
                {
                    lblStatus.Text = "Please choose a different Username as this already exists";
                    throw new Exception("duplicate username");
                }

                // create a transaction for inserting into tblUsers and tblCustomerInfo



                // username is OK, create an entry into tblUsers
                //string sql = "INSERT INTO Users (Username,Password,PHint,PAns) VALUES ('" +
                //    unm + "','" + pwd + "','" + pHint + "','" + pAns + "')";

                //SqlCommand cmd2 = new SqlCommand(sql, conn);
                //cmd2.Transaction = sqtr;
                //int rows = cmd2.ExecuteNonQuery();
                int rows = ida.GetNonQueryDBFromUsers(sqtr, conn, unm, pwd, pHint, pAns);

                // Now get the UserID assigned to the new user from Users
                //string sqluid = "select userid from Users where Username='" +
                //    unm + "'";
                //SqlCommand cmduid = new SqlCommand(sqluid, conn);
                //cmduid.Transaction = sqtr;

                //object objuid = cmduid.ExecuteScalar();
                object objuid = ida.GetScalarDBFromUsersForUserID(sqtr, conn, unm);
                string userID = objuid.ToString();

                // Now insert customer info for the UserID in CustomerInfos
                string fnm = txtFirstName.Text;
                string lnm = txtLastName.Text;
                string addr = txtAddress.Text;
                string zip = txtZipcode.Text;
                string city = txtCity.Text;
                string state = txtState.Text;
                string ccexpir = txtCCExpiration.Text;
                string ccnum = txtCCNumber.Text;
                string cctype = ddlCCType.SelectedItem.ToString();
                string email = txtEmail.Text;
                //string sqlc = "INSERT INTO CustomerInfos (UserID,FirstName,LastName,"
                //    + "Address,ZipCode,City,State,CCNumber,CCExpiration,CCType,Email)"
                //    + " VALUES (" +
                //    userID + ",'" + fnm + "','" + lnm + "','" + addr + "','" +
                //    zip + "','" + city + "','" + state + "','" + ccnum + "','" +
                //    ccexpir + "','" + cctype + "','" + email + "')";

                //SqlCommand cmdc = new SqlCommand(sqlc, conn);
                //cmdc.Transaction = sqtr;
                //int rowsc = cmdc.ExecuteNonQuery();
                int rowsc = ida.GetNonQueryDBFromCustomerInfos(sqtr, conn, fnm, lnm, addr, zip, city, state, ccexpir, ccnum, cctype, email, userID);

                sqtr.Commit();
                conn.Close();

                if (rowsc > 0) // sucessful registration - goto checkout
                {
                    Session["CUSTOMERUSERID"] = userID;
                    Response.Redirect("ConfirmCheckOut.aspx");
                }


            }
            catch (Exception ex)
            {
                sqtr.Rollback();
                lblStatus.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        } // if page is valid

    }
}

