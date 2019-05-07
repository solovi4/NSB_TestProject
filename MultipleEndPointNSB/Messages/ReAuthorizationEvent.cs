using System;
using Messages.Interfaces;

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
