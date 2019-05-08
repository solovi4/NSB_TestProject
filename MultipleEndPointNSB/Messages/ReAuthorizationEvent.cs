using System;
using Messages.Interfaces;

namespace MySystem
{
    [Serializable]
    [Event]
    public class ReAuthorization
    {
        public int ContractId { get; set; }

        public int? SubscriberId { get; set; }

        public int ServiceId { get; set; }
    }
}
