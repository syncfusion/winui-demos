#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DemosCommon.WinUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.ChartDemos.WinUI
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            #region Cartesian Chart

            #region Column Chart

            DemoInfo columnSamples = new DemoInfo()
            {
                Name = "Column",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description= "This sample showcases a column chart that uses vertical bars to display different values or data points.",
            };

            DemoInfo columnChartSample = new DemoInfo()
            {
                Name = "Default column",
                Category = "Basic Charts",
                DemoView = typeof(Views.ColumnChart),
                ShowInfoPanel = true,
            };

            List<Documentation> columnChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Column Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ColumnSeries.html")},
                new Documentation(){ Content = "Column Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/column")},
            };
            columnChartSample.Documentation.AddRange(columnChartDocumentation);

            DemoInfo columnWidthSample = new DemoInfo()
            {
                Name = "Column spacing",
                Category = "Basic Charts",
                DemoView = typeof(Views.ColumnWidthCustomization),
            };

            DemoInfo columnRoundedCornerSample = new DemoInfo()
            {
                Name = "Column with rounded corners",
                Category = "Basic Charts",
                DemoView = typeof(Views.ColumnRoundedEdges),
            };

            List<DemoInfo> subColumnDemos = new List<DemoInfo>();

            subColumnDemos.Add(columnChartSample);
            subColumnDemos.Add(columnRoundedCornerSample);
            subColumnDemos.Add(columnWidthSample);

            columnSamples.SubCategoryDemos = subColumnDemos;

            #endregion

            #region Bar Chart

            DemoInfo barSamples = new DemoInfo()
            {
                Name = "Bar",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description= "This sample demonstrates a bar chart utilizing horizontal columns to showcase various data points."
            };

            DemoInfo barChartSample = new DemoInfo()
            {
                Name = "Default bar",
                Category = "Basic Charts",
                DemoView = typeof(Views.BarChart),
                ShowInfoPanel= true,
            };

            List<Documentation> barChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Column Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ColumnSeries.html")},
                new Documentation(){ Content = "Column Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/column")},
            };
            barChartSample.Documentation.AddRange(barChartDocumentation);

            DemoInfo barWidthSample = new DemoInfo()
            {
                Name = "Bar spacing",
                Category = "Basic Charts",
                DemoView = typeof(Views.BarWidthCustomization),
            };

            DemoInfo barRoundedCornerSample = new DemoInfo()
            {
                Name = "Bar with rounded corners",
                Category = "Basic Charts",
                DemoView = typeof(Views.BarRoundedEdge),
            };

            List<DemoInfo> subBarDemos = new List<DemoInfo>();

            subBarDemos.Add(barChartSample);
            subBarDemos.Add(barRoundedCornerSample);
            subBarDemos.Add(barWidthSample);

            barSamples.SubCategoryDemos = subBarDemos;

            #endregion

            #region Line Chart

            DemoInfo lineSamples = new DemoInfo()
            {
                Name = "Line",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description= "This sample showcases line chart which  represents the data trends at equal intervals by connecting points on a plot with straight lines."
            };

            DemoInfo lineChartSample = new DemoInfo()
            {
                Name = "Default line",
                Category = "Basic Charts",
                DemoView = typeof(Views.LineChart),
                ShowInfoPanel = true
            };

            List<Documentation> lineChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Line Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.LineSeries.html")},
                new Documentation(){ Content = "Line Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/line")},
            };
            lineChartSample.Documentation.AddRange(lineChartDocumentation);

            DemoInfo linewithDashesSample = new DemoInfo()
            {
                Name = "Line with dashes",
                Category = "Basic Charts",
                DemoView = typeof(Views.DashedLineChart),
            };

            List<DemoInfo> subLineDemos = new List<DemoInfo>();

            subLineDemos.Add(lineChartSample);
            subLineDemos.Add(linewithDashesSample);

            lineSamples.SubCategoryDemos = subLineDemos;

            #endregion

            #region Area Chart

            DemoInfo areaChartSample = new DemoInfo()
            {
                Name = "Area",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.AreaChart),
                ShowInfoPanel = true
            };
            List<Documentation> areaChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Area Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.AreaSeries.html")},
                new Documentation(){ Content = "Area Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/area")},
            };
            areaChartSample.Documentation.AddRange(areaChartDocumentation);

            #endregion

            #region Bubble

            DemoInfo bubbleSamples = new DemoInfo()
            {
                Name = "Bubble",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description= "This sample showcases a bubble chart, which is an extension of the scatter chart, where each data point is represented by a circle."
            };

            DemoInfo bubbleChartSample = new DemoInfo()
            {
                Name = "Default bubble",
                Category = "Basic Charts",
                DemoView = typeof(Views.BubbleChart),
                ShowInfoPanel = true
            };
            List<Documentation> bubbleChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Bubble Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.BubbleSeries.html")},
                new Documentation(){ Content = "Bubble Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/bubble")},
            };
            bubbleChartSample.Documentation.AddRange(bubbleChartDocumentation);

            DemoInfo gradientBubbleSample = new DemoInfo()
            {
                Name = "Bubble filled with gradient",
                Category = "Basic Charts",
                DemoView = typeof(Views.MultipleColorBubbleSeries),
            };

            List<DemoInfo> subbubbleDemos = new List<DemoInfo>();

            subbubbleDemos.Add(bubbleChartSample);
            subbubbleDemos.Add(gradientBubbleSample);

            bubbleSamples.SubCategoryDemos = subbubbleDemos;

            #endregion

            #region Scatter

            DemoInfo scatterSamples = new DemoInfo()
            {
                Name = "Scatter",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
            };

            DemoInfo scatterChartSample = new DemoInfo()
            {
                Name = "Default scatter",
                Category = "Basic Charts",
                DemoView = typeof(Views.ScatterChart),
                ShowInfoPanel = true
            };

            List<Documentation> scatterChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Scatter Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ScatterSeries.html")},
                new Documentation(){ Content = "Scatter Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/scatter")},
            };
            scatterChartSample.Documentation.AddRange(scatterChartDocumentation);

            DemoInfo customScatterSample = new DemoInfo()
            {
                Name = "Customized scatter",
                Category = "Basic Charts",
                DemoView = typeof(Views.CustomScatterSeries),
            };

            List<DemoInfo> subScatterDemos = new List<DemoInfo>();

            subScatterDemos.Add(scatterChartSample);
            subScatterDemos.Add(customScatterSample);

            scatterSamples.SubCategoryDemos = subScatterDemos;

            #endregion

            #region Spline Chart

            DemoInfo splineSamples = new DemoInfo()
            {
                Name = "Spline",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description= "This sample showcases a spline chart that connects two data points using curves instead of straight lines."
            };

            DemoInfo splineChartSample = new DemoInfo()
            {
                Name = "Default spline",
                Category = "Basic Charts",
                DemoView = typeof(Views.SplineChart),
                ShowInfoPanel = true
            };

            List<Documentation> splineChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Spline Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.SplineSeries.html")},
                new Documentation(){ Content = "Spline Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/line#spline-chart")},
            };
            splineChartSample.Documentation.AddRange(splineChartDocumentation);

            DemoInfo splinewithDashesSample = new DemoInfo()
            {
                Name = "Spline with dashes",
                Category = "Basic Charts",
                DemoView = typeof(Views.DashedSplineChart),
            };

            DemoInfo customSplineSample = new DemoInfo()
            {
                Name = "Customized spline",
                Category = "Basic Charts",
                DemoView = typeof(Views.CustomSplineSeries),
            };

            List<DemoInfo> subSplineDemos = new List<DemoInfo>();

            subSplineDemos.Add(splineChartSample);
            subSplineDemos.Add(splinewithDashesSample);
            subSplineDemos.Add(customSplineSample);

            splineSamples.SubCategoryDemos = subSplineDemos;

            #endregion

            #region Spline Area

            DemoInfo splineAreaChartSample = new DemoInfo()
            {
                Name = "Spline Area",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.SplineAreaChart),
                ShowInfoPanel = true
            };

            List<Documentation> splineAreaChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Spline Area Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.SplineAreaSeries.html")},
                new Documentation(){ Content = "Spline Area Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/area#spline-area-chart")},
            };
            splineAreaChartSample.Documentation.AddRange(splineAreaChartDocumentation);

            #endregion

            #region Step Line Chart

            DemoInfo stepLineSamples = new DemoInfo()
            {
                Name = "Step Line",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description= "This sample showcases a step line chart that connects data points using horizontal and vertical lines, resulting in a step-like progression."
            };

            DemoInfo steplineChartSample = new DemoInfo()
            {
                Name = "Default step line",
                Category = "Basic Charts",
                DemoView = typeof(Views.StepLineChart),
                ShowInfoPanel = true
            };

            List<Documentation> steplineChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Step Line Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StepLineSeries.html")},
                new Documentation(){ Content = "Step Line Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/line#step-line-chart")},
            };
            steplineChartSample.Documentation.AddRange(steplineChartDocumentation);

            DemoInfo steplinewithDashesSample = new DemoInfo()
            {
                Name = "Step line with dashes",
                Category = "Basic Charts",
                DemoView = typeof(Views.DottedStepLine),
            };

            DemoInfo VerticalsteplineSample = new DemoInfo()
            {
                Name = "Vertical step line",
                Category = "Basic Charts",
                DemoView = typeof(Views.VerticalStepLine),
            };

            List<DemoInfo> subStepLineDemos = new List<DemoInfo>();

            subStepLineDemos.Add(steplineChartSample);
            subStepLineDemos.Add(steplinewithDashesSample);
            subStepLineDemos.Add(VerticalsteplineSample);

            stepLineSamples.SubCategoryDemos = subStepLineDemos;

            #endregion

            #region Step Area

            DemoInfo stepAreaChartSample = new DemoInfo()
            {
                Name = "Step Area",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.StepAreaChart),
                ShowInfoPanel = true
            };

            List<Documentation> stepAreaChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Step Area Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StepAreaSeries.html")},
                new Documentation(){ Content = "Step Area Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/area#step-area-chart")},
            };
            stepAreaChartSample.Documentation.AddRange(stepAreaChartDocumentation);

            #endregion

            #region Fast Charts

            DemoInfo fastChartSamples = new DemoInfo()
            {
                Name = "Fast Charts",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
            };

            DemoInfo fastLineSample = new DemoInfo()
            {
                Name = "Fast line",
                Category = "Basic Charts",
                DemoView = typeof(Views.FastLineChart),
                ShowInfoPanel = true
            };

            List<Documentation> fastLineChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Fast Line Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.FastLineSeries.html")},
                new Documentation(){ Content = "Fast Line Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/fastcharts/fast-line")},
            };
            fastLineSample.Documentation.AddRange(fastLineChartDocumentation);

            DemoInfo fastStepLineSample = new DemoInfo()
            {
                Name = "Fast step line",
                Category = "Basic Charts",
                DemoView = typeof(Views.FastStepLineChart),
                ShowInfoPanel = true
            };

            List<Documentation> fastStepLineChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Fast Step Line Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.FastStepLineBitmapSeries.html")},
                new Documentation(){ Content = "Fast Step Line Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/fastcharts/fast-stepline")},
            };
            fastStepLineSample.Documentation.AddRange(fastStepLineChartDocumentation);

            DemoInfo fastScatterSample = new DemoInfo()
            {
                Name = "Fast scatter",
                Category = "Basic Charts",
                DemoView = typeof(Views.FastScatterChart),
                ShowInfoPanel = true
            };

            List<Documentation> fastScatterChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Fast Scatter Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.FastScatterBitmapSeries.html")},
                new Documentation(){ Content = "Fast Scatter Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/fastcharts/fast-scatter")},
            };
            fastScatterSample.Documentation.AddRange(fastScatterChartDocumentation);

            DemoInfo fastColumnSample = new DemoInfo()
            {
                Name = "Fast column",
                Category = "Basic Charts",
                DemoView = typeof(Views.FastColumnChart),
                ShowInfoPanel = true
            };

            List<Documentation> fastColumnChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Fast Column Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.FastColumnBitmapSeries.html")},
                new Documentation(){ Content = "Fast Column Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/fastcharts/fast-column")},
            };
            fastColumnSample.Documentation.AddRange(fastColumnChartDocumentation);

            List<DemoInfo> subFastChartsDemos = new List<DemoInfo>();

            subFastChartsDemos.Add(fastColumnSample);
            subFastChartsDemos.Add(fastLineSample);
            subFastChartsDemos.Add(fastStepLineSample);
            subFastChartsDemos.Add(fastScatterSample);

            fastChartSamples.SubCategoryDemos = subFastChartsDemos;

            #endregion

            #region Stacked Charts

            DemoInfo stackedChartSamples = new DemoInfo()
            {
                Name = "Stacked Charts",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
            };

            DemoInfo stackedAreaSample = new DemoInfo()
            {
                Name = "Stacked area",
                Category = "Basic Charts",
                DemoView = typeof(Views.StackingAreaChart),
                ShowInfoPanel = true
            };

            List<Documentation> stackedAreaChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Stacked Area Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StackedAreaSeries.html")},
                new Documentation(){ Content = "Stacked Area Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/stacked#stacked-area-chart")},
            };
            stackedAreaSample.Documentation.AddRange(stackedAreaChartDocumentation);

            DemoInfo stackedColumnSample = new DemoInfo()
            {
                Name = "Stacked column",
                Category = "Basic Charts",
                DemoView = typeof(Views.StackingColumnChart),
                ShowInfoPanel = true
            };

            List<Documentation> stackedColumnChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Stacked Column Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StackedColumnSeries.html")},
                new Documentation(){ Content = "Stacked Column Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/stacked#stacked-column-chart")},
            };
            stackedColumnSample.Documentation.AddRange(stackedColumnChartDocumentation);

            DemoInfo stackedLineSample = new DemoInfo()
            {
                Name = "Stacked line",
                Category = "Basic Charts",
                DemoView = typeof(Views.StackingLineChart),
                ShowInfoPanel = true
            };

            List<Documentation> stackedLineChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Stacked Line Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StackedLineSeries.html")},
                new Documentation(){ Content = "Stacked Line Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/stacked#stacked-line-chart")},
            };
            stackedLineSample.Documentation.AddRange(stackedLineChartDocumentation);

            DemoInfo stackedGroupSample = new DemoInfo()
            {
                Name = "Stacked group",
                Category = "Basic Charts",
                DemoView = typeof(Views.Grouping),
                ShowInfoPanel = true
            };

            List<Documentation> stackedGroupDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Grouping API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StackedSeriesBase.html#Syncfusion_UI_Xaml_Charts_StackedSeriesBase_GroupName")},
                new Documentation(){ Content = "Grouping Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/groupingstacked")},
            };
            stackedGroupSample.Documentation.AddRange(stackedGroupDocumentation);


            List<DemoInfo> subStackedChartsDemos = new List<DemoInfo>();

            subStackedChartsDemos.Add(stackedColumnSample);
            subStackedChartsDemos.Add(stackedLineSample);
            subStackedChartsDemos.Add(stackedAreaSample);
            subStackedChartsDemos.Add(stackedGroupSample);

            stackedChartSamples.SubCategoryDemos = subStackedChartsDemos;

            #endregion

            #region 100% Stacked Chart

            DemoInfo stacked100ChartSamples = new DemoInfo()
            {
                Name = "100% Stacked Charts",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
            };

            DemoInfo stackedArea100Sample = new DemoInfo()
            {
                Name = "100% stacked area",
                Category = "Basic Charts",
                DemoView = typeof(Views.StackingArea100Chart),
                ShowInfoPanel = true
            };

            List<Documentation> stackedArea100ChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Stacked Area 100 Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StackedArea100Series.html")},
                new Documentation(){ Content = "Stacked Area 100 Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/stacked100#stacked-area-100-chart")},
            };
            stackedArea100Sample.Documentation.AddRange(stackedArea100ChartDocumentation);

            DemoInfo stackedColumn100Sample = new DemoInfo()
            {
                Name = "100% stacked column",
                Category = "Basic Charts",
                DemoView = typeof(Views.StackingColumn100Chart),
                ShowInfoPanel = true
            };

            List<Documentation> stackedColumn100ChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Stacked Column 100 Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StackedColumn100Series.html")},
                new Documentation(){ Content = "Stacked Column 100 Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/stacked100#stacked-column-100-chart")},
            };
            stackedColumn100Sample.Documentation.AddRange(stackedColumn100ChartDocumentation);

            DemoInfo stackedLine100Sample = new DemoInfo()
            {
                Name = "100% stacked line",
                Category = "Basic Charts",
                DemoView = typeof(Views.StackingLine100Chart),
                ShowInfoPanel = true
            };

            List<Documentation> stackedLine100ChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Stacked Line 100 Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StackedLine100Series.html")},
                new Documentation(){ Content = "Stacked Line 100 Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/stacked100#stacked-line-100-chart")},
            };
            stackedLine100Sample.Documentation.AddRange(stackedLine100ChartDocumentation);


            List<DemoInfo> substacked100ChartDemos = new List<DemoInfo>();

            substacked100ChartDemos.Add(stackedColumn100Sample);
            substacked100ChartDemos.Add(stackedArea100Sample);
            substacked100ChartDemos.Add(stackedLine100Sample);

            stacked100ChartSamples.SubCategoryDemos = substacked100ChartDemos;

            #endregion

            #region Interactive Feautures

            // Crosshair
            DemoInfo crossHairSample = new DemoInfo()
            {
                Name = "Crosshair",
                Category = "Interaction",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Crosshair),
                ShowInfoPanel = true
            };

            List<Documentation> crosshairDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Crosshair API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartCrosshairBehavior.html")},
                new Documentation(){ Content = "Crosshair Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/interactive-features/crosshair")},
            };
            crossHairSample.Documentation.AddRange(crosshairDocumentation);

            //Tooltip 

            DemoInfo tooltipSample = new DemoInfo()
            {
                Name = "Tooltip",
                Category = "Interaction",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Tooltip),
                ShowInfoPanel = true
            };

            List<Documentation> tooltipDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Tooltip API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartTooltipBehavior.html")},
                new Documentation(){ Content = "Cartesian Chart Tooltip Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/tooltip")},
            };
            tooltipSample.Documentation.AddRange(tooltipDocumentation);

            // Trackball
            DemoInfo trackballSample = new DemoInfo()
            {
                Name = "Trackball",
                Category = "Interaction",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Trackball),
                ShowInfoPanel = true
            };

            List<Documentation> trackballDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Trackball API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartTrackballBehavior.html")},
                new Documentation(){ Content = "Trackball Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/trackball")},
            };
            trackballSample.Documentation.AddRange(trackballDocumentation);

            // Selection

            DemoInfo cartesianSelectionSamples = new DemoInfo()
            {
                Name = "Selection",
                Category = "Interaction",
                DemoType = DemoTypes.None,
                Description= "This sample showcases selection behavior which allows you to select either a data point or series based on the segment or series selection."
            };

            DemoInfo dataPointSelectionSample = new DemoInfo()
            {
                Name = "Data point selection",
                Category = "Interaction",
                DemoView = typeof(Views.DataPointSelection),
                ShowInfoPanel = true
            };

            List<Documentation> dataPointSelectionDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "DataPoint Selection API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.DataPointSelectionBehavior.html")},
                new Documentation(){ Content = "DataPoint Selection Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/selection#enable-datapoint-selection")},
            };
            dataPointSelectionSample.Documentation.AddRange(dataPointSelectionDocumentation);

            DemoInfo seriesSelectionSample = new DemoInfo()
            {
                Name = "Series selection",
                Category = "Interaction",
                DemoView = typeof(Views.SeriesSelection),
                ShowInfoPanel= true
            };

            List<Documentation> seriesSelectionDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Series Selection API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.SeriesSelectionBehavior.html")},
                new Documentation(){ Content = "Series Selection Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/selection#enable-series-selection")},
            };
            seriesSelectionSample.Documentation.AddRange(seriesSelectionDocumentation);

            List<DemoInfo> subSelectionDemos = new List<DemoInfo>();

            subSelectionDemos.Add(dataPointSelectionSample);
            subSelectionDemos.Add(seriesSelectionSample);

            cartesianSelectionSamples.SubCategoryDemos = subSelectionDemos;

            //Zooming and Panning

            DemoInfo zoomingSample = new DemoInfo()
            {
                Name = "Zooming and Panning",
                Category = "Interaction",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.ZoomPanBehavior),
                ShowInfoPanel = true
            };

            List<Documentation> zoomingDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Zooming and Panning API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartZoomPanBehavior.html")},
                new Documentation(){ Content = "Zooming and Panning Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/zooming-and-panning")},
            };
            zoomingSample.Documentation.AddRange(zoomingDocumentation);

            #endregion

            #region Legend

            DemoInfo cartesianLegendToggleSample = new DemoInfo()
            {
                Name = "Default Legend",
                Category = "Legend",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.CartesianLegendToggle),
                ShowInfoPanel=true,
                Description= "This sample showcases the toggled legend, which allows individuals to enable or disable series by tapping on the legend."
            };

            List<Documentation> cartesianLegendToggleDocumentation = new List<Documentation>()
            {
                 new Documentation(){ Content = "Legend API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartLegend.html")},
                 new Documentation(){ Content = "Cartesian Chart Legend Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/legend")},
            };
            cartesianLegendToggleSample.Documentation.AddRange(cartesianLegendToggleDocumentation);

            DemoInfo cartesianLegendSample = new DemoInfo()
            {
                Name = "Customized Legend",
                Category = "Legend",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Cartesian_Legend),
                ShowInfoPanel = true,
                Description= "This sample showcases the customized legend, which allows individuals to personalize both its appearance and content to suit their preferences."
            };

            List<Documentation> cartesianLegendDocumentation = new List<Documentation>()
            {
               new Documentation(){ Content = "Legend Template API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartLegend.html#Syncfusion_UI_Xaml_Charts_ChartLegend_ItemTemplate")},
               new Documentation(){ Content = "Cartesian Chart Legend Template Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/legend#template")},
            };
            cartesianLegendSample.Documentation.AddRange(cartesianLegendDocumentation);

            #endregion

            #region Axis

            DemoInfo categorySample = new DemoInfo()
            {
                Name = "Category",
                Category = "Axis",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.CategoryAxis),
                ShowInfoPanel = true,
                Description= "This sample showcases the category axis, which plots values based on the index of the data point collection."
            };

            List<Documentation> categoryDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Category Axis API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.CategoryAxis.html?tabs=tabid-1%2Ctabid-3%2Ctabid-5")},
                new Documentation(){ Content = "Category Axis Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/axis/types#category-axis")},
            };
            categorySample.Documentation.AddRange(categoryDocumentation);

            DemoInfo numericalSample = new DemoInfo()
            {
                Name = "Numerical",
                Category = "Axis",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.NumericalAxis),
                ShowInfoPanel = true,
                Description= "This sample showcases the numerical axis, which is used to display a range of numerical values for data analysis and comparison."
            };

            List<Documentation> numericalDocumentation = new List<Documentation>()
            {
               new Documentation(){ Content = "Numerical Axis API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.NumericalAxis.html")},
               new Documentation(){ Content = "Numerical Axis Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/axis/types#numerical-axis")},
            };
            numericalSample.Documentation.AddRange(numericalDocumentation);

            DemoInfo dateTimeSample = new DemoInfo()
            {
                Name = "Date Time",
                Category = "Axis",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.DateTimeAxis),
                ShowInfoPanel = true,
                Description= "This sample showcases the date-time axis, which is used to plot and visualize DateTime values."
            };

            List<Documentation> dateTimeDocumentation = new List<Documentation>()
            {
               new Documentation(){ Content = "DateTime Axis API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.DateTimeAxis.html")},
               new Documentation(){ Content = "DateTime Axis Documentation", Uri = new Uri("https://help.syncfusion.com/winui/cartesian-charts/axis/types#datetime-axis")},
            };
            dateTimeSample.Documentation.AddRange(dateTimeDocumentation);

            #endregion

            #endregion

            #region Circular Charts

            #region Pie

            DemoInfo pieSamples = new DemoInfo()
            {
                Name = "Pie",
                Category = "Circular Charts",
                DemoType = DemoTypes.None,
            };

            DemoInfo pieChartSample = new DemoInfo()
            {
                Name = "Default pie",
                Category = "Circular Charts",
                DemoView = typeof(Views.PieChart),
                ShowInfoPanel = true
            };

            List<Documentation> pieChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Pie Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.PieSeries.html")},
                new Documentation(){ Content = "Pie Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/circular-charts/piechart")},
            };
            pieChartSample.Documentation.AddRange(pieChartDocumentation);

            DemoInfo semiPieSample = new DemoInfo()
            {
                Name = "Semi-pie",
                Category = "Circular Charts",
                DemoView = typeof(Views.SemiPieChart),
                ShowInfoPanel = true
            };

            List<Documentation> semiPieChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Semi Pie Documentation", Uri = new Uri("https://help.syncfusion.com/winui/circular-charts/piechart#semi-pie")},
            };
            semiPieSample.Documentation.AddRange(semiPieChartDocumentation);

            List<DemoInfo> subPieDemos = new List<DemoInfo>();

            subPieDemos.Add(pieChartSample);
            subPieDemos.Add(semiPieSample);

            pieSamples.SubCategoryDemos = subPieDemos;

            #endregion

            #region Doughnut

            DemoInfo doughnutSamples = new DemoInfo()
            {
                Name = "Doughnut",
                Category = "Circular Charts",
                DemoType = DemoTypes.None,
            };

            DemoInfo doughnutChartSample = new DemoInfo()
            {
                Name = "Default doughnut",
                Category = "Circular Charts",
                DemoView = typeof(Views.DoughnutChart),
                ShowInfoPanel = true
            };

            List<Documentation> doughnutChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Doughnut Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.DoughnutSeries.html")},
                new Documentation(){ Content = "Doughnut Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/circular-charts/doughnutchart")},
            };
            doughnutChartSample.Documentation.AddRange(doughnutChartDocumentation);

            DemoInfo semiDoughnutSample = new DemoInfo()
            {
                Name = "Semi-doughnut",
                Category = "Circular Charts",
                DemoView = typeof(Views.SemiDoughnutChart),
                ShowInfoPanel = true
            };

            List<Documentation> semidoughnutChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Semi Doughnut Documentation", Uri = new Uri("https://help.syncfusion.com/winui/circular-charts/doughnutchart#semi-doughnut")},
            };
            semiDoughnutSample.Documentation.AddRange(semidoughnutChartDocumentation);

            List<DemoInfo> subdoughnutDemos = new List<DemoInfo>();

            subdoughnutDemos.Add(doughnutChartSample);
            subdoughnutDemos.Add(semiDoughnutSample);

            doughnutSamples.SubCategoryDemos = subdoughnutDemos;

            #endregion

            #region Interaction

            DemoInfo interactionSamples = new DemoInfo()
            {
                Name = "Interaction",
                Category = "Circular Charts",
                DemoType = DemoTypes.None,
                Description= "This sample showcases interactive features such as tooltips and selections, which enhance user experience and facilitate data point interaction."
            };

            DemoInfo circularTooltipSample = new DemoInfo()        
            {
                Name = "Tooltip",
                Category = "Circular Charts",
                DemoView = typeof(Views.CircularTooltip),
                ShowInfoPanel = true
            };

            List<Documentation> circularTooltipDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Tooltip API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartTooltipBehavior.html")},
                new Documentation(){ Content = "Circular Chart Tooltip Documentation", Uri = new Uri("https://help.syncfusion.com/winui/circular-charts/tooltip")},
            };
            circularTooltipSample.Documentation.AddRange(circularTooltipDocumentation);

            DemoInfo circularSelectionSample = new DemoInfo()
            {
                Name = "Selection",
                Category = "Circular Charts",
                DemoView = typeof(Views.CircularSelection),
                ShowInfoPanel = true
            };

            List<Documentation> circularSelectionDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Selection API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartSelectionBehavior.html")},
                new Documentation(){ Content = "Circular Chart Selection Documentation", Uri = new Uri("https://help.syncfusion.com/winui/circular-charts/selection")},
            };
            circularSelectionSample.Documentation.AddRange(circularSelectionDocumentation);


            List<DemoInfo> subInteractionDemos = new List<DemoInfo>();

            subInteractionDemos.Add(circularTooltipSample);
            subInteractionDemos.Add(circularSelectionSample);

            interactionSamples.SubCategoryDemos = subInteractionDemos;

            #endregion

            #region Legend

            DemoInfo legendSamples = new DemoInfo()
            {
                Name = "Legend",
                Category = "Circular Charts",
                DemoType = DemoTypes.None,
                Description= "This sample showcases the legend, which provides information about the data points."
            };

            DemoInfo circularLegendToggleSample = new DemoInfo()
            {
                Name = "Default legend ",
                Category = "Circular Charts",
                DemoView = typeof(Views.CircularLegendToggle),
                ShowInfoPanel = true
            };

            List<Documentation> circularLegendToggleDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Legend API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartLegend.html")},
                new Documentation(){ Content = "Circular Chart Legend Documentation", Uri = new Uri("https://help.syncfusion.com/winui/circular-charts/legend")},
            };
            circularLegendToggleSample.Documentation.AddRange(circularLegendToggleDocumentation);

            DemoInfo circularLegendSample = new DemoInfo()
            {
                Name = "Customized legend",
                Category = "Circular Charts",
                DemoView = typeof(Views.CircularLegend),
                ShowInfoPanel = true
            };

            List<Documentation> circularLegendDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Legend Template API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartLegend.html#Syncfusion_UI_Xaml_Charts_ChartLegend_ItemTemplate")},
                new Documentation(){ Content = "Circular Chart Legend Template Documentation", Uri = new Uri("https://help.syncfusion.com/winui/circular-charts/legend#template")},
            };
            circularLegendSample.Documentation.AddRange(circularLegendDocumentation);


            List<DemoInfo> subLegendDemos = new List<DemoInfo>();

            subLegendDemos.Add(circularLegendToggleSample);
            subLegendDemos.Add(circularLegendSample);

            legendSamples.SubCategoryDemos = subLegendDemos;

            #endregion

            #endregion

            #region Funnel 

            DemoInfo defaultFunnelSample = new DemoInfo()
            {
                Name = "Default funnel chart",
                Category = "Funnel Chart",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.DefaultFunnelChart),
                ShowInfoPanel = true
            };

            List<Documentation> funnelChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Funnel Chart API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.SfFunnelChart.html")},
                new Documentation(){ Content = "Funnel Chart Documentation", Uri = new Uri("https://help.syncfusion.com/winui/funnel-chart/getting-started")},
            };
            defaultFunnelSample.Documentation.AddRange(funnelChartDocumentation);

            DemoInfo funnelLegendSample = new DemoInfo()
            {
                Name = "Legend customization",
                Category = "Funnel Chart",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.FunnelLegend),
                ShowInfoPanel = true,
                Description= "This sample showcases the legend, which furnishes information about the data points."
            };

            List<Documentation> funnelLegendChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Legend API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartLegend.html")},
                new Documentation(){ Content = "Funnel Chart Legend Documentation", Uri = new Uri("https://help.syncfusion.com/winui/funnel-chart/legend")},
            };
            funnelLegendSample.Documentation.AddRange(funnelLegendChartDocumentation);

            DemoInfo funnelTooltipSample = new DemoInfo()
            {
                Name = "Tooltip customization",
                Category = "Funnel Chart",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.FunnelTooltip),
                ShowInfoPanel = true,
                Description= "This sample demonstrates tooltip behavior, displaying info over segments when the mouse hovers."
            };

            List<Documentation> funnelTooltipChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Tooltip API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartTooltipBehavior.html")},
                new Documentation(){ Content = "Funnel Chart Tooltip Documentation", Uri = new Uri("https://help.syncfusion.com/winui/funnel-chart/tooltip")},
            };
            funnelTooltipSample.Documentation.AddRange(funnelTooltipChartDocumentation);

            #endregion

            #region Pyramid 

            DemoInfo defaultPyramidSample = new DemoInfo()
            {
                Name = "Default pyramid chart",
                Category = "Pyramid Chart",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.DefaultPyramidChart),
                ShowInfoPanel = true
            };

            List<Documentation> pyramidChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Pyramid Chart API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.SfPyramidChart.html")},
                new Documentation(){ Content = "Pyramid Chart Documentation", Uri = new Uri("https://help.syncfusion.com/winui/pyramid-chart/getting-started")},
            };
            defaultPyramidSample.Documentation.AddRange(pyramidChartDocumentation);

            DemoInfo pyramidLegendSample = new DemoInfo()
            {
                Name = "Legend customization",
                Category = "Pyramid Chart",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.PyramidLegend),
                ShowInfoPanel = true,
                Description= "This sample showcases the legend, which gives an overview of the data points"
            };

            List<Documentation> pyramidLegendChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Legend API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartLegend.html")},
                new Documentation(){ Content = "Pyramid Chart Legend Documentation", Uri = new Uri("https://help.syncfusion.com/winui/pyramid-chart/legend")},
            };
            pyramidLegendSample.Documentation.AddRange(pyramidLegendChartDocumentation);

            DemoInfo pyramidTooltipSample = new DemoInfo()
            {
                Name = "Tooltip customization",
                Category = "Pyramid Chart",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.PyramidTooltip),
                ShowInfoPanel = true,
                Description= "This sample showcases tooltip functionality, displaying info when hovering over segments."
            };

            List<Documentation> pyramidTooltipChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Tooltip API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartTooltipBehavior.html")},
                new Documentation(){ Content = "Pyramid Chart Tooltip Documentation", Uri = new Uri("https://help.syncfusion.com/winui/pyramid-chart/tooltip")},
            };
            pyramidTooltipSample.Documentation.AddRange(pyramidTooltipChartDocumentation);

            #endregion

            #region Polar

            DemoInfo polarAreaSample = new DemoInfo()
            {
                Name = "Polar Area",
                Category = "Polar Chart",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.PolarArea),
                ShowInfoPanel = true
            };

            List<Documentation> polarAreatDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Polar Area Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.PolarAreaSeries.html")},
                new Documentation(){ Content = "Polar Area Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/polar-chart/polar-area")},
            };
            polarAreaSample.Documentation.AddRange(polarAreatDocumentation);

            DemoInfo polarLineSample = new DemoInfo()
            {
                Name = "Polar Line",
                Category = "Polar Chart",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.PolarLine),
                ShowInfoPanel = true
            };

            List<Documentation> polarLineDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Polar Line Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.PolarLineSeries.html")},
                new Documentation(){ Content = "Polar Line Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/polar-chart/polar-line")},
            };
            polarLineSample.Documentation.AddRange(polarLineDocumentation); 

            #endregion

            //Control View
            #region Cartesian Chart

            var demos = new List<DemoInfo>()
            {
                    columnSamples,
                    barSamples,

                    lineSamples,
                    areaChartSample,

                    bubbleSamples,
                    scatterSamples,

                    splineSamples,
                    splineAreaChartSample,

                    stepLineSamples,
                    stepAreaChartSample,

                    fastChartSamples,

                    stackedChartSamples,

                    stacked100ChartSamples,

                    categorySample,
                    numericalSample,
                    dateTimeSample,

                    cartesianLegendToggleSample,
                    cartesianLegendSample,

                    cartesianSelectionSamples,
                    tooltipSample,
                    trackballSample,
                    zoomingSample,
                    crossHairSample,
                   
            };

            var controlInfo = new ControlInfo()
            {
                Control = DemoControl.SfCartesianChart,
                ControlCategory = ControlCategory.DataVisualization,
                Description = "Cartesian charts support different types of series, and each type of chart represents a unique style of data that is user-friendly with great UI visualization.",
                Glyph = "\ue704",
                ImageSource = "CartesianChart.png",
                IsPreview = false,
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);

            #endregion

            #region Circular Chart

            var circularDemo = new List<DemoInfo>()
            {
                   pieSamples,
                   doughnutSamples,
                   legendSamples,
                   interactionSamples,
            };

            var controlInfo1 = new ControlInfo()
            {
                Control = DemoControl.SfCircularChart,
                ControlCategory = ControlCategory.DataVisualization,
                Description = "Circular charts are well-crafted for visualizing data. They contain a rich gallery of graphs that cater to all charting scenarios.",
                Glyph = "\ue717",
                ImageSource = "CircularChart.png",
                IsPreview = false
            };

            controlInfo1.Demos.AddRange(circularDemo);
            DemoHelper.ControlInfos.Add(controlInfo1);

            #endregion

            #region Pyramid

            var pyramidDemo = new List<DemoInfo>()
            {
                   defaultPyramidSample,
                   pyramidLegendSample,
                   pyramidTooltipSample,
            };

            var controlInfo2 = new ControlInfo()
            {
                Control = DemoControl.SfPyramidChart,
                ControlCategory = ControlCategory.DataVisualization,
                Description = "The pyramid chart visually represents the proportional size of each level or layer in the hierarchy, with the largest layer at the bottom and smaller layers at the top.",
                Glyph = "\ue716",
                ImageSource = "PyramidChart.png",
                IsPreview = false,
            };

            controlInfo2.Demos.AddRange(pyramidDemo);
            DemoHelper.ControlInfos.Add(controlInfo2);

            #endregion

            #region Funnel

            var funnelDemo = new List<DemoInfo>()
            {
                    defaultFunnelSample,
                    funnelLegendSample,
                    funnelTooltipSample,
            };

            var controlInfo3 = new ControlInfo()
            {
                Control = DemoControl.SfFunnelChart,
                ControlCategory = ControlCategory.DataVisualization,
                Description = "A funnel chart helps to visualize a linear process that consists of sequential and connected stages.",
                Glyph = "\ue718",
                ImageSource = "FunnelChart.png",
                IsPreview = false,
            };

            controlInfo3.Demos.AddRange(funnelDemo);
            DemoHelper.ControlInfos.Add(controlInfo3);

            #endregion

            #region Polar

            var polarDemo = new List<DemoInfo>()
            {
                    polarAreaSample,
                    polarLineSample,
            };

            var controlInfo4 = new ControlInfo()
            {
                Control = DemoControl.SfPolarChart,
                ControlCategory = ControlCategory.DataVisualization,
                Description = "The polar chart effectively visualizes the comparison of values and angles, facilitating data analysis.",
                Glyph = "\ue719",
                ImageSource = "PolarChart.png",
                IsPreview = false,
            };

            controlInfo4.Demos.AddRange(polarDemo);
            DemoHelper.ControlInfos.Add(controlInfo4); 

            #endregion
        }
    }
}
