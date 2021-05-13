#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.winui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.winui
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {

            //Basic Charts
            DemoInfo areaChartSample = new DemoInfo()
            {
                Name = "Area",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases area chart which connects the y-points using straight lines and forms an area covered by the lines and x-axis.",
                DemoView = typeof(Views.AreaChart),
                ShowInfoPanel = true
            };

            List<Documentation> areaChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - AreaSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.AreaSeries.html")},
                new Documentation(){ Content = "Chart - AreaSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/area#area")},
            };
            areaChartSample.Documentation.AddRange(areaChartDocumentation);

            DemoInfo barChartSample = new DemoInfo()
            {
                Name = "Bar",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases bar chart which displays horizontal bar(s) for each points in the series and points from adjacent series are drawn as bars next to each other.",
                DemoView = typeof(Views.BarChart),
                ShowInfoPanel = true
            };

            List<Documentation> barChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - BarSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.BarSeries.html")},
                new Documentation(){ Content = "Chart - BarSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/columnandbar#bar")},
            };
            barChartSample.Documentation.AddRange(barChartDocumentation);

            DemoInfo bubbleChartSample = new DemoInfo()
            {
                Name = "Bubble",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases bubble chart which is an extension of the scatter chart (or xy-chart) where each data point is represented by a circle.",
                DemoView = typeof(Views.BubbleChart),
                ShowInfoPanel = true
            };

            List<Documentation> bubbleChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - BubbleSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.BubbleSeries.html")},
                new Documentation(){ Content = "Chart - BubbleSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/bubbleandscatter#bubble")},
            };
            bubbleChartSample.Documentation.AddRange(bubbleChartDocumentation);

            DemoInfo columnChartSample = new DemoInfo()
            {
                Name = "Column",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases column chart which uses vertical bar(s) to display different points from adjacent series are drawn as bars next to each other.",
                DemoView = typeof(Views.ColumnChart),
                ShowInfoPanel = true,
            };

            List<Documentation> columnChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - ColumnSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ColumnSeries.html")},
                new Documentation(){ Content = "Chart - ColumnSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/columnandbar#column")},
            };
            columnChartSample.Documentation.AddRange(columnChartDocumentation);

            DemoInfo lineChartSample = new DemoInfo()
            {
                Name = "Line",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases line chart which  represents time-series data and displaying trends in data at equal intervals.",
                DemoView = typeof(Views.LineChart),
                ShowInfoPanel = true
            };

            List<Documentation> lineChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - LineSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.LineSeries.html")},
                new Documentation(){ Content = "Chart - LineSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/lineandstepline#line")},
            };
            lineChartSample.Documentation.AddRange(lineChartDocumentation);

            DemoInfo scatterChartSample = new DemoInfo()
            {
                Name = "Scatter",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases scatter chart which displays the relationships between the two set of data. It represents each data point as circle with fixed dimension.",
                DemoView = typeof(Views.ScatterChart),
                ShowInfoPanel = true
            };

            List<Documentation> scatterChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - ScatterSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ScatterSeries.html")},
                new Documentation(){ Content = "Chart - ScatterSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/bubbleandscatter#scatter")},
            };
            scatterChartSample.Documentation.AddRange(scatterChartDocumentation);

            DemoInfo splineAreaChartSample = new DemoInfo()
            {
                Name = "Spline Area",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases spline area which connects the points of a series by a smooth spline curve.",
                DemoView = typeof(Views.SplineAreaChart),
                ShowInfoPanel = true
            };

            List<Documentation> splineAreaChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - SplineAreaSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.SplineAreaSeries.html")},
                new Documentation(){ Content = "Chart - SplineAreaSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/spline#spline-area")},
            };
            splineAreaChartSample.Documentation.AddRange(splineAreaChartDocumentation);

            DemoInfo splineChartSample = new DemoInfo()
            {
                Name = "Spline",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This samle showcases spline chart which connects the two data points using curves instead of straight lines.",
                DemoView = typeof(Views.SplineChart),
                ShowInfoPanel = true
            };

            List<Documentation> splineChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - SplineSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.SplineSeries.html")},
                new Documentation(){ Content = "Chart - SplineSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/spline#spline")},
            };
            splineChartSample.Documentation.AddRange(splineChartDocumentation);

            DemoInfo stepAreaChartSample = new DemoInfo()
            {
                Name = "Step Area",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases step area which connects the values by continuous vertical and horizontal line(s) forming a step like progression.",
                DemoView = typeof(Views.StepAreaChart),
                ShowInfoPanel = true
            };

            List<Documentation> stepAreaChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - StepAreaSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StepAreaSeries.html")},
                new Documentation(){ Content = "Chart - StepAreaSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/area#step-area")},
            };
            stepAreaChartSample.Documentation.AddRange(stepAreaChartDocumentation);

            DemoInfo steplineChartSample = new DemoInfo()
            {
                Name = "Step Line",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases step line chart which uses horizontal and vertical line(s) to connect data points resulting in a step like progression.",
                DemoView = typeof(Views.StepLineChart),
                ShowInfoPanel = true
            };

            List<Documentation> steplineChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - StepLineSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StepLineSeries.html")},
                new Documentation(){ Content = "Chart - StepLineSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/lineandstepline#step-line")},
            };
            steplineChartSample.Documentation.AddRange(steplineChartDocumentation);

            //Circular Charts
            DemoInfo pieChartSample = new DemoInfo()
            {
                Name = "Pie",
                Category = "Circular Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases pie chart which is ideal for the display of proportionate values expressed in either percentage or fractional formats.",
                DemoView = typeof(Views.PieChart),
                ShowInfoPanel = true
            };

            List<Documentation> pieChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - PieSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.PieSeries.html")},
                new Documentation(){ Content = "Chart - PieSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/pieanddoughnut#pie")},
            };
            pieChartSample.Documentation.AddRange(pieChartDocumentation);

            DemoInfo doughnutSample = new DemoInfo()
            {
                Name = "Doughnut",
                Category = "Circular Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases doughnut chart which is like pie chart with a hole and the value is specified as the doughnut coefficient.",
                DemoView = typeof(Views.DoughnutChart),
                ShowInfoPanel = true
            };

            List<Documentation> doughnutChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - DoughnutSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.DoughnutSeries.html")},
                new Documentation(){ Content = "Chart - DoughnutSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/pieanddoughnut#doughnut")},
            };
            doughnutSample.Documentation.AddRange(doughnutChartDocumentation);

            DemoInfo semiPieSample = new DemoInfo()
            {
                Name = "Semi Pie",
                Category = "Circular Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the different shapes of pie chart such as as semicircular or quarter circular series by using custom StartAngle and EndAngle properties.",
                DemoView = typeof(Views.SemiPieChart),
                ShowInfoPanel = true
            };

            List<Documentation> semiPieChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - Semi Pie Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/pieanddoughnut#semi-pie-and-doughnut")},
            };
            semiPieSample.Documentation.AddRange(semiPieChartDocumentation);

            DemoInfo semiDoughnutSample = new DemoInfo()
            {
                Name = "Semi Doughnut",
                Category = "Circular Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the different shapes of doughnut chart such as semicircular or quarter circular series by using custom StartAngle and EndAngle properties.",
                DemoView = typeof(Views.SemiDoughnutChart),
                ShowInfoPanel = true
            };

            List<Documentation> semidoughnutChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - Semi Doughnut Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/pieanddoughnut#semi-pie-and-doughnut")},
            };
            semiDoughnutSample.Documentation.AddRange(semidoughnutChartDocumentation);

            DemoInfo multiplePieSample = new DemoInfo()
            {
                Name = "Multiple Pie",
                Category = "Circular Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases multiple pie series. Pie chart is ideal for the display of proportionate values expressed in either percentage or fractional formats.",
                DemoView = typeof(Views.MultiplePieChart),
            };

            DemoInfo multipleDoughnutSample = new DemoInfo()
            {
                Name = "Multiple Doughnut",
                Category = "Circular Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases multiple doughnuts. The doughnut chart is best suited for presenting data in proportions.",
                DemoView = typeof(Views.MultipleDoughnutChart),
            };

            DemoInfo verticalchartSample = new DemoInfo()
            {
                Name = "Vertical Chart",
                Category = "Vertical Chart",
                DemoType = DemoTypes.None,
                Description = "This sample showcases vertical chart which is like normal chart except that the axis and series area are rotated to 90 degree.",
                DemoView = typeof(Views.VerticalChart),
            };

            DemoInfo crossHairSample = new DemoInfo()
            {
                Name = "Crosshair",
                Category = "Interactive Features",
                DemoType = DemoTypes.None,
                Description = "This sample showcases crosshair behavior which consists of two lines; perpendicular to each other, fixed at a point to show the values at the current mouse point.",
                DemoView = typeof(Views.Crosshair),
                ShowInfoPanel = true
            };

            List<Documentation> crosshairDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - Crosshair API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartCrosshairBehavior.html")},
                new Documentation(){ Content = "Chart - Crosshair Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/interactive-features/crosshair")},
            };
            crossHairSample.Documentation.AddRange(crosshairDocumentation);

            DemoInfo tooltipSample = new DemoInfo()
            {
                Name = "Tooltip",
                Category = "Interactive Features",
                DemoType = DemoTypes.None,
                Description = "This sample showcases tooltip behavior which displays any information over a chart series like a metadata. It appears when the mouse hovers any chart segment.",
                DemoView = typeof(Views.Tooltip),
            };

            DemoInfo trackballSample = new DemoInfo()
            {
                Name = "Trackball",
                Category = "Interactive Features",
                DemoType = DemoTypes.None,
               Description = "This sample showcases trackball behavior which tracks a data point closer to the touch position or touch contact point.",
                DemoView = typeof(Views.Trackball),
                ShowInfoPanel = true
            };

            List<Documentation> trackballDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - Trackball API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartTrackballBehavior.html")},
                new Documentation(){ Content = "Chart - Trackball Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/interactive-features/trackball")},
            };
            trackballSample.Documentation.AddRange(trackballDocumentation);

            DemoInfo selectionSample = new DemoInfo()
            {
                Name = "Selection",
                Category = "Interactive Features",
                DemoType = DemoTypes.None,
                Description = "This sample showcases selection behavior which allows you to select either a data point or series based on the segment or series selection.",
                DemoView = typeof(Views.SelectionBehavior),
                ShowInfoPanel = true
            };

            List<Documentation> selectionDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - Selection API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartSelectionBehavior.html")},
                new Documentation(){ Content = "Chart - Selection Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/interactive-features/selection")},
            };
            selectionSample.Documentation.AddRange(selectionDocumentation);

            DemoInfo zoomingSample = new DemoInfo()
            {
                Name = "Zoom and Pan",
                Category = "Interactive Features",
                DemoType = DemoTypes.None,
                Description = "This sample showcases zooming behavior which allows you to take a closer look at the data point plotted in the series.",
                DemoView = typeof(Views.ZoomPanBehavior),
                ShowInfoPanel = true
            };

            List<Documentation> zoomingDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - ZoomAndPanning API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartZoomPanBehavior.html")},
                new Documentation(){ Content = "Chart - ZoomAndPanning Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/interactive-features/zoompan")},
            };
            zoomingSample.Documentation.AddRange(zoomingDocumentation);

            DemoInfo palettesSample = new DemoInfo()
            {
                Name = "Palettes",
                Category = "Palettes",
                DemoType = DemoTypes.None,
                Description = "This sample showcases how to apply color palettes for the chart series.",
                DemoView = typeof(Views.ColorPalettes),
            };

            DemoInfo customColumnSample = new DemoInfo()
            {
                Name = "Column",
                Category = "Series Template",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the customization of column series default template to any other shape using CustomTemplate property.",
                DemoView = typeof(Views.CustomColumnSeries),
            };

            DemoInfo customScatterSample = new DemoInfo()
            {
                Name = "Scatter",
                Category = "Series Template",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the customization of scatter series default template to any other shape using CustomTemplate property.",
                DemoView = typeof(Views.CustomScatterSeries),
            };

            DemoInfo customBarSample = new DemoInfo()
            {
                Name = "Bar",
                Category = "Series Template",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the customization of bar series default template to any other shape using CustomTemplate property.",
                DemoView = typeof(Views.CustomBarSeries),
            };

            DemoInfo customSplineSample = new DemoInfo()
            {
                Name = "Spline",
                Category = "Series Template",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the customization of spline series default template to any other shape using CustomTemplate property.",
                DemoView = typeof(Views.CustomSplineSeries),
            };

            DemoInfo stackedAreaSample = new DemoInfo()
            {
                Name = "Stacked Area",
                Category = "Stacked Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases area chart which is similar to regular area charts except that the y-values stack on top of each other.",
                DemoView = typeof(Views.StackingAreaChart),
                ShowInfoPanel = true
            };

            List<Documentation> stackedAreaChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - StackedAreaSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StackedAreaSeries.html")},
                new Documentation(){ Content = "Chart - StackedAreaSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/stacking#stacked-area")},
            };
            stackedAreaSample.Documentation.AddRange(stackedAreaChartDocumentation);

            DemoInfo stackedBarSample = new DemoInfo()
            {
                Name = "Stacked Bar",
                Category = "Stacked Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases bar chart which is similar to regular bar charts except that the y-values stack on top of each other.",
                DemoView = typeof(Views.StackingBarChart),
                ShowInfoPanel = true
            };

            List<Documentation> stackedBarChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - StackedBarSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StackedBarSeries.html")},
                new Documentation(){ Content = "Chart - StackedBarSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/stacking#stacked-bar")},
            };
            stackedBarSample.Documentation.AddRange(stackedBarChartDocumentation);

            DemoInfo stackedColumnSample = new DemoInfo()
            {
                Name = "Stacked Column",
                Category = "Stacked Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases column chart which is similar to regular column charts except that the y-values stack on top of each other.",
                DemoView = typeof(Views.StackingColumnChart),
                ShowInfoPanel = true
            };

            List<Documentation> stackedColumnChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - StackedColumnSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StackedColumnSeries.html")},
                new Documentation(){ Content = "Chart - StackedColumnSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/stacking#stacked-column")},
            };
            stackedColumnSample.Documentation.AddRange(stackedColumnChartDocumentation);

            DemoInfo stackedLineSample = new DemoInfo()
            {
                Name = "Stacked Line",
                Category = "Stacked Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases line chart which is similar to regular line charts except that the y-values stack on top of each other .",
                DemoView = typeof(Views.StackingLineChart),
                ShowInfoPanel = true
            };

            List<Documentation> stackedLineChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - StackedLineSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StackedLineSeries.html")},
                new Documentation(){ Content = "Chart - StackedLineSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/stacking#stacked-line")},
            };
            stackedLineSample.Documentation.AddRange(stackedLineChartDocumentation);

            DemoInfo stackedGroupSample = new DemoInfo()
            {
                Name = "Stacked Group",
                Category = "Stacked Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases stacked series can be grouped based on any category to visualize the comparative relationship of parts to the whole.",
                DemoView = typeof(Views.Grouping),
                ShowInfoPanel = true
            };

            List<Documentation> stackedGroupDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - Grouping API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StackedSeriesBase.html#Syncfusion_UI_Xaml_Charts_StackedSeriesBase_GroupName")},
                new Documentation(){ Content = "Chart - Grouping Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/groupingstacked")},
            };
            stackedGroupSample.Documentation.AddRange(stackedGroupDocumentation);

            DemoInfo stackedArea100Sample = new DemoInfo()
            {
                Name = "100% Stacked Area",
                Category = "100% Stacked Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases 100% area chart which is similar to regular area charts except that the y-values stack on top of each other.",
                DemoView = typeof(Views.StackingArea100Chart),
                ShowInfoPanel = true
            };

            List<Documentation> stackedArea100ChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - StackedArea100Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StackedArea100Series.html")},
                new Documentation(){ Content = "Chart - StackedArea100Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/stacking#100-stacked-area")},
            };
            stackedArea100Sample.Documentation.AddRange(stackedArea100ChartDocumentation);

            DemoInfo stackedBar100Sample = new DemoInfo()
            {
                Name = "100% Stacked Bar",
                Category = "100% Stacked Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases 100% bar chart which is similar to regular bar charts except that the y-values stack on top of each other.",
                DemoView = typeof(Views.StackingBar100Chart),
                ShowInfoPanel = true
            };

            List<Documentation> stackedBar100ChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - StackedBar100Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StackedBar100Series.html")},
                new Documentation(){ Content = "Chart - StackedBar100Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/stacking#100-stacked-bar")},
            };
            stackedBar100Sample.Documentation.AddRange(stackedBar100ChartDocumentation);

            DemoInfo stackedColumn100Sample = new DemoInfo()
            {
                Name = "100% Stacked Column",
                Category = "100% Stacked Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases 100% column chart which is similar to regular column charts except that the y-values stack on top of each other.",
                DemoView = typeof(Views.StackingColumn100Chart),
                ShowInfoPanel = true
            };

            List<Documentation> stackedColumn100ChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - StackedColumn100Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StackedColumn100Series.html")},
                new Documentation(){ Content = "Chart - StackedColumn100Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/stacking#100-stacked-column")},
            };
            stackedColumn100Sample.Documentation.AddRange(stackedColumn100ChartDocumentation);

            DemoInfo stackedLine100Sample = new DemoInfo()
            {
                Name = "100% Stacked Line",
                Category = "100% Stacked Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases 100% line chart which is similar to regular line charts except that the y-values stack on top of each other.",
                DemoView = typeof(Views.StackingLine100Chart),
                ShowInfoPanel = true
            };

            List<Documentation> stackedLine100ChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - StackedLine100Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.StackedLine100Series.html")},
                new Documentation(){ Content = "Chart - StackedLine100Series Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/stacking#100-stacked-line")},
            };
            stackedLine100Sample.Documentation.AddRange(stackedLine100ChartDocumentation);

            DemoInfo funnelSample = new DemoInfo()
            {
                Name = "Funnel",
                Category = "Funnel and Pyramid Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases funnel chart is a single series chart representing the data as portions of 100%, and this chart does not use any axes.",
                DemoView = typeof(Views.FunnelChart),
                ShowInfoPanel = true
            };

            List<Documentation> funnelChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - FunnelSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.FunnelSeries.html")},
                new Documentation(){ Content = "Chart - FunnelSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/funnelandpyramid#funnel")},
            };
            funnelSample.Documentation.AddRange(funnelChartDocumentation);

            DemoInfo pyramidSample = new DemoInfo()
            {
                Name = "Pyramid",
                Category = "Funnel and Pyramid Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases pyramid chart is similar to the funnel chart. It is often used for geographical purposes. This type of chart is a single series chart representing the data as portions of 100%, and this chart does not use any axes.",
                DemoView = typeof(Views.PyramidChart),
                ShowInfoPanel = true
            };

            List<Documentation> pyramidChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - PyramidSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.PyramidSeries.html")},
                new Documentation(){ Content = "Chart - PyramidSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/funnelandpyramid#pyramid")},
            };
            pyramidSample.Documentation.AddRange(pyramidChartDocumentation);

            DemoInfo polarSample = new DemoInfo()
            {
                Name = "Polar",
                Category = "Polar and Radar Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases polar chart is a circular graph on which data is displayed in terms of values and angles. X-values define the angles at which the data points will be plotted. Y-value defines the distance of the data points from the center of the graph, with the center of the graph usually starting at 0.",
                DemoView = typeof(Views.PolarChart),
                ShowInfoPanel = true
            };

            List<Documentation> polarChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - PolarSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.PolarSeries.html")},
                new Documentation(){ Content = "Chart - PolarSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/radarandpolar#polar")},
            };
            polarSample.Documentation.AddRange(polarChartDocumentation);

            DemoInfo radarSample = new DemoInfo()
            {
                Name = "Radar",
                Category = "Polar and Radar Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases radar chart is a circular graph on which data is displayed in terms of values and angles. X-values define the angles at which the data points will be plotted. Y-value defines the distance of the data points from the center of the graph, with the center of the graph usually starting at 0.",
                DemoView = typeof(Views.RadarChart),
                ShowInfoPanel = true
            };

            List<Documentation> radarChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - RadarSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.RadarSeries.html")},
                new Documentation(){ Content = "Chart - RadarSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/seriestypes/radarandpolar#radar")},
            };
            radarSample.Documentation.AddRange(radarChartDocumentation);

            DemoInfo fastLineSample = new DemoInfo()
            {
                Name = "Fast Line",
                Category = "Fast Charts",
                DemoType = DemoTypes.New,
                Description = "This sample showcases a special kind of line series which uses polyline for rendering chart points. FastLineSeries allows to render a collection with large number of data points in fraction of milliseconds.",
                DemoView = typeof(Views.FastLineChart),
                ShowInfoPanel = true
            };

            List<Documentation> fastLineChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - FastLineSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.FastLineSeries.html")},
                new Documentation(){ Content = "Chart - FastLineSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/fastchart/fast-series#fastline-chart")},
            };
            fastLineSample.Documentation.AddRange(fastLineChartDocumentation);

            DemoInfo fastStepLineSample = new DemoInfo()
            {
                Name = "Fast StepLine",
                Category = "Fast Charts",
                DemoType = DemoTypes.New,
                Description = "This sample showcases a special kind of step line series which uses writeable bitmap for rendering chart points. FastStepLineBitmapSeries allows to render a collection with large number of data points in fraction of milliseconds.",
                DemoView = typeof(Views.FastStepLineChart),
                ShowInfoPanel = true
            };

            List<Documentation> fastStepLineChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - FastStepLineBitmapSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.FastStepLineBitmapSeries.html")},
                new Documentation(){ Content = "Chart - FastStepLineBitmapSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/fastchart/fast-bitmapseries#faststeplinebitmap-chart")},
            };
            fastStepLineSample.Documentation.AddRange(fastStepLineChartDocumentation);

            DemoInfo fastScatterSample = new DemoInfo()
            {
                Name = "Fast Scatter",
                Category = "Fast Charts",
                DemoType = DemoTypes.New,
                Description = "This sample showcases a special kind of scatter series which uses writeable bitmap for rendering chart points. FastScatterBitmapSeries allows to render a collection with large number of data points in fraction of milliseconds.",
                DemoView = typeof(Views.FastScatterChart),
                ShowInfoPanel = true
            };

            List<Documentation> fastScatterChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - FastScatterBitmapSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.FastScatterBitmapSeries.html")},
                new Documentation(){ Content = "Chart - FastScatterBitmapSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/fastchart/fast-bitmapseries#fastscatterbitmap-chart")},
            };
            fastScatterSample.Documentation.AddRange(fastScatterChartDocumentation);

            DemoInfo fastBarSample = new DemoInfo()
            {
                Name = "Fast Bar",
                Category = "Fast Charts",
                DemoType = DemoTypes.New,
                Description = "This sample showcases a special kind of bar series which uses writeable bitmap for rendering chart points. FastBarBitmapSeries allows to render a collection with large number of data points in fraction of milliseconds.",
                DemoView = typeof(Views.FastBarChart),
                ShowInfoPanel = true
            };

            List<Documentation> fastBarChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - FastBarBitmapSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.FastBarBitmapSeries.html")},
                new Documentation(){ Content = "Chart - FastBarBitmapSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/fastchart/fast-bitmapseries#fastbarbitmap-chart")},
            };
            fastBarSample.Documentation.AddRange(fastBarChartDocumentation);

            DemoInfo fastColumnSample = new DemoInfo()
            {
                Name = "Fast Column",
                Category = "Fast Charts",
                DemoType = DemoTypes.New,
                Description = "This sample showcases a special kind of column series which uses writeable bitmap for rendering chart points. FastColumnBitmapSeries allows to render a collection with large number of data points in fraction of milliseconds.",
                DemoView = typeof(Views.FastColumnChart),
                ShowInfoPanel = true
            };

            List<Documentation> fastColumnChartDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Chart - FastColumnBitmapSeries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.FastColumnBitmapSeries.html")},
                new Documentation(){ Content = "Chart - FastColumnBitmapSeries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/chart/fastchart/fast-bitmapseries#fastcolumnbitmap-chart")},
            };
            fastColumnSample.Documentation.AddRange(fastColumnChartDocumentation);

            var demos = new List<DemoInfo>()
            {
                    columnChartSample,
                    barChartSample,
                    areaChartSample,
                    bubbleChartSample,
                    scatterChartSample,
                    lineChartSample,
                    splineChartSample,
                    splineAreaChartSample,
                    stepAreaChartSample,
                    steplineChartSample,
                    pieChartSample,
                    doughnutSample,
                    semiPieSample,
                    semiDoughnutSample,
                    multiplePieSample,
                    multipleDoughnutSample,
					fastColumnSample,
                    fastBarSample,
                    fastLineSample, 
                    fastStepLineSample,
                    fastScatterSample,
                    stackedColumnSample,
                    stackedBarSample,
                    stackedAreaSample,
                    stackedLineSample,
                    stackedGroupSample,
                    stackedColumn100Sample,
                    stackedBar100Sample,
                    stackedArea100Sample,
                    stackedLine100Sample,
                    funnelSample,
                    pyramidSample,
                    polarSample,
                    radarSample,
                    verticalchartSample,             
                    //tooltipSample,
                    trackballSample,
                    crossHairSample,
                    selectionSample,
                    zoomingSample,
                    palettesSample,
                    customBarSample,
                    //customColumnSample,                    
                    customScatterSample,
                    customSplineSample,
            };

            var controlInfo = new ControlInfo()
            {
                Control = DemoControl.SfChart,
                ControlCategory = ControlCategory.DataVisualization,
                Description = "The chart is optimized to visualize large quantities of data in an elegant way. Its rich feature set includes functionalities like data binding, legends, animations, data labels, trackballs, tooltips, and zooming.",
                Glyph = "\ue704"
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);

        }
    }
}
