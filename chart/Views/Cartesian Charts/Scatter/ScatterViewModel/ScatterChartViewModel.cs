#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace Syncfusion.ChartDemos.WinUI
{
    public class ScatterChartViewModel : IDisposable
    {
        public ObservableCollection<ScatterChartModel> MaleData { get; set; }
        public ObservableCollection<ScatterChartModel> FemaleData { get; set; }

        public ScatterChartViewModel() 
        {
            MaleData = new ObservableCollection<ScatterChartModel>()
            {
                new ScatterChartModel( 161, 65 ), new ScatterChartModel( 150,  65 ), new ScatterChartModel(155,  65 ), new ScatterChartModel(160, 65 ),
                new ScatterChartModel( 148, 66 ), new ScatterChartModel( 145,  66 ), new ScatterChartModel(137,  66 ), new ScatterChartModel(138, 66 ),
                new ScatterChartModel( 162, 66 ), new ScatterChartModel( 166,  66 ), new ScatterChartModel(159,  66 ), new ScatterChartModel(151, 66 ),
                new ScatterChartModel( 180, 66 ), new ScatterChartModel( 181,  66 ), new ScatterChartModel(174,  66 ), new ScatterChartModel(159, 66 ),
                new ScatterChartModel( 151, 67 ), new ScatterChartModel( 148,  67 ), new ScatterChartModel(141,  67 ), new ScatterChartModel(145, 67 ),
                new ScatterChartModel( 165, 67 ), new ScatterChartModel( 168,  67 ), new ScatterChartModel(159,  67 ), new ScatterChartModel(183, 67 ),
                new ScatterChartModel( 188, 67 ), new ScatterChartModel( 187,  67 ), new ScatterChartModel(172,  67 ), new ScatterChartModel(193, 67 ),
                new ScatterChartModel( 153, 68 ), new ScatterChartModel( 153,  68 ), new ScatterChartModel(147,  68 ), new ScatterChartModel(163, 68 ),
                new ScatterChartModel( 174, 68 ), new ScatterChartModel( 173,  68 ), new ScatterChartModel(160,  68 ), new ScatterChartModel(191, 68 ),
                new ScatterChartModel( 131, 62 ), new ScatterChartModel( 140,  62 ), new ScatterChartModel(149,  62 ), new ScatterChartModel(115, 62 ),
                new ScatterChartModel( 164, 63 ), new ScatterChartModel( 162,  63 ), new ScatterChartModel(167,  63 ), new ScatterChartModel(146, 63 ),
                new ScatterChartModel( 150, 64 ), new ScatterChartModel( 141,  64 ), new ScatterChartModel(142,  64 ), new ScatterChartModel(129, 64 ),
                new ScatterChartModel( 159, 64 ), new ScatterChartModel( 158,  64 ), new ScatterChartModel(162,  64 ), new ScatterChartModel(136, 64 ),
                new ScatterChartModel( 176, 64 ), new ScatterChartModel( 170,  64 ), new ScatterChartModel(167,  64 ), new ScatterChartModel(144, 64 ),
                new ScatterChartModel( 143, 65 ), new ScatterChartModel( 137,  65 ), new ScatterChartModel(137,  65 ), new ScatterChartModel(140, 65 ),
                new ScatterChartModel( 182, 65 ), new ScatterChartModel( 168,  65 ), new ScatterChartModel(181,  65 ), new ScatterChartModel(165, 65 ),
                new ScatterChartModel( 214, 74 ), new ScatterChartModel( 211,  74 ), new ScatterChartModel(166,  74 ), new ScatterChartModel(185, 74 ),
                new ScatterChartModel( 189, 68 ), new ScatterChartModel( 182,  68 ), new ScatterChartModel(181,  68 ), new ScatterChartModel(196, 68 ),
                new ScatterChartModel( 152, 69 ), new ScatterChartModel( 173,  69 ), new ScatterChartModel(190,  69 ), new ScatterChartModel(161, 69 ),
                new ScatterChartModel( 173, 69 ), new ScatterChartModel( 185,  69 ), new ScatterChartModel(141,  69 ), new ScatterChartModel(149, 69 ),
                new ScatterChartModel( 134, 62 ), new ScatterChartModel( 183,  62 ), new ScatterChartModel(155,  62 ), new ScatterChartModel(164, 62 ),
                new ScatterChartModel( 169, 62 ), new ScatterChartModel( 122,  62 ), new ScatterChartModel(161,  62 ), new ScatterChartModel(166, 62 ),
                new ScatterChartModel( 137, 63 ), new ScatterChartModel( 140,  63 ), new ScatterChartModel(140,  63 ), new ScatterChartModel(126, 63 ),
                new ScatterChartModel( 150, 63 ), new ScatterChartModel( 153,  63 ), new ScatterChartModel(154,  63 ), new ScatterChartModel(139, 63 ),
                new ScatterChartModel( 186, 69 ), new ScatterChartModel( 188,  69 ), new ScatterChartModel(148,  69 ), new ScatterChartModel(174, 69 ),
                new ScatterChartModel( 164, 70 ), new ScatterChartModel( 182,  70 ), new ScatterChartModel(200,  70 ), new ScatterChartModel(151, 70 ),
                new ScatterChartModel( 204, 74 ), new ScatterChartModel( 177,  74 ), new ScatterChartModel(194,  74 ), new ScatterChartModel(212, 74 ),
                new ScatterChartModel( 162, 70 ), new ScatterChartModel( 200,  70 ), new ScatterChartModel(166,  70 ), new ScatterChartModel(177, 70 ),
                new ScatterChartModel( 188, 70 ), new ScatterChartModel( 156,  70 ), new ScatterChartModel(175,  70 ), new ScatterChartModel(191, 70 ),
                new ScatterChartModel( 174, 71 ), new ScatterChartModel( 187,  71 ), new ScatterChartModel(208,  71 ), new ScatterChartModel(166, 71 ),
                new ScatterChartModel( 150, 71 ), new ScatterChartModel( 194,  71 ), new ScatterChartModel(157,  71 ), new ScatterChartModel(183, 71 ),
                new ScatterChartModel( 204, 71 ), new ScatterChartModel( 162,  71 ), new ScatterChartModel(179,  71 ), new ScatterChartModel(196, 71 ),
                new ScatterChartModel( 170, 72 ), new ScatterChartModel( 184,  72 ), new ScatterChartModel(197,  72 ), new ScatterChartModel(162, 72 ),
                new ScatterChartModel( 177, 72 ), new ScatterChartModel( 203,  72 ), new ScatterChartModel(159,  72 ), new ScatterChartModel(178, 72 ),
                new ScatterChartModel( 198, 72 ), new ScatterChartModel( 167,  72 ), new ScatterChartModel(184,  72 ), new ScatterChartModel(201, 72 ),
                new ScatterChartModel( 167, 73 ), new ScatterChartModel( 178,  73 ), new ScatterChartModel(215,  73 ), new ScatterChartModel(207, 73 ),
                new ScatterChartModel( 172, 73 ), new ScatterChartModel( 204,  73 ), new ScatterChartModel(162,  73 ), new ScatterChartModel(182, 73 ),
                new ScatterChartModel( 201, 73 ), new ScatterChartModel( 172,  73 ), new ScatterChartModel(189,  73 ), new ScatterChartModel(206, 73 ),
                new ScatterChartModel( 150, 74 ), new ScatterChartModel( 187,  74 ), new ScatterChartModel(153,  74 ), new ScatterChartModel(171, 74 ),
            };

            FemaleData = new ObservableCollection<ScatterChartModel>()
            {
                new ScatterChartModel(115, 57 ), new ScatterChartModel(138, 57 ), new ScatterChartModel(166, 57 ), new ScatterChartModel(122,  57 ),
                new ScatterChartModel(126, 57 ), new ScatterChartModel(130, 57 ), new ScatterChartModel(125, 57 ), new ScatterChartModel(144,  57 ),
                new ScatterChartModel(150, 57 ), new ScatterChartModel(120, 57 ), new ScatterChartModel(125, 57 ), new ScatterChartModel(130,  57 ),
                new ScatterChartModel(103, 58 ), new ScatterChartModel(116, 58 ), new ScatterChartModel(130, 58 ), new ScatterChartModel(126,  58 ),
                new ScatterChartModel(136, 58 ), new ScatterChartModel(148, 58 ), new ScatterChartModel(119, 58 ), new ScatterChartModel(141,  58 ),
                new ScatterChartModel(159, 58 ), new ScatterChartModel(120, 58 ), new ScatterChartModel(135, 58 ), new ScatterChartModel(163,  58 ),
                new ScatterChartModel(119, 59 ), new ScatterChartModel(131, 59 ), new ScatterChartModel(148, 59 ), new ScatterChartModel(123,  59 ),
                new ScatterChartModel(137, 59 ), new ScatterChartModel(149, 59 ), new ScatterChartModel(121, 59 ), new ScatterChartModel(142,  59 ),
                new ScatterChartModel(160, 59 ), new ScatterChartModel(118, 59 ), new ScatterChartModel(130, 59 ), new ScatterChartModel(146,  59 ),
                new ScatterChartModel(119, 60 ), new ScatterChartModel(133, 60 ), new ScatterChartModel(150, 60 ), new ScatterChartModel(133,  60 ),
                new ScatterChartModel(149, 60 ), new ScatterChartModel(165, 60 ), new ScatterChartModel(130, 60 ), new ScatterChartModel(139,  60 ),
                new ScatterChartModel(154, 60 ), new ScatterChartModel(118, 60 ), new ScatterChartModel(152, 60 ), new ScatterChartModel(154,  60 ),
                new ScatterChartModel(130, 61 ), new ScatterChartModel(145, 61 ), new ScatterChartModel(166, 61 ), new ScatterChartModel(131,  61 ),
                new ScatterChartModel(143, 61 ), new ScatterChartModel(162, 61 ), new ScatterChartModel(131, 61 ), new ScatterChartModel(145,  61 ),
                new ScatterChartModel(162, 61 ), new ScatterChartModel(115, 61 ), new ScatterChartModel(149, 61 ), new ScatterChartModel(183,  61 ),
                new ScatterChartModel(121, 62 ), new ScatterChartModel(139, 62 ), new ScatterChartModel(159, 62 ), new ScatterChartModel(135,  62 ),
                new ScatterChartModel(152, 62 ), new ScatterChartModel(178, 62 ), new ScatterChartModel(130, 62 ), new ScatterChartModel(153,  62 ),
                new ScatterChartModel(172, 62 ), new ScatterChartModel(114, 62 ), new ScatterChartModel(135, 62 ), new ScatterChartModel(154,  62 ),
                new ScatterChartModel(126, 63 ), new ScatterChartModel(141, 63 ), new ScatterChartModel(160, 63 ), new ScatterChartModel(135,  63 ),
                new ScatterChartModel(149, 63 ), new ScatterChartModel(180, 63 ), new ScatterChartModel(132, 63 ), new ScatterChartModel(144,  63 ),
                new ScatterChartModel(163, 63 ), new ScatterChartModel(122, 63 ), new ScatterChartModel(146, 63 ), new ScatterChartModel(156,  63 ),
                new ScatterChartModel(133, 64 ), new ScatterChartModel(150, 64 ), new ScatterChartModel(176, 64 ), new ScatterChartModel(133,  64 ),
                new ScatterChartModel(149, 64 ), new ScatterChartModel(176, 64 ), new ScatterChartModel(136, 64 ), new ScatterChartModel(157,  64 ),
                new ScatterChartModel(174, 64 ), new ScatterChartModel(131, 64 ), new ScatterChartModel(155, 64 ), new ScatterChartModel(191,  64 ),
                new ScatterChartModel(136, 65 ), new ScatterChartModel(149, 65 ), new ScatterChartModel(177, 65 ), new ScatterChartModel(143,  65 ),
                new ScatterChartModel(149, 65 ), new ScatterChartModel(184, 65 ), new ScatterChartModel(128, 65 ), new ScatterChartModel(146,  65 ),
                new ScatterChartModel(157, 65 ), new ScatterChartModel(133, 65 ), new ScatterChartModel(153, 65 ), new ScatterChartModel(173,  65 ),
                new ScatterChartModel(141, 66 ), new ScatterChartModel(156, 66 ), new ScatterChartModel(175, 66 ), new ScatterChartModel(125,  66 ),
                new ScatterChartModel(138, 66 ), new ScatterChartModel(165, 66 ), new ScatterChartModel(122, 66 ), new ScatterChartModel(164,  66 ),
                new ScatterChartModel(182, 66 ), new ScatterChartModel(137, 66 ), new ScatterChartModel(157, 66 ), new ScatterChartModel(176,  66 ),
                new ScatterChartModel(149, 67 ), new ScatterChartModel(159, 67 ), new ScatterChartModel(179, 67 ), new ScatterChartModel(156,  67 ),
                new ScatterChartModel(179, 67 ), new ScatterChartModel(186, 67 ), new ScatterChartModel(147, 67 ), new ScatterChartModel(166,  67 ),
                new ScatterChartModel(185, 67 ), new ScatterChartModel(140, 67 ), new ScatterChartModel(160, 67 ), new ScatterChartModel(180,  67 ),
                new ScatterChartModel(145, 68 ), new ScatterChartModel(155, 68 ), new ScatterChartModel(170, 68 ), new ScatterChartModel(129,  68 ),
                new ScatterChartModel(164, 68 ), new ScatterChartModel(189, 68 ), new ScatterChartModel(150, 68 ), new ScatterChartModel(157,  68 ),
                new ScatterChartModel(183, 68 ), new ScatterChartModel(144, 68 ), new ScatterChartModel(170, 68 ), new ScatterChartModel(180,  68 )
            };
        }

        public void Dispose()
        {
            if(MaleData != null)
                MaleData.Clear();

            if(FemaleData != null)
                FemaleData.Clear();
        }
    }
}



