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

//public partial class ProductDisplay : System.Web.UI.Page
public partial class ProductDisplay : MyBasePage
{
    public ProductDisplay()
    {
        requireSSL = true;
    }
    Cart myCart = new Cart();  // shopping cart
    public DataSet ds = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["MYCART"] == null)
            {
                Session["MYCART"] = myCart;
            }
            else
            {
                myCart = (Cart)(Session["MYCART"]);
            }
            string PID = Request["PID"];

            IDataAccount ida = GenericFactory<BusinessLayer, IDataAccount>.CreateInstance();
            ds = ida.GetDataSetDBFromProductsByPID(PID);
            //string sql = "SELECT * FROM  Products WHERE ProductId=" + PID;
            //ds = DBFunctions.GetDataSetDB(sql);
            lblProdDesc.Text = ds.Tables[0].Rows[0]["ProductSDesc"].ToString();
            lblPrice.Text = "$" + ds.Tables[0].Rows[0]["Price"].ToString();

            Session["PRICE"] = ds.Tables[0].Rows[0]["Price"].ToString();
            Session["PRODDESC"] = ds.Tables[0].Rows[0]["ProductSDesc"].ToString();
            Session["PRODUCTID"] = ds.Tables[0].Rows[0]["ProductId"].ToString();
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }


    }
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        string pid = (string)Session["PRODUCTID"];
        string pname = (string)Session["PRODDESC"]; //short description
        string price = (string)Session["PRICE"];

        CartRow row = new CartRow();
        CartRow testrow = new CartRow();
        row.PID = pid;
        row.PName = pname;
        row.Price = price;
        row.Qty = txtQuantity.Text;  // count of how many to buy

        //  if item exists in shopping cart, remove first, then add
        //  with an updated total count
        int nTotalItem = myCart.list.Count;
        for (int nItem = 0; nItem < nTotalItem; nItem++)
        {
            testrow = (CartRow)myCart.list[nItem];
            if (testrow.PID == pid)
            {
                int qty = Int32.Parse(testrow.Qty);
                qty += 1;
                testrow.Qty = qty.ToString();
                myCart.list.RemoveAt(nItem);
                row = testrow;
                break;
            }
        }
        myCart.list.Add(row);
        //Cart.ShowCartTable(myCart, Table1, LabelTotal);
        lblAddToCart.Text = row.Qty + " items of " + row.PName + " added to your Shopping Cart";

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

    protected void btnViewCart_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewCart.aspx");
    }
}
