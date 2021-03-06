﻿using MacroManager.Controllers.IViews.Main;
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
using System.Windows.Shapes;
using MacroManager.Controllers.IViews;
using MacroManager.Controllers.Navigation;

namespace MacroManager.Views.Main
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Window, IViewMain
    {

        public Index(IRouter router)
        {
            InitializeComponent();
            navBar.SetRouter(router);
        }

        public string Text { get; set; }


        public void Display(IViewBase view)
        {
            currentContent.Content = null;
            currentContent.Content = view;

        }
    }
}
