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

    public partial class Edit : UserControl, Controllers.IViews.Package.IViewEdit
    {
        private PackageController _controller;
        private IRouter _router;
        private PackageDto _package;

        public Edit(IRouter router)
        {
            _router = router;
            InitializeComponent();
        }

        public string Text { get; set; }

        public void Initialize(PackageDto package)
        {
            _package = package;
            this.package.PackageName = _package.Name;
            this.package.PackageDescription = _package.Description;

        }

        public void SetController(PackageController controller)
        {
            _controller = controller;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var pkg = _package;
            pkg.Name = package.PackageName;
            pkg.Description = package.PackageDescription;
            _controller.EditPackage(pkg);
            _router.GoTo(new PackageIndexRoute());
        }

    }
}
