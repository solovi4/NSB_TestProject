using Messages;
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
        private IServiceForReAuth service;
        public ReAuthHandler(IServiceForReAuth service)
        {
            this.service = service;
        }
        public Task Handle(ReAuthorizationEvent message, IMessageHandlerContext context)
        {
            service.Write(message);
            return Task.FromResult(true);
        }
    }
}
