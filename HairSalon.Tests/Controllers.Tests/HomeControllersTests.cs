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
            IActionResult addNewView = controller.Index();

            //Assert
            Assert.IsInstanceOfType(addNewView, typeof(ViewResult));
        }
    }
}
