#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.TreeViewDemos.WinUI
{
    /// <summary>
    /// Represents the < see cref="NodeWithImageViewModel"/ > class that contains the collection of items used to populate the <see cref="Syncfusion.UI.Xaml.TreeView"/>.
    /// </summary>
    public class NodeWithImageViewModel
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="NodeWithImageViewModel"/> class.
        /// </summary>
        public NodeWithImageViewModel()
        {
            CommonResourceDictionary = IconResource.Resource;
            this.Folders = GetFiles();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the collections for Folders.
        /// </summary>
        public ObservableCollection<Folder> Folders { get; internal set; }

        /// <summary>
        /// Gets or sets the collections for Files.
        /// </summary>
        public ObservableCollection<File> Files { get; internal set; }

        /// <summary>
        /// Gets or sets the collections for SubFiles.
        /// </summary>
        public ObservableCollection<SubFile> SubFiles { get; internal set; }

        /// <summary>
        /// Holds the required resouces for IconTemplate.
        /// </summary>
        private ResourceDictionary CommonResourceDictionary { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Set the collections for Folders
        /// </summary>
        /// <returns>Returns the collection.</returns>
        private ObservableCollection<Folder> GetFiles()
        {
            var nodeImageInfo = new ObservableCollection<Folder>();

            var doc = new Folder() { FileName = "Documents", ImageTemplate = CommonResourceDictionary["Folder"] as DataTemplate };
            var download = new Folder() { FileName = "Downloads", ImageTemplate = CommonResourceDictionary["Folder"] as DataTemplate };
            var mp3 = new Folder() { FileName = "Music", ImageTemplate = CommonResourceDictionary["Folder"] as DataTemplate };
            var pictures = new Folder() { FileName = "Pictures", ImageTemplate = CommonResourceDictionary["Folder"] as DataTemplate };
            var video = new Folder() { FileName = "Videos", ImageTemplate = CommonResourceDictionary["Folder"] as DataTemplate };

            var pollution = new File() { FileName = "Environmental Pollution.docx", ImageTemplate = CommonResourceDictionary["Word"] as DataTemplate };
            var globalWarming = new File() { FileName = "Global Warming.ppt", ImageTemplate = CommonResourceDictionary["PowerPoint"] as DataTemplate };
            var sanitation = new File() { FileName = "Sanitation.docx", ImageTemplate = CommonResourceDictionary["Word"] as DataTemplate };
            var socialNetwork = new File() { FileName = "Social Network.pdf", ImageTemplate = CommonResourceDictionary["Pdf"] as DataTemplate };
            var youthEmpower = new File() { FileName = "Youth Empowerment.pdf", ImageTemplate = CommonResourceDictionary["Pdf"] as DataTemplate };

            var games = new File() { FileName = "Game.exe", ImageTemplate = CommonResourceDictionary["EXE"] as DataTemplate };
            var tutorials = new File() { FileName = "Tutorials.zip", ImageTemplate = CommonResourceDictionary["Zip"] as DataTemplate };
            var typeScript = new File() { FileName = "TypeScript.7z", ImageTemplate = CommonResourceDictionary["Zip"] as DataTemplate };
            var uiGuide = new File() { FileName = "UI-Guide.pdf", ImageTemplate = CommonResourceDictionary["Pdf"] as DataTemplate };

            var song = new File() { FileName = "Gouttes", ImageTemplate = CommonResourceDictionary["Audio"] as DataTemplate };

            var camera = new File() { FileName = "Camera Roll", ImageTemplate = CommonResourceDictionary["Folder"] as DataTemplate };
            var stone = new File() { FileName = "Stone.jpg", ImageTemplate = CommonResourceDictionary["Png"] as DataTemplate };
            var wind = new File() { FileName = "Wind.jpg", ImageTemplate = CommonResourceDictionary["Png"] as DataTemplate };

            var img0 = new SubFile() { FileName = "WIN_20160726_094117.JPG", ImageTemplate = CommonResourceDictionary["Png"] as DataTemplate };
            var img1 = new SubFile() { FileName = "WIN_20160726_094118.JPG", ImageTemplate = CommonResourceDictionary["Png"] as DataTemplate };

            var video1 = new File() { FileName = "Natural World.mp4", ImageTemplate = CommonResourceDictionary["Video"] as DataTemplate };
            var video2 = new File() { FileName = "Wildlife.mpeg", ImageTemplate = CommonResourceDictionary["Video"] as DataTemplate };

            doc.Files = new ObservableCollection<File>
            {
                pollution,
                globalWarming,
                sanitation,
                socialNetwork,
                youthEmpower
            };

            download.Files = new ObservableCollection<File>
            {
                games,
                tutorials,
                typeScript,
                uiGuide
            };

            mp3.Files = new ObservableCollection<File>
            {
                song
            };

            pictures.Files = new ObservableCollection<File>
            {
                camera,
                stone,
                wind
            };
            camera.SubFiles = new ObservableCollection<SubFile>
            {
                img0,
                img1
            };

            video.Files = new ObservableCollection<File>
            {
                video1,
                video2
            };

            nodeImageInfo.Add(doc);
            nodeImageInfo.Add(download);
            nodeImageInfo.Add(mp3);
            nodeImageInfo.Add(pictures);
            nodeImageInfo.Add(video);

            return nodeImageInfo;
        }
        #endregion
    }
}
