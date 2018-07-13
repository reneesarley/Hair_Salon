using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;


namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet ("/clients/new")]
        public IActionResult AddNewForm()
        {
            return View(Stylist.GetAll());
        }
    }
}
