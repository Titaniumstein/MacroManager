using MacroManager.Controllers.Controllers;
using MacroManager.Controllers.Dispatchers;
using MacroManager.Controllers.IViews.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.ControllersTest.TestHelpers
{
    public class PackageControllerMockBundle
    {
        public PackageController MockController { get; private set; }
        public ICommandDispatcher MockCommandDispatcher { get; private set; }
        public IQueryDispatcher MockQueryDispatcher { get; private set; }
        public ViewCollection MockViews { get; private set; }
        public IViewIndex MockIndexView { get; private set; }
        public IViewCreate MockCreateView { get; private set; }
        public IViewDetail MockDetailView { get; private set; }
        public IViewEdit MockEditView { get; private set; }
        public IViewDelete MockDeleteView { get; private set; }


        public PackageControllerMockBundle()
        {
            MockCommandDispatcher = NSubstitute.Substitute.For<ICommandDispatcher>();
            MockQueryDispatcher = NSubstitute.Substitute.For<IQueryDispatcher>();
            MockIndexView = NSubstitute.Substitute.For<IViewIndex>();
            MockCreateView = NSubstitute.Substitute.For<IViewCreate>();
            MockDetailView = NSubstitute.Substitute.For<IViewDetail>();
            MockEditView = NSubstitute.Substitute.For<IViewEdit>();
            MockDeleteView = NSubstitute.Substitute.For<IViewDelete>();
            MockViews = NSubstitute.Substitute.For<ViewCollection>(MockIndexView, MockCreateView, MockEditView, MockDetailView, MockDeleteView);
            MockController = NSubstitute.Substitute.For<PackageController>(MockCommandDispatcher, MockQueryDispatcher, MockViews);

        }

    }

   
}
