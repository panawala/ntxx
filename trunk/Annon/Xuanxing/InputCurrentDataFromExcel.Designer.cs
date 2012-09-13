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
            this.btnImageImport = new System.Windows.Forms.Button();
            this.btnContentImport = new System.Windows.Forms.Button();
            this.btnUnit = new System.Windows.Forms.Button();
            this.btnCatalog = new System.Windows.Forms.Button();
            this.btnCatalogConstraint = new System.Windows.Forms.Button();
            this.btnPriceConstraint = new System.Windows.Forms.Button();
            this.btnUnitConstraint = new System.Windows.Forms.Button();
            this.btnAccessory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImageImport
            // 
            this.btnImageImport.Location = new System.Drawing.Point(64, 55);
            this.btnImageImport.Name = "btnImageImport";
            this.btnImageImport.Size = new System.Drawing.Size(168, 64);
            this.btnImageImport.TabIndex = 5;
            this.btnImageImport.Text = "图块导入(ImageBlock)";
            this.btnImageImport.UseVisualStyleBackColor = true;
            this.btnImageImport.Click += new System.EventHandler(this.btnImageImport_Click);
            // 
            // btnContentImport
            // 
            this.btnContentImport.Location = new System.Drawing.Point(262, 55);
            this.btnContentImport.Name = "btnContentImport";
            this.btnContentImport.Size = new System.Drawing.Size(152, 64);
            this.btnContentImport.TabIndex = 6;
            this.btnContentImport.Text = "图块信息导入(ContentPropertyValue)";
            this.btnContentImport.UseVisualStyleBackColor = true;
            this.btnContentImport.Click += new System.EventHandler(this.btnContentImport_Click);
            // 
            // btnUnit
            // 
            this.btnUnit.Location = new System.Drawing.Point(64, 152);
            this.btnUnit.Name = "btnUnit";
            this.btnUnit.Size = new System.Drawing.Size(159, 64);
            this.btnUnit.TabIndex = 7;
            this.btnUnit.Text = "unit信息导入(UnitModel)";
            this.btnUnit.UseVisualStyleBackColor = true;
            this.btnUnit.Click += new System.EventHandler(this.btnUnit_Click);
            // 
            // btnCatalog
            // 
            this.btnCatalog.Location = new System.Drawing.Point(64, 258);
            this.btnCatalog.Name = "btnCatalog";
            this.btnCatalog.Size = new System.Drawing.Size(168, 64);
            this.btnCatalog.TabIndex = 8;
            this.btnCatalog.Text = "选型设备导入(CatalogPropertyValue)";
            this.btnCatalog.UseVisualStyleBackColor = true;
            this.btnCatalog.Click += new System.EventHandler(this.btnCatalog_Click);
            // 
            // btnCatalogConstraint
            // 
            this.btnCatalogConstraint.Location = new System.Drawing.Point(262, 258);
            this.btnCatalogConstraint.Name = "btnCatalogConstraint";
            this.btnCatalogConstraint.Size = new System.Drawing.Size(152, 64);
            this.btnCatalogConstraint.TabIndex = 9;
            this.btnCatalogConstraint.Text = "约束导入(CatalogConstraint)";
            this.btnCatalogConstraint.UseVisualStyleBackColor = true;
            this.btnCatalogConstraint.Click += new System.EventHandler(this.btnCatalogConstraint_Click);
            // 
            // btnPriceConstraint
            // 
            this.btnPriceConstraint.Location = new System.Drawing.Point(438, 258);
            this.btnPriceConstraint.Name = "btnPriceConstraint";
            this.btnPriceConstraint.Size = new System.Drawing.Size(159, 64);
            this.btnPriceConstraint.TabIndex = 10;
            this.btnPriceConstraint.Text = "价格约束(CatalogPriceConstraint)";
            this.btnPriceConstraint.UseVisualStyleBackColor = true;
            this.btnPriceConstraint.Click += new System.EventHandler(this.btnPriceConstraint_Click);
            // 
            // btnUnitConstraint
            // 
            this.btnUnitConstraint.Location = new System.Drawing.Point(262, 152);
            this.btnUnitConstraint.Name = "btnUnitConstraint";
            this.btnUnitConstraint.Size = new System.Drawing.Size(152, 64);
            this.btnUnitConstraint.TabIndex = 11;
            this.btnUnitConstraint.Text = "Unit约束";
            this.btnUnitConstraint.UseVisualStyleBackColor = true;
            this.btnUnitConstraint.Click += new System.EventHandler(this.btnUnitConstraint_Click);
            // 
            // btnAccessory
            // 
            this.btnAccessory.Location = new System.Drawing.Point(452, 55);
            this.btnAccessory.Name = "btnAccessory";
            this.btnAccessory.Size = new System.Drawing.Size(145, 64);
            this.btnAccessory.TabIndex = 12;
            this.btnAccessory.Text = "附件导入（Accessory）";
            this.btnAccessory.UseVisualStyleBackColor = true;
            this.btnAccessory.Click += new System.EventHandler(this.btnAccessory_Click);
            // 
            // InputCurrentDataFromExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 385);
            this.Controls.Add(this.btnAccessory);
            this.Controls.Add(this.btnUnitConstraint);
            this.Controls.Add(this.btnPriceConstraint);
            this.Controls.Add(this.btnCatalogConstraint);
            this.Controls.Add(this.btnCatalog);
            this.Controls.Add(this.btnUnit);
            this.Controls.Add(this.btnContentImport);
            this.Controls.Add(this.btnImageImport);
            this.Name = "InputCurrentDataFromExcel";
            this.Text = "InputCurrentDataFromExcel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImageImport;
        private System.Windows.Forms.Button btnContentImport;
        private System.Windows.Forms.Button btnUnit;
        private System.Windows.Forms.Button btnCatalog;
        private System.Windows.Forms.Button btnCatalogConstraint;
        private System.Windows.Forms.Button btnPriceConstraint;
        private System.Windows.Forms.Button btnUnitConstraint;
        private System.Windows.Forms.Button btnAccessory;
    }
}