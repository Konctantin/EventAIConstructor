using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventIAConstructor.EventAIMetadata;
using EventIAConstructor.ViewModel.ActionModel;
using EventIAConstructor.ViewModel.EventModel;

namespace EventIAConstructor.ViewModel
{
    public class EventAIModel : BaseViewModel
    {
        public EventAIModel()
        {
            EventValues = new int[4];
        }

        /// <summary>
        /// This value is merely an incrementing counter of the current Event number.
        /// Required for sql queries.
        /// (ACID Standards: CreatureID+Additional 2 digit Incriment Starting with 01)
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Creature ID which should trigger this event (This is entry value from `creature_template` table).
        /// </summary>
        public int CreatureId { get; set; }

        /// <summary>
        /// Mask with phases this event should NOT trigger in* (See footnote for more details on using any other value then 0)
        /// </summary>
        public uint PhaseMask { get; set; }

        /// <summary>
        /// Percentage chance of triggering the event (1 - 100)
        /// </summary>
        public int Chance { get; set; }

        /// <summary>
        /// Event Flags (Used to select Repeatable or Dungeon Heroic Mode)... <see cref="EventIAConstructor.EventAIMetadata.EventFlags"/>
        /// </summary>
        public int EventFlags { get; set; }

        #region EventType

        private EventType eventType;

        /// <summary>
        /// The type of event you want to script. (see "Event Types" below for different values)
        /// </summary>
        public EventType EventType
        {
            get { return eventType; }
            set
            {
                if (value != eventType)
                {
                    this.eventType = value;
                    this.EventData = GetEventTypeData();
                    OnPropertyChanged();
                    OnPropertyChanged("EventData");
                }
            }
        }

        public int[] EventValues { get; set; }

        public BaseEventModel EventData
        {
            get { return GetEventTypeData(); }
            set
            {
                if (value == null)
                    EventValues = new int[4];
                else
                    EventValues = new int[] { value.Param1, value.Param2, value.Param3, value.Param4 };
            }
        }

        #endregion

        #region Action type 1

        private ActionType actionType1;

        public int[] ActionValue1 = new int[3];

        public ActionType ActionType1
        {
            get { return actionType1; }
            set
            {
                if (value != actionType1)
                {
                    actionType1 = value;
                    ActionData1 = GetActionTypeData(value, ActionValue1);
                    OnPropertyChanged();
                    OnPropertyChanged("ActionData1");
                }
            }
        }

        public BaseActionModel ActionData1 { get; set; }

        #endregion

        #region Action type 2

        private ActionType actionType2;

        public int[] ActionValue2 = new int[3];

        public ActionType ActionType2
        {
            get { return actionType2; }
            set
            {
                if (value != actionType2)
                {
                    actionType2 = value;
                    ActionData2 = GetActionTypeData(value, ActionValue2);
                    OnPropertyChanged();
                    OnPropertyChanged("ActionData2");
                }
            }
        }

        public BaseActionModel ActionData2 { get; set; }

        #endregion

        #region Action type 3

        private ActionType actionType3;

        public int[] ActionValue3 = new int[3];

        public ActionType ActionType3
        {
            get { return actionType3; }
            set
            {
                if (value != actionType3)
                {
                    actionType3 = value;
                    ActionData3 = GetActionTypeData(value, ActionValue3);
                    OnPropertyChanged();
                    OnPropertyChanged("ActionData3");
                }
            }
        }

        public BaseActionModel ActionData3 { get; set; }

        #endregion

        private BaseEventModel GetEventTypeData()
        {
            switch (eventType)
            {
                case EventType.TIMER_IN_COMBAT:       return new TimerEventModel(EventValues);
                case EventType.TIMER_OOC:             return new TimerEventModel(EventValues);
                case EventType.HP:                    return new HpEventModel(EventValues);
                case EventType.MANA:                  return new ManaEventModel(EventValues);
                case EventType.AGGRO:                 return new EmptyEventModel(EventValues);
                case EventType.KILL:                  return new KillEventModel(EventValues);
                case EventType.DEATH:                 return new EmptyEventModel(EventValues);
                case EventType.EVADE:                 return new EmptyEventModel(EventValues);
                case EventType.SPELLHIT:              return new SpellHitEventModel(EventValues);
                case EventType.RANGE:                 return new RangeEventModel(EventValues);
                case EventType.OOC_LOS:               return new OocLosEventModel(EventValues);
                case EventType.SPAWNED:               return new EmptyEventModel(EventValues);
                case EventType.TARGET_HP:             return new HpEventModel(EventValues);
                case EventType.TARGET_CASTING:        return new KillEventModel(EventValues);
                case EventType.FRIENDLY_HP:           return new FrendlyHpEventModel(EventValues);
                case EventType.FRIENDLY_IS_CC:        return new FrendlyIsCcEventModel(EventValues);
                case EventType.FRIENDLY_MISSING_BUFF: return new FrendlyMissingBuffEventModel(EventValues);
                case EventType.SUMMONED_UNIT:         return new SummonEventModel(EventValues);
                case EventType.TARGET_MANA:           return new ManaEventModel(EventValues);
                case EventType.REACHED_HOME:          return new EmptyEventModel(EventValues);
                case EventType.RECEIVE_EMOTE:         return new ReciveEmoteEventModel(EventValues);
                case EventType.AURA:                  return new AuraEventModel(EventValues);
                case EventType.TARGET_BUFFED:         return new AuraEventModel(EventValues);
                case EventType.SUMMONED_JUST_DIED:    return new SummonEventModel(EventValues);
                case EventType.SUMMONED_JUST_DESPAWN: return new SummonEventModel(EventValues);
                case EventType.MISSING_AURA:          return new AuraEventModel(EventValues);
                case EventType.TARGET_MISSING_AURA:   return new AuraEventModel(EventValues);
                case EventType.TIMER_GENERIC:         return new TimerEventModel(EventValues);
                case EventType.RECEIVE_AI_EVENT:      return new ReciveAIEventModel(EventValues);
                default:                              return new BaseEventModel(EventValues);
            }
        }

