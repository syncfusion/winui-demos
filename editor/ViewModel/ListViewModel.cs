#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Media.Imaging;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace Syncfusion.EditorDemos.WinUI
{
    public class ListViewModel : NotificationObject
    {
        private ObservableCollection<Employee> employees;
        private ObservableCollection<Sport> sportsData;
        private ObservableCollection<string> socialMedias;
        private ObservableCollection<string> countries;
        private ObservableCollection<CityInfo> cities;
        private ObservableCollection<CountryInfo> countryList;
        private ObservableCollection<CountryInfo> selectionBoxCountryList;
        private ObservableCollection<State> stateList;
        private ObservableCollection<City> cityList;
        private CountryInfo selectedCountry;
        private State selectedState;
        private Employee selectedEmployee;
        private Sport selectedSport;
        private ComboBoxSelectionMode selectionMode;
        private ComboBoxMultiSelectionDisplayMode multiSelectionMode= ComboBoxMultiSelectionDisplayMode.Token;
        private string placeholderText;
        private string selectedItem;
        private ObservableCollection<Person> persons;
        private string selectedEmployeeValue;

        public ListViewModel()
        {
            this.SelectionMode = ComboBoxSelectionMode.Multiple;
            this.PopulateEmployeesData();
            this.PopulateSportsData();
            this.PopulateSocialMediasData();
            this.PopulateCountriesData();
            this.PopulateVegetablesData();
            this.PopulateCountryListData();
            this.PopulateSelectionBoxCountryListData();
            this.PopulateCitiesData();
            this.selectedEmployee = Employees[0];
            this.persons = GetPersonDetails(50);
            this.PopulateContinentsData();
        }

        public ObservableCollection<Employee> Employees
        {
            get
            {
                return employees;
            }
            set
            {
                employees = value;
                this.RaisePropertyChanged(nameof(this.Employees));
            }
        }

        public ObservableCollection<Sport> SportsData
        {
            get
            {
                return sportsData;
            }
            set
            {
                sportsData = value;
                this.RaisePropertyChanged(nameof(this.SportsData));
            }
        }

        public ObservableCollection<string> SocialMedias
        {
            get
            {
                return socialMedias;
            }
            set
            {
                socialMedias = value;
                this.RaisePropertyChanged(nameof(this.SocialMedias));
            }
        }

        public ObservableCollection<string> Countries
        {
            get { return countries; }
            set
            {
                if (countries != value)
                {
                    countries = value;
                    this.RaisePropertyChanged(nameof(Countries));
                }
            }
        }

        public ObservableCollection<CountryInfo> CountryList
        {
            get { return countryList; }
            set
            {
                if (countryList != value)
                {
                    countryList = value;
                    this.RaisePropertyChanged(nameof(CountryList));
                }
            }
        }

        public ObservableCollection<CountryInfo> SelectionBoxCountryList
        {
            get { return selectionBoxCountryList; }
            set
            {
                if (selectionBoxCountryList != value)
                {
                    selectionBoxCountryList = value;
                    this.RaisePropertyChanged(nameof(SelectionBoxCountryList));
                }
            }
        }

        public ObservableCollection<State> StateList
        {
            get { return stateList; }
            set
            {
                if (stateList != value)
                {
                    stateList = value;
                    this.RaisePropertyChanged(nameof(StateList));
                }
            }
        }

        public ObservableCollection<City> CityList
        {
            get { return cityList; }
            set
            {
                if (cityList != value)
                {
                    cityList = value;
                    this.RaisePropertyChanged(nameof(CityList));
                }
            }
        }

        public CountryInfo SelectedCountry
        {
            get { return selectedCountry; }
            set
            {
                if (selectedCountry != value)
                {
                    selectedCountry = value;
                    this.UpdateStateList();
                    this.RaisePropertyChanged(nameof(SelectedCountry));
                }
            }
        }

        public State SelectedState
        {
            get { return selectedState; }
            set
            {
                if (selectedState != value)
                {
                    selectedState = value;
                    this.UpdateCityList();
                    this.RaisePropertyChanged(nameof(SelectedState));
                }
            }
        }

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                if (selectedEmployee != value)
                {
                    selectedEmployee = value;
                    this.RaisePropertyChanged(nameof(SelectedEmployee));
                }
            }
        }

        public string SelectedEmployeeValue
        {
            get { return selectedEmployeeValue; }
            set
            {
                if (selectedEmployeeValue != value)
                {
                    selectedEmployeeValue = value;
                    this.RaisePropertyChanged(nameof(SelectedEmployeeValue));
                }
            }
        }

        public Sport SelectedSport
        {
            get { return selectedSport; }
            set
            {
                if (selectedSport != value)
                {
                    selectedSport = value;
                    this.RaisePropertyChanged(nameof(SelectedSport));
                }
            }
        }

        public ComboBoxSelectionMode SelectionMode
        {
            get { return selectionMode; }
            set
            {
                if (selectionMode != value)
                {
                    selectionMode = value;
                    this.UpdatePlaceholderText();
                    this.RaisePropertyChanged(nameof(SelectionMode));
                }
            }
        }
        
        public ComboBoxMultiSelectionDisplayMode MultiSelectionMode
        {
            get { return multiSelectionMode; }
            set
            {
                if (multiSelectionMode != value)
                {
                    multiSelectionMode = value;
                    this.RaisePropertyChanged(nameof(MultiSelectionMode));
                }
            }
        }

        public string PlaceholderText
        {
            get { return placeholderText; }
            set
            {
                if (placeholderText != value)
                {
                    placeholderText = value;
                    this.RaisePropertyChanged(nameof(PlaceholderText));
                }
            }
        }

        public string SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    this.RaisePropertyChanged(nameof(SelectedItem));
                }
            }
        }
        public ObservableCollection<CityInfo> Cities
        {
            get { return cities; }
            set
            {
                if (cities != value)
                {
                    cities = value;
                    this.RaisePropertyChanged(nameof(Cities));
                }
            }
        }

        private int selectedContinentIndex;

        public int SelectedContinentIndex
        {
            get { return selectedContinentIndex; }
            set
            {
                selectedContinentIndex = value;
                if (selectedContinentIndex == 5)
                {
                    this.PopulateContinentsData();
                }
                else
                {
                    string selectedContinent = string.Empty;
                    switch (SelectedContinentIndex)
                    {
                        case 0:
                            selectedContinent = "Asia";
                            break;
                        case 1:
                            selectedContinent = "Africa";
                            break;
                        case 2:
                            selectedContinent = "North America";
                            break;
                        case 3:
                            selectedContinent = "South America";
                            break;
                        case 4:
                            selectedContinent = "Europe";
                            break;
                        default:
                            break;
                    }
                    // ObservableCollection<ContinentInfo> countries = new ObservableCollection<ContinentInfo>();
                    //ContinentList = (ObservableCollection<ContinentInfo>)(from ContinentInfo item in ContinentList
                    //                                                      where item.Continent.Equals(selectedContinent)
                    //                                                      select item);
                    FilteredCountryList = new ObservableCollection<ContinentInfo>(ContinentList.Where(x=> x.Continent.Equals(selectedContinent)));
                }

                this.RaisePropertyChanged(nameof(SelectedContinentIndex));
            }
        }

        private ObservableCollection<ContinentInfo> filteredCountryList;

        public ObservableCollection<ContinentInfo> FilteredCountryList
        {
            get { return filteredCountryList; }
            set {
                filteredCountryList = value;
                this.RaisePropertyChanged(nameof(FilteredCountryList));
            }
        }


        public ObservableCollection<ContinentInfo> ContinentList { get; set; }

        public object Vegetables { get; set; }

        public ObservableCollection<Vegetable> VegetablesList { get; set; }

        public ObservableCollection<Person> Persons
        {
            get { return persons; }
        }

        private void PopulateEmployeesData()
        {
            string path = @"ms-appx:///";
#if Main_SB
            path = @"ms-appx:///Editor/";
#endif

            this.Employees = new ObservableCollection<Employee>();
            this.Employees.Add(new Employee
            {
                Name = "Anne Dodsworth",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/ComboBox/Employees/Employee1.png", UriKind.RelativeOrAbsolute)),
                Designation= "Developer",
                ID="E001",
                Country= "USA",
            });
            this.Employees.Add(new Employee
            {
                Name = "Andrew Fuller",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/ComboBox/Employees/Employee7.png", UriKind.RelativeOrAbsolute)),
                Designation = "Team Lead",
                ID = "E002",
                Country = "England",
            });
            this.Employees.Add(new Employee
            {
                Name = "Emilio Alvaro",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/ComboBox/Employees/Employee5.png", UriKind.RelativeOrAbsolute)),
                Designation = "Product Manager",
                ID = "E003",
                Country = "England",
            });
            this.Employees.Add(new Employee
            {
                Name = "Janet Leverling",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/ComboBox/Employees/Employee3.png", UriKind.RelativeOrAbsolute)),
                Designation = "HR",
                ID = "E004",
                Country = "USA",
            });
            this.Employees.Add(new Employee
            {
                Name = "Laura Callahan",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/ComboBox/Employees/Employee2.png", UriKind.RelativeOrAbsolute)),
                Designation = "Product Manager",
                ID = "E005",
                Country = "USA",
            });
            this.Employees.Add(new Employee
            {
                Name = "Margaret Peacock",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/ComboBox/Employees/Employee6.png", UriKind.RelativeOrAbsolute)),
                Designation = "Developer",
                ID = "E006",
                Country = "USA",
            });
            this.Employees.Add(new Employee
            {
                Name = "Michael Suyama",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/ComboBox/Employees/Employee9.png", UriKind.RelativeOrAbsolute)),
                Designation = "Team Lead",
                ID = "E007",
                Country = "USA",
            });
            this.Employees.Add(new Employee
            {
                Name = "Nancy Davolio",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/ComboBox/Employees/Employee4.png", UriKind.RelativeOrAbsolute)),
                Designation = "Developer",
                ID = "E008",
                Country = "USA",
            });
            this.Employees.Add(new Employee
            {
                Name = "Robert King",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/ComboBox/Employees/Employee8.png", UriKind.RelativeOrAbsolute)),
                Designation = "Developer",
                ID = "E009",
                Country = "England",
            });
            this.Employees.Add(new Employee
            {
                Name = "Steven Buchanan",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/ComboBox/Employees/Employee10.png", UriKind.RelativeOrAbsolute)),
                Designation = "CEO",
                ID = "E010",
                Country = "England",
            });
        }

        private void PopulateSportsData()
        {
            this.SportsData = new ObservableCollection<Sport>();
            this.SportsData.Add(new Sport
            {
                ID = "Game1",
                Game = "American Football",
            });
            this.SportsData.Add(new Sport
            {
                ID = "Game2",
                Game = "Badminton",
            });
            this.SportsData.Add(new Sport
            {
                ID = "Game3",
                Game = "Basketball",
            });
            this.SportsData.Add(new Sport
            {
                ID = "Game4",
                Game = "Cricket",
            });
            this.SportsData.Add(new Sport
            {
                ID = "Game5",
                Game = "Football",
            });
            this.SportsData.Add(new Sport
            {
                ID = "Game6",
                Game = "Golf",
            });
            this.SportsData.Add(new Sport
            {
                ID = "Game7",
                Game = "Hockey",
            });
            this.SportsData.Add(new Sport
            {
                ID = "Game8",
                Game = "Rugby",
            });
            this.SportsData.Add(new Sport
            {
                ID = "Game9",
                Game = "Snooker",
            });
            this.SportsData.Add(new Sport
            {
                ID = "Game10",
                Game = "Tennis",
            });
        }

        private void PopulateSocialMediasData()
        {
            this.SocialMedias = new ObservableCollection<string>();
            this.SocialMedias.Add("Facebook");
            this.SocialMedias.Add("Google Plus");
            this.SocialMedias.Add("Instagram");
            this.SocialMedias.Add("LinkedIn");
            this.SocialMedias.Add("Skype");
            this.SocialMedias.Add("Tumblr");
            this.SocialMedias.Add("Twitter");
            this.SocialMedias.Add("Vimeo");
            this.SocialMedias.Add("WhatsApp");
            this.SocialMedias.Add("YouTube");
        }

        private void PopulateCountriesData()
        {
            this.Countries = new ObservableCollection<string>();
            this.Countries.Add("Afghanistan");
            this.Countries.Add("Albania");
            this.Countries.Add("Algeria");
            this.Countries.Add("Australia");
            this.Countries.Add("Argentina");
            this.Countries.Add("Bahamas");
            this.Countries.Add("Bangladesh");
            this.Countries.Add("Belgium");
            this.Countries.Add("Bermuda");
            this.Countries.Add("Canada");
            this.Countries.Add("Cameroon");
            this.Countries.Add("Colombia");
            this.Countries.Add("Comoros");
            this.Countries.Add("Cuba");
            this.Countries.Add("Denmark");
            this.Countries.Add("France");
            this.Countries.Add("Finland");
            this.Countries.Add("Germany");
            this.Countries.Add("Greenland");
            this.Countries.Add("Hong Kong");
            this.Countries.Add("India");
            this.Countries.Add("Italy");
            this.Countries.Add("Japan");
            this.Countries.Add("Mexico");
            this.Countries.Add("Norway");
            this.Countries.Add("Poland");
            this.Countries.Add("Switzerland");
            this.Countries.Add("United Kingdom");
            this.Countries.Add("United States");
        }

        private void PopulateVegetablesData()
        {
            var vegetables = new ObservableCollection<Vegetable>();
            vegetables.Add(new Vegetable
            {
                Name = "Cabbage",
                Category = "Leafy and Salad",
            });
            vegetables.Add(new Vegetable
            {
                Name = "Chickpea",
                Category = "Beans",
            });
            vegetables.Add(new Vegetable
            {
                Name = "Garlic",
                Category = "Bulb and Stem",
            });
            vegetables.Add(new Vegetable
            {
                Name = "Green bean",
                Category = "Beans",
            });
            vegetables.Add(new Vegetable
            {
                Name = "Horse gram",
                Category = "Beans",
            });
            vegetables.Add(new Vegetable
            {
                Name = "Nopal",
                Category = "Bulb and Stem",
            });
            vegetables.Add(new Vegetable
            {
                Name = "Onion",
                Category = "Bulb and Stem",
            });
            vegetables.Add(new Vegetable
            {
                Name = "Pumpkins",
                Category = "Leafy and Salad",
            });
            vegetables.Add(new Vegetable
            {
                Name = "Spinach",
                Category = "Leafy and Salad",
            });
            vegetables.Add(new Vegetable
            {
                Name = "Wheat grass",
                Category = "Leafy and Salad",
            });
            vegetables.Add(new Vegetable
            {
                Name = "Yarrow",
                Category = "Leafy and Salad",
            });

            this.VegetablesList = vegetables;
            this.Vegetables = vegetables.GroupBy(item => item.Category);
        }

        private void PopulateCountryListData()
        {
            this.CountryList = new ObservableCollection<CountryInfo>();
            this.CountryList.Add(new CountryInfo
            {
                CountryName = "Australia",
                CountryID = "2",
            });
            this.CountryList.Add(new CountryInfo
            {
                CountryName = "United States",
                CountryID = "1",
            });
        }

        private void UpdateStateList()
        {
            this.StateList = (this.SelectedCountry != null) ? GetStatesByCountryID(this.SelectedCountry.CountryID) : null;
        }

        private void UpdateCityList()
        {
            this.CityList = (this.SelectedState != null) ? GetCitiesByStateId(this.SelectedState.StateID) : null;
        }

        private void UpdatePlaceholderText()
        {
            if(this.SelectionMode == ComboBoxSelectionMode.Single)
            {
                this.PlaceholderText = "Select a social media";
            }
            else if(this.SelectionMode == ComboBoxSelectionMode.Multiple)
            {
                this.PlaceholderText = "Select social medias";
            }
        }

        private void PopulateSelectionBoxCountryListData()
        {
            string path = @"ms-appx:///";
#if Main_SB
            path = @"ms-appx:///Editor/";
#endif
            this.SelectionBoxCountryList = new ObservableCollection<CountryInfo>();
            this.SelectionBoxCountryList.Add(new CountryInfo
            {
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/UnitedStates.png", UriKind.RelativeOrAbsolute)),
                CountryName = "United States"
            });

            this.SelectionBoxCountryList.Add(new CountryInfo
            {
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/turkey.png", UriKind.RelativeOrAbsolute)),
                CountryName = "Turkey"
            });

            this.SelectionBoxCountryList.Add(new CountryInfo
            {
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/Mexico.png", UriKind.RelativeOrAbsolute)),
                CountryName = "Mexico"
            });

            this.SelectionBoxCountryList.Add(new CountryInfo
            {
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/Basque.png", UriKind.RelativeOrAbsolute)),
                CountryName = "Basque"
            });

            this.SelectionBoxCountryList.Add(new CountryInfo
            {
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/India.png", UriKind.RelativeOrAbsolute)),
                CountryName = "India"
            });

            this.SelectionBoxCountryList.Add(new CountryInfo
            {
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/Portugal.png", UriKind.RelativeOrAbsolute)),
                CountryName = "Portugal"
            });

            this.SelectionBoxCountryList.Add(new CountryInfo
            {
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/UnitedKingdom.png", UriKind.RelativeOrAbsolute)),
                CountryName = "United Kingdom"
            });

            this.SelectionBoxCountryList.Add(new CountryInfo
            {
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/france.png", UriKind.RelativeOrAbsolute)),
                CountryName = "France"
            });

            this.SelectionBoxCountryList.Add(new CountryInfo
            {
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/china.png", UriKind.RelativeOrAbsolute)),
                CountryName = "China"
            });

            this.SelectionBoxCountryList.Add(new CountryInfo
            {
                FlagImage = new BitmapImage(new Uri(path + "Assets/NumberBox/Russia.png", UriKind.RelativeOrAbsolute)),
                CountryName = "Russia"
            });
        }

        private void PopulateCitiesData()
        {
            this.Cities = new ObservableCollection<CityInfo>();
            this.cities.Add(new CityInfo() { CityName= "Chicago", CountryName= "USA" });
            this.cities.Add(new CityInfo() { CityName= "Los Angeles", CountryName= "USA" });          
            this.cities.Add(new CityInfo() { CityName= "Houston", CountryName= "USA" });
            this.cities.Add(new CityInfo() { CityName= "New York", CountryName= "USA" });
            this.cities.Add(new CityInfo() { CityName = "Washington", CountryName = "USA", IsCapital = true });
            this.cities.Add(new CityInfo() { CityName= "Chennai", CountryName= "India" });
            this.cities.Add(new CityInfo() { CityName= "Delhi", CountryName= "India", IsCapital = true });
            this.cities.Add(new CityInfo() { CityName= "Kolkata", CountryName= "India" });
            this.cities.Add(new CityInfo() { CityName= "Mumbai", CountryName= "India" });
            this.cities.Add(new CityInfo() { CityName= "Berlin", CountryName= "Germany", IsCapital = true });
            this.cities.Add(new CityInfo() { CityName= "Cologne", CountryName= "Germany" });
            this.cities.Add(new CityInfo() { CityName= "Hamburg", CountryName= "Germany" });
            this.cities.Add(new CityInfo() { CityName= "Munich", CountryName= "Germany" });
            this.cities.Add(new CityInfo() { CityName= "Quebec City", CountryName= "Canada" });
            this.cities.Add(new CityInfo() { CityName= "Ottawa", CountryName= "Canada", IsCapital = true });
            this.cities.Add(new CityInfo() { CityName= "Toronto", CountryName= "Canada" });
            this.cities.Add(new CityInfo() { CityName= "Vancouver", CountryName= "Canada" });
            this.cities.Add(new CityInfo() { CityName= "Victoria", CountryName= "Canada" });
            this.cities.Add(new CityInfo() { CityName= "London", CountryName= "England", IsCapital = true });
            this.cities.Add(new CityInfo() { CityName= "Bath", CountryName= "England" });
            this.cities.Add(new CityInfo() { CityName= "Manchester", CountryName= "England" });
            this.cities.Add(new CityInfo() { CityName= "Oxford", CountryName= "England" });
            this.cities.Add(new CityInfo() { CityName= "Bandung", CountryName= "Indonesia" });
            this.cities.Add(new CityInfo() { CityName= "Jakarta", CountryName= "Indonesia", IsCapital = true });
            this.cities.Add(new CityInfo() { CityName= "Depok", CountryName= "Indonesia" });
            this.cities.Add(new CityInfo() { CityName= "Makassar", CountryName= "Indonesia" });
            this.cities.Add(new CityInfo() { CityName= "Surabaya", CountryName= "Indonesia" });

        }

        public static ObservableCollection<State> GetStates()
        {
            var states = new ObservableCollection<State>();
            states.Add(new State
            {
                StateName = "New York",
                CountryID = "1",
                StateID = "101",
            });
            states.Add(new State
            {
                StateName = "Queensland",
                CountryID = "2",
                StateID = "104",
            });
            states.Add(new State
            {
                StateName = "Tasmania",
                CountryID = "2",
                StateID = "105",
            });
            states.Add(new State
            {
                StateName = "Victoria",
                CountryID = "2",
                StateID = "106",
            });
            states.Add(new State
            {
                StateName = "Virginia",
                CountryID = "1",
                StateID = "102",
            });
            states.Add(new State
            {
                StateName = "Washington",
                CountryID = "1",
                StateID = "103",
            });

            return states;
        }

        public static ObservableCollection<State> GetStatesByCountryID(string countryID)
        {
            ObservableCollection<State> stateList = new ObservableCollection<State>();
            foreach (State state in GetStates())
            {
                if (state.CountryID == countryID)
                {
                    stateList.Add(new State()
                    {
                        CountryID = state.CountryID,
                        StateName = state.StateName,
                        StateID = state.StateID,
                    });
                }
            }

            return stateList;
        }

        public static ObservableCollection<City> GetCities()
        {
            var cities = new ObservableCollection<City>();
            cities.Add(new City
            {
                CityName = "Aberdeen",
                StateID = "103",
                CityID = "207",
            });
            cities.Add(new City
            {
                CityName = "Alexandria",
                StateID = "102",
                CityID = "204",
            });
            cities.Add(new City
            {
                CityName = "Albany",
                StateID = "101",
                CityID = "201",
            });
            cities.Add(new City
            {
                CityName = "Beacon",
                StateID = "101",
                CityID = "202",
            });
            cities.Add(new City
            {
                CityName = "Brisbane",
                StateID = "104",
                CityID = "211",
            });
            cities.Add(new City
            {
                CityName = "Cairns",
                StateID = "104",
                CityID = "212",
            });
            cities.Add(new City
            {
                CityName = "Colville",
                StateID = "103",
                CityID = "208",
            });
            cities.Add(new City
            {
                CityName = "Devonport",
                StateID = "105",
                CityID = "215",
            });
            cities.Add(new City
            {
                CityName = "Emporia",
                StateID = "102",
                CityID = "206",
            });
            cities.Add(new City
            {
                CityName = "Geelong",
                StateID = "106",
                CityID = "218",
            });
            cities.Add(new City
            {
                CityName = "Hampton",
                StateID = "102",
                CityID = "205",
            });
            cities.Add(new City
            {
                CityName = "Healesville",
                StateID = "106",
                CityID = "217",
            });
            cities.Add(new City
            {
                CityName = "Hobart",
                StateID = "105",
                CityID = "213",
            });
            cities.Add(new City
            {
                CityName = "Launceston",
                StateID = "105",
                CityID = "214",
            });
            cities.Add(new City
            {
                CityName = "Lockport",
                StateID = "101",
                CityID = "203",
            });
            cities.Add(new City
            {
                CityName = "Melbourne",
                StateID = "106",
                CityID = "216",
            });
            cities.Add(new City
            {
                CityName = "Pasco",
                StateID = "103",
                CityID = "209",
            });
            cities.Add(new City
            {
                CityName = "Townsville",
                StateID = "104",
                CityID = "210",
            });

            return cities;
        }

        public static ObservableCollection<City> GetCitiesByStateId(string stateID)
        {
            ObservableCollection<City> cityList = new ObservableCollection<City>();
            foreach (City city in GetCities())
            {
                if (city.StateID == stateID)
                {
                    cityList.Add(new City()
                    {
                        CityName = city.CityName,
                        StateID = city.StateID,
                        CityID = city.CityID,
                    });
                }
            }

            return cityList;
        }
        public static ObservableCollection<Person> GetPersonDetails(int count)
        {
            string[] employees = { "Michael", "Kathryn", "Tamer", "Martin", "Davolio", "Nancy", "Fuller", "Leverling", "Therasa",
        "Margaret", "Buchanan", "Janet", "Andrew", "Callahan", "Laura", "Dodsworth", "Anne",
        "Bergs", "Vinet", "Anto", "Fleet", "Zachery", "Van", "Edward", "Jack", "Rose"};
           
            string[] mail = { "arpy.com", "sample.com", "rpy.com", "jourrapide.com" };
           

            Random random = new Random();
            ObservableCollection<Person> ordersDetails = new ObservableCollection<Person>();

            for (int i = 100; i < count + 100; i++)
            {
                var name = employees[random.Next(25)];

                ordersDetails.Add(new Person(name, name.ToLower(CultureInfo.CurrentCulture) + "@" + mail[random.Next(4)]));
            }

            return ordersDetails;
        }

        private void PopulateContinentsData()
        {
            var continents = new ObservableCollection<ContinentInfo>();
            continents.Add(new ContinentInfo
            {
                Country = "Japan",
                Continent = "Asia",
            });
            continents.Add(new ContinentInfo
            {
                Country = "China",
                Continent = "Asia",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Malaysia",
                Continent = "Asia",
            });
            continents.Add(new ContinentInfo
            {
                Country = "India",
                Continent = "Asia",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Hong Kong",
                Continent = "Asia",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Algeria",
                Continent = "Africa",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Morocco",
                Continent = "Africa",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Angola",
                Continent = "Africa",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Benin",
                Continent = "Africa",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Nigeria",
                Continent = "Africa",
            });
            continents.Add(new ContinentInfo
            {
                Country = "United States",
                Continent = "North America",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Mexico",
                Continent = "North America",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Canada",
                Continent = "North America",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Cuba",
                Continent = "North America",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Haiti",
                Continent = "North America",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Brazil",
                Continent = "South America",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Argentina",
                Continent = "South America",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Colombia",
                Continent = "South America",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Aruba",
                Continent = "South America",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Ecuador",
                Continent = "South America",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Germany",
                Continent = "Europe",
            });
            continents.Add(new ContinentInfo
            {
                Country = "France",
                Continent = "Europe",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Italy",
                Continent = "Europe",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Spain",
                Continent = "Europe",
            });
            continents.Add(new ContinentInfo
            {
                Country = "Portugal",
                Continent = "Europe",
            });

            this.ContinentList = continents;
            this.FilteredCountryList = continents;
        }
    }
}
