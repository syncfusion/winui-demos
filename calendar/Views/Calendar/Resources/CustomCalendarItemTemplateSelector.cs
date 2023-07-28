#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Syncfusion.CalendarDemos.WinUI
{
    public class CustomCalendarItemTemplateSelector : DataTemplateSelector
    {
        public CustomCalendarItemTemplateSelector()
        {
            SpecialDates = new Dictionary<DateTimeOffset, string>();
            SpecialDates.Add(DateTimeOffset.Now.AddMonths(-1).AddDays(1), "SingleEvent_1");
            SpecialDates.Add(DateTimeOffset.Now.AddMonths(-1).AddDays(5), "DoubleEvent_1");
            SpecialDates.Add(DateTimeOffset.Now.AddMonths(-1).AddDays(-2), "TripleEvent_2");
            SpecialDates.Add(DateTimeOffset.Now.AddDays(1), "TripleEvent_1");
            SpecialDates.Add(DateTimeOffset.Now.AddDays(5), "SingleEvent_2");
            SpecialDates.Add(DateTimeOffset.Now.AddDays(7), "DoubleEvent_2");
            SpecialDates.Add(DateTimeOffset.Now.AddDays(9), "SingleEvent_1");
            SpecialDates.Add(DateTimeOffset.Now.AddDays(12), "TripleEvent_2");
            SpecialDates.Add(DateTimeOffset.Now.AddDays(-4), "DoubleEvent_1");
            SpecialDates.Add(DateTimeOffset.Now.AddMonths(1).AddDays(1), "DoubleEvent_3");
            SpecialDates.Add(DateTimeOffset.Now.AddMonths(1).AddDays(3), "SingleEvent_2");
            SpecialDates.Add(DateTimeOffset.Now.AddMonths(1).AddDays(-5), "DoubleEvent_2");
        }
        private Dictionary<DateTimeOffset, string> SpecialDates { get; set; }

        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate SingleEventTemplate_1 { get; set; }
        public DataTemplate SingleEventTemplate_2 { get; set; }
        public DataTemplate DoubleEventTemplate_1 { get; set; }
        public DataTemplate DoubleEventTemplate_2 { get; set; }
        public DataTemplate DoubleEventTemplate_3 { get; set; }
        public DataTemplate TripleEventTemplate_1 { get; set; }
        public DataTemplate TripleEventTemplate_2 { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item != null)
            {
                var calendarItemInfo = (container as ContentControl).DataContext as CalendarItemInfo;
                if (calendarItemInfo != null && calendarItemInfo.ItemType != CalendarItemType.Day)
                {
                    return DefaultTemplate;
                }

                DateTimeOffset calendarItem = (DateTimeOffset)item;
                DateTimeOffset dateTimeOffset = SpecialDates.Keys.FirstOrDefault(x => x.Date == calendarItem.Date);

                if (dateTimeOffset != DateTimeOffset.MinValue)
                {
                    string template = this.SpecialDates[dateTimeOffset];

                    switch (template)
                    {
                        case "SingleEvent_1":
                            return SingleEventTemplate_1;
                        case "SingleEvent_2":
                            return SingleEventTemplate_2;
                        case "DoubleEvent_1":
                            return DoubleEventTemplate_1;
                        case "DoubleEvent_2":
                            return DoubleEventTemplate_2;
                        case "DoubleEvent_3":
                            return DoubleEventTemplate_3;
                        case "TripleEvent_1":
                            return TripleEventTemplate_1;
                        case "TripleEvent_2":
                            return TripleEventTemplate_2;
                    }
                }

                return DefaultTemplate;
            }

            return base.SelectTemplateCore(item, container);
        }
    }
}
