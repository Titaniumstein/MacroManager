using MacroManager.Controllers.Controllers.Orchestrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.Infrastructure.Abstractions
{
    public class Orchestrator : IOrchestrator
    {
        public void Initialize()
        {
            var container = Bootstrapper.Container;
            var macroContextCallback = container.GetInstance<Services.EventCallback>();
            macroContextCallback.CreateConnection();
            macroContextCallback.SubscribeToMessages();
        }

        
    }
}
