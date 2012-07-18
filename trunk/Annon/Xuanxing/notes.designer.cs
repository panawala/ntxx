namespace Annon.Xuanxing
{
    partial class notes
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
            this.label1 = new System.Windows.Forms.Label();
            this.jobDes_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.custNote_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Job Description";
            // 
            // jobDes_textBox
            // 
            this.jobDes_textBox.Location = new System.Drawing.Point(31, 41);
            this.jobDes_textBox.Multiline = true;
            this.jobDes_textBox.Name = "jobDes_textBox";
            this.jobDes_textBox.Size = new System.Drawing.Size(465, 187);
            this.jobDes_textBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(29, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Customer Notes";
            // 
            // custNote_textBox
            // 
            this.custNote_textBox.Location = new System.Drawing.Point(31, 260);
            this.custNote_textBox.Multiline = true;
            this.custNote_textBox.Name = "custNote_textBox";
            this.custNote_textBox.Size = new System.Drawing.Size(465, 187);
            this.custNote_textBox.TabIndex = 3;
            // 
            // notes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 487);
            this.Controls.Add(this.custNote_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.jobDes_textBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "notes";
            this.Text = "notes";
            this.Load += new System.EventHandler(this.notes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox jobDes_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox custNote_textBox;
    }
}