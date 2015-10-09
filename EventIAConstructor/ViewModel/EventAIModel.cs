namespace EventIAConstructor.ViewModel
{
    public class EventAIModel : BaseViewModel
    {
        private int id, creatureId, phase, chance, flag;

        public EventAIModel(int id, int crid, int phase, int chance, int ef)
        {
            Id = id;
            CreatureId = crid;
            PhaseMask = phase;
            Chance = chance;
            EventFlags = ef;
        }

        /// <summary>
        /// This value is merely an incrementing counter of the current Event number.
        /// Required for sql queries.
        /// (ACID Standards: CreatureID+Additional 2 digit Incriment Starting with 01)
        /// </summary>
        public int Id { get { return id; } set { if (value != id) { id = value; OnPropertyChanged(); } } }

        /// <summary>
        /// Creature ID which should trigger this event (This is entry value from `creature_template` table).
        /// </summary>
        public int CreatureId { get { return creatureId; } set { if (value != creatureId) { creatureId = value; OnPropertyChanged(); } } }

        /// <summary>
        /// Mask with phases this event should NOT trigger in* (See footnote for more details on using any other value then 0)
        /// </summary>
        public int PhaseMask { get { return phase; } set { if (value != phase) { phase = value; OnPropertyChanged(); } } }

        /// <summary>
        /// Percentage chance of triggering the event (1 - 100)
        /// </summary>
        public int Chance { get { return chance; } set { if (value != chance) { chance = value; OnPropertyChanged(); } } }

        /// <summary>
        /// Event Flags (Used to select Repeatable or Dungeon Heroic Mode)... <see cref="EventAIMetadata.EventFlags"/>
        /// </summary>
        public int EventFlags { get { return flag; } set { if (value != flag) { flag = value; OnPropertyChanged(); } } }

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
    }
}