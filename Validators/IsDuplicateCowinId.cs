using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vaccinator.Services.Interfaces;

namespace Vaccinator.Validators
{
    public class IsDuplicateCowinId:ValidationAttribute
    {
        private readonly IEmpVaccinationDetailsService _vaccinationDetailsService;
        public IsDuplicateCowinId(IEmpVaccinationDetailsService vaccinationDetailsService)
        {
            _vaccinationDetailsService = vaccinationDetailsService;
        }

        public override bool IsValid(object value)
        {
            long CowinId = Convert.ToInt64(value);
            return false;
        }
    }
}