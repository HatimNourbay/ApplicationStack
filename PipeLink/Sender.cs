using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PipeLink
{
    public class Sender
    {
        public static void SendMessage(int messages)
        {
            SendMessage(messages, Receiver.DefaultPipeName);

        }

        // Use this method when we have an actual pipe name.
        public static void SendMessage(int messages, string PipeName)
        {
            EndpointAddress ep
                = new EndpointAddress(
                    string.Format("{0}/{1}",
                       PipeService.URI,
                       PipeName));

            //            IPipeService proxy = ChannelFactory<IPipeService>.CreateChannel( new BasicHttpBinding(), ep );
            IPipeService proxy = ChannelFactory<IPipeService>.CreateChannel(new NetNamedPipeBinding(), ep);
            proxy.PipeIn(messages);

        }
    }
}
