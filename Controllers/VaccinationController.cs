using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vaccinator.Controllers
{
    [RoutePrefix("vaccination")]
    public class VaccinationController : Controller
    {
        /**
         *  return vaccination main page
         */
        [HttpGet]
        [Route("", Name = "vaccination.home")]
        public ActionResult Index()
        {
            ViewBag.Page = "vaccination-home"; 
            return View("Index");
        }

        /**
         *  returns vaccination details form
         */
        [HttpGet]
        [Route("add-details", Name = "vaccination.create")]
        public ActionResult Create()
        {
            ViewBag.Page = "vaccination-create";
            return View("Create");
        }
    }
}