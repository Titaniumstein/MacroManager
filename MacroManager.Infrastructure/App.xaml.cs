//using MacroContext.Contract.Commands;
//using MacroContext.Contract.Dto;
//using MacroManager.Controllers.Controllers;
//using MacroManager.Infrastructure.Abstractions;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Windows;
//using MacroManager.Views.Main;
//using MacroManager.Views.Package;
//using MacroManager.Infrastructure;
//using MacroManager.Controllers.IViews.Main;
//using MacroManager.Controllers.Controllers.Orchestrator;
//using SimpleInjector;

//namespace MacroManager
//{
//    /// <summary>
//    /// Interaction logic for App.xaml
//    /// </summary>
//    public partial class App : Application
//    {
//        //private static Container _container;

//        [STAThread]
//        public static void Main()
//        {
//            using (var container = Bootstrapper.Container)
//            {
//                var controller = container.GetInstance<OrchestratorController>();
//                var view = container.GetInstance<IViewMain>();

//                var application = new App()
//                {
//                    MainWindow = (Window)view,
//                    ShutdownMode = ShutdownMode.OnMainWindowClose
//                };

//                application.InitializeComponent();
//                //controller.LoadStartUpView();
//                view.Display(controller.View);
//                application.Run(application.MainWindow);
//            }
            
//        }


//    }
//}
