using Messages;

namespace MultipleEndPointNSB
{
    interface IServiceForPfs
    {
        void Send(MySystem.ReloadServices reloadServicesCommand);
    }
}
