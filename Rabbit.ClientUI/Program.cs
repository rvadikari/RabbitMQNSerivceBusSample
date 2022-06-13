using Messages;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Rabbit.ClientUI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            EndpointConfig endpointConfig = new EndpointConfig();
            var endpointConfiguration = endpointConfig.Config("Rabbit.ClientUI");

          

            var endPoint = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
            await RunLoop(endPoint);
            await endPoint.Stop().ConfigureAwait(false);
        }

        static async Task RunLoop(IMessageSession endPoint)
        {
            while (true)
            {
                Console.WriteLine("Press P to Place Order, Q to exit");
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.P:
                        await endPoint.Send(new PlaceOrder { OrderID = Guid.NewGuid().ToString().Substring(0, 8) });
                        break;
                    case ConsoleKey.Q:
                        return;

                }

            }
        }
    }
}
