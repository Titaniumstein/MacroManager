using MacroManager.Controllers.Navigation.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.Controllers.Navigation.RouteHandlers
{
    public interface IRouteHandler<TRoute> where TRoute : IRoute
    {
        void Handle(TRoute route);
    }
}
