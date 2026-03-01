using System.Windows.Forms;

namespace CountTogether.MacroDeckPlugin.GUI
{
    partial class IncrementDecrementCounterActionConfigurator
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            selectedCounter = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // selectedCounter
            // 
            selectedCounter.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
            selectedCounter.DropDownStyle = ComboBoxStyle.DropDownList;
            selectedCounter.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            selectedCounter.ForeColor = System.Drawing.Color.White;
            selectedCounter.Location = new System.Drawing.Point(123, 181);
            selectedCounter.Name = "selectedCounter";
            selectedCounter.Size = new System.Drawing.Size(555, 33);
            selectedCounter.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(34, 186);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 23);
            label1.TabIndex = 1;
            label1.Text = "Counter:";
            // 
            // IncrementDecrementCounterActionConfigurator
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(selectedCounter);
            Name = "IncrementDecrementCounterActionConfigurator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox selectedCounter;
        private System.Windows.Forms.Label label1;
    }
}
