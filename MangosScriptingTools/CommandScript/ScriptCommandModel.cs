using EventIAConstructor.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventIAConstructor.CommandScript
{
    public class ScriptCommandModel : BaseViewModel
    {
        public int Id                      { get; set; }
        public int Delay                   { get; set; }
        public CommandScriptType Command   { get; set; }
        public int Datalong                { get; set; }
        public int Datalong2               { get; set; }
        public int BuddyEntry              { get; set; }
        public int SearchRadius            { get; set; }
        public ScriptCommandFlag DataFlags { get; set; }
        public int DataInt                 { get; set; }
        public int DataInt2                { get; set; }
        public int DataInt3                { get; set; }
        public int DataInt4                { get; set; }
        public float X                     { get; set; }
        public float Y                     { get; set; }
        public float Z                     { get; set; }
        public float O                     { get; set; }
        public string Comments             { get; set; }
    }
}
