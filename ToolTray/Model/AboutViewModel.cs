using System;
using System.Diagnostics;
using System.Windows.Input;
using ToolTray.Resources;

namespace ToolTray
{
    public class AboutViewModel
    {
        public AboutViewModel()
        {
        }
         

        private void _OpenHomepage()
        {
            Process.Start(HomepageLink);
        }

        public ICommand OpenUpdatePageCommand { get; set; }

        public ICommand OpenHomepageCommand { get; set; }
        
        public string VersionLabel { get; set; }

        public string NewVersionLabel { get; set; }
        
        public bool IsNewVersionAvailable { get; set; }

        public bool IsLatestVersion { get; set; }

        public string CopyrightLabel { get; set; }

        public string HomepageLink { get; set; }
    }
}