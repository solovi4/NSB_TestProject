using System;
using System.Linq;
using Messages;

namespace MultipleEndPointNSB
{
    class ServiceForPfs : IServiceForPfs
    {
        public void Send(ReloadServicesCommand reloadServicesCommand)
        {
            Console.WriteLine($"ReloadServiceCommandRecieved {string.Concat(reloadServicesCommand.ServiceIds.Select(id => id.ToString() + " "))}!!!!!!!!!!!!!!!!!!");
        }
    }
}
