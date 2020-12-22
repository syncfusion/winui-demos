#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace syncfusion.editordemos.winui
{
    public class CalendarDatePickerViewModel : NotificationObject
    {
        private DateTimeOffset minDate = new DateTimeOffset(new DateTime(2015, 1, 1));
        private DateTimeOffset maxDate = new DateTimeOffset(new DateTime(2025, 1, 1));

        public CalendarDatePickerViewModel()
        {
            Items = new ObservableCollection<string>();
            Items.Add("JulianCalendar");
            Items.Add("GregorianCalendar");
            Items.Add("HebrewCalendar");
            Items.Add("HijriCalendar");
            Items.Add("JapaneseCalendar");
            Items.Add("KoreanCalendar");
            Items.Add("TaiwanCalendar");
            Items.Add("UmAlQuraCalendar");
            Items.Add("PersianCalendar");


            var lang = new LanguageList();
            Languages = lang.Languages;
        }

        public DateTimeOffset MinDate
        {
            get
            {
                return minDate;
            }
            set
            {
                if (minDate != value)
                {
                    minDate = value;
                    this.RaisePropertyChanged(nameof(this.MinDate));
                }
            }
        }

        public DateTimeOffset MaxDate
        {
            get
            {
                return maxDate;
            }
            set
            {
                if (maxDate != value)
                {
                    maxDate = value;
                    this.RaisePropertyChanged(nameof(this.MaxDate));
                }
            }
        }

        public ObservableCollection<string> Items { get; set; }

        public List<LanguageList.Language> Languages { get; set; }
    }
}
