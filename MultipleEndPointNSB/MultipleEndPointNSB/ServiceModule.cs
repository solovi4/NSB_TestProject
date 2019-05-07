using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
