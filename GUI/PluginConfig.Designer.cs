using SuchByte.MacroDeck.GUI.CustomControls;

namespace CountTogether.MacroDeckPlugin.GUI
{
    partial class PluginConfig
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
            inputToken = new RoundedTextBox();
            lblApiToken = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            btnApply = new ButtonPrimary();
            SuspendLayout();
            // 
            // inputToken
            // 
            inputToken.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
            inputToken.Font = new System.Drawing.Font("Tahoma", 9F);
            inputToken.Icon = null;
            inputToken.Location = new System.Drawing.Point(95, 96);
            inputToken.MaxCharacters = 32767;
            inputToken.Multiline = false;
            inputToken.Name = "inputToken";
            inputToken.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            inputToken.PasswordChar = true;
            inputToken.PlaceHolderColor = System.Drawing.Color.Gray;
            inputToken.PlaceHolderText = "";
            inputToken.ReadOnly = false;
            inputToken.ScrollBars = System.Windows.Forms.ScrollBars.None;
            inputToken.SelectionStart = 0;
            inputToken.Size = new System.Drawing.Size(490, 25);
            inputToken.TabIndex = 0;
            inputToken.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblApiToken
            // 
            lblApiToken.AutoSize = true;
            lblApiToken.Location = new System.Drawing.Point(19, 100);
            lblApiToken.Name = "lblApiToken";
            lblApiToken.Size = new System.Drawing.Size(70, 16);
            lblApiToken.TabIndex = 1;
            lblApiToken.Text = "API Token:";
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(19, 17);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(566, 66);
            label1.TabIndex = 2;
            label1.Text = "This plugin requires a CountTogether API token. You can create one in the app's settings.";
            // 
            // btnApply
            // 
            btnApply.BorderRadius = 8;
            btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnApply.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnApply.ForeColor = System.Drawing.Color.White;
            btnApply.HoverColor = System.Drawing.Color.Empty;
            btnApply.Icon = null;
            btnApply.Location = new System.Drawing.Point(445, 138);
            btnApply.Name = "btnApply";
            btnApply.Progress = 0;
            btnApply.ProgressColor = System.Drawing.Color.FromArgb(0, 103, 205);
            btnApply.Size = new System.Drawing.Size(140, 35);
            btnApply.TabIndex = 3;
            btnApply.Text = "Apply";
            btnApply.UseWindowsAccentColor = true;
            btnApply.WriteProgress = true;
            btnApply.Click += BtnApply_Click;
            // 
            // PluginConfig
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(611, 196);
            Controls.Add(btnApply);
            Controls.Add(label1);
            Controls.Add(lblApiToken);
            Controls.Add(inputToken);
            Name = "PluginConfig";
            Text = "PluginConfig";
            Load += PluginConfig_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundedTextBox inputToken;
        private System.Windows.Forms.Label lblApiToken;
        private System.Windows.Forms.Label label1;
        private ButtonPrimary btnApply;
    }
}