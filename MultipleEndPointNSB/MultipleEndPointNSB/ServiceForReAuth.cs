using System;
using Messages;

namespace MultipleEndPointNSB
{
    class ServiceForReAuth : IServiceForReAuth
    {
        public void Write(MySystem.ReAuthorization reAuthorizationEvent)
        {
            Console.WriteLine($"ReAuth received contract = {reAuthorizationEvent.ContractId} service = {reAuthorizationEvent.ServiceId} subscriber = {reAuthorizationEvent.SubscriberId}");
        }
    }
}
