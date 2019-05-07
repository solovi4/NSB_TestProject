using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
