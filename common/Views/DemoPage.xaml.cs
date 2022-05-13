#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.Core;

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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.DataContext = e?.Parameter;
            if (this.DataContext != null)
            {
                var dataContext = this.DataContext as MainViewModel;

                this.DispatcherQueue.TryEnqueue(() =>
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
                                demoLayout.CopyButtonVisibility = string.IsNullOrEmpty(demoLayout.Xaml) && string.IsNullOrEmpty(demoLayout.XamlSource) && 
                                                                 string.IsNullOrEmpty(demoLayout.CSharp) && string.IsNullOrEmpty(demoLayout.CSharpSource) ? Visibility.Collapsed : Visibility.Visible;
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

            if (this.demoFrame.Content is IDisposable disposableObject)
                disposableObject.Dispose();

            this.demoFrame.Content = null;
            this.DataContext = null;
        }


        private async void DemoPageLoadingIndicatorLoaded(object sender, RoutedEventArgs e)
        {
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
            await Task.Delay(300);
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
            contentRoot.Visibility = Visibility.Visible;
            Header.Visibility = Visibility.Visible;
            loadingIndicator.Visibility = Visibility.Collapsed;
        }
    }
}
