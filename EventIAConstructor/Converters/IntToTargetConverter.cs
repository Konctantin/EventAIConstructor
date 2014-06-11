using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using EventIAConstructor.EventAIMetadata;

namespace EventIAConstructor.Converters
{
    public class IntToTargetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int)
                return (TargetType)value;
            else
                throw new Exception("Incorrect type " + value.GetType());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is TargetType)
                return (int)value;
            else
                throw new Exception("Incorrect type " + value.GetType());
        }
    }
}
