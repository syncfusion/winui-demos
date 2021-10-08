#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ABI.Windows.UI;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace syncfusion.editordemos.winui
{
    /// <summary>
    /// Represents the <see cref="SegmentedViewModel"/> class that contains the collection of items used to populate the <see cref="Syncfusion.UI.Xaml.Editors.SfSegmentedControl"/>.
    /// </summary>
    public class SegmentedViewModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Maintains the object for SelectedItem.
        /// </summary>
        private object selectedbackground;

        /// <summary>
        /// Maintains the object for SelectedItem.
        /// </summary>
        private object selectedItem;

        /// <summary>
        /// Maintains the string value for shirt.
        /// </summary>
        private string selectedShirtModel;

        /// <summary>
        /// Maintains the brush for shirt.
        /// </summary>
        private Brush shirtColor;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentedViewModel"/> class.
        /// </summary>
        public SegmentedViewModel()
        {
            Days = new List<Segment>();
            Days.Add(new Segment() { Name = "Day", Icon = UpdateIcons("Calendar") });
            Days.Add(new Segment() { Name = "Week", Icon = UpdateIcons("Calendar") });
            Days.Add(new Segment() { Name = "Month", Icon = UpdateIcons("Calendar") });
            Days.Add(new Segment() { Name = "Year", Icon = UpdateIcons("Calendar") });
 
            Items = new List<Segment>();
            Items.Add(new Segment() { Name = "Word", Icon = UpdateIcons("Word"), Background = new SolidColorBrush(Microsoft.UI.Colors.Yellow)});
            Items.Add(new Segment() { Name = "PDF", Icon = UpdateIcons("PDF"), Background = new SolidColorBrush(Microsoft.UI.Colors.OrangeRed) });
            Items.Add(new Segment() { Name = "PPT", Icon = UpdateIcons("PPT"), Background = new SolidColorBrush(Microsoft.UI.Colors.Red) });
            Items.Add(new Segment() { Name = "EXE", Icon = UpdateIcons("EXE"), Background = new SolidColorBrush(Microsoft.UI.Colors.DarkGray) });
            Items.Add(new Segment() { Name = "Zip", Icon = UpdateIcons("Zip"), Background = new SolidColorBrush(Microsoft.UI.Colors.DarkOrange) });

            Colors = new List<Segment>();
            Colors.Add(new Segment() { Background = new SolidColorBrush(Microsoft.UI.Colors.LightGreen)});
            Colors.Add(new Segment() { Background = new SolidColorBrush(Microsoft.UI.Colors.Red)});
            Colors.Add(new Segment() { Background = new SolidColorBrush(Microsoft.UI.Colors.OrangeRed)});
            Colors.Add(new Segment() { Background = new SolidColorBrush(Microsoft.UI.Colors.DarkGreen)});
            Colors.Add(new Segment() { Background = new SolidColorBrush(Microsoft.UI.Colors.DarkBlue)});
            Colors.Add(new Segment() { Background = new SolidColorBrush(Microsoft.UI.Colors.Maroon)});
            Colors.Add(new Segment() { Background = new SolidColorBrush(Microsoft.UI.Colors.DeepSkyBlue)});

            Shirts = new List<Segment>();
            Shirts.Add(new Segment() { Name = "Formals" });
            Shirts.Add(new Segment() { Name = "Casuals" });
            Shirts.Add(new Segment() { Name = "Trendy" });

            Sizes = new List<Segment>();
            Sizes.Add(new Segment() { Name = "XS" });
            Sizes.Add(new Segment() { Name = "S" });
            Sizes.Add(new Segment() { Name = "M" });
            Sizes.Add(new Segment() { Name = "L" });
            Sizes.Add(new Segment() { Name = "XL" });
            Sizes.Add(new Segment() { Name = "XXL" });

            SelectedBackground = Colors[2];
            SelectedItem = Shirts[2];
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the collections for Days.
        /// </summary>
        public List<Segment> Days
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the collections for Colors.
        /// </summary>
        public List<Segment> Colors
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the collections for Shirts.
        /// </summary>
        public List<Segment> Shirts
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the collections for Sizes.
        /// </summary>
        public List<Segment> Sizes
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the collections for Items.
        /// </summary>
        public List<Segment> Items
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the SelectedItem for SegmentedControl.
        /// </summary>
        public object SelectedBackground
        {
            get
            {
                return selectedbackground;
            }
            set
            {
                if (selectedbackground != value)
                {
                    selectedbackground = value;
                    if (selectedbackground is Segment)
                        ShirtColor = (selectedbackground as Segment).Background;
                    OnPropertyChanged("SelectedBackground");
                }
            }
        }

        /// <summary>
        /// Gets or sets the shirt color.
        /// </summary>
        public Brush ShirtColor
        {
            get
            {
                return shirtColor;
            }
            set
            {
                if (shirtColor != value)
                {
                    shirtColor = value;
                    OnPropertyChanged("ShirtColor");
                }
            }
        }

        /// <summary>
        /// Gets or sets the SelectedItem for SegmentedControl.
        /// </summary>
        public object SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                    UpdateShirtModels();
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected shirt model.
        /// </summary>
        public string SelectedShirtModel
        {
            get 
            { 
                return selectedShirtModel; 
            }
            set 
            {
                if (selectedShirtModel != value)
                {
                    selectedShirtModel = value;
                    OnPropertyChanged("SelectedShirtModel");
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        /// <summary>
        /// Method used to raise the property changed event.
        /// </summary>
        /// <param name="parameter">Represents the property name.</param>
        private void OnPropertyChanged(string parameter)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(parameter));
        }

        /// <summary>
        /// Method used to update the shirts.
        /// </summary>
        private void UpdateShirtModels()
        {
            if ((SelectedItem as Segment).Name == "Formals")
            {
                SelectedShirtModel = "M8.9130121,0L12.905993,0 15.801013,0 15.999987,0 18.994982,0 22.987963,0C23.286974,6.4811502E-08,23.586962,0.20001219,23.885973,0.39898697L31.671984,9.4829975C32.171008,9.9819905,32.070971,10.781002,31.572009,11.279995L29.775988,12.777003C29.275988,13.275996,28.478015,13.17599,27.978991,12.676997L23.885973,7.8859831 23.885973,23.457999 23.885973,23.558005C23.885973,24.256001,23.286974,24.855,22.588,24.855L19.892993,24.855 19.593981,24.855 19.494006,24.855 16.499011,24.855 16.499011,14.075006 20.892016,6.58801 19.593981,4.9909955 22.088976,4.5920087 18.994982,0.69900501 16.499011,12.277979 15.999987,14.473993 15.500964,12.277979 13.005969,0.69900501 9.8109613,4.4920026 12.306994,4.8909894 11.008959,6.4880039 15.400988,13.975 15.400988,24.655995 12.40697,24.655995 12.306994,24.655995 12.007006,24.655995 9.4119745,24.655995C8.7129999,24.655995,8.1140008,24.056996,8.1140008,23.357993L8.1140008,23.257987 8.1140008,19.564994 8.1140008,7.7860075 4.0219598,12.676997C3.5229974,13.17599,2.8239618,13.275996,2.2249627,12.777003L0.42796574,11.279995C-0.070996724,10.781002,-0.17103334,10.081997,0.32799024,9.4829975L8.1140008,0.39898697C8.314013,0.20001219,8.6140008,6.4811502E-08,8.9130121,0z";
            }
            else if ((SelectedItem as Segment).Name == "Casuals")
            {
                SelectedShirtModel = "M18.799988,11.50001C19.099976,11.50001 19.400024,11.600016 19.599976,11.900003 19.799988,12.100016 19.900024,12.500011 19.900024,12.900004 19.900024,13.299999 19.799988,13.600018 19.599976,13.799999 19.400024,14.000012 19.099976,14.199993 18.799988,14.199993 18.5,14.199993 18.200012,14.100018 18,13.799999 17.799988,13.500012 17.700012,13.199992 17.700012,12.799998 17.700012,12.500011 17.799988,12.199992 18,12.00001 18.099976,11.600016 18.400024,11.50001 18.799988,11.50001z M13.400024,8.9000016C14.200012,8.9000016 14.5,9.7999955 14.5,11.50001 14.5,13.199992 14.099976,14.000012 13.299988,14.000012 12.5,14.000012 12.099976,13.199992 12.099976,11.50001 12.200012,9.7999955 12.599976,8.9000016 13.400024,8.9000016z M19.299988,8.1000128C18.400024,8.1000128 17.700012,8.4000006 17.200012,9.1000138 16.700012,9.7999955 16.400024,10.69999 16.400024,11.900003 16.400024,12.900004 16.599976,13.600018 17,14.100018 17.400024,14.600019 17.900024,14.900006 18.700012,14.900006 19.299988,14.900006 19.900024,14.699994 20.299988,14.299999 20.700012,13.900005 20.900024,13.299999 20.900024,12.699992 20.900024,12.100016 20.700012,11.600016 20.400024,11.199991 20.099976,10.799996 19.599976,10.600015 19.099976,10.600015 18.400024,10.600015 17.900024,10.900003 17.599976,11.400003 17.599976,10.600015 17.799988,10.000009 18.099976,9.6000138 18.400024,9.1000138 18.900024,8.9000016 19.5,8.9000016 19.900024,8.9000016 20.200012,9.0000077 20.5,9.1999894L20.5,8.2999945C20.200012,8.1000128,19.799988,8.1000128,19.299988,8.1000128z M13.400024,8.1000128C12.599976,8.1000128 12.099976,8.4000006 11.599976,9.0000077 11.200012,9.6000138 11,10.500009 11,11.699991 11,12.799998 11.200012,13.600018 11.599976,14.199993 12,14.8 12.5,15.000012 13.200012,15.000012 13.900024,15.000012 14.5,14.699994 14.900024,14.100018 15.299988,13.500012 15.5,12.600017 15.5,11.50001 15.599976,9.1999894 14.900024,8.1000128 13.400024,8.1000128z M2,5.199986L6.2999878,9.6999894 3.7000122,11.400003 0,7.4000002z M30,5.1000105L32,7.2999941 28.200012,11.299997 25.599976,9.6000138z M10.299988,0C11.900024,-6.1045284E-08,12.900024,0.69998223,12.900024,0.69998217L12.900024,1.100007C12.900024,2.6999839 14.299988,4.0000034 16,4.0000034 17.700012,4.0000034 19.200012,2.6999839 19.200012,1.100007 19.200012,0.89999461 19.200012,0.69998223 19.099976,0.50000048L19.299988,0.50000048C24.599976,-1.5000014,28.799988,4.0000034,28.799988,4.0000034L24.299988,8.9000016 24.299988,22.700001 7.5999756,22.700001 7.5999756,8.7999955 3.0999756,4.1999851C5.7999878,0.79998839,8.4000244,-6.1045284E-08,10.299988,0z";
            }
            else
            {
                SelectedShirtModel = "M16,8.6999893L15.099976,11.600016 12.099976,11.600016 14.5,13.400005 13.599976,16.300001 16,14.500012 18.400024,16.300001 17.5,13.400005 19.900024,11.600016 16.900024,11.600016z M2,5.199986L6.2999878,9.6999903 3.7000122,11.400003 0,7.4000001z M30,5.1000104L32,7.299994 28.200012,11.299997 25.599976,9.6000137z M10.299988,0C11.900024,1.3656972E-08,12.900024,0.69998227,12.900024,0.69998215L12.900024,1.100007C12.900024,2.6999841 14.299988,4.0000033 16,4.0000033 17.700012,4.0000033 19.200012,2.6999841 19.200012,1.100007 19.200012,0.89999466 19.200012,0.69998227 19.099976,0.50000046L19.299988,0.50000046C24.599976,-1.5000012,28.799988,4.0000033,28.799988,4.0000033L24.299988,8.9000015 24.299988,22.700001 7.5999756,22.700001 7.5999756,8.7999954 3.0999756,4.199985C5.7999878,0.79998849,8.4000244,1.3656972E-08,10.299988,0z";
            }
        }

        /// <summary>
        /// Method used to update the path data for icon.
        /// </summary>
        /// <param name="name">Represents the string value.</param>
        /// <returns>Returns the path data for icon.</returns>
        private string UpdateIcons(string name)
        {
            if (name == "Calendar")
            {
                return "M16.5,24.500009L19.5,24.500009 19.5,27.50001 16.5,27.50001z M10.5,24.500009L13.5,24.500009 13.5,27.50001 10.5,27.50001z M4.5000002,24.500009L7.5000002,24.500009 7.5000002,27.50001 4.5000002,27.50001z M22.5,19.500009L25.5,19.500009 25.5,22.500009 22.5,22.500009z M16.5,19.500009L19.5,19.500009 19.5,22.500009 16.5,22.500009z M10.5,19.500009L13.5,19.500009 13.5,22.500009 10.5,22.500009z M4.5000002,19.500009L7.5000002,19.500009 7.5000002,22.500009 4.5000002,22.500009z M22.5,14.500009L25.5,14.500009 25.5,17.500009 22.5,17.500009z M16.5,14.500009L19.5,14.500009 19.5,17.500009 16.5,17.500009z M10.5,14.500009L13.5,14.500009 13.5,17.500009 10.5,17.500009z M4.5000002,14.500009L7.5000002,14.500009 7.5000002,17.500009 4.5000002,17.500009z M2.0000001,12.000008L2.0000001,30.00001 28,30.00001 28,12.000008z M2.0000001,5.0000091L2.0000001,10.000007 28,10.000007 28,5.0000091 23.956969,5.0000091 23.956969,6.9310009C23.956969,7.4830005 23.509968,7.9310007 22.956969,7.9310007 22.403969,7.9310007 21.956969,7.4830005 21.956969,6.9310009L21.956969,5.0000091 7.956969,5.0000091 7.956969,6.9310009C7.956969,7.4830005 7.509969,7.9310007 6.956969,7.9310007 6.403969,7.9310007 5.956969,7.4830005 5.956969,6.9310009L5.956969,5.0000091z M6.956969,0C7.509969,0,7.956969,0.44799995,7.956969,1L7.956969,3.0000091 21.956969,3.0000091 21.956969,1C21.956969,0.44799995 22.403969,0 22.956969,0 23.509968,0 23.956969,0.44799995 23.956969,1L23.956969,3.0000091 30,3.0000091 30,32.00001 0,32.00001 0,3.0000091 5.956969,3.0000091 5.956969,1C5.956969,0.44799995,6.403969,0,6.956969,0z";
            }
            else if (name == "Word")
            {
                return "M14.799988,9.800001L12.700012,9.999998 11.400024,17.900005 9.7000122,10.300001 7.7000122,10.300001 6.2000122,17.600002 5.0999756,10.499998 3.4000244,10.499998 5.2000122,20.499996 7.2000122,20.600002 8.7000122,13.499998 10.400024,20.799999 12.5,20.799999z M19.099976,3.4999994L31.599976,3.4999994C31.799988,3.4999994,32,3.7000116,32,3.9000086L32,26.700008C32,26.900005,31.799988,27.100002,31.599976,27.100002L19.099976,27.100002 19.099976,23.999996 29,23.999996 29,22.700008 19.099976,22.700008 19.099976,20.799999 29,20.799999 29,19.499996 19.099976,19.499996 19.099976,17.600002 29,17.600002 29,16.300001 19.099976,16.300001 19.099976,14.400007 29,14.400007 29,12.999998 19.099976,12.999998 19.099976,11.100004 29,11.100004 29,9.800001 19.099976,9.800001 19.099976,7.9000076 29,7.9000076 29,6.600005 19.099976,6.600005z M18.5,0L18.5,30.6 0,27.400005 0,3.1000055z";
            }
            else if (name == "PDF")
            {
                return "M6.2708873,25.179424C4.1949042,25.839416 2.6769034,27.512413 2.1488899,28.156406 2.1548714,28.031406 1.9328871,28.431406 1.9328869,28.431406 1.9328871,28.431406 2.0179089,28.317409 2.1488899,28.156406 2.1468758,28.20541 2.1128792,28.326404 2.0138806,28.588403 1.6579245,29.536396 2.7608875,29.511402 2.7608875,29.511402 5.8899068,29.002403 6.2708873,25.179424 6.2708873,25.179424z M24.193808,21.957441C23.612817,21.957441 23.253808,21.994436 23.253808,21.994436 26.583815,24.909422 29.680793,24.230425 29.680793,24.230425 30.947818,24.060426 29.013802,22.886436 29.013802,22.886436 27.225842,22.093441 25.303851,21.957441 24.193808,21.957441z M12.815851,14.086479C12.815851,14.086479,11.61389,20.34445,10.110903,22.201435L18.443826,20.869442C18.443826,20.869442,14.290883,16.87046,12.815851,14.086479z M13.008843,2.5275399C12.998895,2.5265364 12.987847,2.5275397 12.977898,2.5285394 12.884882,2.5405363 12.788874,2.6505362 12.695856,2.9115369 12.695856,2.9115366 12.246883,5.2215225 13.370842,9.0605037 13.370842,9.0605037 14.328847,6.0145213 13.60784,3.6825325 13.60784,3.6825325 13.32885,2.5585377 13.008843,2.5275399z M11.959896,0.00055218116C12.846857,-0.036450189 13.645865,1.7985433 13.645865,1.798543 16.131881,7.5085132 13.781852,11.156493 13.781852,11.156493 16.242843,17.393461 21.175874,20.724445 21.175874,20.724445 25.969804,20.447447 29.465827,21.749441 29.465827,21.749441 32.216794,23.304434 31.295838,24.757421 31.295838,24.757421 28.412852,28.213405 19.945834,22.823433 19.945834,22.823433L9.031865,24.80042C7.4549045,30.599394 2.1839241,31.962387 2.1839241,31.962387 -0.32809262,32.355383 0.01590053,29.539402 0.015900303,29.539402 1.9768933,24.902425 6.9068717,23.83543 6.9068717,23.83543 8.8498591,21.605438 12.023861,11.122493 12.023861,11.122493 8.8169002,3.375535 11.069884,0.7985484 11.069884,0.79854828 11.358885,0.23254943 11.663876,0.012549346 11.959896,0.00055218116z";
            }
            else if (name == "PPT")
            {
                return "M8.4000244,11.999999L9,11.999999C10.700012,11.999999 10.599976,13.699995 10.599976,13.699995 10.5,15.599989 8.4000244,15.300001 8.4000244,15.300001z M6.7000122,10.300002L6.7000122,20.499998 8.2999878,20.499998 8.2999878,16.999998C8.2999878,16.999998 12.599976,17.699995 12.599976,13.300002 12.599976,13.300002 12.700012,10.300002 10,10.300002z M21.200012,8.999999L21.200012,12.999999 25.200012,12.999999C25.200012,10.800002,23.400024,8.999999,21.200012,8.999999z M19.200012,7.8999929L29.024994,7.8999929C29.024994,7.8999929 29.026556,7.8999929 29.02968,7.8999929 29.032804,7.8999929 29.037491,7.8999929 29.043739,7.8999929 29.049988,7.8999929 29.057798,7.8999929 29.067171,7.8999929 29.076544,7.8999929 29.087479,7.8999929 29.099976,7.8999929 29.200012,7.8999929 29.900024,7.8999929 29.900024,8.8999929L29.900024,23.999998C29.900024,23.999998,30.099976,24.699995,29,24.800001L19.200012,24.800001 19.200012,22.999998 26.400024,22.999998 26.400024,21.699995 19.200012,21.699995 19.200012,20.300001 26.400024,20.300001 26.400024,18.899992 19.200012,18.899992 19.200012,17.399992C19.599976,17.599989 20.099976,17.599989 20.599976,17.599989 22.799988,17.599989 24.599976,15.800001 24.599976,13.599989L20.599976,13.599989 20.599976,9.5999898C20.099976,9.5999898,19.599976,9.6999959,19.200012,9.800002z M19.200012,5.5999903L31.099976,5.5999903C31.900024,5.5999903,32,6.3999933,32,6.3999933L32,20.499998C32,21.199995,31.599976,21.199995,31.599976,21.199995L30.799988,21.199995 30.799988,7.1999964 19.200012,7.1999964z M18.599976,0L18.599976,30.799999 0,27.599987 0,3.0999903z";
            }
            else if (name == "EXE")
            {
                return "M3.3169894,18.909973L3.3169894,20.480957 14.341993,20.480957 14.341993,18.909973z M3.3169894,12.10199L3.3169894,13.672974 19.114001,13.672974 19.114001,12.10199z M16.406999,1.1129761L21.374013,6.3989868 17.453996,6.3989868C16.875993,6.3989868,16.406999,5.9299927,16.406999,5.3519897z M2.2689838,0L14.893996,0 14.893996,5.6429443C14.893996,6.8959961,15.910995,7.9119873,17.163987,7.9119873L22.457999,7.9119873 22.457999,29.730957C22.457999,30.983948,21.442006,32,20.189015,32L2.2689838,32C1.0159922,32,4.4543413E-08,30.983948,0,29.730957L0,2.2689819C4.4543413E-08,1.0159912,1.0159922,0,2.2689838,0z";
            }
            else if (name == "Zip")
            {
                return "M15.417986,25.649994C16.055986,25.649994 16.446977,25.951004 16.446977,26.513992 16.446977,27.108002 16.025987,27.445999 15.334978,27.445999 15.14699,27.445999 14.996966,27.438004 14.88399,27.408005L14.88399,25.694992C14.981981,25.673004,15.161974,25.649994,15.417986,25.649994z M11.79598,24.981995L11.79598,30.044998 12.71999,30.044998 12.71999,24.981995z M7.2489869,24.981003L7.2489869,25.748001 9.6079933,25.748001 9.6079933,25.770004 7.0159852,29.533997 7.0159852,30.044998 10.846976,30.044998 10.846976,29.278 8.2549974,29.278 8.2549974,29.248001 10.808981,25.522995 10.808981,24.981003z M15.379992,24.944C14.756976,24.944,14.298969,24.988998,13.967975,25.048996L13.967975,30.044998 14.88399,30.044998 14.88399,28.136993C15.004992,28.158997 15.161974,28.166992 15.334978,28.166992 15.98897,28.166992 16.566972,27.994003 16.934983,27.625992 17.219957,27.354996 17.370958,26.957001 17.370958,26.475998 17.370958,26.002991 17.17595,25.604996 16.874986,25.358002 16.551988,25.08699 16.055986,24.944 15.379992,24.944z M8.7809984,17.639999C8.1209948,17.639999 7.5879757,18.173996 7.5879757,18.832993 7.5879757,19.490997 8.1209948,20.026001 8.7809984,20.026001 9.439994,20.026001 9.9729835,19.490997 9.9729835,18.832993 9.9729835,18.173996 9.439994,17.639999 8.7809984,17.639999z M8.5529711,11.636002L8.854973,11.638C9.4999916,11.703003,9.741996,12.072998,10.351981,14.084L11.684987,18.748001C11.684987,20.35199 10.384971,21.653 8.7809984,21.653 7.1769959,21.653 5.876002,20.35199 5.876002,18.748001L7.045984,14.216995C7.6649715,12.543991,7.5879757,11.636002,8.5529711,11.636002z M6.5589849,9.2610016L10.771994,9.2610016 10.771994,10.470993 6.5589849,10.470993z M6.5589849,6.8619995L10.771994,6.8619995 10.771994,8.072998 6.5589849,8.072998z M6.5589849,4.4649963L10.771994,4.4649963 10.771994,5.6759949 6.5589849,5.6759949z M2.2839941,2.4179993L2.2839941,22.778 22.124982,22.778 22.124982,8.5029907 15.837969,8.5029907 15.837969,2.4179993z M0,0L15.837969,0 17.129991,0 24.408,7.125 24.408,32 0,32z";
            }
            return null;
        }

        #endregion
    }
}