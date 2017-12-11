using MacroManager.Controllers.Controllers;
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
    public class PackageDetailRouteHandler : IRouteHandler<PackageDetailRoute>
    {
        private IViewMain _main;
        private PackageController _controller;

        public PackageDetailRouteHandler(IViewMain main, PackageController controller)
        {
            _main = main;
            _controller = controller;
        }

        public void Handle(PackageDetailRoute route)
        {
            _controller.LoadDetailView(route.Package);
            _main.Display(_controller.DetailView);
        }
    }
}
