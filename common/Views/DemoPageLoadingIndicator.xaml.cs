using System;
using System.Linq;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Windows.Media.Playback;

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// A section page to display demo list under showcase and what's new.
    /// </summary>
    public sealed partial class DemoPageLoadingIndicator : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoPageLoadingIndicator"/> class.
        /// This constructor calls <see cref="InitializeComponent"/> to load the XAML resources and set up the UI elements for the loading indicator.
        /// </summary>
        public DemoPageLoadingIndicator()
        {
            this.InitializeComponent();
        }
    }
}
