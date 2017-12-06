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

namespace MacroManager.Views.Package
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : UserControl, IPackageIndex
    {
        private PackageController _controller;
        private PackageDto _selectedPackage;

        public Index()
        {
            InitializeComponent();
        }

        public string Text { get; set; }

        public void Initialize(Guid? packageId = default(Guid?))
        {
           
        }

        public void SetController(PackageController controller)
        {
            _controller = controller;
        }

        private void dgvPackages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
