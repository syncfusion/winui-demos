#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace syncfusion.editordemos.winui
{
    public class CustomCalendarItemTemplateSelector : DataTemplateSelector
    {
        public CustomCalendarItemTemplateSelector()
        {
            SpecialDates = new Dictionary<DateTimeOffset, string>();
            SpecialDates.Add(DateTimeOffset.Now.AddMonths(-1).AddDays(1), "BirthDay");
            SpecialDates.Add(DateTimeOffset.Now.AddMonths(-1).AddDays(5), "Appointment");
            SpecialDates.Add(DateTimeOffset.Now.AddMonths(-1).AddDays(-2), "Graduation");
            SpecialDates.Add(DateTimeOffset.Now.AddDays(1), "Gift");
            SpecialDates.Add(DateTimeOffset.Now.AddDays(9), "BirthDay");
            SpecialDates.Add(DateTimeOffset.Now.AddDays(-4), "Appointment");
            SpecialDates.Add(DateTimeOffset.Now.AddMonths(1).AddDays(1), "Award");
            SpecialDates.Add(DateTimeOffset.Now.AddMonths(1).AddDays(3), "Election");
            SpecialDates.Add(DateTimeOffset.Now.AddMonths(1).AddDays(-5), "GroupMeeting");
        }
        private Dictionary<DateTimeOffset, string> SpecialDates { get; set; }

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
            if (item != null)
            {
                DateTimeOffset calendarItem = (DateTimeOffset)item;
                DateTimeOffset dateTimeOffset = SpecialDates.Keys.FirstOrDefault(x => x.Date == calendarItem.Date);

                if (dateTimeOffset != DateTimeOffset.MinValue)
                {
                    string template = this.SpecialDates[dateTimeOffset];

                    switch (template)
                    {
                        case "BirthDay":
                            return BirthdayTemplate;
                        case "Gift":
                            return GiftTemplate;
                        case "Award":
                            return AwardTemplate;
                        case "Appointment":
                            return AppointmentTemplate;
                        case "Graduation":
                            return GraduationTemplate;
                        case "Election":
                            return ElectionTemplate;
                        case "GroupMeeting":
                            return GroupMeetingTemplate;
                    }
                }

                return DefaultTemplate;
            }

            return base.SelectTemplateCore(item, container);
        }
    }
}
