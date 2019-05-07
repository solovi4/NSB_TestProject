using Messages;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher
{
    class ReloadServicePublisher
    {
        private int[] serviceIds = { 800, 520, 660 };
        private IEndpointInstance endpoint;
        public ReloadServicePublisher()
        {

        }

        private EndpointConfiguration ConfigureEndpoint()
        {
            var senderConfig = new EndpointConfiguration("pfs-sender");
            senderConfig.SendOnly();

            var routing = senderConfig.UseTransport<MsmqTransport>().Routing();
            routing.RouteToEndpoint(typeof(ReloadServicesCommand), "pfs.services");

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

        public async Task Stop()
        {
            await endpoint.Stop();
        }

        public async Task Send()
        {
            await endpoint.Send(new ReloadServicesCommand { ServiceIds = serviceIds }).ConfigureAwait(false);            
        }


    }
}
