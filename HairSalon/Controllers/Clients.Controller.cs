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
        [HttpGet("/clients/new")]
        public IActionResult AddNewForm()
        {
            return View(Stylist.GetAll());
        }

        [HttpPost("/clients/new")]
        public IActionResult Save(string firstname, string lastName, int stylistId)
        {
            Client newClient = new Client(firstname, lastName, stylistId);
            newClient.Save();

            return RedirectToAction("Index", "Clients");
        }

        [HttpGet("clients/index")]
        public IActionResult Index()
        {
            List<object> model = new List<object>() { Client.GetAll(), };
            return View(model);
        }

        [HttpPost("clients/{id}/delete")]
         public IActionResult Delete(int id)
        {
            Client.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost("clients/deleteAll")]
        public IActionResult DeleteAll()
        {
            Client.DeleteAll();
            return RedirectToAction("Index");
        }
    }
}
