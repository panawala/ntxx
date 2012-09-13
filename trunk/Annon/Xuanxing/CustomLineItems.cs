using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityFrameworkTryBLL.XuanxingManager;

namespace Annon.Xuanxing
{
    public partial class CustomLineItems : Form
    {
        public CustomLineItems()
        {
            InitializeComponent();
        }
        public CustomLineItems(ControlsAndAccessories parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int OrderId;
        public ControlsAndAccessories parentForm;
        private void button1_Click(object sender, EventArgs e)
        { 
            if(textBox1.Text.Trim()==null)
            {
                MessageBox.Show("不能为空！");
                return;
            }
            if (textBox3.Text .Trim()== null)
            {
                MessageBox.Show("不能为空！");
                return;
            }
            if (textBox4.Text.Trim() == null)
            {
                MessageBox.Show("不能为空！");
                return;
            }
            if (textBox5.Text.Trim() == null)
            {
                MessageBox.Show("不能为空！");
                return;
            }
            AccessoryBLL.insertIntoAccessoryOrder(OrderId, textBox1.Text, textBox3.Text,Convert.ToInt32(textBox4.Text) ,Convert.ToDecimal(textBox5.Text));
            parentForm.dataGridView2.DataSource = AccessoryBLL.getAccessoryOrders(OrderId);
            this.Close();
        }
    }
}
