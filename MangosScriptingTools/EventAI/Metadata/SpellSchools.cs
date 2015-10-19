using System;

namespace EventIAConstructor.EventAI.Metadata
{
    public enum SpellSchools
    {
        NORMAL = 0,
        HOLY   = 1,
        FIRE   = 2,
        NATURE = 3,
        FROST  = 4,
        SHADOW = 5,
        ARCANE = 6
    };

    [Flags]
    public enum SpellSchoolMask
    {
        NONE    = 0,
        NORMAL  = (1 << SpellSchools.NORMAL),
        HOLY    = (1 << SpellSchools.HOLY),
        FIRE    = (1 << SpellSchools.FIRE),
        NATURE  = (1 << SpellSchools.NATURE),
        FROST   = (1 << SpellSchools.FROST),
        SHADOW  = (1 << SpellSchools.SHADOW),
        ARCANE  = (1 << SpellSchools.ARCANE),
        ALL     = -1
    };
}
