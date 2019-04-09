using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class HoaDon_BUS
    {
        HoaDon_DAO HoaDonDAO = new HoaDon_DAO();
        public DataTable ShowHoaDon()
        {
            return HoaDonDAO.LoadHoaDon();
        }
        public bool AddHoaDon(HoaDon hd)
        {
            try
            {
                return HoaDonDAO.AddHoaDon(hd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
