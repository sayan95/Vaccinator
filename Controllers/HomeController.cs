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
        [HttpGet]
        [Route]
        [Route("home", Name = "home")]
        public ViewResult Index()
        {
            ViewBag.Page = "Home";
            return View("Index");
        }
    }
}