using Microsoft.VisualStudio.TestTools.UnitTesting;
using Indkøbsapp.Catalog;
using System;
using System.Collections.Generic;
using System.Text;
using Indkøbsapp.Models;

namespace Indkøbsapp.Catalog.OrdrerTest
{
    [TestClass()]
    public class OrderKatalogTests
    {
        [TestMethod()]
        public void CreateOrderTest()
        {
            //Arrange
            OrderKatalog _orders = new OrderKatalog();
            Bruger b1 = new Bruger();
            b1.UserName = "jens";

            //Act

            _orders.CreateOrder(b1.UserName);

            //Assert
            Assert.IsTrue(_orders.GetAllOrdrer().ContainsKey("jens"));
        }
        [TestMethod()]
        public void FindOrderTest()
        {
            //Arrange
            OrderKatalog _orders = new OrderKatalog();
            Bruger b1 = new Bruger();
            b1.UserName = "jens";

            //Act

            _orders.CreateOrder(b1.UserName);



            //Assert
            Assert.IsTrue(_orders.FindOrder(b1.UserName).ID == _orders.GetAllOrdrer()[b1.UserName].ID);
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            //Arrange
            OrderKatalog _orders = new OrderKatalog();
            Bruger b1 = new Bruger();
            b1.UserName = "jens";

            //Act

            _orders.CreateOrder(b1.UserName);
            _orders.DeleteOrder(b1.UserName);



            //Assert
            Assert.IsFalse(_orders.GetAllOrdrer().ContainsKey(b1.UserName));
        }
    }
}