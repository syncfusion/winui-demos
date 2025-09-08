#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;

namespace Syncfusion.AvatarViewDemos.WinUI.Views.AvatarView
{
    public class ViewModel
    {
        private ObservableCollection<AvatarViewModel> listViewcollection;

        public ObservableCollection<AvatarViewModel> ListViewCollection
        {
            get { return listViewcollection; }
            set { listViewcollection = value; }
        }

        public ViewModel()
        {
            listViewcollection = new ObservableCollection<AvatarViewModel>
            {
                new AvatarViewModel(3) { Title = "My Teams", Participants = "3 Participants" },
                new AvatarViewModel(2) { Title = "Product Teams", Participants = "2 Participants" },
                new AvatarViewModel(5) { Title = "Sales Managers", Participants = "5 Participants" },
                new AvatarViewModel(2) { Title = "Marketing Managers", Participants = "2 Participants" },
                new AvatarViewModel(5) { Title = "Designers", Participants = "5 Participants" },
                new AvatarViewModel(2) { Title = "Old Project", Participants = "2 Participants" },
                new AvatarViewModel(4) { Title = "Process Managers", Participants = "4 Participants" },
                new AvatarViewModel(2) { Title = "Process Heads", Participants = "2 Participants" },
                new AvatarViewModel(8) { Title = "New Project", Participants = "8 Participants" },
                new AvatarViewModel(6) { Title = "Sales Heads", Participants = "6 Participants" }
            };
        }
    }
}
