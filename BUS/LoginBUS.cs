using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data.SqlClient;

namespace BUS
{
    public class LoginBUS
    {
        DataProvider dt = new DataProvider();
        public int Login(string user, string pass)
        {
            try
            {
                return dt.Login(user, pass);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
