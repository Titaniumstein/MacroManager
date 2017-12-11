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
using MacroManager.Controllers.IViews.Main;

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
            var controller = Bootstrapper.Container.GetInstance<PackageController>();
            var view = Bootstrapper.Container.GetInstance<IViewMain>();
            controller.LoadIndexView();
            view.Display(controller.IndexView);
            application.Run((Window)view);
        }
    }
}
