#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Syncfusion.PdfDemos.WinUI
{
    public sealed partial class Annotations : Page
    {

        public Annotations()
        {
            this.InitializeComponent();

        
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.PdfDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Pdf.";
#endif

            //Create a new PDF document.
            PdfDocument document = new PdfDocument();
            //Creates a new page
            PdfPage page = document.Pages.Add();
            //Sets the margins to the page.
            document.PageSettings.SetMargins(0);
            //Create new PDF font instance.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f);
            //Create new PDF solid brush.
            PdfBrush brush = new PdfSolidBrush(Color.FromArgb(255, 0, 0, 0));

            //Draw the text to PDF page graphics. 
            string text = "Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European and Asian commercial markets. While its base operation is located in Washington with 290 employees, several regional sales teams are located throughout their market base.";
            page.Graphics.DrawString("Annotation with Comments and Reviews", font, brush, new PointF(30, 10));
            page.Graphics.DrawString(text, font, brush, new RectangleF(30, 40, page.GetClientSize().Width - 60, 60));

            //Creates PDF text markup annotation.
            string markupText = "North American, European and Asian commercial markets";
            PdfTextMarkupAnnotation textMarkupAnnotation = new PdfTextMarkupAnnotation("sample", "Highlight", markupText, new PointF(147, 63.5f), font);
            textMarkupAnnotation.Author = "Annotation";
            textMarkupAnnotation.Opacity = 1.0f;
            textMarkupAnnotation.Subject = "Comments and Reviews";
            textMarkupAnnotation.ModifiedDate = new DateTime(2015, 1, 18);
            textMarkupAnnotation.TextMarkupAnnotationType = PdfTextMarkupAnnotationType.Highlight;
            textMarkupAnnotation.TextMarkupColor = new PdfColor(Color.Yellow);
            textMarkupAnnotation.InnerColor = new PdfColor(Color.Red);
            textMarkupAnnotation.Color = new PdfColor(Color.Yellow);
            textMarkupAnnotation.AnnotationFlags = PdfAnnotationFlags.Print;

            //Create a new comment.
            PdfPopupAnnotation userQuery = new PdfPopupAnnotation();
            userQuery.Author = "John";
            userQuery.Text = "Can you please change South Asian to Asian?";
            userQuery.ModifiedDate = new DateTime(2015, 1, 18);
            //Add comment to the annotation
            textMarkupAnnotation.Comments.Add(userQuery);

            //Creates a new comment.
            PdfPopupAnnotation userAnswer = new PdfPopupAnnotation();
            userAnswer.Author = "Smith";
            userAnswer.Text = "South Asian has changed as Asian";
            userAnswer.ModifiedDate = new DateTime(2015, 1, 18);
            //Add comment to the annotation.
            textMarkupAnnotation.Comments.Add(userAnswer);

            //Creates a new review.
            PdfPopupAnnotation userAnswerReview = new PdfPopupAnnotation();
            userAnswerReview.Author = "Smith";
            userAnswerReview.State = PdfAnnotationState.Completed;
            userAnswerReview.StateModel = PdfAnnotationStateModel.Review;
            userAnswerReview.ModifiedDate = new DateTime(2015, 1, 18);
            //Add review to the comment.
            userAnswer.ReviewHistory.Add(userAnswerReview);

            //Creates a new review.
            PdfPopupAnnotation userAnswerReviewJohn = new PdfPopupAnnotation();
            userAnswerReviewJohn.Author = "John";
            userAnswerReviewJohn.State = PdfAnnotationState.Accepted;
            userAnswerReviewJohn.StateModel = PdfAnnotationStateModel.Review;
            userAnswerReviewJohn.ModifiedDate = new DateTime(2015, 1, 18);
            //Add review to the comment.
            userAnswer.ReviewHistory.Add(userAnswerReviewJohn);

            //Add annotation to the page.
            page.Annotations.Add(textMarkupAnnotation);

            //Creates a new Circle annotation.
            PdfCircleAnnotation circleAnnotation = new PdfCircleAnnotation(new RectangleF(350, 170, 80, 80));
            circleAnnotation.InnerColor = new PdfColor(Color.Yellow);
            circleAnnotation.Color = new PdfColor(Color.Red);
            circleAnnotation.AnnotationFlags = PdfAnnotationFlags.Default | PdfAnnotationFlags.Print;
            circleAnnotation.Author = "Syncfusion";
            circleAnnotation.Subject = "CircleAnnotation";
            circleAnnotation.ModifiedDate = new DateTime(2015, 1, 18);
            page.Annotations.Add(circleAnnotation);
            page.Graphics.DrawString("Circle Annotation", font, brush, new PointF(350, 130));

            //Creates a new Ellipse annotation.
            PdfEllipseAnnotation ellipseAnnotation = new PdfEllipseAnnotation(new RectangleF(30, 150, 50, 100), "Ellipse Annotation");
            ellipseAnnotation.Color = new PdfColor(Color.Red);
            ellipseAnnotation.InnerColor = new PdfColor(Color.Yellow);
            ellipseAnnotation.AnnotationFlags = PdfAnnotationFlags.Print;
            page.Graphics.DrawString("Ellipse Annotation", font, brush, new PointF(30, 130));
            page.Annotations.Add(ellipseAnnotation);

            //Creates a new Square annotation.
            PdfSquareAnnotation squareAnnotation = new PdfSquareAnnotation(new RectangleF(30, 300, 80, 80));
            squareAnnotation.Text = "SquareAnnotation";
            squareAnnotation.InnerColor = new PdfColor(Color.Red);
            squareAnnotation.Color = new PdfColor(Color.Yellow);
            squareAnnotation.AnnotationFlags = PdfAnnotationFlags.Print;
            page.Graphics.DrawString("Square Annotation", font, brush, new PointF(30, 280));
            page.Annotations.Add(squareAnnotation);

            //Creates a new Rectangle annotation.
            PdfRectangleAnnotation rectangleAnnotation = new PdfRectangleAnnotation(new RectangleF(350, 320, 100, 50), "RectangleAnnotation");
            rectangleAnnotation.InnerColor = new PdfColor(Color.Red);
            rectangleAnnotation.Color = new PdfColor(Color.Yellow);
            rectangleAnnotation.AnnotationFlags = PdfAnnotationFlags.Print;
            page.Graphics.DrawString("Rectangle Annotation", font, brush, new PointF(350, 280));
            page.Annotations.Add(rectangleAnnotation);

            //Creates a new Line annotation.
            int[] linePoints = new int[] { 400, 350, 550, 350 };
            PdfLineAnnotation lineAnnotation = new PdfLineAnnotation(linePoints, "Line Annoation is the one of the annotation type...");
            lineAnnotation.Author = "Syncfusion";
            lineAnnotation.Subject = "LineAnnotation";
            lineAnnotation.ModifiedDate = new DateTime(2015, 1, 18);
            lineAnnotation.Text = "PdfLineAnnotation";
            lineAnnotation.BackColor = new PdfColor(Color.Red);
            lineAnnotation.AnnotationFlags = PdfAnnotationFlags.Print;
            lineAnnotation.SetAppearance(true);
            page.Graphics.DrawString("Line Annotation", font, brush, new PointF(400, 420));
            page.Annotations.Add(lineAnnotation);

            //Creates a new Polygon annotation.
            int[] polyLinePoints = new int[] { 50, 298, 100, 325, 200, 355, 300, 230, 180, 230 };
            PdfPolygonAnnotation polygonAnnotation = new PdfPolygonAnnotation(polyLinePoints, "PolygonAnnotation");
            polygonAnnotation.Bounds = new RectangleF(30, 210, 300, 200);
            polygonAnnotation.Text = "polygon";
            polygonAnnotation.Color = new PdfColor(Color.Red);
            polygonAnnotation.InnerColor = new PdfColor(Color.LightPink);
            polygonAnnotation.AnnotationFlags = PdfAnnotationFlags.Print;
            polygonAnnotation.SetAppearance(true);
            page.Graphics.DrawString("Polygon Annotation", font, brush, new PointF(50, 420));
            page.Annotations.Add(polygonAnnotation);

            //Creates a new Freetext annotation.
            PdfFreeTextAnnotation freeTextAnnotation = new PdfFreeTextAnnotation(new RectangleF(405, 645, 80, 30));
            freeTextAnnotation.MarkupText = "Free Text with Callouts";
            freeTextAnnotation.TextMarkupColor = new PdfColor(Color.Green);
            freeTextAnnotation.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 7f);
            freeTextAnnotation.BorderColor = new PdfColor(Color.Blue);
            freeTextAnnotation.Border = new PdfAnnotationBorder(.5f);
            freeTextAnnotation.AnnotationFlags = PdfAnnotationFlags.Default | PdfAnnotationFlags.Print;
            freeTextAnnotation.Text = "Free Text";
            freeTextAnnotation.Color = new PdfColor(Color.Yellow);
            PointF[] freeTextPoints = { new PointF(365, 700), new PointF(379, 654), new PointF(405, 654) };
            freeTextAnnotation.CalloutLines = freeTextPoints;
            freeTextAnnotation.SetAppearance(true);
            page.Graphics.DrawString("FreeText Annotation", font, brush, new PointF(400, 610));
            page.Annotations.Add(freeTextAnnotation);

            //Creates a new Ink annotation.
            List<float> inkLinePoints = new List<float> { 72.919f, 136.376f, 72.264f, 136.376f, 62.446f, 142.922f, 61.137f, 142.922f, 55.901f, 139.649f, 55.246f, 138.34f, 54.592f, 132.449f, 54.592f, 127.867f, 55.901f, 125.904f, 59.828f, 121.976f, 63.101f, 121.322f, 65.719f, 122.631f, 68.992f, 125.249f, 70.301f, 130.485f, 71.61f, 133.104f, 72.264f, 136.376f, 72.919f, 140.304f, 74.883f, 144.885f, 76.192f, 150.776f, 76.192f, 151.431f, 76.192f, 152.085f, 76.192f, 158.631f, 76.192f, 159.94f, 75.537f, 155.358f, 74.228f, 150.122f, 74.228f, 146.195f, 73.574f, 141.613f, 73.574f, 137.685f, 74.228f, 132.449f, 74.883f, 128.522f, 75.537f, 124.594f, 76.192f, 123.285f, 76.846f, 122.631f, 80.774f, 122.631f, 82.737f, 123.285f, 85.355f, 125.249f, 88.628f, 129.831f, 89.283f, 133.104f, 89.937f, 137.031f, 90.592f, 140.958f, 89.937f, 142.267f, 86.665f, 141.613f, 85.355f, 140.304f, 84.701f, 138.34f, 84.701f, 137.685f, 85.355f, 137.031f, 87.974f, 135.722f, 90.592f, 136.376f, 92.555f, 137.031f, 96.483f, 139.649f, 98.446f, 140.958f, 101.719f, 142.922f, 103.028f, 142.922f, 100.41f, 138.34f, 99.756f, 134.413f, 99.101f, 131.14f, 99.101f, 128.522f, 99.756f, 127.213f, 101.065f, 125.904f, 102.374f, 123.94f, 103.683f, 123.94f, 107.61f, 125.904f, 110.228f, 129.831f, 114.156f, 135.067f, 117.428f, 140.304f, 119.392f, 143.576f, 121.356f, 144.231f, 122.665f, 144.231f, 123.974f, 142.267f, 126.592f, 139.649f, 127.247f, 140.304f, 126.592f, 142.922f, 124.628f, 143.576f, 122.01f, 142.922f, 118.083f, 141.613f, 114.81f, 136.376f, 114.81f, 131.14f, 113.501f, 127.213f, 114.156f, 125.904f, 118.083f, 125.904f, 120.701f, 126.558f, 123.319f, 130.485f, 125.283f, 136.376f, 125.937f, 140.304f, 125.937f, 142.922f, 126.592f, 143.576f, 125.937f, 135.722f, 125.937f, 131.794f, 125.937f, 131.14f, 127.247f, 129.176f, 129.21f, 127.213f, 131.828f, 127.213f, 134.447f, 128.522f, 136.41f, 136.376f, 139.028f, 150.122f, 141.647f, 162.558f, 140.992f, 163.213f, 138.374f, 160.595f, 135.756f, 153.395f, 135.101f, 148.158f, 134.447f, 140.304f, 134.447f, 130.485f, 133.792f, 124.594f, 133.792f, 115.431f, 133.792f, 110.194f, 133.792f, 105.612f, 134.447f, 105.612f, 137.065f, 110.194f, 137.719f, 116.74f, 139.028f, 120.013f, 139.028f, 123.94f, 137.719f, 127.213f, 135.756f, 130.485f, 134.447f, 130.485f, 133.792f, 130.485f, 137.719f, 131.794f, 141.647f, 135.722f, 146.883f, 142.922f, 152.774f, 153.395f, 153.428f, 159.286f, 150.156f, 159.94f, 147.537f, 156.667f, 146.883f, 148.813f, 146.883f, 140.958f, 146.883f, 134.413f, 146.883f, 125.904f, 145.574f, 118.703f, 145.574f, 114.776f, 145.574f, 112.158f, 146.228f, 111.503f, 147.537f, 111.503f, 148.192f, 112.158f, 150.156f, 112.812f, 150.81f, 113.467f, 152.119f, 114.776f, 154.083f, 117.394f, 155.392f, 119.358f, 156.701f, 120.667f, 157.356f, 121.976f, 156.701f, 121.322f, 156.047f, 120.013f, 155.392f, 119.358f, 154.083f, 117.394f, 154.083f, 116.74f, 152.774f, 114.776f, 152.119f, 114.121f, 150.81f, 113.467f, 149.501f, 113.467f, 147.537f, 112.158f, 146.883f, 112.158f, 145.574f, 111.503f, 144.919f, 112.158f, 144.265f, 114.121f, 144.265f, 115.431f, 144.265f, 116.74f, 144.265f, 117.394f, 144.265f, 118.049f, 144.919f, 118.703f, 145.574f, 120.667f, 146.228f, 122.631f, 147.537f, 123.285f, 147.537f, 124.594f, 148.192f, 125.904f, 147.537f, 128.522f, 147.537f, 129.176f, 147.537f, 130.485f, 147.537f, 132.449f, 147.537f, 134.413f, 147.537f, 136.376f, 147.537f, 138.34f, 147.537f, 138.994f, 145.574f, 138.994f, 142.956f, 138.252f };
            RectangleF rectangle = new RectangleF(30, 580, 300, 400);
            PdfInkAnnotation inkAnnotation = new PdfInkAnnotation(rectangle, inkLinePoints);
            inkAnnotation.Bounds = rectangle;
            inkAnnotation.Color = new PdfColor(Color.Red);
            inkAnnotation.AnnotationFlags = PdfAnnotationFlags.Print;
            page.Graphics.DrawString("Ink Annotation", font, brush, new PointF(30, 610));
            page.Annotations.Add(inkAnnotation);

            //Creates a new page.
            PdfPage secondPage = document.Pages.Add();

            //Creates a new TextMarkup annotation.
            text = "This is TextMarkup annotation!!!";
            secondPage.Graphics.DrawString(text, font, brush, new PointF(30, 70));
            PdfTextMarkupAnnotation textAnnotation = new PdfTextMarkupAnnotation("sample", "Strikeout", text, new PointF(30, 70), font);
            textAnnotation.Author = "Annotation";
            textAnnotation.Opacity = 1.0f;
            textAnnotation.Subject = "pdftextmarkupannotation";
            textAnnotation.ModifiedDate = new DateTime(2015, 1, 18);
            textAnnotation.TextMarkupAnnotationType = PdfTextMarkupAnnotationType.StrikeOut;
            textAnnotation.TextMarkupColor = new PdfColor(Color.Yellow);
            textAnnotation.InnerColor = new PdfColor(Color.Red);
            textAnnotation.Color = new PdfColor(Color.Yellow);
            textAnnotation.AnnotationFlags = PdfAnnotationFlags.Print;

            secondPage.Graphics.DrawString("TextMarkup Annotation", font, brush, new PointF(30, 40));
            secondPage.Annotations.Add(textAnnotation);

            //Creates a new popup annotation.
            RectangleF popupRectangle = new RectangleF(430, 70, 30, 30);
            PdfPopupAnnotation popupAnnotation = new PdfPopupAnnotation();
            popupAnnotation.Border.Width = 4;
            popupAnnotation.Border.HorizontalRadius = 20;
            popupAnnotation.Border.VerticalRadius = 30;
            popupAnnotation.Opacity = 1;
            popupAnnotation.Open = true;
            popupAnnotation.Text = "Popup Annotation";
            popupAnnotation.Color = Color.Green;
            popupAnnotation.InnerColor = Color.Blue;
            popupAnnotation.Bounds = popupRectangle;
            popupAnnotation.AnnotationFlags = PdfAnnotationFlags.Print;
            secondPage.Graphics.DrawString("Popup Annotation", font, brush, new PointF(400, 40));

            if (flatten.IsChecked == true)
            {
                //Flatten the annotation and popup window. 
                popupAnnotation.FlattenPopUps = true;
                popupAnnotation.Flatten = true;
            }
            popupAnnotation.SetAppearance(true);
            secondPage.Annotations.Add(popupAnnotation);

            //Creates a new Line measurement annotation.
            linePoints = new int[] { 400, 630, 550, 630 };
            PdfLineMeasurementAnnotation lineMeasureAnnotation = new PdfLineMeasurementAnnotation(linePoints);
            lineMeasureAnnotation.Author = "Syncfusion";
            lineMeasureAnnotation.Subject = "LineAnnotation";
            lineMeasureAnnotation.ModifiedDate = new DateTime(2015, 1, 18);
            lineMeasureAnnotation.Unit = PdfMeasurementUnit.Inch;
            lineMeasureAnnotation.lineBorder.BorderWidth = 2;
            lineMeasureAnnotation.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f, PdfFontStyle.Regular);
            lineMeasureAnnotation.Color = new PdfColor(Color.Red);
            lineMeasureAnnotation.AnnotationFlags = PdfAnnotationFlags.Print;
            if (flatten.IsChecked == true)
            {
                //Flatten the line measurement annotation. 
                lineMeasureAnnotation.Flatten = true;
            }
            lineMeasureAnnotation.SetAppearance(true);
            secondPage.Graphics.DrawString("Line Measurement Annotation", font, brush, new PointF(370, 130));
            secondPage.Annotations.Add(lineMeasureAnnotation);

            //Creates a new Freetext annotation.
            PdfFreeTextAnnotation freeTextAnnotationRotation = new PdfFreeTextAnnotation(new RectangleF(80, 160, 100, 50));
            freeTextAnnotationRotation.MarkupText = "Free Text with Callouts";
            freeTextAnnotationRotation.TextMarkupColor = new PdfColor(Color.Green);
            freeTextAnnotationRotation.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 7f);
            freeTextAnnotationRotation.BorderColor = new PdfColor(Color.Blue);
            freeTextAnnotationRotation.Border = new PdfAnnotationBorder(.5f);
            freeTextAnnotationRotation.AnnotationFlags = PdfAnnotationFlags.Default | PdfAnnotationFlags.Print;
            freeTextAnnotationRotation.Text = "Free Text";
            freeTextAnnotationRotation.Rotate = PdfAnnotationRotateAngle.RotateAngle90;
            freeTextAnnotationRotation.Color = new PdfColor(Color.Yellow);
            PointF[] callOutLines = { new PointF(45, 220), new PointF(60, 175), new PointF(80, 175) };
            freeTextAnnotationRotation.CalloutLines = callOutLines;
            freeTextAnnotationRotation.SetAppearance(true);
            secondPage.Graphics.DrawString("Rotated FreeText Annotation", font, brush, new PointF(40, 130));
            secondPage.Annotations.Add(freeTextAnnotationRotation);

            //Creates a new rectangle annotation with cloud border style.
            PdfRectangleAnnotation cloudAnnotation = new PdfRectangleAnnotation(new RectangleF(30, 300, 100, 50), "Rectangle Cloud Annoatation");
            cloudAnnotation.Border.BorderWidth = 1;
            cloudAnnotation.Color = Color.Red;
            cloudAnnotation.InnerColor = Color.Blue;
            PdfBorderEffect borderEffect = new PdfBorderEffect();
            borderEffect.Intensity = 2;
            borderEffect.Style = PdfBorderEffectStyle.Cloudy;
            cloudAnnotation.BorderEffect = borderEffect;
            cloudAnnotation.AnnotationFlags = PdfAnnotationFlags.Print;
            cloudAnnotation.SetAppearance(true);
            secondPage.Graphics.DrawString("Rectangle Cloud Annotation", font, brush, new PointF(40, 260));
            secondPage.Annotations.Add(cloudAnnotation);
            //Creates a Ellipse Annotation with Cloud Border
            PdfEllipseAnnotation ellipseCloud = new PdfEllipseAnnotation(new RectangleF(355, 310, 70, 30), "Ellipse Cloud Annoatation");
            ellipseCloud.Border.BorderWidth = 1;
            ellipseCloud.Color = Color.Red;
            ellipseCloud.InnerColor = Color.Blue;
            ellipseCloud.AnnotationFlags = PdfAnnotationFlags.Print;
            borderEffect.Intensity = 2;
            borderEffect.Style = PdfBorderEffectStyle.Cloudy;
            ellipseCloud.BorderEffect = borderEffect;
            ellipseCloud.SetAppearance(true);
            secondPage.Graphics.DrawString("Ellipse Cloud Annotation", font, brush, new PointF(350, 260));
            secondPage.Annotations.Add(ellipseCloud);

            //Creates a Circle Annotation with Cloud Border
            PdfCircleAnnotation circleCloud = new PdfCircleAnnotation(new RectangleF(40, 430, 90, 90), "Circle Cloud Annoatation");
            circleCloud.Border.BorderWidth = 1;
            circleCloud.Color = Color.Red;
            circleCloud.InnerColor = Color.Blue;
            circleCloud.AnnotationFlags = PdfAnnotationFlags.Print;
            borderEffect.Intensity = 2;
            borderEffect.Style = PdfBorderEffectStyle.Cloudy;
            circleCloud.BorderEffect = borderEffect;
            circleCloud.SetAppearance(true);
            secondPage.Graphics.DrawString("Circle Cloud Annotation", font, brush, new PointF(40, 390));
            secondPage.Annotations.Add(circleCloud);

            //Creates a Polygon Annotation with Cloud Border
            int[] cloudpolypoints = new int[] { 436, 254, 491, 324, 461, 374, 411, 344, 391, 294, 431, 264, 436, 254 };
            PdfPolygonAnnotation polygonCloud = new PdfPolygonAnnotation(cloudpolypoints, "Polygon Cloud Annoatation");
            polygonCloud.Border.BorderWidth = 1;
            polygonCloud.Color = Color.Red;
            polygonCloud.InnerColor = Color.Blue;
            polygonCloud.AnnotationFlags = PdfAnnotationFlags.Print;
            borderEffect.Intensity = 2;
            borderEffect.Style = PdfBorderEffectStyle.Cloudy;
            polygonCloud.BorderEffect = borderEffect;
            polygonCloud.SetAppearance(true);
            secondPage.Graphics.DrawString("Polygon Cloud Annotation", font, brush, new PointF(350, 390));
            secondPage.Annotations.Add(polygonCloud);

            PdfPage thirdPage = document.Pages.Add();

            //Creates a new RubberStamp annotation
            PdfRubberStampAnnotation rubberStampAnnotation = new PdfRubberStampAnnotation(new RectangleF(30,70, 100, 50));
            rubberStampAnnotation.Text = "Rubber Stamp Annotation";
            rubberStampAnnotation.Author = "Syncfusion";
            rubberStampAnnotation.ModifiedDate = new DateTime(2015, 1, 18);
            rubberStampAnnotation.Color = new PdfColor(Color.Red);
            rubberStampAnnotation.AnnotationFlags = PdfAnnotationFlags.Print;
            thirdPage.Graphics.DrawString("Rubber Stamp Annotation", font, brush, new PointF(30, 40));
            thirdPage.Annotations.Add(rubberStampAnnotation);

            secondPage.Graphics.DrawString("Rich Media Annotation (Video)", font, brush, new PointF(40, 580));

            //Create rich media annotation
            PdfRichMediaAnnotation richMediaAnnotation = new PdfRichMediaAnnotation(new RectangleF(40, 610, 160, 100));
            //Set activation mode
            richMediaAnnotation.ActivationMode = PdfRichMediaActivationMode.Click;
            //Set presentation style
            richMediaAnnotation.PresentationStyle = PdfRichMediaPresentationStyle.Embedded;
            richMediaAnnotation.AnnotationFlags = PdfAnnotationFlags.Print;

            //Get the input PDF file stream from assembly.
            Stream filestream = typeof(Annotations).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.Video.mp4");

            //Create rich media content with video file
            PdfRichMediaContent videoContent = new PdfRichMediaContent("video", filestream, "mp4");
            //Set the content type
            videoContent.ContentType = PdfRichMediaContentType.Video;
            //Add content to the rich media
            richMediaAnnotation.Content = videoContent;

            Stream imageStream = typeof(Annotations).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.richmedia.jpg");
            PdfBitmap image = new PdfBitmap(imageStream);
            //Draw image to the appearance
            richMediaAnnotation.Appearance.Normal.Graphics.DrawImage(image, new RectangleF(0, 0, richMediaAnnotation.Bounds.Width, richMediaAnnotation.Bounds.Height));
            //Add annotation to the page
            secondPage.Annotations.Add(richMediaAnnotation);

            secondPage.Graphics.DrawString("Rich Media Annotation (Sound)", font, brush, new PointF(340, 580));

            //Create rich media annotation
            PdfRichMediaAnnotation richMediaAnnotationSound = new PdfRichMediaAnnotation(new RectangleF(340, 610, 160, 100));
            //Set activation mode
            richMediaAnnotationSound.ActivationMode = PdfRichMediaActivationMode.Click;
            //Set presentation style
            richMediaAnnotationSound.PresentationStyle = PdfRichMediaPresentationStyle.Embedded;
            richMediaAnnotationSound.AnnotationFlags = PdfAnnotationFlags.Print;

            //Create rich media content with audio file
            filestream = typeof(Annotations).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.Sound.mp3");
            PdfRichMediaContent soundContent = new PdfRichMediaContent("Sound", filestream, "mp3");
            //Set the content type
            soundContent.ContentType = PdfRichMediaContentType.Sound;
            //Add content to the rich media
            richMediaAnnotationSound.Content = soundContent;

            Stream soundImageStream = typeof(Annotations).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.richmedia_sound.jpg");
            PdfBitmap soundImage = new PdfBitmap(soundImageStream);

            //Draw image to the appearance
            richMediaAnnotationSound.Appearance.Normal.Graphics.DrawImage(soundImage, new RectangleF(0, 0, richMediaAnnotationSound.Bounds.Width, richMediaAnnotationSound.Bounds.Height));
            //Add annotation to the page
            secondPage.Annotations.Add(richMediaAnnotationSound);

            AddWatermarkAnnotation(document, path);
            //Creating the stream object.
            using (MemoryStream stream = new MemoryStream())
            {
                string fileName = "Annotation.pdf";

                //Save and close the document.
                document.Save(stream);
                document.Close(true);

                if ((bool)flatten.IsChecked)
                {
                    fileName = "AnnotationFlatten.pdf";

                    //Loading and flatten the annotation in a PDF document. 
                    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(stream);
                    foreach (PdfLoadedPage lpage in loadedDocument.Pages)
                    {
                        lpage.Annotations.Flatten = true;
                    }
                    //Save the document into stream.
                    loadedDocument.Save(stream);
                    loadedDocument.Close();
                }
                stream.Position = 0;
                //Save the output stream as a file using file picker.
                PdfUtil.Save(fileName, stream);
            }
        }
        private void AddWatermarkAnnotation(PdfDocument document, string path)
        {
            PdfPage page = document.Pages[2];
            SizeF pageClientSize = page.GetClientSize();
            Stream imageStream = typeof(Annotations).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.AdventureCycle.jpg");

            //Load the image from the disk.
            PdfImage img = PdfImage.FromStream(imageStream);
            //Draw the image in the specified location and size.
            page.Graphics.DrawImage(img, new RectangleF(150, 180, 250, 150));

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 15);

            page.Graphics.DrawString("Watermark Annotation", font, PdfBrushes.Black, new PointF(30, 160));

            PdfTextElement textElement = new PdfTextElement("Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based," +
                                " is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, " +
                                "European and Asian commercial markets. While its base operation is located in Bothell, Washington with 290 employees, several regional" +
                                " sales teams are located throughout their market base.")
            {
                Font = font
            };
            PdfLayoutResult layoutResult = textElement.Draw(page, new RectangleF(0, 350, pageClientSize.Width, pageClientSize.Height));

            textElement = new PdfTextElement("In 2000, Adventure Works Cycles bought a small manufacturing plant, Importadores Neptuno, located in Mexico." +
                " Importadores Neptuno manufactures several critical subcomponents for the Adventure Works Cycles product line." +
                " These subcomponents are shipped to the Bothell location for final product assembly. In 2001, Importadores Neptuno," +
                " became the sole manufacturer and distributor of the touring bicycle product group.")
            {
                Font = font
            };
            layoutResult = textElement.Draw(page, new RectangleF(0, layoutResult.Bounds.Bottom + 20, pageClientSize.Width, pageClientSize.Height));

            //Create watermark annotation.
            PdfWatermarkAnnotation watermarkAnnotation = new PdfWatermarkAnnotation(new RectangleF(0, 0, pageClientSize.Width, pageClientSize.Height));
            //Set opacity.
            watermarkAnnotation.Opacity = 0.25F;
            watermarkAnnotation.AnnotationFlags = PdfAnnotationFlags.Print;
            //Get the appearance graphics.
            PdfGraphics graphics = watermarkAnnotation.Appearance.Normal.Graphics;
            string watermarkText = "Confidential";
            PdfFont watermarkFont = new PdfStandardFont(PdfFontFamily.Helvetica, 40);
            SizeF textSize = watermarkFont.MeasureString(watermarkText);
            //Find the center position.
            float x = pageClientSize.Width / 2 - textSize.Width / 2;
            float y = pageClientSize.Height / 2;
            graphics.Save();
            graphics.TranslateTransform(x, y);
            graphics.RotateTransform(-45);
            //Draw the watermark content.
            graphics.DrawString(watermarkText, watermarkFont, PdfBrushes.Red, PointF.Empty);
            graphics.Restore();
            //Add the watermark annotation to the PDF page.
            page.Annotations.Add(watermarkAnnotation);
        }
    }
}
