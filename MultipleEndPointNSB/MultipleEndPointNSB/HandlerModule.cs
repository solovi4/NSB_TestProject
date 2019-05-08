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
                .As<IHandleMessages<MySystem.ReAuthorization>>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<HandlerPfsServices>()
                .As<IHandleMessages<MySystem.ReloadServices>>()
                .AsSelf()
                .SingleInstance();
        }
    }
}
