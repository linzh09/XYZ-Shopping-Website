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

//public partial class Admin_EditProduct : System.Web.UI.Page
public partial class Admin_EditProduct : MyBasePage
{
    public Admin_EditProduct()
    {
        requireSSL = true;
    }
    IDataAccount ida = GenericFactory<BusinessLayer, IDataAccount>.CreateInstance();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string pid = "";
            string dd = Request["PID"];
            if (dd == null)
                pid = "-1";
            else
                pid = Request["PID"];
            try
            {
                //string sql = "select * from Products where ProductID=" +
                //    pid;
                //DataSet ds = DBFunctions.GetDataSetDB(sql);
                DataSet ds = ida.GetDataSetDBFromProductsByPID(pid);
                int rows = ds.Tables[0].Rows.Count;
                if (rows == 0)
                {
                    lblStatus.Text = "No Product ID was specified, please " +
                        "go to View Products Page and select a product first";
                }
                else
                {
                    // get category ID
                    string catID = ds.Tables[0].Rows[0]["CatID"].ToString();
                    //string sql2 = "Select CatDesc from ProductCategories where CatID=" +
                    //    catID;
                    //object obj = DBFunctions.GetScalarDB(sql2);
                    object obj = ida.GetScalarDBFromProductCategories(catID);
                    string catName = "";
                    if (obj != null)
                        catName = obj.ToString();
                    lblCategory.Text = catName;

                    lblProductID.Text = ds.Tables[0].Rows[0]["ProductID"].ToString();
                    txtShortDesc.Text = ds.Tables[0].Rows[0]["ProductSDesc"].ToString();
                    txtLongDesc.Text = ds.Tables[0].Rows[0]["ProductLDesc"].ToString();
                    txtPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                    txtImageFile.Text = ds.Tables[0].Rows[0]["ProductImage"].ToString();
                    bool instock = (bool)ds.Tables[0].Rows[0]["InStock"];
                    if (instock == true)
                        chkInStock.Checked = true;
                    else
                        chkInStock.Checked = false;
                    txtInventory.Text = ds.Tables[0].Rows[0]["Inventory"].ToString();
                    imgProduct.ImageUrl = "../PImages/" + txtImageFile.Text;

                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string pid = lblProductID.Text;
            string shortDesc = txtShortDesc.Text;
            string longDesc = txtLongDesc.Text.Replace("'", "''");
            string price = txtPrice.Text;
            string instock = "0";
            bool bInstock = chkInStock.Checked;
            if (bInstock == true)
                instock = "1";
            string pimage = txtImageFile.Text;
            string inventory = txtInventory.Text;

            //string sql = "Update Products Set ProductSDesc='" +
            //    shortDesc + "',Inventory=" + inventory + ",ProductLDesc='" + longDesc + "',Price=" +
            //    price + ",ProductImage='" + pimage + "',InStock=" + instock + " where ProductID=" +
            //    pid;
            //int rows = DBFunctions.GetNonQueryDB(sql);
            int rows = ida.GetNonQueryDBUpdateProducts(pid, shortDesc, longDesc, pimage, price, inventory, instock);
            if (rows > 0)
                lblStatus.Text = "Product specs updated successfully";
         }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }
}
