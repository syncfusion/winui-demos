#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace Syncfusion.RadialGaugeDemos.WinUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Syncfusion.UI.Xaml.Core;

    class RadialRangeSliderViewModel : NotificationObject
    {
        private double firstShapeValue = 2;

        private double secondShapeValue = 10;

        private string annotationString = "06" + "hr" + " 00" + "min";

        public double FirstShapeValue
        {
            get { return this.firstShapeValue; }
            set
            {
                this.firstShapeValue = value;
                this.RaisePropertyChanged(nameof(FirstShapeValue));
            }
        }

        public double SecondShapeValue
        {
            get { return this.secondShapeValue; }
            set
            {
                this.secondShapeValue = value;
                this.RaisePropertyChanged(nameof(SecondShapeValue));
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