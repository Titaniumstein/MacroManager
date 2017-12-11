using MacroManager.Controllers.Dispatchers;
using MacroManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.Infrastructure.Abstractions.Dispatchers
{
    class QueryDispatcher : IQueryDispatcher
    {
        public TResult Submit<TResult>(MacroContext.Contract.Queries.IQuery<TResult> query)
        {
            var handler = Bootstrapper.Container.GetInstance<IQueryHandler<MacroContext.Contract.Queries.IQuery<TResult>,TResult>>();
            return handler.Handle(query);
              
        }
    }
}
