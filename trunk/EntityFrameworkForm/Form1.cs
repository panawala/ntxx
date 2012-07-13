using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EntityFrameworkForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = EntityFrameworkTryBLL.DeviceBLL.GetAllDevices();
                dataGridView2.DataSource = EntityFrameworkTryBLL.PropertyBLL.GetPropertiesByDeviceId(1);
                dataGridView3.AutoGenerateColumns = false;
                dataGridView3.DataSource = EntityFrameworkTryBLL.PropertyBLL.GetPtyValuesByDeviceandPtyName(1, "制冷组合");
               
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }
    }
}