        private BaseActionModel GetActionTypeData(ActionType actionType, int[] ActionValues)
        {
            switch (actionType)
            {
                case ActionType.NONE:                       return new EmptyActionModel(ActionValues);
                case ActionType.TEXT:                       return new TextActionModel(ActionValues);
                case ActionType.SET_FACTION:                return new SetFactionActionModel(ActionValues);
                case ActionType.MORPH_TO_ENTRY_OR_MODEL:    return new MorphActionModel(ActionValues);
                case ActionType.SOUND:                      return new SoundActionModel(ActionValues);
                case ActionType.EMOTE:                      return new EmoteActionModel(ActionValues);
                case ActionType.RANDOM_SOUND:               return new RandomSoundActionModel(ActionValues);
                case ActionType.RANDOM_EMOTE:               return new RandomEmoteActionModel(ActionValues);
                case ActionType.CAST:                       return new CastActionModel(ActionValues);
                case ActionType.SUMMON_DURATION:            return new SummonActionModel(ActionValues);
                case ActionType.THREAT_SINGLE_PCT:          return new ThreatAllPctActionModel(ActionValues);
                case ActionType.THREAT_ALL_PCT:             return new ThreatAllPctActionModel(ActionValues);
                case ActionType.QUEST_EVENT:                return new QuestEventActionModel(ActionValues);
                case ActionType.QUEST_CASTCREATUREGO:       return new QuestCastCreatureGOActionModel(ActionValues);
                case ActionType.SET_UNIT_FIELD:             return new SetUnitFieldActionModel(ActionValues);
                case ActionType.SET_UNIT_FLAG:              return new UnitFlagActionModel(ActionValues);
                case ActionType.REMOVE_UNIT_FLAG:           return new UnitFlagActionModel(ActionValues);
                case ActionType.AUTO_ATTACK:                return new AutoAtackActionModel(ActionValues);
                case ActionType.COMBAT_MOVEMENT:            return new CombatMovementActionModel(ActionValues);
                case ActionType.SET_PHASE:                  return new SetPhaseActionModel(ActionValues);
                case ActionType.INC_PHASE:                  return new IncPhaseActionModel(ActionValues);
                case ActionType.EVADE:                      return new EmptyActionModel(ActionValues);
                case ActionType.FLEE_FOR_ASSIST:            return new EmptyActionModel(ActionValues);
                case ActionType.QUEST_EVENT_ALL:            return new QuestEventAllActionModel(ActionValues);
                case ActionType.CASTCREATUREGO_ALL:         return new CastCreatureGOAllActionModel(ActionValues);
                case ActionType.REMOVEAURASFROMSPELL:       return new RemoveAurasFromSpellActionModel(ActionValues);
                case ActionType.RANGED_MOVEMENT:            return new RangetMovementActionModel(ActionValues);
                case ActionType.RANDOM_PHASE:               return new RandomPhaseActionModel(ActionValues);
                case ActionType.RANDOM_PHASE_RANGE:         return new RandomPhaseRangeActionModel(ActionValues);
                case ActionType.SUMMON:                     return new SummonIdActionModel(ActionValues);
                case ActionType.KILLED_MONSTER:             return new KilledMonsterActionModel(ActionValues);
                case ActionType.SET_INST_DATA:              return new SetInstDataActionModel(ActionValues);
                case ActionType.SET_INST_DATA64:            return new SetInstData64ActionModel(ActionValues);
                case ActionType.UPDATE_TEMPLATE:            return new UpdateTemplateActionModel(ActionValues);
                case ActionType.DIE:                        return new EmptyActionModel(ActionValues);
                case ActionType.ZONE_COMBAT_PULSE:          return new EmptyActionModel(ActionValues);
                case ActionType.CALL_FOR_HELP:              return new CallForHelpActionModel(ActionValues);
                case ActionType.SET_SHEATH:                 return new SetSheathActionModel(ActionValues);
                case ActionType.FORCE_DESPAWN:              return new ForceDespawnActionModel(ActionValues);
                case ActionType.SET_INVINCIBILITY_HP_LEVEL: return new SetInviciblityHpLevelActionModel(ActionValues);
                case ActionType.MOUNT_TO_ENTRY_OR_MODEL:    return new MorphActionModel(ActionValues);
                case ActionType.CHANCED_TEXT:               return new ChancedTextActionModel(ActionValues);
                case ActionType.THROW_AI_EVENT:             return new ThrowAIActionModel(ActionValues);
                case ActionType.SET_THROW_MASK:             return new SetThrowMaskActionModel(ActionValues);
                case ActionType.SET_STAND_STATE:            return new SetStandStateActionModel(ActionValues);
                default:                                    return new BaseActionModel(ActionValues);
            }
        }
    }
}
