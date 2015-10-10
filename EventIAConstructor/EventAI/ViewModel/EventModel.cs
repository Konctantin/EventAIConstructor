using EventIAConstructor.Common;
using EventIAConstructor.EventAI.Metadata;
using System;

namespace EventIAConstructor.EventAI.ViewModel
{
    public class EventModel : BaseViewModel
    {
        int type, param1, param2, param3, param4;

        public EventModel Self { get; private set; }

        public EventAIModel Parent { get; private set; }

        public EventModel(EventAIModel parent, int type, params int[] values)
        {
            Parent = parent;

            if (values.Length != 4)
                throw new ArgumentOutOfRangeException(nameof(values), "4 params");
            param1 = values[0];
            param2 = values[1];
            param3 = values[2];
            param4 = values[3];

            Type = type;
            Self = this;
        }

        public int Type
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
                    OnPropertyChanged("Self");
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
                    Self = null;
                    OnPropertyChanged("Self");
                    Self = this;
                    OnPropertyChanged("Self");
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
                    OnPropertyChanged("Self");
                }
            }
        }

        public int Param4
        {
            get { return param4; }
            set
            {
                if (value != param4)
                {
                    param4 = value;
                    OnPropertyChanged();
                    OnPropertyChanged("Self");
                }
            }
        }
    }
}