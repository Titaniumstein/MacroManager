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
    public partial class WritePackage : UserControl
    {
        public WritePackage()
        {
            InitializeComponent();
        }

        public string PackageName
        {
            get { return name.Text; }
            set { name.Text = value; }
        }

        public string PackageDescription
        {
            get { return description.Text; }
            set { description.Text = value; }
        }
    }
}
