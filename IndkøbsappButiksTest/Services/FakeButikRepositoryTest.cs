using Microsoft.VisualStudio.TestTools.UnitTesting;
using Indkøbsapp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Indkøbsapp.Models;

namespace Indkøbsapp.Services.ButiksTest
{
    [TestClass()]
    public class FakeButikRepositoryTest
    {
        [TestMethod()]
        public void AddButikTest()
        {
            //Arrange
            FakeButikRepository TestRepository = new FakeButikRepository();
            Butik TestButik = new Butik("Aldi", "Amager");
            //Act
            TestRepository.AddButik(TestButik);
            //Assert
            Assert.IsTrue(TestRepository.GetButik(TestButik.ButiksNavn).Lokation==TestButik.Lokation);
        }

        [TestMethod()]
        public void DeleteButikTest()
        {
            //Arrange
            FakeButikRepository TestRepository = new FakeButikRepository();
            Butik TestButik = new Butik("Aldi", "Amager");
            //Act
            TestRepository.AddButik(TestButik);
            TestRepository.DeleteButik(TestButik.ButiksNavn);
            //Assert
            Assert.IsFalse(TestRepository.GetAllButikker().Remove(TestButik));
        }

    }
}