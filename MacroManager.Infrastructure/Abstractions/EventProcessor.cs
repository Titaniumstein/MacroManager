using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroManager.Controllers.EventHandlers;
using MacroContext.Contract.Events;

namespace MacroManager.Infrastructure.Abstractions
{
    public class EventProcessor
    {
        public void Process(TransactionResult result)
        {

            if(result.Succeeded)
            {
                foreach(var e in result.Events)
                {

                    try
                    {
                        var handlerType = typeof(IEventHandler<>).MakeGenericType(e.GetType());
                        var handlers = Bootstrapper.Container.GetAllInstances(handlerType);
                        foreach (dynamic handler in handlers)
                        {
                            handler.Handle((dynamic)e);
                        }

                    }
                    catch(Exception error)
                    {

                    }

                }
            }
               
            


        }




    }
}
