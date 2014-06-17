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

//public partial class Checkout : System.Web.UI.Page
public partial class Checkout : MyBasePage
{
    public Checkout()
    {
        requireSSL = true;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MYCART"] == null)
        {
            lblMsg.Text = "Your shopping cart is empty" +
                "Please add product(s) to it before you can checkout";
            pnlLogin.Visible = false;
        }
        else
        {
            Cart ct = (Cart)Session["MYCART"];
            if (ct.list.Count == 0)
            {
                lblMsg.Text = "Your Shopping Cart is empty" +
                    "Please add product(s) to it before you can checkout";
                pnlLogin.Visible = false;
            }
            else
            {
                // check if someone already logged in
                if (Session["CUSTOMERUSERID"] != null)
                    Response.Redirect("ConfirmCheckOut.aspx");
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            string unm = txtUser.Text;
            string pw = txtPW.Text;
            IDataAccount ida = GenericFactory<BusinessLayer, IDataAccount>.CreateInstance();
            object obj = ida.GetScalarDBFromUsers(unm, pw);
            //string sql = "SELECT UserID FROM  Users WHERE UserName='" + unm +
            //    "' and Password='" + pw + "'";
            //object obj = DBFunctions.GetScalarDB(sql);
            if (obj != null)
            {
                Session["CUSTOMERUSERID"] = obj.ToString();
                Response.Redirect("ConfirmCheckOut.aspx");
            }
            else
                lblStatus.Text = "<font color='red'>Invalid Login, please try again..<br></font>" +
                    "If you forgot your password, <a href='ForgotPassword.aspx'>click here</a> <br>" +
                    " else please register as a new customer.";
         }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }
}
