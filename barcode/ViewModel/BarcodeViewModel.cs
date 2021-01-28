#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Syncfusion.UI.Xaml.Barcode;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace syncfusion.barcodedemos.winui
{
    public class BarcodeViewModel : INotifyPropertyChanged
    {
#region Fields

        private string code11BarcodeText = "1010111011";

        private string validateCode11BarcodeText = "";

        private string validateDataMatricBarcodeText = "";

        private string dataMatrixSupportedChar = "[^A-Za-z0-9]";

        private string dataMatrixBarcodeText = "Syncfusion";

        private string qrBarcodeText = "Syncfusion";

        private BarcodeModel selectedItem = new BarcodeModel();

        private BarcodeBase symbologyItem = new CodabarBarcode();

        private BarcodeModel encodingSelectedValue = new BarcodeModel();

        private Visibility code11BarcodeVisibility = Visibility.Visible;

        private Visibility dataMatrixBarcodeVisibility = Visibility.Visible;

        public event PropertyChangedEventHandler PropertyChanged;
#endregion

#region Constructor
        public BarcodeViewModel()
        {
            Symbology = new ObservableCollection<BarcodeModel>();
            EncodingValues = new ObservableCollection<BarcodeModel>();
            Symbology.Add(new BarcodeModel() { SymobologyItem = "CodaBar" });
            Symbology.Add(new BarcodeModel() { SymobologyItem = "Code11" });
            Symbology.Add(new BarcodeModel() { SymobologyItem = "Code32" });
            Symbology.Add(new BarcodeModel() { SymobologyItem = "Code39" });
            Symbology.Add(new BarcodeModel() { SymobologyItem = "Code39Extended" });
            Symbology.Add(new BarcodeModel() { SymobologyItem = "Code93" });
            Symbology.Add(new BarcodeModel() { SymobologyItem = "Code93Extended" });
            Symbology.Add(new BarcodeModel() { SymobologyItem = "Code128A" });
            Symbology.Add(new BarcodeModel() { SymobologyItem = "Code128B" });
            Symbology.Add(new BarcodeModel() { SymobologyItem = "Code128C" });
            Symbology.Add(new BarcodeModel() { SymobologyItem = "UpcBarcode" });
            Symbology.Add(new BarcodeModel() { SymobologyItem = "GS1Code128Barcode" });
            Symbology.Add(new BarcodeModel() { SymobologyItem = "Pdf417Barcode" });
            EncodingValues.Add(new BarcodeModel() { DataMatrixEncoding = "Auto" });
            EncodingValues.Add(new BarcodeModel() { DataMatrixEncoding = "ASCII" });
            EncodingValues.Add(new BarcodeModel() { DataMatrixEncoding = "ASCIINumeric" });
            EncodingValues.Add(new BarcodeModel() { DataMatrixEncoding = "Base256" });
        }
#endregion

#region Properties

        public ObservableCollection<BarcodeModel> Symbology { get; }

        public ObservableCollection<BarcodeModel> EncodingValues { get; }

        public BarcodeModel SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                UpdateSymbology(selectedItem);
                OnPropertyChanged("SelectedItem");
            }
        }


        public BarcodeModel EncodingSelectedValue
        {
            get
            {
                return encodingSelectedValue;
            }
            set
            {
                encodingSelectedValue = value;
                SelectedEncodingValue(encodingSelectedValue);
            }
        }

        public BarcodeBase SymbologyItem
        {
            get
            {
                return symbologyItem;
            }
            set
            {
                symbologyItem = value;
                OnPropertyChanged("SymbologyItem");
            }
        }

        public string Code11BarcodeText
        {
            get
            {
                return code11BarcodeText;
            }
            set
            {
                code11BarcodeText = value;
                ValidateCode11Barcode(code11BarcodeText);
                OnPropertyChanged("Code11BarcodeText");
            }
        }

        public string DataMatrixBarcodeText
        {
            get
            {
                return dataMatrixBarcodeText;
            }
            set
            {
                dataMatrixBarcodeText = value;
                if (EncodingSelectedValue.DataMatrixEncoding == "ASCIINumeric")
                    ValidateDataMatrixText(dataMatrixBarcodeText);
                OnPropertyChanged("DataMatrixBarcodeText");
            }
        }        
        
        public string QRBarcodeText
        {
            get
            {
                return qrBarcodeText;
            }
            set
            {
                qrBarcodeText = value;
                OnPropertyChanged("QRBarcodeText");
            }
        }

        public string ValidateCode11BarcodeText
        {
            get
            {
                return validateCode11BarcodeText;
            }
            set
            {
                validateCode11BarcodeText = value;
                OnPropertyChanged("ValidateCode11BarcodeText");
            }
        }


        public string ValidateDataMatrixBarcodeText
        {
            get
            {
                return validateDataMatricBarcodeText;
            }
            set
            {
                validateDataMatricBarcodeText = value;
                OnPropertyChanged("ValidateDataMatrixBarcodeText");
            }
        }

        public string DataMatrixSupportedChar
        {
            get
            {
                return dataMatrixSupportedChar;
            }
            set
            {
                dataMatrixSupportedChar = value;
                OnPropertyChanged("DataMatrixSupportedChar");
            }
        }

        public Visibility Code11BarcodeVisibility
        {
            get
            {
                return code11BarcodeVisibility;
            }
            set
            {
                code11BarcodeVisibility = value;
                OnPropertyChanged("Code11BarcodeVisibility");
            }
        }

        public Visibility DataMatrixBarcodeVisibility
        {
            get
            {
                return dataMatrixBarcodeVisibility;
            }
            set
            {
                dataMatrixBarcodeVisibility = value;
                OnPropertyChanged("DataMatrixBarcodeVisibility");
            }
        }
