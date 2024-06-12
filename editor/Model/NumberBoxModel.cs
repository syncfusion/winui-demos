#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.EditorDemos.WinUI
{
    //A Country class that represents the elements used in the NumberBox Culture demo.
    public class Country
    {
        public BitmapImage FlagImage { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }
    }

    //A Unit class that represents the elements used in the NumberBox Formatting demo.
    public class Unit
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
