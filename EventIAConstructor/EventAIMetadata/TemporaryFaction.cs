using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventIAConstructor.EventAIMetadata
{
    [Flags]
    public enum TemporaryFaction
    {
        NONE                = 0x00,
        RESTORE_RESPAWN     = 0x01,
        RESTORE_COMBAT_STOP = 0x02,
        RESTORE_REACH_HOME  = 0x04,
    }
}