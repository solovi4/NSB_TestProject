using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
