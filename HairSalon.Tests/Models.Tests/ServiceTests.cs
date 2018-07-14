using System;
using System.Collections.Generic;
using HairSalon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace HairSalon.Tests.Models.Tests
                   
{
    [TestClass]
    public class ServiceTests : IDisposable
    {

        public void Dispose()
        {
            Service.DeleteAll();
        }

        public ServiceTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=renee_sarley_test;";
        }

        [TestMethod]
        public void GetAll_DBStartsEmpty_0()
        {
            //Arrange
            //Act
            int result = Service.GetAll().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        //[TestMethod]
        //public void Save_SavesToDatabase_ServiceList()
        //{
        //    //Arrange
        //    Service testService = new Service("Cut - Long Hair", 2);

        //    //Act
        //    testService.Save();
        //    List<Service> result = Service.GetAll();
        //    List<Service> testList = new List<Service>() { testService };

        //    //Assert
        //    CollectionAssert.AreEqual(result, testList);
        //}
    }
}