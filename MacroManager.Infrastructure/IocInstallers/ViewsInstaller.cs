using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using MacroManager.Views.Package;
using MacroManager.Controllers.IViews;

namespace MacroManager.Infrastructure.IocInstallers
{
    static class ViewsInstaller
    {
        public static void RegisterServices(Container _simpleContainer)
        {
            RegisterViews(_simpleContainer);
        }




        private static void RegisterViews(Container container)
        {
            var viewAssembly = typeof(Index).Assembly;
            var viewTypes =
                from type in viewAssembly.GetExportedTypes()
                where type.GetInterfaces().Contains(typeof(IViewBase))
                select type;

            foreach (var viewType in viewTypes)
            {
                
                var service = GetViewService(viewType);
                container.Register(service, viewType, Lifestyle.Singleton);
                
            }

        }

    

        private static Type GetViewService(Type viewType)
        {
            var service = viewType.GetInterfaces()
                .Where(i => i.GetInterfaces().Contains(typeof(IViewBase)) && i.IsGenericType == false).Single();

            return service;

        }


    }
}
