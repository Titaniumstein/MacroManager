using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

using MacroManager.Controllers.Dispatchers;
using MacroManager.Infrastructure.Services;

namespace MacroManager.Infrastructure.Abstractions.Dispatchers
{
    public class WcfServiceQueryHandlerProxy<TQuery,TResult> : IQueryHandler<TQuery,TResult>
    {


        public TResult Handle(TQuery query)
        {

            var service = new QueryProcessorChannelFactory();
            service.InitializeChannel();



            try
            {
                return service.Submit<TQuery,TResult>(query);
            }

            finally
            {
                try
                {
                    ((IDisposable)service).Dispose();
                }
                catch
                {
                    // Against good practice and the Framework Design Guidelines, WCF can throw an
                    // exception during a call to Dispose, which can result in loss of the original exception.
                    // See: https://marcgravell.blogspot.com/2008/11/dontdontuse-using.html
                    // See: https://msdn.microsoft.com/en-us/library/aa355056.aspx


                }
            }

        }

    }
}
