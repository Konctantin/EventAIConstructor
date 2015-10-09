using System;

namespace EventIAConstructor.EventAI.Metadata
{
    [Flags]
    public enum TemporaryFaction : int
    {
        NONE                = 0x00,
        RESTORE_RESPAWN     = 0x01,
        RESTORE_COMBAT_STOP = 0x02,
        RESTORE_REACH_HOME  = 0x04,
    }
}