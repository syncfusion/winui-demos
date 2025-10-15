#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;

namespace Syncfusion.DemosCommon.WinUI
{
    public sealed partial class HomePageHeaderImage : Page
    {
        public string ControlsGalleryText => UIStringsProvider.ControlsGalleryText;
        public HomePageHeaderImage()
        {
            this.InitializeComponent();
        }
    }

    public static class UIStringsProvider
    {

#if DOCUMENT_SDK
        public static string ControlsGalleryText => "Document SDK for WinUI";
        public static string UWPSamplesLink => "https://github.com/syncfusion/winui-demos";
        public static string UwpApiDocsLink => "https://help.syncfusion.com/cr/document-processing";
        public static string UWPUserGuideLink => "https://help.syncfusion.com/document-processing/introduction";
        public static string DocsLink => "https://help.syncfusion.com/document-processing/introduction";
        public static string DocsDesc => "The user guide documents for the Syncfusion Document SDK for WinUI.";
        public static string GitHubLink => "https://github.com/syncfusion/winui-demos";
        public static string GitHubDesc => "All showcase and basic feature samples for Syncfusion Document SDK for WinUI.";
        public static string FeatureLink => "https://www.syncfusion.com/document-sdk";
        public static string FeatureDesc => "Explore Syncfusion's Document SDK for WinUI: includes powerful PDF, Word, Excel and PowerPoint libraries.";
#else
        public static string ControlsGalleryText => "Gallery for WinUI";
        public static string UWPSamplesLink => "https://github.com/syncfusion/winui-demos";
        public static string UwpApiDocsLink => "https://help.syncfusion.com/cr/winui";
        public static string UWPUserGuideLink => "https://help.syncfusion.com/winui/overview";
        public static string DocsLink => "https://help.syncfusion.com/winui/overview"; 
        public static string DocsDesc => "The user guide documents for the Syncfusion WinUI controls.";
        public static string GitHubLink => "https://github.com/syncfusion/winui-demos";
        public static string GitHubDesc => "All showcase and basic feature samples for Syncfusion WinUI controls.";
        public static string FeatureLink => "https://www.syncfusion.com/winui-controls";
        public static string FeatureDesc => "Explore Syncfusion's WinUI controls: a concise overview of powerful features.";
#endif

    }

}