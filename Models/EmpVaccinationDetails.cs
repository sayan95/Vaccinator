using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vaccinator.Models
{   
    public class EmpVaccinationDetails
    {
        public long? Id { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Employee age is required")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter a valid age")]
        [Range(18, 60, ErrorMessage = "Age must be in between 18-60")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Employee gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Select a valid manufacturer name")]
        public string VaccineMfg { get; set; }

        public string VaccineDescription { get; set; }

        [Required(ErrorMessage = "Vaccination location age is required")]
        public string VaccineLocation { get; set; }

        [Required(ErrorMessage = "Cowin registration id is required")]
        public int? CowinId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}