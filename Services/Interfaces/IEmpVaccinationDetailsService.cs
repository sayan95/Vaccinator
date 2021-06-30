using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaccinator.Models;

namespace Vaccinator.Services.Interfaces
{
    public interface IEmpVaccinationDetailsService
    {
        bool AddDetails(EmpVaccinationDetails details);

        IList<EmpVaccinationDetails> GetEmpVaccinationDetails();

        EmpVaccinationDetails FindVaccinationDetailsById(long id);

        bool UpdateDetails(EmpVaccinationDetails details);

        bool DeleteDetails(long id);
    }
}
