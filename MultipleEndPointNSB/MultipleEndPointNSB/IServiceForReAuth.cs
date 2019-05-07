using Messages;

namespace MultipleEndPointNSB
{
    interface IServiceForReAuth
    {
        void Write(ReAuthorizationEvent reAuthorizationEvent);

    }
}
