﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairSalon.Models;
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
            List<object> clientsAndStylists = new List<object>() {Stylist.GetAll(), Client.GetAll()};

            return View(clientsAndStylists);
        }

        [HttpGet("/employee")]
        public IActionResult Employee()
        {
            return View();
        }

    }
}
