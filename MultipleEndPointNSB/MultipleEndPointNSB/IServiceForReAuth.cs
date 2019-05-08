using Messages;

namespace MultipleEndPointNSB
{
    interface IServiceForReAuth
    {
        void Write(MySystem.ReAuthorization reAuthorizationEvent);

    }
}
