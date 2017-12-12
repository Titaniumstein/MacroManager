using MacroManager.Controllers.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.Controllers.IViews.Package
{
    public class ViewCollection : IViewCollection<PackageController>
    {
        public IViewIndex IndexView { get; private set; }
        public IViewCreate CreateView { get; private set; }
        public IViewEdit EditView { get; private set; }
        public IViewDetail DetailView { get; private set; }
        public IViewDelete DeleteView { get; private set; }

        public ViewCollection(IViewIndex indexView, IViewCreate createView, IViewEdit editView, IViewDetail detailView, IViewDelete deleteView)
        {
            IndexView = indexView;
            CreateView = createView;
            EditView = editView;
            DetailView = detailView;
            DeleteView = deleteView;
        }

        public void SetController(PackageController controller)
        {
            IndexView.SetController(controller);
            CreateView.SetController(controller);
            EditView.SetController(controller);
            DetailView.SetController(controller);
            DeleteView.SetController(controller);

        }
    }
}
