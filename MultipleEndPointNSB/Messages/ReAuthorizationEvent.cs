using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Messages
{
    [Serializable]
    public class ReAuthorizationEvent : IEvent
    {
        public int ContractId { get; set; }

        public int? SubscriberId { get; set; }

        public int ServiceId { get; set; }
    }
}
