using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages;

namespace MultipleEndPointNSB
{
    class ServiceForReAuth : IServiceForReAuth
    {
        public void Write(ReAuthorizationEvent reAuthorizationEvent)
        {
            Console.WriteLine($"ReAuth received contract = {reAuthorizationEvent.ContractId} service = {reAuthorizationEvent.ServiceId} subscriber = {reAuthorizationEvent.SubscriberId}");
        }
    }
}
