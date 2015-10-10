using System;

namespace EventIAConstructor.EventAI.Metadata
{
    [Flags]
    public enum CastFlags
    {
        INTURRUPT_PREVIOUS  = 1,
        TRIGGERED           = 2,
        FORCE_CAST          = 4,
        NO_MELEE_IF_OOM     = 8,
        FORCE_TARGET_SELF   = 16,
        AURA_NOT_PRESENT    = 32,
    }
}
