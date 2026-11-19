using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.SchedulerDemos.WinUI
{
    public class DisplayDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return DateTime.Now.Date.AddHours(9);
            return (value as DateTimeOffset?).Value.Date.AddHours(9);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
	}

    public class MonthAppointmentTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return "No events";
            return (value as Event).From.ToShortTimeString() + " " + (value as Event).EventName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
