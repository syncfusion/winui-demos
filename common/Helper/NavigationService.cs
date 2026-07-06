using Microsoft.UI.Xaml.Controls;
using System;

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// Represent a class which provide navigation service.
    /// </summary>
    public static class NavigationService
    {
        /// <summary>
        /// Get or sets a <see cref="Frame"/>.
        /// </summary>
        public static Frame Frame { get; set; }

        /// <summary>
        /// Get or sets a <see cref="DemoPageFrame"/>.
        /// </summary>
        public static Frame DemoPageFrame { get; set; }

        /// <summary>
        /// Get or sets a <see cref="MainViewModel"/> for to use it in ControlInfo class.
        /// </summary>
        public static MainViewModel ViewModel { get; set; }
    }
}
