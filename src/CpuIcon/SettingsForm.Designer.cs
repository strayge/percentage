﻿namespace CpuIcon
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
            this.panel10 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cpuInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cpuBorderText = new System.Windows.Forms.TextBox();
            this.cpuBorderButton = new System.Windows.Forms.Button();
            this.cpuBorderOpacity = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cpuBackgroundText = new System.Windows.Forms.TextBox();
            this.cpuBackgroundButton = new System.Windows.Forms.Button();
            this.cpuBackgroundOpacity = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cpuForegroundText = new System.Windows.Forms.TextBox();
            this.cpuForegroundButton = new System.Windows.Forms.Button();
            this.cpuForegroundOpacity = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cpuForegroundThrottlingText = new System.Windows.Forms.TextBox();
            this.cpuForegroundThrottlingButton = new System.Windows.Forms.Button();
            this.cpuForegroundThrottlingOpacity = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpuInterval)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpuBorderOpacity)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpuBackgroundOpacity)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpuForegroundOpacity)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpuForegroundThrottlingOpacity)).BeginInit();
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
            this.buttonOk.Location = new System.Drawing.Point(609, 302);
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
            this.buttonCancel.Location = new System.Drawing.Point(418, 302);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(182, 51);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label4);
            this.panel10.Controls.Add(this.cpuInterval);
            this.panel10.Controls.Add(this.label1);
            this.panel10.Location = new System.Drawing.Point(4, 234);
            this.panel10.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(788, 56);
            this.panel10.TabIndex = 80;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 30);
            this.label4.TabIndex = 60;
            this.label4.Text = "Update interval";
            // 
            // cpuInterval
            // 
            this.cpuInterval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.cpuInterval.Location = new System.Drawing.Point(172, 7);
            this.cpuInterval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpuInterval.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.cpuInterval.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.cpuInterval.Name = "cpuInterval";
            this.cpuInterval.Size = new System.Drawing.Size(114, 35);
            this.cpuInterval.TabIndex = 59;
            this.cpuInterval.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 30);
            this.label1.TabIndex = 67;
            this.label1.Text = "ms";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label3);
            this.panel9.Controls.Add(this.cpuBorderText);
            this.panel9.Controls.Add(this.cpuBorderButton);
            this.panel9.Controls.Add(this.cpuBorderOpacity);
            this.panel9.Controls.Add(this.label2);
            this.panel9.Location = new System.Drawing.Point(4, 178);
            this.panel9.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(788, 56);
            this.panel9.TabIndex = 79;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 30);
            this.label3.TabIndex = 62;
            this.label3.Text = "Border";
            // 
            // cpuBorderText
            // 
            this.cpuBorderText.Location = new System.Drawing.Point(172, 7);
            this.cpuBorderText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpuBorderText.Name = "cpuBorderText";
            this.cpuBorderText.Size = new System.Drawing.Size(162, 35);
            this.cpuBorderText.TabIndex = 61;
            // 
            // cpuBorderButton
            // 
            this.cpuBorderButton.Location = new System.Drawing.Point(352, 5);
            this.cpuBorderButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpuBorderButton.Name = "cpuBorderButton";
            this.cpuBorderButton.Size = new System.Drawing.Size(86, 44);
            this.cpuBorderButton.TabIndex = 63;
            this.cpuBorderButton.Text = "Color";
            this.cpuBorderButton.UseVisualStyleBackColor = true;
            this.cpuBorderButton.Click += new System.EventHandler(this.cpuBorderButton_Click);
            // 
            // cpuBorderOpacity
            // 
            this.cpuBorderOpacity.AutoSize = false;
            this.cpuBorderOpacity.Location = new System.Drawing.Point(551, 10);
            this.cpuBorderOpacity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpuBorderOpacity.Maximum = 255;
            this.cpuBorderOpacity.Name = "cpuBorderOpacity";
            this.cpuBorderOpacity.Size = new System.Drawing.Size(231, 32);
            this.cpuBorderOpacity.TabIndex = 64;
            this.cpuBorderOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.cpuBorderOpacity.Scroll += new System.EventHandler(this.cpuBorderOpacity_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(462, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 30);
            this.label2.TabIndex = 65;
            this.label2.Text = "Opacity";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.cpuBackgroundText);
            this.panel8.Controls.Add(this.cpuBackgroundButton);
            this.panel8.Controls.Add(this.cpuBackgroundOpacity);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Location = new System.Drawing.Point(4, 122);
            this.panel8.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(788, 56);
            this.panel8.TabIndex = 78;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 30);
            this.label7.TabIndex = 52;
            this.label7.Text = "Background";
            // 
            // cpuBackgroundText
            // 
            this.cpuBackgroundText.Location = new System.Drawing.Point(172, 7);
            this.cpuBackgroundText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpuBackgroundText.Name = "cpuBackgroundText";
            this.cpuBackgroundText.Size = new System.Drawing.Size(162, 35);
            this.cpuBackgroundText.TabIndex = 51;
            // 
            // cpuBackgroundButton
            // 
            this.cpuBackgroundButton.Location = new System.Drawing.Point(352, 5);
            this.cpuBackgroundButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpuBackgroundButton.Name = "cpuBackgroundButton";
            this.cpuBackgroundButton.Size = new System.Drawing.Size(86, 44);
            this.cpuBackgroundButton.TabIndex = 54;
            this.cpuBackgroundButton.Text = "Color";
            this.cpuBackgroundButton.UseVisualStyleBackColor = true;
            this.cpuBackgroundButton.Click += new System.EventHandler(this.cpuBackgroundButton_Click);
            // 
            // cpuBackgroundOpacity
            // 
            this.cpuBackgroundOpacity.AutoSize = false;
            this.cpuBackgroundOpacity.Location = new System.Drawing.Point(551, 10);
            this.cpuBackgroundOpacity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpuBackgroundOpacity.Maximum = 255;
            this.cpuBackgroundOpacity.Name = "cpuBackgroundOpacity";
            this.cpuBackgroundOpacity.Size = new System.Drawing.Size(231, 32);
            this.cpuBackgroundOpacity.TabIndex = 56;
            this.cpuBackgroundOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.cpuBackgroundOpacity.Scroll += new System.EventHandler(this.cpuBackgroundOpacity_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(462, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 30);
            this.label5.TabIndex = 58;
            this.label5.Text = "Opacity";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.cpuForegroundText);
            this.panel7.Controls.Add(this.cpuForegroundButton);
            this.panel7.Controls.Add(this.cpuForegroundOpacity);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Location = new System.Drawing.Point(4, 10);
            this.panel7.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(788, 56);
            this.panel7.TabIndex = 77;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 14);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 30);
            this.label8.TabIndex = 50;
            this.label8.Text = "Foreground";
            // 
            // cpuForegroundText
            // 
            this.cpuForegroundText.Location = new System.Drawing.Point(172, 7);
            this.cpuForegroundText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpuForegroundText.Name = "cpuForegroundText";
            this.cpuForegroundText.Size = new System.Drawing.Size(162, 35);
            this.cpuForegroundText.TabIndex = 49;
            // 
            // cpuForegroundButton
            // 
            this.cpuForegroundButton.Location = new System.Drawing.Point(352, 5);
            this.cpuForegroundButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpuForegroundButton.Name = "cpuForegroundButton";
            this.cpuForegroundButton.Size = new System.Drawing.Size(86, 44);
            this.cpuForegroundButton.TabIndex = 53;
            this.cpuForegroundButton.Text = "Color";
            this.cpuForegroundButton.UseVisualStyleBackColor = true;
            this.cpuForegroundButton.Click += new System.EventHandler(this.cpuForegroundButton_Click);
            // 
            // cpuForegroundOpacity
            // 
            this.cpuForegroundOpacity.AutoSize = false;
            this.cpuForegroundOpacity.Location = new System.Drawing.Point(551, 10);
            this.cpuForegroundOpacity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpuForegroundOpacity.Maximum = 255;
            this.cpuForegroundOpacity.Name = "cpuForegroundOpacity";
            this.cpuForegroundOpacity.Size = new System.Drawing.Size(231, 32);
            this.cpuForegroundOpacity.TabIndex = 55;
            this.cpuForegroundOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.cpuForegroundOpacity.Scroll += new System.EventHandler(this.cpuForegroundOpacity_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(462, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 30);
            this.label6.TabIndex = 57;
            this.label6.Text = "Opacity";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cpuForegroundThrottlingText);
            this.panel1.Controls.Add(this.cpuForegroundThrottlingButton);
            this.panel1.Controls.Add(this.cpuForegroundThrottlingOpacity);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(4, 66);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 56);
            this.panel1.TabIndex = 81;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 14);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 30);
            this.label9.TabIndex = 50;
            this.label9.Text = "Throttling";
            // 
            // cpuForegroundThrottlingText
            // 
            this.cpuForegroundThrottlingText.Location = new System.Drawing.Point(172, 7);
            this.cpuForegroundThrottlingText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpuForegroundThrottlingText.Name = "cpuForegroundThrottlingText";
            this.cpuForegroundThrottlingText.Size = new System.Drawing.Size(162, 35);
            this.cpuForegroundThrottlingText.TabIndex = 49;
            // 
            // cpuForegroundThrottlingButton
            // 
            this.cpuForegroundThrottlingButton.Location = new System.Drawing.Point(352, 5);
            this.cpuForegroundThrottlingButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpuForegroundThrottlingButton.Name = "cpuForegroundThrottlingButton";
            this.cpuForegroundThrottlingButton.Size = new System.Drawing.Size(86, 44);
            this.cpuForegroundThrottlingButton.TabIndex = 53;
            this.cpuForegroundThrottlingButton.Text = "Color";
            this.cpuForegroundThrottlingButton.UseVisualStyleBackColor = true;
            this.cpuForegroundThrottlingButton.Click += new System.EventHandler(this.cpuForegroundThrottlingButton_Click);
            // 
            // cpuForegroundThrottlingOpacity
            // 
            this.cpuForegroundThrottlingOpacity.AutoSize = false;
            this.cpuForegroundThrottlingOpacity.Location = new System.Drawing.Point(551, 10);
            this.cpuForegroundThrottlingOpacity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpuForegroundThrottlingOpacity.Maximum = 255;
            this.cpuForegroundThrottlingOpacity.Name = "cpuForegroundThrottlingOpacity";
            this.cpuForegroundThrottlingOpacity.Size = new System.Drawing.Size(231, 32);
            this.cpuForegroundThrottlingOpacity.TabIndex = 55;
            this.cpuForegroundThrottlingOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.cpuForegroundThrottlingOpacity.Scroll += new System.EventHandler(this.cpuForegroundThrottlingOpacity_Scroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(462, 14);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 30);
            this.label10.TabIndex = 57;
            this.label10.Text = "Opacity";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(796, 360);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "CpuIcon Settings";
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpuInterval)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpuBorderOpacity)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpuBackgroundOpacity)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpuForegroundOpacity)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpuForegroundThrottlingOpacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.FontDialog batteryFontDialog;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown cpuInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cpuBorderText;
        private System.Windows.Forms.Button cpuBorderButton;
        private System.Windows.Forms.TrackBar cpuBorderOpacity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cpuBackgroundText;
        private System.Windows.Forms.Button cpuBackgroundButton;
        private System.Windows.Forms.TrackBar cpuBackgroundOpacity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox cpuForegroundText;
        private System.Windows.Forms.Button cpuForegroundButton;
        private System.Windows.Forms.TrackBar cpuForegroundOpacity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox cpuForegroundThrottlingText;
        private System.Windows.Forms.Button cpuForegroundThrottlingButton;
        private System.Windows.Forms.TrackBar cpuForegroundThrottlingOpacity;
        private System.Windows.Forms.Label label10;
    }
}