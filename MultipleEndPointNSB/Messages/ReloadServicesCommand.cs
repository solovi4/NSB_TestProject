using System;
using Messages.Interfaces;

namespace Messages
{
    [Serializable]
    public class ReloadServicesCommand : ICommand
    {
        public int[] ServiceIds { get; set; }
    }
}
