using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
//using System.Data;

/// <summary>
/// Summary description for IDataAccount
/// </summary>
public interface IDataAccount
{
    DataSet GetDataSetDBFromProductsByPID(string PID);
    DataSet GetDataSetDBFromProductsBycatID(string catID);
    object GetScalarDBFromUsers(string unm, string pw);
    DataSet GetDataSetDBFromCustomerInfosByUserID(string uid);
    int GetNonQueryDBFromCustomerInfos(string addr2, string city, string state, string zipcode, string email, string ccnum, string cctype, string expir, string uid);
    object GetScalarDBFromOrders(SqlTransaction sqtr, SqlConnection con);
    int GetNonQueryDBFromOrders(SqlTransaction sqtr, SqlConnection con,int orderNum,string s);
    int GetNonQueryDBFromOrderDetails(SqlTransaction sqtr, SqlConnection con,int orderNum,CartRow cr);
    int GetNonQueryDBUpdateOrders(SqlTransaction sqtr, SqlConnection con, int orderNum,double totalPrice,int nQty);
    object GetScalarDBFromtblCustomerInfo(string s);
    object GetScalarDBFromUsersByUserID(SqlTransaction sqtr, SqlConnection con,string unm);
    int GetNonQueryDBFromUsers(SqlTransaction sqtr, SqlConnection con, string unm, string pwd, string pHint, string pAns);
    object GetScalarDBFromUsersForUserID(SqlTransaction sqtr, SqlConnection con, string unm);
    int GetNonQueryDBFromCustomerInfos(SqlTransaction sqtr, SqlConnection con, string fnm, string lnm, string addr, string zip, string city, string state, string ccexpir, string ccnum, string cctype, string email,string userID);
    DataSet GetDataSetDBFromProductCategories();
    int GetNonQueryDBFromProducts(string shortDesc, string longDesc, string catID, string prodImage, string price, string inventory, string instock);
    object GetScalarDBFromProductCategories(string catID);
    int GetNonQueryDBUpdateProducts(string pid, string shortDesc, string longDesc, string pimage, string price, string inventory, string instock);
    DataSet GetDataSetDBFromProducts();
    DataTable getDataTable(string un);
    int DeleteNonQueryDBFromProducts(int pid);
    bool GetScalarDBFromprod(int pid);

}