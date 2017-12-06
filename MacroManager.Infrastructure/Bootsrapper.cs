using MacroManager.Infrastructure.IocInstallers;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.Infrastructure
{
    public static class Bootstrapper
    {
        public static readonly Container Container;


        static Bootstrapper()
        {
            var container = new Container();
            InfrastructureInstaller.RegisterServices(container);
            ControllersInstaller.RegisterServices(container);
            ViewsInstaller.RegisterServices(container);
            container.Verify();
            Container = container;

        }

    }
}
