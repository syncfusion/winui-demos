#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Documents;
using Windows.UI.Core;
using Windows.ApplicationModel.DataTransfer;
using ColorCode;
using ColorCode.Common;

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// Represents a substitution object used for dynamically replacing placeholder values in code snippets.
    /// It allows enabling/disabling substitutions and notifies when the substituted value changes.
    /// </summary>
    public sealed class DemoLayoutSubstitution : DependencyObject
    {
        private object _value;
        private bool _enabled = true;

        /// <summary>
        /// Event raised when the SubstitutionValue or IsEnabled property changes.
        /// </summary>
        public event TypedEventHandler<DemoLayoutSubstitution, object> ValueChanged;

        /// <summary>
        /// Gets or sets a key that identifies this substitution. Used to match placeholders like "$(Key)".
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the actual value that will replace the placeholder identified by <see cref="Key"/>.
        /// </summary>
        public object SubstitutionValue
        {
            get { return _value; }
            set
            {
                _value = value;
                ValueChanged?.Invoke(this, null);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this substitution is currently active.
        /// </summary>
        public bool IsEnabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                ValueChanged?.Invoke(this, null);
            }
        }

        /// <summary>
        /// Returns the string representation of the SubstitutionValue if enabled and not null; otherwise, returns an empty string.
        /// </summary>
        /// <returns>The string value for substitution.</returns>
        public string ValueAsString()
        {
            if (!IsEnabled || SubstitutionValue == null)
            {
                return string.Empty;
            }

            return SubstitutionValue.ToString();
        }
    }

    /// <summary>
    /// Represents a layout control for displaying Syncfusion demo examples, including code snippets (XAML and C#).
    /// It supports dynamic substitution of values within code snippets, loading code from files, syntax highlighting, and copying code to clipboard.
    /// </summary>
    [ContentProperty(Name = "Example")]
    public sealed partial class DemoLayout : UserControl
    {
        /// <summary>
        /// To Merged the Resources properly with Resource Dictionary
        /// </summary>
        public ResourceDictionary ExternalResourceDictionary
        {
            get => this.Resources;
            set
            {
                foreach (var key in value.Keys)
                {
                    this.Resources[key] = value[key];
                }
            }
        }

        private DispatcherTimer timer;
        private ToolTip toolTip;
        private static readonly Regex SubstitutionPattern = new Regex(@"\$\(([^\)]+)\)");

        /// <summary>
        /// Identifies the HeaderText dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderTextProperty = DependencyProperty.Register(nameof(HeaderText), typeof(string), typeof(DemoLayout), new PropertyMetadata(null));
        /// <summary>
        /// Gets or sets the header text displayed for this demo layout.
        /// </summary>
        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }

        /// <summary>
        /// Identifies the Example dependency property. This property takes the main example content.
        /// </summary>
        public static readonly DependencyProperty ExampleProperty = DependencyProperty.Register(nameof(Example), typeof(object), typeof(DemoLayout), new PropertyMetadata(null));
        /// <summary>
        /// Gets or sets the primary example content (e.g., a UI element) to be displayed.
        /// </summary>
        public object Example
        {
            get { return GetValue(ExampleProperty); }
            set { SetValue(ExampleProperty, value); }
        }

        /// <summary>
        /// Identifies the Options dependency property. Typically used for configuration options related to the demo.
        /// </summary>
        public static readonly DependencyProperty OptionsProperty = DependencyProperty.Register(nameof(Options), typeof(object), typeof(DemoLayout), new PropertyMetadata(null));
        /// <summary>
        /// Gets or sets any additional options or configuration related to the demo.
        /// </summary>
        public object Options
        {
            get { return GetValue(OptionsProperty); }
            set { SetValue(OptionsProperty, value); }
        }

        /// <summary>
        /// Identifies the Xaml dependency property. Stores the XAML code snippet as a string.
        /// </summary>
        public static readonly DependencyProperty XamlProperty = DependencyProperty.Register(nameof(Xaml), typeof(string), typeof(DemoLayout), new PropertyMetadata(null));
        /// <summary>
        /// Gets or sets the XAML code snippet content as a string.
        /// </summary>
        public string Xaml
        {
            get { return (string)GetValue(XamlProperty); }
            set { SetValue(XamlProperty, value); }
        }

        /// <summary>
        /// Identifies the Xaml dependency property. Stores the XAML code snippet as a string.
        /// </summary>
        public static readonly DependencyProperty XamlSourceProperty = DependencyProperty.Register(nameof(XamlSource), typeof(string), typeof(DemoLayout), new PropertyMetadata(null));
        /// <summary>
        /// Gets or sets the XAML code snippet content as a string.
        /// </summary>
        public string XamlSource
        {
            get { return (string)GetValue(XamlSourceProperty); }
            set { SetValue(XamlSourceProperty, value); }
        }

        /// <summary>
        /// Identifies the CSharp dependency property. Stores the C# code snippet as a string.
        /// </summary>
        public static readonly DependencyProperty CSharpProperty = DependencyProperty.Register(nameof(Xaml), typeof(string), typeof(DemoLayout), new PropertyMetadata(null));
        /// <summary>
        /// Gets or sets the C# code snippet content as a string.
        /// </summary>
        public string CSharp
        {
            get { return (string)GetValue(CSharpProperty); }
            set { SetValue(CSharpProperty, value); }
        }

        /// <summary>
        /// Identifies the CSharpSource dependency property. Stores the URI to a file containing the C# code snippet.
        /// </summary>
        public static readonly DependencyProperty CSharpSourceProperty = DependencyProperty.Register(nameof(CSharpSource), typeof(string), typeof(DemoLayout), new PropertyMetadata(null));
        /// <summary>
        /// Gets or sets the URI to a file containing the C# code snippet. If set, this overrides the <see cref="CSharp"/> property.
        /// </summary>
        public string CSharpSource
        {
            get { return (string)GetValue(CSharpSourceProperty); }
            set { SetValue(CSharpSourceProperty, value); }
        }

        /// <summary>
        /// Identifies the Substitutions dependency property. A list of dynamic replacements for code snippets.
        /// </summary>
        public static readonly DependencyProperty SubstitutionsProperty = DependencyProperty.Register(nameof(Substitutions), typeof(IList<DemoLayoutSubstitution>), typeof(DemoLayout), new PropertyMetadata(new List<DemoLayoutSubstitution>()));
        /// <summary>
        /// Gets the list of <see cref="DemoLayoutSubstitution"/> objects that define dynamic replacements for placeholders within the code snippets.
        /// </summary>
        public IList<DemoLayoutSubstitution> Substitutions
        {
            get { return (IList<DemoLayoutSubstitution>)GetValue(SubstitutionsProperty); }
        }

        /// <summary>
        /// Identifies the HorizontalContentAlignment dependency property.
        /// </summary>
        public new static readonly DependencyProperty HorizontalContentAlignmentProperty = DependencyProperty.Register(nameof(HorizontalContentAlignment), typeof(HorizontalAlignment), typeof(DemoLayout), new PropertyMetadata(HorizontalAlignment.Stretch));
        /// <summary>
        /// Gets or sets the horizontal alignment of the content within the demo layout.
        /// </summary>
        public new HorizontalAlignment HorizontalContentAlignment
        {
            get { return (HorizontalAlignment)GetValue(HorizontalContentAlignmentProperty); }
            set { SetValue(HorizontalContentAlignmentProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value which indicates whether copy button is visible.
        /// </summary>
        internal Visibility IsCodeSnippetAvailable { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DemoLayout"/> class.
        /// Sets up the internal timer for copy feedback and a ToolTip.
        /// </summary>
        public DemoLayout()
        {
            this.InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Tick += Timer_Tick;
            toolTip = new ToolTip();
        }

        private void RootGridLoaded(object sender, RoutedEventArgs e)
        {
            foreach (var substitution in Substitutions)
            {
                substitution.ValueChanged += OnValueChanged;
            }
        }

        private void XamlPresenterLoaded(object sender, RoutedEventArgs e)
        {
            GenerateSyntaxHighlightedContent(sender as ContentPresenter, Xaml, XamlSource);
        }

        private void CSharpPresenterLoaded(object sender, RoutedEventArgs e)
        {
            GenerateSyntaxHighlightedContent(sender as ContentPresenter, CSharp, CSharpSource);
        }

        private void GenerateAllSyntaxHighlightedContent()
        {
            GenerateSyntaxHighlightedContent(XamlPresenter, Xaml, XamlSource);
            GenerateSyntaxHighlightedContent(CSharpPresenter, CSharp, CSharpSource);
        }

        private void GenerateSyntaxHighlightedContent(ContentPresenter presenter, string demoString, string demoUri)
        {
            if (!String.IsNullOrEmpty(demoString))
            {
                FormatAndRenderDemoFromString(demoString, presenter);
            }
            else
            {
                FormatAndRenderDemoFromFile(demoUri, presenter);
            }
        }

        private async void FormatAndRenderDemoFromFile(string source, ContentPresenter presenter)
        {
            string path = string.Empty;
            if (!string.IsNullOrEmpty(source))
            {
                path = FileLoader.GetFilePath(source);
            }

            if (path != null && System.IO.Path.GetExtension(path) == ".txt")
            {
                string demoSource = await FileLoader.LoadText(path).ConfigureAwait(false);
                FormatAndRenderDemoFromString(demoSource, presenter);
            }
            else
            {
                presenter.Visibility = Visibility.Collapsed;
            }
        }

        private void FormatAndRenderDemoFromString(String demoString, ContentPresenter presenter)
        {
            demoString = demoString.TrimStart('\n').TrimEnd();

            this.DispatcherQueue.TryEnqueue(() =>
            {
                demoString = SubstitutionPattern.Replace(demoString, match =>
                {
                    foreach (var substitution in this.Substitutions)
                    {
                        if (substitution.Key == match.Groups[1].Value)
                        {
                            return substitution.ValueAsString();
                        }
                    }
                    throw new KeyNotFoundException(match.Groups[1].Value);
                });

                RichTextBlock richTextBlock = new RichTextBlock() { FontFamily = new FontFamily("Consolas") };
                ILanguage highlightLanguage = presenter.Name.Contains("XamlPresenter") ? Languages.Xml : Languages.CSharp;
                GenerateRichTextFormatter().FormatRichTextBlock(demoString, highlightLanguage, richTextBlock);
                presenter.Content = richTextBlock;
            });
        }

        private RichTextBlockFormatter GenerateRichTextFormatter()
        {
            ElementTheme currentTheme = ThemeHelper.IsDarkTheme() ? ElementTheme.Dark : ElementTheme.Light;
            RichTextBlockFormatter formatter = new RichTextBlockFormatter(currentTheme);
            if (currentTheme == ElementTheme.Dark)
            {
                UpdateFormatterDarkThemeColors(formatter);
            }
            return formatter;
        }

        private void UpdateFormatterDarkThemeColors(RichTextBlockFormatter formatter)
        {
            // Replace the default dark theme resources.
            formatter.Styles.Remove(formatter.Styles[ScopeName.XmlAttribute]);
            formatter.Styles.Remove(formatter.Styles[ScopeName.XmlAttributeQuotes]);
            formatter.Styles.Remove(formatter.Styles[ScopeName.XmlAttributeValue]);
            formatter.Styles.Remove(formatter.Styles[ScopeName.HtmlComment]);
            formatter.Styles.Remove(formatter.Styles[ScopeName.XmlDelimiter]);
            formatter.Styles.Remove(formatter.Styles[ScopeName.XmlName]);

            formatter.Styles.Add(new ColorCode.Styling.Style(ScopeName.XmlAttribute)
            {
                Foreground = "#FF87CEFA",
                ReferenceName = "xmlAttribute"
            });
            formatter.Styles.Add(new ColorCode.Styling.Style(ScopeName.XmlAttributeQuotes)
            {
                Foreground = "#FFFFA07A",
                ReferenceName = "xmlAttributeQuotes"
            });
            formatter.Styles.Add(new ColorCode.Styling.Style(ScopeName.XmlAttributeValue)
            {
                Foreground = "#FFFFA07A",
                ReferenceName = "xmlAttributeValue"
            });
            formatter.Styles.Add(new ColorCode.Styling.Style(ScopeName.HtmlComment)
            {
                Foreground = "#FF6B8E23",
                ReferenceName = "htmlComment"
            });
            formatter.Styles.Add(new ColorCode.Styling.Style(ScopeName.XmlDelimiter)
            {
                Foreground = "#FF808080",
                ReferenceName = "xmlDelimiter"
            });
            formatter.Styles.Add(new ColorCode.Styling.Style(ScopeName.XmlName)
            {
                Foreground = "#FF5F82E8",
                ReferenceName = "xmlName"
            });
        }

        private void OnValueChanged(DemoLayoutSubstitution sender, object e)
        {
            //GenerateAllSyntaxHighlightedContent();
        }

        private void CopyButtonClick(object sender, RoutedEventArgs e)
        {
            string content = string.Empty;
            RichTextBlock richTextBlock;

            if (this.XamlPresenter.Content is RichTextBlock)
            {
                richTextBlock = this.XamlPresenter.Content as RichTextBlock;
                richTextBlock.SelectAll();
                content += richTextBlock.SelectedText;
            }

            if (this.CSharpPresenter.Content is RichTextBlock)
            {
                richTextBlock = this.CSharpPresenter.Content as RichTextBlock;
                richTextBlock.SelectAll();
                content += "\n\n\n" + richTextBlock.SelectedText;
            }

            DataPackage dataPackage = new DataPackage();
            dataPackage.SetText(content);
            Clipboard.SetContent(dataPackage);
            timer.Stop();
            toolTip.Content = "Copied";
            ToolTipService.SetToolTip(CopyButton, toolTip);
            CopyIcon.Glyph = "\uF78C";
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            toolTip.Content = "Copy";
            ToolTipService.SetToolTip(CopyButton, toolTip);
            CopyIcon.Glyph = "\uE8C8";
            timer.Stop();
        }
    }
}