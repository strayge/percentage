using TrayIconLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CpuIcon
{
    public partial class SettingsForm : Form
    {
        CustomSettings settings;

        public SettingsForm()
        {
            InitializeComponent();

            // load settings
            // cpu
            settings = CustomSettings.Instance;
            cpuForegroundText.Text = Utils.ColorToString(settings.foregroundColor);
            cpuForegroundOpacity.Value = settings.foregroundColor.A;
            cpuForegroundThrottlingText.Text = Utils.ColorToString(settings.foregroundThrottlingColor);
            cpuForegroundThrottlingOpacity.Value = settings.foregroundThrottlingColor.A;
            cpuBackgroundText.Text = Utils.ColorToString(settings.backgroundColor);
            cpuBackgroundOpacity.Value = settings.backgroundColor.A;
            cpuBorderText.Text = Utils.ColorToString(settings.borderColor);
            cpuBorderOpacity.Value = settings.borderColor.A;
            cpuInterval.Value = settings.updateInterval;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // cpu
            settings.foregroundColor = Utils.ColorFromString(cpuForegroundText.Text);
            settings.foregroundThrottlingColor = Utils.ColorFromString(cpuForegroundThrottlingText.Text);
            settings.backgroundColor = Utils.ColorFromString(cpuBackgroundText.Text);
            settings.borderColor = Utils.ColorFromString(cpuBorderText.Text);
            settings.updateInterval = (int)cpuInterval.Value;

            Close();
        }

        // cpu
        private void cpuForegroundButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Utils.ColorFromString(cpuForegroundText.Text);
            colorDialog.ShowDialog();
            Color color = Color.FromArgb(cpuForegroundOpacity.Value, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            cpuForegroundText.Text = Utils.ColorToString(color);
        }

        private void cpuForegroundThrottlingButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Utils.ColorFromString(cpuForegroundThrottlingText.Text);
            colorDialog.ShowDialog();
            Color color = Color.FromArgb(cpuForegroundThrottlingOpacity.Value, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            cpuForegroundThrottlingText.Text = Utils.ColorToString(color);
        }

        private void cpuBackgroundButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Utils.ColorFromString(cpuBackgroundText.Text);
            colorDialog.ShowDialog();
            Color color = Color.FromArgb(cpuBackgroundOpacity.Value, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            cpuBackgroundText.Text = Utils.ColorToString(color);
        }

        private void cpuBorderButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Utils.ColorFromString(cpuBorderText.Text);
            colorDialog.ShowDialog();
            Color color = Color.FromArgb(cpuBorderOpacity.Value, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            cpuBorderText.Text = Utils.ColorToString(color);
        }

        private void cpuForegroundOpacity_Scroll(object sender, EventArgs e)
        {
            Color color = Utils.ColorFromString(cpuForegroundText.Text);
            Color color2 = Color.FromArgb(cpuForegroundOpacity.Value, color.R, color.G, color.B);
            cpuForegroundText.Text = Utils.ColorToString(color2);
        }

        private void cpuForegroundThrottlingOpacity_Scroll(object sender, EventArgs e)
        {
            Color color = Utils.ColorFromString(cpuForegroundThrottlingText.Text);
            Color color2 = Color.FromArgb(cpuForegroundThrottlingOpacity.Value, color.R, color.G, color.B);
            cpuForegroundThrottlingText.Text = Utils.ColorToString(color2);
        }

        private void cpuBackgroundOpacity_Scroll(object sender, EventArgs e)
        {
            Color color = Utils.ColorFromString(cpuBackgroundText.Text);
            Color color2 = Color.FromArgb(cpuBackgroundOpacity.Value, color.R, color.G, color.B);
            cpuBackgroundText.Text = Utils.ColorToString(color2);
        }

        private void cpuBorderOpacity_Scroll(object sender, EventArgs e)
        {
            Color color = Utils.ColorFromString(cpuBorderText.Text);
            Color color2 = Color.FromArgb(cpuBorderOpacity.Value, color.R, color.G, color.B);
            cpuBorderText.Text = Utils.ColorToString(color2);
        }

    }
}
