#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Collections.ObjectModel;
#if WinUI_Desktop
using System.Windows.Input;
#endif

namespace Syncfusion.EditorDemos.WinUI
{
    public class NumberBoxViewModel : NotificationObject
    {
        private string placeholderText = "Enter Fahrenheit value";
        private bool allowNull = true;
        private bool isEditable = true;
        private bool showGroupSeparator = true;
        private NumberBoxUpDownPlacementMode upDownPlacementMode = NumberBoxUpDownPlacementMode.Inline;
        private ObservableCollection<Country> countryCollection = new ObservableCollection<Country>();
        private ObservableCollection<Unit> unitCollection = new ObservableCollection<Unit>();
        private double minimum = -100;
        private double maximum = 1000;
        private double smallChange = 10.0;
        private double largeChange = 100.0;
        private double? celsiusValue = 0.0d;
        private double? kelvinValue = 273.15d;
        private double? rankineValue = 491.67d;
        private double? fahrenheitValue = 32.0d;
        private int minimumIntegerDigits = 5;
        private int minimumFractionDigits = 2;
        private int maximumFractionDigits = 3;
        private string selectedUnitValue = "cm";
        private string customFormat;

        #region Getting Started
        public string PlaceholderText
        {
            get
            {
                return placeholderText;
            }
            set
            {
                placeholderText = value;
                this.RaisePropertyChanged(nameof(this.PlaceholderText));
            }
        }

        public double? CelsiusValue
        {
            get
            {
                return celsiusValue;
            }
            set
            {
                celsiusValue = value;
                this.RaisePropertyChanged(nameof(this.CelsiusValue));
            }
        }

        public double? KelvinValue
        {
            get
            {
                return kelvinValue;
            }
            set
            {
                kelvinValue = value;
                this.RaisePropertyChanged(nameof(this.KelvinValue));
            }
        }

        public double? RankineValue
        {
            get
            {
                return rankineValue;
            }
            set
            {
                rankineValue = value;
                this.RaisePropertyChanged(nameof(this.RankineValue));
            }
        }

        public double? FahrenheitValue
        {
            get
            {
                return fahrenheitValue;
            }
            set
            {
                fahrenheitValue = value;
                this.RaisePropertyChanged(nameof(this.FahrenheitValue));
            }
        }

        public bool AllowNull
        {
            get
            {
                return allowNull;
            }
            set
            {
                allowNull = value;
                this.RaisePropertyChanged(nameof(this.AllowNull));
            }
        }

        public bool IsEditable
        {
            get
            {
                return isEditable;
            }
            set
            {
                isEditable = value;
                this.RaisePropertyChanged(nameof(this.IsEditable));
            }
        }

        public double Minimum
        {
            get
            {
                return minimum;
            }
            set
            {
                minimum = value;
                this.RaisePropertyChanged(nameof(this.Minimum));
            }
        }

        public double Maximum
        {
            get
            {
                return maximum;
            }
            set
            {
                maximum = value;
                this.RaisePropertyChanged(nameof(this.Maximum));
            }
        }

        public double SmallChange
        {
            get
            {
                return smallChange;
            }
            set
            {
                smallChange = value;
                this.RaisePropertyChanged(nameof(this.SmallChange));
            }
        }

        public double LargeChange
        {
            get
            {
                return largeChange;
            }
            set
            {
                largeChange = value;
                this.RaisePropertyChanged(nameof(this.LargeChange));
            }
        }

        public NumberBoxUpDownPlacementMode UpDownPlacementMode
        {
            get
            {
                return upDownPlacementMode;
            }
            set
            {
                upDownPlacementMode = value;
                this.RaisePropertyChanged(nameof(this.UpDownPlacementMode));
            }
        }
        #endregion

        #region Formatting

        public ObservableCollection<Unit> UnitCollection
        {
            get
            {
                return unitCollection;
            }
            set
            {
                unitCollection = value;
                this.RaisePropertyChanged(nameof(this.UnitCollection));
            }
        }
        public int MinimumIntegerDigits
        {
            get
            {
                return minimumIntegerDigits;
            }
            set
            {
                if (value < 0)
                {
                    minimumIntegerDigits = 0;
                }
                else
                {
                    minimumIntegerDigits = value;
                }
                this.RaisePropertyChanged(nameof(this.MinimumIntegerDigits));
            }
        }

        public int MinimumFractionDigits
        {
            get
            {
                return minimumFractionDigits;
            }
            set
            {
                if (value < 0)
                {
                    minimumFractionDigits = 0;
                }
                else
                {
                    minimumFractionDigits = value;
                }
                this.RaisePropertyChanged(nameof(this.MinimumFractionDigits));
            }
        }

        public int MaximumFractionDigits
        {
            get
            {
                return maximumFractionDigits;
            }
            set
            {
                if (value < 0)
                {
                    maximumFractionDigits = 0;
                }
                else
                {
                    maximumFractionDigits = value;
                }
                this.RaisePropertyChanged(nameof(this.MaximumFractionDigits));
            }
        }

        public bool ShowGroupSeparator
        {
            get
            {
                return showGroupSeparator;
            }
            set
            {
                showGroupSeparator = value;
                this.RaisePropertyChanged(nameof(this.ShowGroupSeparator));
            }
        }

        public string SelectedUnitValue
        {
            get
            {
                return selectedUnitValue;
            }
            set
            {
                selectedUnitValue = value;
                this.RaisePropertyChanged(nameof(this.SelectedUnitValue));
            }
        }
        public string CustomFormat
        {
            get
            {
                return customFormat;
            }
            set
            {
                customFormat = value;
                this.RaisePropertyChanged(nameof(this.CustomFormat));
            }
        }

