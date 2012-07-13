namespace Annon.Xuanxing
{
    partial class OrderForm
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
            this.dataGridView_OrderDetail = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SumPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OrderDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_OrderDetail
            // 
            this.dataGridView_OrderDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_OrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_OrderDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderId,
            this.DeviceType,
            this.DeviceId,
            this.OrderDetail,
            this.SumPrice});
            this.dataGridView_OrderDetail.Location = new System.Drawing.Point(12, 54);
            this.dataGridView_OrderDetail.Name = "dataGridView_OrderDetail";
            this.dataGridView_OrderDetail.RowTemplate.Height = 23;
            this.dataGridView_OrderDetail.Size = new System.Drawing.Size(700, 318);
            this.dataGridView_OrderDetail.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(301, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "订单详情";
            // 
            // OrderId
            // 
            this.OrderId.DataPropertyName = "OrderId";
            this.OrderId.HeaderText = "订单编号";
            this.OrderId.Name = "OrderId";
            // 
            // DeviceType
            // 
            this.DeviceType.DataPropertyName = "DeviceType";
            this.DeviceType.HeaderText = "设备类型";
            this.DeviceType.Name = "DeviceType";
            // 
            // DeviceId
            // 
            this.DeviceId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DeviceId.DataPropertyName = "DeviceId";
            this.DeviceId.HeaderText = "设备编号";
            this.DeviceId.Name = "DeviceId";
            this.DeviceId.Width = 279;
            // 
            // OrderDetail
            // 
            this.OrderDetail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OrderDetail.DataPropertyName = "OrderDetail";
            this.OrderDetail.HeaderText = "订单详情";
            this.OrderDetail.Name = "OrderDetail";
            // 
            // SumPrice
            // 
            this.SumPrice.DataPropertyName = "SumPrice";
            this.SumPrice.HeaderText = "总价";
            this.SumPrice.Name = "SumPrice";
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 384);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_OrderDetail);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OrderDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_OrderDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn SumPrice;
    }
}