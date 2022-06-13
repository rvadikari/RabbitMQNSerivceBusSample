using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Rabbit.Sales  
{
    class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public async Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            // throw new NotImplementedException();
            log.Info($"Received Place Order, OrderID= {message.OrderID}");
            await context.Publish(new OrderPlaced { OrderID = message.OrderID });
            //return Task.CompletedTask;
        }
        static ILog log = LogManager.GetLogger<PlaceOrderHandler>();

    }
}
