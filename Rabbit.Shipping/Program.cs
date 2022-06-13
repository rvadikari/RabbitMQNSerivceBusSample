using System;
using System.Threading.Tasks;
using NServiceBus;
using Messages;

namespace Rabbit.Shipping
{
    class Program
    {
        public static async Task Main(string[] args)
        {
           
            EndpointConfig endpointConfig = new EndpointConfig();
            var endpointConfiguration = endpointConfig.Config("Rabbit.Shipping");
            var endpoint = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            await endpoint.Stop().ConfigureAwait(false);




        }
    }
}
