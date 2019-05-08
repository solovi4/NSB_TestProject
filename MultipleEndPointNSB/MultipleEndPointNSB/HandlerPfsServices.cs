using Messages;
using NServiceBus;
using System.Threading.Tasks;

namespace MultipleEndPointNSB
{
    class HandlerPfsServices : IHandleMessages<MySystem.ReloadServices>
    {
        IServiceForPfs service;
        public HandlerPfsServices(IServiceForPfs service)
        {
            this.service = service;
        }

        public Task Handle(MySystem.ReloadServices message, IMessageHandlerContext context)
        {
            service.Send(message);
            return Task.CompletedTask;
        }
    }
}
