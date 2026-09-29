using Syncfusion.DemosCommon.WinUI;
using System;
using System.Collections.Generic;

namespace Syncfusion.ShadowDemos.WinUI
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            DemoInfo shadowDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Shadow",
                Description = "Shadow control is used to apply the shadow effects to any framework element to display with a beautiful and attractive UI.",
                DemoView = typeof(Views.Shadow.ShadowView),
                DemoType = DemoTypes.None,
                ShowInfoPanel = false,
            };

            var shadow = new ControlInfo()
            {
                Control = DemoControl.SfShadow,
                ControlCategory = ControlCategory.Miscellaneous,
                ControlBadge = ControlBadge.None,
                Description = "Shadow control is used to apply the shadow effects to any framework element to display with a beautiful and attractive UI.",
                Glyph = "\ue722",
                ImageSource = "Shadow.png",
                IsPreview = false,   
            };
            shadow.Demos.Add(shadowDemo);

            var controlInfos = new List<ControlInfo>()
            {
                shadow,
            };

            DemoHelper.ControlInfos.AddRange(controlInfos);
        }
    }
}
