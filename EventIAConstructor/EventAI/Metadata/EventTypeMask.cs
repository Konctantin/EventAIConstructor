using System;

namespace EventIAConstructor.EventAI.Metadata
{
    [Flags]
    public enum EventTypeMask
    {
        NONE             = 0x00,
        JUST_DIED        = 0x01,
        CRITICAL_HEALTH  = 0x02,
        LOST_HEALTH      = 0x04,
        LOST_SOME_HEALTH = 0x08,
        GOT_FULL_HEALTH  = 0x10,
    }
}
