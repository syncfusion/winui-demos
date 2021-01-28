#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.Notifications;
using System.Collections.Generic;

namespace syncfusion.notificationdemos.winui
{
    public class BadgeViewModel : NotificationObject
    {
        private BadgeShape badgeShape = BadgeShape.Ellipse;
        private BadgeFill badgeFill = BadgeFill.Accent;
        private BadgeAnimationType badgeAnimationType = BadgeAnimationType.None;
        private double badgeContent = 20;
        private HorizontalAlignment horizontalAlignment = HorizontalAlignment.Right;
        private VerticalAlignment verticalAlignment = VerticalAlignment.Top;
        private BadgeAnchor horizontalAnchor = BadgeAnchor.Center;
        private BadgeAnchor verticalAnchor = BadgeAnchor.Center;
        private double controlSize = 100.0;
        private double horizontalPosition = 0.9;
        private double verticalPosition = 0.8;
        private double horizontalAnchorPosition = 0.8;
        private double verticalAnchorPosition = 0.3;
        private double content = 20;

        public BadgeViewModel()
        {
            MailItems = new List<MailInfo>();
            MailItems.Add(new MailInfo() { ItemName = "Inbox", UnreadMessageount = 20 });
            MailItems.Add(new MailInfo() { ItemName = "Drafts", UnreadMessageount = null });
            MailItems.Add(new MailInfo() { ItemName = "Sent Intems", UnreadMessageount = 5 });
            MailItems.Add(new MailInfo() { ItemName = "Deleted Items", UnreadMessageount = null });
            MailItems.Add(new MailInfo() { ItemName = "Junk Email", UnreadMessageount = null });
        }

        public List<MailInfo> MailItems { get; }

        public BadgeShape BadgeShape
        {
            get 
            { 
                return badgeShape; 
            }
            set
            {
                if (badgeShape != value)
                {
                    badgeShape = value;
                    this.RaisePropertyChanged(nameof(this.BadgeShape));
                }
            }
        }

        public BadgeFill BadgeFill
        {
            get
            {
                return badgeFill;
            }
            set
            {
                if (badgeFill != value)
                {
                    badgeFill = value;
                    this.RaisePropertyChanged(nameof(this.BadgeFill));
                }
            }
        }

        public BadgeAnimationType BadgeAnimationType
        {
            get
            {
                return badgeAnimationType;
            }
            set
            {
                if (badgeAnimationType != value)
                {
                    badgeAnimationType = value;
                    this.RaisePropertyChanged(nameof(this.BadgeAnimationType));
                }
            }
        }

        public double BadgeContent
        {
            get
            {
                return badgeContent;
            }
            set
            {
                if (badgeContent != value)
                {
                    badgeContent = value;
                    this.RaisePropertyChanged(nameof(this.BadgeContent));
                }
            }
        }

        public HorizontalAlignment HorizontalAlignment
        {
            get
            {
                return horizontalAlignment;
            }
            set
            {
                if (horizontalAlignment != value)
                {
                    horizontalAlignment = value;
                    this.RaisePropertyChanged(nameof(this.HorizontalAlignment));
                }
            }
        }

        public VerticalAlignment VerticalAlignment
        {
            get
            {
                return verticalAlignment;
            }
            set
            {
                if (verticalAlignment != value)
                {
                    verticalAlignment = value;
                    this.RaisePropertyChanged(nameof(this.VerticalAlignment));
                }
            }
        }

        public BadgeAnchor HorizontalAnchor
        {
            get
            {
                return horizontalAnchor;
            }
            set
            {
                if (horizontalAnchor != value)
                {
                    horizontalAnchor = value;
                    this.RaisePropertyChanged(nameof(this.HorizontalAnchor));
                }
            }
        }

        public BadgeAnchor VerticalAnchor
        {
            get
            {
                return verticalAnchor;
            }
            set
            {
                if (verticalAnchor != value)
                {
                    verticalAnchor = value;
                    this.RaisePropertyChanged(nameof(this.VerticalAnchor));
                }
            }
        }

        public double ControlSize
        {
            get
            {
                return controlSize;
            }
            set
            {
                if (controlSize != value)
                {
                    controlSize = value;
                    this.RaisePropertyChanged(nameof(this.ControlSize));
                }
            }
        }

        public double HorizontalPosition
        {
            get
            {
                return horizontalPosition;
            }
            set
            {
                if (horizontalPosition != value)
                {
                    horizontalPosition = value;
                    this.RaisePropertyChanged(nameof(this.HorizontalPosition));
                }
            }
        }

        public double VerticalPosition
        {
            get
            {
                return verticalPosition;
            }
            set
            {
                if (verticalPosition != value)
                {
                    verticalPosition = value;
                    this.RaisePropertyChanged(nameof(this.VerticalPosition));
                }
            }
        }

        public double HorizontalAnchorPosition
        {
            get
            {
                return horizontalAnchorPosition;
            }
            set
            {
                if (horizontalAnchorPosition != value)
                {
                    horizontalAnchorPosition = value;
                    this.RaisePropertyChanged(nameof(this.HorizontalAnchorPosition));
                }
            }
        }

        public double VerticalAnchorPosition
        {
            get
            {
                return verticalAnchorPosition;
            }
            set
            {
                if (verticalAnchorPosition != value)
                {
                    verticalAnchorPosition = value;
                    this.RaisePropertyChanged(nameof(this.VerticalAnchorPosition));
                }
            }
        }

        public double Content
        {
            get
            {
                return content;
            }
            set
            {
                if (content != value)
                {
                    content = value;
                    this.RaisePropertyChanged(nameof(this.Content));
                }
            }
        }
    }
}
