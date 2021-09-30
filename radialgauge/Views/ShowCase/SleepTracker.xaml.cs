#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace syncfusion.radialgaugedemos.winui.Views
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
        /// Story board to perform marker pointer scale in animation.
        /// </summary>
        private Storyboard markerPointerScaleInAnimation;

        /// <summary>
        /// Story board to perform marker pointer scale out animation.
        /// </summary>
        private Storyboard markerPointerScaleOutAnimation;

        /// <summary>
        /// Story board to perform annotation scale in animation.
        /// </summary>
        private Storyboard annotationScaleInAnimation;

        /// <summary>
        /// Story board to perform annotation scale in animation.
        /// </summary>
        private Storyboard annotationScaleOutAnimation;

        /// <summary>
        /// Story board to perform annotation fade in animation.
        /// </summary>
        private Storyboard annotationFadeInAnimation;

        /// <summary>
        /// Story board to perform annotation fade out animation.
        /// </summary>
        private Storyboard annotationFadeOutAnimation;

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
            this.DisposeAnnotationFadeInAnimation();
            this.DisposeAnnotationFadeOutAnimation();
            this.DisposeAnnotationScaleInAnimation();
            this.DisposeAnnotationScaleOutAnimation();
            this.DisposeMarkerPointerScaleInAnimation();
            this.DisposeMarkerPointerScaleOutAnimation();
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
            this.ScaleInMarkerPointer(this.startPointer);
            this.AnnotationFadeOut(this.IntermediateAnnotation, this.EndValueAnnotation);
            this.AnnotationScaleIn(this.StartValueAnnotation, true);
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
            this.DisposeMarkerPointerScaleInAnimation();
            this.DisposeAnnotationScaleInAnimation();
            this.DisposeAnnotationFadeOutAnimation();

            this.ScaleOutMarkerPointer(this.startPointer);
            this.AnnotationFadeIn(this.IntermediateAnnotation, this.EndValueAnnotation);
            this.AnnotationScaleOut(this.StartValueAnnotation, true);
        }

        /// <summary>
        /// Called when end pointer value started changing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The value changed event arguments.</param>
        private void EndPointer_ValueChangeStarted(object sender, ValueChangedEventArgs e)
        {
            this.ScaleInMarkerPointer(this.EndPointer);
            this.AnnotationFadeOut(this.IntermediateAnnotation, this.StartValueAnnotation);
            this.AnnotationScaleIn(this.EndValueAnnotation, false);
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
            this.ScaleInMarkerPointer(this.EndPointer);
        }

        /// <summary>
        /// Called when end pointer value change completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The value changed event arguments.</param>
        private void EndPointer_ValueChangeCompleted(object sender, ValueChangedEventArgs e)
        {
            this.DisposeMarkerPointerScaleInAnimation();
            this.DisposeAnnotationScaleInAnimation();
            this.DisposeAnnotationFadeOutAnimation();

            this.ScaleOutMarkerPointer(this.EndPointer);
            this.AnnotationFadeIn(this.IntermediateAnnotation, this.StartValueAnnotation);
            this.AnnotationScaleOut(this.EndValueAnnotation, false);
        }

        /// <summary>
        /// Called when marker pointer scale out animation got completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The object.</param>
        private void MarkerPointerScaleOutAnimation_Completed(object sender, object e)
        {
            this.DisposeMarkerPointerScaleOutAnimation();
        }

        /// <summary>
        /// Called when annotation scale out animation got completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The object.</param>
        private void AnnotationScaleOutAnimation_Completed(object sender, object e)
        {
            this.DisposeAnnotationScaleOutAnimation();
        }

        /// <summary>
        /// Called when annotation fade in animation got completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The object.</param>
        private void AnnotationFadeInAnimation_Completed(object sender, object e)
        {
            this.DisposeAnnotationFadeInAnimation();
        }

        #region Implementations

        /// <summary>
        /// To perform marker pointer scale in animation.
        /// </summary>
        /// <param name="markerPointer">The marker pointer.</param>
        private void ScaleInMarkerPointer(Syncfusion.UI.Xaml.Gauges.MarkerPointer markerPointer)
        {
            if (this.markerPointerScaleInAnimation == null)
            {
                this.markerPointerScaleInAnimation = new Storyboard();

                DoubleAnimation doubleAnimation = new DoubleAnimation();
                this.markerPointerScaleInAnimation.Children.Add(doubleAnimation);
                doubleAnimation.EnableDependentAnimation = true;
                doubleAnimation.From = this.startPointer.MarkerHeight;
                doubleAnimation.To = this.startPointer.MarkerHeight + 10;
#if WinUI_Desktop
                doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
#else
                doubleAnimation.Duration = new Duration
                {
                    TimeSpan = TimeSpan.FromMilliseconds(100),
                    Type = DurationType.TimeSpan
                };
#endif
                Storyboard.SetTarget(doubleAnimation, markerPointer);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(Syncfusion.UI.Xaml.Gauges.MarkerPointer.MarkerHeight));

                doubleAnimation = new DoubleAnimation();
                this.markerPointerScaleInAnimation.Children.Add(doubleAnimation);
                doubleAnimation.EnableDependentAnimation = true;
                doubleAnimation.From = this.startPointer.MarkerHeight;
                doubleAnimation.To = this.startPointer.MarkerHeight + 10;
#if WinUI_Desktop
                doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
#else
                doubleAnimation.Duration = new Duration
                {
                    TimeSpan = TimeSpan.FromMilliseconds(100),
                    Type = DurationType.TimeSpan
                };
#endif
                Storyboard.SetTarget(doubleAnimation, markerPointer);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(Syncfusion.UI.Xaml.Gauges.MarkerPointer.MarkerWidth));

                this.markerPointerScaleInAnimation.Begin();
            }
        }

        /// <summary>
        /// To perform marker pointer scale out animation.
        /// </summary>
        /// <param name="markerPointer">The marker pointer.</param>
        private void ScaleOutMarkerPointer(Syncfusion.UI.Xaml.Gauges.MarkerPointer markerPointer)
        {
            if (this.markerPointerScaleOutAnimation == null)
            {
                this.markerPointerScaleOutAnimation = new Storyboard();
                this.markerPointerScaleOutAnimation.Completed += this.MarkerPointerScaleOutAnimation_Completed;

                DoubleAnimation doubleAnimation = new DoubleAnimation();
                this.markerPointerScaleOutAnimation.Children.Add(doubleAnimation);
                doubleAnimation.EnableDependentAnimation = true;
                doubleAnimation.From = this.startPointer.MarkerHeight + 10;
                doubleAnimation.To = this.startPointer.MarkerHeight;
#if WinUI_Desktop
                doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
#else
                doubleAnimation.Duration = new Duration
                {
                    TimeSpan = TimeSpan.FromMilliseconds(100),
                    Type = DurationType.TimeSpan
                };
#endif
                Storyboard.SetTarget(doubleAnimation, markerPointer);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(Syncfusion.UI.Xaml.Gauges.MarkerPointer.MarkerHeight));

                doubleAnimation = new DoubleAnimation();
                this.markerPointerScaleOutAnimation.Children.Add(doubleAnimation);
                doubleAnimation.EnableDependentAnimation = true;
                doubleAnimation.From = this.startPointer.MarkerHeight + 10;
                doubleAnimation.To = this.startPointer.MarkerHeight;
#if WinUI_Desktop
                doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
#else
                doubleAnimation.Duration = new Duration
                {
                    TimeSpan = TimeSpan.FromMilliseconds(100),
                    Type = DurationType.TimeSpan
                };
#endif
                Storyboard.SetTarget(doubleAnimation, markerPointer);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(Syncfusion.UI.Xaml.Gauges.MarkerPointer.MarkerWidth));

                this.markerPointerScaleOutAnimation.Begin();
            }
        }

        /// <summary>
        /// To perform annotation scale in animation.
        /// </summary>
        /// <param name="annotation">The annotation.</param>
        /// <param name="isStart">boolean to identify whether start or end pointer.</param>
        private void AnnotationScaleIn(GaugeAnnotation annotation, bool isStart)
        {
            if (this.annotationScaleInAnimation == null)
            {
                this.annotationScaleInAnimation = new Storyboard();

                TransformGroup transformGroup = new TransformGroup();
                transformGroup.Children.Add(new ScaleTransform());
                transformGroup.Children.Add(new TranslateTransform());
                annotation.RenderTransform = transformGroup;
                if (isStart)
                {
                    annotation.RenderTransformOrigin = new Point(0, 0.5);
                }
                else
                {
                    annotation.RenderTransformOrigin = new Point(1, 0.5);
                }

                DoubleAnimation doubleAnimation = new DoubleAnimation();
                this.annotationScaleInAnimation.Children.Add(doubleAnimation);
                doubleAnimation.EnableDependentAnimation = true;
                doubleAnimation.From = 1;
                doubleAnimation.To = 1.8;
#if WinUI_Desktop
                doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
#else
                doubleAnimation.Duration = new Duration
                {
                    TimeSpan = TimeSpan.FromMilliseconds(100),
                    Type = DurationType.TimeSpan
                };
#endif
                Storyboard.SetTarget(doubleAnimation, annotation);
                Storyboard.SetTargetProperty(doubleAnimation, "(UIElement.RenderTransform).Children[0].ScaleX");

                doubleAnimation = new DoubleAnimation();
                this.annotationScaleInAnimation.Children.Add(doubleAnimation);
                doubleAnimation.EnableDependentAnimation = true;
                doubleAnimation.From = 1;
                doubleAnimation.To = 1.8;
#if WinUI_Desktop
                doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
#else
                doubleAnimation.Duration = new Duration
                {
                    TimeSpan = TimeSpan.FromMilliseconds(100),
                    Type = DurationType.TimeSpan
                };
#endif
                Storyboard.SetTarget(doubleAnimation, annotation);
                Storyboard.SetTargetProperty(doubleAnimation, "(UIElement.RenderTransform).Children[0].ScaleY");

                doubleAnimation = new DoubleAnimation();
                this.annotationScaleInAnimation.Children.Add(doubleAnimation);
                doubleAnimation.EnableDependentAnimation = true;
                doubleAnimation.From = 0.4;
                doubleAnimation.To = 0.15;
#if WinUI_Desktop
                doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
#else
                doubleAnimation.Duration = new Duration
                {
                    TimeSpan = TimeSpan.FromMilliseconds(100),
                    Type = DurationType.TimeSpan
                };
#endif
                Storyboard.SetTarget(doubleAnimation, annotation);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(GaugeAnnotation.PositionFactor));

                this.annotationScaleInAnimation.Begin();
            }
        }

        /// <summary>
        /// To perform annotation scale out animation.
        /// </summary>
        /// <param name="annotation">The annotation.</param>
        /// <param name="isStart">boolean to identify whether start or end pointer.</param>
        private void AnnotationScaleOut(GaugeAnnotation annotation, bool isStart)
        {
            if (this.annotationScaleOutAnimation == null)
            {
                this.annotationScaleOutAnimation = new Storyboard();
                this.annotationScaleOutAnimation.Completed += this.AnnotationScaleOutAnimation_Completed;

                TransformGroup transformGroup = new TransformGroup();
                transformGroup.Children.Add(new ScaleTransform());
                transformGroup.Children.Add(new TranslateTransform());
                annotation.RenderTransform = transformGroup;
                if (isStart)
                {
                    annotation.RenderTransformOrigin = new Point(0, 0.5);
                }
                else
                {
                    annotation.RenderTransformOrigin = new Point(1, 0.5);
                }

                DoubleAnimation doubleAnimation = new DoubleAnimation();
                this.annotationScaleOutAnimation.Children.Add(doubleAnimation);
                doubleAnimation.EnableDependentAnimation = true;
                doubleAnimation.From = 1.8;
                doubleAnimation.To = 1;
#if WinUI_Desktop
                doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
#else
                doubleAnimation.Duration = new Duration
                {
                    TimeSpan = TimeSpan.FromMilliseconds(100),
                    Type = DurationType.TimeSpan
                };
#endif
                Storyboard.SetTarget(doubleAnimation, annotation);
                Storyboard.SetTargetProperty(doubleAnimation, "(UIElement.RenderTransform).Children[0].ScaleX");

                doubleAnimation = new DoubleAnimation();
                this.annotationScaleOutAnimation.Children.Add(doubleAnimation);
                doubleAnimation.EnableDependentAnimation = true;
                doubleAnimation.From = 1.8;
                doubleAnimation.To = 1;
#if WinUI_Desktop
                doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
#else
                doubleAnimation.Duration = new Duration
                {
                    TimeSpan = TimeSpan.FromMilliseconds(100),
                    Type = DurationType.TimeSpan
                };
#endif
                Storyboard.SetTarget(doubleAnimation, annotation);
                Storyboard.SetTargetProperty(doubleAnimation, "(UIElement.RenderTransform).Children[0].ScaleY");

                doubleAnimation = new DoubleAnimation();
                this.annotationScaleOutAnimation.Children.Add(doubleAnimation);
                doubleAnimation.EnableDependentAnimation = true;
                doubleAnimation.From = 0.15;
                doubleAnimation.To = 0.4;
#if WinUI_Desktop
                doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
#else
                doubleAnimation.Duration = new Duration
                {
                    TimeSpan = TimeSpan.FromMilliseconds(100),
                    Type = DurationType.TimeSpan
                };
#endif
                Storyboard.SetTarget(doubleAnimation, annotation);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(GaugeAnnotation.PositionFactor));

                this.annotationScaleOutAnimation.Begin();
            }
        }

        /// <summary>
        /// To perform annotation fade out animation.
        /// </summary>
        /// <param name="intermediateAnnotation">The intermediate annotation.</param>
        /// <param name="startOrEndAnnotation">The start or end value annotation.</param>
        private void AnnotationFadeOut(GaugeAnnotation intermediateAnnotation, GaugeAnnotation startOrEndAnnotation)
        {
            if (this.annotationFadeOutAnimation == null)
            {
                this.annotationFadeOutAnimation = new Storyboard();

                DoubleAnimation doubleAnimation = new DoubleAnimation();
                this.annotationFadeOutAnimation.Children.Add(doubleAnimation);
                doubleAnimation.EnableDependentAnimation = true;
                doubleAnimation.From = 1;
                doubleAnimation.To = 0;
#if WinUI_Desktop
                doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
#else
                doubleAnimation.Duration = new Duration
                {
                    TimeSpan = TimeSpan.FromMilliseconds(100),
                    Type = DurationType.TimeSpan
                };
#endif
                Storyboard.SetTarget(doubleAnimation, intermediateAnnotation);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(UIElement.Opacity));

                doubleAnimation = new DoubleAnimation();
                this.annotationFadeOutAnimation.Children.Add(doubleAnimation);
                doubleAnimation.EnableDependentAnimation = true;
                doubleAnimation.From = 1;
                doubleAnimation.To = 0;
#if WinUI_Desktop
                doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
#else
                doubleAnimation.Duration = new Duration
                {
                    TimeSpan = TimeSpan.FromMilliseconds(100),
                    Type = DurationType.TimeSpan
                };
#endif
                Storyboard.SetTarget(doubleAnimation, startOrEndAnnotation);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(UIElement.Opacity));

                this.annotationFadeOutAnimation.Begin();
            }
        }

        /// <summary>
        /// To perform annotation fade in animation.
        /// </summary>
        /// <param name="intermediateAnnotation">The intermediate annotation.</param>
        /// <param name="startOrEndAnnotation">The start or end value annotation.</param>
        private void AnnotationFadeIn(GaugeAnnotation intermediateAnnotation, GaugeAnnotation startOrEndAnnotation)
        {
            if (this.annotationFadeInAnimation == null)
            {
                this.annotationFadeInAnimation = new Storyboard();
                this.annotationFadeInAnimation.Completed += this.AnnotationFadeInAnimation_Completed;

                DoubleAnimation doubleAnimation = new DoubleAnimation();
                this.annotationFadeInAnimation.Children.Add(doubleAnimation);
                doubleAnimation.EnableDependentAnimation = true;
                doubleAnimation.From = 0;
                doubleAnimation.To = 1;
#if WinUI_Desktop
                doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
#else
                doubleAnimation.Duration = new Duration
                {
                    TimeSpan = TimeSpan.FromMilliseconds(100),
                    Type = DurationType.TimeSpan
                };
#endif
                Storyboard.SetTarget(doubleAnimation, intermediateAnnotation);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(UIElement.Opacity));

                doubleAnimation = new DoubleAnimation();
                this.annotationFadeInAnimation.Children.Add(doubleAnimation);
                doubleAnimation.EnableDependentAnimation = true;
                doubleAnimation.From = 0;
                doubleAnimation.To = 1;
#if WinUI_Desktop
                doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
#else
                doubleAnimation.Duration = new Duration
                {
                    TimeSpan = TimeSpan.FromMilliseconds(100),
                    Type = DurationType.TimeSpan
                };
#endif
                Storyboard.SetTarget(doubleAnimation, startOrEndAnnotation);
                Storyboard.SetTargetProperty(doubleAnimation, nameof(UIElement.Opacity));

                this.annotationFadeInAnimation.Begin();
            }
        }

        /// <summary>
        /// To dispose annotation fade out animation storyboard.
        /// </summary>
        private void DisposeAnnotationFadeOutAnimation()
        {
            if (this.annotationFadeOutAnimation != null)
            {
                this.annotationFadeOutAnimation.Stop();
                this.annotationFadeOutAnimation.Children.Clear();
                this.annotationFadeOutAnimation = null;
            }
        }

        /// <summary>
        /// To dispose annotation scale in animation storyboard.
        /// </summary>
        private void DisposeAnnotationScaleInAnimation()
        {
            if (this.annotationScaleInAnimation != null)
            {
                this.annotationScaleInAnimation.Stop();
                this.annotationScaleInAnimation.Children.Clear();
                this.annotationScaleInAnimation = null;
            }
        }

        /// <summary>
        /// To dispose marker pointer scale in animation storyboard.
        /// </summary>
        private void DisposeMarkerPointerScaleInAnimation()
        {
            if (this.markerPointerScaleInAnimation != null)
            {
                this.markerPointerScaleInAnimation.Stop();
                this.markerPointerScaleInAnimation.Children.Clear();
                this.markerPointerScaleInAnimation = null;
            }
        }

        /// <summary>
        /// To dispose marker pointer scale out animation storyboard.
        /// </summary>
        private void DisposeMarkerPointerScaleOutAnimation()
        {
            if (this.markerPointerScaleOutAnimation != null)
            {
                this.markerPointerScaleOutAnimation.Completed -= this.MarkerPointerScaleOutAnimation_Completed;
                this.markerPointerScaleOutAnimation.Stop();
                this.markerPointerScaleOutAnimation.Children.Clear();
                this.markerPointerScaleOutAnimation = null;
            }
        }

        /// <summary>
        /// To dispose annotation scale out animation storyboard.
        /// </summary>
        private void DisposeAnnotationScaleOutAnimation()
        {
            if (this.annotationScaleOutAnimation != null)
            {
                this.annotationScaleOutAnimation.Completed -= this.AnnotationScaleOutAnimation_Completed;
                this.annotationScaleOutAnimation.Stop();
                this.annotationScaleOutAnimation.Children.Clear();
                this.annotationScaleOutAnimation = null;
            }
        }

        /// <summary>
        /// To dispose annotation fade in animation storyboard.
        /// </summary>
        private void DisposeAnnotationFadeInAnimation()
        {
            if (this.annotationFadeInAnimation != null)
            {
                this.annotationFadeInAnimation.Completed -= this.AnnotationFadeInAnimation_Completed;
                this.annotationFadeInAnimation.Stop();
                this.annotationFadeInAnimation.Children.Clear();
                this.annotationFadeInAnimation = null;
            }
        }

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

#endregion
    }
}