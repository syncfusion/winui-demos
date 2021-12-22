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

namespace syncfusion.editordemos.winui
{
    public class DateItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NewYearTemplate { get; set; }

        public DataTemplate ArmyDayTemplate { get; set; }

        public DataTemplate CancerDayTemplate { get; set; }

        public DataTemplate ValentineDayTemplate { get; set; }

        public DataTemplate WomensDayTemplate { get; set; }

        public DataTemplate ForestryDayTemplate { get; set; }

        public DataTemplate WaterDayTemplate { get; set; }

        public DataTemplate EarthDayTemplate { get; set; }

        public DataTemplate WorkersDayTemplate { get; set; }

        public DataTemplate TobaccoDayTemplate { get; set; }

        public DataTemplate BloodDonarDayTemplate { get; set; }

        public DataTemplate YogaDayTemplate { get; set; }

        public DataTemplate DoctorsDayTemplate { get; set; }

        public DataTemplate PhotographyDayTemplate { get; set; }

        public DataTemplate SportsDayTemplate { get; set; }

        public DataTemplate EngineersDayTemplate { get; set; }

        public DataTemplate TourismDayTemplate { get; set; }

        public DataTemplate PostOfficeDayTemplate { get; set; }

        public DataTemplate WorldFoodDayTemplate { get; set; }

        public DataTemplate TsunamiDayTemplate { get; set; }

        public DataTemplate ChildrensDayTemplate { get; set; }

        public DataTemplate AIDSDayTemplate { get; set; }

        public DataTemplate ChristmasDayTemplate { get; set; }

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