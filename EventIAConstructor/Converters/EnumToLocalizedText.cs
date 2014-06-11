using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EventIAConstructor.Converters
{
    public class EnumToLocalizedText : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Binding.DoNothing;
            if (!(value is Enum))
                return Binding.DoNothing;

            var name = string.Format("{0}_{1}", value.GetType().Name, value);

            if (parameter is string && !string.IsNullOrWhiteSpace((string)parameter))
                name += "_" + parameter;

            return Localization.ResourceManager.GetString(name, CultureInfo.CurrentUICulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
