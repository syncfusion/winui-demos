#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI;
using Syncfusion.AvatarViewDemos.WinUI.Views.AvatarView;
using System.Collections.ObjectModel;

namespace Syncfusion.AvatarViewDemos.WinUI.Views.AvatarView
{
    public class AvatarViewModel
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string participants;

        public string Participants
        {
            get { return participants; }
            set { participants = value; }
        }

        public ObservableCollection<Model> PeopleCollection { get; set; }

        public ObservableCollection<Model> GroupViewCollection { get; set; }

        public AvatarViewModel(int count)
        {
            PopulateModel();
            PopulatePeopleCollection(count);
        }

        static int count = 0;

        private void PopulatePeopleCollection(int peopleCount)
        {
            PeopleCollection = new ObservableCollection<Model>();
            for (int i = 0; i < peopleCount; i++)
            {
                while (true)
                {
                    if (GroupViewCollection.Count <= count)
                        count = 0;

                    var person = GroupViewCollection[count++];
                    if (!PeopleCollection.Contains(person))
                    {
                        PeopleCollection.Add(person);
                        break;
                    }
                }
            }

        }

        private void PopulateModel()
        {
            string path = "";
#if Main_SB
            path = "AvatarView/";
#endif
            GroupViewCollection = new ObservableCollection<Model>
            {
                new Model() { Name = "Adriana", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xF2, 0xE9, 0xC8), InitialColor = ColorHelper.FromArgb(0xFF, 0x69, 0x53, 0x1C) },
                new Model() { Name = "Haven", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xD6, 0xE8, 0xD7), InitialColor = ColorHelper.FromArgb(0xFF, 0x24, 0x4F, 0x23) },
                new Model() { Name = "Karla", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xD6, 0xE3, 0xE8), InitialColor = ColorHelper.FromArgb(0xFF, 0x1A, 0x5F, 0x6F) },
                new Model() { Name = "Davis", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xF2, 0xE9, 0xC8), InitialColor = ColorHelper.FromArgb(0xFF, 0x69, 0x53, 0x1C) },
                new Model() { Name = "Clara", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xD8, 0xFF, 0xF6), InitialColor = ColorHelper.FromArgb(0xFF, 0x06, 0x79, 0x6B), ImagePath = path+"Assets/AvatarView/Sarah.png" },
                new Model() { Name = "Daleyza", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xD2, 0xF1, 0xEF), InitialColor = ColorHelper.FromArgb(0xFF, 0x1D, 0x7B, 0x6A) },
                new Model() { Name = "Ellie", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xF2, 0xE9, 0xC8), InitialColor = ColorHelper.FromArgb(0xFF, 0x69, 0x53, 0x1C) },
                new Model() { Name = "Finley", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xF0, 0xD7, 0xE9), InitialColor = ColorHelper.FromArgb(0xFF, 0x7B, 0x1D, 0x67) },
                new Model() { Name = "Jackson", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xD6, 0xE8, 0xD7), InitialColor = ColorHelper.FromArgb(0xFF, 0x24, 0x4F, 0x23) },
                new Model() { Name = "Jayden", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xD6, 0xE3, 0xE8), InitialColor = ColorHelper.FromArgb(0xFF, 0x1A, 0x5F, 0x6F) },
                new Model() { Name = "Kaylee", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xD8, 0xD7, 0xF0), InitialColor = ColorHelper.FromArgb(0xFF, 0x25, 0x1D, 0x7B), ImagePath = path+"Assets/AvatarView/Gabriella.png" },
                new Model() { Name = "Lucy", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xF0, 0xD7, 0xE9), InitialColor = ColorHelper.FromArgb(0xFF, 0x7B, 0x1D, 0x67), ImagePath = path+"Assets/AvatarView/Victoriya.png"},
                new Model() { Name = "Jaden", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xD2, 0xF1, 0xEF), InitialColor = ColorHelper.FromArgb(0xFF, 0x1D, 0x7B, 0x6A) },
                new Model() { Name = "George", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xFB, 0xE3, 0xDB), InitialColor = ColorHelper.FromArgb(0xFF, 0x7B, 0x2E, 0x1D),ImagePath = path+"Assets/AvatarView/Michael.png" },
                new Model() { Name = "Jayden", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xF2, 0xE9, 0xC8), InitialColor = ColorHelper.FromArgb(0xFF, 0x69, 0x53, 0x1C) },
                new Model() { Name = "Ellanaa", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xD6, 0xE8, 0xD7), InitialColor = ColorHelper.FromArgb(0xFF, 0x24, 0x4F, 0x23) },
                new Model() { Name = "James", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xD6, 0xE3, 0xE8), InitialColor = ColorHelper.FromArgb(0xFF, 0x1A, 0x5F, 0x6F), ImagePath = path+"Assets/AvatarView/Oscar.png" },
                new Model() { Name = "Zelda", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xD8, 0xD7, 0xF0), InitialColor = ColorHelper.FromArgb(0xFF, 0x25, 0x1D, 0x7B), ImagePath = path+"Assets/AvatarView/Jayden.png" },
                new Model() { Name = "Wren", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xF0, 0xD7, 0xE9), InitialColor = ColorHelper.FromArgb(0xFF, 0x7B, 0x1D, 0x67) },
                new Model() { Name = "Yamileth", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xF4, 0xFF, 0xD6), InitialColor = ColorHelper.FromArgb(0xFF, 0x42, 0x58, 0x03) },
                new Model() { Name = "Briley", BackgroundColor = ColorHelper.FromArgb(0xFF, 0xFB, 0xE3, 0xDB), InitialColor = ColorHelper.FromArgb(0xFF, 0x7B, 0x2E, 0x1D), ImagePath = path+"Assets/AvatarView/Finley.png" }
            };
        }
    }
}
