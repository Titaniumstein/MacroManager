using MacroManager.Controllers.IViews.Package;
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
using MacroContext.Contract.Dto;
using MacroManager.Controllers.Navigation;
using MacroManager.Controllers.Navigation.Routes;

namespace MacroManager.Views.Package
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : UserControl, IViewCreate
    {
        private PackageController _controller;
        private IRouter _router;

        public Create(IRouter router)
        {
            _router = router;
            InitializeComponent();
        }

        public string Text { get; set; }


        public void SetController(PackageController controller)
        {
            _controller = controller;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var pkg = new PackageDto(Guid.NewGuid());
            pkg.Name = package.PackageName;
            pkg.Description = package.PackageDescription;
            _controller.AddPackage(pkg);
            //_router.GoTo(new PackageIndexRoute());
        }

        
    }
}
