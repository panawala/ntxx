namespace Annon.Xuanxing
{
    partial class orderImformation
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
            this.orderImformationPanel = new System.Windows.Forms.Panel();
            this.billing_button = new System.Windows.Forms.Button();
            this.shipping_button = new System.Windows.Forms.Button();
            this.notes_button = new System.Windows.Forms.Button();
            this.pricing_button = new System.Windows.Forms.Button();
            this.OK_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // orderImformationPanel
            // 
            this.orderImformationPanel.Location = new System.Drawing.Point(12, 44);
            this.orderImformationPanel.Name = "orderImformationPanel";
            this.orderImformationPanel.Size = new System.Drawing.Size(517, 465);
            this.orderImformationPanel.TabIndex = 0;
            // 
            // billing_button
            // 
            this.billing_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.billing_button.Location = new System.Drawing.Point(12, 15);
            this.billing_button.Name = "billing_button";
            this.billing_button.Size = new System.Drawing.Size(97, 23);
            this.billing_button.TabIndex = 1;
            this.billing_button.Text = "Billing Info";
            this.billing_button.UseVisualStyleBackColor = true;
            this.billing_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // shipping_button
            // 
            this.shipping_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shipping_button.Location = new System.Drawing.Point(149, 15);
            this.shipping_button.Name = "shipping_button";
            this.shipping_button.Size = new System.Drawing.Size(97, 23);
            this.shipping_button.TabIndex = 2;
            this.shipping_button.Text = "Shipping Info";
            this.shipping_button.UseVisualStyleBackColor = true;
            this.shipping_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // notes_button
            // 
            this.notes_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notes_button.Location = new System.Drawing.Point(286, 15);
            this.notes_button.Name = "notes_button";
            this.notes_button.Size = new System.Drawing.Size(97, 23);
            this.notes_button.TabIndex = 3;
            this.notes_button.Text = "Notes";
            this.notes_button.UseVisualStyleBackColor = true;
            this.notes_button.Click += new System.EventHandler(this.button3_Click);
            // 
            // pricing_button
            // 
            this.pricing_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pricing_button.Location = new System.Drawing.Point(423, 15);
            this.pricing_button.Name = "pricing_button";
            this.pricing_button.Size = new System.Drawing.Size(97, 23);
            this.pricing_button.TabIndex = 4;
            this.pricing_button.Text = "Pricing";
            this.pricing_button.UseVisualStyleBackColor = true;
            this.pricing_button.Click += new System.EventHandler(this.pricing_button_Click);
            // 
            // OK_button
            // 
            this.OK_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OK_button.Location = new System.Drawing.Point(535, 61);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(62, 23);
            this.OK_button.TabIndex = 5;
            this.OK_button.Text = "&OK";
            this.OK_button.UseVisualStyleBackColor = true;
            this.OK_button.Click += new System.EventHandler(this.OK_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancel_button.Location = new System.Drawing.Point(535, 105);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(62, 23);
            this.cancel_button.TabIndex = 6;
            this.cancel_button.Text = "&Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // orderImformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 521);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.pricing_button);
            this.Controls.Add(this.notes_button);
            this.Controls.Add(this.shipping_button);
            this.Controls.Add(this.billing_button);
            this.Controls.Add(this.orderImformationPanel);
            this.Name = "orderImformation";
            this.Text = "Order Imformation";
            this.Load += new System.EventHandler(this.orderImformation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel orderImformationPanel;
        private System.Windows.Forms.Button billing_button;
        private System.Windows.Forms.Button shipping_button;
        private System.Windows.Forms.Button notes_button;
        private System.Windows.Forms.Button pricing_button;
        private System.Windows.Forms.Button OK_button;
        private System.Windows.Forms.Button cancel_button;
    }
}