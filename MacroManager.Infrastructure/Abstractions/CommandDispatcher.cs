using MacroManager.Controllers.Dispatchers;
using MacroManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.Infrastructure.Abstractions
{
    class CommandDispatcher : ICommandDispatcher
    {
        public void Submit<TCommand>(TCommand command)
        {
            var handler = Bootstrapper.Container.GetInstance<ICommandHandler<TCommand>>();
            handler.Execute(command);
              
        }
    }
}
