using System; 
using Windows.UI.Xaml.Data;

namespace Balance.Converters
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object format, string language)
        {
            var d = value as DateTime?;
            if (!d.HasValue)
                return value;

            return d.Value.ToString(format.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}