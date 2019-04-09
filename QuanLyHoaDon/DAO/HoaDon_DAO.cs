using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class HoaDon_DAO : DataProvider
    {
        public DataTable LoadHoaDon()
        {
            string sql = "SELECT * FROM HOADON";
            return GetTable(sql);
        }
        public bool AddHoaDon(HoaDon hoadon)
        {
            string sql = "INSERT INTO HOADON(MaHD, Ngay, TenKH, DiaChi, SDT, MaHH, TenHH, SoLuong, DonViTinh, DonGia, ChietKhau, ThanhTien, DaTra, ConNo) " +
                "VALUES('"+ hoadon.MaHD +"', '"+ hoadon.Ngay +"','"+ hoadon.TenKH +"','"+ hoadon.DiaChi +
                "','"+ hoadon.SDT +"','"+ hoadon.MaHH+"','"+ hoadon.TenHH +"','" + hoadon.SoLuong +"','"+
                        hoadon.DonViTinh +"','"+ hoadon.DonGia +"','"+ hoadon.ChietKhau +"','"+ hoadon.ThanhTien +"','"+ hoadon.DaTra+"','"+ hoadon.ConNo +"')";
            Connect();
            try
            {
                int number = myExecuteNoneQuery(sql);
                if (number > 0)
                {
                    return true;
                }
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
    }
}
