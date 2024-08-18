using System.Globalization;
using System.Windows.Data;

namespace ColorViewer
{
    public class SliderValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (parameter is bool isEnabled && isEnabled)
            {
                return value;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
