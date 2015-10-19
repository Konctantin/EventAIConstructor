
namespace EventIAConstructor.EventAI.Metadata
{
    /// <summary>
    /// Events that do not have lables on them are events that are directly involved with the in and out of combat state.
    /// </summary>
    public enum EventType
    {
        TIMER_IN_COMBAT         = 0,
        TIMER_OOC               = 1,
        HP                      = 2,
        MANA                    = 3,
        AGGRO                   = 4,
        KILL                    = 5,
        DEATH                   = 6,
        EVADE                   = 7,
        SPELLHIT                = 8,
        RANGE                   = 9,
        OOC_LOS                 = 10,
        SPAWNED                 = 11,
        TARGET_HP               = 12,
        TARGET_CASTING          = 13,
        FRIENDLY_HP             = 14,
        FRIENDLY_IS_CC          = 15,
        FRIENDLY_MISSING_BUFF   = 16,
        SUMMONED_UNIT           = 17,
        TARGET_MANA             = 18,
        REACHED_HOME            = 21,
        RECEIVE_EMOTE           = 22,
        AURA                    = 23,
        TARGET_BUFFED           = 24,
        SUMMONED_JUST_DIED      = 25,
        SUMMONED_JUST_DESPAWN   = 26,
        MISSING_AURA            = 27,
        TARGET_MISSING_AURA     = 28,
        TIMER_GENERIC           = 29,
        RECEIVE_AI_EVENT        = 30,
        ENERGY                  = 31,
    }
}
