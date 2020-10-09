#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.Core.Extensions;

namespace syncfusion.demoscommon.winui
{
    /// <summary>
    /// Demo page to display demo with code
    /// </summary>
    public sealed partial class DemoPage : Page
    {
        public DemoPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.DataContext = e?.Parameter;
            if (this.DataContext != null)
            {
                var dataContext = this.DataContext as MainViewModel;

                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    if (dataContext.DemoInfo?.DemoView != null)
                    {
                        demoFrame.Navigate(dataContext.DemoInfo.DemoView);
                    }

                    if (this.demoFrame.Content is FrameworkElement frameworkElement)
                    {
                        var demoLayouts = LogicalTree.FindChildren<DemoLayout>(frameworkElement);
                        if (demoLayouts != null)
                        {
                            Enum.TryParse(typeof(ElementTheme), dataContext.CurrentTheme.ToString(), out object theme);
                            foreach (var demoLayout in demoLayouts)
                            {
                                demoLayout.ExampleContainer.RequestedTheme = (ElementTheme)theme;
                            }
                        }
                    }
                });
            }

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if (this.demoFrame.Content is FrameworkElement frameworkElement)
            {
                if (this.demoFrame.Content is IDisposable disposableObject)
                    disposableObject.Dispose();

                this.demoFrame.Content = null;

                var demoLayouts = LogicalTree.FindChildren<DemoLayout>(frameworkElement);
                if (demoLayouts != null)
                {
                    foreach (var demoLayout in demoLayouts)
                    {
                        demoLayout.HeaderText = null;
                        demoLayout.Example = null;
                        demoLayout.Options = null;
                        demoLayout.Xaml = null;
                        demoLayout.XamlSource = null;
                        demoLayout.CSharp = null;
                        demoLayout.CSharpSource = null;
                        demoLayout.Substitutions.Clear();
                    }
                }
            }

            this.demoFrame.Content = null;
            this.DataContext = null;
            GC.Collect();
        }
    }
}