#endregion

#region Methods
        private void UpdateSymbology(BarcodeModel barcodeModel)
        {
            switch(barcodeModel.SymobologyItem)
            {
                case "CodaBar":
                    CodabarBarcode codabarBarcode = new CodabarBarcode();
                    SymbologyItem = codabarBarcode;
                    break;
                case "Code11":
                    Code11Barcode code11Barcode = new Code11Barcode();
                    SymbologyItem = code11Barcode;
                    break;
                case "Code32":
                    Code32Barcode code32Barcode = new Code32Barcode();
                    SymbologyItem = code32Barcode;
                    break;
                case "Code39":
                    Code39Barcode code39Barcode = new Code39Barcode();
                    SymbologyItem = code39Barcode;
                    break;
                case "Code39Extended":
                    Code39ExtendedBarcode code39ExtendedBarcode = new Code39ExtendedBarcode();
                    SymbologyItem = code39ExtendedBarcode;
                    break;
                case "Code93":
                    Code93Barcode code93Barcode = new Code93Barcode();
                    SymbologyItem = code93Barcode;
                    break;
                case "Code93Extended":
                    Code93ExtendedBarcode code93ExtendedBarcode = new Code93ExtendedBarcode();
                    SymbologyItem = code93ExtendedBarcode;
                    break;
                case "Code128A":
                    Code128ABarcode code128Barcode = new Code128ABarcode();
                    SymbologyItem = code128Barcode;
                    break;
                case "Code128B":
                    Code128BBarcode code128BBarcode = new Code128BBarcode();
                    SymbologyItem = code128BBarcode;
                    break;
                case "Code128C":
                    Code128CBarcode code128CBarcode = new Code128CBarcode();
                    SymbologyItem = code128CBarcode;
                    break;
                case "UpcBarcode":
                    UpcBarcode upcBarcode = new UpcBarcode();
                    SymbologyItem = upcBarcode;
                    break;
                case "GS1Code128Barcode":
                    GS1Code128Barcode gS1Code128Barcode = new GS1Code128Barcode();
                    SymbologyItem = gS1Code128Barcode;
                    break;
                case "Pdf417Barcode":
                    Pdf417Barcode pdf417Barcode = new Pdf417Barcode();
                    SymbologyItem = pdf417Barcode;
                    break;
            }
        }

        private void ValidateCode11Barcode(string value)
        {
            bool isNumeric = false;
            char[] validate = value.ToCharArray();
            for (int i = 0; i < validate.Length; i++)
            {
                if (Char.IsDigit(validate[i]))
                {
                    isNumeric = true;
                }
                else
                {
                    isNumeric = false;
                }
            }
            if (isNumeric)
            {
                ValidateCode11BarcodeText = "";
                Code11BarcodeVisibility = Visibility.Visible;
            }
            else
            {
                ValidateCode11BarcodeText = "Invalid Input";
                Code11BarcodeVisibility = Visibility.Collapsed;
            }
        }

        private void ValidateDataMatrixText(string value)
        {
            bool isNumeric = false;
            char[] validate = value.ToCharArray();
            for (int i = 0; i < validate.Length; i++)
            {
                if (Char.IsDigit(validate[i]))
                {
                    isNumeric = true;
                }
                else
                {
                    isNumeric = false;
                }
            }
            if (isNumeric)
            {
                ValidateDataMatrixBarcodeText = "";
                DataMatrixBarcodeVisibility = Visibility.Visible;
            }
            else
            {
                ValidateDataMatrixBarcodeText = "Invalid Input";
                DataMatrixBarcodeVisibility = Visibility.Collapsed;
            }
        }

        private void SelectedEncodingValue(BarcodeModel value)
        {
            bool isNumeric = int.TryParse(DataMatrixBarcodeText, out int data);

            if (value.DataMatrixEncoding == "ASCIINumeric")
            {
                DataMatrixSupportedChar = "[0-9]";
                DataMatrixBarcodeText = "583748";
            }
            else
            {
                DataMatrixSupportedChar = "[^A-Za-z0-9]";
                DataMatrixBarcodeText = "Syncfusion";
            }
        }

        private void OnPropertyChanged(string Parameter)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(Parameter));
        }
#endregion
    }
}
