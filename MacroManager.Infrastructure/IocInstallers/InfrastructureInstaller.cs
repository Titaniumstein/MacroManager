using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using MacroManager.Controllers.Dispatchers;
using MacroManager.Infrastructure.Abstractions;
using MacroManager.Infrastructure.Abstractions.Dispatchers;
using MacroManager.Controllers.Navigation.RouteHandlers;
using MacroManager.Controllers.Navigation;

namespace MacroManager.Infrastructure.IocInstallers
{
    static class InfrastructureInstaller
    {

        public static void RegisterServices(Container _simpleContainer)
        {
            _simpleContainer.RegisterSingleton<ICommandDispatcher>(new CommandDispatcher());
            _simpleContainer.RegisterSingleton<IQueryDispatcher>(new QueryDispatcher());

     
            _simpleContainer.Register(typeof(ICommandHandler<>), typeof(WcfServiceCommandHandlerProxy<>));
            _simpleContainer.Register(typeof(IQueryHandler<,>), typeof(WcfServiceQueryHandlerProxy<,>));

            _simpleContainer.Register(typeof(IRouteHandler<>), AppDomain.CurrentDomain.GetAssemblies());
            _simpleContainer.RegisterSingleton<IRouter>(new Router());


        }
    }
}
