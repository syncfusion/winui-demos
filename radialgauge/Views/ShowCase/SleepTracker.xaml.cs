#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
    using System.Globalization;
    using System.Linq;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Media;
    using Microsoft.UI.Xaml.Media.Animation;
    using Syncfusion.UI.Xaml.Gauges;
    using Windows.Foundation;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SleepTracker : Page, IDisposable
    {
        /// <summary>
        /// Story board to perform pointer pressed animation.
        /// </summary>
        private Storyboard storyBoard;

        /// <summary>
        /// Initializes a new instance of the <see cref="SleepTracker"/> class.
        /// </summary>
        public SleepTracker()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            this.DisposeStoryboard();
#if WinUI_Desktop
            this.sleepTracker.Dispose();
#endif
        }

        /// <summary>
        /// Called when start pointer value started changing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The value changed event arguments.</param>
        private void StartPointer_ValueChangeStarted(object sender, ValueChangedEventArgs e)
        {
            this.DisposeStoryboard();
            this.OnStartAnimation(true);
        }

        /// <summary>
        /// Called when start pointer value changing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The value changing event arguments.</param>
        private void StartPointer_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            this.range.StartValue = e.NewValue;
            this.CalculateSleepTime();
        }

        /// <summary>
        /// Called when start pointer value change completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The value changed event arguments.</param>
        private void StartPointer_ValueChangeCompleted(object sender, ValueChangedEventArgs e)
        {
            this.DisposeStoryboard();
            this.OnEndAnimation(true);
        }

        /// <summary>
        /// Called when end pointer value started changing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The value changed event arguments.</param>
        private void EndPointer_ValueChangeStarted(object sender, ValueChangedEventArgs e)
        {
            this.DisposeStoryboard();
            this.OnStartAnimation(false);
        }

        /// <summary>
        /// Called when end pointer value changing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The value changing event arguments.</param>
        private void EndPointer_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            this.range.EndValue = e.NewValue;
            this.CalculateSleepTime();
        }

        /// <summary>
        /// Called when end pointer value change completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The value changed event arguments.</param>
        private void EndPointer_ValueChangeCompleted(object sender, ValueChangedEventArgs e)
        {
            this.DisposeStoryboard();
            this.OnEndAnimation(false);
        }

        #region Implementations

        /// <summary>
        /// To calculate sleep time.
        /// </summary>
        private void CalculateSleepTime()
        {
            if (this.range.StartValue < this.range.EndValue)
            {
                this.EndValueAnnotationDate.Text = "4 Apr";
            }
            else
            {
                this.EndValueAnnotationDate.Text = "5 Apr";
            }

            DateTime startDate = this.ConvertToDateTime(new DateTime(2021, 4, 4), this.range.StartValue);
            this.SleepTime.Text = this.GetDisplayString(startDate.Hour) + ":" + this.GetDisplayString(startDate.Minute);

            DateTime endDate = this.ConvertToDateTime(new DateTime(2021, 4, 5), this.range.EndValue);
            this.WakeUpTime.Text = this.GetDisplayString(endDate.Hour) + ":" + this.GetDisplayString(endDate.Minute);

            TimeSpan timeSpan = endDate.Subtract(startDate);
            this.sleepedTime.Text = this.GetDisplayString(timeSpan.Hours) + " hrs " + this.GetDisplayString(timeSpan.Minutes) + " min";
        }

        /// <summary>
        /// To get the display value.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="hoursValue">The hour value.</param>
        /// <param name="minutesValue">The minutes value.</param>
        private string GetDisplayString(int value)
        {
            float digit = value / 10f;
            bool isSingleDigit = digit >= 1 ? false : true;
            return isSingleDigit ? "0" + value : value.ToString(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// To convert the pointer value to date.
        /// </summary>
        /// <param name="day">The day.</param>
        /// <param name="value">The pointer value.</param>
        /// <returns>Calculated date.</returns>
        private DateTime ConvertToDateTime(DateTime day, double value)
        {
            int hours = this.GetHours(value);
            day = day.AddHours(hours);
            day = day.AddMinutes(this.GetMinutes(value, hours));
            return day;
        }

        /// <summary>
        /// To get the hours from pointer value.
        /// </summary>
        /// <param name="value">The pointer value.</param>
        /// <returns>Calculated hours value.</returns>
        private int GetHours(double value)
        {
            return Convert.ToInt32(Math.Floor(value));
        }

        /// <summary>
        /// To get the minutes from pointer value.
        /// </summary>
        /// <param name="value">The pointer value.</param>
        /// <param name="hour">The hours.</param>
        /// <returns>The calculated minutes value.</returns>
        private int GetMinutes(double value, int hour)
        {
            return Convert.ToInt32(Math.Floor((value - hour) * 60));
        }

        /// <summary>
        /// To perform animation on pointer pressed.
        /// </summary>
        /// <param name="isStart">Boolean to identify whether start or end pointer.</param>
        private void OnStartAnimation(bool isStart)
        {
            if (this.storyBoard == null)
            {
                this.storyBoard = new Storyboard();
                DoubleAnimation doubleAnimation = this.GetDoubleAnimation(this.StartPtrContentView.Height, this.StartPtrContentView.Height + 10);
                this.storyBoard.Children.Add(doubleAnimation);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(Height));
                Storyboard.SetTarget(doubleAnimation, isStart ? this.StartPtrContentView : this.EndPtrContentView);

                doubleAnimation = this.GetDoubleAnimation(this.StartPtrContentView.Width, this.StartPtrContentView.Width + 10);
                this.storyBoard.Children.Add(doubleAnimation);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(Width));
                Storyboard.SetTarget(doubleAnimation, isStart ? this.StartPtrContentView : this.EndPtrContentView);

                doubleAnimation = this.GetDoubleAnimation(1, 0);
                this.storyBoard.Children.Add(doubleAnimation);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(UIElement.Opacity));
                Storyboard.SetTarget(doubleAnimation, this.IntermediateAnnotation);

                doubleAnimation = this.GetDoubleAnimation(1, 0);
                this.storyBoard.Children.Add(doubleAnimation);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(UIElement.Opacity));
                Storyboard.SetTarget(doubleAnimation, isStart ? this.EndValueAnnotation : this.StartValueAnnotation);

                TransformGroup transformGroup = new TransformGroup();
                transformGroup.Children.Add(new ScaleTransform());
                transformGroup.Children.Add(new TranslateTransform());
                GaugeAnnotation gaugeAnnotation = isStart ? this.StartValueAnnotation : this.EndValueAnnotation;
                gaugeAnnotation.RenderTransform = transformGroup;
                gaugeAnnotation.RenderTransformOrigin = isStart ? new Point(0, 0.5) : new Point(1, 0.5);

                doubleAnimation = this.GetDoubleAnimation(1, 1.8);
                this.storyBoard.Children.Add(doubleAnimation);
                Storyboard.SetTarget(doubleAnimation, isStart ? this.StartValueAnnotation : this.EndValueAnnotation);
                Storyboard.SetTargetProperty(doubleAnimation, "(UIElement.RenderTransform).Children[0].ScaleX");

                doubleAnimation = this.GetDoubleAnimation(1, 1.8);
                this.storyBoard.Children.Add(doubleAnimation);
                Storyboard.SetTarget(doubleAnimation, isStart ? this.StartValueAnnotation : this.EndValueAnnotation);
                Storyboard.SetTargetProperty(doubleAnimation, "(UIElement.RenderTransform).Children[0].ScaleY");

                doubleAnimation = this.GetDoubleAnimation(0.4, 0.15);
                this.storyBoard.Children.Add(doubleAnimation);
                Storyboard.SetTarget(doubleAnimation, isStart ? this.StartValueAnnotation : this.EndValueAnnotation);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(GaugeAnnotation.PositionFactor));
                
                this.storyBoard.Begin();
            }
        }

        /// <summary>
        /// To perform animation on pointer released.
        /// </summary>
        /// <param name="isStart">Boolean to identify whether start or end pointer.</param>
        private void OnEndAnimation(bool isStart)
        {
            if (this.storyBoard == null)
            {
                this.storyBoard = new Storyboard();
                this.storyBoard.Completed += this.Storyboard_Completed;

                DoubleAnimation doubleAnimation = this.GetDoubleAnimation(this.StartPtrContentView.Height + 10, this.StartPtrContentView.Height);
                this.storyBoard.Children.Add(doubleAnimation);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(Height));
                Storyboard.SetTarget(doubleAnimation, isStart ? this.StartPtrContentView : this.EndPtrContentView);

                doubleAnimation = this.GetDoubleAnimation(this.StartPtrContentView.Width + 10, this.StartPtrContentView.Width);
                this.storyBoard.Children.Add(doubleAnimation);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(Width));
                Storyboard.SetTarget(doubleAnimation, isStart ? this.StartPtrContentView : this.EndPtrContentView);

                doubleAnimation = this.GetDoubleAnimation(0, 1);
                this.storyBoard.Children.Add(doubleAnimation);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(UIElement.Opacity));
                Storyboard.SetTarget(doubleAnimation, isStart ? this.EndValueAnnotation : this.StartValueAnnotation);

                doubleAnimation = this.GetDoubleAnimation(0, 1);
                this.storyBoard.Children.Add(doubleAnimation);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(UIElement.Opacity));
                Storyboard.SetTarget(doubleAnimation, this.IntermediateAnnotation);

                TransformGroup transformGroup = new TransformGroup();
                transformGroup.Children.Add(new ScaleTransform());
                transformGroup.Children.Add(new TranslateTransform());
                GaugeAnnotation gaugeAnnotation = isStart ? this.StartValueAnnotation : this.EndValueAnnotation;
                gaugeAnnotation.RenderTransform = transformGroup;
                gaugeAnnotation.RenderTransformOrigin = isStart ? new Point(0,0.5) : new Point(1,0.5);

                doubleAnimation = this.GetDoubleAnimation(1.8, 1);
                this.storyBoard.Children.Add(doubleAnimation);
                Storyboard.SetTargetProperty(doubleAnimation, "(UIElement.RenderTransform).Children[0].ScaleX");
                Storyboard.SetTarget(doubleAnimation, isStart ? this.StartValueAnnotation : this.EndValueAnnotation);

                doubleAnimation = this.GetDoubleAnimation(1.8, 1);
                this.storyBoard.Children.Add(doubleAnimation);
                Storyboard.SetTargetProperty(doubleAnimation, "(UIElement.RenderTransform).Children[0].ScaleY");
                Storyboard.SetTarget(doubleAnimation, isStart ? this.StartValueAnnotation : this.EndValueAnnotation);

                doubleAnimation = this.GetDoubleAnimation(0.15, 0.4);
                this.storyBoard.Children.Add(doubleAnimation);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(GaugeAnnotation.PositionFactor));
                Storyboard.SetTarget(doubleAnimation, isStart ? this.StartValueAnnotation : this.EndValueAnnotation);
                this.storyBoard.Begin();
            }
        }

        /// <summary>
        /// To get the double animation.
        /// </summary>
        /// <param name="from">The double animation from value.</param>
        /// <param name="to">The double animation end value.</param>
        /// <returns>The double animation instance for the given from and to values.</returns>
        private DoubleAnimation GetDoubleAnimation(double from, double to)
        {
            return new DoubleAnimation
            {
                EnableDependentAnimation = true,
                From = from,
                To = to,
#if WinUI_Desktop
                Duration = new Duration(TimeSpan.FromMilliseconds(100))
#else
                Duration = new Duration
                {
                    TimeSpan = TimeSpan.FromMilliseconds(100),
                    Type = DurationType.TimeSpan
                };
#endif
            };
        }

        /// <summary>
        /// Called when animation get completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The object.</param>
        private void Storyboard_Completed(object sender, object e)
        {
            this.DisposeStoryboard();
        }

        /// <summary>
        /// To dispose annotation fade out animation storyboard.
        /// </summary>
        private void DisposeStoryboard()
        {
            if (this.storyBoard != null)
            {
                this.storyBoard.Completed -= this.Storyboard_Completed;
                this.storyBoard.Stop();
                this.storyBoard.Children.Clear();
                this.storyBoard = null;
            }
        }

        #endregion

    }
}