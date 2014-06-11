namespace EventIAConstructor.ViewModel.ActionModel
{
    public class BaseActionModel : BaseViewModel
    {
        protected int param1;
        protected int param2;
        protected int param3;

        public BaseActionModel(int[] values)
        {
            this.param1 = values[0];
            this.param2 = values[1];
            this.param3 = values[2];
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

        public virtual int[] RawData
        {
            get { return new int[] { param1, param2, param3 }; }
        }
    }
}