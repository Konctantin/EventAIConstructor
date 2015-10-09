
namespace EventIAConstructor.EventAI.Metadata
{
    public enum TargetType : int
    {
        /// <summary>
        /// Self Cast
        /// </summary>
        SELF                            = 0,
        /// <summary>
        /// Current Target (ie: Highest Aggro)
        /// </summary>
        HOSTILE                         = 1,
        /// <summary>
        /// Second Highest Aggro (Generaly used for Cleaves and some special attacks)
        /// </summary>
        HOSTILE_SECOND_AGGRO            = 2,
        /// <summary>
        /// Dead Last on Aggro (no idea what this could be used for)
        /// </summary>
        HOSTILE_LAST_AGGRO              = 3,
        /// <summary>
        /// Random Target on The Threat List
        /// </summary>
        HOSTILE_RANDOM                  = 4,
        /// <summary>
        /// Any Random Target Except Top Threat
        /// </summary>
        HOSTILE_RANDOM_NOT_TOP          = 5,
        /// <summary>
        /// Unit Who Caused This Event to Occur
        /// </summary>
        ACTION_INVOKER                  = 6,
        /// <summary>
        /// Unit who is responsible for Event to occur
        /// </summary>
        ACTION_INVOKER_OWNER            = 7,
        /// <summary>
        /// Random Player on The Threat List
        /// </summary>
        HOSTILE_RANDOM_PLAYER           = 8,
        /// <summary>
        /// Any Random Player Except Top Threat
        /// </summary>
        HOSTILE_RANDOM_NOT_TOP_PLAYER   = 9,
        /// <summary>
        /// Creature who sent a received AIEvent - only triggered by EVENT_T_RECEIVE_AI_EVENT
        /// </summary>
        EVENT_SENDER                    = 10,
    }
}
