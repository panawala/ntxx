namespace Annon.Xuanxing
{
    partial class InputCurrentDataFromExcel
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
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.btnDataImport = new System.Windows.Forms.Button();
            this.btnConstraint = new System.Windows.Forms.Button();
            this.btnOrderDetail = new System.Windows.Forms.Button();
            this.btnImageImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(55, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "当前设备导入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Location = new System.Drawing.Point(195, 45);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(75, 23);
            this.btnNewOrder.TabIndex = 1;
            this.btnNewOrder.Text = "新建订单";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // btnDataImport
            // 
            this.btnDataImport.Location = new System.Drawing.Point(460, 45);
            this.btnDataImport.Name = "btnDataImport";
            this.btnDataImport.Size = new System.Drawing.Size(75, 23);
            this.btnDataImport.TabIndex = 2;
            this.btnDataImport.Text = "数据导入";
            this.btnDataImport.UseVisualStyleBackColor = true;
            this.btnDataImport.Click += new System.EventHandler(this.btnDataImport_Click);
            // 
            // btnConstraint
            // 
            this.btnConstraint.Location = new System.Drawing.Point(582, 45);
            this.btnConstraint.Name = "btnConstraint";
            this.btnConstraint.Size = new System.Drawing.Size(75, 23);
            this.btnConstraint.TabIndex = 3;
            this.btnConstraint.Text = "约束检查";
            this.btnConstraint.UseVisualStyleBackColor = true;
            this.btnConstraint.Click += new System.EventHandler(this.btnConstraint_Click);
            // 
            // btnOrderDetail
            // 
            this.btnOrderDetail.Location = new System.Drawing.Point(337, 45);
            this.btnOrderDetail.Name = "btnOrderDetail";
            this.btnOrderDetail.Size = new System.Drawing.Size(75, 23);
            this.btnOrderDetail.TabIndex = 4;
            this.btnOrderDetail.Text = "订单详情";
            this.btnOrderDetail.UseVisualStyleBackColor = true;
            this.btnOrderDetail.Click += new System.EventHandler(this.btnOrderDetail_Click);
            // 
            // btnImageImport
            // 
            this.btnImageImport.Location = new System.Drawing.Point(55, 130);
            this.btnImageImport.Name = "btnImageImport";
            this.btnImageImport.Size = new System.Drawing.Size(75, 23);
            this.btnImageImport.TabIndex = 5;
            this.btnImageImport.Text = "图块导入";
            this.btnImageImport.UseVisualStyleBackColor = true;
            this.btnImageImport.Click += new System.EventHandler(this.btnImageImport_Click);
            // 
            // InputCurrentDataFromExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 336);
            this.Controls.Add(this.btnImageImport);
            this.Controls.Add(this.btnOrderDetail);
            this.Controls.Add(this.btnConstraint);
            this.Controls.Add(this.btnDataImport);
            this.Controls.Add(this.btnNewOrder);
            this.Controls.Add(this.button1);
            this.Name = "InputCurrentDataFromExcel";
            this.Text = "InputCurrentDataFromExcel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnDataImport;
        private System.Windows.Forms.Button btnConstraint;
        private System.Windows.Forms.Button btnOrderDetail;
        private System.Windows.Forms.Button btnImageImport;
    }
}