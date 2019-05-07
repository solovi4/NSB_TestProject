using System;

namespace MultipleEndPointNSB
{
    class ConfigReader
    {
        public static ReAuthEndpointConfig ReadReAuthConfig()
        {
            ReAuthEndpointConfig config = new ReAuthEndpointConfig
            {
                DelayedNumberOfRetries = 10,
                ImmediateNumberOfRetries = 10,
                MaxDop = 8,
                Queue = "pfs.reauthorization",
                ErrorQueue = "pfs.reauthorization.error",
                DelayedTimeIncrease = new TimeSpan(0, 0, 20),
                Install = true
            };

            return config;
        }

        public static PfsServiceEndPointConfig ReadPfsServiceEndPoitConfig()
        {
            PfsServiceEndPointConfig config = new PfsServiceEndPointConfig
            {
                DelayedNumberOfRetries = 10,
                ImmediateNumberOfRetries = 10,
                MaxDop = 8,
                Queue = "pfs.services",
                ErrorQueue = "pfs.services.error",
                DelayedTimeIncrease = new TimeSpan(0, 0, 20),
                Install = true
            };

            return config;
        }
    }
}
