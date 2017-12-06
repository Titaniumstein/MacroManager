using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Infrastructure.Abstractions;
using MacroManager.Controllers.Dispatchers;

namespace MacroManager.Infrastructure.IocInstallers
{
    static class InfrastructureInstaller
    {

        public static void RegisterServices(Container _simpleContainer)
        {
            _simpleContainer.RegisterSingleton<ICommandDispatcher>(new CommandDispatcher());

            _simpleContainer.Register(typeof(ICommandHandler<>), typeof(WcfServiceCommandHandlerProxy<>));

        }
    }
}
