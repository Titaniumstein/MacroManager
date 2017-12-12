using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using MacroContext.Contract.Dto;
using MacroManager.Controllers.IViews.Main;
using MacroManager.Controllers.Navigation.RouteHandlers;
using MacroManager.Controllers.Navigation.Routes;
using MacroManager.ControllersTest.TestHelpers;

namespace MacroManager.ControllersTest.Controllers
{
    [TestClass]
    public class PackageEditRouteHandlerTest
    {
        private PackageEditRouteHandler _handler;
        private PackageEditRoute _route;
        private IViewMain _mockMainView;
        private PackageControllerMockBundle _controllerMockBundle;
        private PackageDto _package;



        [TestInitialize]
        public void TestInitialize()
        {
            _mockMainView = Substitute.For<IViewMain>();
            _controllerMockBundle = new PackageControllerMockBundle();
            _handler = new PackageEditRouteHandler(_mockMainView, _controllerMockBundle.MockController);
            _package = new PackageDto(Guid.NewGuid());
            _route = new PackageEditRoute(_package);
        }


        [TestMethod]
        public void Handle_CallsMainViewDisplay()
        {
            _handler.Handle(_route);
            _mockMainView.Received().Display(_controllerMockBundle.MockEditView);
        }

        [TestMethod]
        public void Handle_CallsControllerLoadView()
        {
            _handler.Handle(_route);
            _controllerMockBundle.MockController.Received().LoadEditView(_package);
        }





    }
}
