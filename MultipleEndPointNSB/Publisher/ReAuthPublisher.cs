﻿using Messages;
using NServiceBus;
using System.Threading.Tasks;

namespace Publisher
{
    class ReAuthPublisher
    {
        private IEndpointInstance endpoint;

        private EndpointConfiguration ConfigureEndpoint()
        {
            var senderConfig = new EndpointConfiguration("reAuth-sender");
            senderConfig.SendOnly();

           

            var routing = senderConfig.UseTransport<MsmqTransport>().Routing();
            routing.RouteToEndpoint(typeof(MySystem.ReAuthorization), "pfs.reauthorization");

            senderConfig.Conventions().Apply();

            senderConfig.UsePersistence<NHibernatePersistence>();
            senderConfig.UseSerialization<JsonSerializer>();
            senderConfig.EnableInstallers();

            return senderConfig;
        }

        public Task Send()
        {
            return endpoint.Publish(new MySystem.ReAuthorization { ContractId = 30, ServiceId = 40, SubscriberId = 50 });
        }

        public async Task Start()
        {
            var config = ConfigureEndpoint();
            endpoint = await Endpoint.Start(config).ConfigureAwait(false);
        }

        public Task Stop()
        {
            return endpoint.Stop();
        }
    }
}
