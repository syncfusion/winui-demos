#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI;

namespace Syncfusion.AvatarViewDemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GettingStartedView : Page
    {
        public GettingStartedView()
        {
            this.InitializeComponent();
        }

        private void InitialTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (initialTypeComboBox.SelectedIndex)
            {
                case 0:
                    avatarView.InitialsType = AvatarInitialsType.SingleCharacter;
                    break;
                case 1:
                    avatarView.InitialsType = AvatarInitialsType.DoubleCharacter;
                    break;
            }
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            avatarView.AvatarName = firstNameTextBox.Text.Replace(" ", string.Empty).Trim() + " " + lastNameTextBox.Text.Trim();
        }

        private void AvatarBackgroundcolor_ColorChanged(ColorPicker sender, ColorChangedEventArgs args)
        {
            avatarView.Background = new SolidColorBrush(avatarBackgroundcolor.Color);
        }

        private void ContentTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (contentTypeComboBox.SelectedIndex)
            {
                case 0:
                    avatarView.ContentType = AvatarContentType.Initials;
                    firstNameTextBlock.Visibility = Visibility.Visible;
                    firstNameTextBox.Visibility = Visibility.Visible;
                    lastNameTextBlock.Visibility = Visibility.Visible;
                    lastNameTextBox.Visibility = Visibility.Visible;
                    initialTypeTextBlock.Visibility = Visibility.Visible;
                    initialTypeComboBox.Visibility = Visibility.Visible;
                    if (colorTextBlock != null && colorPickerViewBox != null)
                    {
                        colorTextBlock.Visibility = Visibility.Visible;
                        colorPickerViewBox.Visibility = Visibility.Visible;
                        avatarCharactersTextBlock.Visibility = Visibility.Collapsed;
                        avatarCharactersComboBox.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 1:
                    avatarView.ContentType = AvatarContentType.CustomImage;
                    firstNameTextBlock.Visibility = Visibility.Collapsed;
                    firstNameTextBox.Visibility = Visibility.Collapsed;
                    lastNameTextBlock.Visibility = Visibility.Collapsed;
                    lastNameTextBox.Visibility = Visibility.Collapsed;
                    initialTypeTextBlock.Visibility = Visibility.Collapsed;
                    initialTypeComboBox.Visibility = Visibility.Collapsed;
                    colorTextBlock.Visibility = Visibility.Collapsed;
                    colorPickerViewBox.Visibility = Visibility.Collapsed;
                    avatarCharactersTextBlock.Visibility = Visibility.Collapsed;
                    avatarCharactersComboBox.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    avatarView.ContentType = AvatarContentType.AvatarCharacter;
                    avatarView.AvatarCharacter = AvatarCharacter.Avatar1;
                    firstNameTextBlock.Visibility = Visibility.Collapsed;
                    firstNameTextBox.Visibility = Visibility.Collapsed;
                    lastNameTextBlock.Visibility = Visibility.Collapsed;
                    lastNameTextBox.Visibility = Visibility.Collapsed;
                    initialTypeTextBlock.Visibility = Visibility.Collapsed;
                    initialTypeComboBox.Visibility = Visibility.Collapsed;
                    colorTextBlock.Visibility = Visibility.Collapsed;
                    colorPickerViewBox.Visibility = Visibility.Collapsed;
                    avatarCharactersTextBlock.Visibility = Visibility.Visible;
                    avatarCharactersComboBox.Visibility = Visibility.Visible;
                    avatarCharactersComboBox.SelectedIndex = 0;
                    break;
            }
        }

        private void AvatarShapeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (avatarShapeComboBox.SelectedIndex)
            {
                case 0:
                    if (avatarSizeComboBox != null && avatarSizeTextBlock != null)
                    {
                        avatarSizeComboBox.Visibility = Visibility.Visible;
                        avatarSizeTextBlock.Visibility = Visibility.Visible;
                        customSizeSlider.Visibility = Visibility.Collapsed;
                        badge.HorizontalPosition = 0.83;
                        badge.VerticalPosition = 0.85;
                        UpdateAvatarViewSize();
                    }
                    avatarView.AvatarShape = AvatarShape.Circle;
                    break;
                case 1:
                    avatarView.AvatarShape = AvatarShape.Square;
                    customSizeSlider.Visibility = Visibility.Collapsed;
                    avatarSizeComboBox.Visibility = Visibility.Visible;
                    avatarSizeTextBlock.Visibility = Visibility.Visible;
                    badge.HorizontalPosition = 0.90;
                    badge.VerticalPosition = 0.90;
                    UpdateAvatarViewSize();
                    break;
                case 2:
                    avatarView.AvatarShape = AvatarShape.Custom;
                    avatarSizeComboBox.Visibility = Visibility.Collapsed;
                    avatarSizeTextBlock.Visibility = Visibility.Collapsed;
                    customSizeSlider.Visibility = Visibility.Visible;
                    avatarView.Height = customSizeSlider.Value;
                    avatarView.Width = customSizeSlider.Value;
                    badge.HorizontalPosition =0.90;
                    badge.VerticalPosition = 0.90;
                    badgeViewBox.Height = customSizeSlider.Value / 3.2;
                    badgeViewBox.Width = customSizeSlider.Value / 3.2;
                    break;
            }
        }

        private void UpdateAvatarViewSize()
        {
            switch (avatarSizeComboBox.SelectedIndex)
            {
                case 0:
                    avatarView.AvatarSize = AvatarSize.ExtraLarge;
                    badgeViewBox.Height = 31;
                    badgeViewBox.Width = 31;
                    break;
                case 1:
                    avatarView.AvatarSize = AvatarSize.Large;
                    badgeViewBox.Height = 19;
                    badgeViewBox.Width = 19;
                    break;
                case 2:
                    avatarView.AvatarSize = AvatarSize.Medium;
                    badgeViewBox.Height = 16;
                    badgeViewBox.Width = 16;
                    break;
                case 3:
                    avatarView.AvatarSize = AvatarSize.Small;
                    badgeViewBox.Height = 14;
                    badgeViewBox.Width = 14;
                    break;
                case 4:
                    avatarView.AvatarSize = AvatarSize.ExtraSmall;
                    badgeViewBox.Height = 11;
                    badgeViewBox.Width = 11;
                    break;
            }
        }

        private void AvatarSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAvatarViewSize();
        }

        private void CustomSizeSlider_Changed(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (avatarShapeComboBox.SelectedIndex == 2)
            {
                avatarView.Width = customSizeSlider.Value;
                avatarView.Height = customSizeSlider.Value;
                badgeViewBox.Height = customSizeSlider.Value / 3.2;
                badgeViewBox.Width = customSizeSlider.Value / 3.2;
            }
        }

        private void AvatarCharactersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (avatarCharactersComboBox.SelectedIndex)
            {
                case 0:
                    avatarView.AvatarCharacter = AvatarCharacter.Avatar1;
                    break;
                case 1:
                    avatarView.AvatarCharacter = AvatarCharacter.Avatar2;
                    break;
                case 2:
                    avatarView.AvatarCharacter = AvatarCharacter.Avatar3;
                    break;
                case 3:
                    avatarView.AvatarCharacter = AvatarCharacter.Avatar4;
                    break;
                case 4:
                    avatarView.AvatarCharacter = AvatarCharacter.Avatar5;
                    break;
                case 5:
                    avatarView.AvatarCharacter = AvatarCharacter.Avatar6;
                    break;
                case 6:
                    avatarView.AvatarCharacter = AvatarCharacter.Avatar7;
                    break;
                case 7:
                    avatarView.AvatarCharacter = AvatarCharacter.Avatar8;
                    break;
                case 8:
                    avatarView.AvatarCharacter = AvatarCharacter.Avatar9;
                    break;
                case 9:
                    avatarView.AvatarCharacter = AvatarCharacter.Avatar10;
                    break;
            }
        }
    }
}
