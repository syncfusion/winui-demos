#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Syncfusion.SchedulerDemos.WinUI
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    using Microsoft.SemanticKernel.ChatCompletion;
    using Microsoft.SemanticKernel;
    using Newtonsoft.Json.Linq;
    using Syncfusion.DemosCommon.WinUI;
    using Syncfusion.UI.Xaml.Chat;
    using Syncfusion.UI.Xaml.Core;
    using Syncfusion.UI.Xaml.Scheduler;
    using Microsoft.UI.Xaml.Media;
    using Microsoft.UI;
    using Windows.UI;

    /// <summary>
    /// Represents the smart scheduler view model class.
    /// </summary>
    public class SmartSchedulerViewModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Holds the current user.
        /// </summary>
        private Author currentUser;

        /// <summary>
        /// Holds the Sophia start time collection.
        /// </summary>
        internal List<DateTime> SophiaStartTimeCollection;

        /// <summary>
        /// Holds the Sophia end time collection.
        /// </summary>
        internal List<DateTime> SophiaEndTimeCollection;

        /// <summary>
        /// Holds the Sophia subject collection.
        /// </summary>
        internal List<string> SophiaSubjectCollection;

        /// <summary>
        /// Holds the Sophia location collection.
        /// </summary>
        internal List<string> SophiaLocationCollection;

        /// <summary>
        /// Holds the Sophia resource ID collection.
        /// </summary>
        internal List<string> SophiaResourceIDCollection;

        /// <summary>
        /// Holds the John start time collection.
        /// </summary>
        internal List<DateTime> JohnStartTimeCollection;

        /// <summary>
        /// Holds the John end time collection.
        /// </summary>
        internal List<DateTime> JohnEndTimeCollection;

        /// <summary>
        /// Holds the John subject collection.
        /// </summary>
        internal List<string> JohnSubjectCollection;

        /// <summary>
        /// Holds the John location collection.
        /// </summary>
        internal List<string> JohnLocationCollection;

        /// <summary>
        /// Holds the John resource ID collection.
        /// </summary>
        internal List<string> JohnResourceIDCollection;

        /// <summary>
        /// Holds the Sophia time slots collection.
        /// </summary>
        internal List<string> SophiaAvailableTimeSlots = new List<string>();

        /// <summary>
        /// Holds the John time slots collection.
        /// </summary>
        internal List<string> JohnAvailableTimeSlots = new List<string>();

        /// <summary>
        /// Holds the collection resources.
        /// </summary>
        private ObservableCollection<object> resources;

        /// <summary>
        /// Holds the return message of AI.
        /// </summary>
        private string returnMessage = string.Empty;

        /// <summary>
        /// Holds the chat completion service.
        /// </summary>
        private IChatCompletionService chatCompletionService;

        /// <summary>
        /// Holds the kernel model.
        /// </summary>
        private Kernel kernel;

        /// <summary>
        /// Holds the showHeader value.
        /// </summary>
        private bool showHeader = true;

        /// <summary>
        /// Used to handle the visibility of assist view.
        /// </summary>
        private bool showAssistView = false;

        /// <summary>
        /// Holds the request time.
        /// </summary>
        private string requestTime = string.Empty;

        /// <summary>
        /// Gets or sets the scheduler.
        /// </summary>
        public SfScheduler Scheduler { get; set; }

        /// <summary>
        /// Holds the suggestion collection.
        /// </summary>
        private ObservableCollection<string> suggestion;

        /// <summary>
        /// Holds the chat collection.
        /// </summary>
        private ObservableCollection<object> chats;

        /// <summary>
        /// Holds the online appointment collection.
        /// </summary>
        public ScheduleAppointmentCollection Appointments = new ScheduleAppointmentCollection();

        /// <summary>
        /// Holds the AI assist resources collection.
        /// </summary>
        public ObservableCollection<AIAssistResourceViewModel> aIAssistResources;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the AI assist resources.
        /// </summary>
        public ObservableCollection<AIAssistResourceViewModel> AIAssistResources
        {
            get 
            { 
                return this.aIAssistResources; 
            }
            set 
            { 
                this.aIAssistResources = value; 
                this.RaisePropertyChanged("AIAssistResources"); 
            }
        }

        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        public Author CurrentUser
        {
            get
            {
                return this.currentUser;
            }
            set
            {
                this.currentUser = value;
                this.RaisePropertyChanged("CurrentUser");
            }
        }

        /// <summary>
        /// Gets or sets the collection of messages.
        /// </summary>
        public ObservableCollection<object> Chats
        {
            get
            {
                return this.chats;
            }
            set
            {
                this.chats = value;
                this.RaisePropertyChanged("Chats");
            }
        }

       /// <summary>
       /// Gets or sets the suggestion collection.
       /// </summary>
        public ObservableCollection<string> Suggestion
        {
            get
            {
                return this.suggestion;
            }
            set
            {
                this.suggestion = value;
                this.RaisePropertyChanged("Suggestion");
            }
        }

        /// <summary>
        /// Gets or sets the collection resources.
        /// </summary>
        public ObservableCollection<object> Resources
        {
            get
            {
                return this.resources;
            }

            set
            {
                this.resources = value;
            }
        }

        /// <summary>
        /// Gets or sets the show header.
        /// </summary>
        public bool ShowHeader
        {
            get { return this.showHeader; }
            set { this.showHeader = value; this.RaisePropertyChanged("ShowHeader"); }
        }

        /// <summary>
        /// Gets or sets the show assist view.
        /// </summary>
        public bool ShowAssistView
        {
            get { return this.showAssistView; }
            set { this.showAssistView = value; this.RaisePropertyChanged("ShowAssistView"); }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SmartSchedulerViewModel"/> class.
        /// </summary>
        public SmartSchedulerViewModel()
        {
            this.Chats = new ObservableCollection<object>();
            this.Chats.CollectionChanged += this.OnChatsCollectionChanged;
            this.Suggestion = new ObservableCollection<string>();
            this.Resources = new ObservableCollection<object>();
            this.CurrentUser = new Author { Name = "You" };
            this.InitializeResourcesView();
            this.GenerateAIAssistResource();
        }

        #region Methods

        /// <summary>
        /// Method to generate the AI assist resource info.
        /// </summary>
        private void GenerateAIAssistResource()
        {
            AIAssistResources = new ObservableCollection<AIAssistResourceViewModel>();
#if Main_SB
            AIAssistResources.Add(new AIAssistResourceViewModel() { Name = "Book an appointment with Dr. Sophia.", ImageName = "/Scheduler/Assets/Scheduler/People_Circle0.png" });
            AIAssistResources.Add(new AIAssistResourceViewModel() { Name = "Book an appointment with Dr. John.", ImageName = "/Scheduler/Assets/Scheduler/People_Circle1.png" });
#else
            AIAssistResources.Add(new AIAssistResourceViewModel() { Name = "Book an appointment with Dr. Sophia.", ImageName = "/Assets/Scheduler/People_Circle0.png" });
            AIAssistResources.Add(new AIAssistResourceViewModel() { Name = "Book an appointment with Dr. John.", ImageName = "/Assets/Scheduler/People_Circle1.png" });
#endif
        }

        /// <summary>
        /// Method to handle the collection changed event.
        /// </summary>
        /// <param name="sender">The object</param>
        /// <param name="e">The event args</param>
        private void OnChatsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var item = e.NewItems?[0] as ITextMessage;
            string requestString = item?.Text;
            if (item != null)
            {
                string pattern = @"\b\d{2}:\d{2} (AM|PM)\b";
                string pattern2 = @"\b\d{1,2}\s?(AM|PM)\b";
                bool isValidPattern = Regex.IsMatch(requestString, pattern);
                bool isValidPattern2 = Regex.IsMatch(requestString, pattern2);
                if (AISettings.IsCredentialValid)
                {
                    if (isValidPattern && (!requestString.Contains("Dr. Sophia’s available appointment times:") || !requestString.Contains("Dr. Sophia’s available appointment times:")))
                    {
                        this.OnAssistViewRequest(requestString);
                    }
                    else if (isValidPattern2 || requestString == "General Checkup" || requestString == "Vaccinations" || requestString == "Diagnostic report" || requestString == "Diabetes")
                    {
                        this.HandleOfflineAppointmentChat(requestString);
                    }
                    else if (item.Author.Name == currentUser.Name)
                    {
                        this.Suggestion.Clear();
                        this.GetResponseFromGPT(requestString);
                    }
                   
                }
                else
                {
                    this.HandleOfflineAppointmentChat(requestString);
                }
            }
        }

        /// <summary>
        /// Method to handle the offline chat.
        /// </summary>
        /// <param name="requestString">The request string</param>
        internal async void HandleOfflineAppointmentChat(string requestString)
        {
            if (requestString == "Book an appointment with Dr. Sophia.")
            {
                this.Chats.Add(new TextMessage
                {
                    Author = new Author { Name = "AI" },
                    DateTime = DateTime.Now,
                    Text = "Please select an available time slot."
                });
                await Task.Delay(1000);
                this.Suggestion = new ObservableCollection<string> { "9 AM", "11 AM", "2 PM", "4 PM" };
            }
            else if (requestString == "Book an appointment with Dr. John.")
            {
                this.Chats.Add(new TextMessage
                {
                    Author = new Author { Name = "AI" },
                    DateTime = DateTime.Now,
                    Text = "Please select an available time slot."
                });
                await Task.Delay(1000);
                this.Suggestion = new ObservableCollection<string> { "10 AM", "12 PM", "3 PM", "5 PM" };
            }
            else if (requestString == "9 AM" || requestString == "11 AM" || requestString == "2 PM"
            || requestString == "4 PM" || requestString == "10 AM" || requestString == "12 PM" || requestString == "3 PM" || requestString == "5 PM")
            {
                requestTime = requestString;
                await Task.Delay(1000);
                this.Chats.Add(new TextMessage
                {
                    Author = new Author { Name = "AI" },
                    DateTime = DateTime.Now,
                    Text = "What is the purpose of your appointment?"
                });

                this.Suggestion = new ObservableCollection<string> { "General Checkup", "Vaccinations", "Diagnostic report", "Diabetes" };
            }
            else if (requestString == "General Checkup" || requestString == "Vaccinations" || requestString == "Diagnostic report" || requestString == "Diabetes")
            {
                this.UpdateOfflineAppointmentBooking(requestTime, requestString);
                await Task.Delay(1000);
                this.Suggestion.Clear();
                this.Chats.Add(new TextMessage
                {
                    Author = new Author { Name = "AI" },
                    DateTime = DateTime.Now,
                    Text = "Appointment booked successfully.\nThank you!"
                });

                await Task.Delay(1000);
                this.Chats.Add(new TextMessage
                {
                    Author = new Author { Name = "AI" },
                    DateTime = DateTime.Now,
                    Text = "Please click the refresh button to schedule a new appointment."
                });
            }
            else if (!AISettings.IsCredentialValid && requestString != "Please select an available time slot." && requestString != "What is the purpose of your appointment?"
                && requestString != "Appointment booked successfully.\nThank you!" && requestString != "Please click the refresh button to schedule a new appointment.")
            {
                await Task.Delay(1000);
                this.Suggestion = new ObservableCollection<string> { "You are offline. Please connect to the internet and OpenAI." };
                await Task.Delay(3000);
                this.Suggestion.Clear();
            }
        }

        /// <summary>
        /// Method to book the offline appointments.
        /// </summary>
        /// <param name="timeValue">The time value.</param>
        /// <param name="subject">The subject.</param>
        private void UpdateOfflineAppointmentBooking(string timeValue, string subject)
        {
            var appointmentData = new Dictionary<string, (int hour, string resourceId)>
            {
                { "9 AM",  (9, "1000") },
                { "10 AM", (10, "1001") },
                { "11 AM", (11, "1000") },
                { "12 PM", (12, "1001") },
                { "2 PM",  (14, "1000") },
                { "3 PM",  (15, "1001") },
                { "4 PM",  (16, "1000") },
                { "5 PM",  (17, "1001") }
            };

            if (appointmentData.TryGetValue(timeValue, out var data))
            {
                if (this.Scheduler != null)
                {
                    var startTime = DateTime.Today.AddHours(data.hour);
                    this.Scheduler.DisplayDate = startTime;
                    this.Appointments.Add(new ScheduleAppointment()
                    {
                        StartTime = startTime,
                        EndTime = startTime.AddMinutes(30),
                        Subject = subject,
                        Location = "ABC hospital",
                        Foreground = new SolidColorBrush(Colors.White),
                        ResourceIdCollection = new ObservableCollection<object> { data.resourceId }
                    });

                    this.Scheduler.ItemsSource = Appointments;
                }
            }
        }

        /// <summary>
        /// Method to provide AI request.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private async void OnAssistViewRequest(string input)
        {
            string requeststring = input;
            DateTime sophiaStartTime;
            DateTime sophiaEndTime;
            string sophiaSubject = string.Empty;
            string sophiaLocation = string.Empty;
            string sophiaResourceID = string.Empty;
            DateTime johnStartTime;
            DateTime johnEndTime;
            string johnSubject = string.Empty;
            string johnLocation = string.Empty;
            string johnResourceID = string.Empty;

            if (string.IsNullOrEmpty(requeststring))
            {
                return;
            }

            bool timeMatched = false;
            for (int i = 0; i < this.SophiaAvailableTimeSlots?.Count; i++)
            {
                if (requeststring == this.SophiaAvailableTimeSlots[i].ToString())
                {
                    timeMatched = true;
                    sophiaStartTime = this.SophiaStartTimeCollection![i];
                    sophiaEndTime = this.SophiaEndTimeCollection![i];
                    sophiaSubject = this.SophiaSubjectCollection![i];
                    sophiaLocation = this.SophiaLocationCollection![i];
                    sophiaResourceID = this.SophiaResourceIDCollection![i];
                    this.BookOnlineAppointments(sophiaStartTime, sophiaEndTime, sophiaSubject, sophiaLocation, sophiaResourceID);
                    await Task.Delay(1000);
                    this.Chats.Add(new TextMessage
                    {
                        Author = new Author { Name = "AI" },
                        DateTime = DateTime.Now,
                        Text = "Your appointment with Dr. Sophia has been booked. See you soon!"
                    });
                }
            }

            for (int j = 0; j < this.JohnAvailableTimeSlots?.Count; j++)
            {
                if (requeststring == this.JohnAvailableTimeSlots[j].ToString())
                {
                    timeMatched = true;
                    johnStartTime = this.JohnStartTimeCollection![j];
                    johnEndTime = this.JohnEndTimeCollection![j];
                    johnSubject = this.JohnSubjectCollection![j];
                    johnLocation = this.JohnLocationCollection![j];
                    johnResourceID = this.JohnResourceIDCollection![j];
                    this.BookOnlineAppointments(johnStartTime, johnEndTime, johnSubject, johnLocation, johnResourceID);
                    await Task.Delay(1000);
                    this.Chats.Add(new TextMessage
                    {
                        Author = new Author { Name = "AI" },
                        DateTime = DateTime.Now,
                        Text = "Your appointment with Dr. John has been booked. See you soon!"
                    });
                }
            }

            if (!timeMatched)
            {
                await Task.Delay(1000);
                this.Chats.Add(new TextMessage
                {
                    Author = new Author { Name = "AI" },
                    DateTime = DateTime.Now,
                    Text = "This time is not available. Please enter an available time slot."
                });
            }
        }

        /// <summary>
        /// Method to get the initial appointments.
        /// </summary>
        internal void InitializeDefaultAppointments()
        {
            this.Appointments.Add(new ScheduleAppointment()
            {
                StartTime = DateTime.Today.AddHours(15).AddMinutes(30),
                EndTime = DateTime.Today.AddHours(16),
                Subject = "General Checkup",
                Location = "ABC hospital",
                Foreground = new SolidColorBrush(Colors.White),
                ResourceIdCollection = new ObservableCollection<object>() { "1000" }
            });

            this.Appointments.Add(new ScheduleAppointment()
            {
                StartTime = DateTime.Today.AddHours(10).AddMinutes(30),
                EndTime = DateTime.Today.AddHours(11),
                Subject = "Vaccinations",
                Location = "ABC hospital",
                Foreground = new SolidColorBrush(Colors.White),
                ResourceIdCollection = new ObservableCollection<object>() { "1000" }
            });

            this.Appointments.Add(new ScheduleAppointment()
            {
                StartTime = DateTime.Today.AddHours(9).AddMinutes(30),
                EndTime = DateTime.Today.AddHours(10),
                Subject = "Diagnostic report",
                Location = "ABC hospital",
                Foreground = new SolidColorBrush(Colors.White),
                ResourceIdCollection = new ObservableCollection<object>() { "1001" }
            });

            this.Appointments.Add(new ScheduleAppointment()
            {
                StartTime = DateTime.Today.AddHours(16).AddMinutes(30),
                EndTime = DateTime.Today.AddHours(17),
                Subject = "Diabetes",
                Location = "ABC hospital",
                Foreground = new SolidColorBrush(Colors.White),
                ResourceIdCollection = new ObservableCollection<object>() { "1001" }
            });

            this.Scheduler.ItemsSource = this.Appointments;
        }

        /// <summary>
        /// Method to book the online appointments.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="location">The location.</param>
        /// <param name="resourceID">The resource id.</param>
        private void BookOnlineAppointments(DateTime startTime, DateTime endTime, string subject, string location, string resourceID)
        {
            this.Scheduler.DisplayDate = startTime;
            this.Appointments.Add(new ScheduleAppointment()
            {
                StartTime = startTime,
                EndTime = endTime,
                Subject = subject,
                Location = location,
                ResourceIdCollection = new ObservableCollection<object>() { resourceID },
                Foreground = new SolidColorBrush(Colors.White),
            });

            this.Scheduler.ItemsSource = Appointments;
        }

        /// <summary>
        /// Method to initialize the AI.
        /// </summary>
        internal async void InitializeAIService()
        {
            if (!AISettings.IsCredentialValid)
            {
                await AISettings.ShowAISettingsWindow();
            }

            if (AISettings.IsCredentialValid)
            {
                var builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion(AISettings.ModelName,
                    AISettings.EndPoint, AISettings.Key);
                kernel = builder.Build();
                this.chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
            }
        }

        /// <summary>
        /// Method to get the AI response.
        /// </summary>
        /// <param name="prompt">The prompt</param>
        /// <returns>The response</returns>
        private async Task<string> GetAIResponse(string prompt)
        {
            var Conversation = new ChatHistory();
            Conversation.AddUserMessage(prompt);
            var response = await chatCompletionService.GetChatMessageContentAsync(chatHistory: Conversation, kernel: kernel);
            return response.ToString();
        }

        /// <summary>
        /// Method to contain AI response and updates.
        /// </summary>
        /// <param name="userInput">The user input</param>
        /// <returns>The user input</returns>
        private async void GetResponseFromGPT(string userInput)
        {
            DateTime todayDate = DateTime.Today;
            string prompt = $"Given data: {userInput}. Based on the given data, provide 10 appointment time details for Doctor1 and Doctor2 on {todayDate}." +
                            $"Availability time is 9AM to 6PM." +
                            $"In 10 appointments, split the time details as 5 for Doctor1 and 5 for Doctor2." +
                            $"Provide complete appointment time details for both Doctor1 and Doctor2 without missing any fields." +
                            $"It should be 30 minutes appointment duration." +
                            $"Doctor1 time details should not collide with Doctor2." +
                            $"Provide ResourceID for Doctor1 as 1000 and for Doctor2 as 1001." +
                            $"Do not repeat the same time. Generate the following fields: StartDate, EndDate, Subject, Location, and ResourceID." +
                            $"The return format should be the following JSON format: Doctor1[StartDate, EndDate, Subject, Location, ResourceID], Doctor2[StartDate, EndDate, Subject, Location, ResourceID]." +
                            $"Condition: provide details without any explanation.";

            returnMessage = await GetAIResponse(prompt);
            returnMessage = returnMessage.Substring(returnMessage.IndexOf('{'), returnMessage.LastIndexOf('}') - returnMessage.IndexOf('{') + 1);
            this.GetDoctorAppointments();

            this.FilterAppointmentsForSophia();
            this.FilterAppointmentsForJohn();

            this.SophiaAvailableTimeSlots = GenerateScheduleTimeSlotCollection(SophiaStartTimeCollection);
            this.JohnAvailableTimeSlots = GenerateScheduleTimeSlotCollection(JohnStartTimeCollection);

            var reply = this.GetAvailableTimeSlotsFromAI(userInput);
            this.Chats.Add(new TextMessage
            {
                Author = new Author { Name = "AI" },
                DateTime = DateTime.Now,
                Text = reply,
            });
        }

        /// <summary>
        /// Method to get the doctor appointments.
        /// </summary>
        private void GetDoctorAppointments()
        {
            var jsonObj = JObject.Parse(returnMessage);
            var doctorAppointments = new Dictionary<string, (List<DateTime> StartTimes, List<DateTime> EndTimes, List<string> Subjects, List<string> Locations, List<string> ResourceIDs)>
            {
                { "Doctor1", (new List<DateTime>(), new List<DateTime>(), new List<string>(), new List<string>(), new List<string>()) },
                { "Doctor2", (new List<DateTime>(), new List<DateTime>(), new List<string>(), new List<string>(), new List<string>()) }
            };

            foreach (var doctor in doctorAppointments.Keys)
            {
                foreach (var appointment in jsonObj[doctor]!)
                {
                    if (DateTime.TryParse((string)appointment["StartDate"]!, out DateTime startTime) && DateTime.TryParse((string)appointment["EndDate"]!, out DateTime endTime))
                    {
                        doctorAppointments[doctor].StartTimes.Add(startTime);
                        doctorAppointments[doctor].EndTimes.Add(endTime);
                    }

                    doctorAppointments[doctor].Subjects.Add((string)appointment["Subject"]!);
                    doctorAppointments[doctor].Locations.Add((string)appointment["Location"]!);
                    doctorAppointments[doctor].ResourceIDs.Add((string)appointment["ResourceID"]!);
                }
            }

            this.SophiaStartTimeCollection = doctorAppointments["Doctor1"].StartTimes;
            this.SophiaEndTimeCollection = doctorAppointments["Doctor1"].EndTimes;
            this.SophiaSubjectCollection = doctorAppointments["Doctor1"].Subjects;
            this.SophiaLocationCollection = doctorAppointments["Doctor1"].Locations;
            this.SophiaResourceIDCollection = doctorAppointments["Doctor1"].ResourceIDs;

            this.JohnStartTimeCollection = doctorAppointments["Doctor2"].StartTimes;
            this.JohnEndTimeCollection = doctorAppointments["Doctor2"].EndTimes;
            this.JohnSubjectCollection = doctorAppointments["Doctor2"].Subjects;
            this.JohnLocationCollection = doctorAppointments["Doctor2"].Locations;
            this.JohnResourceIDCollection = doctorAppointments["Doctor2"].ResourceIDs;
        }

        /// <summary>
        /// Method to generate the time slots.
        /// </summary>
        /// <param name="timeCollection">The time collection</param>
        /// <returns>The time collection.</returns>
        private List<string> GenerateScheduleTimeSlotCollection(List<DateTime> timeCollection)
        {
            return timeCollection.Select(time => time.ToString("hh:mm tt")).ToList();
        }

        /// <summary>
        /// Method to generate the final time slots.
        /// </summary>
        /// <param name="userInput">The user input</param>
        /// <returns>The availed time slot.</returns>
        private string GetAvailableTimeSlotsFromAI(string userInput)
        {
            string sophiaAvailedTimeSlots = string.Join(" \n ", this.SophiaAvailableTimeSlots!);
            string johnAvailedTimeSlots = string.Join(" \n ", this.JohnAvailableTimeSlots!);

            if (userInput.Contains("Sophia"))
            {
                return $"Dr. Sophia’s available appointment times:\n {sophiaAvailedTimeSlots} \nEnter the time (hh:mm tt) at which you’d like to book an appointment.";
            }
            else if (userInput.Contains("John"))
            {
                return $"Dr. Sophia’s available appointment times:\n {johnAvailedTimeSlots} \nEnter the time (hh:mm tt) at which you’d like to book an appointment.";
            }
            else
            {
                return $"Dr. Sophia’s available appointment times:\n {sophiaAvailedTimeSlots}\nDr. John available appointment slots:\n {johnAvailedTimeSlots}\nEnter the time (hh:mm tt) at which you’d like to book an appointment.";
            }
        }

        /// <summary>
        /// Method to filter the Sophia appointments.
        /// </summary>
        private void FilterAppointmentsForSophia()
        {
            for (int i = 0; i < this.Appointments?.Count; i++)
            {
                if (this.SophiaStartTimeCollection!.Contains(this.Appointments[i].StartTime))
                {
                    this.SophiaStartTimeCollection.Remove(this.Appointments[i].StartTime);
                }
            }
        }

        /// <summary>
        /// Method to filter the John appointments.
        /// </summary>
        private void FilterAppointmentsForJohn()
        {
            for (int i = 0; i < this.Appointments?.Count; i++)
            {
                if (this.JohnStartTimeCollection!.Contains(this.Appointments[i].StartTime))
                {
                    this.JohnStartTimeCollection.Remove(this.Appointments[i].StartTime);
                }
            }
        }

        /// <summary>
        /// Method to initialize the resources.
        /// </summary>
        private void InitializeResourcesView()
        {
            for (int i = 0; i < 2; i++)
            {
                SmartSchedulerResourceViewModel resourceViewModel = new SmartSchedulerResourceViewModel();

                if (i == 0)
                {
                    resourceViewModel.Name = "Sophia";
#if Main_SB
                    resourceViewModel.ImageName = "/Scheduler/Assets/Scheduler/People_Circle" + i.ToString() + ".png";
#else
                    resourceViewModel.ImageName = "/Assets/Scheduler/People_Circle" + i.ToString() + ".png";
#endif
                    resourceViewModel.Id = "1000";
                    resourceViewModel.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x36, 0xB3, 0x7B));
                }
                else
                {
                    resourceViewModel.Name = "John";
#if Main_SB
                    resourceViewModel.ImageName = "/Scheduler/Assets/Scheduler/People_Circle" + i.ToString() + ".png";
#else
                    resourceViewModel.ImageName = "/Assets/Scheduler/People_Circle" + i.ToString() + ".png";
#endif
                    resourceViewModel.Id = "1001";
                    resourceViewModel.Background = new SolidColorBrush(Color.FromArgb(255, 0x8B, 0x1F, 0xA9));
                }

                this.Resources?.Add(resourceViewModel);
            }
        }

        /// <summary>
        /// Method to handle the property changed event.
        /// </summary>
        /// <param name="propertyName">The property name</param>
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    #endregion

    /// <summary>
    /// Represents the message interface.
    /// </summary>
    public class AIMessage : NotificationObject, IMessage
    {
        /// <summary>
        /// Holds the solution.
        /// </summary>
        private string solution;

        /// <summary>
        /// Holds the author.
        /// </summary>
        private Author author;

        /// <summary>
        /// Holds the date and time.
        /// </summary>
        private DateTime dateTime;

        /// <summary>
        /// Gets or sets the text to be display as the message.
        /// </summary>
        public string Solution
        {
            get
            {
                return this.solution;
            }
            set
            {
                this.solution = value;
                this.RaisePropertyChanged(nameof(Solution));
            }
        }

        /// <summary>
        /// Gets or sets the author to be display in the message.
        /// </summary>
        public Author Author
        {
            get 
            { 
                return this.author; 
            }
            set
            {
                this.author = value;
                this.RaisePropertyChanged(nameof(Author));
            }
        }

        /// <summary>
        /// Gets or sets the date and time details when the message was created.
        /// </summary>
        public DateTime DateTime
        {
            get 
            { 
                return this.dateTime;
            }
            set
            {
                this.dateTime = value;
                this.RaisePropertyChanged(nameof(DateTime));
            }
        }
    }

    /// <summary>
    /// The AI assist resource view model class.
    /// </summary>
    public class AIAssistResourceViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AIAssistResourceViewModel"/> class.
        /// </summary>
        public AIAssistResourceViewModel()
        {
            this.Name = string.Empty;
            this.ImageName = string.Empty;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the image name.
        /// </summary>
        public string ImageName { get; set; }
    }
}