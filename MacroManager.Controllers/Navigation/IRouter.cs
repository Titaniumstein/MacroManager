using MacroManager.Controllers.Navigation.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.Controllers.Navigation
{
    public interface IRouter
    {
        void GoTo<TRoute>(TRoute route) where TRoute : class, IRoute;
    }
}
