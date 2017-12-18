using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using MacroContext.Contract.Dto;
using MacroManager.Controllers.IViews.Main;
using MacroManager.Controllers.Navigation.RouteHandlers;
using MacroManager.Controllers.Navigation.Routes;
using MacroManager.ControllersTest.TestHelpers;
using MacroManager.Controllers;
using MacroManager.Controllers.Controllers;

namespace MacroManager.ControllersTest.Controllers
{
    [TestClass]
    public class PackageIndexRouteHandlerTest
    {
        private PackageIndexRouteHandler _handler;
        private IThreadDispatcher _mockDispatcher;
        private PackageIndexRoute _route;
        private IViewMain _mockMainView;
        private PackageController _mockController;
        private PackageDto _package;



        [TestInitialize]
        public void TestInitialize()
        {
            _mockMainView = Substitute.For<IViewMain>();
            _mockController = new PackageControllerMockBundle().MockController;
            _mockDispatcher = Substitute.For<IThreadDispatcher>();
            _mockDispatcher.Dispatch(Arg.Invoke());
            _handler = new PackageIndexRouteHandler(_mockDispatcher, _mockMainView, _mockController);
            _package = new PackageDto(Guid.NewGuid());
            _route = new PackageIndexRoute();
        }


        [TestMethod]
        public void Handle_CallsMainViewDisplay()
        {
            _handler.Handle(_route);
            _mockMainView.Received().Display(_mockController.Views.IndexView);
        }

        [TestMethod]
        public void Handle_CallsControllerLoadView()
        {
            _handler.Handle(_route);
            _mockController.Received().LoadIndexView();
        }





    }
}
