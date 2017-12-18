using MacroContext.Contract.Events;
using MacroManager.Controllers.Controllers;
using MacroManager.Controllers.IViews.Main;
using MacroManager.Controllers.Navigation;
using MacroManager.Controllers.Navigation.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MacroManager.Controllers.EventHandlers
{
    public class PackageAddedEventHandler : IEventHandler<PackageAddedEvent>
    {
        private IViewMain _mainView;
        private PackageController _controller;
        private IRouter _router;
        private IThreadDispatcher _dispatcher;

        public PackageAddedEventHandler(IRouter router, IThreadDispatcher dispatcher, IViewMain mainView, PackageController controller)
        {
            _mainView = mainView;
            _controller = controller;
            _router = router;
            _dispatcher = dispatcher;
        }

        public void Handle(PackageAddedEvent e)
        {
            _dispatcher.Dispatch(() => _router.GoTo(new PackageIndexRoute()));
        }
    }
}
