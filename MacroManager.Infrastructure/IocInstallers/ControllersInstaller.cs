using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using MacroManager.Controllers.Controllers;
using MacroManager.Controllers.IViews;

namespace MacroManager.Infrastructure.IocInstallers
{
    static class ControllersInstaller
    {

        public static void RegisterServices(Container container)
        {
            RegisterControllers(container);
            RegisterViewCollections(container);
            

        }

        private static void RegisterControllers(Container container)
        {

            var controllerAssembly = typeof(IController).Assembly;
            var controllerRegistrations =
                from type in controllerAssembly.GetExportedTypes()
                where type.Namespace == typeof(IController).Namespace
                where type.GetInterfaces().Contains(typeof(IController)) && type.IsClass
                select new { Service = type.GetInterfaces().Single(), Implementation = type };

            foreach (var reg in controllerRegistrations)
            {
                container.Register(reg.Implementation, reg.Implementation, Lifestyle.Singleton);
            }

        }

        public static void RegisterViewCollections(Container container)
        {

            var controllerAssembly = typeof(IController).Assembly;
            var controllerRegistrations =
                from type in controllerAssembly.GetExportedTypes()
                where isViewCollectionType(type) && type.IsClass
                select new { Service = type.GetInterfaces().Single(), Implementation = type };
           
            foreach (var reg in controllerRegistrations)
            {
                container.Register(reg.Implementation, reg.Implementation, Lifestyle.Singleton);
            }

        }

        private static bool isViewCollectionType(Type type)
        {
            if( type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IViewCollection<>)))
            {
                return true;
            }
            return false;
        }

       


    }
}
