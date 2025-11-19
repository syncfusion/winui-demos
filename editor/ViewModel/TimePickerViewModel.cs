#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
    /// <summary>
    /// ViewModel for demonstrating the TimePicker control. Manages properties related to time selection, including visible item count, minimum/maximum time, display format,
    /// calendar type options, and language settings.
    /// </summary>
    public class TimePickerViewModel : NotificationObject
    {
        private int visibleItemsCount = 7;
        private DateTimeOffset minTime = new DateTimeOffset(DateTimeOffset.Now.Year, DateTimeOffset.Now.Month, DateTimeOffset.Now.Day, 9, 0, 0, DateTimeOffset.Now.Offset);
        private DateTimeOffset maxTime = new DateTimeOffset(DateTimeOffset.Now.Year, DateTimeOffset.Now.Month, DateTimeOffset.Now.Day, 18, 30, 59, DateTimeOffset.Now.Offset);
        private string formatString = "h:mm:ss tt";

        /// <summary>
        /// Initializes a new instance of the <see cref="TimePickerViewModel"/> class. Sets up options for clock format (12-hour/24-hour) and loads the list of available languages.
        /// </summary>
        public TimePickerViewModel()
        {
            Items = new ObservableCollection<string>();
            Items.Add("12HourClock");
            Items.Add("24HourClock");

            var lang = new LanguageList();
            Languages = lang.Languages;
        }

        /// <summary>
        /// Gets or sets the number of items visible in the time picker's dropdown or list at once.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the minimum selectable time in the time picker.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the primary format string used for displaying the selected time.
        /// </summary>
        public string FormatString
        {
            get { return formatString; }
            set { formatString = value; RaisePropertyChanged("FormatString"); }
        }

        /// <summary>
        /// Gets or sets the maximum selectable time in the time picker.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the collection of strings representing different clock formats (e.g., 12-hour, 24-hour).
        /// </summary>
        public ObservableCollection<string> Items { get; set; }

        /// <summary>
        /// Gets or sets the list of available languages for localization features.
        /// </summary>
        public List<LanguageList.Language> Languages { get; set; }
    }
}
