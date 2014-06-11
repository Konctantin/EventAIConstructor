using System;

namespace EventIAConstructor.ViewModel.EventModel
{
    public class BaseEventModel : BaseViewModel
    {
        protected int param1;
        protected int param2;
        protected int param3;
        protected int param4;

        public BaseEventModel(int[] values)
        {
            if (values.Length != 4)
                throw new ArgumentOutOfRangeException();
            this.param1 = values[0];
            this.param2 = values[1];
            this.param3 = values[2];
            this.param4 = values[3];
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

        public int Param4
        {
            get { return param4; }
            set
            {
                if (value != param4)
                {
                    param4 = value;
                    OnPropertyChanged();
                }
            }
        }

        public virtual int[] RawData
        {
            get { return new int[] { param1, param2, param3, param4 }; }
        }
    }
}