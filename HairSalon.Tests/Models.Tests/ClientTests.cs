using System;
using System.Collections.Generic;
using HairSalon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HairSalon.Tests.Models.Tests
{
   
    [TestClass]
    public class ClientTests : IDisposable
    {
        public void Dispose()
        {
            Client.DeleteAll();
        }

        public ClientTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=renee_sarley_test;";
        }

        [TestMethod]
        public void GetAll_DBStartsEmpty_0()
        {
            //Arrange
            //Act
            int result = Client.GetAll().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Save_SavesToDatabase_ClientList()
        {
            //Arrange
            Client testClient  = new Client("Sarah", "Jones", 2);

            //Act
            testClient.Save();
            List<Client> result = Client.GetAll();
            List<Client> testList = new List<Client>() { testClient };

            //Assert
            CollectionAssert.AreEqual(result, testList);
        }

        [TestMethod]
        public void Find_FindsClient_Client()
        {
            //Arrange
            Client testClient = new Client("Sarah", "Jones", 1);
            testClient.Save();

            //Act
            Client foundClient = Client.Find(testClient.GetId());

            //Assert
            Assert.AreEqual(testClient, foundClient);
        }

        //[TestMethod]
        //public void Update_UpdatesClientInDatabase_Client()
        //{
        //    //Arrange
        //    string initialFirstName = "Tom";
        //    string initialLastName = "Jones";
        //    int initialStylistId = 1;
        //    Client testClient = new Client(initialFirstName, initialLastName, initialStylistId, 1);
        //    testClient.Save();
        //    string secondFirstName = "Bob";
        //    string secondLastName = "Smith";
        //    int secondStylistId = 1;
        //    Client updatedClient = new Client(secondFirstName, secondLastName, secondStylistId);

        //    //Act
        //    Client.Update(secondFirstName, secondLastName, secondStylistId, 1);
        //    Client result = Client.Find(testClient.GetId());

        //    //Assert
        //    Assert.AreEqual(result, updatedClient);
        //}
    }
}
