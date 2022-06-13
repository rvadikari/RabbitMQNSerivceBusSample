using System;
using System.Collections.Generic;
using System.Text;
using NServiceBus;
using Messages;
using System.Threading.Tasks;
using NServiceBus.Logging;

namespace Rabbit.Shipping
{
    class ShippingPolicy : IHandleMessages<OrderPlaced>, IHandleMessages<OrderBilled>
    {
        static ILog log = LogManager.GetLogger<ShippingPolicy>();
        bool orderPlaced = false, orderBilled = false;
        public async Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            orderPlaced = true;
            log.Info($"Order Placed with orderID={message.OrderID}. Should we ship?");
        }

        public async Task Handle(OrderBilled message, IMessageHandlerContext context)
        {
            orderBilled = true;
            if (orderPlaced && orderBilled)
                log.Info($"Order billed with orderID {message.OrderID}. It is time to ship");
            log.Info($"Order Billed with orderID={message.OrderID}. Should we ship?");
        }
    }
}
