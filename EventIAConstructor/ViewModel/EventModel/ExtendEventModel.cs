
using EventIAConstructor.EventAIMetadata;
using EventIAConstructor.ViewModel.EventModel.ConditionModel;
namespace EventIAConstructor.ViewModel.EventModel
{
    public class EmptyEventModel : BaseEventModel
    {
        public EmptyEventModel(int[] values) : base(values) { }
    }

    public class TimerEventModel : BaseEventModel
    {
        public TimerEventModel(int[] values) : base(values) { }
    }

    public class HpEventModel : BaseEventModel
    {
        public HpEventModel(int[] values) : base(values) { }
    }

    public class ManaEventModel : BaseEventModel
    {
        public ManaEventModel(int[] values) : base(values) { }
    }

    public class KillEventModel : BaseEventModel
    {
        public KillEventModel(int[] values) : base(values) { }
    }

    public class SpellHitEventModel : BaseEventModel
    {
        public SpellHitEventModel(int[] values) : base(values) { }
    }

    public class RangeEventModel : BaseEventModel
    {
        public RangeEventModel(int[] values) : base(values) { }
    }

    public class OocLosEventModel : BaseEventModel
    {
        public OocLosEventModel(int[] values) : base(values) { }
    }

    public class FrendlyHpEventModel : BaseEventModel
    {
        public FrendlyHpEventModel(int[] values) : base(values) { }
    }

    public class FrendlyIsCcEventModel : BaseEventModel
    {
        public FrendlyIsCcEventModel(int[] values) : base(values) { }
    }

    public class FrendlyMissingBuffEventModel : BaseEventModel
    {
        public FrendlyMissingBuffEventModel(int[] values) : base(values) { }
    }

    public class SummonEventModel : BaseEventModel
    {
        public SummonEventModel(int[] values) : base(values) { }
    }

    public class ReciveEmoteEventModel : BaseEventModel
    {
        public ReciveEmoteEventModel(int[] values) : base(values) { }

        public ConditionType Condition
        {
            get { return (ConditionType)param2; }
            set
            {
                param2 = (int)value;
                this.CondData = GetConditionTypeData();
                OnPropertyChanged();
                OnPropertyChanged("CondData");
            }
        }

        public int[] CondValues
        {
            get { return new int[] { param3, param4 }; }
            set 
            {
                param3 = value[0];
                param4 = value[1];
            }
        }
        

        public BaseConditionModel CondData
        {
            get { return GetConditionTypeData(); }
            set
            {
                if (value == null)
                    CondValues = new int[2];
                else
                    CondValues = new int[] { value.CondValue1, value.CondValue2 };
            }
        }

        private BaseConditionModel GetConditionTypeData()
        {
            switch (Condition)
            {
                case ConditionType.NONE:            return new BaseConditionModel(CondValues);
                case ConditionType.AURA:            return new AuraConditionModel(CondValues);
                case ConditionType.ITEM:            return new ItemConditionModel(CondValues);
                case ConditionType.ITEM_EQUIPPED:   return new ItemConditionModel(CondValues);
                case ConditionType.ZONEID:          return new ZoneConditionModel(CondValues);
                case ConditionType.REPUTATION_RANK: return new ReputationConditionModel(CondValues);
                case ConditionType.TEAM:            return new TeamConditionModel(CondValues);
                case ConditionType.SKILL:           return new SkillConditionModel(CondValues);
                case ConditionType.QUESTREWARDED:   return new QuestRewardedConditionModel(CondValues);
                case ConditionType.QUESTTAKEN:      return new QuestTakenConditionModel(CondValues);
                case ConditionType.ACTIVE_EVENT:    return new ActiveEventConditionModel(CondValues);
                default:                            return new BaseConditionModel(CondValues);
            }
        }
    }

    public class AuraEventModel : BaseEventModel
    {
        public AuraEventModel(int[] values) : base(values) { }
    }

    public class ReciveAIEventModel : BaseEventModel
    {
        public ReciveAIEventModel(int[] values) : base(values) { }
    }
}
