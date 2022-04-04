#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
#if WinUI_Desktop
using ColorCode;
using ColorCode.Common;
#endif

namespace syncfusion.demoscommon.winui
{
    public sealed class DemoLayoutSubstitution : DependencyObject
    {
        private object _value;
        private bool _enabled = true;
        public event TypedEventHandler<DemoLayoutSubstitution, object> ValueChanged;

        public string Key { get; set; }

        public object SubstitutionValue
        {
            get { return _value; }
            set
            {
                _value = value;
                ValueChanged?.Invoke(this, null);
            }
        }

        public bool IsEnabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                ValueChanged?.Invoke(this, null);
            }
        }

        public string ValueAsString()
        {
            if (!IsEnabled || SubstitutionValue == null)
            {
                return string.Empty;
            }

            return SubstitutionValue.ToString();
        }
    }

    [ContentProperty(Name = "Example")]
    public sealed partial class DemoLayout : UserControl
    {
        private DispatcherTimer timer;
        private ToolTip toolTip;
        private static readonly Regex SubstitutionPattern = new Regex(@"\$\(([^\)]+)\)");

        public static readonly DependencyProperty HeaderTextProperty = DependencyProperty.Register(nameof(HeaderText), typeof(string), typeof(DemoLayout), new PropertyMetadata(null));
        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }

        public static readonly DependencyProperty ExampleProperty = DependencyProperty.Register(nameof(Example), typeof(object), typeof(DemoLayout), new PropertyMetadata(null));
        public object Example
        {
            get { return GetValue(ExampleProperty); }
            set { SetValue(ExampleProperty, value); }
        }

        public static readonly DependencyProperty OptionsProperty = DependencyProperty.Register(nameof(Options), typeof(object), typeof(DemoLayout), new PropertyMetadata(null));
        public object Options
        {
            get { return GetValue(OptionsProperty); }
            set { SetValue(OptionsProperty, value); }
        }

        public static readonly DependencyProperty XamlProperty = DependencyProperty.Register(nameof(Xaml), typeof(string), typeof(DemoLayout), new PropertyMetadata(null));
        public string Xaml
        {
            get { return (string)GetValue(XamlProperty); }
            set { SetValue(XamlProperty, value); }
        }

        public static readonly DependencyProperty XamlSourceProperty = DependencyProperty.Register(nameof(XamlSource), typeof(string), typeof(DemoLayout), new PropertyMetadata(null));
        public string XamlSource
        {
            get { return (string)GetValue(XamlSourceProperty); }
            set { SetValue(XamlSourceProperty, value); }
        }

        public static readonly DependencyProperty CSharpProperty = DependencyProperty.Register(nameof(Xaml), typeof(string), typeof(DemoLayout), new PropertyMetadata(null));
        public string CSharp
        {
            get { return (string)GetValue(CSharpProperty); }
            set { SetValue(CSharpProperty, value); }
        }

        public static readonly DependencyProperty CSharpSourceProperty = DependencyProperty.Register(nameof(CSharpSource), typeof(string), typeof(DemoLayout), new PropertyMetadata(null));
        public string CSharpSource
        {
            get { return (string)GetValue(CSharpSourceProperty); }
            set { SetValue(CSharpSourceProperty, value); }
        }

        public static readonly DependencyProperty SubstitutionsProperty = DependencyProperty.Register(nameof(Substitutions), typeof(IList<DemoLayoutSubstitution>), typeof(DemoLayout), new PropertyMetadata(new List<DemoLayoutSubstitution>()));
        public IList<DemoLayoutSubstitution> Substitutions
        {
            get { return (IList<DemoLayoutSubstitution>)GetValue(SubstitutionsProperty); }
        }

        public new static readonly DependencyProperty HorizontalContentAlignmentProperty = DependencyProperty.Register(nameof(HorizontalContentAlignment), typeof(HorizontalAlignment), typeof(DemoLayout), new PropertyMetadata(HorizontalAlignment.Stretch));
        public new HorizontalAlignment HorizontalContentAlignment
        {
            get { return (HorizontalAlignment)GetValue(HorizontalContentAlignmentProperty); }
            set { SetValue(HorizontalContentAlignmentProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value which indicates whether copy button is visible.
        /// </summary>
        internal Visibility CopyButtonVisibility { get; set; }

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
#if !WinUI_Desktop
                Run run = new Run
                {
                    Text = demoString
                };

                Paragraph paragraph = new Paragraph();
                paragraph.Inlines.Add(run);
                richTextBlock.Blocks.Add(paragraph);
                presenter.Content = richTextBlock;
#else
                ILanguage highlightLanguage = presenter.Name.Contains("XamlPresenter") ? Languages.Xml : Languages.CSharp;
                GenerateRichTextFormatter().FormatRichTextBlock(demoString, highlightLanguage, richTextBlock);
                presenter.Content = richTextBlock;
#endif
            });
        }

#if WinUI_Desktop
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
#endif

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