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
    public class MacroContextCommandProcessorChannelFactory
    {


        private ChannelFactory<ICommandProcessorService> _channelFactory;
        private EndpointAddress _endpoint = new EndpointAddress("net.tcp://localhost:9011/CommandProcessor");
        private Binding _binding = new NetTcpBinding();


        public void InitializeChannel()
        {

            _channelFactory = new ChannelFactory<ICommandProcessorService>(_binding, _endpoint);

        }


        public void Submit<TCommand>(TCommand cmd)
        {
            ICommandProcessorService channel = _channelFactory.CreateChannel();
            var jsonCmd = JsonConvert.SerializeObject(cmd);
            channel.Submit(cmd.GetType().ToString(), jsonCmd);
            ((IClientChannel)channel).Close();

        }

    }

    
}
