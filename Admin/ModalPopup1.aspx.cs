using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//public partial class ModalPopup1 : System.Web.UI.Page
public partial class Admin_ModalPopup1 : MyBasePage
{
    public Admin_ModalPopup1()
    {
        requireSSL = true;
    }
    IDataAccount ida = GenericFactory<BusinessLayer, IDataAccount>.CreateInstance();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblStatus.Text = "";
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        txtPassword.Text = "";
    }
    protected void btnUpdatePrice_Click1(object sender, EventArgs e)
    {
        if (txtPassword.Text == "admin100")
        {
            int pid = int.Parse(txtProductID.Text);
            bool b;
            b = ida.GetScalarDBFromprod(pid);
            if (b == true)
            {
                lblStatus.Text = "Delete succeed.";
            }
            else
            {
                lblStatus.Text = "This product is not exist.";
            }
        }
        else
        {
            lblStatus.Text = "Invalid Password for deleting.";
        }
    }
}