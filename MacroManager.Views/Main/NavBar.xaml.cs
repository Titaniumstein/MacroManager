using MacroManager.Controllers.IViews.Main;
using MacroManager.Controllers.Navigation;
using MacroManager.Controllers.Navigation.Routes;
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

namespace MacroManager.Views.Main
{
    /// <summary>
    /// Interaction logic for NavBar.xaml
    /// </summary>
    public partial class NavBar : UserControl
    {
        private IRouter _router;
        public string Text { get; set; }


        public NavBar()
        {
            InitializeComponent();
        }

        public void SetRouter(IRouter router)
        {
            _router = router;
        }


        public string Title
        {
            get { return title.Content.ToString(); }
            set { title.Content = value; }
        }



        private void Packages_Click(object sender, RoutedEventArgs e)
        {
            _router.GoTo(new PackageIndexRoute());
        }
    }
}
