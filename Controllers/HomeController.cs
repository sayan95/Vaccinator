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
        public ActionResult Index()
        {
            return View("Index");
        }

        /**
         *  returns an about page 
         */
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("About");
        }

        /**
         *  returns a contact details page
         */
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View("Contact");
        }
    }
}