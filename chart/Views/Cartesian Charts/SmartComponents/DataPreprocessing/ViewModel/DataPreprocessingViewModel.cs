#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Windows.UI;
using Microsoft.UI.Xaml;

namespace Syncfusion.ChartDemos.WinUI
{
    public class DataPreprocessingViewModel : INotifyPropertyChanged , IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<DataPreprocessingModel> RawData { get; set; }

        public ObservableCollection<Brush> PaletteBrushes { get; set; }

        private ObservableCollection<DataPreprocessingModel> cleanData;
        public ObservableCollection<DataPreprocessingModel> CleanedData
        {
            get { return cleanData; }
            set
            {
                cleanData = value;
                OnPropertyChanged(nameof(CleanedData));
            }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }

            set
            {
                isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        private Visibility isVisible;
        public Visibility IsVisible
        {
            get
            {
                return isVisible;
            }

            set
            {
                isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        public DataPreprocessingViewModel()
        {
            IsVisible = Visibility.Collapsed;
            IsBusy = false;

            PaletteBrushes = new ObservableCollection<Brush>()
            {
                 new SolidColorBrush(Color.FromArgb(255, 36, 133, 250)), // #2485FA
                 new SolidColorBrush(Color.FromArgb(255, 204, 74, 224)) // #CC4AE0
            };

            RawData = new ObservableCollection<DataPreprocessingModel>()
            {
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 00, 00, 00), Visitors = 150 },
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 01, 00, 00), Visitors = 160 },
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 02, 00, 00), Visitors = 155 },
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 03, 00, 00), Visitors = double.NaN }, // Missing data
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 04, 00, 00), Visitors = 170 },
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 05, 00, 00), Visitors = 175 },
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 06, 00, 00), Visitors = 145 },
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 07, 00, 00), Visitors = 180 },
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 08, 00, 00), Visitors = double.NaN }, // Missing data
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 09, 00, 00), Visitors = 185 },
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 10, 00, 00), Visitors = 200 },
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 11, 00, 00), Visitors = double.NaN }, // Missing data
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 12, 00, 00), Visitors = 220 },
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 13, 00, 00), Visitors = 230 },
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 14, 00, 00), Visitors = double.NaN }, // Missing data
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 15, 00, 00), Visitors = 250 },
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 16, 00, 00), Visitors = 260 },
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 17, 00, 00), Visitors = 270 },
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 18, 00, 00), Visitors = double.NaN }, // Missing data
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 19, 00, 00), Visitors = 280 },
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 20, 00, 00), Visitors = 250 },
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 21, 00, 00), Visitors = 290 },
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 22, 00, 00), Visitors = 300 },
                new DataPreprocessingModel{ DateTime = new DateTime(2024, 07, 01, 23, 00, 00), Visitors = double.NaN }, // Missing data
            };

            CleanedData = new ObservableCollection<DataPreprocessingModel>();
        }

        internal async Task LoadCleanedDataAsync()
        {
            var service = new DataPreprocessingAIService();
            CleanedData = await service.GetCleanedData(RawData);
            IsBusy = false;
            IsVisible = Visibility.Collapsed;
        }

        public void Dispose()
        {
            if(RawData != null)
                RawData.Clear();

            if(CleanedData != null) 
                CleanedData.Clear();
        }
    }
}
