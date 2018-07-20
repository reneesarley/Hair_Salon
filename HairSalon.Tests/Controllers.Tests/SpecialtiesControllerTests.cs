using System;
using System.Collections.Generic;
using HairSalon.Models;
using HairSalon.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Tests.Controllers.Tests
{
    [TestClass]
    public class SpecialtiesControllerTests
    {
        public void Dispose()
        {
            Specialty.DeleteAll();
        }

        public SpecialtiesControllerTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=renee_sarley_test;";
        }

        [TestMethod]
        public void Index_ReturnsCorrectView_View()
        {
            //Arrange
           SpecialtyController controller = new SpecialtyController();

            //Act
            IActionResult indexView = controller.Index();

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

    }
}
