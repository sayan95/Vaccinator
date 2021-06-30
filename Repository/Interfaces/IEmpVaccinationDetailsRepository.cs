using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaccinator.Models;

namespace Vaccinator.Repository.Interfaces
{
    public interface IEmpVaccinationDetailsRepository
    {
        
        bool Add(EmpVaccinationDetails details);

        IList<EmpVaccinationDetails> All();

        EmpVaccinationDetails FindById(long id);

        bool Update(EmpVaccinationDetails details);

        bool Delete(long id);
    }
}
