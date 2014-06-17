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

//public partial class ViewCart : System.Web.UI.Page
public partial class ViewCart : MyBasePage
{
    public ViewCart()
    {
        requireSSL = true;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnContinueShopping_Click(object sender, EventArgs e)
    {
        if (Session["CATID"] != null)
        {
            string catID = (string)Session["CATID"];
            Response.Redirect("Products.aspx?CatID=" + catID);
        }
        else
            Response.Redirect("Products.aspx?CatID=10");
    }

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("CheckOut.aspx");
    }
}
