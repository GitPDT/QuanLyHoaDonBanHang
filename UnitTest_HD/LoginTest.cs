using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyHoaDon;
using DAO;
using DTO;

namespace UnitTest_HD
{
    [TestClass]
    public class LoginTest
    {
        DataProvider dt = new DataProvider();
        [TestMethod]
        public void MatKhauVaTaiKhoanDung()
        {
            //KiemTraDung- Neu dung thi Pass
            string user = "admin";
            string pass = "123";
            bool a = dt.Login(user, pass);
            Assert.IsTrue(a);
        }
        [TestMethod]
        public void MatKhauHoacTaiKhoanSai()
        {
            //KiemTraSai- Neu sai thi Pass
            string user = "admin";
            string pass = "111";
            bool actual = dt.Login(user, pass);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void KhongNhapMatKhauHoacTaiKhoan()
        {
            //Kiem Tra sai - Neu sai thi pass
            string user = "";
            string pass = "";
            bool actual = dt.Login(user, pass);
            Assert.IsFalse(actual);
        }
    }
}
