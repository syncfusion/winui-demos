#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Input;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TreeGrid
{
    public class Commands
    {
        public Commands()
        {
            ExpandCommand = new DelegateCommand(OnExpandClicked);
            CollapseCommand = new DelegateCommand(OnCollapseClicked);
        }

        private ICommand expandCommand;

        public ICommand ExpandCommand
        {
            get
            {
                return expandCommand;
            }
            set
            {
                expandCommand = value;
            }
        }

        private ICommand collapseCommand;

        public ICommand CollapseCommand
        {
            get
            {
                return collapseCommand;
            }
            set
            {
                collapseCommand = value;
            }
        }

        #region Command Methods

        private void OnCollapseClicked(object obj)
        {
            var treeGrid = obj as SfTreeGrid;
            treeGrid.CollapseAllNodes();
        }

        private void OnExpandClicked(object obj)
        {
            var treeGrid = obj as SfTreeGrid;
            treeGrid.ExpandAllNodes();
        }


        #endregion
    }
}
