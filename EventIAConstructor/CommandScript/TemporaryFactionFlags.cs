using System;

namespace EventIAConstructor.CommandScript
{
    [Flags]
    public enum TemporaryFactionFlags
    {
        NONE                  = 0x00,  // When no flag is used in temporary faction change, faction will be persistent. It will then require manual change back to default/another faction when changed once
        RESTORE_RESPAWN       = 0x01,  // Default faction will be restored at respawn
        RESTORE_COMBAT_STOP   = 0x02,  // ... at CombatStop() (happens at creature death, at evade or custom scripte among others)
        RESTORE_REACH_HOME    = 0x04,  // ... at reaching home in home movement (evade), if not already done at CombatStop()
                                                   // The next flags allow to remove unit_flags combined with a faction change (also these flags will be reapplied when the faction is changed back)
        TOGGLE_NON_ATTACKABLE = 0x08,  // Remove UNIT_FLAG_NON_ATTACKABLE(0x02) when faction is changed (reapply when temp-faction is removed)
        TOGGLE_OOC_NOT_ATTACK = 0x10,  // Remove UNIT_FLAG_OOC_NOT_ATTACKABLE(0x100) when faction is changed (reapply when temp-faction is removed)
        TOGGLE_PASSIVE        = 0x20,  // Remove UNIT_FLAG_PASSIVE(0x200) when faction is changed (reapply when temp-faction is removed)
        TOGGLE_PACIFIED       = 0x40,  // Remove UNIT_FLAG_PACIFIED(0x20000) when faction is changed (reapply when temp-faction is removed)
        TOGGLE_NOT_SELECTABLE = 0x80,  // Remove UNIT_FLAG_NOT_SELECTABLE(0x2000000) when faction is changed (reapply when temp-faction is removed)
    }
}
