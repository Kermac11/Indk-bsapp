using Microsoft.VisualStudio.TestTools.UnitTesting;
using Indkøbsapp.Catalog;
using System;
using System.Collections.Generic;
using System.Text;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using Indkøbsapp.Services;

namespace Indkøbsapp.Catalog.Tests
{
    [TestClass()]
    public class ButiksKatalogTests
    {
        [TestMethod()]
        public void SortPricesTest()
        {
            ButiksKatalog test =  new ButiksKatalog("bilka", "ørelundsvej");
            IButikItems b1 = new ButikItems(0, "ost", 32, VareKategori.Mælkeprodukter);
            IButikItems b2 = new ButikItems(1, "mælk", 72, VareKategori.IS);
            IButikItems b3 = new ButikItems(2, "pastil" , 5, VareKategori.Grønsager);
            test.AddItem(b1);
            test.AddItem(b2);
            test.AddItem(b3);

            Assert.AreEqual(b3.Price, test.SortPrices()[0].Price);
        }
    }
}