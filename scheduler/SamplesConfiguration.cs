#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.winui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.schedulerdemos.winui
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {

            DemoInfo gettingstarted = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Getting Started",
                DemoType = DemoTypes.New,
                Description = "This sample showcases the basic capabilities customization of different view modes, context menu to add, edit, and delete appointments, and Minimum date and maximum date to restrict the date navigation.",
                DemoView = typeof(GettingStarted),
            };

            DemoInfo dataBinding = new DemoInfo()
            {
                Name = "Data Binding",
                Category = "Getting Started",
                DemoType = DemoTypes.New,
                Description = "This sample showcases how to map properties of a data object to ScheduleAppointment and bind custom data collection to ItemSource.",
                DemoView = typeof(DataBinding),
            };

            DemoInfo timelineViews = new DemoInfo()
            {
                Name = "Timeline views",
                Category = "Getting Started",
                DemoType = DemoTypes.New,
                Description = "This sample showcases the SfScheduler Timeline day, Timeline week, Timeline work week, and Timeline month views.",
                DemoView = typeof(TimelineViews),
            };

            DemoInfo recursiveAppointment = new DemoInfo()
            {
                Name = "Recurring Appointments",
                Category = "Appointments",
                DemoType = DemoTypes.New,
                Description = "This sample showcases how to create recurring appointments on daily, weekly, monthly, and yearly intervals in SfScheduler.",
                DemoView = typeof(RecurringAppointment),
            };

            DemoInfo recursiveAppointmentWithException = new DemoInfo()
            {
                Name = "Recurring Appointment with Exception",
                Category = "Appointments",
                DemoType = DemoTypes.New,
                Description = "This sample showcases the following capabilities of the SfScheduler.\n \u2022 Generate recurring appointments on daily, weekly, monthly, and yearly intervals. \n \u2022 Avoid the occurrence of recurring appointments on specific dates. \n \u2022 Create and add the changed occurrence of recurring appointments.",
                DemoView = typeof(RecursiveExceptionAppointment),
            };

            DemoInfo loadOnDemandCommand = new DemoInfo()
            {
                Name = "Load on demand",
                Category = "Load On Demand",
                DemoType = DemoTypes.New,
                Description = "This sample showcases the appointment on-demand loading capability of the SfScheduler with custom data binding.",
                DemoView = typeof(LoadOnDemand),
            };

            DemoInfo resource = new DemoInfo()
            {
                Name = "Resource",
                Category = "Resources",
                DemoType = DemoTypes.New,
                Description = "This sample showcases the following capabilities of the SfScheduler.\n \u2022 Display the resources when the scheduler is grouped by either resource or date.\n \u2022 Customize the resource view by using the DataTemplate.",
                DemoView = typeof(Resource),
            };

            DemoInfo appointmentCustomization = new DemoInfo()
            {
                Name = "Appointment",
                Category = "Customization",
                DemoType = DemoTypes.New,
                Description = "This sample showcases the customization capabilities of the scheduler appointment control.",
                DemoView = typeof(AppointmentCustomaization),
            };

			DemoInfo timeslotCustomization = new DemoInfo()
			{
				Name = "Time Slot",
				Category = "Customization",
				DemoType = DemoTypes.New,
				Description = "This sample showcases the following capabilities of the SfScheduler.\n \u2022 Navigate to specific dates in view.\n \u2022 Hide or show time values and header in view.",
				DemoView = typeof(TimeslotCustomization),
            };

            DemoInfo speialTimeRegionCustomization = new DemoInfo()
            {
                Name = "Speical Time Region",
                Category = "Customization",
                DemoType = DemoTypes.New,
                Description = "This sample showcases how to add the SpecialTimeRegion and customize its appearance using the DataTemplate in SfScheduler. The SpecialTimeRegion is used for restricting the user interactions such as selection, highlighting specific regions of time, and editing data in the scheduler.",
                DemoView = typeof(SpecialTimeRegionCustomization),
            };

			DemoInfo fareCalendar = new DemoInfo()
			{
				Name = "Fare calendar",
				Category = "Customization",
				DemoType = DemoTypes.New,
				Description = "This sample showcases the customization capabilities of a scheduler month cell.",
				DemoView = typeof(MonthCellCustomization),
            };

			var demos = new List<DemoInfo>()
            {
                gettingstarted,
                dataBinding,
                timelineViews,
                recursiveAppointment,
                recursiveAppointmentWithException,              
                loadOnDemandCommand,
                resource,
                appointmentCustomization,
                speialTimeRegionCustomization,
                fareCalendar,
                timeslotCustomization,
            };

            var controlInfo = new ControlInfo()
            {
                Control = DemoControl.SfScheduler,
                ControlBadge = ControlBadge.New,
                ControlCategory = ControlCategory.Calendars,
                Description = "The Scheduler control is used to schedule and manage appointments through an intuitive user interface, similar to the Windows calendar",
                Glyph = "\uE710"
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);
        }
    }
}
