using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using NServiceBus;

namespace MultipleEndPointNSB
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ContainerBuilder();

            ReAuthEndpointConfig reAuthEndpointConfig = ConfigReader.ReadReAuthConfig();
            PfsServiceEndPointConfig pfsServiceEndPointConfig = ConfigReader.ReadPfsServiceEndPoitConfig();

            builder.RegisterInstance(reAuthEndpointConfig);
            builder.RegisterInstance(pfsServiceEndPointConfig);
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new HandlerModule());
            builder.RegisterModule(new ReceiverModule());
            
            var container = builder.Build();
            
            var endPointPfsServices = container.Resolve<EndPointPfsServices>();
            var endPointReAuth = container.Resolve<EndPointReAuth>();

            await endPointPfsServices.Start(container);
            await endPointReAuth.Start(container);            

            Console.ReadLine();

            await endPointReAuth.Stop();
            await endPointPfsServices.Stop();
        }

        
    }
}
