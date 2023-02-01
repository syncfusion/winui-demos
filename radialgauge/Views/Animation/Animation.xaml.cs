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
    using System.Collections.Generic;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Media.Animation;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Animation : Page, IDisposable
    {
        public Animation()
        {
            this.InitializeComponent();
        }

        private void AnimationTypesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.needlePointer.AnimationEasingFunction = AnimationTypesComboBox.SelectedValue as EasingFunctionBase;
        }

        /// <summary>
        /// To dispose the objects.
        /// </summary>
        public void Dispose()
        {
            this.AnimationTypesComboBox.SelectionChanged -= this.AnimationTypesComboBox_SelectionChanged;
#if WinUI_Desktop
            this.gauge.Dispose();
#endif
            this.DataContext = null;
        }
    }

    public class AnimationDemoViewModel
    {
        public List<AnimationTypes> AnimationTypesItemsSource { get; }
        public AnimationDemoViewModel()
        {
            this.AnimationTypesItemsSource = new List<AnimationTypes>()
            {
                new AnimationTypes("Linear", "x:Null", null),
                new AnimationTypes("Bounce out", "BounceEase Bounciness=\"5\" EasingMode=\"EaseOut\"", new BounceEase { Bounciness = 5 }),
                new AnimationTypes("Ease", "CircleEase EasingMode=\"EaseOut\"", new CircleEase { EasingMode = EasingMode.EaseOut }),
                new AnimationTypes("Ease in cric", "CircleEase EasingMode=\"EaseIn\"", new CircleEase { EasingMode = EasingMode.EaseIn }),
                new AnimationTypes("Elastic out", "ElasticEase Oscillations=\"2\" Springiness=\"7\" EasingMode=\"EaseOut\"", new ElasticEase { Oscillations = 2, Springiness = 7 }),
                new AnimationTypes("Ease out back","BackEase Amplitude=\"0.5\" EasingMode=\"EaseOut\"", new BackEase { Amplitude = 0.5 }),
            };
        }
    }

    public class AnimationTypes
    {
        public string AnimationType { get; private set; }
        public string SubstitutionString { get; private set; }
        public EasingFunctionBase EasingFunction { get; private set; }
        public AnimationTypes(string animationType, string substitutionString, EasingFunctionBase easingFunction)
        {
            this.AnimationType = animationType;
            this.SubstitutionString = substitutionString;
            this.EasingFunction = easingFunction;
        }
    }
}
