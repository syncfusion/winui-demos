#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
                Description = "This samples showcases area chart which connects the Y-points using straight lines and forms an area covered by the lines and X-axis.",
                DemoView = typeof(Views.AreaChart),
            };

            DemoInfo barChartSample = new DemoInfo()
            {
                Name = "Bar",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This samples showcases bar chart which displays horizontal bar(s) for each points in the series and points from adjacent series are drawn as bars next to each other.",
                DemoView = typeof(Views.BarChart),
            };

            DemoInfo bubbleChartSample = new DemoInfo()
            {
                Name = "Bubble",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases bubble chart which is an extension of the Scatter chart (or XY-chart) where each data point is represented by a circle.",
                DemoView = typeof(Views.BubbleChart),
            };

            DemoInfo columnChartSample = new DemoInfo()
            {
                Name = "Column",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases column chart which uses vertical bar(s) to display different points from adjacent series are drawn as bars next to each other.",
                DemoView = typeof(Views.ColumnChart),
            };

            DemoInfo lineChartSample = new DemoInfo()
            {
                Name = "Line",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases line chart which  represents time-series data and displaying trends in data at equal intervals.",
                DemoView = typeof(Views.LineChart),
            };

            DemoInfo scatterChartSample = new DemoInfo()
            {
                Name = "Scatter",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases scatter chart which displays the relationships between the two set of data. It represents each data point as circle with fixed dimension.",
                DemoView = typeof(Views.ScatterChart),
            };

            DemoInfo splineAreaChartSample = new DemoInfo()
            {
                Name = "Spline Area",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases spline Area which connects the points of a series by a smooth spline curve.",
                DemoView = typeof(Views.SplineAreaChart),
            };

            DemoInfo splineChartSample = new DemoInfo()
            {
                Name = "Spline",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This samle showcases Spline chart which connects the two data points using curves instead of straight lines.",
                DemoView = typeof(Views.SplineChart),
            };

            DemoInfo stepAreaChartSample = new DemoInfo()
            {
                Name = "Step Area",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases Step Area which connects the values by continuous vertical and horizontal line(s) forming a step like progression.",
                DemoView = typeof(Views.StepAreaChart),
            };

            DemoInfo steplineChartSample = new DemoInfo()
            {
                Name = "Step Line",
                Category = "Basic Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases Step line chart which uses horizontal and vertical line(s) to connect data points resulting in a step like progression.",
                DemoView = typeof(Views.StepLineChart),
            };

            //Circular Charts
            DemoInfo pieChartSample = new DemoInfo()
            {
                Name = "Pie",
                Category = "Circular Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases Pie chart which is ideal for the display of proportionate values expressed in either percentage or fractional formats.",
                DemoView = typeof(Views.PieChart),
            };

            DemoInfo doughnutSample = new DemoInfo()
            {
                Name = "Doughnut",
                Category = "Circular Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases Doughnut chart which is like pie chart with a hole and the value is specified as the doughnut coefficient.",
                DemoView = typeof(Views.DoughnutChart),
            };

            DemoInfo semiPieSample = new DemoInfo()
            {
                Name = "Semi Pie",
                Category = "Circular Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the different shapes of Pie chart such as as semicircular or quarter circular series by using custom StartAngle and EndAngle properties.",
                DemoView = typeof(Views.SemiPieChart),
            };

            DemoInfo semiDoughnutSample = new DemoInfo()
            {
                Name = "Semi Doughnut",
                Category = "Circular Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the different shapes of Doughnut chart such as semicircular or quarter circular series by using custom StartAngle and EndAngle properties",
                DemoView = typeof(Views.SemiDoughnutChart),
            };

            DemoInfo multiplePieSample = new DemoInfo()
            {
                Name = "Multiple Pie",
                Category = "Circular Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases multiple Pie series.Pie chart is ideal for the display of proportionate values expressed in either percentage or fractional formats.",
                DemoView = typeof(Views.MultiplePieChart),
            };

            DemoInfo multipleDoughnutSample = new DemoInfo()
            {
                Name = "Multiple Doughnut",
                Category = "Circular Charts",
                DemoType = DemoTypes.None,
                Description = "This sample showcases multiple Doughnuts.The Doughnut Chart is best suited for presenting data in proportions.",
                DemoView = typeof(Views.MultipleDoughnutChart),
            };

            DemoInfo verticalchartSample = new DemoInfo()
            {
                Name = "Vertical Chart",
                Category = "Vertical Chart",
                DemoType = DemoTypes.None,
                Description = "This sample showcases Vertical chart which is like normal chart except that the axis and series area are rotated to 90 degree.",
                DemoView = typeof(Views.VerticalChart),
            };

            DemoInfo crossHairSample = new DemoInfo()
            {
                Name = "Crosshair",
                Category = "Interactive Features",
                DemoType = DemoTypes.None,
                Description = "This sample showcases Crosshair behaviour which consists of two lines; perpendicular to each other, fixed at a point to show the values at the current mouse point.",
                DemoView = typeof(Views.Crosshair),
            };

            DemoInfo tooltipSample = new DemoInfo()
            {
                Name = "Tooltip",
                Category = "Interactive Features",
                DemoType = DemoTypes.None,
                Description = "This sample showcases ToolTip behaviour which displays any information over a chart series like a metadata. It appears when the mouse hovers any chart segment.",
                DemoView = typeof(Views.Tooltip),
            };

            DemoInfo trackballSample = new DemoInfo()
            {
                Name = "Trackball",
                Category = "Interactive Features",
                DemoType = DemoTypes.None,
               Description = "This sample showcases Trackball behaviour which tracks a data point closer to the touch position or touch contact point.",
                DemoView = typeof(Views.Trackball),
            };

            DemoInfo selectionSample = new DemoInfo()
            {
                Name = "Selection",
                Category = "Interactive Features",
                DemoType = DemoTypes.None,
                Description = "This sample showcases Selection behaviour which allows you to select either a data point or series based on the segment or series selection.",
                DemoView = typeof(Views.SelectionBehavior)
            };


            DemoInfo zoomingSample = new DemoInfo()
            {
                Name = "Zoom and Pan",
                Category = "Interactive Features",
                DemoType = DemoTypes.None,
                Description = "This sample showcases Zooming and behaviour which allows you to take a closer look at the data point plotted in the series.",
                DemoView = typeof(Views.ZoomPanBehavior),
            };

            DemoInfo palettesSample = new DemoInfo()
            {
                Name = "Palettes",
                Category = "Palettes",
                DemoType = DemoTypes.None,
                Description = "This sample showcases how to apply color palettes for the chart series.",
                DemoView = typeof(Views.ColorPalettes),
            };

            DemoInfo customcolumnsample = new DemoInfo()
            {
                Name = "Column",
                Category = "Series Template",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the customization of Column series default template to any other shape using CustomTemplate property.",
                DemoView = typeof(Views.CustomColumnSeries),
            };

            DemoInfo customscattersample = new DemoInfo()
            {
                Name = "Scatter",
                Category = "Series Template",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the customization of Scatter series default template to any other shape using CustomTemplate property.",
                DemoView = typeof(Views.CustomScatterSeries),
            };

            DemoInfo custombarample = new DemoInfo()
            {
                Name = "Bar",
                Category = "Series Template",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the customization of Bar series default template to any other shape using CustomTemplate property.",
                DemoView = typeof(Views.CustomBarSeries),
            };

            DemoInfo customsplinesample = new DemoInfo()
            {
                Name = "Spline",
                Category = "Series Template",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the customization of Spline series default template to any other shape using CustomTemplate property.",
                DemoView = typeof(Views.CustomSplineSeries),
            };

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
                    verticalchartSample,             
                    tooltipSample,
                    trackballSample,
                    crossHairSample,
                    selectionSample,
                    zoomingSample,
                    palettesSample,
                    custombarample,
                    customcolumnsample,                    
                    customscattersample,
                    customsplinesample
            };

            var controlInfo = new ControlInfo()
            {
                Control = DemoControl.SfChart,
                ControlCategory = ControlCategory.DataVisualization,
                Description = "The Chart is optimized to visualize large quantities of data in an elegant way.Its rich feature set includes functionalities like data binding, legends, animations, data labels, trackballs, tooltips, and zooming.",
                Glyph = "\ue704"
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);

        }
    }
}
