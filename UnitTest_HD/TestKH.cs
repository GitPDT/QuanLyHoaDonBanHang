using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DTO;
using QuanLyHoaDon;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest_HD
{
    [TestClass]
    public class TestKH
    {
        KhachHang_DAO dao = new KhachHang_DAO();
        [TestMethod]
        public void ThemKhachHang_NhapDungThongTin()
        {
            string id = "P", name = "s", address = "s", sex = "s", phone = "5";
        
            KhachHang cus = new KhachHang(id, name, address, sex, phone);


            List<KhachHang> list = new List<KhachHang>();
            list = dao.ShowKhachHang();
            int count = list.Count();
            int index = 0;

            dao.AddCustomer(cus);
            list = dao.ShowKhachHang();
            Assert.AreEqual(count + 1, list.Count());
            foreach (KhachHang custom in list)
            {
                if (custom.MaKH == id)
                    break;
                index++;

            }
            Assert.AreEqual(id, list[index].MaKH);
            Assert.AreEqual(name, list[index].TenKH);
            Assert.AreEqual(address, list[index].DiaChi);
            Assert.AreEqual(sex, list[index].GioiTinh);
            Assert.AreEqual(phone, list[index].SDT);
           
            dao.Delete(id);
        }
    }
}
