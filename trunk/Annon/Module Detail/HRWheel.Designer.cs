namespace Annon.Module_Detail
{
    partial class HRWheel
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
            this.button1 = new System.Windows.Forms.Button();
            this.cbBoxSp = new System.Windows.Forms.ComboBox();
            this.cbBoxWS = new System.Windows.Forms.ComboBox();
            this.textBoxTag = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(33, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(524, 1);
            this.button1.TabIndex = 29;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // cbBoxSp
            // 
            this.cbBoxSp.FormattingEnabled = true;
            this.cbBoxSp.Location = new System.Drawing.Point(232, 171);
            this.cbBoxSp.Name = "cbBoxSp";
            this.cbBoxSp.Size = new System.Drawing.Size(156, 20);
            this.cbBoxSp.TabIndex = 28;
            // 
            // cbBoxWS
            // 
            this.cbBoxWS.FormattingEnabled = true;
            this.cbBoxWS.Location = new System.Drawing.Point(232, 133);
            this.cbBoxWS.Name = "cbBoxWS";
            this.cbBoxWS.Size = new System.Drawing.Size(156, 20);
            this.cbBoxWS.TabIndex = 27;
            // 
            // textBoxTag
            // 
            this.textBoxTag.BackColor = System.Drawing.SystemColors.ControlDark;
            this.textBoxTag.Location = new System.Drawing.Point(232, 94);
            this.textBoxTag.Name = "textBoxTag";
            this.textBoxTag.ReadOnly = true;
            this.textBoxTag.Size = new System.Drawing.Size(156, 21);
            this.textBoxTag.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(156, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 25;
            this.label11.Text = "Special：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "Wheel Size：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "Module Tag：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "List Price：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "HR Wheel：";
            // 
            // HRWheel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbBoxSp);
            this.Controls.Add(this.cbBoxWS);
            this.Controls.Add(this.textBoxTag);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HRWheel";
            this.Text = "HRWheel";
            this.Load += new System.EventHandler(this.HRWheel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbBoxSp;
        private System.Windows.Forms.ComboBox cbBoxWS;
        private System.Windows.Forms.TextBox textBoxTag;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}