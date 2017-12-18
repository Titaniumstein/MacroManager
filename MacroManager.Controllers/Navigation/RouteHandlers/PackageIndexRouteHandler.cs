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
    public class PackageIndexRouteHandler : IRouteHandler<PackageIndexRoute>
    {
        private IViewMain _main;
        private PackageController _controller;
        private IThreadDispatcher _dispatcher;

        public PackageIndexRouteHandler(IThreadDispatcher dispatcher, IViewMain main, PackageController controller)
        {
            _dispatcher = dispatcher;
            _main = main;
            _controller = controller;
        }

        public void Handle(PackageIndexRoute route)
        {
            _controller.LoadIndexView();
            _dispatcher.Dispatch(()=> _main.Display(_controller.Views.IndexView));
        }
    }
}
