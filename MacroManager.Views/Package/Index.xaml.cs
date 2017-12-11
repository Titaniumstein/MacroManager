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
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : UserControl, Controllers.IViews.Package.IViewIndex
    {
        private PackageController _controller;
        private PackageDto _selectedPackage;
        private IRouter _router;

        public Index(IRouter router)
        {
            _router = router;
            InitializeComponent();
        }

        public string Text { get; set; }

        public void Initialize(Guid? packageId = default(Guid?))
        {
            var packages = _controller.GetAllPackages();
            dgvPackages.ItemsSource = null;
            dgvPackages.ItemsSource = packages;


        }

        public void SetController(PackageController controller)
        {
            _controller = controller;
        }

        private void dgvPackages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedPackage = (PackageDto)dgvPackages.SelectedItem;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            _router.GoTo(new PackageCreateRoute());

        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            _router.GoTo(new PackageEditRoute(_selectedPackage));
        }

        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            _router.GoTo(new PackageDetailRoute(_selectedPackage));

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            _router.GoTo(new PackageDeleteRoute(_selectedPackage));
        }
    }
}
