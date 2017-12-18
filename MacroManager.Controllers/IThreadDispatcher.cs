using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.Controllers
{
    public interface IThreadDispatcher
    {
        void Dispatch(Action action);
    }
}
