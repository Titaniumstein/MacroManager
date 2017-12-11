using MacroContext.Contract.Commands;
using MacroContext.Contract.Dto;
using MacroManager.Controllers.Controllers;
using MacroManager.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MacroManager.Views.Main;
using MacroManager.Views.Package;
using MacroManager.Infrastructure;

namespace MacroManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            var application = new App();
            application.InitializeComponent();

            //var dispatcher = new CommandDispatcher();

            //var pkg = new PackageDto(Guid.NewGuid());
            //pkg.Name = "test2";

            //controller.AddPackage(pkg);
            var controller = Bootstrapper.Container.GetInstance<PackageController>();
            var view = new Views.Main.Index();
            //var index = new Views.Package.Index();
            //var create = new Views.Package.Create();
            //var controller = new PackageController(dispatcher, create, index);
            controller.LoadIndexView();
            view.Content = controller.IndexView;
            //view.Content = new Views.Package.Index();
            application.Run(view);
        }
    }
}