        #endregion

        #region Culture

        public ObservableCollection<Country> CountryCollection
        {
            get
            {
                return countryCollection;
            }
            set
            {
                countryCollection = value;
                this.RaisePropertyChanged(nameof(this.CountryCollection));
            }
        }
        #endregion

        public NumberBoxViewModel()
        {
            string path = @"ms-appx:///";
#if Main_SB
            path = @"ms-appx:///Editor/";
#endif
            UnitCollection = new ObservableCollection<Unit>();
            UnitCollection.Add(new Unit() { Name = "Centimetre (cm)", Value = "cm" });
            UnitCollection.Add(new Unit() { Name = "Pound (lb)", Value = "lb" });
            UnitCollection.Add(new Unit() { Name = "Kilobyte (kb)", Value = "kb" });
            UnitCollection.Add(new Unit() { Name = "Litre (ℓ)", Value = "ℓ" });

            CountryCollection = new ObservableCollection<Country>();
            CountryCollection.Add(new Country { 
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/UnitedStates.png", UriKind.RelativeOrAbsolute)), 
                Culture = "en-US", 
                Name = "United States" });
            CountryCollection.Add(new Country { 
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/turkey.png", UriKind.RelativeOrAbsolute)), 
                Culture = "tr-TR", 
                Name = "Turkey" });
            CountryCollection.Add(new Country { 
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/Mexico.png", UriKind.RelativeOrAbsolute)),
                Culture = "es-MX", 
                Name = "Mexico" });
            CountryCollection.Add(new Country { 
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/Basque.png", UriKind.RelativeOrAbsolute)), 
                Culture = "eu-ES", 
                Name = "Basque" });
            CountryCollection.Add(new Country { 
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/India.png", UriKind.RelativeOrAbsolute)),
                Culture = "ta-IN", 
                Name = "India" });
            CountryCollection.Add(new Country { 
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/Portugal.png", UriKind.RelativeOrAbsolute)),
                Culture = "pt-PT", 
                Name = "Portugal" });
            CountryCollection.Add(new Country { 
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/UnitedKingdom.png", UriKind.RelativeOrAbsolute)),
                Culture = "en-GB", 
                Name = "United Kingdom" });
            CountryCollection.Add(new Country { 
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/france.png", UriKind.RelativeOrAbsolute)),
                Culture = "fr-FR", 
                Name = "France" });
            CountryCollection.Add(new Country { 
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/china.png", UriKind.RelativeOrAbsolute)),
                Culture = "zh-CN", 
                Name = "China" });
            CountryCollection.Add(new Country { 
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/Russia.png", UriKind.RelativeOrAbsolute)),
                Culture = "ru-RU",
                Name = "Russia" });

            //Initially creating the custom format.
            this.OnCustomFormatStringChanged();
        }

        protected override void RaisePropertyChanged(string propertyName)
        {
            if (propertyName.Equals(nameof(this.FahrenheitValue)))
            {
                this.OnFahrenheitValueChanged();
            }
            else if (propertyName.Equals(nameof(this.MinimumIntegerDigits)) ||
                     propertyName.Equals(nameof(this.MinimumFractionDigits)) ||
                     propertyName.Equals(nameof(this.MaximumFractionDigits)) ||
                     propertyName.Equals(nameof(this.ShowGroupSeparator)) ||
                     propertyName.Equals(nameof(this.SelectedUnitValue)))
            {
                this.OnCustomFormatStringChanged();
            }
            base.RaisePropertyChanged(propertyName);
        }

        #region Getting Started
        /// <summary>
        /// To convert the fahrenheit value to celsius, kelvin and rankine units.
        /// </summary>
        private void OnFahrenheitValueChanged()
        {
            CelsiusValue = (this.fahrenheitValue - 32) * 5 / 9;
            KelvinValue = (this.fahrenheitValue - 32) * 5 / 9 + 273.15;
            RankineValue = this.fahrenheitValue + 459.67;
        }
        #endregion

        #region Formatting
        /// <summary>
        /// To create the custom format string based on the given inputs. 
        /// </summary>
        private void OnCustomFormatStringChanged()
        {
            string minIntegerFormat = "";
            string minFractionFormat = "";
            string maxFractionFormat = "";

            //Adding group seperator in custom format string.
            if (this.ShowGroupSeparator)
            {
                minIntegerFormat = minIntegerFormat.PadRight(minIntegerFormat.Length + 1, '#');
                minIntegerFormat = minIntegerFormat.PadRight(minIntegerFormat.Length + 1, ',');
            }

            //Adding minimum integer digits in custom format string.
            if (this.MinimumIntegerDigits > 0)
            {
                minIntegerFormat = minIntegerFormat.PadRight(minIntegerFormat.Length + this.MinimumIntegerDigits, '0');
            }
            else
            {
                minIntegerFormat = minIntegerFormat.PadRight(minIntegerFormat.Length + 1, '#');
            }

            //Adding minimum and maximum fraction digits in custom format string.
            minFractionFormat = minFractionFormat.PadRight(this.MinimumFractionDigits, '0');
            maxFractionFormat = maxFractionFormat.PadRight(Math.Abs(this.MaximumFractionDigits - this.MinimumFractionDigits), '#');

            //Creating the custom format string
            string customFormat = string.Format("{0}.{1}{2} {3}",
                minIntegerFormat,
                minFractionFormat,
                maxFractionFormat,
                this.SelectedUnitValue
                );

            //Assigning created custom format string to CustomFormat property.
            this.CustomFormat = customFormat;
        }
        #endregion
    }
}