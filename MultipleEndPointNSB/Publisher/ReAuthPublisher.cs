using Messages;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher
{
    class ReAuthPublisher
    {
        private IEndpointInstance endpoint;
        public ReAuthPublisher()
        {

        }

        private EndpointConfiguration ConfigureEndpoint()
        {
            var senderConfig = new EndpointConfiguration("reAuth-sender");
            senderConfig.SendOnly();

           

            var routing = senderConfig.UseTransport<MsmqTransport>().Routing();
            routing.RouteToEndpoint(typeof(ReAuthorizationEvent), "pfs.reauthorization");

            var conventions = senderConfig.Conventions();
            conventions.DefiningEventsAs(Messages.Conventions.IsEvent);

            senderConfig.UsePersistence<NHibernatePersistence>();
            senderConfig.UseSerialization<JsonSerializer>();
            senderConfig.EnableInstallers();

            return senderConfig;
        }

        public async Task Send()
        {
            await endpoint.Publish(new ReAuthorizationEvent() { ContractId = 30, ServiceId = 40, SubscriberId = 50 }).ConfigureAwait(false);
        }

        public async Task Start()
        {
            var config = ConfigureEndpoint();
            endpoint = await Endpoint.Start(config).ConfigureAwait(false);
        }

        public async Task Stop()
        {
            await endpoint.Stop();
        }
    }
}
