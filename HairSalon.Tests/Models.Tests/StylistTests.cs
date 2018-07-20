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
            Specialty.DeleteAll();
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
            Stylist foundStylist = Stylist.Find(testStylist.id);

            //Assert
           Assert.AreEqual(testStylist, foundStylist);
        }

        [TestMethod]
        public void AddSpecialty_AddsSpecialtyToStylist_SpecialtyList()
        {
            //Arrange
            Stylist testStylist = new Stylist("first", "last");
            testStylist.Save();

            Specialty testSpecialty = new Specialty("Hair Cut");
            testSpecialty.Save();

            //Act
            testStylist.AddSpecialty(testSpecialty);

            List<Specialty> result = testStylist.GetSpecialties();
            List<Specialty> testList = new List<Specialty> { testSpecialty };

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }
        [TestMethod]
        public void GetSpecialtys_ReturnsAllStylistSpecialtys_CategoryList()
        {
            //Arrange
            Stylist testStylist = new Stylist("first", "last");
            testStylist.Save();

            Specialty testSpecialty1 = new Specialty("hair cut");
            testSpecialty1.Save();

            Specialty testSpecialty2 = new Specialty("color");
            testSpecialty2.Save();

            //Act
            testStylist.AddSpecialty(testSpecialty1);
            List<Specialty> result = testStylist.GetSpecialties();
            List<Specialty> testList = new List<Specialty> { testSpecialty1 };

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }

    }
}
