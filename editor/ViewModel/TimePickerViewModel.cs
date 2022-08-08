#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Syncfusion.EditorDemos.WinUI
{
    public class TimePickerViewModel : NotificationObject
    {
        private int visibleItemsCount = 7;
        private DateTimeOffset minTime = new DateTimeOffset(DateTimeOffset.Now.Year, DateTimeOffset.Now.Month, DateTimeOffset.Now.Day, 9, 0, 0, DateTimeOffset.Now.Offset);
        private DateTimeOffset maxTime = new DateTimeOffset(DateTimeOffset.Now.Year, DateTimeOffset.Now.Month, DateTimeOffset.Now.Day, 18, 30, 59, DateTimeOffset.Now.Offset);
        private string formatString = "h:mm:ss tt";

        public TimePickerViewModel()
        {
            Items = new ObservableCollection<string>();
            Items.Add("12HourClock");
            Items.Add("24HourClock");

            var lang = new LanguageList();
            Languages = lang.Languages;
        }

        public int VisibleItemsCount
        {
            get
            {
                return visibleItemsCount;
            }
            set
            {
                if (visibleItemsCount != value)
                {
                    visibleItemsCount = value;
                    this.RaisePropertyChanged(nameof(this.VisibleItemsCount));
                }
            }
        }

        public DateTimeOffset MinTime
        {
            get
            {
                return minTime;
            }
            set
            {
                if (minTime != value)
                {
                    minTime = value;
                    this.RaisePropertyChanged(nameof(this.MinTime));
                }
            }
        }

        public string FormatString
        {
            get { return formatString; }
            set { formatString = value; RaisePropertyChanged("FormatString"); }
        }

        public DateTimeOffset MaxTime
        {
            get
            {
                return maxTime;
            }
            set
            {
                if (maxTime != value)
                {
                    maxTime = value;
                    this.RaisePropertyChanged(nameof(this.MaxTime));
                }
            }
        }

        public ObservableCollection<string> Items { get; set; }

        public List<LanguageList.Language> Languages { get; set; }
    }
}
