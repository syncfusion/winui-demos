#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Profile;
using Windows.UI;
using Windows.UI.Core;
using Colors = Microsoft.UI.Colors;

namespace Syncfusion.ChartDemos.WinUI
{
    public class LoadDetailViewModel
    {
        public ObservableCollection<LoadDetail> LoadDetails { get; }
        public LoadDetailViewModel()
        {
            LoadDetails = new ObservableCollection<LoadDetail>();
            GenerateData();
        }

        private void GenerateData()
        {           
            var randam = new Random();
            var value = 70d;
            var date = new DateTime(2015, 4, 1);

            for (int i = 1; i < 500; i++)
            {
                if (randam.NextDouble() > 0.5)
                {
                    value += randam.NextDouble();
                }
                else
                {
                    value -= randam.NextDouble();
                }

                var commidity = new LoadDetail() { Load = value, Date = date.AddDays(i) };
                LoadDetails.Add(commidity);
            }
        }
    }



    public class StackedDoughnutModel
    {
        public string XValue
        {
            get;
            set;
        }

        public double YValue
        {
            get;
            set;
        }

        public Uri Image
        {
            get;
            set;
        }

        public StackedDoughnutModel(string xValue, double yValue, Uri image)
        {
            XValue = xValue;
            YValue = yValue;
            Image = image;
        }
    }

    public class CircularChartViewModel 
    {
        public CircularChartViewModel()
        {
            DoughnutSeriesData = new ObservableCollection<StackedDoughnutModel>
            {
                new StackedDoughnutModel("Vehicle", 62.7, new Uri("ms-appx:///Chart/Tutorials/ChartSamples/PieChart/Images/Car.png", UriKind.RelativeOrAbsolute)),
                new StackedDoughnutModel("Education",29.5, new Uri("ms-appx:///Chart/Tutorials/ChartSamples/PieChart/Images/Chart_Book.png", UriKind.RelativeOrAbsolute)),
                new StackedDoughnutModel("Home", 85.2, new Uri("ms-appx:///Chart/Tutorials/ChartSamples/PieChart/Images/House.png", UriKind.RelativeOrAbsolute)),
                new StackedDoughnutModel("Personal", 45.6, new Uri("ms-appx:///Chart/Tutorials/ChartSamples/PieChart/Images/Personal.png", UriKind.RelativeOrAbsolute))
            };

            this.CountryDetails = new List<Populations>();
            CountryDetails.Add(new Populations() { Countries = "Uruguay", Count = 2807 });
            CountryDetails.Add(new Populations() { Countries = "Argentina", Count = 2577 });
            CountryDetails.Add(new Populations() { Countries = "USA", Count = 2473 });
            CountryDetails.Add(new Populations() { Countries = "Germany", Count = 2120 });
            CountryDetails.Add(new Populations() { Countries = "Netherlands", Count = 2071 });
            CountryDetails.Add(new Populations() { Countries = "Malta", Count = 960 });
            

            CompanyDetails = new List<CompanyDetail>();
            CompanyDetails.Add(new CompanyDetail() { CompanyName = "Rolls Royce", CompanyTurnover = 750000 });
            CompanyDetails.Add(new CompanyDetail() { CompanyName = "Benz", CompanyTurnover = 500000 });
            CompanyDetails.Add(new CompanyDetail() { CompanyName = "Audi", CompanyTurnover = 450000 });
            CompanyDetails.Add(new CompanyDetail() { CompanyName = "BMW", CompanyTurnover = 700000 });
            CompanyDetails.Add(new CompanyDetail() { CompanyName = "Mahindra", CompanyTurnover = 350000 });
            CompanyDetails.Add(new CompanyDetail() { CompanyName = "Jaguar", CompanyTurnover = 650000 });

            Metric = new List<Metrics>();
            Metric.Add(new Metrics() { ResponseTime = 43, Utilization = 10 });
            Metric.Add(new Metrics() { ResponseTime = 20, Utilization = 20 });
            Metric.Add(new Metrics() { ResponseTime = 67, Utilization = 30 });
            Metric.Add(new Metrics() { ResponseTime = 52, Utilization = 40 });
            Metric.Add(new Metrics() { ResponseTime = 71, Utilization = 50 });
            Metric.Add(new Metrics() { ResponseTime = 30, Utilization = 60 });

            this.Population = new List<Populations>();
            Population.Add(new Populations() { Continent = "Asia", Countries = "China", States = "Taiwan", PopulationinContinents = 50.02, PopulationinCountries = 26.02, PopulationinStates = 18.02 });
            Population.Add(new Populations() { Continent = "Africa", Countries = "India", States = "Shandong", PopulationinContinents = 20.81, PopulationinCountries = 24, PopulationinStates = 8 });
            Population.Add(new Populations() { Continent = "Europe", Countries = "Nigeria", States = "UP", PopulationinContinents = 15.37, PopulationinCountries = 12.81, PopulationinStates = 14.5 });
            Population.Add(new Populations() { Countries = "Ethiopia", States = "Bihar", PopulationinCountries = 8, PopulationinStates = 9.5 });
            Population.Add(new Populations() { Countries = "Germany", States = "Kano", PopulationinCountries = 8.37, PopulationinStates = 7.81 });
            Population.Add(new Populations() { Countries = "Turkey", States = "Lagos", PopulationinCountries = 7, PopulationinStates = 5 });
            Population.Add(new Populations() { States = "Oromia", PopulationinStates = 5 });
            Population.Add(new Populations() { States = "Amhara", PopulationinStates = 3 });
            Population.Add(new Populations() { States = "Hessen", PopulationinStates = 5.37 });
            Population.Add(new Populations() { States = "Bayern", PopulationinStates = 3 });
            Population.Add(new Populations() { States = "Mugla", PopulationinStates = 4.5 });
            Population.Add(new Populations() { States = "Ankara", PopulationinStates = 2.5 });

            CustomBrush1 = new List<Brush>();
            CustomBrush2 = new List<Brush>();
            CustomBrush3 = new List<Brush>();

            IList<Brush> chartColorModel = Resources.ColorModelResource.Resource["CustomBrushes"] as IList<Brush>;
            SolidColorBrush interior1 = chartColorModel[0] as SolidColorBrush;
            SolidColorBrush interior2 = chartColorModel[1] as SolidColorBrush;
            SolidColorBrush interior3 = chartColorModel[2] as SolidColorBrush;

            CustomBrush1.Add(interior1);
            CustomBrush1.Add(interior2);
            CustomBrush1.Add(interior3);

            CustomBrush2.Add(interior1);
            CustomBrush2.Add(interior1);
            CustomBrush2.Add(interior2);
            CustomBrush2.Add(interior2);
            CustomBrush2.Add(interior3);
            CustomBrush2.Add(interior3);

            CustomBrush3.Add(interior1);
            CustomBrush3.Add(interior1);
            CustomBrush3.Add(interior1);
            CustomBrush3.Add(interior1);
            CustomBrush3.Add(interior2);
            CustomBrush3.Add(interior2);
            CustomBrush3.Add(interior2);
            CustomBrush3.Add(interior2);
            CustomBrush3.Add(interior3);
            CustomBrush3.Add(interior3);
            CustomBrush3.Add(interior3);
            CustomBrush3.Add(interior3);

        }

