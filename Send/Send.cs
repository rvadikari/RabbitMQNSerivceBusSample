using System;
using RabbitMQ.Client;
using System.Text;
using NServiceBus;
using System.Configuration;
using System.Threading.Tasks;
using Messages;

namespace Send
{
    public class Send
    {
        //public static void Main(string[] args)
        //{
        //    var endpointConfiguration = new EndpointConfiguration("Samples.RabbitMQ.NativeIntegration");
        //    var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
        //    transport.UseConventionalRoutingTopology();
        //    transport.ConnectionString(ConfigurationManager.ConnectionStrings[0].ConnectionString);

        //    var factory = new ConnectionFactory() { HostName = "localhost" };
        //    using(var connection=factory.CreateConnection())
        //        using(var channel = connection.CreateModel())
        //    {
        //      //  channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
        //        string message = "Hello world";
        //        var body = Encoding.UTF8.GetBytes(message);
        //        channel.BasicPublish(exchange: "", routingKey: "Samples.RabbitMQ.NativeIntegration", basicProperties: null, body: body);

        //        Console.WriteLine(" [x] Sent {0}", message);
        //    }
        //    Console.WriteLine("Press enter to exit");
        //    Console.ReadLine();
        //}

        static async Task Main(string[] args)
        {
            Console.Title = "Rabbit.ClientUI";

            var endpointConfiguration = new EndpointConfiguration("Rabbit.ClientUI");

            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            transport.ConnectionString("host=localhost");
           // transport.UsePublisherConfirms(true);
            transport.UseDirectRoutingTopology();

            var routing = transport.Routing();
            routing.RouteToEndpoint(typeof(Message), "Receive");
            endpointConfiguration.SendOnly();
            var endPoint = await Endpoint.Start(endpointConfiguration);
            await RunLoop(endPoint);
            await endPoint.Stop();
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
                        await endPoint.Send(new Message { Result = Guid.NewGuid().ToString().Substring(0, 8) });
                        break;
                    case ConsoleKey.Q:
                        return;

                }

            }
        }


    }
}
