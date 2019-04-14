using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DataProvider
    {
        SqlConnection cn;

        public DataProvider()
        {
            string cnStr = "Data Source=.;Initial Catalog=QuanLyHoaDon;Integrated Security=True";
            cn = new SqlConnection(cnStr);
        }

        public void Connect()
        {
            try
            {
                if (cn != null && cn.State == System.Data.ConnectionState.Closed)
                    cn.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Disconnect()
        {
            if (cn != null && cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public bool Login(string user, string pass)
        {
            string sql = "SELECT COUNT(UserName) FROM Users WHERE Username = '" + user + "' AND Password = '" + pass + "'";

            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = cn;
            //cmd.CommandText = sql;
            //cmd.CommandType = System.Data.CommandType.Text;

            Connect();
            try
            {
                int number = (int)myEXecuteScalar(sql);

                if (number > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }
        public int myExecuteNoneQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = CommandType.Text;

            Connect();
            try
            {
                int noOfRows = cmd.ExecuteNonQuery();
                return noOfRows;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }
        public int myEXecuteScalar(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = CommandType.Text;

            Connect();
            try
            {
                int num = (int)cmd.ExecuteScalar();
                return num;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }

        }
        public SqlDataReader myExecuteReader(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = CommandType.Text;

            Connect();
            try
            {
                return cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public DataTable GetTable(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            int numberOfRows = da.Fill(dt);
            if (numberOfRows > 0)
                return dt;
            else
                return null;
        }
    }
}
