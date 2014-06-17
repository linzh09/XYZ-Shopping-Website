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

//public partial class Accounting_ShowCart : System.Web.UI.Page
public partial class Accounting_ShowCart : MyBasePage
{
    public Accounting_ShowCart()
    {
        requireSSL = true;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Cart ct = (Cart)Session["MYCART"];
        Cart.ShowCartTable(ct, Table1);
    }
}
