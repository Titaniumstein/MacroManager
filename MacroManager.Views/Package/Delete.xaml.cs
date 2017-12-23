using System;
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
using MacroManager.Controllers.Controllers;
using MacroManager.Controllers.IViews.Package;
using MacroContext.Contract.Dto;
using System.Collections.ObjectModel;
using MacroManager.Controllers.Navigation;
using MacroManager.Controllers.Navigation.Routes;

namespace MacroManager.Views.Package
{

    public partial class Delete : UserControl, Controllers.IViews.Package.IViewDelete
    {
        private PackageController _controller;
        private IRouter _router;
        private PackageDto _package;

        public Delete(IRouter router)
        {
            _router = router;
            InitializeComponent();
        }

        public string Text { get; set; }

        public void Initialize(PackageDto package)
        {

            _package = package;
            this.packageControl.PackageName = _package.Name;
            this.packageControl.PackageDescription = _package.Description;

        }

        public void SetController(PackageController controller)
        {
            _controller = controller;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            _controller.RemovePackage(_package);
            _router.GoTo(new PackageIndexRoute());
        }
    }
}
