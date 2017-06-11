namespace ToolTray
{
    public static class StartupHelper
    {
        public static void UpdateStartupSettings(bool isSetAsAutoStartup)
        {
            if (isSetAsAutoStartup)
                _AddToAutostart();
            else
                _RemoveFromAutostart();
        }


        public static bool IsSetAsAutoStartup()
        {
            return ShortcutHelper.IsSetAsAutoStartup();
        }

        private static void _AddToAutostart()
        {
            if (UacHelper.IsRunningAsAdmin())
            {
                ShortcutHelper.DeleteStartupShortcut();
            }
            else
            {
                ShortcutHelper.CreateStartupShortcut();
            }
        }

        private static void _RemoveFromAutostart()
        {
            // remove shortcut if needed
            ShortcutHelper.DeleteStartupShortcut();
        }
    }
}