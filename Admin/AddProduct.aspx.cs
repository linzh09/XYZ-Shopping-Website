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

//public partial class Admin_AddProduct : System.Web.UI.Page
public partial class Admin_AddProduct : MyBasePage
{
    public Admin_AddProduct()
    {
        requireSSL = true;
    }
    IDataAccount ida = GenericFactory<BusinessLayer, IDataAccount>.CreateInstance();
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblTime1.Text = DateTime.Now.ToString();
        // Put user code to initialize the page here
        if (!Page.IsPostBack)
        {
            //string sql = "select * from ProductCategories";
            //DataSet ds = DBFunctions.GetDataSetDB(sql);
            DataSet ds = ida.GetDataSetDBFromProductCategories();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ddlCategory.Items.Add(ds.Tables[0].Rows[i]["CatDesc"].ToString());
                ddlCategory.Items[i].Value = ds.Tables[0].Rows[i]["CatID"].ToString();

            }

        }
    }
    protected void btnAddProduct_Click(object sender, EventArgs e)
    {
        try
        {
            string shortDesc = txtShortDesc.Text;
            string longDesc = txtLongDesc.Text;
            string catID = ddlCategory.SelectedItem.Value;
            string prodImage = txtImageFile.Text;
            string price = txtPrice.Text;
            string inventory = txtInventory.Text;
            string instock = "0";
            if (chkInStock.Checked == true)
                instock = "1";

            //string sql = "Insert into Products (CatID,ProductSDesc,ProductLDesc,"
            //    + "ProductImage,Price,InStock,Inventory) Values (" +
            //    catID + ",'" + shortDesc + "','" + longDesc + "','" +
            //    prodImage + "'," + price + "," + instock + "," + inventory + ")";

            //int rows = DBFunctions.GetNonQueryDB(sql);
            int rows = ida.GetNonQueryDBFromProducts(shortDesc, longDesc, catID, prodImage, price, inventory, instock);
            if (rows > 0)
                lblStatus.Text = "Product Added successfully";
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }
}
