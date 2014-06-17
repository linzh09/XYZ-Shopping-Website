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

//public partial class Accounting_CustomerBalances : System.Web.UI.Page
public partial class Accounting_CustomerBalances : MyBasePage
{
    public Accounting_CustomerBalances()
    {
        requireSSL = true;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
