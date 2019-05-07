using Autofac;
using Messages;
using NServiceBus;

namespace MultipleEndPointNSB
{
    class HandlerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {            

            builder.RegisterType<ReAuthHandler>()
                .As<IHandleMessages<ReAuthorizationEvent>>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<HandlerPfsServices>()
                .As<IHandleMessages<ReloadServicesCommand>>()
                .AsSelf()
                .SingleInstance();
        }
    }
}
