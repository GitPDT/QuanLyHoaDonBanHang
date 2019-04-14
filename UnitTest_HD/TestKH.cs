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
            KhachHang kh1 = new KhachHang("PH2", "Phan", "Go Vap", "Nam", "08389283882");
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
        [TestMethod]
        public void UpdateKhachHang()
        {
            //Neu Update thanh cong thi Pass
            KhachHang kh2 = new KhachHang("PH2", "Phan Duc Tai", "Go Vap", "Nam", "08389283882");
            bool actual = dao.UpdateCustomer(kh2);
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void XoaKhachHang()
        {
            //Neu Xoa thanh cong thi Pass
            bool actual = dao.Delete("PH2");
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void XoaKhachHang_MaKH_KhongTonTai()
        {
            //Neu Xoa khong thanh cong thi Pass
            bool actual = dao.Delete("MM");
            Assert.IsFalse(actual);
        }

    }
}
