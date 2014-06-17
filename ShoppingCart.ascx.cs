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

public partial class ShoppingCart : System.Web.UI.UserControl
{
    Cart myCart = new Cart();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if ((Session["MYCART"] == null))
            {
                Session["MYCART"] = myCart;
            }
            else
            {
                myCart = (Cart)(Session["MYCART"]);
            }
            DataTable dt = Cart.getCartTable(myCart);
            gv1.DataSource = dt;
            gv1.DataBind();
        }
        //Cart.ShowCartTable(myCart, tblCart);
    }
    
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Session["MYCARTOLD"] = myCart;
        //myCart.list.Clear();
        //Session["MYCART"] = myCart;
        // if you use the above two lines instead of the following
        // line, you end up clearing the Session["MYOLDCART"]
        // unintentionally.
        Session["MYCART"] = null;


        //Response.Redirect("ViewCart.aspx");
        // The above line should be the actual page in which the 
        // shopping cart user control resides, as given below
        string reqPage = Request["SCRIPT_NAME"];
        Response.Redirect(reqPage);
    }
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Session["MYCARTOLD"] != null)
        {
            myCart = (Cart)Session["MYCARTOLD"];
            Session["MYCART"] = myCart;

            //Response.Redirect("ViewCart.aspx");
            // The above line should be the actual page in which the 
            // shopping cart user control resides, as given below
            string reqPage = Request["SCRIPT_NAME"];
            Response.Redirect(reqPage);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ////Session["MYCARTOLD"] = myCart;  // will not work
        //// as we are clearing myCart in the following line.
        //// To make it work properly, the above call should
        //// use a clone object of myCart. For this, we have 
        //// to provide a clone method in the Cart class.
        //Session["MYCARTOLD"] = myCart.Clone();
        //// clone is important here

        //myCart.list.Clear();
        
        //// first row is heading, last row is total
        //for (int i = 1; i < tblCart.Rows.Count - 1; i++)
        //{

        //    CartRow cr = new CartRow();
        //    cr.PID = tblCart.Rows[i].Cells[0].Text;
        //    if (cr.PID != "")  // not shipping/handling price
        //    {
        //        if (int.Parse(((TextBox)(tblCart.Rows[i].Cells[2].Controls[0])).Text) > 0)
        //        {  // if Qty is greater than 0
        //            cr.PName = tblCart.Rows[i].Cells[1].Text;
        //            cr.Qty = ((TextBox)(tblCart.Rows[i].Cells[2].Controls[0])).Text;
        //            cr.Price = tblCart.Rows[i].Cells[3].Text.Substring(1, tblCart.Rows[i].Cells[3].Text.Length - 1);
        //                        // exclude $ from price
        //            myCart.list.Add(cr);
        //        }
        //    }
        //    else
        //    {
        //        cr.PName = "Shipping/Handling";
        //        cr.Price = tblCart.Rows[i].Cells[4].Text.Substring(1,
        //            tblCart.Rows[i].Cells[4].Text.Length - 1); // price without $
        //        myCart.list.Add(cr);
        //    }
        //}
        //Session["MYCART"] = myCart;

        ////Cart.ShowCartTable(myCart,Table2);  
        //// uncomment above line and comment the Response.Redirect
        //// line to see interesting bug in updating cart quantity

        ////Response.Redirect("ViewCart.aspx");
        //// The above line should be the actual page in which the 
        //// shopping cart user control resides, as given below
        //string reqPage = Request["SCRIPT_NAME"];
        //Response.Redirect(reqPage);


        //Session["MYCARTOLD"] = myCart;  // will not work
        // as we are clearing myCart in the following line.
        // To make it work properly, the above call should
        // use a clone object of myCart. For this, we have 
        // to provide a clone method in the Cart class.
        Session["MYCARTOLD"] = myCart.Clone();
        // clone is important here

        myCart.list.Clear();
        
        // first row is heading, last row is total
        for (int i = 1; i < gv1.Rows.Count + 1; i++)
        {

            CartRow cr = new CartRow();
            cr.PID = ((Label)gv1.Rows[i-1].Cells[0].FindControl("lblProductID")).Text;
            if (cr.PID != "" && ((Label)gv1.Rows[i - 1].Cells[1].FindControl("lblProductName")).Text != "Shipping/Handling")  // not shipping/handling price
            {
                if (int.Parse(((TextBox)gv1.Rows[i-1].Cells[2].FindControl("lblQuantity")).Text) > 0)
                {  // if Qty is greater than 0
                    cr.PName = ((Label)gv1.Rows[i-1].Cells[1].FindControl("lblProductName")).Text;
                    cr.Qty = ((TextBox)gv1.Rows[i-1].Cells[2].FindControl("lblQuantity")).Text;
                    cr.Price = ((Label)gv1.Rows[i-1].Cells[3].FindControl("lblPriceItem")).Text;
                                // exclude $ from price
                    myCart.list.Add(cr);
                }
            }
            //else
            //{
            //    cr.PName = "Shipping/Handling";
            //    cr.Qty = "";
            //    cr.Price =((Label)gv1.Rows[i-1].Cells[3].FindControl("lblPriceItem")).Text; // price without $
            //    myCart.list.Add(cr);
            //}
        }
        Session["MYCART"] = myCart;

        //Cart.ShowCartTable(myCart,Table2);  
        // uncomment above line and comment the Response.Redirect
        // line to see interesting bug in updating cart quantity

        //Response.Redirect("ViewCart.aspx");
        // The above line should be the actual page in which the 
        // shopping cart user control resides, as given below
        string reqPage = Request["SCRIPT_NAME"];
        Response.Redirect(reqPage);
    }
    protected void gv1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gr = e.Row;
        Control ct = gr.FindControl("lblProductName");
        Control ct1 = gr.FindControl("lblQuantity");
        Control ct2 = gr.FindControl("lblPriceItem");
        if (ct != null)
        {
            Label lblP = (Label)ct;
            TextBox tb = (TextBox)ct1;
            Label lblP2 = (Label)ct2;
            string ProductName = lblP.Text;
            string Qty = tb.Text;
            string price=lblP2.Text;
            if (ProductName == "Shipping/Handling" || price == "Total")
            {
                tb.Visible = false;
            }
        }
        //if (((Label)e.Row.FindControl("lblProductName")).Text == "Shipping/Handling")
        //{
        //    e.Row.FindControl("lblQuantity").Visible = false;
        //}
        //if (e.Row.Cells[1].Text == "Shipping/Handling")
        //{
        //    e.Row.Cells[2].Visible = false;
        //}
        //if (e.Row.Cells[1].Text == "")
        //{
        //    e.Row.Cells[2].Visible = false;
        //}
    }
}
