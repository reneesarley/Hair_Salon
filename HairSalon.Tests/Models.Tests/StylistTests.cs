using System;
using HairSalon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;



namespace HairSalon.Tests.Models.Tests
{
    [TestClass]
    public class StylistTests : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
        }

        public StylistTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=renee_sarley_test;";
        }

        [TestMethod]
        public void GetAll_DBStartsEmpty_0()
        {
            //Arrange
            //Act
            int result = Stylist.GetAll().Count;

            //Assert
            Assert.AreEqual(0, result);
         }

        [TestMethod]
        public void Save_SavesToDatabase_StylistList()
        {
            //Arrange
            Stylist testStylist = new Stylist("Sarah", "Jones");

            //Act
            testStylist.Save();
            List<Stylist> result = Stylist.GetAll();
            List<Stylist> testList = new List<Stylist>() { testStylist };

            //Assert
            CollectionAssert.AreEqual(result, testList);
        }

        [TestMethod]
        public void Find_FindsStylist_Stylist()
        {
            //Arrange
            Stylist testStylist = new Stylist("Sarah", "Jones");
            testStylist.Save();

            //Act
            Stylist foundStylist = Stylist.Find(testStylist.GetId());

            //Assert
           Assert.AreEqual(testStylist, foundStylist);
        }
    }
}
