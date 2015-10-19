using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventIAConstructor.EventAI.Metadata
{
    public enum UnitFlags
    {
        UNK_0               = 0x00000001,
        NON_ATTACKABLE      = 0x00000002,           // not attackable
        DISABLE_MOVE        = 0x00000004,
        PVP_ATTACKABLE      = 0x00000008,           // allow apply pvp rules to attackable state in addition to faction dependent state
        RENAME              = 0x00000010,
        PREPARATION         = 0x00000020,           // don't take reagents for spells with SPELL_ATTR_EX5_NO_REAGENT_WHILE_PREP
        UNK_6               = 0x00000040,
        NOT_ATTACKABLE_1    = 0x00000080,           // ?? (UNIT_FLAG_PVP_ATTACKABLE | UNIT_FLAG_NOT_ATTACKABLE_1) is NON_PVP_ATTACKABLE
        OOC_NOT_ATTACKABLE  = 0x00000100,           // 2.0.8 - (OOC Out Of Combat) Can not be attacked when not in combat. Removed if unit for some reason enter combat (flag probably removed for the attacked and it's party/group only)
        PASSIVE             = 0x00000200,           // makes you unable to attack everything. Almost identical to our "civilian"-term. Will ignore it's surroundings and not engage in combat unless "called upon" or engaged by another unit.
        LOOTING             = 0x00000400,           // loot animation
        PET_IN_COMBAT       = 0x00000800,           // in combat?, 2.0.8
        PVP                 = 0x00001000,           // changed in 3.0.3
        SILENCED            = 0x00002000,           // silenced, 2.1.1
        UNK_14              = 0x00004000,           // 2.0.8
        UNK_15              = 0x00008000,           // related to jerky movement in water?
        UNK_16              = 0x00010000,           // removes attackable icon
        PACIFIED            = 0x00020000,           // 3.0.3 ok
        STUNNED             = 0x00040000,           // 3.0.3 ok
        IN_COMBAT           = 0x00080000,
        TAXI_FLIGHT         = 0x00100000,           // disable casting at client side spell not allowed by taxi flight (mounted?), probably used with 0x4 flag
        DISARMED            = 0x00200000,           // 3.0.3, disable melee spells casting..., "Required melee weapon" added to melee spells tooltip.
        CONFUSED            = 0x00400000,
        FLEEING             = 0x00800000,
        PLAYER_CONTROLLED   = 0x01000000,           // used in spell Eyes of the Beast for pet... let attack by controlled creature
        NOT_SELECTABLE      = 0x02000000,
        SKINNABLE           = 0x04000000,
        MOUNT               = 0x08000000,
        UNK_28              = 0x10000000,
        UNK_29              = 0x20000000,           // used in Feing Death spell
        SHEATHE             = 0x40000000,
    }
}
