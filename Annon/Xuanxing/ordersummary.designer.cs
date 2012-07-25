namespace Annon.Xuanxing
{
    partial class ordersummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ordersummary));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_addNew = new System.Windows.Forms.Button();
            this.btn_editDetail = new System.Windows.Forms.Button();
            this.btn_cpyDetail = new System.Windows.Forms.Button();
            this.btn_DelDetail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 12F);
            this.label1.Location = new System.Drawing.Point(19, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Add New..";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 12F);
            this.label2.Location = new System.Drawing.Point(39, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Edit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 12F);
            this.label3.Location = new System.Drawing.Point(39, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Copy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 12F);
            this.label4.Location = new System.Drawing.Point(31, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Delete";
            // 
            // btn_addNew
            // 
            this.btn_addNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_addNew.Image = ((System.Drawing.Image)(resources.GetObject("btn_addNew.Image")));
            this.btn_addNew.Location = new System.Drawing.Point(41, 6);
            this.btn_addNew.Name = "btn_addNew";
            this.btn_addNew.Size = new System.Drawing.Size(58, 51);
            this.btn_addNew.TabIndex = 20;
            this.btn_addNew.UseVisualStyleBackColor = true;
            this.btn_addNew.Click += new System.EventHandler(this.btn_addNew_Click);
            // 
            // btn_editDetail
            // 
            this.btn_editDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_editDetail.Image = ((System.Drawing.Image)(resources.GetObject("btn_editDetail.Image")));
            this.btn_editDetail.Location = new System.Drawing.Point(41, 88);
            this.btn_editDetail.Name = "btn_editDetail";
            this.btn_editDetail.Size = new System.Drawing.Size(58, 51);
            this.btn_editDetail.TabIndex = 21;
            this.btn_editDetail.UseVisualStyleBackColor = true;
            this.btn_editDetail.Click += new System.EventHandler(this.btn_editDetail_Click);
            // 
            // btn_cpyDetail
            // 
            this.btn_cpyDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_cpyDetail.Image = ((System.Drawing.Image)(resources.GetObject("btn_cpyDetail.Image")));
            this.btn_cpyDetail.Location = new System.Drawing.Point(41, 170);
            this.btn_cpyDetail.Name = "btn_cpyDetail";
            this.btn_cpyDetail.Size = new System.Drawing.Size(58, 51);
            this.btn_cpyDetail.TabIndex = 22;
            this.btn_cpyDetail.UseVisualStyleBackColor = true;
            this.btn_cpyDetail.Click += new System.EventHandler(this.btn_cpyDetail_Click);
            // 
            // btn_DelDetail
            // 
            this.btn_DelDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_DelDetail.Image = ((System.Drawing.Image)(resources.GetObject("btn_DelDetail.Image")));
            this.btn_DelDetail.Location = new System.Drawing.Point(41, 252);
            this.btn_DelDetail.Name = "btn_DelDetail";
            this.btn_DelDetail.Size = new System.Drawing.Size(58, 51);
            this.btn_DelDetail.TabIndex = 23;
            this.btn_DelDetail.UseVisualStyleBackColor = true;
            this.btn_DelDetail.Click += new System.EventHandler(this.btn_DelDetail_Click);
            // 
            // ordersummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(135, 446);
            this.Controls.Add(this.btn_DelDetail);
            this.Controls.Add(this.btn_cpyDetail);
            this.Controls.Add(this.btn_editDetail);
            this.Controls.Add(this.btn_addNew);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ordersummary";
            this.Text = "ordersummary";
            this.Load += new System.EventHandler(this.ordersummary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_addNew;
        private System.Windows.Forms.Button btn_editDetail;
        private System.Windows.Forms.Button btn_cpyDetail;
        private System.Windows.Forms.Button btn_DelDetail;
    }
}