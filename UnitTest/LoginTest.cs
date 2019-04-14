using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BUS;
using DAO;

namespace UnitTest
{
    
    [TestClass]
    public class LoginTest
    {
        DataProvider Datapr = new DataProvider();
        [TestMethod]
        public void UserAndPassIsCorrect()
        {
            string user = "admin";
            string pass = "123";
            int actual = Datapr.Login(user, pass);
            int expect = 0;
            Assert.AreSame(expect,actual);
        }
    }
}
