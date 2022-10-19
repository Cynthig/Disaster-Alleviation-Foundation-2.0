using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisasterAlleviation.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Models.DisplayRecords verify)
        {
               string user = Request.Form["username"].ToString();
            string password = Request.Form["password"].ToString();

             if (verify.verified(user, password)) 
             {
                 return RedirectToAction("Index", "Home"); 
             }
             else
             {
                return View("Login"); 
             }

        }
    }
}
