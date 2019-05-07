using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleEndPointNSB
{
    interface IServiceForReAuth
    {
        void Write(ReAuthorizationEvent reAuthorizationEvent);

    }
}
