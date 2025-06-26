#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Syncfusion.SchedulerDemos.WinUI
{
    using Microsoft.UI.Xaml.Media;
    using Microsoft.UI;

    /// <summary>
    /// Represents the smart scheduler resource view model class.
    /// </summary>
    public class SmartSchedulerResourceViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmartSchedulerResourceViewModel"/> class.
        /// </summary>
        public SmartSchedulerResourceViewModel()
        {
            this.Name = string.Empty;
            this.Id = string.Empty;
            this.Background = new SolidColorBrush(Colors.Transparent);
            this.Foreground = new SolidColorBrush(Colors.Black);
            this.ImageName = string.Empty;
        }

        #region Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///  Gets or sets the Background.
        /// </summary>
        public Brush Background { get; set; }

        /// <summary>
        ///  Gets or sets the Foreground.
        /// </summary>
        public Brush Foreground { get; set; }

        /// <summary>
        ///  Gets or sets the ImageName.
        /// </summary>
        public string ImageName { get; set; }

        #endregion
    }
}