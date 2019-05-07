using Autofac;

namespace MultipleEndPointNSB
{
    class ReceiverModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EndPointPfsServices>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<EndPointReAuth>()
                .AsSelf()
                .SingleInstance();
        }
    }
}
