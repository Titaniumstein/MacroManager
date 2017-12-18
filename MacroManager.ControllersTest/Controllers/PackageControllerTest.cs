using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MacroManager.Controllers.Controllers;
using NSubstitute;
using MacroContext.Contract.Dto;
using MacroContext.Contract.Commands;
using MacroContext.Contract.Queries;
using MacroManager.ControllersTest.TestHelpers;

namespace MacroManager.ControllersTest.Controllers
{
    [TestClass]
    public class PackageControllerTest
    {

        private PackageController _controller;
        private PackageControllerMockBundle _controllerMockBundle;
        private PackageDto _package;

        [TestInitialize]
        public void TestInitialize()
        {
            _controllerMockBundle = new PackageControllerMockBundle();
            _package = new PackageDto(Guid.NewGuid());
            _controller = new PackageController(
                _controllerMockBundle.MockThreadDispatcher,
                _controllerMockBundle.MockCommandDispatcher,
                _controllerMockBundle.MockQueryDispatcher,
                _controllerMockBundle.MockViews
                );

        }


        [TestMethod]
        public void LoadIndexView_CallsGetAllPackages()
        {
            var mockController = _controllerMockBundle.MockController;
            mockController.LoadIndexView();
            mockController.Received().GetAllPackages();
        }

        [TestMethod]
        public void LoadIndexView_WithoutDefaultSelection()
        {
            _controller.LoadIndexView();
            _controllerMockBundle.MockIndexView.Received().Initialize(Arg.Any<PackageDto[]>(), null);
        }

        [TestMethod]
        public void LoadDeleteView_CallsInitialize()
        {
            _controller.LoadDeleteView(_package);
            _controllerMockBundle.MockDeleteView.Received().Initialize(_package);
        }

        [TestMethod]
        public void LoadEditView_CallsInitialize()
        {
            _controller.LoadEditView(_package);
            _controllerMockBundle.MockEditView.Received().Initialize(_package);
        }

        [TestMethod]
        public void LoadDetailView_CallsInitialize()
        {
            _controller.LoadDetailView(_package);
            _controllerMockBundle.MockDetailView.Received().Initialize(_package);
        }


        [TestMethod]
        public void AddPackage_CallsCommandDispatcher()
        {
            _controller.AddPackage(_package);
            _controllerMockBundle.MockCommandDispatcher.Received().Submit(Arg.Any<AddPackageCommand>());
   
        }

        [TestMethod]
        public void EditPackage_CallsCommandDispatcher()
        {
            _controller.EditPackage(_package);
            _controllerMockBundle.MockCommandDispatcher.Received().Submit(Arg.Any<EditPackageCommand>());

        }

        [TestMethod]
        public void RemovePackage_CallsCommandDispatcher()
        {
            _controller.RemovePackage(_package);
            _controllerMockBundle.MockCommandDispatcher.Received().Submit(Arg.Any<RemovePackageCommand>());

        }

        [TestMethod]
        public void GetAllPackages_CallsQueryDispatcher()
        {
            _controller.GetAllPackages();
            _controllerMockBundle.MockQueryDispatcher.Received().Submit(Arg.Any<GetAllPackagesQuery>());

        }


    }
}
