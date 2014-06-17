using System;
using System.Collections;
using System.Web.UI.WebControls;
using System.Data;

public class CartRow  // for one item in the shopping cart
{
    public string PID;
    public string PName;
    public string Price;
    public string Qty;
}


public class Cart : ICloneable  // complete shopping cart, each item stored in ArrayList
{
   
    public ArrayList list = new ArrayList(20);  // maximum of 20 items

    public object Clone()   // needed in implementing shopping
                            // "Cancel Last Change" functionality.
    {
        Cart clone = new Cart();
        clone.list = (ArrayList)this.list.Clone();
        return clone;
    }

    public static void ShowCartTable(Cart myCart, System.Web.UI.WebControls.Table Table1)
    {
        int nTotalItem = myCart.list.Count;
        double dTotal = 0.0;

        // Create appropriate table headings
        Table1.Rows.Clear();
        
        TableRow trowh = new TableRow();  // heading row
        
        TableCell c1h = new TableCell();
        TableCell c2h = new TableCell();
        TableCell c3h = new TableCell();
        TableCell c4h = new TableCell();
        TableCell c5h = new TableCell();
        c1h.Text = "<b>Product ID</b>";
        c2h.Text = "<b>Product Name</b>";
        c3h.Text = "<b>Quantity</b>";
        c4h.Text = "<b>Price/Item</b>";
        c5h.Text = "<b>Total</b>";
        trowh.Cells.Add(c1h);
        trowh.Cells.Add(c2h);
        trowh.Cells.Add(c3h);
        trowh.Cells.Add(c4h);
        trowh.Cells.Add(c5h);
        Table1.Rows.Add(trowh);

        TableCell shipc1 = new TableCell();  // show shipping cells at bottom
        TableCell shipc2 = new TableCell();
        TableCell shipc3 = new TableCell();
        TableCell shipc4 = new TableCell();
        TableCell shipc5 = new TableCell();


        for (int nItem = 0; nItem < nTotalItem; nItem++)
        {
            TableRow trow = new TableRow();
            
            CartRow row = (CartRow)myCart.list[nItem];

            TableCell c1 = new TableCell();
            TableCell c2 = new TableCell();
            TableCell c3 = new TableCell();
            TableCell c4 = new TableCell();
            TableCell c5 = new TableCell();

            if (row.PID != "") // not shipping and handling
                c1.Text = row.PID;
            else
                shipc1.Text = "ShippingAndHandling";

            if (row.PID != "") // not shipping and handling
                c2.Text = row.PName;
            else
                shipc2.Text = "";

            if (row.PID != "") // not shipping and handling
            {
                TextBox countT = new TextBox();
                countT.MaxLength = 4;
                countT.Width = 30; // pixels
                countT.Text = row.Qty;
                c3.Controls.Add(countT);

                c4.Text = "$" + row.Price;
                double rowPrice = Double.Parse(row.Price)
                    * Double.Parse(row.Qty);
                c5.Text = "$" + rowPrice.ToString();
                dTotal = dTotal + rowPrice;
            }
            else  // shipping and handling
            {
                shipc3.Text = "Shipping and Handling";
                shipc5.Text = row.Price;
            }


            if (row.PID != "") // not shipping and handling
            {
                trow.Cells.Add(c1);
                trow.Cells.Add(c2);
                trow.Cells.Add(c3);
                trow.Cells.Add(c4);
                trow.Cells.Add(c5);

                Table1.Rows.Add(trow);
            }

        }
        // now add shipping/handling row if it was encountered
        if (shipc1.Text == "ShippingAndHandling")
        {
            shipc1.Text = "";
            TableRow shiprow = new TableRow();
            dTotal = dTotal + Double.Parse(shipc5.Text);
            shipc5.Text = "$" + shipc5.Text;
            shiprow.Cells.Add(shipc1);
            shiprow.Cells.Add(shipc2);
            shiprow.Cells.Add(shipc3);
            shiprow.Cells.Add(shipc4);
            shiprow.Cells.Add(shipc5);
            Table1.Rows.Add(shiprow);
        }

        //LabelTotal.Text = dTotal.ToString();
        TableRow trowt = new TableRow();
        TableCell c1t = new TableCell();
        TableCell c2t = new TableCell();
        TableCell c3t = new TableCell();
        TableCell c4t = new TableCell();
        TableCell c5t = new TableCell();
        c1t.Text = "";
        c2t.Text = "";
        c3t.Text = "";
        c4t.Text = "<font color='blue'><b>Grand Total</b></font>";
        c5t.Text = "<b>$" + dTotal.ToString() + "</b>";
        trowt.Cells.Add(c1t);
        trowt.Cells.Add(c2t);
        trowt.Cells.Add(c3t);
        trowt.Cells.Add(c4t);
        trowt.Cells.Add(c5t);
        Table1.Rows.Add(trowt);
    }
    public static DataTable getCartTable(Cart myCart)
    {
        DataTable Cpdt = new DataTable();
        Cpdt.Columns.Add(new DataColumn("lblProductID", typeof(String)));
        Cpdt.Columns.Add(new DataColumn("lblProductName", typeof(String)));
        Cpdt.Columns.Add(new DataColumn("lblQuantity", typeof(String)));
        Cpdt.Columns.Add(new DataColumn("lblPriceItem", typeof(String)));
        Cpdt.Columns.Add(new DataColumn("lblTotal", typeof(String)));
        Cpdt.AcceptChanges();
        //Cpdt.PrimaryKey = new DataColumn[] { Cpdt.Columns[0] };
        Cpdt.AcceptChanges();
        //DataRow dr=dt.NewRow();
        //Cart myCart = new Cart();
        //myCart = (Cart)(Session["MYCART"]);
        int nTotalItem = myCart.list.Count;
        CartRow testrow = new CartRow();
        double sun = 0;
        for (int nItem = 0; nItem < nTotalItem; nItem++)
        {
            DataRow dr = Cpdt.NewRow();
            testrow = (CartRow)myCart.list[nItem];
            if (testrow.PID.ToString() != "")
            {
                dr["lblProductID"] = testrow.PID.ToString();
                dr["lblProductName"] = testrow.PName.ToString();
                dr["lblQuantity"] = testrow.Qty.ToString();
                dr["lblPriceItem"] = testrow.Price.ToString();

                double total = (Double.Parse(testrow.Qty)) * (Double.Parse(testrow.Price));
                sun += total;
                dr["lblTotal"] = total.ToString();
            }
            else
            {
                dr["lblProductID"] = testrow.PID.ToString();
                dr["lblProductName"] = testrow.PName.ToString();
                dr["lblQuantity"] = testrow.Qty.ToString();
                dr["lblPriceItem"] = testrow.Price.ToString();

                double total = (Double.Parse(testrow.Price));
                sun += total;
                dr["lblTotal"] = total.ToString();
            }
            //dr["Product ID"] = testrow.PID;
            //dr["Product Name"] = testrow.PName;
            //dr["Quantity"] = testrow.Qty;
            //dr["Price/Item"] = testrow.Price;
            //int total = (Int32.Parse(testrow.Qty)) * (Int32.Parse(testrow.Price));
            //dr["Total"] = total.ToString();
            Cpdt.Rows.Add(dr);
            Cpdt.AcceptChanges();
        }
        DataRow dr1 = Cpdt.NewRow();
        dr1["lblProductID"] = "";
        dr1["lblProductName"] ="";
        dr1["lblQuantity"] ="";
        dr1["lblPriceItem"] = "Total";
        dr1["lblTotal"] = sun.ToString();
        Cpdt.Rows.Add(dr1);
        return Cpdt;
        //string sql = "select * from OrderDetails where OrderNo=(select MAX(OrderNo) from OrderDetails)";
        //DataTable dt = DBFunctions.GetDataTable(sql);
        //dt.Rows.Add(dr);
        //gv1.DataSource = Cpdt;
        //gv1.DataBind();
    }
}

