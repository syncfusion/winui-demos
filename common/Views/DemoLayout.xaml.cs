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

        public DemoLayout()
        {
            this.InitializeComponent();
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

        private async void FormatAndRenderDemoFromString(String demoString, ContentPresenter presenter)
        {
            demoString = demoString.TrimStart('\n').TrimEnd();

            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
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
                Run run = new Run
                {
                    Text = demoString
                };

                Paragraph paragraph = new Paragraph();
                paragraph.Inlines.Add(run);
                richTextBlock.Blocks.Add(paragraph);
                presenter.Content = richTextBlock;
            });
        }
        
        private void OnValueChanged(DemoLayoutSubstitution sender, object e)
        {
            GenerateAllSyntaxHighlightedContent();
        }
    }
}