using System;
using System.Collections.Generic;
using System.Text;
using NServiceBus;
using Messages;
using System.Threading.Tasks;
using NServiceBus.Logging;

namespace Receive
{
    class MyAsyncHandler : IHandleMessages<Message>
    {
        static ILog logger = LogManager.GetLogger<MyAsyncHandler>();

        public async Task Handle(Message message, IMessageHandlerContext context)
        {
            logger.Info($"Received PlaceOrder, OrderId = {message.Result}");

            // This is normally where some business logic would occur

            //var orderPlaced = new Message
            //{
            //    Result = message.Result
            //};
          //  return context.Publish(orderPlaced);
        }
    }
}
