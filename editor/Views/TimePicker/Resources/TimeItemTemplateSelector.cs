#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
    /// <summary>
    /// Selects a <see cref="DataTemplate"/> for displaying time items. This selector can be used in controls like ComboBoxes or ListBoxes to apply different templates
    /// based on the time item's properties or context.
    /// </summary>
    public class TimeItemTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Properties to hold DataTemplate for Default
        /// </summary>
        public DataTemplate DefaultTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Moon
        /// </summary>
        public DataTemplate MoonTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Alarm
        /// </summary>
        public DataTemplate AlarmTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Drinks
        /// </summary>
        public DataTemplate DrinksTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Appointment
        /// </summary>
        public DataTemplate AppointmentTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Sleep
        /// </summary>
        public DataTemplate SleepTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Election
        /// </summary>
        public DataTemplate ElectionTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Group Meeting
        /// </summary>
        public DataTemplate GroupMeetingTemplate { get; set; }
        /// <summary>
        /// Selects the appropriate <see cref="DataTemplate"/> for the given time item.
        /// </summary>
        /// <param name="item">The data item for which to select a template.</param>
        /// <param name="container">The UI element container.</param>
        /// <returns>The selected <see cref="DataTemplate"/> for the item, or null if no specific template is matched.</returns>
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
