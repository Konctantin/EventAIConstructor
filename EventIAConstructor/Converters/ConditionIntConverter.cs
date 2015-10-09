using EventIAConstructor.EventAIMetadata;
using System;
using System.Windows.Data;

namespace EventIAConstructor.Converters
{
    public class ConditionIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int)
                return (ConditionType)(int)value;
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is ConditionType)
                return (int)(ConditionType)value;
            return Binding.DoNothing;
        }
    }
}
