using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleEndPointNSB
{
    interface IServiceForPfs
    {
        void Send(ReloadServicesCommand reloadServicesCommand);
    }
}
