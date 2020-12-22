#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Editors;

namespace syncfusion.editordemos.winui
{
    public class DateItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate BirthdayTemplate { get; set; }
        public DataTemplate GiftTemplate { get; set; }
        public DataTemplate AwardTemplate { get; set; }
        public DataTemplate AppointmentTemplate { get; set; }
        public DataTemplate GraduationTemplate { get; set; }
        public DataTemplate ElectionTemplate { get; set; }
        public DataTemplate GroupMeetingTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            DateTimeFieldItemInfo dateTimeField = item as DateTimeFieldItemInfo;
            if (dateTimeField.Field == DateTimeField.Day)
            {
                switch (dateTimeField.DateTime.Value.Day)
                {
                    case 2:
                        return BirthdayTemplate as DataTemplate;
                    case 7:
                        return GiftTemplate as DataTemplate;
                    case 12:
                        return AwardTemplate as DataTemplate;
                    case 17:
                        return AppointmentTemplate as DataTemplate;
                    case 20:
                        return GraduationTemplate as DataTemplate;
                    case 26:
                        return ElectionTemplate as DataTemplate;
                }
            }

            return base.SelectTemplateCore(item, container);
        }
    }
}
