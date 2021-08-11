#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Globalization;
using System.Threading;
using Windows.Globalization;
using Windows.Globalization.NumberFormatting;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace syncfusion.editordemos.winui.Views.NumberBox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CultureView : Page
    {
        //Culture variable that will be applied to the application.
        CultureInfo ci;

        //Culture variable that will hold the default culture of application.
        CultureInfo defaultCulture;
        public CultureView()
        {
            this.InitializeComponent();
            this.Loaded += OnCultureViewLoaded;
            this.Unloaded += OnCultureViewUnloaded;
            this.cultureComboBox.SelectionChanged += this.OnCultureSelectionChanged;
        }

        /// <summary>
        /// To get the default application culture.
        /// </summary>
        private void OnCultureViewLoaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            defaultCulture = Thread.CurrentThread.CurrentUICulture;
        }

        /// <summary>
        /// Occurs when culture option is changed.
        /// </summary>
        private void OnCultureSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (cultureComboBox != null && cultureComboBox.SelectedValue != null)
            {
                //Setting selected culture to the application.
                ci = new CultureInfo(cultureComboBox.SelectedValue.ToString());
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;


                //Setting minimum and maximum fraction digits
                int minDecimalDigit = 2;
                double maxDecimalDigit = 0.01;

                //Getting currency code for Currency NumberBox.
                string currencyCode = new RegionInfo(ci.LCID).ISOCurrencySymbol;

                //To perform format operation for deciaml, currency, and percent values.
                this.OnDecimalFormatValueChanged(minDecimalDigit, maxDecimalDigit);
                this.OnCurrencyFormatValueChanged(currencyCode, minDecimalDigit, maxDecimalDigit);
                this.OnPercentFormatValueChanged(minDecimalDigit, maxDecimalDigit);
            }
        }

        /// <summary>
        /// To reload the default application culture.
        /// </summary>
        private void OnCultureViewUnloaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = defaultCulture;
            Thread.CurrentThread.CurrentUICulture = defaultCulture;
        }

        /// <summary>
        /// To format the NumberBox to allows the decimal value.
        /// </summary>
        /// <param name="fractiondigits">Minimum fraction digits for Decimal NumberBox.</param>
        /// <param name="increment">Maximum fraction digits for Decimal NumberBox.</param>
        /// <param name="customFormat">CustomFormat for CustomFormat Decimal NumberBox.</param>
        private void OnDecimalFormatValueChanged(int fractiondigits, double increment)
        {
            decimalNumberBox.NumberFormatter = new DecimalFormatter(new[] { ci.Name }, "ZZ")
            {
                FractionDigits = fractiondigits,
                NumberRounder = new IncrementNumberRounder
                {
                    Increment = increment
                }
            };
        }

        /// <summary>
        /// To format the NumberBox to allows the currency value.
        /// </summary>
        /// <param name="currencyIdentifiers">Culture format for Currency NumberBox.</param>
        /// <param name="fractiondigits">Minimum fraction digits for Currency NumberBox.</param>
        /// <param name="increment">Maximum fraction digits for Currency NumberBox.</param>
        /// <param name="customFormat">CustomFormat for CustomFormat Currency NumberBox.</param>
        private void OnCurrencyFormatValueChanged(string currencyIdentifiers, int fractiondigits, double increment)
        {
            currencyNumberBox.NumberFormatter = new CurrencyFormatter(
                     currencyIdentifiers,
                     new string[] { ci.Name },
                     "ZZ")
            {
                FractionDigits = fractiondigits,
                NumberRounder = new IncrementNumberRounder
                {
                    Increment = increment
                }
            };
        }

        /// <summary>
        /// To format the NumberBox to allows the percent value.
        /// </summary>
        /// <param name="fractiondigits">Minimum fraction digits for Percent NumberBox.</param>
        /// <param name="increment">Maximum fraction digits for Percent NumberBox.</param>
        /// <param name="customFormat">CustomFormat for CustomFormat Percent NumberBox.</param>
        private void OnPercentFormatValueChanged(int fractiondigits, double increment)
        {
            percentNumberBox.NumberFormatter = new PercentFormatter(new[] { ci.Name }, "ZZ")
            {
                FractionDigits = fractiondigits,
                NumberRounder = new IncrementNumberRounder
                {
                    Increment = increment / 100
                }
            };
        }
    }
}