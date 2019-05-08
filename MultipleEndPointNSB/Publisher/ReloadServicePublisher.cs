using Messages;
using NServiceBus;
using System.Threading.Tasks;

namespace Publisher
{
    class ReloadServicePublisher
    {
        private int[] serviceIds = { 800, 520, 660 };
        private IEndpointInstance endpoint;

        private EndpointConfiguration ConfigureEndpoint()
        {
            var senderConfig = new EndpointConfiguration("pfs-sender");
            senderConfig.SendOnly();

            senderConfig.Conventions().Apply();

            var routing = senderConfig.UseTransport<MsmqTransport>().Routing();
            routing.RouteToEndpoint(typeof(MySystem.ReloadServices), "pfs.services");

            senderConfig.UsePersistence<NHibernatePersistence>();
            senderConfig.UseSerialization<JsonSerializer>();
            senderConfig.EnableInstallers();

            return senderConfig;
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

        public Task Send()
        {
            return endpoint.Send(new MySystem.ReloadServices {ServiceIds = serviceIds});
        }


    }
}
