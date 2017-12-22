using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MacroManager.Views.Controls
{
    public static class ResourceLocator
    {
        public static ResourceDictionary GetResource<TControl>(TControl control) where TControl : Control
        {
            var rd = new ResourceDictionary();
            var resourceName = control.GetType().Name + "Resource.xaml";
            var resourcePath = @"Resources/" + resourceName;
            var uri = UriBuilder(resourcePath);
            //var uriStr = @"pack://application:,,,/MacroManager.Views;component/Resource/ButtonResource.xaml";
            rd.Source = uri;
            return rd;
        }

        private static Uri UriBuilder(string resoucePath)
        {
            var assemblyName = typeof(ResourceLocator).Assembly.GetName().Name;
            var prefixText = @"pack://application:,,,/";
            var middleText = assemblyName + @";component/";
            var suffix = resoucePath;
            var uriStr = prefixText + middleText + suffix;
            return new Uri(uriStr);
            
        }
    }
}
