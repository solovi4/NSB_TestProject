using System;

namespace MultipleEndPointNSB
{
    class EndPointConfig
    {
        public string Queue { get; set; }
        public string ErrorQueue { get; set; } 
        public int MaxDop { get; set; }
        public int ImmediateNumberOfRetries { get; set; }
        public int DelayedNumberOfRetries { get; set; }
        public TimeSpan DelayedTimeIncrease { get; set; }
        public bool Install { get; set; }
    }

    class ReAuthEndpointConfig : EndPointConfig
    {

    }

    class PfsServiceEndPointConfig : EndPointConfig
    {

    }
     
}