        public List<Brush> CustomBrush1 { get; set; }

        public List<Brush> CustomBrush2 { get; set; }

        public List<Brush> CustomBrush3 { get; set; }

        public IList<CompanyDetail> CompanyDetails
        {
            get;
        }

        public IList<Metrics> Metric
        {
            get;
        }

        public IList<Populations> Population
        {
            get;
        }

        public IList<Populations> CountryDetails { get;  }

        public IList<StackedDoughnutModel> DoughnutSeriesData { get;  }
        
    }  
    
    public class PaletteViewModel 
    {
        public ObservableCollection<PaletteModel> FacebookStatistics
        {
            get;
        }
        public ObservableCollection<PaletteModel> ActiveUsers
        {
            get;
        }
        public ObservableCollection<PaletteModel> RegisteredUsers
        {
            get;
        }
        public ObservableCollection<PaletteModel> Users
        {
            get;
        }

        public PaletteViewModel()
        {
            //PieSeries
            this.FacebookStatistics = new ObservableCollection<PaletteModel>();
            FacebookStatistics.Add(new PaletteModel { Country = "Finland", UsersCount = 12.68 });
            FacebookStatistics.Add(new PaletteModel { Country = "Germany", UsersCount = 10.59 });
            FacebookStatistics.Add(new PaletteModel { Country = "Poland", UsersCount = 11.16 });
            FacebookStatistics.Add(new PaletteModel { Country = "France", UsersCount = 10.48 });
            FacebookStatistics.Add(new PaletteModel { Country = "Australia", UsersCount = 10.13 });
            FacebookStatistics.Add(new PaletteModel { Country = "Brazil", UsersCount = 7.99 });
            if (AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile")
            {
                FacebookStatistics.Add(new PaletteModel { Country = "Russia", UsersCount = 6.25 });
                FacebookStatistics.Add(new PaletteModel { Country = "Israel", UsersCount = 10.50 });
            }

            //Active User in Year of 2012,2014,2015
            this.Users = new ObservableCollection<PaletteModel>();
            Users.Add(new PaletteModel { SocialSite = "Facebook", Year2012 = 788, Year2014 = 1240, Year2015 = 1550 });
            Users.Add(new PaletteModel { SocialSite = "QZone", Year2012 = 310, Year2014 = 632, Year2015 = 900 });
            Users.Add(new PaletteModel { SocialSite = "Google+", Year2012 = 500, Year2014 = 743, Year2015 = 890 });
            Users.Add(new PaletteModel { SocialSite = "Twitter", Year2012 = 250, Year2014 = 540, Year2015 = 784 });
            Users.Add(new PaletteModel { SocialSite = "Skype", Year2012 = 120, Year2014 = 300, Year2015 = 520 });
            Users.Add(new PaletteModel { SocialSite = "WeChat", Year2012 = 180, Year2014 = 390, Year2015 = 550 });
            Users.Add(new PaletteModel { SocialSite = "Instagram", Year2012 = 120, Year2014 = 250, Year2015 = 850 });
            Users.Add(new PaletteModel { SocialSite = "WhatsApp", Year2012 = 100, Year2014 = 300, Year2015 = 300 });

            //Active Users
            this.ActiveUsers = new ObservableCollection<PaletteModel>();
            ActiveUsers.Add(new PaletteModel { SocialSite = "Twitter", UsersCount = 302 });
            ActiveUsers.Add(new PaletteModel { SocialSite = "Skype", UsersCount = 300 });
            ActiveUsers.Add(new PaletteModel { SocialSite = "WeChat", UsersCount = 559 });
            if (AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile")
            {
                ActiveUsers.Add(new PaletteModel { SocialSite = "Google+", UsersCount = 650 });
                ActiveUsers.Add(new PaletteModel { SocialSite = "WhatsApp", UsersCount = 800 });
            }
            ActiveUsers.Add(new PaletteModel { SocialSite = "Facebook", UsersCount = 1184 });

            // Registered users
            this.RegisteredUsers = new ObservableCollection<PaletteModel>();
            RegisteredUsers.Add(new PaletteModel { SocialSite = "Twitter", UsersCount = 500 });
            RegisteredUsers.Add(new PaletteModel { SocialSite = "Skype", UsersCount = 663 });
            RegisteredUsers.Add(new PaletteModel { SocialSite = "WeChat", UsersCount = 1120 });
            if (AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile")
            {
                RegisteredUsers.Add(new PaletteModel { SocialSite = "Google+", UsersCount = 540 });
                RegisteredUsers.Add(new PaletteModel { SocialSite = "WhatsApp", UsersCount = 920 });
            }
            RegisteredUsers.Add(new PaletteModel { SocialSite = "Facebook", UsersCount = 1600 });

            List<Brush> PaletteBrushes1 = new List<Brush>()
            {
                new SolidColorBrush(Color.FromArgb(255, 0, 127, 0)),
                new SolidColorBrush(Color.FromArgb(255, 227, 35, 111)),
                new SolidColorBrush(Color.FromArgb(255, 177, 70, 194)),
                new SolidColorBrush(Color.FromArgb(255, 226, 24, 47)),
                new SolidColorBrush(Color.FromArgb(255, 250, 153, 1)),
                new SolidColorBrush(Color.FromArgb(255, 255, 185, 0)),
                new SolidColorBrush(Color.FromArgb(255, 14, 0, 230)),
                new SolidColorBrush(Color.FromArgb(255, 122, 117, 116)),
                new SolidColorBrush(Color.FromArgb(255, 0, 120, 222)),
                new SolidColorBrush(Color.FromArgb(255, 0, 204, 106)),
            };

            List<Brush> PaletteBrushes2 = new List<Brush>()
            {
                new SolidColorBrush(Color.FromArgb(255, 122, 117, 116)),
                new SolidColorBrush(Color.FromArgb(255, 0, 120, 222)),
                new SolidColorBrush(Color.FromArgb(255, 0, 204, 106)),
                new SolidColorBrush(Color.FromArgb(255, 250, 153, 1)),
                new SolidColorBrush(Color.FromArgb(255, 255, 185, 0)),
                new SolidColorBrush(Color.FromArgb(255, 226, 24, 47)),
                new SolidColorBrush(Color.FromArgb(255, 0, 127, 0)),
                new SolidColorBrush(Color.FromArgb(255, 227, 35, 111)),
                new SolidColorBrush(Color.FromArgb(255, 177, 70, 194)),
                new SolidColorBrush(Color.FromArgb(255, 14, 0, 230)),
            };

            List<Brush> PaletteBrushes3 = new List<Brush>()
            {
                new SolidColorBrush(Color.FromArgb(255, 250, 153, 1)),
                new SolidColorBrush(Color.FromArgb(255, 0, 127, 0)),
                new SolidColorBrush(Color.FromArgb(255, 14, 0, 230)),
                new SolidColorBrush(Color.FromArgb(255, 0, 204, 106)),
                new SolidColorBrush(Color.FromArgb(255, 177, 70, 194)),
                new SolidColorBrush(Color.FromArgb(255, 227, 35, 111)),
                new SolidColorBrush(Color.FromArgb(255, 0, 120, 222)),
                new SolidColorBrush(Color.FromArgb(255, 226, 24, 47)),
                new SolidColorBrush(Color.FromArgb(255, 255, 185, 0)),
                new SolidColorBrush(Color.FromArgb(255, 122, 117, 116)),
            };

            this.PaletteCollections = new ObservableCollection<PaletteCollection>()
            {
                new PaletteCollection(){Name="Palette1" , Brushes = PaletteBrushes1},
                new PaletteCollection(){Name="Palette2" , Brushes = PaletteBrushes2},
                new PaletteCollection(){Name="Palette3" , Brushes = PaletteBrushes3},
            };
        }




        public ObservableCollection<PaletteCollection> PaletteCollections { get; set; }
    }
    public class MeasurementDetails : ObservableCollection<Measurement>
    {
        DispatcherTimer timer = new DispatcherTimer();
        DateTime i = DateTime.Now;
        int count;

        public MeasurementDetails()
        {
            Random rand = new Random();
            count = 0;
            DateTime dt = new DateTime(2014, 7, 8, 5, 20, 10);
            for (int i = 11; i < 50; i++)
            {
                dt = dt.AddSeconds(1);
                this.Add(new Measurement { Velocity1 = rand.Next(-3, 3), Time = dt, Velocity2 = rand.Next(-2, 2) });
                dt = dt.AddSeconds(1);
            }

            timer.Interval = TimeSpan.FromMilliseconds(2);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
#if WinUI_Desktop
            OnTick();
#else
#pragma warning disable CA2008 // Specify Task creation
            Task.Factory.StartNew(() => OnTick());
#pragma warning disable CA2008 // Specify Task creation
#endif
        }
        internal void StopTimer()
        {
            timer.Stop();
        }

#if !WinUI_Desktop
        private async void OnTick()
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
#else
        private void OnTick()
#endif
        {
            i = this[this.Count - 1].Time.AddSeconds(1);
            count = count + 1;
            Random rand = new Random();
            if (count > 350)
            {
                timer.Stop();
            }
            else if (count > 300)
            {
                this.Add(new Measurement() { Time = i, Velocity1 = rand.Next(0, 0), Velocity2 = rand.Next(0, 1) });
            }
            else if (count > 250)
            {
                this.Add(new Measurement() { Time = i, Velocity1 = rand.Next(-2, 1), Velocity2 = rand.Next(-2, 2) });
            }
            else if (count > 180)
            {
                this.Add(new Measurement() { Time = i, Velocity1 = rand.Next(-3, 2), Velocity2 = rand.Next(-2, 3) });
            }
            else if (count > 100)
            {
                this.Add(new Measurement() { Time = i, Velocity1 = rand.Next(-7, 6), Velocity2 = rand.Next(-6, 7) });
            }
            else
            {
                this.Add(new Measurement() { Time = i, Velocity1 = rand.Next(-9, 9), Velocity2 = rand.Next(-9, 9) });
            }
        }
#if !WinUI_Desktop
               );
        }
#endif
        
    }

    public class PaletteCollection
    {
        public string Name { get; set; }

        public List<Brush> Brushes { get; set; }
    }

}
