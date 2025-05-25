using Microsoft.Win32;
using System.Reflection;

namespace VolumeChanger
{
    internal static class Utils
    {
        /// <summary>
        ///Sets or removes the application from the Windows startup registry.
        /// </summary>
        /// <param name="enable"></param>
        public static void SetStartupRegistry(bool enable, string appName)
        {
            try
            {
                // Using CurrentUser, so no admin rights needed.
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (rk == null)
                {
                    // This should ideally not happen, but handle it just in case.
                    MessageBox.Show("Could not open registry key for startup configuration.", "Registry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string exePath = Assembly.GetExecutingAssembly().Location;
                // For .NET Core/5+ single-file published apps, Location might point to a temp directory.
                // If using single-file deployment, consider Environment.ProcessPath or other means to get the persistent path.
                // For standard deployments, Assembly.GetExecutingAssembly().Location is usually correct.

                if (enable)
                {
                    rk.SetValue(appName, $"\"{exePath}\""); // Use quotes for paths with spaces
                }
                else
                {
                    rk.DeleteValue(appName, false); // false to not throw an exception if the value doesn't exist
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error modifying startup registry: {ex.Message}", "Registry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
