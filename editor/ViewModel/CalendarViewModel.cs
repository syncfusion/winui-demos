#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Calendar;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace syncfusion.editordemos.winui
{
    public class CalendarViewModel : NotificationObject
    {
        private DateTimeOffset minDate = new DateTimeOffset(new DateTime(2000, 1, 1));
        private DateTimeOffset maxDate = new DateTimeOffset(new DateTime(3000, 1, 1));
        private DateTimeOffset? selectedDate = DateTimeOffset.Now;
        private DateTimeOffsetCollection blackoutDates = new DateTimeOffsetCollection();
        private CalendarDisplayMode minDisplayMode = CalendarDisplayMode.Month;
        private CalendarDisplayMode maxDisplayMode = CalendarDisplayMode.Century;

        public CalendarDisplayMode MinDisplayMode
        {
            get { return minDisplayMode; }
            set
            {
                if (value != minDisplayMode)
                {
                    minDisplayMode = value;
                    if (maxDisplayMode < minDisplayMode)
                    {
                        MaxDisplayMode = minDisplayMode;
                    }
                    RaisePropertyChanged(nameof(MinDisplayMode));
                }
            }
        }

        public CalendarDisplayMode MaxDisplayMode
        {
            get { return maxDisplayMode; }
            set
            {
                if (value != maxDisplayMode)
                {
                    maxDisplayMode = value;
                    if (minDisplayMode > maxDisplayMode)
                    {
                        MinDisplayMode = maxDisplayMode;
                    }
                    RaisePropertyChanged(nameof(MaxDisplayMode));
                }
            }
        }

        public CalendarViewModel()
        {
            this.UpdateWeekendDates();

            Items = new ObservableCollection<string>();
            Items.Add("JulianCalendar");
            Items.Add("GregorianCalendar");
            Items.Add("HebrewCalendar");
            Items.Add("HijriCalendar");
            Items.Add("JapaneseCalendar");
            Items.Add("KoreanCalendar");
            Items.Add("TaiwanCalendar");
            Items.Add("UmAlQuraCalendar");
            Items.Add("PersianCalendar");


            var lang = new LanguageList();
            Languages = lang.Languages;
        }

        public DateTimeOffset MinDate
        {
            get
            {
                return minDate;
            }
            set
            {
                if (minDate != value)
                {
                    minDate = value;
                    this.RaisePropertyChanged(nameof(this.MinDate));
                }
            }
        }

        public DateTimeOffset MaxDate
        {
            get
            {
                return maxDate;
            }
            set
            {
                if (maxDate != value)
                {
                    maxDate = value;
                    this.RaisePropertyChanged(nameof(this.MaxDate));
                }
            }
        }

        public DateTimeOffset? SelectedDate
        {
            get
            {
                return selectedDate;
            }
            set
            {
                if (selectedDate != value)
                {
                    selectedDate = value;
                    this.RaisePropertyChanged(nameof(this.SelectedDate));
                }
            }
        }

        public DateTimeOffsetCollection BlackoutDates
        {
            get
            {
                return blackoutDates;
            }
            set
            {
                if (blackoutDates != value)
                {
                    blackoutDates = value;
                    this.RaisePropertyChanged(nameof(this.BlackoutDates));
                }
            }
        }

        public ObservableCollection<string> Items { get; set; }

        public List<LanguageList.Language> Languages { get; set; }

        private void UpdateWeekendDates()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            int noOfDays = DateTime.DaysInMonth(year, month);
            DateTime dateTime = new DateTime(year, month, 1);

            for (int i = 0; i < noOfDays; i++)
            {
                DateTime date = dateTime.AddDays(i);
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (this.selectedDate.HasValue && this.SelectedDate.Value.Date != date)
                        blackoutDates.Add(date);
                }
            }
        }
    }

    public class LanguageList
    {
        private List<Language> _languages;
        public List<Language> Languages
        {
            get { return _languages; }
        }

        public LanguageList()
        {
            if (_languages == null)
            {
                _languages = new List<Language>();
            }

            _languages.Add(new Language("English", "en"));
            _languages.Add(new Language("Arabic", "ar"));
            _languages.Add(new Language("Afrikaans", "af"));
            _languages.Add(new Language("Albanian", "sq"));
            _languages.Add(new Language("Amharic", "am"));
            _languages.Add(new Language("Armenian", "hy"));
            _languages.Add(new Language("Assamese", "as"));
            _languages.Add(new Language("Azerbaijani", "az"));
            _languages.Add(new Language("Basque ", "eu"));
            _languages.Add(new Language("Belarusian", "be"));
            _languages.Add(new Language("Bangla", "bn"));
            _languages.Add(new Language("Bosnian", "bs"));
            _languages.Add(new Language("Bulgarian", "bg"));
            _languages.Add(new Language("Catalan", "ca"));
            _languages.Add(new Language("Chinese (Simplified)", "zh"));
            _languages.Add(new Language("Croatian", "hr"));
            _languages.Add(new Language("Czech", "cs"));
            _languages.Add(new Language("Danish", "da"));
            _languages.Add(new Language("Dari", "prs"));
            _languages.Add(new Language("Dutch", "nl"));
            _languages.Add(new Language("Estonian", "et"));
            _languages.Add(new Language("Filipino", "fil"));
            _languages.Add(new Language("Finnish", "fi"));
            _languages.Add(new Language("French ", "fr"));
            _languages.Add(new Language("Galician", "gl"));
            _languages.Add(new Language("Georgian", "ka"));
            _languages.Add(new Language("German", "de"));
            _languages.Add(new Language("Greek", "el"));
            _languages.Add(new Language("Gujarati", "gu"));
            _languages.Add(new Language("Hausa", "ha"));
            _languages.Add(new Language("Hebrew", "he"));
            _languages.Add(new Language("Hindi", "hi"));
            _languages.Add(new Language("Hungarian", "hu"));
            _languages.Add(new Language("Icelandic", "is"));
            _languages.Add(new Language("Indonesian", "id"));
            _languages.Add(new Language("Irish", "ga"));
            _languages.Add(new Language("isiXhosa", "xh"));
            _languages.Add(new Language("isiZulu", "zu"));
            _languages.Add(new Language("Italian", "it"));
            _languages.Add(new Language("Japanese ", "ja"));
            _languages.Add(new Language("Kannada", "kn"));
            _languages.Add(new Language("Kazakh", "kk"));
            _languages.Add(new Language("Khmer", "km"));
            _languages.Add(new Language("Kinyarwanda", "rw"));
            _languages.Add(new Language("KiSwahili", "sw"));
            _languages.Add(new Language("Konkani", "kok"));
            _languages.Add(new Language("Korean", "ko"));
            _languages.Add(new Language("Lao", "lo"));
            _languages.Add(new Language("Latvian", "lv"));
            _languages.Add(new Language("Lithuanian", "lt"));
            _languages.Add(new Language("Luxembourgish", "lb"));
            _languages.Add(new Language("Macedonian", "mk"));
            _languages.Add(new Language("Malay", "ms"));
            _languages.Add(new Language("Malayalam", "ml"));
            _languages.Add(new Language("Maltese", "mt"));
            _languages.Add(new Language("Maori ", "mi"));
            _languages.Add(new Language("Marathi", "mr"));
            _languages.Add(new Language("Nepali", "ne"));
            _languages.Add(new Language("Norwegian", "nb"));
            _languages.Add(new Language("Odia", "or"));
            _languages.Add(new Language("Persian", "fa"));
            _languages.Add(new Language("Polish", "pl"));
            _languages.Add(new Language("Portuguese", "pt"));
            _languages.Add(new Language("Punjabi", "pa"));
            _languages.Add(new Language("Quechua", "quz"));
            _languages.Add(new Language("Romanian", "ro"));
            _languages.Add(new Language("Russian", "ru"));
            _languages.Add(new Language("Serbian (Latin)", "sr"));
            _languages.Add(new Language("Sesotho sa Leboa", "nso"));
            _languages.Add(new Language("Setswana", "tn"));
            _languages.Add(new Language("Sinhala", "si"));
            _languages.Add(new Language("Slovak ", "sk"));
            _languages.Add(new Language("Slovenian", "sl"));
            _languages.Add(new Language("Spanish", "es"));
            _languages.Add(new Language("Swedish", "sv"));
            _languages.Add(new Language("Tamil", "ta"));
            _languages.Add(new Language("Telugu", "te"));
            _languages.Add(new Language("Thai", "th"));
            _languages.Add(new Language("Tigrinya", "ti"));
            _languages.Add(new Language("Turkish", "tr"));
            _languages.Add(new Language("Ukrainian", "uk"));
            _languages.Add(new Language("Urdu", "ur"));
            _languages.Add(new Language("Uzbek (Latin)", "uz"));
            _languages.Add(new Language("Vietnamese", "vi"));
            _languages.Add(new Language("Welsh", "cy"));
            _languages.Add(new Language("Wolof", "wo"));

        }

        public class Language
        {
            public string Name { get; set; }
            public string Code { get; set; }

            public Language(string name, string code)
            {
                this.Name = name;
                this.Code = code;
            }
        }
    }
}
