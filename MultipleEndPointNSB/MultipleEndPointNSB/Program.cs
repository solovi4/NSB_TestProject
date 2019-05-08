using System;
using System.Threading.Tasks;
using Autofac;

namespace MultipleEndPointNSB
{
    class Program
    {
        static async Task Main()
        {
            Console.Title = "Receiver";
            var builder = new ContainerBuilder();

            ReAuthEndpointConfig reAuthEndpointConfig = ConfigReader.ReadReAuthConfig();
            PfsServiceEndPointConfig pfsServiceEndPointConfig = ConfigReader.ReadPfsServiceEndPoitConfig();

            builder.RegisterInstance(reAuthEndpointConfig);
            builder.RegisterInstance(pfsServiceEndPointConfig);
            builder.RegisterModule(new HandlerModule());
            builder.RegisterModule(new ServiceModule());
            
            builder.RegisterModule(new ReceiverModule());
            
            var container = builder.Build();
            
            var endPointPfsServices = container.Resolve<EndPointPfsServices>();
            var endPointReAuth = container.Resolve<EndPointReAuth>();

            
            await endPointPfsServices.Start(container).ConfigureAwait(false);
            await endPointReAuth.Start(container).ConfigureAwait(false);

            Console.ReadLine();

            await endPointReAuth.Stop().ConfigureAwait(false);
            await endPointPfsServices.Stop().ConfigureAwait(false);
        }

        
    }
}
