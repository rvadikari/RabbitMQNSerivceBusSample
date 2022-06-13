using System;
using System.Threading.Tasks;
using NServiceBus;
using Messages;


namespace Rabbit.Billing
{
    class Program
    {
        static async Task Main(string[] args)
        {
          
            EndpointConfig endpointConfig = new EndpointConfig();
            var endpointConfiguration = endpointConfig.Config("Rabbit.Billing");

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
               .ConfigureAwait(false);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            await endpointInstance.Stop()
                .ConfigureAwait(false);


        }
    }
}
