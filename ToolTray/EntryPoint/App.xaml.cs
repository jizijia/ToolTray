using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ToolTray
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : ISingleInstance
    {
        private ApplicationRuntime mApplicationRuntime;

        protected override void OnStartup(StartupEventArgs e)
        {
            // ensure that only a single instance of the application is started
            // the app is clossed if another instance is already running
            SingleInstanceHelper.MakeSingleInstance("WindowsUpdateNotifier", this);

            var cmdHelper = new CommandLineHelper();

            AppSettings.Initialize(cmdHelper.UseDefaultSettings);
            mApplicationRuntime = new ApplicationRuntime(cmdHelper.CloseAfterCheck);
            mApplicationRuntime.Start();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            mApplicationRuntime.Dispose();
        }

        public void OnNewInstanceStarted()
        {
            //Dispatcher.BeginInvoke((Action)(() => mApplicationRuntime.OpenSettings()), null);
        }
    }
}
