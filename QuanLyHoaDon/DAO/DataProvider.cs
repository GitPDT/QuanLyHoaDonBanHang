using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO
{
    public class DataProvider
    {
        SqlConnection cn;

        public DataProvider()
        {
            string cnStr = "Data Source=.;Initial Catalog=CoffeeShop;Integrated Security=True";
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

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;

            Connect();
            try
            {
                int number = (int)cmd.ExecuteScalar();

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
            cmd.CommandType = System.Data.CommandType.Text;

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
            cmd.CommandType = System.Data.CommandType.Text;

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
            cmd.CommandType = System.Data.CommandType.Text;

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
    }
}
