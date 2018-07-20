using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;


namespace HairSalon.Controllers
{
    public class SpecialtiesController : Controller
    {
        [HttpGet("specialties/index")]
        public IActionResult Index()
        {
            //List<Specialty> allSpecialties = Specialty.GetAll();
            return View(Specialty.GetAll());
        }

        [HttpGet("specialties/new")]
        public IActionResult AddNew()
        {
            return View();   
        }
        [HttpPost("specialties/new")]
        public IActionResult Save(string specialty)
        {
            Specialty newSpecialty = new Specialty (specialty);
            newSpecialty.Save();
            return RedirectToAction("Index");
        }
    }
}
