using Messages;

namespace MultipleEndPointNSB
{
    interface IServiceForPfs
    {
        void Send(ReloadServicesCommand reloadServicesCommand);
    }
}
