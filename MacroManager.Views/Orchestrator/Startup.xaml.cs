using MacroManager.Controllers.IViews.Orchestrator;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MacroManager.Controllers.Controllers.Orchestrator;
using MacroManager.Controllers.Navigation;
using MacroManager.Controllers.Navigation.Routes;
using System;

namespace MacroManager.Views.Orchestrator
{
    /// <summary>
    /// Interaction logic for Startup.xaml
    /// </summary>
    public partial class Startup : UserControl, IViewStartup
    {
        private OrchestratorController _controller;
        private IRouter _router;

        public Startup(IRouter router)
        {
            _router = router;
            InitializeComponent();
        }

        public String Text { get; set; }

        public void SetController(OrchestratorController controller)
        {
            _controller = controller;
        }


    }
}
