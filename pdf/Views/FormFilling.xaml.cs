#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.IO;
using System.Reflection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.Pdf.Parsing;
using System.Collections.Generic;
using System;

namespace syncfusion.pdfdemos.winui
{
    public sealed partial class FormFilling : Page
    {
        public FormFilling()
        {
            this.InitializeComponent();

            //Initialize the cities to combo box. 
            List<string> cities = InitializeFromCity();
            foreach (string city in cities)
            {
                this.fromCity.Items.Add(city);
            }
            this.fromCity.SelectedIndex = 0;

            //Initialize the date to date of birth field. 
            dateofbirth.Date = new DateTimeOffset(new DateTime(2000, 5, 12));
            dateofbirth.DateFormat = "{month.full} {day.integer}, {year.full}";
        }

        private void FillForm_Click(object sender, RoutedEventArgs e)
        {
            //Get the template PDF form file stream from assembly.
            Stream documentStream = typeof(FormFilling).GetTypeInfo().Assembly.GetManifestResourceStream("syncfusion.pdfdemos.winui.Assets.form_template.pdf");
            //Load the PDF document from stream.
            PdfLoadedDocument document = new PdfLoadedDocument(documentStream);

            //File the PDF form. 
            FillDocument(document);

            //Creating the stream object.
            using (MemoryStream stream = new MemoryStream())
            {
                //Save and close the document.
                document.Save(stream);
                document.Close();

                stream.Position = 0;
                //Save the output stream as a file using file picker.
                PdfUtil.Save("FormFilling.pdf", stream);
            }
        }
        private void FillAndFlatten_Click(object sender, RoutedEventArgs e)
        {
            //Get the template PDF form file stream from assembly.
            Stream documentStream = typeof(FormFilling).GetTypeInfo().Assembly.GetManifestResourceStream("syncfusion.pdfdemos.winui.Assets.form_template.pdf");
            //Load the PDF document from stream.
            PdfLoadedDocument document = new PdfLoadedDocument(documentStream);

            //File the PDF form. 
            FillDocument(document);

            //Flatten the form fields in a document. 
            if (document.Form != null)
            {
                document.Form.Flatten = true;
            }

            //Creating the stream object.
            using (MemoryStream stream = new MemoryStream())
            {
                //Save and close the document.
                document.Save(stream);
                document.Close();

                stream.Position = 0;
                //Save the output stream as a file using file picker.
                PdfUtil.Save("FormFillAndFlatten.pdf", stream);
            }
        }

        private void FillDocument(PdfLoadedDocument document)
        {
            //Get the PDF form from the document. 
            PdfLoadedForm form = document.Form;
            //Set default appearance to false, to create a appearance. 
            form.SetDefaultAppearance(false);

            //Get formatted date for date of birth
            var dateTimeOffset = dateofbirth.Date;
            DateTime time = dateTimeOffset.Value.DateTime;
            string formatedTime = time.ToString("MMMM d, yyyy");

            //Set the date of birth to text box field. 
            (form.Fields[0] as PdfLoadedTextBoxField).Text = formatedTime;
            //Set the name to text box field. 
            (form.Fields[1] as PdfLoadedTextBoxField).Text = name.Text;
            //Set the email to text box field. 
            (form.Fields[2] as PdfLoadedTextBoxField).Text = email.Text;

            int selectedIndex = 0;
            if ((bool)Unspecified.IsChecked)
            {
                selectedIndex = 1;
            }
            else if ((bool)Female.IsChecked)
            {
                selectedIndex = 2;
            }
            //Set the selected value to PdfLoadedRadioButtonListField. 
            (form.Fields[3] as PdfLoadedRadioButtonListField).SelectedIndex = selectedIndex;
            //Set the selected city to PdfLoadedComboBoxField.
            (form.Fields[4] as PdfLoadedComboBoxField).SelectedValue = fromCity.SelectedValue.ToString();
            //Set the selected value to PdfLoadedCheckBoxField. 
            (form.Fields[5] as PdfLoadedCheckBoxField).Checked = newsletter.IsChecked ?? false;
        }

        private void ViewTemplate_Click(object sender, RoutedEventArgs e)
        {
            //Get the template PDF form file stream from assembly.
            Stream documentStream = typeof(FormFilling).GetTypeInfo().Assembly.GetManifestResourceStream("syncfusion.pdfdemos.winui.Assets.form_template.pdf");
            //Load the PDF document from stream.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);

            //Creating the stream object.
            using (MemoryStream stream = new MemoryStream())
            {
                //Save and close the document.
                loadedDocument.Save(stream);
                loadedDocument.Close();

                stream.Position = 0;
                //Save the output stream as a file using file picker.
                PdfUtil.Save("FormFilling_Template.pdf", stream);
            }
        }

        private List<string> InitializeFromCity()
        {
            List<string> cityList = new List<string>();
            cityList.Add("Alabama");
            cityList.Add("Alaska");
            cityList.Add("Arizona");
            cityList.Add("Arkansas");
            cityList.Add("California");
            cityList.Add("Colorado");
            cityList.Add("Connecticut");
            cityList.Add("Delaware");
            cityList.Add("Florida");
            cityList.Add("Georgia");
            cityList.Add("Hawaii");
            cityList.Add("Idaho");
            cityList.Add("Illinois");
            cityList.Add("Indiana");
            cityList.Add("Iowa");
            cityList.Add("Kansas");
            cityList.Add("Kentucky");
            cityList.Add("Louisiana");
            cityList.Add("Maine");
            cityList.Add("Maryland");
            cityList.Add("Massachusetts");
            cityList.Add("Michigan");
            cityList.Add("Minnesota");
            cityList.Add("Mississippi");
            cityList.Add("Missouri");
            cityList.Add("Montana");
            cityList.Add("Nebraska");
            cityList.Add("Nevada");
            cityList.Add("New Jersey");
            cityList.Add("New Mexico");
            cityList.Add("New York");
            cityList.Add("North Carolina");
            cityList.Add("North Dakota");
            cityList.Add("Ohio");
            cityList.Add("Oklahoma");
            cityList.Add("Oregon");
            cityList.Add("Pennsylvania");
            cityList.Add("South Carolina");
            cityList.Add("South Dakota");
            cityList.Add("Tennessee");
            cityList.Add("Texas");
            cityList.Add("Utah");
            cityList.Add("Vermont");
            cityList.Add("Virginia");
            cityList.Add("Washington");
            cityList.Add("West Virginia");
            cityList.Add("Wisconsin");
            cityList.Add("Wyoming");

            return cityList;
        }        
    }
}
