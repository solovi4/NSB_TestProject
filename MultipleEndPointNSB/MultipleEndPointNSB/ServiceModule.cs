using Autofac;

namespace MultipleEndPointNSB
{
    class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ServiceForPfs())
                .As<IServiceForPfs>()
                .SingleInstance();

            builder.Register(c => new ServiceForReAuth())
                .As<IServiceForReAuth>()
                .SingleInstance();
        }
    }
}
