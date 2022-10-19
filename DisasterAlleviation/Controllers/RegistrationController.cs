using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisasterAlleviation.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Registration(Models.DisplayRecords RegisterUser)
        {
            string name = Request.Form["FirstName"].ToString();
            string surname = Request.Form["surname"].ToString();
            string username = Request.Form["username"].ToString();
            string password = Request.Form["password"].ToString();

            //Checking if the student is registered in the database
            if (RegisterUser.Register(name, surname, username, password))
            {
                return RedirectToAction("Login", "Login"); //Index is the page that is getting accessed, Home is the folder that holds Index - goes to index page
            }
            else
            {
                return View("Register"); 
            }

        }
    }
}
