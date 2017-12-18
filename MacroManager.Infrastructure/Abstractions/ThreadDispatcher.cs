using MacroManager.Controllers;
using MacroManager.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MacroManager.Infrastructure.Abstractions
{
    class ThreadDispatcher : IThreadDispatcher
    {
        public void Dispatch(Action action)
        {
            Application.Current.Dispatcher.Invoke(action);
        }
    }
}
