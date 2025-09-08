#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DemosCommon.WinUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.SchedulerDemos.WinUI
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {

            DemoInfo gettingstarted = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Getting Started",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the scheduler views such as day, week, workweek and month views with scheduler appointments added. It also showcases the date navigation restriction within minimum and maximum scheduler date range and context menu to add, edit, and delete appointments.",
                DemoView = typeof(GettingStarted),
                ShowInfoPanel = true
            };

            List<Documentation> gettingstartedDocumentations = new List<Documentation>();
            gettingstartedDocumentations.Add(new Documentation() { Content = "Scheduler - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Scheduler.html") });
            gettingstartedDocumentations.Add(new Documentation() { Content = "Scheduler - Getting Started Documentation", Uri = new Uri("https://help.syncfusion.com/winui/scheduler/getting-started") });

            gettingstarted.Documentation.AddRange(gettingstartedDocumentations);

            DemoInfo dataBinding = new DemoInfo()
            {
                Name = "Data Binding",
                Category = "Getting Started",
                DemoType = DemoTypes.None,
                Description = "This sample showcases to binding any business event object to the scheduler items source using the property mapping concept.",
                DemoView = typeof(DataBinding),
                ShowInfoPanel = true
            };

            List<Documentation> dataBindingDocumentations = new List<Documentation>();
            dataBindingDocumentations.Add(new Documentation() { Content = "Scheduler - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Scheduler.html") });
            dataBindingDocumentations.Add(new Documentation() { Content = "Scheduler - Data Binding Documentation", Uri = new Uri("https://help.syncfusion.com/winui/scheduler/appointments#creating-business-objects") });

            dataBinding.Documentation.AddRange(dataBindingDocumentations);

            DemoInfo timelineViews = new DemoInfo()
            {
                Name = "Timeline views",
                Category = "Getting Started",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the scheduler timeline day , timeline week , timeline workweek and timeline month views. It also showcases the capabilities of creating recurring appointments on daily, weekly, monthly, and yearly intervals in timeline day, timeline week, timeline workweek and timeline month views, creating the recurrence appointment with exception date and changed occurrence of recurring series appointments and the capabilities of highlighting specific regions in timeslot cells and restricting user interactions such as selection, appointment creations.",
                DemoView = typeof(TimelineViews),
                ShowInfoPanel = true
            };

            List<Documentation> timelineViewsDocumentations = new List<Documentation>();
            timelineViewsDocumentations.Add(new Documentation() { Content = "Scheduler - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Scheduler.html") });
            timelineViewsDocumentations.Add(new Documentation() { Content = "Scheduler - Timeline Views Documentation", Uri = new Uri("https://help.syncfusion.com/winui/scheduler/timeline-views") });

            timelineViews.Documentation.AddRange(timelineViewsDocumentations);

            DemoInfo recursiveAppointment = new DemoInfo()
            {
                Name = "Recurring Appointments",
                Category = "Appointments",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the capabilities of creating recurring appointments on daily, weekly, monthly, and yearly intervals in day, week, workweek and month views.",
                DemoView = typeof(RecurringAppointment),
                ShowInfoPanel = true
            };

            List<Documentation> recursiveAppointmentDocumentations = new List<Documentation>();
            recursiveAppointmentDocumentations.Add(new Documentation() { Content = "Scheduler - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Scheduler.html") });
            recursiveAppointmentDocumentations.Add(new Documentation() { Content = "Scheduler - Recurring Appointments Documentation", Uri = new Uri("https://help.syncfusion.com/winui/scheduler/appointments#recurrence-appointment") });

            recursiveAppointment.Documentation.AddRange(recursiveAppointmentDocumentations);

            DemoInfo recursiveAppointmentWithException = new DemoInfo()
            {
                Name = "Recurrence Exception",
                Category = "Appointments",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the capabilities of creating the recurrence appointment with exception date and changed occurrence of recurring series appointments.",
                DemoView = typeof(RecursiveExceptionAppointment),
                ShowInfoPanel = true
            };

            List<Documentation> recursiveAppointmentExceptionDocumentations = new List<Documentation>();
            recursiveAppointmentExceptionDocumentations.Add(new Documentation() { Content = "Scheduler - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Scheduler.html") });
            recursiveAppointmentExceptionDocumentations.Add(new Documentation() { Content = "Scheduler - Recurring Appointment with Exception Documentation", Uri = new Uri("https://help.syncfusion.com/winui/scheduler/appointments#creating-the-recurrence-exceptions-for-schedule-appointment") });

            recursiveAppointmentWithException.Documentation.AddRange(recursiveAppointmentExceptionDocumentations);

            DemoInfo loadOnDemandCommand = new DemoInfo()
            {
                Name = "Load on demand",
                Category = "Load On Demand",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the appointment on demand loading capability of the scheduler with business event object binding.",
                DemoView = typeof(LoadOnDemand),
                ShowInfoPanel = true
            };

            List<Documentation> loadOnDemandDocumentations = new List<Documentation>();
            loadOnDemandDocumentations.Add(new Documentation() { Content = "Scheduler - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Scheduler.html") });
            loadOnDemandDocumentations.Add(new Documentation() { Content = "Scheduler - Load On Demand Documentation", Uri = new Uri("https://help.syncfusion.com/winui/scheduler/load-on-demand") });

            loadOnDemandCommand.Documentation.AddRange(loadOnDemandDocumentations);

            DemoInfo horizondatalGrouping = new DemoInfo()
            {
                Name = "Horizontal Grouping",
                Category = "Resources",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the capabilities to display or group appointments based on the resources in day, week and workweek views.",
                DemoView = typeof(HorizontalResourceGrouping),
                ShowInfoPanel = true
            };

            List<Documentation> resourceDocumentations = new List<Documentation>();
            resourceDocumentations.Add(new Documentation() { Content = "Scheduler - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Scheduler.html") });
            resourceDocumentations.Add(new Documentation() { Content = "Scheduler - Resource Grouping Documentation", Uri = new Uri("https://help.syncfusion.com/winui/scheduler/resource-grouping") });
            horizondatalGrouping.Documentation.AddRange(resourceDocumentations);

            DemoInfo dateWiseGrouping = new DemoInfo()
            {
                Name = "Date-wise Grouping",
                Category = "Resources",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the capabilities to display or group appointments based on the dates in day, week and workweek views.",
                DemoView = typeof(DateWiseResourceGrouping),
                ShowInfoPanel = true
            };

            dateWiseGrouping.Documentation.AddRange(resourceDocumentations);

            DemoInfo timelineGrouping = new DemoInfo()
            {
                Name = "Timeline Grouping",
                Category = "Resources",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the capabilities to display or group appointments based on the resources in timeline day, timeline week, timeline workweek and timeline month views.",
                DemoView = typeof(TimelineResourceGrouping),
                ShowInfoPanel = true,
            };

            timelineGrouping.Documentation.AddRange(resourceDocumentations);

            DemoInfo appointmentCustomization = new DemoInfo()
            {
                Name = "Appointment",
                Category = "Customization",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the customization capabilities of the scheduler appointment control.",
                DemoView = typeof(AppointmentCustomaization),
                ShowInfoPanel = true
            };

            List<Documentation> appointmentCustomizationDocumentations = new List<Documentation>();
            appointmentCustomizationDocumentations.Add(new Documentation() { Content = "Scheduler - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Scheduler.html") });
            appointmentCustomizationDocumentations.Add(new Documentation() { Content = "Scheduler - Appointment Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/scheduler/appointments#appearance-customization") });

            appointmentCustomization.Documentation.AddRange(appointmentCustomizationDocumentations);

            DemoInfo timeslotCustomization = new DemoInfo()
			{
				Name = "Time Slot",
				Category = "Customization",
				DemoType = DemoTypes.None,
				Description = "This sample showcases the capabilities to navigate to specific dates in scheduler views, show or hide time ruler label and header view in the scheduler.",
				DemoView = typeof(TimeslotCustomization),
                ShowInfoPanel = true
            };

            List<Documentation> timeslotCustomizationDocumentations = new List<Documentation>();
            timeslotCustomizationDocumentations.Add(new Documentation() { Content = "Scheduler - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Scheduler.html") });
            timeslotCustomizationDocumentations.Add(new Documentation() { Content = "Scheduler - Time Slot Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/scheduler/day-week-views") });

            timeslotCustomization.Documentation.AddRange(timeslotCustomizationDocumentations);

            DemoInfo specialTimeRegionCustomization = new DemoInfo()
            {
                Name = "Special Time Region",
                Category = "Customization",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the capabilities of highlighting specific regions in timeslot cells and restricting user interactions such as selection, appointment creation and customize the appearance of highlighted timeslot cells.",
                DemoView = typeof(SpecialTimeRegionCustomization),
                ShowInfoPanel = true
            };

            List<Documentation> specialTimeRegionCustomizationDocumentations = new List<Documentation>();
            specialTimeRegionCustomizationDocumentations.Add(new Documentation() { Content = "Scheduler - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Scheduler.html") });
            specialTimeRegionCustomizationDocumentations.Add(new Documentation() { Content = "Scheduler - Special Time Region Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/scheduler/day-week-views#special-time-region-customization") });

            specialTimeRegionCustomization.Documentation.AddRange(specialTimeRegionCustomizationDocumentations);

            DemoInfo fareCalendar = new DemoInfo()
			{
				Name = "Fare calendar",
				Category = "Customization",
				DemoType = DemoTypes.None,
				Description = "This sample showcases the customization capabilities of a scheduler month cell.",
				DemoView = typeof(MonthCellCustomization),
                ShowInfoPanel = true
            };

            List<Documentation> fareCalendarDocumentations = new List<Documentation>();
            fareCalendarDocumentations.Add(new Documentation() { Content = "Scheduler - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Scheduler.html") });
            fareCalendarDocumentations.Add(new Documentation() { Content = "Scheduler - MonthCell Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/scheduler/month-view#customize-month-cell-appearance") });

            fareCalendar.Documentation.AddRange(fareCalendarDocumentations);

            DemoInfo calendarType = new DemoInfo()
            {
                Name = "Calendar Identifier",
                Category = "Calendar Types",
                DemoType = DemoTypes.None,
                Description = "This example shows how to use the scheduler to set several calendar types such as Gregorian, Korean, Hebrew, and so on.",
                DemoView = typeof(CalendarIdentifierDemo),
                ShowInfoPanel = false,
            };

            DemoInfo dragAndDrop = new DemoInfo()
            {
                Name = "Drag and Drop",
                Category = "Interactive Features",
                DemoType = DemoTypes.None,
                Description = "The scheduler allows drag and drop the appointments in all views and this sample showcases the drag and drop behavior between ListView and Scheduler.",
                DemoView = typeof(DragAndDrop),
                ShowInfoPanel = false,
            };

            DemoInfo smartScheduler = new DemoInfo()
            {
                Name = "Smart Scheduler",
                Category = "Smart Scheduler",
                DemoType = DemoTypes.AISamples | DemoTypes.None,
                Description = "This sample showcases a smart scheduler that lets users check doctor availability and book appointments.",
                DemoView = typeof(SmartScheduler),
                ShowInfoPanel = false,
            };

            var demos = new List<DemoInfo>()
            {
                gettingstarted,
                dataBinding,
                timelineViews,
                recursiveAppointment,
                recursiveAppointmentWithException,
                calendarType,
                loadOnDemandCommand,
                horizondatalGrouping,
                dateWiseGrouping,
                timelineGrouping,
                appointmentCustomization,
                specialTimeRegionCustomization,
                fareCalendar,
                timeslotCustomization,
                smartScheduler,
            };

            var controlInfo = new ControlInfo()
            {
                Control = DemoControl.SfScheduler,
                ControlBadge = ControlBadge.None,
                ControlCategory = ControlCategory.Calendars,
                Description = "The Scheduler control is used to schedule and manage appointments through an intuitive user interface, similar to the Windows calendar",
                Glyph = "\uE71a",
                ImageSource = "Scheduler.png"
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);
        }
    }
}
