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
//using System.Data;
using System.Data.SqlClient;

//public partial class Products : System.Web.UI.Page
public partial class Products : MyBasePage
{
    public Products()
    {
        requireSSL = true;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string catID = Request["catID"];
            if (catID == null)
                return; // no catid
            catID = Utils.StripPunctuation(catID);
            Session["CATID"] = catID;
           try
            {
                IDataAccount ida = GenericFactory<BusinessLayer, IDataAccount>.CreateInstance();
                //string sql = "SELECT * FROM  Products WHERE CATID=" + catID;
                //DataSet ds = DBFunctions.GetDataSetDB(sql);
                DataSet ds = ida.GetDataSetDBFromProductsBycatID(catID);
                gv1.DataSource = ds.Tables[0];
                ds.Tables[0].Columns.Remove("CatID");
                ds.Tables[0].Columns.Remove("ProductLDesc");

                gv1.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }
    }
}
