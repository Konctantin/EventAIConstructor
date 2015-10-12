using System;

namespace EventIAConstructor.EventAI.Metadata
{
    /// <summary>
    /// Below is the list of current Event Flags that EventAI can handle.
    /// </summary>
    [Flags]
    public enum EventFlags
    {
        NONE                = 0,
        /// <summary>
        /// Event repeats (Does not repeat if this flag is not set)
        /// </summary>
        REPEATABLE          = 1,
        /// <summary>
        /// Event occurs in Normal instance difficulty (will not occur in Normal if not set)
        /// </summary>
        NORMAL              = 2,
        /// <summary>
        /// Event occurs in Heroic instance difficulty (will not occur in Heroic if not set)
        /// </summary>
        HEROIC              = 4,
        /// <summary>
        /// At event occur execute one random action from event actions instead all actions.
        /// </summary>
        RANDOM_ACTION       = 32,
        /// <summary>
        /// Prevents events from occuring on Release builds. Useful for testing new features.
        /// </summary>
        DEBUG_ONLY          = 128,
    }
}
