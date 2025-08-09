using Microsoft.Maui.Controls;
using System.Globalization;

namespace MoodProyect.Converters;

public class BoolInverseConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is bool b ? !b : value;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => value is bool b ? !b : value;
}
