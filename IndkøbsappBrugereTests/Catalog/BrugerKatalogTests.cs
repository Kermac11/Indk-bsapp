using Microsoft.VisualStudio.TestTools.UnitTesting;
using Indkøbsapp.Catalog;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;
using Indkøbsapp.Models;

namespace Indkøbsapp.Catalog.Tests
{
    [TestClass()]
    public class BrugerKatalogTests
    {
        [TestMethod()]
        public void CreateUserTest()
        {
            //Arrange
            BrugerKatalog users = new BrugerKatalog();
            Bruger b1 = new Bruger();
            b1.UserName = "jens";
            //Act
            users.CreateUser(b1);
            //Assert
            Assert.IsTrue(b1.UserName == users.SearchUser("jens").UserName);
        }
        [TestMethod()]
        public void SearchUserTest()
        {
            //Arrange
            BrugerKatalog users = new BrugerKatalog();
            Bruger b1 = new Bruger();
            Bruger b2 = new Bruger();
            Bruger b3 = new Bruger();
            b1.UserName = "jens";
            b2.UserName = "niels";
            b3.UserName = "per";
            //Act
            users.CreateUser(b1);
            users.CreateUser(b2);
            users.CreateUser(b3);
            //Assert
            Assert.IsTrue(b2.UserName == users.SearchUser("niels").UserName);
        }
        [TestMethod()]
        public void UpdateUserTest()
        {
            //Arrange
            BrugerKatalog users = new BrugerKatalog();
            Bruger b1 = new Bruger();
            Bruger b2 = new Bruger();
            Bruger b3 = new Bruger();
            Bruger b4 = new Bruger();
            b1.UserName = "jens";
            b2.UserName = "niels";
            b3.UserName = "per";
            //Act
            users.CreateUser(b1);
            users.CreateUser(b2);
            users.CreateUser(b3);
            b3.Navn = "lars";
            users.UpdateUser(b3);
            //Assert
            Assert.IsTrue(b3.Navn == users.SearchUser("per").Navn);
        }
        [TestMethod()]
        public void DeleteUserTest()
        {
            //Arrange
            BrugerKatalog users = new BrugerKatalog();
            Bruger b1 = new Bruger();
            Bruger b2 = new Bruger();
            Bruger b3 = new Bruger();
            Bruger b4 = new Bruger();
            b1.UserName = "jens";
            b2.UserName = "niels";
            b3.UserName = "per";
            //Act
            users.CreateUser(b1);
            users.CreateUser(b2);
            users.CreateUser(b3);
            users.DeleteUserName(b2.UserName);
            //Assert
            Assert.IsFalse(users.GetAllUsers().ContainsKey(b2.UserName));
        }
        [TestMethod()]
        public void CheckPaswwordTest()
        {
            //Arrange
            BrugerKatalog users = new BrugerKatalog();
            Bruger b1 = new Bruger();
            Bruger b2 = new Bruger();
            Bruger b3 = new Bruger();
            Bruger b4 = new Bruger();
            b1.UserName = "jens";
            b2.UserName = "niels";
            b3.UserName = "per";
            b1.PassWord = "123";
            //Act
            users.CreateUser(b1);
            users.CreateUser(b2);
            users.CreateUser(b3);
            b2 = users.SearchUser(b1.UserName);
            b4 = users.CheckPassword(b1);

            //Assert
            Assert.IsTrue(b2.PassWord==b4.PassWord);
        }
    }
}