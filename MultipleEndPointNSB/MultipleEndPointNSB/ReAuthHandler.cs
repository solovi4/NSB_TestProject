using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleEndPointNSB
{
    class ReAuthHandler : IHandleMessages<ReAuthorizationEvent>
    {
        public Task Handle(ReAuthorizationEvent message, IMessageHandlerContext context)
        {
            Console.WriteLine($"ReAuth received contract = {message.ContractId} service = {message.ServiceId} subscriber = {message.SubscriberId}");
            return Task.FromResult(true);
        }
    }
}
