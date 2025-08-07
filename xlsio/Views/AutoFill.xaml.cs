#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.XlsIO;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.Storage;
using Windows.UI.Popups;

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    public partial class AutoFill : Page
    {
        private List<DisplayItem> AutoFillOptions = new List<DisplayItem>
        {
            new DisplayItem { Text = "Default", Value = "FillDefault" },
            new DisplayItem { Text = "Copy", Value = "FillCopy" },
            new DisplayItem { Text = "Series", Value = "FillSeries" },
            new DisplayItem { Text = "Formats", Value = "FillFormats" },
            new DisplayItem { Text = "Values", Value = "FillValues" },
            new DisplayItem { Text = "Days", Value = "FillDays" },
            new DisplayItem { Text = "Weekdays", Value = "FillWeekdays" },
            new DisplayItem { Text = "Months", Value = "FillMonths" },
            new DisplayItem { Text = "Years", Value = "FillYears" },
            new DisplayItem { Text = "Linear Trend", Value = "LinearTrend" },
            new DisplayItem { Text = "Growth Trend", Value = "GrowthTrend" }
        };
        private List<DisplayItem> FillSeriesOptions = new List<DisplayItem>
        {
            new DisplayItem { Text = "Linear", Value = "Linear" },
            new DisplayItem { Text = "Growth", Value = "Growth" },
            new DisplayItem { Text = "Days", Value = "Days" },
            new DisplayItem { Text = "Weekdays", Value = "Weekdays" },
            new DisplayItem { Text = "Months", Value = "Months" },
            new DisplayItem { Text = "Years", Value = "Years" },
            new DisplayItem { Text = "AutoFill", Value = "AutoFill" }
        };
        private AutoFillOptionsModel model = new AutoFillOptionsModel();

        public AutoFill()
        {
            this.InitializeComponent();
            this.Loaded += AutoFill_Loaded;
        }
        private void AutoFill_Loaded(object sender, RoutedEventArgs e)
        {
            SetupControls();
        }

        private void SetupControls()
        {
            if (FillOptionCombo == null || AutoFillRadio == null)
                return;

            FillOptionCombo.ItemsSource = AutoFillOptions;
            FillOptionCombo.DisplayMemberPath = "Text";
            FillOptionCombo.SelectedValuePath = "Value";
            SeriesByCombo.ItemsSource = Enum.GetNames(typeof(ExcelSeriesBy));
            SeriesByCombo.SelectedIndex = 0;
            FillOptionCombo.SelectionChanged += FillOptionsComboBox_SelectionChanged;
            AutoFillRadio.Checked += FillTypeChanged;
            FillSeriesRadio.Checked += FillTypeChanged;
            TrendCheckBox.Checked += TrendCheckboxChanged;
            TrendCheckBox.Unchecked += TrendCheckboxChanged;
            AutoFillRadio.IsChecked = true;
            this.DispatcherQueue.TryEnqueue(() =>
            {
                FillOptionCombo.SelectedIndex = 0;
                ToggleFieldStates();
            });
        }

        private void FillTypeChanged(object sender, RoutedEventArgs e)
        {
            if (FillOptionCombo == null || AutoFillRadio == null)
                return;
            FillOptionCombo.ItemsSource = AutoFillRadio.IsChecked == true ? AutoFillOptions : FillSeriesOptions;
            FillOptionCombo.DisplayMemberPath = "Text";
            FillOptionCombo.SelectedValuePath = "Value";
            FillOptionCombo.SelectedIndex = 0;
            StepValueTextBox.Text = string.Empty;
            StopValueTextBox.Text = string.Empty;
            if (AutoFillRadio.IsChecked == true)
            {
                SeriesByCombo.SelectedIndex = 0;
            }
            else
            {
                SeriesByCombo.SelectedIndex = 0;
            }
            ToggleFieldStates();
        }

        private void FillOptionsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToggleFieldStates();
        }

        private void TrendCheckboxChanged(object sender, RoutedEventArgs e)
        {
            ToggleFieldStates();
        }

        private void ToggleFieldStates()
        {
            var selected = FillOptionCombo.SelectedValue?.ToString() ?? "";
            bool isAutoFill = AutoFillRadio.IsChecked == true;
            bool isLinearOrGrowth = selected == "Linear" || selected == "Growth";
            bool isAType = selected.StartsWith("A");
            bool trendChecked = TrendCheckBox.IsChecked == true;
            if (!isAutoFill && isLinearOrGrowth)
            {
                TrendCheckBox.Visibility = Visibility.Visible;
                TrendCheckBox.IsEnabled = true;
            }
            else
            {
                TrendCheckBox.Visibility = Visibility.Collapsed;
                TrendCheckBox.IsChecked = false; 
            }
            // Enable or disable SeriesBy and TrendCheckBox
            SeriesByCombo.IsEnabled = !isAutoFill;
            TrendCheckBox.IsEnabled = !isAutoFill && !isAType && isLinearOrGrowth;
            if (TrendCheckBox.IsEnabled) {
                StepValueTextBox.Text = string.Empty;
                StopValueTextBox.Text = string.Empty;
            }
            // Enable Step/Stop fields for FillSeries by default,
            // but disable if Linear or Growth is selected and Trend is checked
            if (!isAutoFill && isLinearOrGrowth && trendChecked && !isAType)
            {
                StepValueTextBox.IsEnabled = false;
                StopValueTextBox.IsEnabled = false;
            }
            else if (isAType && !isAutoFill)
            {
                StepValueTextBox.Text = string.Empty;
                StopValueTextBox.Text = string.Empty;
                StepValueTextBox.IsEnabled = false;
                StopValueTextBox.IsEnabled = false;
            }
            else
            {
                StepValueTextBox.IsEnabled = !isAutoFill;
                StopValueTextBox.IsEnabled = !isAutoFill;
            }
        }


        private void OnCreateDocumentClicked(object sender, RoutedEventArgs e)
        {
            var selectedName = FillOptionCombo.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(selectedName))
                return;

            var service = new AutoFillService();
            MemoryStream stream = null;
            var model = new AutoFillOptionsModel
            {
                StepValue = StepValueTextBox.Text,
                StopValue = StopValueTextBox.Text,
                Trend = TrendCheckBox.IsChecked ?? false,
                SeriesBy = Enum.TryParse<ExcelSeriesBy>(SeriesByCombo.SelectedItem?.ToString(), out var seriesBy)
                ? seriesBy
                : ExcelSeriesBy.Rows
            };

            if (AutoFillRadio.IsChecked == true)
            {
                var enumVal = (ExcelAutoFillType)Enum.Parse(typeof(ExcelAutoFillType), selectedName);
                model.SelectedAutoFillOption = $"A{(int)enumVal}";
                stream = service.AutoFill(enumVal);
                if (stream != null)
                {
                    Save(stream, "AutoFill");
                }
            }
            else
            {
                var enumVal = (ExcelFillSeries)Enum.Parse(typeof(ExcelFillSeries), selectedName);
                model.SelectedAutoFillOption = $"F{(int)enumVal}";
                stream = service.AutoFill(
                    enumVal, model.SeriesBy, model.StepValue, model.StopValue, model.Trend);
                if (stream != null)
                {
                    Save(stream, "FillSeries");
                }
            }
        }
        async void Save(MemoryStream stream, string filename)
        {
            StorageFile stFile;
            var hwnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")))
            {
                FileSavePicker savePicker = new FileSavePicker();
                {
                    savePicker.DefaultFileExtension = ".xlsx";
                    savePicker.SuggestedFileName = filename;
                    savePicker.FileTypeChoices.Add("Excel Documents", new List<string>() { ".xlsx" });
                }

                WinRT.Interop.InitializeWithWindow.Initialize(savePicker, hwnd);
                stFile = await savePicker.PickSaveFileAsync();
            }
            else
            {
                StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
                stFile = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            }
            if (stFile != null)
            {
                using (IRandomAccessStream zipStream = await stFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    //Write compressed data from memory to file
                    using (Stream outstream = zipStream.AsStreamForWrite())
                    {
                        outstream.SetLength(0);
                        byte[] buffer = stream.ToArray();
                        outstream.Write(buffer, 0, buffer.Length);
                        outstream.Flush();
                    }
                }
                //Creates message dialog box. 
                MessageDialog msgDialog = new("Do you want to view the Document?", "File has been created successfully");
                UICommand yesCmd = new("Yes");
                msgDialog.Commands.Add(yesCmd);
                UICommand noCmd = new("No");
                msgDialog.Commands.Add(noCmd);

                WinRT.Interop.InitializeWithWindow.Initialize(msgDialog, hwnd);

                //Showing a dialog box. 
                IUICommand cmd = await msgDialog.ShowAsync();
                if (cmd.Label == yesCmd.Label)
                {
                    //Launch the saved file. 
                    await Windows.System.Launcher.LaunchFileAsync(stFile);
                }
            }
        }
    }
    internal class DisplayItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
