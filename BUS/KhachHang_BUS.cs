using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data.SqlClient;

namespace BUS
{
    public class KhachHang_BUS
    {
        KhachHang_DAO khachHangDAO = new KhachHang_DAO();
        public List<KhachHang> ShowKhachHang()
        {
            try
            {
                return khachHangDAO.ShowKhachHang();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
