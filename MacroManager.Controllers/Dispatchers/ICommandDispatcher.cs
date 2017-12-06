using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.Controllers.Dispatchers
{
    public interface ICommandDispatcher
    {
        void Submit<TCommand>(TCommand command);
    }
}
