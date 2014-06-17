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

//public partial class _Default : System.Web.UI.Page
public partial class _Default : MyBasePage
{
    public _Default()
    {
        requireSSL = true;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
