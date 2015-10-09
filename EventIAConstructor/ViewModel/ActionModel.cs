using EventIAConstructor.EventAIMetadata;
using System;

namespace EventIAConstructor.ViewModel
{
    public class ActionModel : BaseViewModel
    {
        ActionType type;
        int param1, param2, param3;

        public ActionModel Self { get; private set; }

        public EventAIModel Parent { get; private set; }

        public ActionModel(EventAIModel parent, ActionType type, params int[] values)
        {
            Parent = parent;

            if (values.Length != 3)
                throw new ArgumentOutOfRangeException(nameof(values), "3 params");

            Param1 = values[0];
            Param2 = values[1];
            Param3 = values[2];

            Type = type;
            Self = this;
        }

        public ActionType Type
        {
            get { return type; }
            set
            {
                if (value != type)
                {
                    type = value;
                    OnPropertyChanged();
                    Self = null;
                    OnPropertyChanged("Self");
                    Self = this;
                    OnPropertyChanged("Self");
                }
            }
        }

        public int Param1
        {
            get { return param1; }
            set
            {
                if (value != param1)
                {
                    param1 = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Param2
        {
            get { return param2; }
            set
            {
                if (value != param2)
                {
                    param2 = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Param3
        {
            get { return param3; }
            set
            {
                if (value != param3)
                {
                    param3 = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}