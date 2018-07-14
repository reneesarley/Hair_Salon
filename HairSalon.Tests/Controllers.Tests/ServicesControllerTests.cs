using System;
using System.Collections.Generic;
using HairSalon.Models;
using HairSalon.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Tests.Controllers.Tests
{
    [TestClass]
    public class ServicesControllerTests
    {
        public void Dispose()
        {
            Service.DeleteAll();
        }

        public ServicesControllerTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=renee_sarley_test;";
        }

        [TestMethod]
        public void Index_ReturnsCorrectView_View()
        {
            //Arrange
           ServicesController controller = new ServicesController();

            //Act
            IActionResult indexView = controller.Index();

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

    }
}
