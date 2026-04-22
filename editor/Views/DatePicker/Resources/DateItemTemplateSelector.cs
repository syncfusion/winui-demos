#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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
    /// Selects a specific <see cref="DataTemplate"/> for display based on the date and field type within a date picker/calendar.
    /// This allows for custom visual representation of specific dates (e.g., holidays, special days).
    /// </summary>
    public class DateItemTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Properties to hold DataTemplate for New Year
        /// </summary>
        public DataTemplate NewYearTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Army Day
        /// </summary>
        public DataTemplate ArmyDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Cancer Day
        /// </summary>
        public DataTemplate CancerDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Valentine Day
        /// </summary>
        public DataTemplate ValentineDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Womens Day
        /// </summary>
        public DataTemplate WomensDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Forestry Day
        /// </summary>
        public DataTemplate ForestryDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Water Day
        /// </summary>
        public DataTemplate WaterDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Earth Day
        /// </summary>
        public DataTemplate EarthDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Workers Day
        /// </summary>
        public DataTemplate WorkersDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Tobacco Day
        /// </summary>
        public DataTemplate TobaccoDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Blood Donar Day
        /// </summary>
        public DataTemplate BloodDonarDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Yoga Day
        /// </summary>
        public DataTemplate YogaDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Doctors Day
        /// </summary>
        public DataTemplate DoctorsDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Photography Day
        /// </summary>
        public DataTemplate PhotographyDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Sports Day
        /// </summary>
        public DataTemplate SportsDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Engineers Day
        /// </summary>
        public DataTemplate EngineersDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Tourism Day
        /// </summary>
        public DataTemplate TourismDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Post Office Day
        /// </summary>
        public DataTemplate PostOfficeDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for World Food Day
        /// </summary>
        public DataTemplate WorldFoodDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Tsunami Day
        /// </summary>
        public DataTemplate TsunamiDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Childrens Day
        /// </summary>
        public DataTemplate ChildrensDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for AIDS Day
        /// </summary>
        public DataTemplate AIDSDayTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Christmas Day
        /// </summary>
        public DataTemplate ChristmasDayTemplate { get; set; }

        /// <summary>
        /// Selects the appropriate <see cref="DataTemplate"/> for a given date item. It checks if the item represents a specific day and returns the corresponding template.
        /// If no specific date matches, it falls back to the base template selection.
        /// </summary>
        /// <param name="item">The data item to select a template for. Expected to be of type <see cref="DateTimeFieldItemInfo"/>.</param>
        /// <param name="container">The UI element container.</param>
        /// <returns>The selected <see cref="DataTemplate"/> for the item, or the base template if no specific match is found.</returns>
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            DateTimeFieldItemInfo dateTimeField = item as DateTimeFieldItemInfo;
            if (dateTimeField.Field == DateTimeField.Day && dateTimeField.DateTime != null)
            {
                var dateTime = dateTimeField.DateTime.Value.Date;
                if (dateTime.Month == 1 && dateTime.Day == 1)
                {
                    return NewYearTemplate;
                }
                else if (dateTime.Month == 1 && dateTime.Day == 15)
                {
                    return ArmyDayTemplate;
                }
                else if (dateTime.Month == 2 && dateTime.Day == 4)
                {
                    return CancerDayTemplate;
                }
                else if (dateTime.Month == 2 && dateTime.Day == 14)
                {
                    return ValentineDayTemplate;
                }
                else if (dateTime.Month == 3 && dateTime.Day == 8)
                {
                    return WomensDayTemplate;
                }
                else if (dateTime.Month == 3 && dateTime.Day == 21)
                {
                    return ForestryDayTemplate;
                }
                else if (dateTime.Month == 3 && dateTime.Day == 24)
                {
                    return WaterDayTemplate;
                }
                else if (dateTime.Month == 4 && dateTime.Day == 22)
                {
                    return EarthDayTemplate;
                }
                else if (dateTime.Month == 5 && dateTime.Day == 1)
                {
                    return WorkersDayTemplate;
                }
                else if (dateTime.Month == 5 && dateTime.Day == 31)
                {
                    return TobaccoDayTemplate;
                }
                else if (dateTime.Month == 6 && dateTime.Day == 14)
                {
                    return BloodDonarDayTemplate;
                }
                else if (dateTime.Month == 6 && dateTime.Day == 21)
                {
                    return YogaDayTemplate;
                }
                else if (dateTime.Month == 7 && dateTime.Day == 1)
                {
                    return DoctorsDayTemplate;
                }
                else if (dateTime.Month == 8 && dateTime.Day == 19)
                {
                    return PhotographyDayTemplate;
                }
                else if (dateTime.Month == 8 && dateTime.Day == 29)
                {
                    return SportsDayTemplate;
                }
                else if (dateTime.Month == 9 && dateTime.Day == 15)
                {
                    return EngineersDayTemplate;
                }
                else if (dateTime.Month == 9 && dateTime.Day == 27)
                {
                    return TourismDayTemplate;
                }
                else if (dateTime.Month == 10 && dateTime.Day == 9)
                {
                    return PostOfficeDayTemplate;
                }
                else if (dateTime.Month == 10 && dateTime.Day == 16)
                {
                    return WorldFoodDayTemplate;
                }
                else if (dateTime.Month == 11 && dateTime.Day == 5)
                {
                    return TsunamiDayTemplate;
                }
                else if (dateTime.Month == 11 && dateTime.Day == 14)
                {
                    return ChildrensDayTemplate;
                }
                else if (dateTime.Month == 12 && dateTime.Day == 1)
                {
                    return AIDSDayTemplate;
                }
                else if (dateTime.Month == 12 && dateTime.Day == 25)
                {
                    return ChristmasDayTemplate;
                }
            }

            return base.SelectTemplateCore(item, container);
        }
    }
}