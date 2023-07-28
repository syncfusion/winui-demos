#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Editors;

namespace Syncfusion.EditorDemos.WinUI
{
    public class TimeItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate MoonTemplate { get; set; }
        public DataTemplate AlarmTemplate { get; set; }
        public DataTemplate DrinksTemplate { get; set; }
        public DataTemplate AppointmentTemplate { get; set; }
        public DataTemplate SleepTemplate { get; set; }
        public DataTemplate ElectionTemplate { get; set; }
        public DataTemplate GroupMeetingTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            DateTimeFieldItemInfo dateTimeField = item as DateTimeFieldItemInfo;
            if (dateTimeField.Field == DateTimeField.Hour12)
            {
                switch (dateTimeField.DateTime.Value.Hour)
                {
                    case 2:
                        return MoonTemplate as DataTemplate;
                    case 5:
                        return AlarmTemplate as DataTemplate;
                    case 10:
                        return AppointmentTemplate as DataTemplate;
                    case 14:
                        return GroupMeetingTemplate as DataTemplate;
                    case 17:
                        return DrinksTemplate as DataTemplate;
                    case 22:
                        return SleepTemplate as DataTemplate;
                }
            }

            return base.SelectTemplateCore(item, container);
        }
    }
}
