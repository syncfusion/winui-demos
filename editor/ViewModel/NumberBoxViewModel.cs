#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using System.Windows.Input;

namespace Syncfusion.EditorDemos.WinUI
{
    /// <summary>
    /// ViewModel for demonstrating the NumberBox control. It manages properties related to NumberBox behavior such as placeholder text, editability, value limits,
    /// formatting options (integer/fraction digits, group separators, custom formats), culture-specific data (countries with flags), and unit selections.
    /// This class inherits from <see cref="NotificationObject"/> to support property change notifications.
    /// </summary>
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
        /// <summary>
        /// Gets or sets the placeholder text displayed in the NumberBox when no value is entered.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the temperature value in Celsius. Changing this value updates other temperature scales.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the temperature value in Kelvin.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the temperature value in Rankine.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the temperature value in Fahrenheit. Changing this value triggers updates for other temperature scales.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether the NumberBox allows null values.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether the NumberBox is editable by the user.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the minimum allowed value for the NumberBox.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the maximum allowed value for the NumberBox.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the small change value used for incrementing/decrementing in the NumberBox's up-down buttons.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the large change value used for incrementing/decrementing in the NumberBox's up-down buttons (e.g., using PageUp/PageDown keys).
        /// </summary>
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

        /// <summary>
        /// Gets or sets the placement mode for the up-down buttons (spin buttons) of the NumberBox.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the collection of available units for formatting (e.g., cm, lb, kb).
        /// </summary>
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
        /// <summary>
        /// Gets or sets the minimum number of integer digits to display.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the minimum number of fraction digits to display.
        /// </summary>
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
        /// <summary>
        /// Gets or sets the maximum number of fraction digits to display.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether to show the group separator (e.g., comma for thousands).
        /// </summary>
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

        /// <summary>
        /// Gets or sets the selected unit value (e.g., "cm", "lb").
        /// </summary>
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
        /// <summary>
        /// Gets or sets a custom format string for the NumberBox.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the collection of country data, used for culture-specific formatting demos.
        /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberBoxViewModel"/> class. Sets up sample data for units, countries with flags, and initializes formatting properties.
        /// </summary>
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

        /// <summary>
        /// Overrides the default RaisePropertyChanged to potentially perform additional actions based on the property changed. Specifically handles changes to FahrenheitValue for temperature conversions and formatting properties.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
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