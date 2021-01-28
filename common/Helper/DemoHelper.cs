#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace syncfusion.demoscommon.winui
{
    public class CategoryGroup
    {
        public string CategoryName { get; set; }
        private IEnumerable menuItems;
        public IEnumerable Items
        {
            get { return menuItems; }
            set
            {
                menuItems = value;
            }
        }
    }

    /// <summary>
    /// Represent a class which contain all helper instance and methods
    /// </summary>
    public sealed class DemoHelper
    {
        #region Variables
        /// <summary>
        /// Demo helper instance created as singleton.
        /// </summary>
        private static readonly DemoHelper instance = new DemoHelper();

        /// <summary>
        /// A list of showcase demos
        /// </summary>
        internal static List<DemoInfo> ShowCaseDemos = new List<DemoInfo>();

        /// <summary>
        /// A list of what's new demos
        /// </summary>
        internal static List<DemoInfo> WhatsNewDemos = new List<DemoInfo>();

        #endregion Variables

        #region Properties
        /// <summary>
        /// A list of control infos
        /// </summary>
        public static readonly List<ControlInfo> ControlInfos = new List<ControlInfo>();

        /// <summary>
        /// A singleton instance of <see cref="DemoHelper"/>
        /// </summary>
        public static DemoHelper Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoHelper"/> class.
        /// </summary>
        private DemoHelper()
        {
            
        }

        #endregion Constructor

        #region Methods
        /// <summary>
        /// A method to identify the control information of the demo info
        /// </summary>
        /// <param name="demoInfo">demo info</param>
        /// <returns>Control info</returns>
        internal static ControlInfo GetControlInfo(DemoInfo demoInfo)
        {
            foreach (var control in DemoHelper.ControlInfos)
            {
                var demo = control.Demos.FirstOrDefault(x => x.Equals(demoInfo));
                if (demo != null)
                {
                    return control;
                }
            }
            return null;
        }

        #endregion Methods
    }
}
