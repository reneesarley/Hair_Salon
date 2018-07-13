using System;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace HairSalon.Tests.Controllers.Tests
{
    [TestClass]
    public class HomeControllersTests
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_View()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            IActionResult indexView = controller.Index();

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Owner_ReturnsCorrectView_View()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            IActionResult ownerView = controller.Owner();

            //Assert
            Assert.IsInstanceOfType(ownerView, typeof(ViewResult));
        }

        [TestMethod]
        public void Employee_ReturnsCorrectView_View()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            IActionResult employeeView = controller.Employee();

            //Assert
            Assert.IsInstanceOfType(employeeView, typeof(ViewResult));
        }
    }
}
