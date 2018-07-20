using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        [HttpGet("stylists/new")]
        public IActionResult AddNewForm()
        {
            return View();
        }

        [HttpPost ("stylists/new")]
        public IActionResult Save(string firstName, string lastName)
        {
            Stylist newStylist = new Stylist(firstName, lastName);
            newStylist.Save();
            return RedirectToAction("Index", "Stylists");
        }

        [HttpGet("stylists/index")]
        public IActionResult Index()
        {
            return View(Stylist.GetAll());
        }

        [HttpPost("stylists/{id}/delete")]
        public IActionResult Delete(int id)
        {
            Stylist.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost("stylists/deleteAll")]
        public IActionResult DeleteAll( )
        {
            Stylist.DeleteAll();
            return RedirectToAction("Index");
        }


        [HttpGet("/stylists/{id}/update")]
        public IActionResult UpdateForm(int id)
        {
            return View(Stylist.Find(id));
        }

        [HttpPost("/stylists/{id}/update")]
        public IActionResult UpdateStylist(int id, string newFirstName, string newLastName)
        {
            Stylist.Update(newFirstName, newLastName, id);
            return RedirectToAction("Index");
        }
    }
}
