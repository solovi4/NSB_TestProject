using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleEndPointNSB
{
    class HandlerPfsServices : IHandleMessages<ReloadServicesCommand>
    {
        public Task Handle(ReloadServicesCommand message, IMessageHandlerContext context)
        {
            Console.WriteLine($"ReloadServiceCommandRecieved {string.Concat(message.ServiceIds.Select(id => id.ToString() + " "))}");
            return Task.FromResult(true);
        }
    }
}
