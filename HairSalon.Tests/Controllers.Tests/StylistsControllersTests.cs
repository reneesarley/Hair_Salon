using System;
using System.Collections.Generic;
using HairSalon.Models;
using HairSalon.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Tests.Controllers.Tests
{

    [TestClass]
    public class StylistsControllersTests : IDisposable
    {
        
        public void Dispose()
        {
            Stylist.DeleteAll();
        }

        public StylistsControllersTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=renee_sarley_test;";  
        }

        [TestMethod]
        public void AddNewForm_ReturnsCorrectView_View()
        {
            //Arrange
            StylistsController controller = new StylistsController();

            //Act
            IActionResult addNewFormView = controller.AddNewForm();

            //Assert
            Assert.IsInstanceOfType(addNewFormView, typeof(ViewResult));
        }

    }
}
