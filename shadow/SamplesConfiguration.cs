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
                ShowInfoPanel = false,
                DemoType = DemoTypes.New
            };

            var shadow = new ControlInfo()
            {
                Control = DemoControl.SfShadow,
                ControlCategory = ControlCategory.Miscellaneous,
                ControlBadge = ControlBadge.New,
                Description = "Shadow control is used to apply the shadow effects to any framework element to display with a beautiful and attractive UI.",
                Glyph = "\ue722",
                IsPreview = true,   
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
