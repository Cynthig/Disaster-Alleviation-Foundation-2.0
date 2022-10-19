using DisasterAlleviation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DisasterAlleviation.Controllers
{
    public class HomeController : Controller
    {
        DisplayRecords d = new DisplayRecords();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DonationPage()
        {
            return View();
        }
        public IActionResult DisasterPage()
        {
            return View();
        }
        public IActionResult DisplayUserInfo()
        {
            return View(d.MonetaryInformation());
        }
        public IActionResult DisasterInformation()
        {
            return View(d.DisasterInformation());
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Allocate()
        {
            return View(d.AvailableMoney());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult CaptureMonetaryDonations(Models.DisplayRecords CaptureMonetary)
        {
            int NoOfDonations = int.Parse(Request.Form["inputNoOfDonations"].ToString());
            string dateOfDonation = Request.Form["dateOfDonation"].ToString();
            string Description = Request.Form["DescriptionOfMonetaryGoods"].ToString();
            string Category = "";


            //Checking if the student is registered in the database
            if (CaptureMonetary.CaptureMonetary( dateOfDonation, NoOfDonations, Category, Description))
            {
                return RedirectToAction("Notification", "Home");
            }
            else
            {
                return View("DonationPage"); 
            }
        }
        public IActionResult CaptureDisaster(Models.DisplayRecords CaptureD)
        {
            string start_date = Request.Form["startDateD"].ToString();
            string end_date = Request.Form["endDateD"].ToString();
            string location = Request.Form["AddLocation"].ToString();
            string description = Request.Form["AddDisasterD"].ToString();


            //Checking if the student is registered in the database
            if (CaptureD.CaptureD(start_date, end_date, location, description))
            {
                return View("Home/Notification");
            }
            else
            {
                return View("DonationPage");
            }
        }
        public IActionResult CaptureGoodsDonations(Models.DisplayRecords CaptureGoods)
        {
            int NoOfDonations = int.Parse(Request.Form["inputNoOfGoodsDonations"].ToString());
            string dateOfDonation = Request.Form["dateOfGoodsDonation"].ToString();
            string Category = Request.Form["Category"].ToString();
            string Description = Request.Form["DescriptionOfGoods"].ToString();
            string AddedCategory = Request.Form["AddCategory"].ToString();

            if (Category == "Select Category")
            {
                Category = AddedCategory;
            }
            if(CaptureGoods.CaptureGoods(dateOfDonation, NoOfDonations, Category, Description))
                {
                    return RedirectToAction("Notification", "Home"); 

            }
            else
                { 
                    return View("DonationPage");
                }
            
          
            
        }

    }
}
