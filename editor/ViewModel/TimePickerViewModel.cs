#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Core;
using System;

namespace syncfusion.editordemos.winui
{
    public class TimePickerViewModel : NotificationObject
    {
        private int visibleItemsCount = 7;
        private DateTimeOffset minTime = new DateTimeOffset(DateTimeOffset.Now.Year, DateTimeOffset.Now.Month, DateTimeOffset.Now.Day, 9, 0, 0, DateTimeOffset.Now.Offset);
        private DateTimeOffset maxTime = new DateTimeOffset(DateTimeOffset.Now.Year, DateTimeOffset.Now.Month, DateTimeOffset.Now.Day, 18, 30, 0, DateTimeOffset.Now.Offset);

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
    }
}
