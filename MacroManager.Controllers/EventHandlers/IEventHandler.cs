using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.Controllers.EventHandlers
{
    public interface IEventHandler<TEvent> //where TEvent: class
    {
        void Handle(TEvent e);

    }
}
