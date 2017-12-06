using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using MacroManager.Controllers.Controllers;

namespace MacroManager.Infrastructure.IocInstallers
{
    static class ControllersInstaller
    {

        public static void RegisterServices(Container _simpleContainer)
        {

            var controllerAssembly = typeof(IController).Assembly;
            var controllerRegistrations =
                from type in controllerAssembly.GetExportedTypes()
                where type.Namespace == typeof(IController).Namespace
                where type.GetInterfaces().Contains(typeof(IController)) && type.IsClass
                select new { Service = type.GetInterfaces().Single(), Implementation = type };

            foreach (var reg in controllerRegistrations)
            {
                _simpleContainer.Register(reg.Implementation, reg.Implementation, Lifestyle.Singleton);
            }

        }


    }
}
