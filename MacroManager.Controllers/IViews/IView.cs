using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroManager.Controllers.Controllers;

namespace MacroManager.Controllers.IViews
{
    public interface IView<TController> : IViewBase where TController : IController
    {
        void SetController(TController controller);
    }
}
