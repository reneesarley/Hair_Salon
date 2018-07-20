using System;
using System.Collections.Generic;
using HairSalon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace HairSalon.Tests.Models.Tests
                   
{
    [TestClass]
    public class SpecialtyTests : IDisposable
    {

        public void Dispose()
        {
            Specialty.DeleteAll();
        }

        public SpecialtyTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=renee_sarley_test;";
        }

        [TestMethod]
        public void GetAll_DBStartsEmpty_0()
        {
            //Arrange
            //Act
            int result = Specialty.GetAll().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Save_SavesToDatabase_SpecialtyList()
        {
            //Arrange
            Specialty testSpecialty = new Specialty("Cut - Long Hair");

            //Act
            testSpecialty.Save();
            List<Specialty> result = Specialty.GetAll();
            List<Specialty> testList = new List<Specialty>() {new Specialty("Cut - Long Hair")};

            //Assert
            CollectionAssert.AreEqual(result, testList);
        }
    }
}