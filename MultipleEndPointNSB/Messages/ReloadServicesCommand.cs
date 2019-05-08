using System;
using Messages.Interfaces;

namespace MySystem
{
    [Serializable]
    [Command]
    public class ReloadServices
    {
        public int[] ServiceIds { get; set; }
    }
}
