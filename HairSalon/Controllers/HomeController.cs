using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet ("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/owner")]
        public IActionResult Owner()
        {
            return View();
        }

        [HttpGet("/employee")]
        public IActionResult Employee()
        {
            return View();
        }

    }
}
