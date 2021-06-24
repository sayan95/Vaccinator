using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vaccinator.Models;
using Vaccinator.ViewModels;

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

        /**
         *  saves vaccination details 
         */
        [HttpPost]
        public ActionResult Save(VaccinationFormViewModel vaccinationDetails)
        {
            // validate inputs
            if (!ModelState.IsValid)
            {
                ViewBag.Page = "vaccination-create";
                return View("Create", vaccinationDetails);
            }

            ViewBag.Page = "vaccination-create";
            return Content("Create");
        }
    }
}