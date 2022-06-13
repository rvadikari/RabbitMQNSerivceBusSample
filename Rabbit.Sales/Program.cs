using Microsoft.Extensions.Hosting;
using NServiceBus;
using System;
using System.Threading.Tasks;
using Messages;

namespace Rabbit.Sales
{
    class Program
    {
        static async Task Main(string[] args)
        {
            EndpointConfig endpointConfig = new EndpointConfig();
            var endpointConfiguration = endpointConfig.Config("Rabbit.Sales");
            var endpointInstance = await Endpoint.Start(endpointConfiguration)
               .ConfigureAwait(false);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }
}
