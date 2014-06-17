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
using XYZShopAdminServiceWClient.XYZPS;
using System.Collections.Generic;
using System.ComponentModel;

//public partial class Admin_ViewProductsWCF : System.Web.UI.Page
public partial class Admin_ViewProductsWCF : MyBasePage
{
    public Admin_ViewProductsWCF()
    {
        requireSSL = true;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindToGridFromWCF();
    }

    void BindToGridFromWCF()
    {
        try
        {
            ProductsAdminClient pac
                    = new ProductsAdminClient();
            BindingList<ProductInfo>
                   PList = pac.GetAllProducts();
            ProductInfo pi = PList[0];
            lblStatus.Text = pi.ProductImage;
            gv1.DataSource = PList;
            gv1.DataBind();
            pac.Close();
            //ds.Tables[0].Columns.Remove("CatID");
            //gv1.DataSource = ds.Tables[0];
            //DataBind();
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }
    protected void btnLogoff_Click(object sender, EventArgs e)
    {
        System.Web.Security.FormsAuthentication.SignOut();
        Response.Redirect("http://localhost/xyzeve05/default.aspx");
    }
 
    protected void gv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv1.PageIndex = e.NewPageIndex;
        BindToGridFromWCF();
    }
}
