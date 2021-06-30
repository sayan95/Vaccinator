using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Vaccinator.Repository.Classes;
using Vaccinator.Repository.Interfaces;
using Vaccinator.Services.Classes;
using Vaccinator.Services.Interfaces;

namespace Vaccinator
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IEmpVaccinationDetailsRepository, EmpVaccinationDetailsRepository>();
            container.RegisterType<IEmpVaccinationDetailsService, EmpVaccinationDetailsService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}