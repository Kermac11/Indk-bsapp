using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Indkøbsapp;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using Indkøbsapp.Services;

namespace VareTests
{
    [TestClass]
    public class VareTesting
    {
        [TestMethod]
        public void TestAfAddItem()
        {
            //Arrange
            ButiksVareKatalog TestKatalog= new ButiksVareKatalog();
            ButikItems TestVare1=new ButikItems(VareKategori.Kage,27546345,"Chokoladekage",15.2,"En chokoladekage","Aldi");
            //Act
            TestKatalog.AddItem(TestVare1);
            //Assert
            Assert.IsTrue(TestKatalog.FindItem(TestVare1.ID).Navn==TestVare1.Navn);

        }
        [TestMethod]
        public void TestAfDeleteItem()
        {
            //Arrange
            ButiksVareKatalog TestKatalog = new ButiksVareKatalog();
            ButikItems TestVare1 = new ButikItems(VareKategori.Kage, 3566457, "Chokoladekage", 15.2, "En chokoladekage", "Aldi");
            //Act
            TestKatalog.AddItem(TestVare1);
            TestKatalog.DeleteItem(TestVare1.ID);
            //Assert
            Assert.IsFalse(TestKatalog.GetAllButikVarer().ContainsKey(TestVare1.ID));

        }
        [TestMethod]
        public void TestAfEditItem()
        {
            //Arrange
            ButiksVareKatalog TestKatalog = new ButiksVareKatalog();
            ButikItems TestVare1 = new ButikItems(VareKategori.Kage, 123122312, "Chokoladekage", 15.2, "En chokoladekage", "Aldi");
            ButikItems TestVare2 = new ButikItems(VareKategori.Grøntsager, 123122312, "Agurk", 15.2, "En agurk", "Aldi");
            //Act
            TestKatalog.AddItem(TestVare1);
            TestKatalog.EditVare(TestVare2);
            //Assert
            Assert.IsTrue(TestKatalog.FindItem(TestVare1.ID).Navn == TestVare2.Navn);

        }
        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            ButiksVareKatalog TestKatalog = new ButiksVareKatalog();
            ButikItems TestVare1 = new ButikItems(VareKategori.Kage, 696456, "Chokoladekage", 15.2, "En chokoladekage", "Aldi");
            ButikItems TestVare2 = new ButikItems(VareKategori.Grøntsager, 86453542, "Agurk", 15.2, "En agurk", "Irma");
            TestKatalog.AddItem(TestVare1);
            TestKatalog.AddItem(TestVare2);
            //Act
            List<ButikItems> TestList = TestKatalog.FilterByEitherItemOrButik("", "Aldi");
            
            //Assert
            foreach (var vare in TestList)
            {
                Assert.IsTrue(vare.Butik=="Aldi");
            }
        }
    }
}
