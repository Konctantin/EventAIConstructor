using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventIAConstructor.ViewModel.EventModel.ConditionModel
{
    public class BaseConditionModel : BaseViewModel
    {   
        protected int condValue1;
        protected int condValue2;

        public BaseConditionModel(int[] values)
        {
            if (values.Length != 2)
                throw new ArgumentOutOfRangeException();
            this.condValue1 = values[0];
            this.condValue2 = values[1];
        }

        public int CondValue1
        {
            get { return condValue1; }
            set
            {
                if (value != condValue1)
                {
                    condValue1 = value;
                    OnPropertyChanged();
                }
            }
        }

        public int CondValue2
        {
            get { return condValue2; }
            set
            {
                if (value != condValue2)
                {
                    condValue2 = value;
                    OnPropertyChanged();
                }
            }
        }

        public virtual int[] RawData
        {
            get { return new int[] { condValue1, condValue2 }; }
        }
    }
}
