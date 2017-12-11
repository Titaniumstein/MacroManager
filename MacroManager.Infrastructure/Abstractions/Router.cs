using MacroManager.Controllers.Navigation;
using MacroManager.Controllers.Navigation.RouteHandlers;
using MacroManager.Controllers.Navigation.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.Infrastructure.Abstractions
{
    public class Router : IRouter
    {

        public void GoTo<TRoute>(TRoute route) where TRoute : class, IRoute
        {
            var handler = Bootstrapper.Container.GetInstance<IRouteHandler<TRoute>>();
            handler.Handle(route);
        }


    }
}
