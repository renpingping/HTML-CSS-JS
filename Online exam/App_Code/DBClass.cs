using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// DBClass 的摘要说明
/// </summary>
public class DBClass
{
	public DBClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public SqlConnection GetConnection()//创建与数据库的连接，并返回SqlConnection类对象
    {
        string myStr = ConfigurationManager.ConnectionStrings["administratorConnectionString"].ToString();
        SqlConnection myConn = new SqlConnection(myStr);
        return myConn;
    }
    public void ExecNonQuery(SqlCommand myCmd)//执行SQL语句，并返回受影响的行数
    {
        try
        {
            if (myCmd.Connection.State != ConnectionState.Open)
            {
                myCmd.Connection.Open();
            }
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myCmd.Connection.State == ConnectionState.Open)
            {
                myCmd.Connection.Close();
            }
        }
    }
    public string ExecScalar(SqlCommand myCmd)//执行查询，并返回查询所返回的结果集众第一行的第一列的值
    {
        string strSql;
        try
        {
            if (myCmd.Connection.State != ConnectionState.Open)
            {
                myCmd.Connection.Open();
            }
            strSql = Convert.ToString(myCmd.ExecuteScalar());
            return strSql;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myCmd.Connection.State == ConnectionState.Open)
            {
                myCmd.Connection.Close();
            }
        }
    }
    public DataTable GetDataSet(SqlCommand myCmd, string TableName)//返回数据集的表的集合
    {
        SqlDataAdapter adapt;
        DataSet ds = new DataSet();
        try
        {
            if (myCmd.Connection.State != ConnectionState.Open)
            {
                myCmd.Connection.Open();
            }
            adapt = new SqlDataAdapter(myCmd);
            adapt.Fill(ds, TableName);
            return ds.Tables[TableName];
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myCmd.Connection.State == ConnectionState.Open)
            {
                myCmd.Connection.Close();
            }
        }
    }
    public SqlCommand GetCommandProc(string strProcName)//执行存储过程，返回SqlCommand类对象
    {
        SqlConnection myConn = GetConnection();
        SqlCommand myCmd = new SqlCommand();
        myCmd.Connection = myConn;
        myCmd.CommandText = strProcName;
        myCmd.CommandType = CommandType.StoredProcedure;
        return myCmd;
    }
    public SqlCommand GetCommandStr(string strSql)//执行查询语句，返回SqlCommand类对象
    {
        SqlConnection myConn = GetConnection();
        SqlCommand myCmd = new SqlCommand();
        myCmd.Connection = myConn;
        myCmd.CommandText = strSql;
        myCmd.CommandType = CommandType.Text;
        return myCmd;
    }
    public DataTable GetDataSetStr(string sqlStr, string TableName)//执行SQL语句，返回数据源的数据表
    {
        SqlConnection myConn = GetConnection();
        myConn.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter adapt = new SqlDataAdapter(sqlStr, myConn);
        adapt.Fill(ds, TableName);
        myConn.Close();
        return ds.Tables[TableName];
    }
}