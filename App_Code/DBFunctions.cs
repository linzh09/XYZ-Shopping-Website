using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Threading;

/// <summary>
/// Summary description for DBFunctions
/// </summary>
public class DBFunctions
{
    public static string CONNSTR =
      ConfigurationManager.ConnectionStrings["XYZEVEDSN"].ConnectionString;

    public DBFunctions()
	{
	}

    public static DataTable GetDataTable(string sql)
    {
        SqlConnection conn = new SqlConnection(CONNSTR);
        DataTable dt = null;
        try
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            conn.Close();
        }
        return dt;
    }


    public static object 
        GetScalarParameterizedDB(string sql, SqlParameter[] pArr)
    {
        SqlConnection conn = new SqlConnection(CONNSTR);
        object obj = null;
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            for (int i = 0; i < pArr.Length; i++)
                cmd.Parameters.Add(pArr[i]);
            obj = cmd.ExecuteScalar();
            conn.Close();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close(); // very important with databases
        }
        return obj;

    }

    public static object GetScalarDB(string sql)
    {
        SqlConnection conn = new SqlConnection(CONNSTR);
        object obj = null;
        try
        {
            conn.Open();
             SqlCommand cmd = new SqlCommand(sql, conn);
            obj = cmd.ExecuteScalar();
            conn.Close();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close(); // very important with databases
        }
        return obj;

    }

  

    public static int GetNonQueryDB(string sql)
    {
        SqlConnection conn = new SqlConnection(CONNSTR);
        int rows = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            rows = cmd.ExecuteNonQuery();
            conn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close(); // very important with databases
        }
        return rows;
    }

    public static DataSet GetDataSetDB(string sql)
    {
        SqlConnection conn = new SqlConnection(CONNSTR);
        DataSet ds = null;
        try
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            ds = new DataSet();
            //Thread.Sleep(6000); // milliseconds
            da.Fill(ds);
            conn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close(); // very important with databases

        }
        return ds;
    }
}
