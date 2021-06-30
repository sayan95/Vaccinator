using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vaccinator.Models;

namespace Vaccinator.ViewModels
{
    public class VaccinationOverviewViewModel
    {
        public IEnumerable<EmpVaccinationDetails> VaccinationDetails { get; set; }
        public string Message { get; set; }
    }
}