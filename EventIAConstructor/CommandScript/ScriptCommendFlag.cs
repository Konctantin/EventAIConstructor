using System;

namespace EventIAConstructor.CommandScript
{
    [Flags]
    public enum ScriptCommendFlag : int
    {
        BUDDY_AS_TARGET     = 0x01,
        REVERSE_DIRECTION   = 0x02,
        SOURCE_TARGETS_SELF = 0x04,
        COMMAND_ADDITIONAL  = 0x08, //(Only for some commands possible)
        BUDDY_BY_GUID       = 0x10, //(Interpret search_radius as buddy's guid)
        BUDDY_IS_PET        = 0x20, //(Do not search for an npc, but for a pet)
        BUDDY_IS_DESPAWNED  = 0X40, //(Search for a buddy that is dead or despawned)
    }
}
