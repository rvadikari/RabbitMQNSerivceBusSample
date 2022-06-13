using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using NServiceBus;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Receive
{
    class Receive
    {
        //public static void Main(string[] args)
        //{
        //    var endpointConfiguration = new EndpointConfiguration("Recieve");
        //    var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
        //    transport.UseConventionalRoutingTopology();
        //    transport.ConnectionString(ConfigurationManager.ConnectionStrings[0].ConnectionString);
        //    var factory = new ConnectionFactory() { HostName = "localhost" };
        //    using (var connection = factory.CreateConnection()) 
        //    using(var channel = connection.CreateModel())
        //    {
        //        channel.QueueDeclare(queue: "Samples.RabbitMQ.NativeIntegration", durable: false, exclusive: false, autoDelete: false, arguments: null);
        //        var consumer = new EventingBasicConsumer(channel);
        //        consumer.Received += (model, ea) =>
        //        {
        //            var body = ea.Body.ToArray();
        //            var message = Encoding.UTF8.GetString(body);
        //            Console.WriteLine("[x] Received {0}", message);
        //        };
        //        channel.BasicConsume(queue: "hello",
        //                         autoAck: true,
        //                         consumer: consumer);

        //        Console.WriteLine(" Press [enter] to exit.");
        //        Console.ReadLine();
        //    }
        //}
         static async Task Main(string[] args)
        {
            Console.Title = "Sales";
            await Host.CreateDefaultBuilder(args).UseNServiceBus(context =>
            {
                var endPointConfiguration = new EndpointConfiguration("Receive");
                endPointConfiguration.UseTransport<LearningTransport>();
                //endPointConfiguration.UseTransport<RabbitMQTransport>().ConnectionString(ConfigurationManager.ConnectionStrings["NServiceBus/Transport"].ConnectionString); ;
                return endPointConfiguration;
            }).RunConsoleAsync();
        }
    }
}
