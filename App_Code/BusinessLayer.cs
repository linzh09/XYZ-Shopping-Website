using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

/// <summary>
/// Summary description for BusinessLayer
/// </summary>
public class BusinessLayer : IBusinessAuthentication, IDataAccount
{
    //IDataAuthentication idau = null;
    //IDataAccount idac = null;
    ////ICheckingActivity icac = null;
    //BaseState state; // state of the system
    //internal BaseState State
    //{
    //    get { return state; }
    //    set { state = value; }
    //}
    //public BusinessLayer()
    //{
    //    state = new PERFECT(this);
    //}
    //public BusinessLayer(IDataAccount idacc)
    //{
    //    //idau = idauth;
    //    idac = idacc;
    //}

    //public BusinessLayer() :
    //    this( GenericFactory<Repository, IDataAccount>.CreateInstance())
    //{
    //}
    //public static
    //    string CONNSTR = ConfigurationManager.ConnectionStrings["XYZEVEDSN"].ConnectionString;
    #region IBusinessAuthentication Members

    public string CheckUser(string uid, string pwd)
    {
        string sql = "select UserName from Users where Username='" +
            uid + "' and Password='" + pwd + "'";
        Object obj = DBFunctions.GetScalarDB(sql);
        if (obj != null)
            return obj.ToString();  // Username column
        else
            return "";  // means user not found
    }

    public string GetRolesForUser(string uname)
    {
        string roles = "";
        string connStr = ConfigurationManager.ConnectionStrings["XYZEVEDSN"].ConnectionString;
        SqlConnection conn = new SqlConnection(connStr);

        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("GetUserRoles", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Username", uname));
            SqlDataReader reader = cmd.ExecuteReader();

            ArrayList roleList = new ArrayList();
            while (reader.Read())
                roles += reader["Role"].ToString() + "|";
            if (roles != "")  // remove last "|"
                roles = roles.Substring(0, roles.Length - 1);
            conn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
        }
        return roles;
    }

    #endregion

    #region IDataAccount Members

    public DataSet GetDataSetDBFromProductsByPID(string PID)
    {
        string sql = "SELECT * FROM  Products WHERE ProductId=" + PID;
        DataSet ds = DBFunctions.GetDataSetDB(sql);
        return ds;
    }

    public DataSet GetDataSetDBFromProductsBycatID(string catID)
    {
        string sql = "SELECT * FROM  Products WHERE CATID=" + catID;
        DataSet ds = DBFunctions.GetDataSetDB(sql);
        return ds;
    }

    public object GetScalarDBFromUsers(string unm, string pw)
    {
        string sql = "SELECT UserID FROM  Users WHERE UserName='" + unm +
                "' and Password='" + pw + "'";
        object obj = DBFunctions.GetScalarDB(sql);
        return obj;
    }

    public DataSet GetDataSetDBFromCustomerInfosByUserID(string uid)
    {
        string sql = "SELECT * FROM  CustomerInfos WHERE UserID=" + uid;
        DataSet ds = DBFunctions.GetDataSetDB(sql);
        return ds;
    }

    public int GetNonQueryDBFromCustomerInfos(string addr2, string city, string state, string zipcode, string email, string ccnum, string cctype, string expir,string uid)
    {
        string sql = "Update CustomerInfos set Address='" + addr2 + "'," +
                        "City='" + city + "',"
                        + "State='" + state + "',"
                        + "Zipcode='" + zipcode + "',"
                        + "Email='" + email + "',"
                        + "CCNumber='" + ccnum + "',"
                        + "CCType='" + cctype + "',"
                        + "CCExpiration='" + expir + "'" + "where UserID=" + uid;
        int rows = DBFunctions.GetNonQueryDB(sql);
        return rows;
    }

    public object GetScalarDBFromOrders(SqlTransaction sqtr, SqlConnection con)
    {
        string sql0 = "SELECT MAX(OrderNo) AS MAXORDNO FROM Orders";
        SqlCommand cmd0 = new SqlCommand(sql0, con);
        cmd0.Transaction = sqtr;
        object obj = cmd0.ExecuteScalar();
        return obj;
    }

    public int GetNonQueryDBFromOrders(SqlTransaction sqtr, SqlConnection con,int orderNum, string s)
    {
        string sql1 = "INSERT INTO Orders (OrderNo,UserID, OrderDate) VALUES ("
                + orderNum.ToString() + ",'" + s + "','" +
                System.DateTime.Now.ToString() + "')";
        SqlCommand cmd1 = new SqlCommand(sql1, con);
        cmd1.Transaction = sqtr;
        int rows = cmd1.ExecuteNonQuery();
        return rows;
    }

    public int GetNonQueryDBFromOrderDetails(SqlTransaction sqtr, SqlConnection con, int orderNum, CartRow cr)
    {
        string sql2 = "INSERT INTO OrderDetails (OrderNo,ItemNo, ItemDesc, Qty, Price) VALUES ("
                        + orderNum.ToString() + "," + cr.PID +
                        ",'" + cr.PName.Replace("'", "''") + "'," +
                        cr.Qty + "," + cr.Price + ")";
        SqlCommand cmd2 = new SqlCommand(sql2, con);
        cmd2.Transaction = sqtr;

        int rows = cmd2.ExecuteNonQuery();
        return rows;
    }

