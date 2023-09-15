#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.SchedulerDemos.WinUI
{
	public class AppointmentTemplateSelector : DataTemplateSelector
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MonthCellTemplateSelector" /> class.
		/// </summary>
		public AppointmentTemplateSelector()
		{

		}

		/// <summary>
		/// Gets or sets cancer awareness appointment template.
		/// </summary>
		public DataTemplate CancerAwarenessAppointmentTemplate { get; set; }

		/// <summary>
		/// Gets or sets tourism appointment template.
		/// </summary>
		public DataTemplate TourismAppointmentTemplate { get; set; }

		/// <summary>
		/// Gets or sets environmental discussion appointment template.
		/// </summary>
		public DataTemplate EnvironmentalDiscussionAppointmentTemplate { get; set; }

		/// <summary>
		/// Gets or sets happiness appointment template.
		/// </summary>
		public DataTemplate HappinessAppointmentTemplate { get; set; }

		/// <summary>
		/// Gets or sets health checkup appointment template.
		/// </summary>
		public DataTemplate HealthCheckupAppointmentTemplate { get; set; }

		/// <summary>
		/// Template selection method
		/// </summary>
		/// <param name="item">return the object</param>
		/// <param name="container">return the bindable object</param>
		/// <returns>return the template</returns>
		protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
		{
            if (item is ScheduleAppointment appointment)
            {
                if (appointment.Subject == "Environmental Discussion")
                    return EnvironmentalDiscussionAppointmentTemplate;
                else if (appointment.Subject == "Health Checkup")
                    return HealthCheckupAppointmentTemplate;
                else if (appointment.Subject == "Cancer awareness")
                    return CancerAwarenessAppointmentTemplate;
                else if (appointment.Subject == "Happiness")
                    return HappinessAppointmentTemplate;
                else
                    return TourismAppointmentTemplate;
            }
            return TourismAppointmentTemplate;
		}
	}
}
