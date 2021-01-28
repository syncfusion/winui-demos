#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.winui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;

namespace syncfusion.treeviewdemos.winui
{
    public class SamplesConfiguration 
    {
        public SamplesConfiguration()
        {
            DemoInfo gettingStartedSample = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Getting Started",
                Description = "These samples showcase the basic features of the Tree View with data binding using ObservableCollection, and also populating nodes directly.",
                DemoView = typeof(syncfusion.treeviewdemos.winui.GettingStartedPage),
            };
            gettingStartedSample.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "TreeView - API", Uri = new Uri("https://help.syncfusion.com"), } });

            DemoInfo nodeWithImageSample = new DemoInfo()
            {
                Name = "Node with Image",
                Category = "Getting Started",
                Description = "This sample showcases how to load the text as well as image in each node using the ItemTemplate option from a Tree View.",
                DemoView = typeof(syncfusion.treeviewdemos.winui.NodeWithImagePage),
            };
            nodeWithImageSample.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "TreeView - API", Uri = new Uri("https://help.syncfusion.com"), } });

            DemoInfo loadOnDemandSample = new DemoInfo()
            {
                Name = "Load On Demand",
                Category = "Getting Started",
                Description = "This sample showcases the dynamic loading of child items in each level of hierarchy when the node is expanded using the load on demand support.",
                DemoView = typeof(syncfusion.treeviewdemos.winui.LoadOnDemandPage),
            };
            loadOnDemandSample.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "TreeView - API", Uri = new Uri("https://help.syncfusion.com"), } });

            DemoInfo performanceSample = new DemoInfo()
            {
                Name = "Performance",
                Category = "Getting Started",
                Description = "This sample showcases the loading and scrolling performance of a Tree View with one million nodes.",
                DemoView = typeof(syncfusion.treeviewdemos.winui.PerformancePage),
            };
            performanceSample.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "TreeView - API", Uri = new Uri("https://help.syncfusion.com"), } });

            DemoInfo checkBoxSample = new DemoInfo()
            {
                Name = "CheckBoxes",
                Category = "Interactive Features",
                Description = "This sample showcases customization of nodes with CheckBox using ItemTemplate that allows recursive checking of child nodes based on checkbox modes.",
                DemoView = typeof(syncfusion.treeviewdemos.winui.CheckBoxPage),
            };
            checkBoxSample.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "TreeView - API", Uri = new Uri("https://help.syncfusion.com"), } });
                                
            var demos = new List<DemoInfo>()
            {
                   gettingStartedSample,
                   nodeWithImageSample,
                   loadOnDemandSample,
                   performanceSample,
                   checkBoxSample,
            };

            var controlInfo = new ControlInfo()
            {
                Control = DemoControl.SfTreeView,
                Glyph = "\uE708",
                Description = "The Tree View is a data-oriented control that displays data in a hierarchical structure with nodes that expand and collapse.",
                ControlCategory = ControlCategory.Navigation,
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);
        }
    }
}
