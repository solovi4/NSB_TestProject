using Messages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public static class Conventions
    {
        private static readonly List<Assembly> assemblies = new List<Assembly> {
            typeof(ReAuthorizationEvent).Assembly,
            typeof(ReloadServicesCommand).Assembly
        };

        public static bool IsEvent(Type t)
        {
            return assemblies.Contains(t.Assembly)
                   && typeof(IEvent).IsAssignableFrom(t)
                   && !t.IsAbstract;
        }


        public static bool IsCommand(Type t)
        {
            return assemblies.Contains(t.Assembly)
                   && typeof(ICommand).IsAssignableFrom(t)
                   && !t.IsAbstract;
        }
    }
}
