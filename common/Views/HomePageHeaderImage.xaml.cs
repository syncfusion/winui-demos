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
    /// <summary>
    /// Represents a page that displays a header image, potentially with text overlays, for a home page or landing section.
    /// It provides access to localized or conditionally compiled UI strings.
    /// </summary>
    public sealed partial class HomePageHeaderImage : Page
    {
        /// <summary>
        /// Gets the text for the "Controls Gallery" heading, which is provided by the `UIStringsProvider`.
        /// </summary>
        public string ControlsGalleryText => UIStringsProvider.ControlsGalleryText;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageHeaderImage"/> class.
        /// Calls <see cref="InitializeComponent"/> to load the XAML UI definitions.
        /// </summary>
        public HomePageHeaderImage()
        {
            this.InitializeComponent();
        }
    }

    /// <summary>
    /// Provides access to various UI strings used throughout the application.
    /// These strings can be conditionally compiled based on preprocessor directives (e.g., `DOCUMENT_SDK`)
    /// to support different versions or targets of the application.
    /// </summary>
    public static class UIStringsProvider
    {

#if DOCUMENT_SDK
        /// <summary>
        /// Gets the title for the Controls Gallery specific to the Document SDK.
        /// </summary>
        public static string ControlsGalleryText => "Document SDK for WinUI";
        /// <summary>
        /// Gets the link to the WinUI demos GitHub repository.
        /// </summary>
        public static string UWPSamplesLink => "https://github.com/syncfusion/winui-demos";
        /// <summary>
        /// Gets the link to the API documentation for the Document SDK.
        /// </summary>
        public static string UwpApiDocsLink => "https://help.syncfusion.com/cr/document-processing";
        /// <summary>
        /// Gets the link to the user guide for the Document SDK.
        /// </summary>
        public static string UWPUserGuideLink => "https://help.syncfusion.com/document-processing/introduction";
        /// <summary>
        /// Gets a general link to the documentation, specific to the Document SDK.
        /// </summary>
        public static string DocsLink => "https://help.syncfusion.com/document-processing/introduction";
        /// <summary>
        /// Gets a description for the documentation link related to the Document SDK.
        /// </summary>
        public static string DocsDesc => "The user guide documents for the Syncfusion Document SDK for WinUI.";
        /// <summary>
        /// Gets the link to the Syncfusion WinUI demos GitHub repository.
        /// </summary>
        public static string GitHubLink => "https://github.com/syncfusion/winui-demos";
        /// <summary>
        /// Gets a description for the GitHub link, detailing the content for the Document SDK WinUI demos.
        /// </summary>
        public static string GitHubDesc => "All showcase and basic feature samples for Syncfusion Document SDK for WinUI.";
        /// <summary>
        /// Gets a link to the main product page for the Syncfusion Document SDK.
        /// </summary>
        public static string FeatureLink => "https://www.syncfusion.com/document-sdk";
        /// <summary>
        /// Gets a description for the feature link, highlighting the capabilities of the Syncfusion Document SDK.
        /// </summary>
        public static string FeatureDesc => "Explore Syncfusion's Document SDK for WinUI: includes powerful PDF, Word, Excel and PowerPoint libraries.";
#else
        /// <summary>
        /// Gets the title for the Controls Gallery, general for WinUI.
        /// </summary>
        public static string ControlsGalleryText => "Gallery for WinUI";
        /// <summary>
        /// Gets the link to the general Syncfusion WinUI demos GitHub repository.
        /// </summary>
        public static string UWPSamplesLink => "https://github.com/syncfusion/winui-demos";
        /// <summary>
        /// Gets the link to the API documentation for Syncfusion WinUI controls.
        /// </summary>
        public static string UwpApiDocsLink => "https://help.syncfusion.com/cr/winui";
        /// <summary>
        /// Gets the link to the user guide for Syncfusion WinUI controls.
        /// </summary>
        public static string UWPUserGuideLink => "https://help.syncfusion.com/winui/overview";
        /// <summary>
        /// Gets a general link to the documentation for Syncfusion WinUI controls.
        /// </summary>
        public static string DocsLink => "https://help.syncfusion.com/winui/overview"; 
        /// <summary>
        /// Gets a description for the documentation link, referring to the user guide for Syncfusion WinUI controls.
        /// </summary>
        public static string DocsDesc => "The user guide documents for the Syncfusion WinUI controls.";
        /// <summary>
        /// Gets the link to the Syncfusion WinUI demos GitHub repository.
        /// </summary>
        public static string GitHubLink => "https://github.com/syncfusion/winui-demos";
        /// <summary>
        /// Gets a description for the GitHub link, detailing the content for the Syncfusion WinUI controls samples.
        /// </summary>
        public static string GitHubDesc => "All showcase and basic feature samples for Syncfusion WinUI controls.";
        /// <summary>
        /// Gets a link to the main product page for Syncfusion WinUI controls.
        /// </summary>
        public static string FeatureLink => "https://www.syncfusion.com/winui-controls";
        /// <summary>
        /// Gets a description for the feature link, providing a concise overview of Syncfusion WinUI controls' features.
        /// </summary>
        public static string FeatureDesc => "Explore Syncfusion's WinUI controls: a concise overview of powerful features.";
#endif

    }

}