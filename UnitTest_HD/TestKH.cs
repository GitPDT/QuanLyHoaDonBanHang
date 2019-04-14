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
            //Nhap thong tin dung - neu dung thi pass
            KhachHang kh1 = new KhachHang("K11", "Phan", "Go Vap", "Nam", "08389283882");
            bool actual = dao.AddCustomer(kh1);
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void ThemKhachHang_NhapMaKhachHangBiTrung()
        {
            //nhập mã khách hàng đã tồn tại
            //Kiểm tra sai - nếu không thêm được thì Pass
            KhachHang kh2 = new KhachHang("PH2", "Phan", "Go Vap", "Nam", "08389283882");
            bool actual = dao.AddCustomer(kh2);
            Assert.IsFalse(actual);
        }
    }
}
