using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class KhachHang_DAO:DataProvider
    {
        public bool AddCustomer(KhachHang cus)
        {
            string sql = "INSERT INTO KHACHHANG(MaKH, TenKH, DiaChi, GioiTinh, SoDienThoai) VALUES('"
                + cus.MaKH + "' , N'" + cus.TenKH + "' , N'" + cus.DiaChi + "' , N'" + cus.GioiTinh + "' , '" + cus.SDT+"')";
            try
            {
                int number =  myExecuteNoneQuery(sql);
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
        }
        public List<KhachHang> ShowKhachHang()
        {
            List<KhachHang> list = new List<KhachHang>();
            string sql = "Select * from KhachHang";
            try
            {
                SqlDataReader reader = myExecuteReader(sql);
                while (reader.Read())
                {
                    string id = reader[0].ToString();
                    string name = reader[1].ToString();
                    string address = reader[2].ToString();
                    string phone = reader[4].ToString();
                    string sex = reader[3].ToString();
                    KhachHang cus = new KhachHang(id, name, address, sex, phone);
                    list.Add(cus);
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
    }
}
