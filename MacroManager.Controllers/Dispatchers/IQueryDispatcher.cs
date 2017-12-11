using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.Controllers.Dispatchers
{
    public interface IQueryDispatcher
    {
        TResult Submit<TResult>(MacroContext.Contract.Queries.IQuery<TResult> query);
    }
}
