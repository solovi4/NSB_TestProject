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
        private string _queue = "pfs.services";
        private string _errorQueue = "pfs.services.error";
        private int _maxDop = 8;
        private int _immediateNumberOfRetries = 10;
        private int _delayedNumberOfRetries = 10;
        private TimeSpan _delayedTimeIncrease = new TimeSpan(0, 0, 20);
        private bool _install = true;
        private IEndpointInstance endpointInstance;

        private EndpointConfiguration ConfigureEndpoint()
        {
            var endpointConfiguration = new EndpointConfiguration(_queue);

            endpointConfiguration.UsePersistence<NHibernatePersistence>();
            endpointConfiguration.UseTransport<MsmqTransport>();
            endpointConfiguration.UseSerialization<JsonSerializer>();
            endpointConfiguration.SendFailedMessagesTo(_errorQueue);
            endpointConfiguration.LimitMessageProcessingConcurrencyTo(_maxDop);

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

            //var conventions = endpointConfiguration.Conventions();
            //conventions.DefiningCommandsAs(Check);

            var scanner = endpointConfiguration.AssemblyScanner();
            scanner.ScanAssembliesInNestedDirectories = true;
            scanner.ScanAppDomainAssemblies = true;

            if (_install)
                endpointConfiguration.EnableInstallers();

            return endpointConfiguration;
        }

        private bool Check(Type t)
        {
            return t.Assembly == typeof(ReloadServicesCommand).Assembly;
        }

        public async Task Start()
        {
            var configuration = ConfigureEndpoint();
            endpointInstance = await Endpoint.Start(configuration).ConfigureAwait(false);           
        }

        public async Task Stop()
        {
            await endpointInstance.Stop();
        }
    }
}
