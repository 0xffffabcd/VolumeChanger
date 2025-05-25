using NAudio.CoreAudioApi;
using NAudio.CoreAudioApi.Interfaces;

namespace VolumeChanger
{
    public partial class MainForm : Form, IMMNotificationClient
    {
        private readonly MMDeviceEnumerator Enumerator;
        private float WantedVolume;
        private const string AppName = "VolumeChanger"; // Application name for registry

        public MainForm()
        {
            InitializeComponent();
            Enumerator = new MMDeviceEnumerator();
            Enumerator.RegisterEndpointNotificationCallback(this);
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            try
            {
                LoadSettings();
                EnumerateInputDevices();
                UpdateWantedVolumeFromNud();
                SetVolumeAdjustmentActive(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred on startup: {ex.Message}", "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSettings()
        {
            StartWithWindows_toolStripMenuItem.Checked = Properties.Settings.Default.StartWithWindows;
            wantedVolumeNud.Value = Properties.Settings.Default.WantedVolume;
            UpdateFrequencyNud.Value = Properties.Settings.Default.UpdateFrequency;
            StartWithWindows_Checkbox.Checked = Properties.Settings.Default.StartWithWindows;

            Utils.SetStartupRegistry(StartWithWindows_toolStripMenuItem.Checked, AppName);
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.UpdateFrequency = (int)UpdateFrequencyNud.Value;
            Properties.Settings.Default.WantedVolume = (int)wantedVolumeNud.Value;
            Properties.Settings.Default.StartWithWindows = StartWithWindows_Checkbox.Checked;
            Properties.Settings.Default.Save();

            Utils.SetStartupRegistry(StartWithWindows_Checkbox.Checked, AppName);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveSettings();

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
            else
            {
                // If closing for reasons other than user action (e.g., Application.Exit()),
                // ensure the timer is stopped and the icon is hidden.
                UpdateTimer?.Stop();
                if (notifyIcon1 != null) notifyIcon1.Visible = false;
                base.OnFormClosing(e);
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            ChangeMicrophoneVolume();
        }

        private void SwitchUpdate_Click(object sender, EventArgs e)
        {
            if (DevicesComboBox.SelectedItem is null || DevicesComboBox.SelectedItem.ToString() == "No microphones found")
            {
                MessageBox.Show("Please select a valid microphone device first.", "No Device Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SetVolumeAdjustmentActive(!UpdateTimer.Enabled); // Toggle the current state
        }

        private void UpdateFrequencyNud_ValueChanged(object sender, EventArgs e)
        {
            UpdateTimer.Interval = Math.Max(10, (int)UpdateFrequencyNud.Value); // Minimum interval 10ms
        }

        private void WantedVolumeNud_ValueChanged(object sender, EventArgs e)
        {
            UpdateWantedVolumeFromNud();
        }

        #region tray icon menu
        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RestoreApplicationWindow();
        }

        private void OpenWindow_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreApplicationWindow();
        }

        private void Exit_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Enumerator?.UnregisterEndpointNotificationCallback(this);
                Enumerator?.Dispose();
                components?.Dispose(); // Dispose IContainer components if it exists
            }
            base.Dispose(disposing);
        }

        #region IMMNotificationClient
        public void OnDeviceStateChanged(string deviceId, DeviceState newState)
        {
            // Refresh if a device is unplugged, not present, or becomes active
            if (newState == DeviceState.Unplugged || newState == DeviceState.NotPresent || newState == DeviceState.Active)
            {
                SafeUpdateUI(EnumerateInputDevices);
            }
        }

        public void OnDeviceAdded(string pwstrDeviceId)
        {
            SafeUpdateUI(EnumerateInputDevices);
        }
        
        public void OnDeviceRemoved(string deviceId)
        {
            SafeUpdateUI(EnumerateInputDevices);
        }
        
        public void OnDefaultDeviceChanged(DataFlow flow, Role role, string defaultDeviceId)
        {
            if (flow == DataFlow.Capture) 
            {
                SafeUpdateUI(EnumerateInputDevices);
            }
        }
        
        public void OnPropertyValueChanged(string pwstrDeviceId, PropertyKey key) {  }
        #endregion

        private void EnumerateInputDevices()
        {
            MMDevice previouslySelectedDevice = DevicesComboBox.SelectedItem as MMDevice;
            string previouslySelectedDeviceId = previouslySelectedDevice?.ID;

            DevicesComboBox.Items.Clear();
            SetVolumeAdjustmentActive(false); // Ensure timer is stopped and UI is reset

            var devices = Enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            if (devices.Count == 0)
            {
                DisableControlsForNoDevice();
                return;
            }

            foreach (var device in devices)
            {
                DevicesComboBox.Items.Add(device);
            }

            EnableControlsAfterDeviceEnumeration();

            bool deviceReselected = false;
            if (!string.IsNullOrEmpty(previouslySelectedDeviceId))
            {
                for (int i = 0; i < DevicesComboBox.Items.Count; i++)
                {
                    if ((DevicesComboBox.Items[i] as MMDevice)?.ID == previouslySelectedDeviceId)
                    {
                        DevicesComboBox.SelectedIndex = i;
                        deviceReselected = true;
                        break;
                    }
                }
            }

            if (!deviceReselected && DevicesComboBox.Items.Count > 0)
            {
                DevicesComboBox.SelectedIndex = 0;
            }
            else if (DevicesComboBox.Items.Count == 0)
            {
                DisableControlsForNoDevice(); // Should be caught earlier, but as a safeguard
            }
        }

        private void DisableControlsForNoDevice()
        {
            SwitchButton.Enabled = false;
            wantedVolumeNud.Enabled = false;
            UpdateFrequencyNud.Enabled = false;
            DevicesComboBox.Enabled = false;
            if (DevicesComboBox.Items.Count == 0)
            {
                DevicesComboBox.Items.Add("No microphones found");
                DevicesComboBox.SelectedIndex = 0;
            }
        }

        private void EnableControlsAfterDeviceEnumeration()
        {
            SwitchButton.Enabled = true;
            wantedVolumeNud.Enabled = true;
            UpdateFrequencyNud.Enabled = true;
            DevicesComboBox.Enabled = true;
        }

        private void ChangeMicrophoneVolume()
        {
            if (DevicesComboBox.SelectedItem is not MMDevice selectedDevice || selectedDevice.State != DeviceState.Active)
            {
                // If device is no longer active or not selected, try to re-enumerate.
                SafeUpdateUI(EnumerateInputDevices);
                return;
            }

            if (Math.Abs(selectedDevice.AudioEndpointVolume.MasterVolumeLevelScalar - WantedVolume) > 0.001f)
            {
                selectedDevice.AudioEndpointVolume.MasterVolumeLevelScalar = WantedVolume;
            }
        }

        // Renamed from Switch for clarity. Parameter 'active' indicates the desired state.
        private void SetVolumeAdjustmentActive(bool active)
        {
            if (active) // True: Start or keep running
            {
                UpdateTimer.Start();
                SwitchButton.Text = "Stop Changing Volume";
                DevicesComboBox.Enabled = false;
            }
            else // False: Stop or keep stopped
            {
                UpdateTimer.Stop();
                SwitchButton.Text = "Start Changing Volume";
                // Only enable ComboBox if there are actual devices and it's not showing the "No microphones found" placeholder
                DevicesComboBox.Enabled = DevicesComboBox.Items.Count > 0 && (DevicesComboBox.Items.Count > 0 && !(DevicesComboBox.Items[0] is string s && s == "No microphones found"));
            }
        }

        private void UpdateWantedVolumeFromNud()
        {
            WantedVolume = (float)(wantedVolumeNud.Value / 100m);
        }

        private void RestoreApplicationWindow()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            this.Activate();
            this.BringToFront();
        }

        private void SafeUpdateUI(Action action)
        {
            // Check if the handle is created and the form is not disposed or disposing
            if (this.IsHandleCreated && !this.IsDisposed && !this.Disposing)
            {
                if (InvokeRequired)
                {
                    try
                    {
                        // Using BeginInvoke for asynchronous update, which is generally safer
                        // if the UI update isn't critically time-sensitive for subsequent logic.
                        BeginInvoke(action);
                    }
                    // Catch specific exceptions that might occur if the form is in the process of closing
                    catch (ObjectDisposedException) { /* Form or control might have been disposed between checks */ }
                    catch (InvalidOperationException) { /* Handle might not be valid (e.g., during shutdown) */ }
                }
                else
                {
                    action();
                }
            }
        }

        private void StartWithWindowsMenuItem_Click(object sender, EventArgs e)
        {
            // update strip menu
            StartWithWindows_Checkbox.Checked = !StartWithWindows_toolStripMenuItem.Checked;

            SaveSettings();
        }

        private void StartWithWindows_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            // update strip menu
            StartWithWindows_toolStripMenuItem.Checked = StartWithWindows_Checkbox.Checked;

            SaveSettings();
        }
    }
}
