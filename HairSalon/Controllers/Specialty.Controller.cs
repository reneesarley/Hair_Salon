using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;


namespace HairSalon.Controllers
{
    public class SpecialtyController : Controller
    {
        [HttpGet ("specialty/index")]
        public IActionResult Index()
        {
            List<Specialty> allSpecialties = Specialty.GetAll();
            return View(allSpecialties);
        }
    }
}
