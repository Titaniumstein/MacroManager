using MacroContext.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;


namespace MacroManager.Infrastructure.Services
{
    public class MacroContextQueryProcessorChannelFactory
    {


        private ChannelFactory<IQueryProcessorService> _channelFactory;
        private EndpointAddress _endpoint = new EndpointAddress("net.tcp://localhost:9011/QueryProcessor");
        private Binding _binding = new NetTcpBinding();


        public void InitializeChannel()
        {

            _channelFactory = new ChannelFactory<IQueryProcessorService>(_binding, _endpoint);

        }


        public TResult Submit<TQuery, TResult>(TQuery query)
        {
            Console.Write(typeof(TResult).Name);
            IQueryProcessorService channel = _channelFactory.CreateChannel();
            var jsonCmd = JsonConvert.SerializeObject(query);
            var jsonResult = channel.Submit(query.GetType().ToString(), jsonCmd);
            ((IClientChannel)channel).Close();
            var result = JsonConvert.DeserializeObject<TResult>(jsonResult);
            return (TResult)result;

        }

    }

    
}
