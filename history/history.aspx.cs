using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

//public partial class history_history : System.Web.UI.Page
public partial class history_history : MyBasePage
{
    public history_history()
    {
        requireSSL = true;
    }
    IDataAccount ida = GenericFactory<BusinessLayer, IDataAccount>.CreateInstance();
    protected void Page_Load(object sender, EventArgs e)
    {

        string s =(string)Session["ADMINUID"];
        DataTable dt = ida.getDataTable(s);
        gv1.DataSource = dt;
        gv1.DataBind();  
    }
}