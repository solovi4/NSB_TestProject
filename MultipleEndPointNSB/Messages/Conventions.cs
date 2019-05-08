using Messages.Interfaces;
using System;
using NServiceBus;

public static class Conventions
{
    static bool IsEvent(Type t)
    {
        return t != null && t.IsDefined(typeof(EventAttribute), true);
    }

    static bool IsCommand(Type t)
    {
        return t != null && t.IsDefined(typeof(CommandAttribute), true);
    }

    public static void Apply(this ConventionsBuilder instance)
    {
        instance.DefiningEventsAs(IsEvent);
        instance.DefiningCommandsAs(IsCommand);
    }
}
