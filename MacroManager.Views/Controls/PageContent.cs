using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MacroManager.Views.Controls
{
    public class PageContent : ContentControl
    {
        private ResourceDictionary _rd;

        public PageContent()
        {
            _rd = ResourceLocator.GetResource(this);
            ApplyResouce(_rd);
        }

        private void ApplyResouce(ResourceDictionary rd)
        {
            this.Style = rd["Style"] as Style;
        }
    }
}
