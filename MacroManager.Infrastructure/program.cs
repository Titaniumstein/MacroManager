using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SimpleInjector;
using MacroManager.Controllers.Controllers.Orchestrator;
using MacroManager.Controllers.IViews.Main;

//this file is required for integrating wpf with simpleinjector
//http://simpleinjector.readthedocs.io/en/latest/wpfintegration.html

namespace MacroManager.Infrastructure
{

    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                using (var container = Bootstrapper.Container)
                {
                    RunApplication(container);

                }

            }
            catch(Exception e)
            {

            }



        }



        private static void RunApplication(Container container)
        {

            var controller = container.GetInstance<OrchestratorController>();
            var view = container.GetInstance<IViewMain>();

            var application = new App()
            {
                MainWindow = (Window)view,
                ShutdownMode = ShutdownMode.OnMainWindowClose
            };

            //application.InitializeComponent();
            view.Display(controller.View);
            controller.Initialize();
            application.Run(application.MainWindow);


            

        }

    }
}

