using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace UniSharing
{
    public class DAO_databaseControl
    {
        private static SqlConnection connection;
        public static SqlConnection Connection
        {
            get
            {
                //获取连接字符串，若无，则从web.config获取
                string connString = ConfigurationManager.ConnectionStrings["sqlserver"].ToString();
                if(connection==null||connection.State== ConnectionState.Closed)
                {
                    connection = new SqlConnection(connString);
                    connection.Open();
                }
                return connection;
            }
        }

        /// <summary>
        /// 无参数执行返回DataTable数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataSet(string sql)
        {
            SqlCommand command = new SqlCommand(sql, Connection);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
            //关闭连接
            Connection.Close();
            return ds.Tables[0];
        }

        /// <summary>
        /// 有参数执行返回DataTable数据集
        /// </summary>
        /// <param name="sql">z字符串</param>
        /// <param name="sqlParameter">变量</param>
        /// <returns></returns>
        public static DataTable GetDataSet(string sql, SqlParameter[] sqlParameter)
        {
            SqlCommand command = new SqlCommand(sql, Connection);
            foreach (SqlParameter parameter in sqlParameter)
            {
                command.Parameters.Add(parameter);
            }
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
            //关闭连接
            Connection.Close();
            return ds.Tables[0];
        }

        /// <summary>
        /// 无参数执行返回受影响行数
        /// </summary>
        /// <param name="sql"></param >
        /// <returns></returns>
        public static int ExecuteSql(string sql)
        {
            SqlCommand command = new SqlCommand(sql, Connection);
            int ret = command.ExecuteNonQuery();
            //关闭连接
            Connection.Close();
            return ret;
        }

        /// <summary>
        /// 有参数执行返回受影响函数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParameter"></param>
        /// <returns></returns>
        public static int ExecuteSql(string sql, SqlParameter[] sqlParameter)
        {
            SqlCommand command = new SqlCommand(sql, Connection);
            foreach (SqlParameter parameter in sqlParameter)
            {
                command.Parameters.Add(parameter);
            }
            int ret = command.ExecuteNonQuery();
            //关闭连接
            Connection.Close();
            return ret;
        }
    }
}