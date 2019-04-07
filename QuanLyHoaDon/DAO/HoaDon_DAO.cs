using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAO
{
    public class HoaDon_DAO:DataProvider
    {
        public DataTable LoadHoaDon()
        {
            string sql = "SELECT * FROM HOADON";
            return GetTable(sql);
        }
    }
}
