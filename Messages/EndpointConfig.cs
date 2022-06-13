using System;
using System.Collections.Generic;
using System.Text;
using NServiceBus;

namespace Messages
{
    public class EndpointConfig
    {
        public EndpointConfiguration Config(string endpointName)
        {
            Console.Title = endpointName;
           
            var endpointConfiguration = new EndpointConfiguration(endpointName);
            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            transport.UseConventionalRoutingTopology();
            transport.ConnectionString("host=localhost;username=guest;password=guest");

            var routing = transport.Routing();
            routing.RouteToEndpoint(typeof(PlaceOrder), "Rabbit.Sales");
            endpointConfiguration.EnableInstallers();

            return endpointConfiguration;
        }
    }
}
