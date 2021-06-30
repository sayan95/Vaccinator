using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vaccinator.Models;
using Vaccinator.Repository.Interfaces;
using Vaccinator.Services.Interfaces;

namespace Vaccinator.Services.Classes
{
    public class EmpVaccinationDetailsService : IEmpVaccinationDetailsService
    {
        private readonly IEmpVaccinationDetailsRepository _vaccinationDetailsRepository;
        public EmpVaccinationDetailsService() { }
        public EmpVaccinationDetailsService(IEmpVaccinationDetailsRepository vaccinationDetailsRepository)
        {
            _vaccinationDetailsRepository = vaccinationDetailsRepository;
        }
        public bool AddDetails(EmpVaccinationDetails details)
        {
            return _vaccinationDetailsRepository.Add(details);
        }

        public IList<EmpVaccinationDetails> GetEmpVaccinationDetails()
        {
            return _vaccinationDetailsRepository.All();
        }

        public EmpVaccinationDetails FindVaccinationDetailsById(long id)
        {
            return _vaccinationDetailsRepository.FindById(id);
        }

        public bool UpdateDetails(EmpVaccinationDetails details)
        {
            return _vaccinationDetailsRepository.Update(details);
        }

        public bool DeleteDetails(long id)
        {
            return _vaccinationDetailsRepository.Delete(id);
        }
    }
}