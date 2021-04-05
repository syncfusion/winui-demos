#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.demoscommon.winui
{
    /// <summary>
    /// A class to populate demo information.
    /// </summary>
    public class DemoInfoDataSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoInfoDataSource"/> class.
        /// </summary>
        public DemoInfoDataSource()
        {
            FetchDetails();
        }

        /// <summary>
        /// A method to fetch details from <see cref="DemoHelper"/>.
        /// </summary>
        private static void FetchDetails()
        {
            foreach (var control in DemoHelper.ControlInfos)
            {
                foreach (var demo in control.Demos)
                {
                    if ((demo.DemoType & DemoTypes.Showcase) == DemoTypes.Showcase)
                    {
                        DemoHelper.ShowCaseDemos.Add(demo);
                    }
                    else if (demo.DemoType == DemoTypes.New || demo.DemoType == DemoTypes.Updated)
                    {
                        demo.ControlName = control.Name;
                        DemoHelper.WhatsNewDemos.Add(demo);
                    }
                    else if (demo.DemoType.HasFlag(DemoTypes.Updated) & demo.DemoType.HasFlag(DemoTypes.New))
                    {
                        throw new Exception($"Invalid DemoType: for demo:{demo.Name}, Control:{control.Name}");
                    }
                }
            }
        }
    }
}
