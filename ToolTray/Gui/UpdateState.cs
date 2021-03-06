﻿using System;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ToolTray.Resources;

namespace ToolTray
{
    public enum UpdateState
    {
        Searching,
        UpdatesAvailable,
        NoUpdatesAvailable,
        UpdatesInstalled,
        Failure
    }

    public static class UpdateStateExtensions
    {
        public static bool CanApplicationBeClosed(this UpdateState state, int failureCount)
        {
            switch (state)
            {
                case UpdateState.Failure:
                    return failureCount >= 10;
                case UpdateState.Searching:
                case UpdateState.UpdatesAvailable:
                    return false;
                default:
                    return true;
            }
        }
        
        public static Icon GetIcon(this UpdateState state)
        {
            switch (state)
            {
                case UpdateState.Searching:
                    return ImageResources.WindowsUpdateSearching1;
                case UpdateState.UpdatesAvailable:
                    return ImageResources.WindowsUpdate;
                case UpdateState.Failure:
                    return ImageResources.WindowsUpdateNoConnection;
                default:
                    return ImageResources.WindowsUpdateNothing;
            }
        }

        public static Icon GetPopupIcon(this UpdateState state)
        {
            switch (state)
            {
                case UpdateState.UpdatesAvailable:
                    return ImageResources.ShieldYellow;
                default:
                    return ImageResources.ShieldGreen;
            }
        }

        public static ImageSource GetPopupImage(this UpdateState state)
        {
            switch (state)
            {
                case UpdateState.UpdatesAvailable:
                    return _GetUpdateIcon();
                default:
                    return _GetShieldIcon();
            }
        }

        private static ImageSource sShieldIcon;

        private static ImageSource sUpdateIcon;

        private static ImageSource _GetUpdateIcon()
        {
            if (sUpdateIcon == null)
            {
                sUpdateIcon = new BitmapImage(new Uri(@"pack://application:,,,/Resources/Images/Update.png", UriKind.RelativeOrAbsolute));
                sUpdateIcon.Freeze();
            }
            
            return sUpdateIcon;
        }

        private static ImageSource _GetShieldIcon()
        {
            if (sShieldIcon == null)
            {
                sShieldIcon = new BitmapImage(new Uri(@"pack://application:,,,/Resources/Images/SecurityShieldGreen.png", UriKind.RelativeOrAbsolute));
                sShieldIcon.Freeze();
            }

            return sShieldIcon;
        }
    }
}