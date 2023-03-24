#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.RadialGaugeDemos.WinUI.Views
{
    using System;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Navigation;
    using Syncfusion.UI.Xaml.Gauges;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Clock : Page, IDisposable
    {
        private double seconds;
        private DispatcherTimer timer;
        public Clock()
        {
            this.InitializeComponent();
            this.seconds = 0;
            timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 1000)
            };
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, object e)
        {
            this.seconds += 0.2;
            this.secondsPointer.Value = seconds;
            if (this.seconds >= 12)
            {
                this.secondsPointer.EnableAnimation = false;
                this.seconds = 0.2;
                this.secondsPointer.Value = seconds;
                this.secondsPointer.EnableAnimation = true;
            }
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        private void DisposeObjects()
        {
            this.timer.Stop();
            this.timer.Tick -= this.Timer_Tick;
            this.timer = null;

#if WinUI_Desktop
            this.gauge.Dispose();
            this.clock1.Dispose();
            this.clock2.Dispose();
#endif
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.timer.Start();
            base.OnNavigatedTo(e);
        }

        public void Dispose()
        {
            DisposeObjects();
        }
    }

    public class ClockRadialAxis : RadialAxis
    {
        protected override void OnApplyTemplate()
        {
            ItemsControl annotations = GetTemplateChild("PART_Annotations") as ItemsControl;
            if (annotations != null)
            {
                // To bring the annotation back to needle.
                Canvas.SetZIndex(annotations, -1);
            }

            base.OnApplyTemplate();
        }
    }
}