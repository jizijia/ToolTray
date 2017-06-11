using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;
using ToolTray.Resources;

namespace ToolTray
{
    public class ApplicationRuntime : IApplication, IDisposable
    {
        private readonly bool mCloseAfterCheck;
        private readonly SystemTrayIcon mTrayIcon;
        private readonly DispatcherTimer mTimer;

        private int mFailureCount;

        public ApplicationRuntime(bool closeAfterCheck)
        {
            UiThreadHelper.InitializeWithCurrentDispatcher();

            mCloseAfterCheck = closeAfterCheck;

            mTrayIcon = new SystemTrayIcon(this);
            mTimer = new DispatcherTimer();
        }

        public void Start()
        {
        }

        
        public void Dispose()
        {
            mTimer.Stop();
            mTrayIcon.Dispose();
        }

        public void OpenWindowsUpdateControlPanel()
        {
            Process.Start("control.exe", "/name Microsoft.WindowsUpdate");
        }

        public void OpenDownloadPage()
        {
            Process.Start("http://wun.codeplex.com/releases");
        }                
          
        private void _ShowPopup(string title, string message, UpdateState state)
        {
            if (AppSettings.Instance.DisableNotifications)
                return;

            if (AppSettings.Instance.UseMetroStyle)
            {
                //var popup = new PopupView();
                //popup.DataContext = new PopupViewModel(title, message, state, popup.Close, OpenWindowsUpdateControlPanel);
                //popup.Show();

                //if (mSettingsView != null)
                //    mSettingsView.Focus();
            }
            else
            {
                mTrayIcon.ShowBallonTip(title, message, state);
            }
        }
    }
}