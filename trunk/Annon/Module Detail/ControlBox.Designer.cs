namespace Annon.Module_Detail
{
    partial class ControlBox
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
            this.cbBoxSf = new System.Windows.Forms.ComboBox();
            this.textBoxTag = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(72, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(524, 1);
            this.button1.TabIndex = 29;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // cbBoxSp
            // 
            this.cbBoxSp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbBoxSp.FormattingEnabled = true;
            this.cbBoxSp.Location = new System.Drawing.Point(271, 145);
            this.cbBoxSp.Name = "cbBoxSp";
            this.cbBoxSp.Size = new System.Drawing.Size(156, 20);
            this.cbBoxSp.TabIndex = 28;
            this.cbBoxSp.Tag = "TYPE";
            this.cbBoxSp.SelectedIndexChanged += new System.EventHandler(this.cbBoxSp_SelectedIndexChanged);
            // 
            // cbBoxSf
            // 
            this.cbBoxSf.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbBoxSf.FormattingEnabled = true;
            this.cbBoxSf.Location = new System.Drawing.Point(271, 109);
            this.cbBoxSf.Name = "cbBoxSf";
            this.cbBoxSf.Size = new System.Drawing.Size(156, 20);
            this.cbBoxSf.TabIndex = 27;
            this.cbBoxSf.Tag = "SAFETY OPTIONS";
            this.cbBoxSf.SelectedIndexChanged += new System.EventHandler(this.cbBoxSf_SelectedIndexChanged);
            // 
            // textBoxTag
            // 
            this.textBoxTag.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxTag.BackColor = System.Drawing.Color.Gray;
            this.textBoxTag.Location = new System.Drawing.Point(271, 71);
            this.textBoxTag.Name = "textBoxTag";
            this.textBoxTag.ReadOnly = true;
            this.textBoxTag.Size = new System.Drawing.Size(156, 21);
            this.textBoxTag.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(197, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 25;
            this.label11.Text = "Special：";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(197, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 24;
            this.label9.Text = "Safety：";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "Module Tag：";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "List Price：";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "Control Box：";
            // 
            // ControlBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 214);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbBoxSp);
            this.Controls.Add(this.cbBoxSf);
            this.Controls.Add(this.textBoxTag);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ControlBox";
            this.Text = "ControlBox";
            this.Load += new System.EventHandler(this.ControlBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbBoxSp;
        private System.Windows.Forms.ComboBox cbBoxSf;
        private System.Windows.Forms.TextBox textBoxTag;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}