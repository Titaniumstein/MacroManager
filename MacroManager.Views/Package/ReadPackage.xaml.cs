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

namespace MacroManager.Views.Package
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class ReadPackage : UserControl
    {
        public ReadPackage()
        {
            InitializeComponent();
        }

        public string PackageName
        {
            get { return name.Content.ToString(); }
            set { name.Content = value; }
        }

        public string PackageDescription
        {
            get { return description.Content.ToString(); }
            set { description.Content = value; }
        }
    }
}
