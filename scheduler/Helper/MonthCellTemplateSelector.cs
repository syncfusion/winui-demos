#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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

namespace syncfusion.schedulerdemos.winui
{
    public class MonthCellTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MonthCellTemplateSelector" /> class.
        /// </summary>
        public MonthCellTemplateSelector()
        {

        }

        /// <summary>
        /// Gets or sets Month Appointment Template1.
        /// </summary>
        public DataTemplate MonthCellWithoutBestPriceTemplate1 { get; set; }

		/// <summary>
		/// Gets or sets Month Appointment Template2.
		/// </summary>
		public DataTemplate MonthCellWithoutBestPriceTemplate2 { get; set; }

		/// <summary>
		/// Gets or sets Month Appointment Template3.
		/// </summary>
		public DataTemplate MonthCellWithoutBestPriceTemplate3 { get; set; }

		/// <summary>
		/// Gets or sets Month Cell Dates Template.
		/// </summary>
		public DataTemplate MonthCellWithBestPriceTemplate1 { get; set; }

		/// <summary>
		/// Gets or sets Month Cell Dates Template.
		/// </summary>
		public DataTemplate MonthCellWithBestPriceTemplate2 { get; set; }

		/// <summary>
		/// Gets or sets Month Cell Dates Template.
		/// </summary>
		public DataTemplate MonthCellWithBestPriceTemplate3 { get; set; }

		/// <summary>
		/// Template selection method
		/// </summary>
		/// <param name="item">return the object</param>
		/// <param name="container">return the bindable object</param>
		/// <returns>return the template</returns>
		protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
		{
			var appointments = item as List<ScheduleAppointment>;

			foreach (var app in appointments)
			{
				if(app.Subject == "Airways 1")
				{
					if (app.Notes == "$100.17")
						return MonthCellWithBestPriceTemplate1;
					else
						return
							MonthCellWithoutBestPriceTemplate1;
				}

				else if (app.Subject == "Airways 2")
				{
					if (app.Notes == "$100.17")
						return MonthCellWithBestPriceTemplate2;
					else
						return
							MonthCellWithoutBestPriceTemplate2;
				}

				else if (app.Subject == "Airways 3")
				{
					if (app.Notes == "$100.17")
						return MonthCellWithBestPriceTemplate3;
					else
						return
							MonthCellWithoutBestPriceTemplate3;
				}

			}
			return MonthCellWithoutBestPriceTemplate1;
		}
	}

}
