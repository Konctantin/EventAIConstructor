using EventIAConstructor.Common;
using System;
using System.Runtime.CompilerServices;

namespace EventIAConstructor.EventAI.ViewModel
{
    public class EventAIModel : BaseViewModel
    {
        int id, creatureId, phase, chance, flag;
        string comment;

        public EventAIModel(int id, int crid, int phase, int chance, int ef)
        {
            Id = id;
            CreatureId = crid;
            PhaseMask = phase;
            Chance = chance;
            EventFlags = ef;
        }

        /// <summary>
        /// This value is merely an incrementing counter of the current Event number. Required for sql queries.
        /// (ACID Standards: CreatureID+Additional 2 digit Incriment Starting with 01)
        /// </summary>
        public int Id { get { return id; } set { if (value != id) { id = value; UpdateAll(); } } }

        /// <summary>
        /// Creature ID which should trigger this event (This is entry value from `creature_template` table).
        /// </summary>
        public int CreatureId { get { return creatureId; } set { if (value != creatureId) { creatureId = value; UpdateAll(); } } }

        /// <summary>
        /// Mask with phases this event should NOT trigger in* (See footnote for more details on using any other value then 0)
        /// </summary>
        public int PhaseMask { get { return phase; } set { if (value != phase) { phase = value; UpdateAll(); } } }

        /// <summary>
        /// Percentage chance of triggering the event (1 - 100)
        /// </summary>
        public int Chance { get { return chance; } set { if (value != chance) { chance = value; UpdateAll(); } } }

        /// <summary>
        /// Event Flags (Used to select Repeatable or Dungeon Heroic Mode)... <see cref="EventAIMetadata.EventFlags"/>
        /// </summary>
        public int EventFlags { get { return flag; } set { if (value != flag) { flag = value; UpdateAll(); } } }

        /// <summary>
        /// The type of event you want to script. (see "Event Types" below for different values)
        /// </summary>
        public EventModel Event { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ActionModel Action1 { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ActionModel Action2 { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ActionModel Action3 { get; set; }

        public string Comment { get { return comment; } set { if (value != comment) { comment = value; UpdateAll(); } } }

        public string Sql
        {
            get
            {
                return
                    $"DELETE FROM creature_ai_scripts WHERE id = {Id};{Environment.NewLine}"
                    + $"UPDATE creature_template SET AIName = 'EventAI' WHERE entry = {CreatureId};{Environment.NewLine}"
                    + $"INSERT INTO creature_ai_scripts VALUES("
                    + $"{Id}, {CreatureId}, {Event.Type}, {PhaseMask}, {Chance}, {EventFlags}"
                    + $", {Event.Param1}, {Event.Param2}, {Event.Param3}, {Event.Param4}"
                    + $", {Action1.Type}, {Action1.Param1}, {Action1.Param2}, {Action1.Param3}"
                    + $", {Action2.Type}, {Action2.Param1}, {Action2.Param2}, {Action2.Param3}"
                    + $", {Action3.Type}, {Action3.Param1}, {Action3.Param2}, {Action3.Param3}"
                    + $", '{Comment.Replace("'", "\'").Replace("\\", "\\\\")}');";
            }
        }

        internal void UpdateAll([CallerMemberName] string propertyName = "")
        {
            OnPropertyChanged(propertyName);
            OnPropertyChanged("Sql");
        }
    }
}