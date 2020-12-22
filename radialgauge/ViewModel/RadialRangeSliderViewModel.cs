#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.radialgaugedemos.winui
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Syncfusion.UI.Xaml.Core;

    class RadialRangeSliderViewModel : NotificationObject
    {
        private double firstMarkerValue = 2;

        private double secondMarkerValue = 10;

        private string annotationString = "06" + "hr" + " 00" + "min";

        public double FirstMarkerValue
        {
            get { return this.firstMarkerValue; }
            set
            {
                this.firstMarkerValue = value;
                this.RaisePropertyChanged(nameof(FirstMarkerValue));
            }
        }

        public double SecondMarkerValue
        {
            get { return this.secondMarkerValue; }
            set
            {
                this.secondMarkerValue = value;
                this.RaisePropertyChanged(nameof(SecondMarkerValue));
            }
        }

        public string AnnotationString
        {
            get
            {
                return this.annotationString;
            }

            set
            {
                this.annotationString = value;
                this.RaisePropertyChanged(nameof(AnnotationString));
            }
        }
    }
}