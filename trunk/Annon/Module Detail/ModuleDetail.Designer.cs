namespace Annon.Module_Detail
{
    partial class ModuleDetail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.RightPinal = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 625);
            this.panel1.TabIndex = 0;
            // 
            // RightPinal
            // 
            this.RightPinal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RightPinal.BackColor = System.Drawing.SystemColors.Control;
            this.RightPinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RightPinal.Location = new System.Drawing.Point(174, 0);
            this.RightPinal.Name = "RightPinal";
            this.RightPinal.Size = new System.Drawing.Size(641, 629);
            this.RightPinal.TabIndex = 1;
            this.RightPinal.Paint += new System.Windows.Forms.PaintEventHandler(this.RightPinal_Paint);
            // 
            // ModuleDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 629);
            this.Controls.Add(this.RightPinal);
            this.Controls.Add(this.panel1);
            this.Name = "ModuleDetail";
            this.Text = "ModuleDetail";
            this.Load += new System.EventHandler(this.ModuleDetail_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel RightPinal;
    }
}