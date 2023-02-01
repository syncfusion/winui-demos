#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
using Microsoft.UI.Xaml;

namespace Syncfusion.TreeViewDemos.WinUI
{
    public class SamplesConfiguration 
    {
        public SamplesConfiguration()
        {
            DemoInfo gettingStartedSample = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Getting Started",
                Description = "This sample showcases the basic features of the TreeView with data binding using ObservableCollection, and also populating nodes directly.",
                DemoView = typeof(Syncfusion.TreeViewDemos.WinUI.GettingStartedPage),
                ShowInfoPanel = true
            };

            List<Documentation> gettingStartedSampleDocumentation = new List<Documentation>();
            gettingStartedSampleDocumentation.Add(new Documentation() { Content = "TreeView - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeView.html") });
            gettingStartedSampleDocumentation.Add(new Documentation() { Content = "TreeView - ShowLines API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_ShowLines") });
            gettingStartedSampleDocumentation.Add(new Documentation() { Content = "TreeView - Getting Started Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/getting-started") });
            gettingStartedSampleDocumentation.Add(new Documentation() { Content = "TreeView - Data Binding Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/data-binding") });
            gettingStartedSampleDocumentation.Add(new Documentation() { Content = "TreeView - Editing Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/editing") });
            gettingStartedSampleDocumentation.Add(new Documentation() { Content = "TreeView - Selection Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/selection") });
            gettingStartedSampleDocumentation.Add(new Documentation() { Content = "TreeView - Appearance Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/appearance") });
            gettingStartedSampleDocumentation.Add(new Documentation() { Content = "TreeView - Tree Lines Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/treelines") });
            gettingStartedSampleDocumentation.Add(new Documentation() { Content = "TreeView - CRUD Operations Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/crud-operations") });
            gettingStartedSampleDocumentation.Add(new Documentation() { Content = "TreeView - Drag and Drop Operations Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/drag-and-drop") });

            gettingStartedSample.Documentation.AddRange(gettingStartedSampleDocumentation);

            DemoInfo nodeWithImageSample = new DemoInfo()
            {
                Name = "Node with Image",
                Category = "Getting Started",
                Description = "This sample showcases how to load the text as well as image in each node using the ItemTemplate option from a TreeView.",
                DemoView = typeof(Syncfusion.TreeViewDemos.WinUI.NodeWithImagePage),
                ShowInfoPanel = true
            };

            List<Documentation> nodeWithImageSampleDocumentation = new List<Documentation>();
            nodeWithImageSampleDocumentation.Add(new Documentation() { Content = "TreeView - TreeViewItem API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeView.TreeViewItem.html") });
            nodeWithImageSampleDocumentation.Add(new Documentation() { Content = "TreeView - ItemTemplate API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_ItemTemplate") });
            nodeWithImageSampleDocumentation.Add(new Documentation() { Content = "TreeView - Animation Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/appearance#animation") });
            nodeWithImageSampleDocumentation.Add(new Documentation() { Content = "TreeView - Level Based Styling Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/appearance#level-based-styling") });
            nodeWithImageSampleDocumentation.Add(new Documentation() { Content = "TreeView - TreeNode Expand and Collapse Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/expand-collapse") });


            nodeWithImageSample.Documentation.AddRange(nodeWithImageSampleDocumentation);

            DemoInfo loadOnDemandSample = new DemoInfo()
            {
                Name = "Load On Demand",
                Category = "Getting Started",
                Description = "This sample showcases the dynamic loading of child items in each level of hierarchy when the node is expanded using the load on demand support.",
                DemoView = typeof(Syncfusion.TreeViewDemos.WinUI.LoadOnDemandPage),
                ShowInfoPanel = true
            };

            List<Documentation> loadOnDemandSampleDocumentation = new List<Documentation>();
            loadOnDemandSampleDocumentation.Add(new Documentation() { Content = "TreeView - LoadOnDemandCommand API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_LoadOnDemandCommand") });
            loadOnDemandSampleDocumentation.Add(new Documentation() { Content = "TreeView - Load On Demand Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/load-on-demand") });
            loadOnDemandSampleDocumentation.Add(new Documentation() { Content = "TreeView - Interactivity Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/interactivity") });

            loadOnDemandSample.Documentation.AddRange(loadOnDemandSampleDocumentation);

            DemoInfo performanceSample = new DemoInfo()
            {
                Name = "Performance",
                Category = "Getting Started",
                Description = "This sample showcases the loading and scrolling performance of a TreeView with one million nodes.",
                DemoView = typeof(Syncfusion.TreeViewDemos.WinUI.PerformancePage),
                ShowInfoPanel = true
            };

            List<Documentation> performanceSampleDocumentation = new List<Documentation>();
            performanceSampleDocumentation.Add(new Documentation() { Content = "TreeView - LoadOnDemandCommand API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_LoadOnDemandCommand") });
            performanceSampleDocumentation.Add(new Documentation() { Content = "TreeView - Load On Demand Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/load-on-demand") });
            performanceSampleDocumentation.Add(new Documentation() { Content = "TreeView - Scrolling Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/scrolling") });

            performanceSample.Documentation.AddRange(performanceSampleDocumentation);

            DemoInfo checkBoxSample = new DemoInfo()
            {
                Name = "CheckBoxes",
                Category = "Interactive Features",
                Description = "This sample showcases customization of nodes with CheckBox using ItemTemplate that allows recursive checking of child nodes based on checkbox modes.",
                DemoView = typeof(Syncfusion.TreeViewDemos.WinUI.CheckBoxPage),
                ShowInfoPanel = true
            };

            List<Documentation> checkBoxSampleDocumentation = new List<Documentation>();
            checkBoxSampleDocumentation.Add(new Documentation() { Content = "TreeView - CheckBoxMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeView.CheckBoxMode.html") });
            checkBoxSampleDocumentation.Add(new Documentation() { Content = "TreeView - CheckBox Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/checkbox") });
            checkBoxSampleDocumentation.Add(new Documentation() { Content = "TreeView - CheckBox in Bound Mode Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/checkbox#working-with-checkbox-in-bound-mode") });
            checkBoxSampleDocumentation.Add(new Documentation() { Content = "TreeView - CheckBox in UnBound Mode Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/checkbox#working-with-checkbox-in-unbound-mode") });
            checkBoxSampleDocumentation.Add(new Documentation() { Content = "TreeView - CheckBox Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/checkbox#events") });

            checkBoxSample.Documentation.AddRange(checkBoxSampleDocumentation);

            DemoInfo editingSample = new DemoInfo()
            {
                Name = "Editing",
                Category = "Interactive Features",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the editing capability in TreeView. You can start editing by navigating to required Treeview item and press the F2 key.",
                DemoView = typeof(Syncfusion.TreeViewDemos.WinUI.EditingPage),
                ShowInfoPanel = true
            };
			
            List<Documentation> editingSampleDocumentation = new List<Documentation>();
            editingSampleDocumentation.Add(new Documentation() { Content = "TreeView - AllowEditing API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_AllowEditing") });
            editingSampleDocumentation.Add(new Documentation() { Content = "TreeView - EditTemplate API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_EditTemplate") });
            editingSampleDocumentation.Add(new Documentation() { Content = "TreeView - BeginEdit Method API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_BeginEdit_Syncfusion_UI_Xaml_TreeView_TreeViewNode_") });
            editingSampleDocumentation.Add(new Documentation() { Content = "TreeView - Editing Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/editing") });
            editingSampleDocumentation.Add(new Documentation() { Content = "TreeView - Editing Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treeview/editing#events") });
            
            editingSample.Documentation.AddRange(editingSampleDocumentation);

            var demos = new List<DemoInfo>()
            {
                   gettingStartedSample,
                   nodeWithImageSample,
                   loadOnDemandSample,
                   performanceSample,
                   checkBoxSample,
                   editingSample,
            };

            var controlInfo = new ControlInfo()
            {
                Control = DemoControl.SfTreeView,
                Glyph = "\uE708",
                ImageSource="TreeView.png",
                Description = "The TreeView is a data-oriented control that displays data in a hierarchical structure with nodes that expand and collapse.",
                ControlCategory = ControlCategory.Navigation,
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);
        }
    }
}
