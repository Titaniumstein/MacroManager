using Infrastructure.Abstractions;
using MacroContext.Contract.Commands;
using MacroContext.Contract.Dto;
using MacroManager.Controllers.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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

            var dispatcher = new CommandDispatcher();
            var controller = new PackageController(dispatcher);
            var pkg = new PackageDto(Guid.NewGuid());
            pkg.Name = "test2";

            controller.AddPackage(pkg);

            //application.Run();
        }
    }
}
