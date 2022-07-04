#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.LinearGaugeDemos.WinUI.Views
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Media;
    using Microsoft.UI.Xaml.Shapes;
    using Windows.Foundation;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WaterLevelIndicatorDemo : Page, IDisposable
    {
        public WaterLevelIndicatorDemo()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
#if WinUI_Desktop
            this.Gauge.Dispose();
#endif
        }
    }

    #region Water tank control

    /// <summary>
    /// The water level indicator control.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = " Declared class is valid.")]
    public class WaterLevelControl : Control
    {
        #region Dependency registrations

        /// <summary>
        /// Identifies <see cref="GaugeSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty GaugeSizeProperty =
            DependencyProperty.Register(nameof(GaugeSize), typeof(Size), typeof(WaterLevelControl), new PropertyMetadata(null));

        #endregion

        #region Fields

        /// <summary>
        /// Backing field to store path.
        /// </summary>
        private Path path;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="WaterLevelControl"/> class.
        /// </summary>
        public WaterLevelControl()
        {
            this.DefaultStyleKey = typeof(WaterLevelControl);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the linear gauge size.
        /// </summary>
        public Size GaugeSize
        {
            get { return (Size)this.GetValue(GaugeSizeProperty); }
            set { this.SetValue(GaugeSizeProperty, value); }
        }

        #endregion

        #region Override methods

        /// <summary>
        /// Invoke to render <see cref="WaterLevelControl"/> class.
        /// </summary>
        protected override void OnApplyTemplate()
        {
            this.path = this.GetTemplateChild("PART_Path") as Path;
            if (this.path != null)
            {
                this.path.StrokeThickness = 1;
            }

            base.OnApplyTemplate();
        }

        /// <summary>
        /// Measures the size in layout required for child elements.
        /// </summary>
        /// <param name="availableSize">This size give to child elements.</param>
        /// <returns>Return child element size.</returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            if (availableSize != Size.Empty && this.GaugeSize != Size.Empty && this.path != null)
            {
                double factor = availableSize.Height / this.GaugeSize.Height;
                factor = 1 - factor;
                factor *= 0.25;
                List<Point> points = new List<Point>
                {
                new Point(availableSize.Width * factor, 0),
                new Point(availableSize.Width - (availableSize.Width * factor), 0),
                new Point(availableSize.Width * 0.75d, availableSize.Height - 1),
                new Point(availableSize.Width - (availableSize.Width * 0.75d), availableSize.Height - 1)
                };
                PathFigure figure = new PathFigure { StartPoint = points[0], IsClosed = true };
                for (int i = 1; i < points.Count; i++)
                {
                    figure.Segments.Add(new LineSegment { Point = points[i] });
                }

                PathGeometry rangePathGeometry = new PathGeometry();
                rangePathGeometry.Figures.Add(figure);
                this.path.Data = rangePathGeometry;
            }

            return base.MeasureOverride(availableSize);
        }

        #endregion
    }

    #endregion
}