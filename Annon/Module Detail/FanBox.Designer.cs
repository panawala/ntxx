﻿namespace Annon.Module_Detail
{
    partial class FanBox
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
            this.fanBoxName = new System.Windows.Forms.Label();
            this.FanCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGViewFanBox = new System.Windows.Forms.DataGridView();
            this.FanSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RPM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVFanBox = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.cbBoxSp = new System.Windows.Forms.ComboBox();
            this.cbBoxSC = new System.Windows.Forms.ComboBox();
            this.cbBoxMT = new System.Windows.Forms.ComboBox();
            this.cbBoxMS = new System.Windows.Forms.ComboBox();
            this.textBoxTag = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SPA = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGViewFanBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fanBoxName
            // 
            this.fanBoxName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fanBoxName.AutoSize = true;
            this.fanBoxName.Location = new System.Drawing.Point(151, 38);
            this.fanBoxName.Name = "fanBoxName";
            this.fanBoxName.Size = new System.Drawing.Size(35, 12);
            this.fanBoxName.TabIndex = 52;
            this.fanBoxName.Text = "11111";
            // 
            // FanCode
            // 
            this.FanCode.HeaderText = "FanCode";
            this.FanCode.Name = "FanCode";
            this.FanCode.Width = 80;
            // 
            // dGViewFanBox
            // 
            this.dGViewFanBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dGViewFanBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGViewFanBox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FanCode,
            this.FanSize,
            this.BHP,
            this.RPM,
            this.Valid});
            this.dGViewFanBox.Location = new System.Drawing.Point(137, 222);
            this.dGViewFanBox.Name = "dGViewFanBox";
            this.dGViewFanBox.RowTemplate.Height = 23;
            this.dGViewFanBox.Size = new System.Drawing.Size(387, 101);
            this.dGViewFanBox.TabIndex = 51;
            // 
            // FanSize
            // 
            this.FanSize.HeaderText = "Fan Size";
            this.FanSize.Name = "FanSize";
            this.FanSize.Width = 80;
            // 
            // BHP
            // 
            this.BHP.HeaderText = "BHP";
            this.BHP.Name = "BHP";
            this.BHP.Width = 80;
            // 
            // RPM
            // 
            this.RPM.HeaderText = "RPM";
            this.RPM.Name = "RPM";
            this.RPM.Width = 80;
            // 
            // Valid
            // 
            this.Valid.HeaderText = "Valid";
            this.Valid.Name = "Valid";
            this.Valid.Width = 80;
            // 
            // lVFanBox
            // 
            this.lVFanBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lVFanBox.Location = new System.Drawing.Point(137, 111);
            this.lVFanBox.Name = "lVFanBox";
            this.lVFanBox.Size = new System.Drawing.Size(387, 114);
            this.lVFanBox.TabIndex = 50;
            this.lVFanBox.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(74, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(524, 1);
            this.button1.TabIndex = 49;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // cbBoxSp
            // 
            this.cbBoxSp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbBoxSp.FormattingEnabled = true;
            this.cbBoxSp.Location = new System.Drawing.Point(291, 438);
            this.cbBoxSp.Name = "cbBoxSp";
            this.cbBoxSp.Size = new System.Drawing.Size(181, 20);
            this.cbBoxSp.TabIndex = 48;
            this.cbBoxSp.Tag = "TYPE";
            // 
            // cbBoxSC
            // 
            this.cbBoxSC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbBoxSC.FormattingEnabled = true;
            this.cbBoxSC.Location = new System.Drawing.Point(291, 408);
            this.cbBoxSC.Name = "cbBoxSC";
            this.cbBoxSC.Size = new System.Drawing.Size(181, 20);
            this.cbBoxSC.TabIndex = 47;
            this.cbBoxSC.Tag = "SAFETY CONTROL";
            // 
            // cbBoxMT
            // 
            this.cbBoxMT.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbBoxMT.FormattingEnabled = true;
            this.cbBoxMT.Location = new System.Drawing.Point(291, 378);
            this.cbBoxMT.Name = "cbBoxMT";
            this.cbBoxMT.Size = new System.Drawing.Size(181, 20);
            this.cbBoxMT.TabIndex = 46;
            this.cbBoxMT.Tag = "MOTOR TYPE";
            // 
            // cbBoxMS
            // 
            this.cbBoxMS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbBoxMS.FormattingEnabled = true;
            this.cbBoxMS.Location = new System.Drawing.Point(291, 348);
            this.cbBoxMS.Name = "cbBoxMS";
            this.cbBoxMS.Size = new System.Drawing.Size(181, 20);
            this.cbBoxMS.TabIndex = 45;
            this.cbBoxMS.Tag = "MOTOR SIZE";
            // 
            // textBoxTag
            // 
            this.textBoxTag.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxTag.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBoxTag.Location = new System.Drawing.Point(277, 79);
            this.textBoxTag.Name = "textBoxTag";
            this.textBoxTag.ReadOnly = true;
            this.textBoxTag.Size = new System.Drawing.Size(181, 21);
            this.textBoxTag.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(178, 439);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 43;
            this.label11.Text = "Special：";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(178, 381);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 42;
            this.label9.Text = "Motor Type：";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(178, 410);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 41;
            this.label7.Text = "Safety Control：";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 352);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 40;
            this.label6.Text = "Motor Size：";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 39;
            this.label3.Text = "Module Tag：";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 38;
            this.label2.Text = "List Price：";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 37;
            this.label1.Text = "Fan Box：";
            // 
            // SPA
            // 
            this.SPA.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SPA.Location = new System.Drawing.Point(479, 438);
            this.SPA.Name = "SPA";
            this.SPA.Size = new System.Drawing.Size(45, 23);
            this.SPA.TabIndex = 53;
            this.SPA.Text = "SPA";
            this.SPA.UseVisualStyleBackColor = true;
            this.SPA.Visible = false;
            this.SPA.Click += new System.EventHandler(this.SPA_Click);
            // 
            // FanBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 495);
            this.Controls.Add(this.SPA);
            this.Controls.Add(this.fanBoxName);
            this.Controls.Add(this.dGViewFanBox);
            this.Controls.Add(this.lVFanBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbBoxSp);
            this.Controls.Add(this.cbBoxSC);
            this.Controls.Add(this.cbBoxMT);
            this.Controls.Add(this.cbBoxMS);
            this.Controls.Add(this.textBoxTag);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FanBox";
            this.Text = "FanBox";
            this.Load += new System.EventHandler(this.FanBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGViewFanBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fanBoxName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FanCode;
        private System.Windows.Forms.DataGridView dGViewFanBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn FanSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn BHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn RPM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valid;
        private System.Windows.Forms.ListView lVFanBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbBoxSp;
        private System.Windows.Forms.ComboBox cbBoxSC;
        private System.Windows.Forms.ComboBox cbBoxMT;
        private System.Windows.Forms.ComboBox cbBoxMS;
        private System.Windows.Forms.TextBox textBoxTag;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SPA;

    }
}