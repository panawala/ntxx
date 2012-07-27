namespace Annon.Module_Detail
{
    partial class MixingBox
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
            this.cbBoxFO = new System.Windows.Forms.ComboBox();
            this.cbBoxSf = new System.Windows.Forms.ComboBox();
            this.cbBoxFS = new System.Windows.Forms.ComboBox();
            this.cbBoxAT = new System.Windows.Forms.ComboBox();
            this.textBoxDA = new System.Windows.Forms.TextBox();
            this.textBoxTag = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mixingBoxName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(48, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(524, 1);
            this.button1.TabIndex = 37;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // cbBoxSp
            // 
            this.cbBoxSp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbBoxSp.FormattingEnabled = true;
            this.cbBoxSp.Location = new System.Drawing.Point(271, 280);
            this.cbBoxSp.Name = "cbBoxSp";
            this.cbBoxSp.Size = new System.Drawing.Size(132, 20);
            this.cbBoxSp.TabIndex = 36;
            this.cbBoxSp.Tag = "TYPE";
            this.cbBoxSp.SelectedIndexChanged += new System.EventHandler(this.cbBoxSp_SelectedIndexChanged);
            // 
            // cbBoxFO
            // 
            this.cbBoxFO.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbBoxFO.FormattingEnabled = true;
            this.cbBoxFO.Location = new System.Drawing.Point(271, 249);
            this.cbBoxFO.Name = "cbBoxFO";
            this.cbBoxFO.Size = new System.Drawing.Size(132, 20);
            this.cbBoxFO.TabIndex = 35;
            this.cbBoxFO.Tag = "FILTER OPTIONS";
            this.cbBoxFO.SelectedIndexChanged += new System.EventHandler(this.cbBoxFO_SelectedIndexChanged);
            // 
            // cbBoxSf
            // 
            this.cbBoxSf.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbBoxSf.FormattingEnabled = true;
            this.cbBoxSf.Location = new System.Drawing.Point(271, 218);
            this.cbBoxSf.Name = "cbBoxSf";
            this.cbBoxSf.Size = new System.Drawing.Size(132, 20);
            this.cbBoxSf.TabIndex = 34;
            this.cbBoxSf.Tag = "SAFETY CONTROL";
            this.cbBoxSf.SelectedIndexChanged += new System.EventHandler(this.cbBoxSf_SelectedIndexChanged);
            // 
            // cbBoxFS
            // 
            this.cbBoxFS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbBoxFS.FormattingEnabled = true;
            this.cbBoxFS.Location = new System.Drawing.Point(271, 187);
            this.cbBoxFS.Name = "cbBoxFS";
            this.cbBoxFS.Size = new System.Drawing.Size(132, 20);
            this.cbBoxFS.TabIndex = 33;
            this.cbBoxFS.Tag = "FILTERS";
            this.cbBoxFS.SelectedIndexChanged += new System.EventHandler(this.cbBoxFS_SelectedIndexChanged);
            // 
            // cbBoxAT
            // 
            this.cbBoxAT.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbBoxAT.FormattingEnabled = true;
            this.cbBoxAT.Location = new System.Drawing.Point(271, 156);
            this.cbBoxAT.Name = "cbBoxAT";
            this.cbBoxAT.Size = new System.Drawing.Size(132, 20);
            this.cbBoxAT.TabIndex = 32;
            this.cbBoxAT.Tag = "ACTUATOR";
            this.cbBoxAT.SelectedIndexChanged += new System.EventHandler(this.cbBoxAT_SelectedIndexChanged);
            // 
            // textBoxDA
            // 
            this.textBoxDA.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxDA.Location = new System.Drawing.Point(314, 124);
            this.textBoxDA.Name = "textBoxDA";
            this.textBoxDA.Size = new System.Drawing.Size(89, 21);
            this.textBoxDA.TabIndex = 31;
            // 
            // textBoxTag
            // 
            this.textBoxTag.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxTag.BackColor = System.Drawing.Color.DarkGray;
            this.textBoxTag.Location = new System.Drawing.Point(247, 92);
            this.textBoxTag.Name = "textBoxTag";
            this.textBoxTag.ReadOnly = true;
            this.textBoxTag.Size = new System.Drawing.Size(156, 21);
            this.textBoxTag.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(158, 282);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 29;
            this.label11.Text = "Special：";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(158, 251);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 12);
            this.label10.TabIndex = 28;
            this.label10.Text = "Filter Option：";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(158, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "Filter Size：";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(158, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "Safety：";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "Actuator Type：";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "Dirt Allowance(in.wg.)：";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "Module Tag：";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "List Price：";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "MixingBox：";
            // 
            // mixingBoxName
            // 
            this.mixingBoxName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mixingBoxName.AutoSize = true;
            this.mixingBoxName.Location = new System.Drawing.Point(138, 44);
            this.mixingBoxName.Name = "mixingBoxName";
            this.mixingBoxName.Size = new System.Drawing.Size(35, 12);
            this.mixingBoxName.TabIndex = 38;
            this.mixingBoxName.Text = "11111";
            // 
            // MixingBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 345);
            this.Controls.Add(this.mixingBoxName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbBoxSp);
            this.Controls.Add(this.cbBoxFO);
            this.Controls.Add(this.cbBoxSf);
            this.Controls.Add(this.cbBoxFS);
            this.Controls.Add(this.cbBoxAT);
            this.Controls.Add(this.textBoxDA);
            this.Controls.Add(this.textBoxTag);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MixingBox";
            this.Text = "11111";
            this.Load += new System.EventHandler(this.MixingBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbBoxSp;
        private System.Windows.Forms.ComboBox cbBoxFO;
        private System.Windows.Forms.ComboBox cbBoxSf;
        private System.Windows.Forms.ComboBox cbBoxFS;
        private System.Windows.Forms.ComboBox cbBoxAT;
        private System.Windows.Forms.TextBox textBoxDA;
        private System.Windows.Forms.TextBox textBoxTag;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label mixingBoxName;
    }
}