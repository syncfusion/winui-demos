#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DemosCommon.WinUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.BarcodeDemos.WinUI
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            // Showcase & Updated

            // Showcase & New

            //What's New

            DemoInfo showCaseSample1 = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Getting Started",
                Description = "This sample showcases how to display data in the encoded machine-readable format using supported symbol types either in a one-dimensional or two-dimensional pattern.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.BarcodeDemoPage)
            };
            showCaseSample1.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Barcode - API", Uri = new Uri("https://help.syncfusion.com"), } });

            // Updated

            var demos = new List<DemoInfo>()
            {
                showCaseSample1
            };

            var controlInfo = new ControlInfo()
            {
                Control = DemoControl.Barcode,
                Description = "The Barcode is a data visualization control to generate and display data in a machine-readable format using supported symbol types.",
                Glyph = "\uE709",
                ImageSource= "Barcode.png",
                ControlBadge = ControlBadge.None,
                ControlCategory = ControlCategory.DataVisualization
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);
        }

    }
}
