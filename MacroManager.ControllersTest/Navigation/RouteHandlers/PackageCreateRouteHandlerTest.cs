using Microsoft.VisualStudio.TestTools.UnitTesting;
using MacroManager.Controllers.IViews.Package;
using NSubstitute;
using MacroManager.Controllers.IViews.Main;
using MacroManager.Controllers.Navigation.RouteHandlers;
using MacroManager.Controllers.Navigation.Routes;

namespace MacroManager.ControllersTest.Controllers
{
    [TestClass]
    public class PackageCreateRouteHandlerTest
    {
        private PackageCreateRouteHandler _handler;
        private PackageCreateRoute _route;
        private IViewMain _mockMainView;
        private IViewCreate _mockView;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockMainView = Substitute.For<IViewMain>();
            _mockView = Substitute.For<IViewCreate>();
            _handler = new PackageCreateRouteHandler(_mockMainView, _mockView);
            _route = new PackageCreateRoute();
        }


        [TestMethod]
        public void Handle_CallsMainViewDisplay()
        {
            _handler.Handle(_route);
            _mockMainView.Received().Display(_mockView);
        }




    }
}
