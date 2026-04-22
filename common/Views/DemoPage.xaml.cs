#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// Demo page to display demo with code
    /// </summary>
    public sealed partial class DemoPage : Page
    {        
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoPage"/> class.
        /// Sets up the frame for navigating to demo content and assigns it to the `NavigationService`.
        /// </summary>
        public DemoPage()
        {
            this.InitializeComponent();
            NavigationService.DemoPageFrame = demoFrame;
        }

        /// <summary>
        /// Called when the page is navigated to.
        /// Sets the DataContext, handles sub-category demos, navigates to the main demo view, and applies themes.
        /// </summary>
        /// <param name="e">Navigation event arguments containing the data context parameter.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.DataContext = e?.Parameter;
            if (this.DataContext != null)
            {
                var dataContext = this.DataContext as MainViewModel;
                if (dataContext.DemoInfo?.SubCategoryDemos != null && dataContext.DemoInfo.SubCategoryDemos.Count > 0)
                {
                    rootGrid.Margin = new Thickness(0, 4, 0, 0);
                    if (dataContext.DemoInfo.DemoView != null || (dataContext.DemoInfo.Documentation != null && dataContext.DemoInfo.Documentation.Count > 0))
                    {
                        throw new Exception("Invalid values have been assigned to the DemoView or Documentation properties of the parent demo");
                    }
                    dataContext.SubCategorySelectedItem = dataContext.DemoInfo.SubCategoryDemos[0];
                }
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
                            Enum.TryParse(typeof(ElementTheme), ThemeHelper.RootTheme.ToString(), out object theme);
                            foreach (var demoLayout in demoLayouts)
                            {
                                demoLayout.IsCodeSnippetAvailable = string.IsNullOrEmpty(demoLayout.Xaml) && string.IsNullOrEmpty(demoLayout.XamlSource) &&
                                                                 string.IsNullOrEmpty(demoLayout.CSharp) && string.IsNullOrEmpty(demoLayout.CSharpSource) ? Visibility.Collapsed : Visibility.Visible;
                                demoLayout.ExampleContainer.RequestedTheme = (ElementTheme)theme;
                            }
                            dataContext.CurrentTheme = (ElementTheme)theme;
                        }
                    }
                });
            }

            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// Called when the page is navigated away from.
        /// Cleans up resources by disposing the content of the demo frame and nullifying the DataContext.
        /// </summary>
        /// <param name="e">Navigation event arguments.</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            if (this.demoFrame.Content is IDisposable disposableObject)
                disposableObject.Dispose();

            this.demoFrame.Content = null;
            this.DataContext = null;
        }

        /// <summary>
        /// Event handler for when the DemoPage Loading Indicator is loaded.
        /// It introduces a short delay before making the main content visible and hiding the loading indicator.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Routed event arguments.</param>
        private async void DemoPageLoadingIndicatorLoaded(object sender, RoutedEventArgs e)
        {
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
            await Task.Delay(50);
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
            contentRoot.Visibility = Visibility.Visible;
            Header.Visibility = Visibility.Visible;
            loadingIndicator.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Event handler for the theme toggle button click.
        /// Switches the application theme between Light and Dark.
        /// </summary>
        /// <param name="sender">The object that raised the event (toggle theme button).</param>
        /// <param name="e">Routed event arguments.</param>
        private void OnThemeButtonClick(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as MainViewModel;
            ElementTheme elementTheme;
            if (viewModel.CurrentTheme == ElementTheme.Default && Application.Current != null)
            {
                elementTheme = Application.Current.RequestedTheme.ToString() == "Dark" ? ElementTheme.Dark : ElementTheme.Light;
            }
            else
            {
                elementTheme = viewModel.CurrentTheme;
            }

            viewModel.CurrentTheme = elementTheme == ElementTheme.Dark ? ElementTheme.Light : ElementTheme.Dark; ;
        }

        /// <summary>
        /// Handles Preview KeyDown events for sub-category demo items, enabling left/right arrow navigation between them.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Key routed event arguments.</param>
        private void SubCategoryDemo_PreviewKeyDown(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            var dataContext = this.DataContext as MainViewModel;
            int selectedIndex = SubCategoryGridView.SelectedIndex;
            if (e.Key == Windows.System.VirtualKey.Right)
            {
                selectedIndex++;
                if(dataContext.DemoInfo.SubCategoryDemos != null && selectedIndex < dataContext.DemoInfo.SubCategoryDemos.Count)
                {
                    dataContext.SubCategorySelectedItem = dataContext.DemoInfo.SubCategoryDemos[selectedIndex];
                }
            }
            else if(e.Key == Windows.System.VirtualKey.Left)
            {
                selectedIndex--;
                if(selectedIndex >= 0)
                {
                    dataContext.SubCategorySelectedItem = dataContext.DemoInfo.SubCategoryDemos[selectedIndex];
                }
            }
            else if(e.Key == Windows.System.VirtualKey.Up || e.Key == Windows.System.VirtualKey.Down)
            {
                e.Handled= true;
            }
        }
    }
}