    public int GetNonQueryDBUpdateOrders(SqlTransaction sqtr, SqlConnection con, int orderNum,double totalPrice,int nQty)
    {
        string sql3 = "UPDATE Orders SET TotalQty = " + nQty.ToString() + ", TotalCost = "
                + totalPrice.ToString() + " WHERE OrderNo = " + orderNum.ToString();
        SqlCommand cmd3 = new SqlCommand(sql3, con);
        cmd3.Transaction = sqtr;
        int rows = cmd3.ExecuteNonQuery();
        return rows;
    }

    public object GetScalarDBFromtblCustomerInfo(string s)
    {
        string sql4 = "Select Email from tblCustomerInfo where UserID=" + s;
        object obj = DBFunctions.GetScalarDB(sql4);
        return obj;
    }

    public object GetScalarDBFromUsersByUserID(SqlTransaction sqtr, SqlConnection con,string unm)
    {
        string sqlcheck = "select * from Users where Username='" +
                    unm + "'";
        SqlCommand cmd = new SqlCommand(sqlcheck, con);
        cmd.Transaction = sqtr;
        object obj = cmd.ExecuteScalar();
        return obj;
    }

    public int GetNonQueryDBFromUsers(SqlTransaction sqtr, SqlConnection con, string unm, string pwd, string pHint, string pAns)
    {
        string sql = "INSERT INTO Users (Username,Password,PHint,PAns) VALUES ('" +
                    unm + "','" + pwd + "','" + pHint + "','" + pAns + "')";

        SqlCommand cmd2 = new SqlCommand(sql, con);
        cmd2.Transaction = sqtr;
        int rows = cmd2.ExecuteNonQuery();
        return rows;
    }

    public object GetScalarDBFromUsersForUserID(SqlTransaction sqtr, SqlConnection con, string unm)
    {
        string sqluid = "select userid from Users where Username='" +
                    unm + "'";
        SqlCommand cmduid = new SqlCommand(sqluid, con);
        cmduid.Transaction = sqtr;
        object objuid = cmduid.ExecuteScalar();
        return objuid;
    }

    public int GetNonQueryDBFromCustomerInfos(SqlTransaction sqtr, SqlConnection con, string fnm, string lnm, string addr, string zip, string city, string state, string ccexpir, string ccnum, string cctype, string email,string userID)
    {
        string sqlc = "INSERT INTO CustomerInfos (UserID,FirstName,LastName,"
                    + "Address,ZipCode,City,State,CCNumber,CCExpiration,CCType,Email)"
                    + " VALUES (" +
                    userID + ",'" + fnm + "','" + lnm + "','" + addr + "','" +
                    zip + "','" + city + "','" + state + "','" + ccnum + "','" +
                    ccexpir + "','" + cctype + "','" + email + "')";

        SqlCommand cmdc = new SqlCommand(sqlc, con);
        cmdc.Transaction = sqtr;
        int rowsc = cmdc.ExecuteNonQuery();
        return rowsc;
    }

    public DataSet GetDataSetDBFromProductCategories()
    {
        string sql = "select * from ProductCategories";
        DataSet ds = DBFunctions.GetDataSetDB(sql);
        return ds;
    }

    public int GetNonQueryDBFromProducts(string shortDesc, string longDesc, string catID, string prodImage, string price, string inventory, string instock)
    {
        string sql = "Insert into Products (CatID,ProductSDesc,ProductLDesc,"
                + "ProductImage,Price,InStock,Inventory) Values (" +
                catID + ",'" + shortDesc + "','" + longDesc + "','" +
                prodImage + "'," + price + "," + instock + "," + inventory + ")";

        int rows = DBFunctions.GetNonQueryDB(sql);
        return rows;
    }

    public object GetScalarDBFromProductCategories(string catID)
    {
        string sql2 = "Select CatDesc from ProductCategories where CatID=" +
                        catID;
        object obj = DBFunctions.GetScalarDB(sql2);
        return obj;
    }

    public int GetNonQueryDBUpdateProducts(string pid, string shortDesc, string longDesc, string pimage, string price, string inventory, string instock)
    {
        string sql = "Update Products Set ProductSDesc='" +
                shortDesc + "',Inventory=" + inventory + ",ProductLDesc='" + longDesc + "',Price=" +
                price + ",ProductImage='" + pimage + "',InStock=" + instock + " where ProductID=" +
                pid;
        int rows = DBFunctions.GetNonQueryDB(sql);
        return rows;
    }

    public DataSet GetDataSetDBFromProducts()
    {
        string sql = "SELECT * FROM  Products";
        DataSet ds = DBFunctions.GetDataSetDB(sql);
        return ds;
    }

    public DataTable getDataTable(string un)
    {
        string sql = "select o.OrderNo,o.OrderDate,o.TotalQty,o.TotalCost from Users u,Orders o where u.Username='" + un + "' and u.UserID=o.UserID";
        //string sql = "select * from Users u,Orders o where u.Username='" + un + "' and u.UserID=o.UserID";
        DataTable dt = DBFunctions.GetDataTable(sql);
        return dt;
    }

    public int DeleteNonQueryDBFromProducts(int pid)
    {
        string sql = "delete from Products where ProductId=" +pid + "";
        int rows = DBFunctions.GetNonQueryDB(sql);
        return rows;
    }

    public bool GetScalarDBFromprod(int pid)
    {
        string sql = "select ProductId from Products where ProductId=" + pid + "";
        object obj = DBFunctions.GetScalarDB(sql);
        if (obj != "")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion
}