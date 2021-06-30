using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vaccinator.Services.Interfaces;
using Vaccinator.ViewModels;

namespace Vaccinator.Controllers
{
    [RoutePrefix("vaccination")]
    public class VaccinationController : Controller
    {
        private readonly IEmpVaccinationDetailsService _vaccinationDetailsService;
        public VaccinationController(IEmpVaccinationDetailsService vaccinationDetailsService)
        {
            _vaccinationDetailsService = vaccinationDetailsService;
        }

        /**
         *  return vaccination main page
         */
        [HttpGet]
        [Route("", Name = "vaccination.home")]
        public ActionResult Index()
        {
            try
            {
                var vaccinationDetails = new VaccinationOverviewViewModel()
                {
                    VaccinationDetails = _vaccinationDetailsService.GetEmpVaccinationDetails(),
                    Message = ""
                };
                ViewBag.Page = "vaccination";
                ViewBag.CurrentMenu = "vaccination-home";
                return View("Index", vaccinationDetails);
            }
            catch (Exception e)
            {
                throw new HttpException(e.Message);
            }
        }

        /**
         *  returns vaccination details form
         */
        [HttpGet]
        [Route("add-details", Name = "vaccination.create")]
        public ActionResult Create(VaccinationFormViewModel vaccinationDetails)
        {
            ViewBag.Page = "vaccination";
            ViewBag.CurrentMenu = "vaccination-create";
            return View("Create", vaccinationDetails);
        }

        /**
         *  saves vaccination details 
         */
        [HttpPost]
        public ActionResult Save(VaccinationFormViewModel vaccinationDetails)
        {
            VaccinationFormViewModel formViewModel = null;
            // validates inputs
            if (!ModelState.IsValid)
            {
                ViewBag.Page = "vaccination";
                ViewBag.CurrentMenu = "vaccination-home";
                return View("Create", vaccinationDetails);
            }
            try
            {
                var id = vaccinationDetails.EmpVaccinationDetails.Id;
                if (id.Equals(null))
                {
                    // working as a save operation
                    _vaccinationDetailsService.AddDetails(vaccinationDetails.EmpVaccinationDetails);
                    ModelState.Clear();
                    formViewModel = new VaccinationFormViewModel()
                    {
                        Message = "Details has been saved successfully"
                    };
                }
                else
                {
                    // working as an update operation
                    _vaccinationDetailsService.UpdateDetails(vaccinationDetails.EmpVaccinationDetails);
                    formViewModel = new VaccinationFormViewModel()
                    {
                        Message = "Details has been updated successfully"
                    };
                }
                ViewBag.Page = "vaccination";
                ViewBag.CurrentMenu = "vaccination-create";
                return View("Create", formViewModel);
            }
            catch (Exception e)
            {
                throw new HttpException(e.Message);
            }
        }

        /**
         *  returns vaccination details page
         */
        [HttpGet]
        [Route("view-details/{id}", Name = "vaccination.details")]
        public ActionResult ShowDetailsPage(long id)
        {
            try
            {
                var vaccinationDetails = _vaccinationDetailsService.FindVaccinationDetailsById(id);
                return View("ShowDetails", vaccinationDetails);
            }
            catch (Exception e)
            {
                throw new HttpException(e.Message);
            }
        }

        /**
         *  returns vaccinatoin details edit page
         */
        [HttpGet]
        [Route("edit-details/{id}", Name = "vaccination.edit")]
        public ActionResult Edit(long id)
        {
            var formViewModel = new VaccinationFormViewModel()
            {
                EmpVaccinationDetails = _vaccinationDetailsService.FindVaccinationDetailsById(id)
            };
            ViewBag.Page = "vaccination";
            ViewBag.CurrentMenu = "vaccination-create";
            return View("Create", formViewModel);
        }

        /**
         *  Deletes vaccine details 
         */

        [HttpGet]
        [Route("delete-details/{id}", Name = "vaccination.delete")]
        public ActionResult Delete(long id)
        {
            var existingDetailsCowinId = _vaccinationDetailsService.FindVaccinationDetailsById(id).CowinId;   
             _vaccinationDetailsService.DeleteDetails(id);
            var overviewViewModel = new VaccinationOverviewViewModel()
            {
                VaccinationDetails = _vaccinationDetailsService.GetEmpVaccinationDetails(),
                Message = "Details for Cowin Id " + existingDetailsCowinId + " has been deleted"
            };

            ViewBag.Page = "vaccination";
            ViewBag.CurrentMenu = "vaccination-home";
            return View("Index", overviewViewModel);
        }
    }
}