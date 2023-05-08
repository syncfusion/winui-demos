#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.TreeViewDemos.WinUI
{
    public class EditingViewModel : NotificationObject
    {        
        public EditingViewModel()
        {
            CommonResourceDictionary = IconResource.Resource;
            
            Nodes1 = new ObservableCollection<EditingModel>();            

            // Generate source for SfTreeView1
            PopulateData1();           
        }

        /// <summary>
        /// Holds the required resouces for IconTemplate.
        /// </summary>
        private ResourceDictionary CommonResourceDictionary { get; set; }

        private void PopulateData1()
        {
            var RootNode1 = new EditingModel("Work Documents") { ImageTemplate = CommonResourceDictionary["Folder"] as DataTemplate, IsExpanded = true };
            var RootNode2 = new EditingModel("Personal Folder") { ImageTemplate = CommonResourceDictionary["Folder"] as DataTemplate, IsExpanded = true };

            var ChildNode1 = new EditingModel("Functional Specifications") { ImageTemplate = CommonResourceDictionary["Folder"] as DataTemplate, IsExpanded = true };
            var ChildNode2 = new EditingModel("TreeView spec.docx") { ImageTemplate = CommonResourceDictionary["Word"] as DataTemplate, IsExpanded = true };
            var ChildNode3 = new EditingModel("Feature Schedule.docx") { ImageTemplate = CommonResourceDictionary["Word"] as DataTemplate, IsExpanded = false };
            var ChildNode4 = new EditingModel("Overall Project Plan.docx") { ImageTemplate = CommonResourceDictionary["Word"] as DataTemplate, IsExpanded = false };
            var ChildNode5 = new EditingModel("Feature Resource Allocation.docx") { ImageTemplate = CommonResourceDictionary["Word"] as DataTemplate, IsExpanded = false };
            var ChildNode6 = new EditingModel("Home Remodel Folder") { ImageTemplate = CommonResourceDictionary["Folder"] as DataTemplate, IsExpanded = true };
            var ChildNode7 = new EditingModel("Contractor Contact Info.docx") { ImageTemplate = CommonResourceDictionary["Word"] as DataTemplate, IsExpanded = false };
            var ChildNode8 = new EditingModel("Paint Color Scheme.ppt") { ImageTemplate = CommonResourceDictionary["PowerPoint"] as DataTemplate, IsExpanded = false };
            var ChildNode9 = new EditingModel("Flooring Woodgrain type.ppt") { ImageTemplate = CommonResourceDictionary["PowerPoint"] as DataTemplate, IsExpanded = false };
            var ChildNode10 = new EditingModel("Kitchen Cabinet Style.ppt") { ImageTemplate = CommonResourceDictionary["PowerPoint"] as DataTemplate, IsExpanded = false };

            var ChildNode11 = new EditingModel("My Network Places") { ImageTemplate = CommonResourceDictionary["Folder"] as DataTemplate, IsExpanded = true };
            var ChildNode12 = new EditingModel("Server") { ImageTemplate = CommonResourceDictionary["Folder"] as DataTemplate, IsExpanded = false };
            var ChildNode13 = new EditingModel("My Folders") { ImageTemplate = CommonResourceDictionary["Folder"] as DataTemplate, IsExpanded = false };

            var ChildNode14 = new EditingModel("My Computer") { ImageTemplate = CommonResourceDictionary["Folder"] as DataTemplate, IsExpanded = true };
            var ChildNode15 = new EditingModel("Music") { ImageTemplate = CommonResourceDictionary["Audio"] as DataTemplate, IsExpanded = false };
            var ChildNode16 = new EditingModel("Videos") { ImageTemplate = CommonResourceDictionary["Video"] as DataTemplate, IsExpanded = false };
            var ChildNode17 = new EditingModel("Wallpaper.png") { ImageTemplate = CommonResourceDictionary["Png"] as DataTemplate, IsExpanded = false };
            var ChildNode18 = new EditingModel("My Banner.png") { ImageTemplate = CommonResourceDictionary["Png"] as DataTemplate, IsExpanded = false };

            var ChildNode19 = new EditingModel("Favourites") { ImageTemplate = CommonResourceDictionary["Folder"] as DataTemplate, IsExpanded = true };
            var ChildNode20 = new EditingModel("Stone.png") { ImageTemplate = CommonResourceDictionary["Png"] as DataTemplate, IsExpanded = false };
            var ChildNode21 = new EditingModel("Wind.png") { ImageTemplate = CommonResourceDictionary["Png"] as DataTemplate, IsExpanded = false };
            var ChildNode22 = new EditingModel("Nature.png") { ImageTemplate = CommonResourceDictionary["Png"] as DataTemplate, IsExpanded = false };

            RootNode1.Childs.Add(ChildNode1);
            RootNode1.Childs.Add(ChildNode3);
            RootNode1.Childs.Add(ChildNode4);
            RootNode1.Childs.Add(ChildNode5);
            RootNode2.Childs.Add(ChildNode6);

            RootNode2.Childs.Add(ChildNode11);
            RootNode2.Childs.Add(ChildNode14);
            RootNode2.Childs.Add(ChildNode19);

            ChildNode1.Childs.Add(ChildNode2);
            ChildNode6.Childs.Add(ChildNode7);
            ChildNode6.Childs.Add(ChildNode8);
            ChildNode6.Childs.Add(ChildNode9);
            ChildNode6.Childs.Add(ChildNode10);
            ChildNode11.Childs.Add(ChildNode12);
            ChildNode11.Childs.Add(ChildNode13);
            ChildNode11.Childs.Add(ChildNode17);

            ChildNode14.Childs.Add(ChildNode15);
            ChildNode14.Childs.Add(ChildNode16);
            ChildNode14.Childs.Add(ChildNode18);

            ChildNode19.Childs.Add(ChildNode20);
            ChildNode19.Childs.Add(ChildNode21);
            ChildNode19.Childs.Add(ChildNode22);

            Nodes1.Add(RootNode1);
            Nodes1.Add(RootNode2);
        }        

        public ObservableCollection<EditingModel> Nodes1 { get; set; }

    }
}
