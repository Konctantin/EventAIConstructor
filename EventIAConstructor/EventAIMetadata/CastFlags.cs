using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventIAConstructor.EventAIMetadata
{
    [Flags]
    public enum CastFlags : int
    {
        INTURRUPT_PREVIOUS  = 1,
        TRIGGERED           = 2,
        FORCE_CAST          = 4,
        NO_MELEE_IF_OOM     = 8,
        FORCE_TARGET_SELF   = 16,
        AURA_NOT_PRESENT    = 32,
    }
}
