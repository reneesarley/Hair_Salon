using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;


namespace HairSalon.Controllers
{
    public class ServicesController : Controller
    {
        [HttpGet ("services/index")]
        public IActionResult Index()
        {
            List<Service> allServices = Service.GetAll();
            return View(allServices);
        }
    }
}
