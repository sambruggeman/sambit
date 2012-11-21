using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace sambit
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();            
            UnityConfigurationSection section = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
            section.Configure(container, "default");

            return container;
        }
    }
}