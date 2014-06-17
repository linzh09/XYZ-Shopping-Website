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
public partial class Login1 : MyBasePage
//public partial class Login1 : System.Web.UI.Page
{
    public Login1()
    {
        requireSSL = true;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        // Role based security needs concepts of 
        // Identities, Roles, Principles
        // Identities represent users, and have properties that 
        // allow you to obtain information e.g., username 
        // A Principal contains information about both the identity 
        // and roles that the current user is associated with
        IBusinessAuthentication iba = GenericFactory<BusinessLayer, IBusinessAuthentication>.CreateInstance();


        lblMsg.Visible = false;
        string uid = txtName.Text;
        string pwd = txtPwd.Text;
        string accessLevel = iba.CheckUser(uid, pwd);
        //string accessLevel = CheckUser(uid, pwd);
        if (accessLevel != "")
        {
            //-----------Create authentication cookie----
            string roles = iba.GetRolesForUser(uid);
            //string roles = GetRolesForUser(uid);//pipe or comma delimited role list - add later
            FormsAuthenticationTicket authTicket 
                    = new FormsAuthenticationTicket(1, uid, DateTime.Now, DateTime.Now.AddMinutes(30), false, roles);
            //  encrypt the ticket
            string encryptedTicket =
                FormsAuthentication.Encrypt(authTicket);

            // add the encrypted ticket to the cookie as data
            HttpCookie authCookie = new HttpCookie
                (FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(authCookie);
            Session["ADMINUID"] = uid;
            Response.Redirect(FormsAuthentication.GetRedirectUrl(uid, true));
            // calling FormsAuthentication indicates that the
            // user has been authenticated, and now we want roles for this user
            // to be populated in the Principle object for this user
            // Above code triggers Global.asax Application_AuthenticateRequest 
            // with authenticated set to true
            // By putting a check on authenticated, we can slightly
            // speed up the Authenticate request for open access pages
            //-------------------------------------------
             //Session["ADMINUID"] = uid;
           
            /* old code - where Roles were obtained from DB each time
             * authentication request occured which was multiple
             * times per page
             if (FormsAuthentication.GetRedirectUrl(uid, false).Trim() == "/XYZEVE05/default.aspx")
             {
                 FormsAuthentication.RedirectFromLoginPage(uid, false);
             }
             else
             {
                 FormsAuthentication.RedirectFromLoginPage(uid, false);
             } */
        }
        else
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Invalid login for Requested Page";
        }
    }

    //private string CheckUser(string uid, string pwd)
    //{
    //     string sql = "select UserName from Users where Username='" +
    //        uid + "' and Password='" + pwd + "'";
    //    Object obj = DBFunctions.GetScalarDB(sql);
    //    if (obj != null)
    //        return obj.ToString();  // Username column
    //    else
    //        return "";  // means user not found
    // }

    //string GetRolesForUser(string uname) // pipe delimited string
    //{
    //    string roles = "";
    //    string connStr = ConfigurationManager.ConnectionStrings["XYZEVEDSN"].ConnectionString;
    //    SqlConnection conn = new SqlConnection(connStr);

    //    try
    //    {
    //        conn.Open();
    //        SqlCommand cmd = new SqlCommand("GetUserRoles", conn);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.Add(new SqlParameter("@Username", uname));
    //        SqlDataReader reader = cmd.ExecuteReader();

    //        ArrayList roleList = new ArrayList();
    //        while (reader.Read())
    //            roles += reader["Role"].ToString() + "|";
    //        if (roles != "")  // remove last "|"
    //            roles = roles.Substring(0, roles.Length - 1);
    //        conn.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        conn.Close();
    //    }
    //    return roles;
    //}

    

}
