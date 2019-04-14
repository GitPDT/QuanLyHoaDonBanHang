using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BUS;
using DAO;
using DTO;
using System.Linq;
using System.Collections.Generic;
using QuanLyHoaDon;

namespace UnitTest
{
    [TestClass]
    public class TestKhachHang
    {
        KhachHang_DAO dao;
        KhachHang khachHang1;
        KhachHang khachHang2;
        [TestInitialize]
        public void Setup()
        {
            dao = new KhachHang_DAO();
            khachHang1 = new KhachHang("123", "Tai", "Go Vap", "Nam", "09388282");
            khachHang2 = new KhachHang("1233", "Tai", "Go Vap", "Nam", "09388282");
        }
        [TestMethod]
        public void ThemKhachHang()
        {
            bool kq = dao.AddCustomer(khachHang1);
            dao.AddCustomer(khachHang2);
            Assert.AreEqual(true,kq);
            //Assert.AreEqual(khachHang1.MaKH.Trim(),"123");
            //Assert.AreEqual(khachHang1.TenKH.Trim(), "Tai");
            //Assert.AreEqual(khachHang1.DiaChi.Trim(), "Go Vap");
            //Assert.AreEqual(khachHang1.GioiTinh.Trim(), "Nam");
            //Assert.AreEqual(khachHang1.SDT.Trim(), "09388282");
        }
    }
}
