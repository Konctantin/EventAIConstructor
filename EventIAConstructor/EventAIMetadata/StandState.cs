using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventIAConstructor.EventAIMetadata
{
    public enum StandState : int
    {
        STAND            = 0,
        SIT              = 1,
        SIT_CHAIR        = 2,
        SLEEP            = 3,
        SIT_LOW_CHAIR    = 4,
        SIT_MEDIUM_CHAIR = 5,
        SIT_HIGH_CHAIR   = 6,
        DEAD             = 7,
        KNEEL            = 8
    };
}
