#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace Syncfusion.ChartDemos.WinUI
{
    public class FastScatterChartViewModel : IDisposable
    {
        public ObservableCollection<FastScatterModel> DataCollection { get; set; }

        public FastScatterChartViewModel()
        {
            DataCollection = GenerateData();
        }

        public ObservableCollection<FastScatterModel> GenerateData()
        {
            ObservableCollection<FastScatterModel> datas = new ObservableCollection<FastScatterModel>();

            datas.Add(new FastScatterModel() { Eruptions = 3.600f, WaitingTime = 79 });
            datas.Add(new FastScatterModel() { Eruptions = 1.800f, WaitingTime = 54 });
            datas.Add(new FastScatterModel() { Eruptions = 3.333f, WaitingTime = 74 });
            datas.Add(new FastScatterModel() { Eruptions = 2.283f, WaitingTime = 62 });
            datas.Add(new FastScatterModel() { Eruptions = 4.533f, WaitingTime = 85 });
            datas.Add(new FastScatterModel() { Eruptions = 2.883f, WaitingTime = 55 });
            datas.Add(new FastScatterModel() { Eruptions = 4.700f, WaitingTime = 88 });
            datas.Add(new FastScatterModel() { Eruptions = 3.600f, WaitingTime = 85 });
            datas.Add(new FastScatterModel() { Eruptions = 1.950f, WaitingTime = 51 });
            datas.Add(new FastScatterModel() { Eruptions = 4.350f, WaitingTime = 85 });
            datas.Add(new FastScatterModel() { Eruptions = 1.833f, WaitingTime = 54 });
            datas.Add(new FastScatterModel() { Eruptions = 3.917f, WaitingTime = 84 });
            datas.Add(new FastScatterModel() { Eruptions = 4.200f, WaitingTime = 78 });
            datas.Add(new FastScatterModel() { Eruptions = 1.750f, WaitingTime = 47 });
            datas.Add(new FastScatterModel() { Eruptions = 4.700f, WaitingTime = 83 });
            datas.Add(new FastScatterModel() { Eruptions = 2.167f, WaitingTime = 52 });
            datas.Add(new FastScatterModel() { Eruptions = 1.750f, WaitingTime = 62 });
            datas.Add(new FastScatterModel() { Eruptions = 4.800f, WaitingTime = 84 });
            datas.Add(new FastScatterModel() { Eruptions = 1.600f, WaitingTime = 52 });
            datas.Add(new FastScatterModel() { Eruptions = 4.250f, WaitingTime = 79 });
            datas.Add(new FastScatterModel() { Eruptions = 1.800f, WaitingTime = 51 });
            datas.Add(new FastScatterModel() { Eruptions = 1.750f, WaitingTime = 47 });
            datas.Add(new FastScatterModel() { Eruptions = 3.450f, WaitingTime = 78 });
            datas.Add(new FastScatterModel() { Eruptions = 3.067f, WaitingTime = 69 });
            datas.Add(new FastScatterModel() { Eruptions = 4.533f, WaitingTime = 74 });
            datas.Add(new FastScatterModel() { Eruptions = 3.600f, WaitingTime = 83 });
            datas.Add(new FastScatterModel() { Eruptions = 1.967f, WaitingTime = 55 });
            datas.Add(new FastScatterModel() { Eruptions = 4.083f, WaitingTime = 76 });
            datas.Add(new FastScatterModel() { Eruptions = 3.850f, WaitingTime = 78 });
            datas.Add(new FastScatterModel() { Eruptions = 4.433f, WaitingTime = 79 });
            datas.Add(new FastScatterModel() { Eruptions = 4.300f, WaitingTime = 73 });
            datas.Add(new FastScatterModel() { Eruptions = 4.467f, WaitingTime = 77 });
            datas.Add(new FastScatterModel() { Eruptions = 3.367f, WaitingTime = 66 });
            datas.Add(new FastScatterModel() { Eruptions = 4.033f, WaitingTime = 80 });
            datas.Add(new FastScatterModel() { Eruptions = 3.833f, WaitingTime = 74 });
            datas.Add(new FastScatterModel() { Eruptions = 2.017f, WaitingTime = 52 });
            datas.Add(new FastScatterModel() { Eruptions = 1.867f, WaitingTime = 48 });
            datas.Add(new FastScatterModel() { Eruptions = 4.833f, WaitingTime = 80 });
            datas.Add(new FastScatterModel() { Eruptions = 1.833f, WaitingTime = 59 });
            datas.Add(new FastScatterModel() { Eruptions = 4.783f, WaitingTime = 90 });
            datas.Add(new FastScatterModel() { Eruptions = 4.350f, WaitingTime = 80 });
            datas.Add(new FastScatterModel() { Eruptions = 1.883f, WaitingTime = 58 });
            datas.Add(new FastScatterModel() { Eruptions = 4.567f, WaitingTime = 84 });
            datas.Add(new FastScatterModel() { Eruptions = 1.750f, WaitingTime = 58 });
            datas.Add(new FastScatterModel() { Eruptions = 4.533f, WaitingTime = 73 });
            datas.Add(new FastScatterModel() { Eruptions = 3.317f, WaitingTime = 83 });
            datas.Add(new FastScatterModel() { Eruptions = 3.833f, WaitingTime = 64 });
            datas.Add(new FastScatterModel() { Eruptions = 2.100f, WaitingTime = 53 });
            datas.Add(new FastScatterModel() { Eruptions = 4.633f, WaitingTime = 82 });
            datas.Add(new FastScatterModel() { Eruptions = 2.000f, WaitingTime = 59 });
            datas.Add(new FastScatterModel() { Eruptions = 4.800f, WaitingTime = 75 });
            datas.Add(new FastScatterModel() { Eruptions = 4.716f, WaitingTime = 90 });
            datas.Add(new FastScatterModel() { Eruptions = 1.833f, WaitingTime = 54 });
            datas.Add(new FastScatterModel() { Eruptions = 4.833f, WaitingTime = 80 });
            datas.Add(new FastScatterModel() { Eruptions = 1.733f, WaitingTime = 54 });
            datas.Add(new FastScatterModel() { Eruptions = 4.883f, WaitingTime = 83 });
            datas.Add(new FastScatterModel() { Eruptions = 3.717f, WaitingTime = 71 });
            datas.Add(new FastScatterModel() { Eruptions = 1.667f, WaitingTime = 64 });
            datas.Add(new FastScatterModel() { Eruptions = 4.567f, WaitingTime = 77 });
            datas.Add(new FastScatterModel() { Eruptions = 4.317f, WaitingTime = 81 });
            datas.Add(new FastScatterModel() { Eruptions = 2.233f, WaitingTime = 59 });
            datas.Add(new FastScatterModel() { Eruptions = 4.500f, WaitingTime = 84 });
            datas.Add(new FastScatterModel() { Eruptions = 1.750f, WaitingTime = 48 });
            datas.Add(new FastScatterModel() { Eruptions = 4.800f, WaitingTime = 82 });
            datas.Add(new FastScatterModel() { Eruptions = 1.817f, WaitingTime = 60 });
            datas.Add(new FastScatterModel() { Eruptions = 4.400f, WaitingTime = 92 });
            datas.Add(new FastScatterModel() { Eruptions = 4.167f, WaitingTime = 78 });
            datas.Add(new FastScatterModel() { Eruptions = 4.700f, WaitingTime = 78 });
            datas.Add(new FastScatterModel() { Eruptions = 2.067f, WaitingTime = 65 });
            datas.Add(new FastScatterModel() { Eruptions = 4.700f, WaitingTime = 73 });
            datas.Add(new FastScatterModel() { Eruptions = 4.033f, WaitingTime = 82 });
            datas.Add(new FastScatterModel() { Eruptions = 1.967f, WaitingTime = 56 });
            datas.Add(new FastScatterModel() { Eruptions = 4.500f, WaitingTime = 79 });
            datas.Add(new FastScatterModel() { Eruptions = 4.000f, WaitingTime = 71 });
            datas.Add(new FastScatterModel() { Eruptions = 1.983f, WaitingTime = 62 });
            datas.Add(new FastScatterModel() { Eruptions = 5.067f, WaitingTime = 76 });
            datas.Add(new FastScatterModel() { Eruptions = 2.017f, WaitingTime = 60 });
            datas.Add(new FastScatterModel() { Eruptions = 4.567f, WaitingTime = 78 });
            datas.Add(new FastScatterModel() { Eruptions = 3.883f, WaitingTime = 76 });
            datas.Add(new FastScatterModel() { Eruptions = 3.600f, WaitingTime = 83 });
            datas.Add(new FastScatterModel() { Eruptions = 4.133f, WaitingTime = 75 });
            datas.Add(new FastScatterModel() { Eruptions = 4.333f, WaitingTime = 82 });
            datas.Add(new FastScatterModel() { Eruptions = 4.100f, WaitingTime = 70 });
            datas.Add(new FastScatterModel() { Eruptions = 2.633f, WaitingTime = 65 });
            datas.Add(new FastScatterModel() { Eruptions = 4.067f, WaitingTime = 73 });
            datas.Add(new FastScatterModel() { Eruptions = 4.933f, WaitingTime = 88 });
            datas.Add(new FastScatterModel() { Eruptions = 3.950f, WaitingTime = 76 });
            datas.Add(new FastScatterModel() { Eruptions = 4.517f, WaitingTime = 80 });
            datas.Add(new FastScatterModel() { Eruptions = 2.167f, WaitingTime = 48 });
            datas.Add(new FastScatterModel() { Eruptions = 4.000f, WaitingTime = 86 });
            datas.Add(new FastScatterModel() { Eruptions = 2.200f, WaitingTime = 60 });
            datas.Add(new FastScatterModel() { Eruptions = 4.333f, WaitingTime = 90 });
            datas.Add(new FastScatterModel() { Eruptions = 1.867f, WaitingTime = 50 });
            datas.Add(new FastScatterModel() { Eruptions = 4.817f, WaitingTime = 78 });
            datas.Add(new FastScatterModel() { Eruptions = 1.833f, WaitingTime = 63 });
            datas.Add(new FastScatterModel() { Eruptions = 4.300f, WaitingTime = 72 });
            datas.Add(new FastScatterModel() { Eruptions = 4.667f, WaitingTime = 84 });
            datas.Add(new FastScatterModel() { Eruptions = 3.750f, WaitingTime = 75 });
            datas.Add(new FastScatterModel() { Eruptions = 1.867f, WaitingTime = 51 });
            datas.Add(new FastScatterModel() { Eruptions = 4.900f, WaitingTime = 82 });
            datas.Add(new FastScatterModel() { Eruptions = 2.483f, WaitingTime = 62 });
            datas.Add(new FastScatterModel() { Eruptions = 4.367f, WaitingTime = 88 });
            datas.Add(new FastScatterModel() { Eruptions = 2.100f, WaitingTime = 49 });
            datas.Add(new FastScatterModel() { Eruptions = 4.500f, WaitingTime = 83 });
            datas.Add(new FastScatterModel() { Eruptions = 4.050f, WaitingTime = 81 });
            datas.Add(new FastScatterModel() { Eruptions = 1.867f, WaitingTime = 47 });
            datas.Add(new FastScatterModel() { Eruptions = 4.700f, WaitingTime = 84 });
            datas.Add(new FastScatterModel() { Eruptions = 1.783f, WaitingTime = 52 });
            datas.Add(new FastScatterModel() { Eruptions = 4.850f, WaitingTime = 86 });
            datas.Add(new FastScatterModel() { Eruptions = 3.683f, WaitingTime = 81 });
            datas.Add(new FastScatterModel() { Eruptions = 4.733f, WaitingTime = 75 });
            datas.Add(new FastScatterModel() { Eruptions = 2.300f, WaitingTime = 59 });
            datas.Add(new FastScatterModel() { Eruptions = 4.900f, WaitingTime = 89 });
            datas.Add(new FastScatterModel() { Eruptions = 4.417f, WaitingTime = 79 });
            datas.Add(new FastScatterModel() { Eruptions = 1.700f, WaitingTime = 59 });
            datas.Add(new FastScatterModel() { Eruptions = 4.633f, WaitingTime = 81 });
            datas.Add(new FastScatterModel() { Eruptions = 2.317f, WaitingTime = 50 });
            datas.Add(new FastScatterModel() { Eruptions = 4.600f, WaitingTime = 85 });
            datas.Add(new FastScatterModel() { Eruptions = 1.817f, WaitingTime = 59 });
            datas.Add(new FastScatterModel() { Eruptions = 4.417f, WaitingTime = 87 });
            datas.Add(new FastScatterModel() { Eruptions = 2.617f, WaitingTime = 53 });
            datas.Add(new FastScatterModel() { Eruptions = 4.067f, WaitingTime = 69 });
            datas.Add(new FastScatterModel() { Eruptions = 4.250f, WaitingTime = 77 });
            datas.Add(new FastScatterModel() { Eruptions = 1.967f, WaitingTime = 56 });
            datas.Add(new FastScatterModel() { Eruptions = 4.600f, WaitingTime = 88 });
            datas.Add(new FastScatterModel() { Eruptions = 3.767f, WaitingTime = 81 });
            datas.Add(new FastScatterModel() { Eruptions = 1.917f, WaitingTime = 45 });
            datas.Add(new FastScatterModel() { Eruptions = 4.500f, WaitingTime = 82 });
            datas.Add(new FastScatterModel() { Eruptions = 2.267f, WaitingTime = 55 });
            datas.Add(new FastScatterModel() { Eruptions = 4.650f, WaitingTime = 90 });
            datas.Add(new FastScatterModel() { Eruptions = 1.867f, WaitingTime = 45 });
            datas.Add(new FastScatterModel() { Eruptions = 4.167f, WaitingTime = 83 });
            datas.Add(new FastScatterModel() { Eruptions = 2.800f, WaitingTime = 56 });
            datas.Add(new FastScatterModel() { Eruptions = 4.333f, WaitingTime = 89 });
            datas.Add(new FastScatterModel() { Eruptions = 1.833f, WaitingTime = 46 });
            datas.Add(new FastScatterModel() { Eruptions = 4.383f, WaitingTime = 82 });
            datas.Add(new FastScatterModel() { Eruptions = 1.883f, WaitingTime = 51 });
            datas.Add(new FastScatterModel() { Eruptions = 4.933f, WaitingTime = 86 });
            datas.Add(new FastScatterModel() { Eruptions = 2.033f, WaitingTime = 53 });
            datas.Add(new FastScatterModel() { Eruptions = 3.733f, WaitingTime = 79 });
            datas.Add(new FastScatterModel() { Eruptions = 4.233f, WaitingTime = 81 });
            datas.Add(new FastScatterModel() { Eruptions = 2.233f, WaitingTime = 60 });
            datas.Add(new FastScatterModel() { Eruptions = 4.533f, WaitingTime = 82 });
            datas.Add(new FastScatterModel() { Eruptions = 4.817f, WaitingTime = 77 });
            datas.Add(new FastScatterModel() { Eruptions = 4.333f, WaitingTime = 76 });
            datas.Add(new FastScatterModel() { Eruptions = 1.983f, WaitingTime = 59 });
            datas.Add(new FastScatterModel() { Eruptions = 4.633f, WaitingTime = 80 });
            datas.Add(new FastScatterModel() { Eruptions = 2.017f, WaitingTime = 49 });
            datas.Add(new FastScatterModel() { Eruptions = 5.100f, WaitingTime = 96 });
            datas.Add(new FastScatterModel() { Eruptions = 1.800f, WaitingTime = 53 });
            datas.Add(new FastScatterModel() { Eruptions = 5.033f, WaitingTime = 77 });
            datas.Add(new FastScatterModel() { Eruptions = 4.000f, WaitingTime = 77 });
            datas.Add(new FastScatterModel() { Eruptions = 2.400f, WaitingTime = 65 });
            datas.Add(new FastScatterModel() { Eruptions = 4.600f, WaitingTime = 81 });
            datas.Add(new FastScatterModel() { Eruptions = 3.567f, WaitingTime = 71 });
            datas.Add(new FastScatterModel() { Eruptions = 4.000f, WaitingTime = 70 });
            datas.Add(new FastScatterModel() { Eruptions = 4.500f, WaitingTime = 81 });
            datas.Add(new FastScatterModel() { Eruptions = 4.083f, WaitingTime = 93 });
            datas.Add(new FastScatterModel() { Eruptions = 1.800f, WaitingTime = 53 });
            datas.Add(new FastScatterModel() { Eruptions = 3.967f, WaitingTime = 89 });
            datas.Add(new FastScatterModel() { Eruptions = 2.200f, WaitingTime = 45 });
            datas.Add(new FastScatterModel() { Eruptions = 4.150f, WaitingTime = 86 });
            datas.Add(new FastScatterModel() { Eruptions = 2.000f, WaitingTime = 58 });
            datas.Add(new FastScatterModel() { Eruptions = 3.833f, WaitingTime = 78 });
            datas.Add(new FastScatterModel() { Eruptions = 3.500f, WaitingTime = 66 });
            datas.Add(new FastScatterModel() { Eruptions = 4.583f, WaitingTime = 76 });
            datas.Add(new FastScatterModel() { Eruptions = 2.367f, WaitingTime = 63 });
            datas.Add(new FastScatterModel() { Eruptions = 5.000f, WaitingTime = 88 });
            datas.Add(new FastScatterModel() { Eruptions = 1.933f, WaitingTime = 52 });
            datas.Add(new FastScatterModel() { Eruptions = 4.617f, WaitingTime = 93 });
            datas.Add(new FastScatterModel() { Eruptions = 1.917f, WaitingTime = 49 });
            datas.Add(new FastScatterModel() { Eruptions = 2.083f, WaitingTime = 57 });
            datas.Add(new FastScatterModel() { Eruptions = 4.583f, WaitingTime = 77 });
            datas.Add(new FastScatterModel() { Eruptions = 3.333f, WaitingTime = 68 });
            datas.Add(new FastScatterModel() { Eruptions = 4.167f, WaitingTime = 81 });
            datas.Add(new FastScatterModel() { Eruptions = 4.333f, WaitingTime = 81 });
            datas.Add(new FastScatterModel() { Eruptions = 4.500f, WaitingTime = 73 });
            datas.Add(new FastScatterModel() { Eruptions = 2.417f, WaitingTime = 50 });
            datas.Add(new FastScatterModel() { Eruptions = 4.000f, WaitingTime = 85 });
            datas.Add(new FastScatterModel() { Eruptions = 4.167f, WaitingTime = 74 });
            datas.Add(new FastScatterModel() { Eruptions = 1.883f, WaitingTime = 55 });
            datas.Add(new FastScatterModel() { Eruptions = 4.583f, WaitingTime = 77 });
            datas.Add(new FastScatterModel() { Eruptions = 4.250f, WaitingTime = 83 });
            datas.Add(new FastScatterModel() { Eruptions = 3.767f, WaitingTime = 83 });
            datas.Add(new FastScatterModel() { Eruptions = 2.033f, WaitingTime = 51 });
            datas.Add(new FastScatterModel() { Eruptions = 4.433f, WaitingTime = 78 });
            datas.Add(new FastScatterModel() { Eruptions = 4.083f, WaitingTime = 84 });
            datas.Add(new FastScatterModel() { Eruptions = 1.833f, WaitingTime = 46 });
            datas.Add(new FastScatterModel() { Eruptions = 4.417f, WaitingTime = 83 });
            datas.Add(new FastScatterModel() { Eruptions = 2.183f, WaitingTime = 55 });
            datas.Add(new FastScatterModel() { Eruptions = 4.800f, WaitingTime = 81 });
            datas.Add(new FastScatterModel() { Eruptions = 1.833f, WaitingTime = 57 });
            datas.Add(new FastScatterModel() { Eruptions = 4.800f, WaitingTime = 76 });
            datas.Add(new FastScatterModel() { Eruptions = 4.100f, WaitingTime = 84 });
            datas.Add(new FastScatterModel() { Eruptions = 3.966f, WaitingTime = 77 });
            datas.Add(new FastScatterModel() { Eruptions = 4.233f, WaitingTime = 81 });
            datas.Add(new FastScatterModel() { Eruptions = 3.500f, WaitingTime = 87 });
            datas.Add(new FastScatterModel() { Eruptions = 4.366f, WaitingTime = 77 });
            datas.Add(new FastScatterModel() { Eruptions = 2.250f, WaitingTime = 51 });
            datas.Add(new FastScatterModel() { Eruptions = 4.667f, WaitingTime = 78 });
            datas.Add(new FastScatterModel() { Eruptions = 2.100f, WaitingTime = 60 });
            datas.Add(new FastScatterModel() { Eruptions = 4.350f, WaitingTime = 82 });
            datas.Add(new FastScatterModel() { Eruptions = 4.133f, WaitingTime = 91 });
            datas.Add(new FastScatterModel() { Eruptions = 1.867f, WaitingTime = 53 });
            datas.Add(new FastScatterModel() { Eruptions = 4.600f, WaitingTime = 78 });
            datas.Add(new FastScatterModel() { Eruptions = 1.783f, WaitingTime = 46 });
            datas.Add(new FastScatterModel() { Eruptions = 4.367f, WaitingTime = 77 });
            datas.Add(new FastScatterModel() { Eruptions = 3.850f, WaitingTime = 84 });
            datas.Add(new FastScatterModel() { Eruptions = 1.933f, WaitingTime = 49 });
            datas.Add(new FastScatterModel() { Eruptions = 4.500f, WaitingTime = 83 });
            datas.Add(new FastScatterModel() { Eruptions = 2.383f, WaitingTime = 71 });
            datas.Add(new FastScatterModel() { Eruptions = 4.700f, WaitingTime = 80 });
            datas.Add(new FastScatterModel() { Eruptions = 1.867f, WaitingTime = 49 });
            datas.Add(new FastScatterModel() { Eruptions = 3.833f, WaitingTime = 75 });
            datas.Add(new FastScatterModel() { Eruptions = 3.417f, WaitingTime = 64 });
            datas.Add(new FastScatterModel() { Eruptions = 4.233f, WaitingTime = 76 });
            datas.Add(new FastScatterModel() { Eruptions = 2.400f, WaitingTime = 53 });
            datas.Add(new FastScatterModel() { Eruptions = 4.800f, WaitingTime = 94 });
            datas.Add(new FastScatterModel() { Eruptions = 2.000f, WaitingTime = 55 });
            datas.Add(new FastScatterModel() { Eruptions = 4.150f, WaitingTime = 76 });
            datas.Add(new FastScatterModel() { Eruptions = 1.867f, WaitingTime = 50 });
            datas.Add(new FastScatterModel() { Eruptions = 4.267f, WaitingTime = 82 });
            datas.Add(new FastScatterModel() { Eruptions = 1.750f, WaitingTime = 54 });
            datas.Add(new FastScatterModel() { Eruptions = 4.483f, WaitingTime = 75 });
            datas.Add(new FastScatterModel() { Eruptions = 4.000f, WaitingTime = 78 });
            datas.Add(new FastScatterModel() { Eruptions = 4.117f, WaitingTime = 79 });
            datas.Add(new FastScatterModel() { Eruptions = 4.083f, WaitingTime = 78 });
            datas.Add(new FastScatterModel() { Eruptions = 4.267f, WaitingTime = 78 });
            datas.Add(new FastScatterModel() { Eruptions = 3.917f, WaitingTime = 70 });
            datas.Add(new FastScatterModel() { Eruptions = 4.550f, WaitingTime = 79 });
            datas.Add(new FastScatterModel() { Eruptions = 4.083f, WaitingTime = 70 });
            datas.Add(new FastScatterModel() { Eruptions = 2.417f, WaitingTime = 54 });
            datas.Add(new FastScatterModel() { Eruptions = 4.183f, WaitingTime = 86 });
            datas.Add(new FastScatterModel() { Eruptions = 2.217f, WaitingTime = 50 });
            datas.Add(new FastScatterModel() { Eruptions = 4.450f, WaitingTime = 90 });
            datas.Add(new FastScatterModel() { Eruptions = 1.883f, WaitingTime = 54 });
            datas.Add(new FastScatterModel() { Eruptions = 1.850f, WaitingTime = 54 });
            datas.Add(new FastScatterModel() { Eruptions = 4.283f, WaitingTime = 77 });
            datas.Add(new FastScatterModel() { Eruptions = 3.950f, WaitingTime = 79 });
            datas.Add(new FastScatterModel() { Eruptions = 2.333f, WaitingTime = 64 });
            datas.Add(new FastScatterModel() { Eruptions = 4.150f, WaitingTime = 75 });
            datas.Add(new FastScatterModel() { Eruptions = 2.350f, WaitingTime = 47 });
            datas.Add(new FastScatterModel() { Eruptions = 4.933f, WaitingTime = 86 });
            datas.Add(new FastScatterModel() { Eruptions = 2.900f, WaitingTime = 63 });
            datas.Add(new FastScatterModel() { Eruptions = 4.583f, WaitingTime = 85 });
            datas.Add(new FastScatterModel() { Eruptions = 3.833f, WaitingTime = 82 });
            datas.Add(new FastScatterModel() { Eruptions = 2.083f, WaitingTime = 57 });
            datas.Add(new FastScatterModel() { Eruptions = 4.367f, WaitingTime = 82 });
            datas.Add(new FastScatterModel() { Eruptions = 2.133f, WaitingTime = 67 });
            datas.Add(new FastScatterModel() { Eruptions = 4.350f, WaitingTime = 74 });
            datas.Add(new FastScatterModel() { Eruptions = 2.200f, WaitingTime = 54 });
            datas.Add(new FastScatterModel() { Eruptions = 4.450f, WaitingTime = 83 });
            datas.Add(new FastScatterModel() { Eruptions = 3.567f, WaitingTime = 73 });
            datas.Add(new FastScatterModel() { Eruptions = 4.500f, WaitingTime = 73 });
            datas.Add(new FastScatterModel() { Eruptions = 4.150f, WaitingTime = 88 });
            datas.Add(new FastScatterModel() { Eruptions = 3.817f, WaitingTime = 80 });
            datas.Add(new FastScatterModel() { Eruptions = 3.917f, WaitingTime = 71 });
            datas.Add(new FastScatterModel() { Eruptions = 4.450f, WaitingTime = 83 });
            datas.Add(new FastScatterModel() { Eruptions = 2.000f, WaitingTime = 56 });
            datas.Add(new FastScatterModel() { Eruptions = 4.283f, WaitingTime = 79 });
            datas.Add(new FastScatterModel() { Eruptions = 4.767f, WaitingTime = 78 });
            datas.Add(new FastScatterModel() { Eruptions = 4.533f, WaitingTime = 84 });
            datas.Add(new FastScatterModel() { Eruptions = 1.850f, WaitingTime = 58 });
            datas.Add(new FastScatterModel() { Eruptions = 4.250f, WaitingTime = 83 });
            datas.Add(new FastScatterModel() { Eruptions = 1.983f, WaitingTime = 43 });
            datas.Add(new FastScatterModel() { Eruptions = 2.250f, WaitingTime = 60 });
            datas.Add(new FastScatterModel() { Eruptions = 4.750f, WaitingTime = 75 });
            datas.Add(new FastScatterModel() { Eruptions = 4.117f, WaitingTime = 81 });
            datas.Add(new FastScatterModel() { Eruptions = 2.150f, WaitingTime = 46 });
            datas.Add(new FastScatterModel() { Eruptions = 4.417f, WaitingTime = 90 });
            datas.Add(new FastScatterModel() { Eruptions = 1.817f, WaitingTime = 46 });
            datas.Add(new FastScatterModel() { Eruptions = 4.467f, WaitingTime = 74 });




            datas.Add(new FastScatterModel() { Eruptions = 2.283f, WaitingTime = 45 });
            datas.Add(new FastScatterModel() { Eruptions = 2.767f, WaitingTime = 67 });
            datas.Add(new FastScatterModel() { Eruptions = 2.533f, WaitingTime = 55 });
            datas.Add(new FastScatterModel() { Eruptions = 2.850f, WaitingTime = 58 });
            datas.Add(new FastScatterModel() { Eruptions = 2.250f, WaitingTime = 51 });
            datas.Add(new FastScatterModel() { Eruptions = 2.983f, WaitingTime = 43 });
            datas.Add(new FastScatterModel() { Eruptions = 2.250f, WaitingTime = 60 });
            datas.Add(new FastScatterModel() { Eruptions = 2.750f, WaitingTime = 59 });
            datas.Add(new FastScatterModel() { Eruptions = 2.117f, WaitingTime = 55 });
            datas.Add(new FastScatterModel() { Eruptions = 2.150f, WaitingTime = 46 });
            datas.Add(new FastScatterModel() { Eruptions = 2.417f, WaitingTime = 58 });
            datas.Add(new FastScatterModel() { Eruptions = 2.817f, WaitingTime = 51 });
            datas.Add(new FastScatterModel() { Eruptions = 2.467f, WaitingTime = 48 });

            datas.Add(new FastScatterModel() { Eruptions = 2.283f, WaitingTime = 43 });
            datas.Add(new FastScatterModel() { Eruptions = 2.233f, WaitingTime = 55 });
            datas.Add(new FastScatterModel() { Eruptions = 2.250f, WaitingTime = 58 });
            datas.Add(new FastScatterModel() { Eruptions = 2.267f, WaitingTime = 51 });
            datas.Add(new FastScatterModel() { Eruptions = 2.250f, WaitingTime = 51 });
            datas.Add(new FastScatterModel() { Eruptions = 2.283f, WaitingTime = 55 });
            datas.Add(new FastScatterModel() { Eruptions = 2.250f, WaitingTime = 56 });
            datas.Add(new FastScatterModel() { Eruptions = 2.250f, WaitingTime = 59 });
            datas.Add(new FastScatterModel() { Eruptions = 2.217f, WaitingTime = 55 });
            datas.Add(new FastScatterModel() { Eruptions = 2.250f, WaitingTime = 60 });
            datas.Add(new FastScatterModel() { Eruptions = 2.317f, WaitingTime = 58 });
            datas.Add(new FastScatterModel() { Eruptions = 2.317f, WaitingTime = 51 });
            datas.Add(new FastScatterModel() { Eruptions = 2.367f, WaitingTime = 48 });

            datas.Add(new FastScatterModel() { Eruptions = 2.183f, WaitingTime = 43 });
            datas.Add(new FastScatterModel() { Eruptions = 2.133f, WaitingTime = 55 });
            datas.Add(new FastScatterModel() { Eruptions = 2.150f, WaitingTime = 58 });
            datas.Add(new FastScatterModel() { Eruptions = 2.167f, WaitingTime = 51 });
            datas.Add(new FastScatterModel() { Eruptions = 2.150f, WaitingTime = 51 });
            datas.Add(new FastScatterModel() { Eruptions = 2.183f, WaitingTime = 55 });
            datas.Add(new FastScatterModel() { Eruptions = 2.150f, WaitingTime = 56 });
            datas.Add(new FastScatterModel() { Eruptions = 2.150f, WaitingTime = 59 });
            datas.Add(new FastScatterModel() { Eruptions = 2.117f, WaitingTime = 55 });
            datas.Add(new FastScatterModel() { Eruptions = 2.150f, WaitingTime = 60 });
            datas.Add(new FastScatterModel() { Eruptions = 2.117f, WaitingTime = 58 });
            datas.Add(new FastScatterModel() { Eruptions = 2.117f, WaitingTime = 51 });
            datas.Add(new FastScatterModel() { Eruptions = 2.167f, WaitingTime = 48 });

            datas.Add(new FastScatterModel() { Eruptions = 2.083f, WaitingTime = 43 });
            datas.Add(new FastScatterModel() { Eruptions = 2.033f, WaitingTime = 55 });
            datas.Add(new FastScatterModel() { Eruptions = 2.050f, WaitingTime = 58 });
            datas.Add(new FastScatterModel() { Eruptions = 2.067f, WaitingTime = 51 });
            datas.Add(new FastScatterModel() { Eruptions = 2.050f, WaitingTime = 51 });
            datas.Add(new FastScatterModel() { Eruptions = 2.083f, WaitingTime = 55 });
            datas.Add(new FastScatterModel() { Eruptions = 2.050f, WaitingTime = 56 });
            datas.Add(new FastScatterModel() { Eruptions = 2.050f, WaitingTime = 59 });
            datas.Add(new FastScatterModel() { Eruptions = 2.017f, WaitingTime = 55 });
            datas.Add(new FastScatterModel() { Eruptions = 2.050f, WaitingTime = 60 });
            datas.Add(new FastScatterModel() { Eruptions = 2.017f, WaitingTime = 58 });
            datas.Add(new FastScatterModel() { Eruptions = 2.017f, WaitingTime = 51 });
            datas.Add(new FastScatterModel() { Eruptions = 2.067f, WaitingTime = 48 });


            datas.Add(new FastScatterModel() { Eruptions = 4.583f, WaitingTime = 83 });
            datas.Add(new FastScatterModel() { Eruptions = 4.533f, WaitingTime = 85 });
            datas.Add(new FastScatterModel() { Eruptions = 4.550f, WaitingTime = 88 });
            datas.Add(new FastScatterModel() { Eruptions = 4.567f, WaitingTime = 81 });
            datas.Add(new FastScatterModel() { Eruptions = 4.550f, WaitingTime = 87 });
            datas.Add(new FastScatterModel() { Eruptions = 4.583f, WaitingTime = 85 });
            datas.Add(new FastScatterModel() { Eruptions = 4.550f, WaitingTime = 86 });
            datas.Add(new FastScatterModel() { Eruptions = 4.550f, WaitingTime = 84 });
            datas.Add(new FastScatterModel() { Eruptions = 4.517f, WaitingTime = 85 });
            datas.Add(new FastScatterModel() { Eruptions = 4.550f, WaitingTime = 80 });
            datas.Add(new FastScatterModel() { Eruptions = 4.517f, WaitingTime = 86 });
            datas.Add(new FastScatterModel() { Eruptions = 4.517f, WaitingTime = 81 });
            datas.Add(new FastScatterModel() { Eruptions = 4.567f, WaitingTime = 88 });

            datas.Add(new FastScatterModel() { Eruptions = 4.483f, WaitingTime = 83 });
            datas.Add(new FastScatterModel() { Eruptions = 4.433f, WaitingTime = 85 });
            datas.Add(new FastScatterModel() { Eruptions = 4.450f, WaitingTime = 88 });
            datas.Add(new FastScatterModel() { Eruptions = 4.467f, WaitingTime = 81 });
            datas.Add(new FastScatterModel() { Eruptions = 4.450f, WaitingTime = 87 });
            datas.Add(new FastScatterModel() { Eruptions = 4.483f, WaitingTime = 85 });
            datas.Add(new FastScatterModel() { Eruptions = 4.450f, WaitingTime = 86 });
            datas.Add(new FastScatterModel() { Eruptions = 4.450f, WaitingTime = 84 });
            datas.Add(new FastScatterModel() { Eruptions = 4.417f, WaitingTime = 85 });
            datas.Add(new FastScatterModel() { Eruptions = 4.450f, WaitingTime = 80 });
            datas.Add(new FastScatterModel() { Eruptions = 4.417f, WaitingTime = 86 });
            datas.Add(new FastScatterModel() { Eruptions = 4.417f, WaitingTime = 81 });
            datas.Add(new FastScatterModel() { Eruptions = 4.467f, WaitingTime = 88 });

            return datas;
        }

        public void Dispose()
        {
            if (DataCollection != null)
                DataCollection.Clear();
        }
    }
}
