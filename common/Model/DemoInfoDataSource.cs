using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.DemosCommon.WinUI
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
                    if ((demo.DemoType & DemoTypes.AISamples) == DemoTypes.AISamples)
                    {
                        DemoHelper.AIDemos.Add(demo);
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
