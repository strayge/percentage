namespace NetIcon
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.batteryFontDialog = new System.Windows.Forms.FontDialog();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel21 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.networkMaxBandwidth = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.label31 = new System.Windows.Forms.Label();
            this.networkInterval = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.networkBorderText = new System.Windows.Forms.TextBox();
            this.networkBorderButton = new System.Windows.Forms.Button();
            this.networkBorderOpacity = new System.Windows.Forms.TrackBar();
            this.label29 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.label35 = new System.Windows.Forms.Label();
            this.networkBackgroundText = new System.Windows.Forms.TextBox();
            this.networkBackgroundButton = new System.Windows.Forms.Button();
            this.networkBackgroundOpacity = new System.Windows.Forms.TrackBar();
            this.label33 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label36 = new System.Windows.Forms.Label();
            this.networkForegroundText = new System.Windows.Forms.TextBox();
            this.networkForegroundButton = new System.Windows.Forms.Button();
            this.networkForegroundOpacity = new System.Windows.Forms.TrackBar();
            this.label34 = new System.Windows.Forms.Label();
            this.panel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.networkMaxBandwidth)).BeginInit();
            this.panel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.networkInterval)).BeginInit();
            this.panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.networkBorderOpacity)).BeginInit();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.networkBackgroundOpacity)).BeginInit();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.networkForegroundOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.FullOpen = true;
            // 
            // batteryFontDialog
            // 
            this.batteryFontDialog.AllowScriptChange = false;
            this.batteryFontDialog.ShowEffects = false;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(604, 299);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(182, 51);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(413, 299);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(182, 51);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.label24);
            this.panel21.Controls.Add(this.networkMaxBandwidth);
            this.panel21.Controls.Add(this.label32);
            this.panel21.Location = new System.Drawing.Point(-4, 233);
            this.panel21.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(788, 56);
            this.panel21.TabIndex = 104;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(9, 14);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(157, 30);
            this.label24.TabIndex = 39;
            this.label24.Text = "Max bandwidth";
            // 
            // networkMaxBandwidth
            // 
            this.networkMaxBandwidth.Location = new System.Drawing.Point(172, 7);
            this.networkMaxBandwidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.networkMaxBandwidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.networkMaxBandwidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.networkMaxBandwidth.Name = "networkMaxBandwidth";
            this.networkMaxBandwidth.Size = new System.Drawing.Size(168, 35);
            this.networkMaxBandwidth.TabIndex = 38;
            this.networkMaxBandwidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(346, 14);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(82, 30);
            this.label32.TabIndex = 45;
            this.label32.Text = "Mbits/s";
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.label31);
            this.panel20.Controls.Add(this.networkInterval);
            this.panel20.Controls.Add(this.label28);
            this.panel20.Location = new System.Drawing.Point(-4, 177);
            this.panel20.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(788, 56);
            this.panel20.TabIndex = 103;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(9, 14);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(154, 30);
            this.label31.TabIndex = 82;
            this.label31.Text = "Update interval";
            // 
            // networkInterval
            // 
            this.networkInterval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.networkInterval.Location = new System.Drawing.Point(172, 7);
            this.networkInterval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.networkInterval.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.networkInterval.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.networkInterval.Name = "networkInterval";
            this.networkInterval.Size = new System.Drawing.Size(114, 35);
            this.networkInterval.TabIndex = 81;
            this.networkInterval.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(289, 14);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(40, 30);
            this.label28.TabIndex = 89;
            this.label28.Text = "ms";
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.label30);
            this.panel19.Controls.Add(this.networkBorderText);
            this.panel19.Controls.Add(this.networkBorderButton);
            this.panel19.Controls.Add(this.networkBorderOpacity);
            this.panel19.Controls.Add(this.label29);
            this.panel19.Location = new System.Drawing.Point(-4, 121);
            this.panel19.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(788, 56);
            this.panel19.TabIndex = 102;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(9, 14);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(74, 30);
            this.label30.TabIndex = 84;
            this.label30.Text = "Border";
            // 
            // networkBorderText
            // 
            this.networkBorderText.Location = new System.Drawing.Point(172, 7);
            this.networkBorderText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.networkBorderText.Name = "networkBorderText";
            this.networkBorderText.Size = new System.Drawing.Size(162, 35);
            this.networkBorderText.TabIndex = 83;
            // 
            // networkBorderButton
            // 
            this.networkBorderButton.Location = new System.Drawing.Point(352, 5);
            this.networkBorderButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.networkBorderButton.Name = "networkBorderButton";
            this.networkBorderButton.Size = new System.Drawing.Size(86, 44);
            this.networkBorderButton.TabIndex = 85;
            this.networkBorderButton.Text = "Color";
            this.networkBorderButton.UseVisualStyleBackColor = true;
            this.networkBorderButton.Click += new System.EventHandler(this.networkBorderButton_Click);
            // 
            // networkBorderOpacity
            // 
            this.networkBorderOpacity.AutoSize = false;
            this.networkBorderOpacity.Location = new System.Drawing.Point(551, 10);
            this.networkBorderOpacity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.networkBorderOpacity.Maximum = 255;
            this.networkBorderOpacity.Name = "networkBorderOpacity";
            this.networkBorderOpacity.Size = new System.Drawing.Size(231, 32);
            this.networkBorderOpacity.TabIndex = 86;
            this.networkBorderOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.networkBorderOpacity.Scroll += new System.EventHandler(this.networkBorderOpacity_Scroll);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(462, 14);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(84, 30);
            this.label29.TabIndex = 87;
            this.label29.Text = "Opacity";
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.label35);
            this.panel18.Controls.Add(this.networkBackgroundText);
            this.panel18.Controls.Add(this.networkBackgroundButton);
            this.panel18.Controls.Add(this.networkBackgroundOpacity);
            this.panel18.Controls.Add(this.label33);
            this.panel18.Location = new System.Drawing.Point(-4, 65);
            this.panel18.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(788, 56);
            this.panel18.TabIndex = 101;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(9, 14);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(123, 30);
            this.label35.TabIndex = 74;
            this.label35.Text = "Background";
            // 
            // networkBackgroundText
            // 
            this.networkBackgroundText.Location = new System.Drawing.Point(172, 7);
            this.networkBackgroundText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.networkBackgroundText.Name = "networkBackgroundText";
            this.networkBackgroundText.Size = new System.Drawing.Size(162, 35);
            this.networkBackgroundText.TabIndex = 73;
            // 
            // networkBackgroundButton
            // 
            this.networkBackgroundButton.Location = new System.Drawing.Point(352, 5);
            this.networkBackgroundButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.networkBackgroundButton.Name = "networkBackgroundButton";
            this.networkBackgroundButton.Size = new System.Drawing.Size(86, 44);
            this.networkBackgroundButton.TabIndex = 76;
            this.networkBackgroundButton.Text = "Color";
            this.networkBackgroundButton.UseVisualStyleBackColor = true;
            this.networkBackgroundButton.Click += new System.EventHandler(this.networkBackgroundButton_Click);
            // 
            // networkBackgroundOpacity
            // 
            this.networkBackgroundOpacity.AutoSize = false;
            this.networkBackgroundOpacity.Location = new System.Drawing.Point(551, 10);
            this.networkBackgroundOpacity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.networkBackgroundOpacity.Maximum = 255;
            this.networkBackgroundOpacity.Name = "networkBackgroundOpacity";
            this.networkBackgroundOpacity.Size = new System.Drawing.Size(231, 32);
            this.networkBackgroundOpacity.TabIndex = 78;
            this.networkBackgroundOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.networkBackgroundOpacity.Scroll += new System.EventHandler(this.networkBackgroundOpacity_Scroll);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(462, 14);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(84, 30);
            this.label33.TabIndex = 80;
            this.label33.Text = "Opacity";
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.label36);
            this.panel17.Controls.Add(this.networkForegroundText);
            this.panel17.Controls.Add(this.networkForegroundButton);
            this.panel17.Controls.Add(this.networkForegroundOpacity);
            this.panel17.Controls.Add(this.label34);
            this.panel17.Location = new System.Drawing.Point(-4, 9);
            this.panel17.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(788, 56);
            this.panel17.TabIndex = 100;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(9, 14);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(120, 30);
            this.label36.TabIndex = 72;
            this.label36.Text = "Foreground";
            // 
            // networkForegroundText
            // 
            this.networkForegroundText.Location = new System.Drawing.Point(172, 7);
            this.networkForegroundText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.networkForegroundText.Name = "networkForegroundText";
            this.networkForegroundText.Size = new System.Drawing.Size(162, 35);
            this.networkForegroundText.TabIndex = 71;
            // 
            // networkForegroundButton
            // 
            this.networkForegroundButton.Location = new System.Drawing.Point(352, 5);
            this.networkForegroundButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.networkForegroundButton.Name = "networkForegroundButton";
            this.networkForegroundButton.Size = new System.Drawing.Size(86, 44);
            this.networkForegroundButton.TabIndex = 75;
            this.networkForegroundButton.Text = "Color";
            this.networkForegroundButton.UseVisualStyleBackColor = true;
            this.networkForegroundButton.Click += new System.EventHandler(this.networkForegroundButton_Click);
            // 
            // networkForegroundOpacity
            // 
            this.networkForegroundOpacity.AutoSize = false;
            this.networkForegroundOpacity.Location = new System.Drawing.Point(551, 10);
            this.networkForegroundOpacity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.networkForegroundOpacity.Maximum = 255;
            this.networkForegroundOpacity.Name = "networkForegroundOpacity";
            this.networkForegroundOpacity.Size = new System.Drawing.Size(231, 32);
            this.networkForegroundOpacity.TabIndex = 77;
            this.networkForegroundOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.networkForegroundOpacity.Scroll += new System.EventHandler(this.networkForegroundOpacity_Scroll);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(462, 14);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(84, 30);
            this.label34.TabIndex = 79;
            this.label34.Text = "Opacity";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(791, 357);
            this.Controls.Add(this.panel21);
            this.Controls.Add(this.panel20);
            this.Controls.Add(this.panel19);
            this.Controls.Add(this.panel18);
            this.Controls.Add(this.panel17);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "NetIcon Settings";
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.networkMaxBandwidth)).EndInit();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.networkInterval)).EndInit();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.networkBorderOpacity)).EndInit();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.networkBackgroundOpacity)).EndInit();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.networkForegroundOpacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.FontDialog batteryFontDialog;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown networkMaxBandwidth;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.NumericUpDown networkInterval;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox networkBorderText;
        private System.Windows.Forms.Button networkBorderButton;
        private System.Windows.Forms.TrackBar networkBorderOpacity;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox networkBackgroundText;
        private System.Windows.Forms.Button networkBackgroundButton;
        private System.Windows.Forms.TrackBar networkBackgroundOpacity;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox networkForegroundText;
        private System.Windows.Forms.Button networkForegroundButton;
        private System.Windows.Forms.TrackBar networkForegroundOpacity;
        private System.Windows.Forms.Label label34;
    }
}