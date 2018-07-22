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
            return View(Specialty.GetAll());
        }

        [HttpPost ("stylists/new")]
        public IActionResult Save(string firstName, string lastName, int[] specialties)
        {
            Stylist newStylist = new Stylist(firstName, lastName);
            newStylist.Save();
            int stylistId = Stylist.FindLastAdded();

            for (int i = 0; i < specialties.Count(); i++)
            {
                newStylist.AddSpecialty(specialties[i]);
            }

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
            List<object> model = new List<object>(){Stylist.Find(id), "checked"};
            return View(model);
        }

        [HttpPost("/stylists/{id}/update")]
        public IActionResult UpdateStylist(int id, string newFirstName, string newLastName)
        {
            Specialty.DeleteAllSpecialtiesForSylist(id);
            Stylist.Update(newFirstName, newLastName, id);
            Stylist newStylist = Stylist.Find(id);
            //get values from check boxes
            List<Specialty> allSpecialties = Specialty.GetAll();

            for ( int i=0; i<allSpecialties.Count; i++)
            {
                string specialtyName = allSpecialties[i].GetSpecialtyName(); 
                string specialtyValueInput = Request.Form[specialtyName]; 
                if (!(specialtyValueInput == null))
                {
                    //string specialtyValueInput = Request.Form[specialtyName];
                    int specialtyValueInt = Int32.Parse(specialtyValueInput);                          
                    newStylist.AddSpecialty(specialtyValueInt);
                }

            }
            return RedirectToAction("Index");
        }
    }
}
