using PersonalExpenses.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace PersonalExpenses.ViewModel.ValueConverters
{
    public class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            var difference = DateTime.Now - date;
            if (difference.TotalMinutes < 60)
                return AppResources.since + " " + difference.TotalMinutes + " " + AppResources.minutes;
            if (difference.TotalHours < 24)
                return AppResources.since + " " + difference.TotalHours + " " + AppResources.hours;
            if (difference.TotalHours < 48)
                return AppResources.yesterday;
            if (difference.TotalDays < 7)
                return AppResources.since + " " + difference.TotalDays + " " + AppResources.days;
            return date;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTime.Now;
        }
    }
}
