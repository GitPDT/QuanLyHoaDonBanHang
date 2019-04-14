using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyHoaDon;
using DTO;
using BUS;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest_HD
{
    
    [TestClass]
    public class TestHoaDon
    {
        HoaDon_BUS HoadonBus = new HoaDon_BUS();
        [TestMethod]
        public void TestHamThanhTien()
        {
            //Tinh tien
            int dongia = 10000;
            int soluong = 5;
            int chietkhau = 10; //10%
            int actual = HoadonBus.TinhTien(soluong, dongia, chietkhau);
            int expected = 45000;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestHamThanhTien_NhapDonGiaBang0()
        {
            //Tinh tien
            int dongia = 0;
            int soluong = 5;
            int chietkhau = 10; //10%
            int actual = HoadonBus.TinhTien(soluong, dongia, chietkhau);
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestHamTinhNo()
        {
            //Tinh tien no
            int thanhtien = 100000;
            int datra = 20000;
            int actual = HoadonBus.TinhNo(thanhtien,datra);
            int expected = 80000;
            Assert.AreEqual(expected, actual);
        }
    }
}
