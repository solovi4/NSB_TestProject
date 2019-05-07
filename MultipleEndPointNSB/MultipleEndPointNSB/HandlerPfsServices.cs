using Messages;
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
        IServiceForPfs service;
        public HandlerPfsServices(IServiceForPfs service)
        {
            this.service = service;
        }

        public async Task Handle(ReloadServicesCommand message, IMessageHandlerContext context)
        {
            service.Send(message);
            await Task.FromResult(true);
        }
    }
}
