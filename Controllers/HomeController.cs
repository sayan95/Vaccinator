using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vaccinator.Controllers
{
    public class HomeController : Controller
    {
        /**
         *  returns landing page of the application
         */
        public ViewResult Index()
        {
            ViewBag.Page = "Home";
            return View("Index");
        }

        /**
         *  returns an about page 
         */
        public ViewResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Page = "About";
            return View("About");
        }

        /**
         *  returns a contact details page
         */
        public ViewResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Page = "Contact";
            return View("Contact");
        }
    }
}