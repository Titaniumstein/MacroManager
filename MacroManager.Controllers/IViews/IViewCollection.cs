using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.Controllers.IViews
{
    public interface IViewCollection<TController> 
    {
        void SetController(TController controller);
       
    }
}
