using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Indk�bsapp;
using Indk�bsapp.Interfaces;
using Indk�bsapp.Models;
using Indk�bsapp.Services;
namespace ButikTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private List<Butik> butikker;
        [TestMethod]
        public void TestMethod1()
        {

            List<Butik> butikker = new List<Butik>();
            butikker.Add(new Butik() { ButiksNavn = "F�tex", Lokation = "Amager" });
        }
    }
}
