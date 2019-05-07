using Messages;
using NServiceBus;
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

        public Task Handle(ReloadServicesCommand message, IMessageHandlerContext context)
        {
            service.Send(message);
            return Task.CompletedTask;
        }
    }
}
