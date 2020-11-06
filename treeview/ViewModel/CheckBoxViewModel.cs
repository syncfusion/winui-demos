#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace syncfusion.treeviewdemos.winui
{
    /// <summary>
    /// Represents the < see cref="CheckBoxView"/ > class that contains the collection of items used to populate the <see cref="Syncfusion.UI.Xaml.TreeView"/>.
    /// </summary>
    public class CheckBoxView : NotificationObject
    {
        #region Properties
        /// <summary>
        /// Gets or Sets the collection for CheckedItems.
        /// </summary>
        public ObservableCollection<object> CheckedItems { get; internal set; }

        /// <summary>
        /// Gets or Sets the collection for Items.
        /// </summary>
        public ObservableCollection<CheckBoxModel> Items { get; internal set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBoxView"/> class.
        /// </summary>
        public CheckBoxView()
        {
            Items = new ObservableCollection<CheckBoxModel>();

            var country1 = new CheckBoxModel { State = "Australia" };
            var country2 = new CheckBoxModel { State = "Brazil" };
            var country3 = new CheckBoxModel { State = "China" };
            var country4 = new CheckBoxModel { State = "France" };
            var country5 = new CheckBoxModel { State = "India" };
            var country6 = new CheckBoxModel { State = "USA" };
            var country7 = new CheckBoxModel { State = "UK" };
            var country8 = new CheckBoxModel { State = "Russia" };
            var country9 = new CheckBoxModel { State = "Canada" };
            var country10 = new CheckBoxModel { State = "Germany" };

            var aus_state1 = new CheckBoxModel { State = "New South Wales" };
            var aus_state2 = new CheckBoxModel { State = "Victoria" };
            var aus_state3 = new CheckBoxModel { State = "South Australia" };
            var aus_state4 = new CheckBoxModel { State = "Western Australia" };

            var brazil_state1 = new CheckBoxModel { State = "Parana" };
            var brazil_state2 = new CheckBoxModel { State = "Ceara" };
            var brazil_state3 = new CheckBoxModel { State = "Acre" };

            var china_state1 = new CheckBoxModel { State = "Guangzhou" };
            var china_state2 = new CheckBoxModel { State = "Shanghai" };
            var china_state3 = new CheckBoxModel { State = "Beijing" };
            var china_state4 = new CheckBoxModel { State = "Shantou" };

            var france_state1 = new CheckBoxModel { State = "Pays de la Loire" };
            var france_state2 = new CheckBoxModel { State = "Aquitaine" };
            var france_state3 = new CheckBoxModel { State = "Brittany" };
            var france_state4 = new CheckBoxModel { State = "Lorraine" };

            var ind_State1 = new CheckBoxModel { State = "Assam" };
            var ind_State2 = new CheckBoxModel { State = "Bihar" };
            var ind_State3 = new CheckBoxModel { State = "Tamil Nadu" };
            var ind_State4 = new CheckBoxModel { State = "Punjab" };

            var usa_state1 = new CheckBoxModel { State = "New York" };
            var usa_state2 = new CheckBoxModel { State = "California" };
            var usa_state3 = new CheckBoxModel { State = "Texas" };
            var usa_state4 = new CheckBoxModel { State = "Washington" };
            var usa_state5 = new CheckBoxModel { State = "Florida" };

            var uk_state1 = new CheckBoxModel { State = "England" };
            var uk_state2 = new CheckBoxModel { State = "Wales" };
            var uk_state3 = new CheckBoxModel { State = "Scotland" };
            var uk_state4 = new CheckBoxModel { State = "Northern Ireland" };

            var russia_state1 = new CheckBoxModel { State = "Mordovia" };
            var russia_state2 = new CheckBoxModel { State = "Chechnya" };
            var russia_state3 = new CheckBoxModel { State = "Tatarstan" };
            var russia_state4 = new CheckBoxModel { State = "Dagestan" };

            var canada_state1 = new CheckBoxModel { State = "Alberta" };
            var canada_state2 = new CheckBoxModel { State = "Manitoba" };
            var canada_state3 = new CheckBoxModel { State = "New Brunswick" };
            var canada_state4 = new CheckBoxModel { State = "Quebec" };

            var germany_state1 = new CheckBoxModel { State = "Berlin" };
            var germany_state2 = new CheckBoxModel { State = "Hamburg" };
            var germany_state3 = new CheckBoxModel { State = "Bremen" };
            var germany_state4 = new CheckBoxModel { State = "Lower Saxony" };

            country1.Models.Add(aus_state1);
            country1.Models.Add(aus_state2);
            country1.Models.Add(aus_state3);
            country1.Models.Add(aus_state4);

            country2.Models.Add(brazil_state1);
            country2.Models.Add(brazil_state2);
            country2.Models.Add(brazil_state3);

            country3.Models.Add(china_state1);
            country3.Models.Add(china_state2);
            country3.Models.Add(china_state3);
            country3.Models.Add(china_state4);

            country4.Models.Add(france_state1);
            country4.Models.Add(france_state2);
            country4.Models.Add(france_state3);
            country4.Models.Add(france_state4);

            country5.Models.Add(ind_State1);
            country5.Models.Add(ind_State2);
            country5.Models.Add(ind_State3);
            country5.Models.Add(ind_State4);

            country6.Models.Add(usa_state1);
            country6.Models.Add(usa_state2);
            country6.Models.Add(usa_state3);
            country6.Models.Add(usa_state4);
            country6.Models.Add(usa_state5);

            country7.Models.Add(uk_state1);
            country7.Models.Add(uk_state2);
            country7.Models.Add(uk_state3);
            country7.Models.Add(uk_state4);

            country8.Models.Add(russia_state1);
            country8.Models.Add(russia_state2);
            country8.Models.Add(russia_state3);
            country8.Models.Add(russia_state4);

            country9.Models.Add(canada_state1);
            country9.Models.Add(canada_state2);
            country9.Models.Add(canada_state3);
            country9.Models.Add(canada_state4);

            country10.Models.Add(germany_state1);
            country10.Models.Add(germany_state2);
            country10.Models.Add(germany_state3);
            country10.Models.Add(germany_state4);

            Items.Add(country1);
            Items.Add(country2);
            Items.Add(country3);
            Items.Add(country4);
            Items.Add(country5);
            Items.Add(country6);
            Items.Add(country7);
            Items.Add(country8);
            Items.Add(country9);
            Items.Add(country10);

            CheckedItems = new ObservableCollection<object>();
            CheckedItems.Add(aus_state3);
            CheckedItems.Add(aus_state4);
            CheckedItems.Add(brazil_state2);
            CheckedItems.Add(brazil_state3);
            CheckedItems.Add(china_state3);
        }
        #endregion
    }

    /// <summary>
    /// Represents the < see cref="NullableTreeCheckbox"/ > class that maintains the checked states.
    /// </summary>
    public class NullableTreeCheckbox : DependencyObject
    {
        /// <summary>
        /// Identifies the <see cref="IsEnabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(NullableTreeCheckbox), new PropertyMetadata(false, OnIsEnabledChanged));

        /// <summary>
        /// Identifies the <see cref="IsChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.RegisterAttached("IsChecked", typeof(object),
            typeof(NullableTreeCheckbox), new PropertyMetadata(default(object), IsCheckedChanged));

        /// <summary>
        /// Identifies the <see cref="IsInternalChecked"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty IsInternalCheckedProperty =
            DependencyProperty.RegisterAttached("IsInternalChecked", typeof(object),
            typeof(NullableTreeCheckbox), new PropertyMetadata(null, OnIsInternalCheckedChanged));

        /// <summary>
        /// Returns a boolean value whether the NullableTreeCheckbox is Enabled or not.
        /// </summary>
        /// <param name="obj">The Source of the event.</param>
        /// <returns>Returns the boolean value.</returns>
        public static bool GetIsEnabled(DependencyObject obj)
        {
            if (obj == null)
                return false;

            return (bool)obj.GetValue(IsEnabledProperty);
        }

        /// <summary>
        /// Sets the NullableTreeCheckbox IsEnabled property based on the new value.
        /// </summary>
        /// <param name="obj">The Source of the event.</param>
        /// <param name="value">Represents the new value.</param>
        public static void SetIsEnabled(DependencyObject obj, bool value)
        {
            if (obj == null)
                return;
            obj.SetValue(IsEnabledProperty, value); 
        }

        /// <summary>
        /// Returns a boolean value whether the NullableTreeCheckbox is checked or not.
        /// </summary>
        /// <param name="obj">The Source of the event.</param>
        /// <returns>Returns the boolean value.</returns>
        public static object GetIsChecked(DependencyObject obj)
        {
            if (obj == null)
                return false;

            return (bool?)obj.GetValue(IsCheckedProperty);
        }

        /// <summary>
        /// Sets the NullableTreeCheckbox IsChecked property based on the new value.
        /// </summary>
        /// <param name="obj">The Source of the event.</param>
        /// <param name="value">Represents the new value.</param>
        public static void SetIsChecked(DependencyObject obj, object value)
        {
            if (obj == null)
                return;

            obj.SetValue(IsCheckedProperty, value);
        }

        /// <summary>
        /// Occurs when <see cref="IsInternalChecked"/> property is changed.
        /// </summary>
        /// <param name="d">The Source of the event.</param>
        /// <param name="e">Contains all information about the event.</param>
        private static void OnIsInternalCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SetIsChecked(d, (bool?)e.NewValue);
        }

        /// <summary>
        /// Occurs when <see cref="IsEnabled"/> property is changed.
        /// </summary>
        /// <param name="d">The Source of the event.</param>
        /// <param name="e">Contains all information about the event.</param>
        private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var checkbox = d as Microsoft.UI.Xaml.Controls.CheckBox;
            if ((bool)e.NewValue)
            {
                var binding = new Binding
                {
                    Path = new PropertyPath("IsChecked"),
                    Mode = BindingMode.TwoWay,
                    Source = checkbox,
                };
                checkbox.SetBinding(NullableTreeCheckbox.IsInternalCheckedProperty, binding);
            }
        }

        /// <summary>
        /// Occurs when <see cref="IsChecked"/> property is changed.
        /// </summary>
        /// <param name="d">The Source of the event.</param>
        /// <param name="e">Contains all information about the event.</param>
        private static void IsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var checkbox = d as Microsoft.UI.Xaml.Controls.CheckBox;
            bool? newValue = null;
            if (e.NewValue is bool?)
                newValue = (bool?)e.NewValue;
            else if (e.NewValue != null)
                newValue = (bool)e.NewValue;
            if (!checkbox.IsChecked.Equals(newValue))
                checkbox.IsChecked = newValue;
        }
    }
}
