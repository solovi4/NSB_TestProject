using Autofac;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleEndPointNSB
{
    class EndPointPfsServices
    {
        private string _queue;
        private string _errorQueue;
        private int _maxDop;
        private int _immediateNumberOfRetries;
        private int _delayedNumberOfRetries;
        private TimeSpan _delayedTimeIncrease;
        private bool _install;
        private IEndpointInstance endpointInstance;

        public EndPointPfsServices(PfsServiceEndPointConfig config)
        {
            _queue = config.Queue;
            _errorQueue = config.ErrorQueue;
            _maxDop = config.MaxDop;
            _immediateNumberOfRetries = config.ImmediateNumberOfRetries;
            _delayedNumberOfRetries = config.DelayedNumberOfRetries;
            _delayedTimeIncrease = config.DelayedTimeIncrease;
            _install = config.Install;
        }

        private EndpointConfiguration ConfigureEndpoint(IContainer container)
        {
            var endpointConfiguration = new EndpointConfiguration(_queue);

            endpointConfiguration.UsePersistence<NHibernatePersistence>();
            endpointConfiguration.UseTransport<MsmqTransport>();
            endpointConfiguration.UseSerialization<JsonSerializer>();
            endpointConfiguration.SendFailedMessagesTo(_errorQueue);
            endpointConfiguration.LimitMessageProcessingConcurrencyTo(_maxDop);

            endpointConfiguration.UseContainer<AutofacBuilder>(
                customizations: customizations =>
                {
                    customizations.ExistingLifetimeScope(container);
                });

            var recoverability = endpointConfiguration.Recoverability();
            recoverability.Immediate(
                customizations: immediate =>
                {
                    immediate.NumberOfRetries(_immediateNumberOfRetries);
                });

            recoverability.Delayed(
                customizations: delayed =>
                {
                    var numberOfRetries = delayed.NumberOfRetries(_delayedNumberOfRetries);
                    numberOfRetries.TimeIncrease(_delayedTimeIncrease);
                });

            if (_install)
                endpointConfiguration.EnableInstallers();

            return endpointConfiguration;
        }

        public async Task Start(IContainer container)
        {
            var configuration = ConfigureEndpoint(container);
            endpointInstance = await Endpoint.Start(configuration).ConfigureAwait(false);           
        }

        public async Task Stop()
        {
            await endpointInstance.Stop();
        }
    }
}
