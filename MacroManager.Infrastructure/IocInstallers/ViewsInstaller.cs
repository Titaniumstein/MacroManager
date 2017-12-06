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
        private static IEnumerable<Type> ViewServiceTypes; // used to suppress errors
        private static Lifestyle CacheActionPaneWhileNotDisposed;
        public static void RegisterServices(Container _simpleContainer)
        {

            RegisterViews(_simpleContainer);


        }



        private static void RegisterViews(Container _simpleContainer)
        {
            var viewAssembly = typeof(Index).Assembly;
            var viewTypes =
                from type in viewAssembly.GetExportedTypes()
                where type.GetInterfaces().Contains(typeof(IViewBase))
                select type;

            var viewServiceTypes = new List<Type>(); // to suppress warnings after
            foreach (var viewType in viewTypes)
            {
                
                var service = GetViewService(viewType);
                _simpleContainer.Register(service, viewType, Lifestyle.Singleton);
                
            }

        }

    

        private static Type GetViewService(Type viewType)
        {
            var service = viewType.GetInterfaces()
                .Where(i => i.GetInterfaces().Contains(typeof(IViewBase)) && i.IsGenericType == false).Single();

            return service;

        }


        //public static void SuppressIocWarnings(Container _simpleContainer)
        //{
        //    Registration reg = null;

        //    foreach (var service in ViewServiceTypes)
        //    {
        //        reg = _simpleContainer.GetRegistration(service).Registration;
        //        reg.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent,
        //            "The views are expected to dispose when form is closed");
        //        //reg.SuppressDiagnosticWarning(DiagnosticType.LifestyleMismatch,
        //        //    "A captive depedency is avoided becasue The controller lifestyle should dispose when its dependency (view) is disposed");
        //    }

        //}
    }
}
