using System;
using System.Collections.Generic;
using HairSalon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


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
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=diningTracker_test;";  
        }


    }
}
