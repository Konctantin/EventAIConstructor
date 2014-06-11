using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EventIAConstructor.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}