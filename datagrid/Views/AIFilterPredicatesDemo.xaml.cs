#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Syncfusion.UI.Xaml.Data;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DataGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AIFilterPredicatesDemo : Page, IDisposable
    {
        /// <summary>
        /// Holds the SemanticKernel AI service instance.
        /// </summary>
        private SemanticKernelAI semanticKernelAIService;

        /// <summary>
        /// Holds the result of the AI response.
        /// </summary>
        private string result;

        /// <summary>
        /// Holds the schema of the AIFilterPredicate.
        /// </summary>
        private string schema;

        public AIFilterPredicatesDemo()
        {
            this.InitializeComponent();
            semanticKernelAIService = new SemanticKernelAI();
            schema = GetSerializedFilterPredicate();
            this.executePromptButton.Click += OnExecutePrompt;
            this.resetButton.Click += OnReset;
            this.queryTextBox.KeyDown += QueryTextBox_KeyDown;
            this.semanticKernelAIService.IsCredentialsValid();
        }

        /// <summary>
        /// Handles the KeyDown event for the query text box. 
        /// Triggers the application of filters based on an AI query when the Enter key is pressed.
        /// </summary>
        /// <param name="sender">The source of the event, typically the query text box.</param>
        /// <param name="e">The key routed event arguments.</param>
        private void QueryTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key != Windows.System.VirtualKey.Enter)
                return;
            ApplyFiltersBasedOnAIQuery();
        }

        /// <summary>
        /// Event handler for the execute prompt button click event.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The routed event args.</param>
        private void OnExecutePrompt(object sender, RoutedEventArgs e)
        {
            ApplyFiltersBasedOnAIQuery();
        }

        /// <summary>
        /// Event handler for the reset button click event.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The routed event args.</param>
        private void OnReset(object sender, RoutedEventArgs e)
        {
            queryTextBox.Text = null;
            dataGrid.Columns.ForEach(column =>
            {
                column.FilterPredicates.Clear();
            });
        }

        /// <summary>
        /// Applies filters to the data grid based on a query processed by an AI service.
        /// </summary>
        public async void ApplyFiltersBasedOnAIQuery()
        {
            if (!string.IsNullOrEmpty(queryTextBox.Text))
            {
                var gridReportJson = GetSerializedGridReport(new EmployeeInfo());
                string userInput = ValidateAndGeneratePrompt(schema, queryTextBox.Text, gridReportJson);
                if (userInput != null && semanticKernelAIService.IsCredentialsValid())
                {
                    busyIndicator.Visibility = Visibility.Visible;
                    busyIndicator.IsActive = true;
                    result = await semanticKernelAIService.GetResponseFromGPT(userInput);
                    if (result != null)
                    {
                        try
                        {
                            result = result.Replace("json", "").Replace("```", "").Replace("\n", "");
                            string[] datas = result.Split(new char[] { ';' });
                            List<AIFilterPredicate> FilterPredicates = new List<AIFilterPredicate>();
                            foreach (var data in datas)
                            {
                                if (!string.IsNullOrEmpty(data))
                                {
                                    try
                                    {
                                        FilterPredicates.Add(GetDeserializedFilterPredicate(data));
                                    }
                                    catch 
                                    {
                                        busyIndicator.IsActive = false;
                                        busyIndicator.Visibility = Visibility.Collapsed;
                                        semanticKernelAIService.ShowErrorMessage("Error occurred while processing the AI response.");
                                        return;
                                    }
                                }
                            }
                            for (int i = 0; i < FilterPredicates.Count; i++)
                            {
                                if (FilterPredicates[i].ColumnName != null && dataGrid.Columns.Any(x => x.MappingName == FilterPredicates[i].ColumnName) && FilterPredicates[i].FilterPredicate != null)
                                    dataGrid.Columns[FilterPredicates[i].ColumnName].FilterPredicates.Add(FilterPredicates[i].FilterPredicate);
                                else
                                {
                                    busyIndicator.IsActive = false;
                                    busyIndicator.Visibility = Visibility.Collapsed;
                                    semanticKernelAIService.ShowErrorMessage("Invalid ColumnName / FilterPredicates. Kindly provide a proper query.");
                                    return;
                                }
                            }
                            busyIndicator.IsActive = false;
                            busyIndicator.Visibility = Visibility.Collapsed;

                        }
                        catch (Exception ex)
                        {
                            busyIndicator.IsActive = false;
                            busyIndicator.Visibility = Visibility.Collapsed;
                            semanticKernelAIService.ShowErrorMessage(ex.Message);
                        }
                    }
                    else
                    {
                        busyIndicator.IsActive = false;
                        busyIndicator.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        /// <summary>
        /// Serializes the provided <see cref="EmployeeInfo"/> object into a JSON string.
        /// </summary>
        /// <param name="report">The <see cref="EmployeeInfo"/> object to be serialized.</param>
        /// <returns>A JSON string representation of the <paramref name="report"/>.</returns>
        private string GetSerializedGridReport(EmployeeInfo report)
        {
            return JsonConvert.SerializeObject(report);
        }

        /// <summary>
        /// Validates the provided text and generates a formatted prompt string based on the specified model.
        /// </summary>
        /// <param name="filterPredicate">Serialized AIFilterPredicate schema.</param>
        /// <param name="text">The text representing the condition or query for filtering.</param>
        /// <param name="model">Generate the conditions based on model.</param>    
        private static string ValidateAndGeneratePrompt(string filterPredicate, string text, string model)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            return $"Generate the JSON of type AIFilterPredicate to filter the model\nModel : {model} for the given query\nQuery : {text} and the AIFilterPredicate schema is AIFilterPredicate : {filterPredicate}. Do not provide any additional information except the AIFilterPredicate as JSON object. If more than one AIFilterPredicate then seperate AIFilterPredicates using semi-colon. Rules for providing the responses : Should not include any unwanted brackets or special characters. Filter predicates should be separated by using a semicolon.";
        }

        /// <summary>
        /// Serializes the <see cref="AIFilterPredicate"/> object into a JSON string.
        /// </summary>
        private string GetSerializedFilterPredicate()
        {
            return "{\r\n  \"definitions\": {\r\n    \"FilterPredicate\": {\r\n      \"type\": [\r\n        \"object\",\r\n        \"null\"\r\n      ],\r\n      \"properties\": {\r\n        \"FilterType\": {\r\n          \"type\": \"string\",\r\n          \"enum\": [\r\n            \"LessThan\",\r\n            \"LessThanOrEqual\",\r\n            \"Equals\",\r\n            \"NotEquals\",\r\n            \"GreaterThanOrEqual\",\r\n            \"GreaterThan\",\r\n            \"StartsWith\",\r\n            \"NotStartsWith\",\r\n            \"EndsWith\",\r\n            \"NotEndsWith\",\r\n            \"Contains\",\r\n            \"NotContains\"\r\n          ]\r\n        },\r\n        \"FilterValue\": {},\r\n        \"PredicateType\": {\r\n          \"type\": \"string\",\r\n          \"enum\": [\r\n            \"And\",\r\n            \"Or\",\r\n            \"AndAlso\",\r\n            \"OrElse\"\r\n          ]\r\n        },\r\n        \"FilterBehavior\": {\r\n          \"type\": \"string\",\r\n          \"enum\": [\r\n            \"StronglyTyped\",\r\n            \"StringTyped\"\r\n          ]\r\n        },\r\n        \"IsCaseSensitive\": {\r\n          \"type\": \"boolean\"\r\n        },\r\n        \"FilterMode\": {\r\n          \"type\": \"string\",\r\n          \"enum\": [\r\n            \"Value\",\r\n            \"DisplayText\"\r\n          ]\r\n        }\r\n      },\r\n      \"required\": [\r\n        \"FilterType\",\r\n        \"FilterValue\",\r\n        \"PredicateType\",\r\n        \"FilterBehavior\",\r\n        \"IsCaseSensitive\",\r\n        \"FilterMode\"\r\n      ]\r\n    }\r\n  },\r\n  \"type\": \"object\",\r\n  \"properties\": {\r\n    \"ColumnName\": {\r\n      \"type\": [\r\n        \"string\",\r\n        \"null\"\r\n      ]\r\n    },\r\n    \"FilterPredicate\": {\r\n      \"$ref\": \"#/definitions/FilterPredicate\"\r\n    }\r\n  },\r\n  \"required\": [\r\n    \"ColumnName\",\r\n    \"FilterPredicate\"\r\n  ]\r\n}";
        }

        /// <summary>
        /// De-Serializes the provided string into a  <see cref="AIFilterPredicate"/>.
        /// </summary>
        /// <param name="report">String to be Deserialized.</param>
        private AIFilterPredicate GetDeserializedFilterPredicate(string report)
        {
            return JsonConvert.DeserializeObject<AIFilterPredicate>(report);
        }

        /// <summary>
        /// Releases the resources used by the <see cref="AIFilterPredicatesDemo"/> class, including both managed and unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.executePromptButton.Click -= OnExecutePrompt;
            this.resetButton.Click -= OnReset;
            this.queryTextBox.KeyDown -= QueryTextBox_KeyDown;
            schema = string.Empty;
            //Release all managed resources
            if (this.dataGrid != null)
            {
                this.dataGrid.Dispose();
                this.dataGrid = null;
            }

            if (this.DataContext != null)
            {
                var dataContext = this.Root_Grid.DataContext as EmployeeInfoViewModel;
                dataContext.Dispose();
                this.DataContext = null;
            }

            if (this.executePromptButton != null)
                this.executePromptButton = null;

            if (this.resetButton != null)
                this.resetButton = null;

            if (this.queryTextBox != null)
                this.queryTextBox = null;
        }
    }
}
