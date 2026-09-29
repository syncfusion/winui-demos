using Syncfusion.UI.Xaml.Chat;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;

namespace Syncfusion.ChatDemos.WinUI
{
    /// <summary>
    /// View model for the Conversation History sample. Maintains a list of past
    /// conversations (each with a title, timestamp and stored messages) that the
    /// SfAIAssistView navigation pane displays, and a single active chat
    /// collection (<see cref="Chats"/>) bound to the control's Messages.
    /// </summary>
    internal class ConversationHistoryViewModel : INotifyPropertyChanged
    {
        internal bool isStopResponding;

        private Author currentUser;
        public Author CurrentUser
        {
            get
            {
                return this.currentUser;
            }
            set
            {
                this.currentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }

        private ObservableCollection<object> chats;
        public ObservableCollection<object> Chats
        {
            get
            {
                return this.chats;
            }
            set
            {
                this.chats = value;
                RaisePropertyChanged("Chats");
            }
        }

        private bool showTypingIndicator;
        public bool ShowTypingIndicator
        {
            get
            {
                return this.showTypingIndicator;
            }
            set
            {
                this.showTypingIndicator = value;
                RaisePropertyChanged("ShowTypingIndicator");
            }
        }

        AIAssistChatService<Response> service;

        public DataTemplate AIIcon { get; set; }

        // Author for the bot messages. The ContentTemplate is applied in
        // InitAI because the AIIcon property is set by XAML after the
        // constructor has already run and the conversations are built.
        private Author bot;

        private ObservableCollection<AssistConversationItem> conversations;
        public ObservableCollection<AssistConversationItem> Conversations
        {
            get { return this.conversations; }
            set
            {
                this.conversations = value;
                RaisePropertyChanged("Conversations");
            }
        }

        public ConversationHistoryViewModel()
        {
            this.Chats = new ObservableCollection<object>();
            this.CurrentUser = new Author { Name = "John" };

            var user = new Author { Name = "John" };
            // ContentTemplate is applied later (see InitAI) since AIIcon is
            // not yet assigned when the constructor runs.
            bot = new Author { Name = "Bot", ContentTemplate = AIIcon };

            this.Conversations = new ObservableCollection<AssistConversationItem>()
            {
                new AssistConversationItem
                {
                    Title = "How to Improve Code Quality",
                    DateTime = DateTime.Now.AddMinutes(-30),
                    AssistItems = new ObservableCollection<object>
                    {
                        new TextMessage
                        {
                            Author = user,
                            DateTime = DateTime.Now.AddMinutes(-30),
                            Text = "How to Improve Code Quality"
                        },
                        new AIMessage
                        {
                            Author = bot,
                            DateTime = DateTime.Now.AddMinutes(-29),
                            Solution = "**How to Improve Code Quality:**\n\n" +
                                   "1. Follow SOLID principles (Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion) to create maintainable and scalable code.\n" +
                                   "2. Write comprehensive unit tests with high coverage to catch bugs early and facilitate refactoring with confidence.\n" +
                                   "3. Conduct regular code reviews to share knowledge, identify issues, and maintain consistent coding standards across the team.\n" +
                                   "4. Use static analysis tools like SonarQube or StyleCop to automatically detect code smells, security vulnerabilities, and potential bugs."
                        }
                    }
                },
                new AssistConversationItem
                {
                    Title = "Best Practices for API Design",
                    DateTime = DateTime.Now.AddDays(-1),
                    AssistItems = new ObservableCollection<object>
                    {
                        new TextMessage
                        {
                            Author = user,
                            DateTime = DateTime.Now.AddDays(-1),
                            Text = "Best Practices for API Design"
                        },
                        new AIMessage
                        {
                            Author = bot,
                            DateTime = DateTime.Now.AddDays(-1).AddMinutes(1),
                            Solution = "**Best Practices for API Design:**\n\n" +
                                   "1. Use RESTful principles with clear resource models and proper HTTP methods (GET for retrieval, POST for creation, PUT for updates, DELETE for removal).\n" +
                                   "2. Implement API versioning (URL-based or header-based) to maintain backward compatibility while introducing new features.\n" +
                                   "3. Provide comprehensive API documentation using tools like Swagger/OpenAPI with examples, error codes, and authentication details.\n" +
                                   "4. Design consistent error responses, implement rate limiting, and use proper status codes to communicate API behavior clearly."
                        }
                    }
                },
                new AssistConversationItem
                {
                    Title = "Cloud Migration Strategy",
                    DateTime = DateTime.Now.AddDays(-2),
                    AssistItems = new ObservableCollection<object>
                    {
                        new TextMessage
                        {
                            Author = user,
                            DateTime = DateTime.Now.AddDays(-2),
                            Text = "Cloud Migration Strategy"
                        },
                        new AIMessage
                        {
                            Author = bot,
                            DateTime = DateTime.Now.AddDays(-2).AddMinutes(1),
                            Solution = "**Cloud Migration Strategy:**\n\n" +
                                   "1. Assess current infrastructure by documenting applications, dependencies, performance metrics, and security requirements in detail.\n" +
                                   "2. Choose appropriate cloud services (IaaS, PaaS, SaaS) based on workload requirements, cost analysis, and organizational expertise.\n" +
                                   "3. Create a phased migration plan starting with non-critical systems, conducting thorough testing at each stage, and maintaining rollback procedures.\n" +
                                   "4. Monitor post-migration performance, optimize resource allocation, and continuously review costs to ensure ROI."
                        }
                    }
                },
                new AssistConversationItem
                {
                    Title = "Database Optimization Tips",
                    DateTime = DateTime.Now.AddDays(-3),
                    AssistItems = new ObservableCollection<object>
                    {
                        new TextMessage
                        {
                            Author = user,
                            DateTime = DateTime.Now.AddDays(-3),
                            Text = "Database Optimization Tips"
                        },
                        new AIMessage
                        {
                            Author = bot,
                            DateTime = DateTime.Now.AddDays(-3).AddMinutes(1),
                            Solution = "**Database Optimization Tips:**\n\n" +
                                   "1. Implement proper indexing on frequently queried columns, but avoid over-indexing which can slow down write operations.\n" +
                                   "2. Optimize queries by using EXPLAIN plans, eliminating N+1 queries, and using appropriate JOIN strategies for your database system.\n" +
                                   "3. Implement connection pooling to reuse database connections efficiently and reduce overhead from establishing new connections.\n" +
                                   "4. Use caching strategies (Redis, Memcached) for frequently accessed data, and consider database partitioning for very large datasets to improve query performance."
                        }
                    }
                },
                new AssistConversationItem
                {
                    Title = "Security Considerations",
                    DateTime = DateTime.Now.AddDays(-4),
                    AssistItems = new ObservableCollection<object>
                    {
                        new TextMessage
                        {
                            Author = user,
                            DateTime = DateTime.Now.AddDays(-4),
                            Text = "Security Considerations"
                        },
                        new AIMessage
                        {
                            Author = bot,
                            DateTime = DateTime.Now.AddDays(-4).AddMinutes(1),
                            Solution = "**Security Considerations:**\n\n" +
                                   "1. Implement robust authentication mechanisms (OAuth 2.0, JWT) and authorization frameworks (RBAC, ABAC) to control access to sensitive resources.\n" +
                                   "2. Encrypt sensitive data both in transit (TLS/SSL) and at rest using industry-standard encryption algorithms like AES-256.\n" +
                                   "3. Validate all user inputs on the server-side to prevent injection attacks, XSS, and other common vulnerabilities.\n" +
                                   "4. Conduct regular security audits, penetration testing, and stay updated with security patches to protect against emerging threats."
                        }
                    }
                },
                new AssistConversationItem
                {
                    Title = "Performance Tuning",
                    DateTime = DateTime.Now.AddDays(-5),
                    AssistItems = new ObservableCollection<object>
                    {
                        new TextMessage
                        {
                            Author = user,
                            DateTime = DateTime.Now.AddDays(-5),
                            Text = "Performance Tuning"
                        },
                        new AIMessage
                        {
                            Author = bot,
                            DateTime = DateTime.Now.AddDays(-5).AddMinutes(1),
                            Solution = "**Performance Tuning:**\n\n" +
                                   "1. Profile your code using tools like dotTrace or profilers to identify bottlenecks and resource-intensive operations accurately.\n" +
                                   "2. Optimize algorithms by choosing appropriate data structures, reducing time complexity, and avoiding unnecessary computations.\n" +
                                   "3. Implement caching layers (distributed caches) and asynchronous processing to handle high loads and improve response times.\n" +
                                   "4. Use load balancing techniques and horizontal scaling to distribute traffic across multiple servers and ensure system reliability."
                        }
                    }
                }
            };
        }

        public async void InitAI()
        {
            // AIIcon is assigned via XAML after the constructor ran, so the
            // bot author used in the stored conversations missed it until
            // now. Applying it here (Author raises PropertyChanged for
            // ContentTemplate) makes the AI avatar show in the default/
            // stored conversation messages as well, not just new chats.
            this.bot.ContentTemplate = this.AIIcon;

            service = new AIAssistChatService<Response>
            {
                Requirement = string.Format("I am an AI assistant that helps people find information, " +
                "Give required information in markdown format and send the response in json schema.{0}",
                GenerateJsonSchema(typeof(Response))),
            };

            await service.Initialize();

            // Note: no greeting message is added here. Chats stays empty at
            // startup so the EmptyView of SfAIAssistView is shown until the
            // user selects a past conversation or sends a new prompt.
        }

        public static string GenerateJsonSchema(Type type)
        {
            var store =
@"{
  ""type"": ""object"",
  ""properties"": {
    ""AIResponse"": {
      ""type"": [
        ""string"",
        ""null""
      ]
    },
    ""Suggestions"": {
      ""type"": [
        ""array"",
        ""null""
      ],
      ""items"": {
        ""type"": [
          ""string"",
          ""null""
        ]
      }
    }
  },
  ""required"": [
    ""AIResponse"",
    ""Suggestions""
  ]
}";
            return store;
        }

        /// <summary>
        /// Sends the given user text to the AI service and appends the
        /// response to the active chat. Called by the code-behind when the
        /// user types a new prompt. This is the ONLY path that triggers an
        /// AI response in the conversation-history demo.
        /// </summary>
        public async Task SendUserMessageAsync(string text)
        {
            if (service == null || string.IsNullOrWhiteSpace(text))
                return;

            ShowTypingIndicator = true;
            try
            {
                await service.NonStreamingChat(text);

                await Task.Delay(500);
                if (!isStopResponding)
                {
                    // Append the bot reply to the active chat.
                    Chats.Add(new AIMessage
                    {
                        Author = bot,
                        DateTime = DateTime.Now,
                        Solution = service.Response
                    });
                }
            }
            finally
            {
                ShowTypingIndicator = false;
                isStopResponding = false;
            }
        }

        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        internal async void ResponseToolbarItemClicked(ResponseToolbarItemClickedEventArgs e)
        {
            ShowTypingIndicator = true;
            await service.ResponseToolbarItemClicked(e, chats);
            ShowTypingIndicator = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
