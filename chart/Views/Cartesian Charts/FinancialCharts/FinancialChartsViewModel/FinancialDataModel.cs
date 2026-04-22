#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace Syncfusion.ChartDemos.WinUI
{
    /// <summary>
    /// Represents a single financial data point used in candlestick or other stock chart series.
    /// </summary>
    public class FinancialDataModel
    {
        /// <summary>
        /// Gets or sets the trading date associated with this data point.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the highest price reached during the day.
        /// </summary>
        public double High { get; set; }

        /// <summary>
        /// Gets or sets the lowest price reached during the day.
        /// </summary>
        public double Low { get; set; }

        /// <summary>
        /// Gets or sets the opening price at the start of the day.
        /// </summary>
        public double Open { get; set; }

        /// <summary>
        /// Gets or sets the closing price at the end of the trading day.
        /// </summary>
        public double Close { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialDataModel"/> class with the specified date and OHLC (Open, High, Low, Close) values.
        /// </summary>
        public FinancialDataModel(DateTime date, double high, double low, double open, double close)
        {
            Date = date;
            High = high;
            Low = low;
            Open = open;
            Close = close;
        }
    }
}
