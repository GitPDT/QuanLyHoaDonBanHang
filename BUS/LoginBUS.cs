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
        public bool Login(string user, string pass)
        {
            try
            {
                return new DataProvider().Login(user, pass);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
