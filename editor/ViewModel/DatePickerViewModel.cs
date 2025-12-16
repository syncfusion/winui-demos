#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Syncfusion.EditorDemos.WinUI
{
    /// <summary>
    /// ViewModel for demonstrating the DatePicker control. It manages properties related to date selection, formatting, calendar types, blackout dates, and internationalization.
    /// </summary>
    public class DatePickerViewModel : NotificationObject
    {
        private int visibleItemsCount = 7; 
        private DateTimeOffset minDate = new DateTimeOffset(1921, 1, 1, DateTimeOffset.Now.Hour, DateTimeOffset.Now.Minute, DateTimeOffset.Now.Second, DateTimeOffset.Now.Offset);
        private DateTimeOffset maxDate = new DateTimeOffset(2121, 12, 31, DateTimeOffset.Now.Hour, DateTimeOffset.Now.Minute, DateTimeOffset.Now.Second, DateTimeOffset.Now.Offset);
        private DateTimeOffset? selectedDate = DateTimeOffset.Now;
        private DateTimeOffsetCollection blackoutDates = new DateTimeOffsetCollection();
        private string formatString = "M/d/yyyy";
        private string dayFormat = "{}{day.integer} ({dayofweek.abbreviated})";
        private string monthFormat = "{}{month.abbreviated}";
        private string yearFormat = "{}{year.full}";
        private DateTimeOffset minimumDate = new DateTimeOffset(1601, 1, 1, 6, 0, 0, new TimeSpan(0));
        private DateTimeOffset maximumDate = DateTimeOffset.MaxValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatePickerViewModel"/> class.
        /// Sets up initial dates, blackout dates (weekends), populates calendar type options, and loads language lists.
        /// </summary>
        public DatePickerViewModel()
        {
            this.UpdateWeekendDates();
            Items = new ObservableCollection<string>();
            Items.Add("GregorianCalendar");
            Items.Add("HijriCalendar");
            Items.Add("JulianCalendar");
            Items.Add("KoreanCalendar");
            Items.Add("TaiwanCalendar");
            Items.Add("ThaiCalendar");
            Items.Add("UmAlQuraCalendar");
            Items.Add("PersianCalendar");
            
            var lang = new LanguageList();
            Languages = lang.Languages;
        }

        /// <summary>
        /// Gets or sets the number of visible items in the date picker's dropdown (e.g., in a calendar view).
        /// </summary>
        public int VisibleItemsCount
        {
            get
            {
                return visibleItemsCount;
            }
            set
            {
                if (visibleItemsCount != value)
                {
                    visibleItemsCount = value;
                    this.RaisePropertyChanged(nameof(this.VisibleItemsCount));
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum selectable date in the date picker.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the maximum selectable date in the date picker.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the currently selected date. Can be null if no date is selected.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the collection of dates that are blacked out (non-selectable).
        /// </summary>
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

        /// <summary>
        /// Gets or sets the primary format string used for displaying the selected date.
        /// </summary>
        public string FormatString
        {
            get { return formatString; }
            set { formatString = value; RaisePropertyChanged("FormatString"); }
        }

        /// <summary>
        /// Gets or sets the format string used for displaying the day part of the date.
        /// </summary>
        public string DayFormat
        {
            get { return dayFormat; }
            set { dayFormat = value; RaisePropertyChanged("DayFormat"); }
        }

        /// <summary>
        /// Gets or sets the format string used for displaying the month part of the date.
        /// </summary>
        public string MonthFormat
        {
            get { return monthFormat; }
            set { monthFormat = value; RaisePropertyChanged("MonthFormat"); }
        }

        /// <summary>
        /// Gets or sets the format string used for displaying the year part of the date.
        /// </summary>
        public string YearFormat
        {
            get { return yearFormat; }
            set { yearFormat = value; RaisePropertyChanged("YearFormat"); }
        }

        /// <summary>
        /// Gets or sets the minimum date for DatePicker contained in options to change Minimum and Maximum date.
        /// </summary>
        public DateTimeOffset MinimumDate
        {
            get
            {
                return minimumDate;
            }
            set
            {
                if (minimumDate != value)
                {
                    minimumDate = value;
                    this.RaisePropertyChanged(nameof(this.MinimumDate));
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum date for DatePicker contained in options to change Minimum and Maximum date.
        /// </summary>
        public DateTimeOffset MaximumDate
        {
            get
            {
                return maximumDate;
            }
            set
            {
                if (maximumDate != value)
                {
                    maximumDate = value;
                    this.RaisePropertyChanged(nameof(this.MaximumDate));
                }
            }
        }

        /// <summary>
        /// Gets or sets the collection of strings representing different calendar types available for selection (e.g., Gregorian, Hijri).
        /// </summary>
        public ObservableCollection<string> Items { get; set; }

        /// <summary>
        /// Gets or sets the list of available languages for localization features.
        /// </summary>
        public List<LanguageList.Language> Languages { get; set; }

        /// <summary>
        /// Populates the `BlackoutDates` collection with the current month's Saturdays and Sundays.
        /// This method is called during initialization.
        /// </summary>
        private void UpdateWeekendDates()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            int noOfDays = DateTime.DaysInMonth(year, month);
            DateTime dateTime = new DateTime(year, month, 1);

            for (int i = 0; i < noOfDays; i++)
            {
                DateTime date = dateTime.AddDays(i);
                if(date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    if(this.SelectedDate != null && this.SelectedDate.HasValue && this.SelectedDate.Value.Date != date)
                       blackoutDates.Add(date);
                }
            }
        }
    }

    /// <summary>
    /// Provides a list of supported languages with their names and codes for internationalization demos.
    /// </summary>
    public class LanguageList
    {
        private List<Language> _languages;
        /// <summary>
        /// Gets the list of available languages.
        /// </summary>
        public List<Language> Languages
        {
            get { return _languages; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageList"/> class.
        /// Populates the list with a comprehensive set of languages and their codes.
        /// </summary>
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

        /// <summary>
        /// Represents a single language entry with its display name and code.
        /// </summary>
        public class Language
        {
            /// <summary>
            /// Gets the display name of the language.
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Gets the language code (e.g., "en", "fr").
            /// </summary>
            public string Code { get; set; }
            /// <summary>
            /// Initializes a new instance of the <see cref="Language"/> class.
            /// </summary>
            /// <param name="name">The display name of the language.</param>
            /// <param name="code">The language code.</param>

            public Language(string name, string code)
            {
                this.Name = name;
                this.Code = code;
            }
        }
    }
}
