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
    public class PackageDeleteRouteHandler : IRouteHandler<PackageDeleteRoute>
    {
        private IViewMain _main;
        private PackageController _controller;

        public PackageDeleteRouteHandler(IViewMain main, PackageController controller)
        {
            _main = main;
            _controller = controller;
        }

        public void Handle(PackageDeleteRoute route)
        {
            _controller.LoadDeleteView(route.Package);
            _main.Display(_controller.DeleteView);
        }
    }
}
