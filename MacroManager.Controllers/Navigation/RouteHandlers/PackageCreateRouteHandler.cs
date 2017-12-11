using MacroManager.Controllers.IViews.Main;
using MacroManager.Controllers.IViews.Package;
using MacroManager.Controllers.Navigation.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.Controllers.Navigation.RouteHandlers
{
    public class PackageCreateRouteHandler : IRouteHandler<PackageCreateRoute>
    {
        private IViewMain _main;
        private IViewCreate _view;

        public PackageCreateRouteHandler(IViewMain main, IViewCreate view)
        {
            _main = main;
            _view = view;
        }

        public void Handle(PackageCreateRoute route)
        {
            _main.Display(_view);
        }
    }
}
