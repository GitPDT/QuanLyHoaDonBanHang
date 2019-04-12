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
        public List<HoaDon> ShowHoaDon()
        {
            string sql = "SELECT * FROM HOADON";
            try
            {
                List<HoaDon> list = new List<HoaDon>();
                SqlDataReader reader = myExecuteReader(sql);
                while (reader.Read())
                {
                    string maHD = reader[0].ToString();
                    DateTime ngay = DateTime.Parse(reader[1].ToString());
                    string tenKH = reader[2].ToString();
                    string diaChi = reader[3].ToString();
                    string sdt = reader[4].ToString();
                    string maHH = reader[5].ToString();
                    string tenHH = reader[6].ToString();
                    int soLuong = int.Parse(reader[7].ToString());
                    string dvt = reader[8].ToString();
                    int donGia = int.Parse(reader[9].ToString());
                    int chietKhau = int.Parse(reader[10].ToString());
                    int thanhTien = int.Parse(reader[11].ToString());
                    int daTra = int.Parse(reader[12].ToString());
                    int conNo = int.Parse(reader[13].ToString());

                    HoaDon hd = new HoaDon(maHD, ngay, tenKH, diaChi, sdt, maHH, tenHH, soLuong, dvt, donGia, chietKhau, thanhTien, daTra, conNo);
                    list.Add(hd);
                }
                return list;

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
        public bool AddHoaDon(HoaDon hoadon)
        {
            string sql = "INSERT INTO HOADON(MaHD, Ngay, TenKH, DiaChi, SDT, MaHH, TenHH, SoLuong, DonViTinh, DonGia, ChietKhau, ThanhTien, DaTra, ConNo) " +
                "VALUES('" + hoadon.MaHD + "', N'" + hoadon.Ngay + "',N'" + hoadon.TenKH + "',N'" + hoadon.DiaChi +
                "','" + hoadon.SDT + "','" + hoadon.MaHH + "',N'" + hoadon.TenHH + "','" + hoadon.SoLuong + "',N'" +
                        hoadon.DonViTinh + "','" + hoadon.DonGia + "','" + hoadon.ChietKhau + "','" + hoadon.ThanhTien + "','" + hoadon.DaTra + "','" + hoadon.ConNo + "')";
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
        public bool DeleteHoaDon(string maHD)
        {
            string sql = "DELETE FROM HOADON WHERE MaHD = '" + maHD + "'";
            int numberOfRow = myExecuteNoneQuery(sql);
            try
            {
                if (numberOfRow > 0)
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
        }
    }
}
