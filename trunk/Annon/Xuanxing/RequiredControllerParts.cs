using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityFrameworkTryBLL;
using EntityFrameworkTryBLL.XuanxingManager;
using EntityFrameworkTryBLL.OrderManager;

namespace Annon.Xuanxing
{
    public partial class RequiredControllerParts : Form
    {
        public RequiredControllerParts()
        {
            InitializeComponent();
        }

        public RequiredControllerParts(int deviceId, string propertyName, string propertyValueCode)
        {
            InitializeComponent();
            accessoryDataGridView.AutoGenerateColumns = false;
            //accessoryDataGridView.DataSource=AccessoryBLL.GetAccessoriesByPtyValue(deviceId, propertyName, propertyValueCode);
        }
        private int deviceId;
        private int orderId;
        private int parentOrderId;
        public RequiredControllerParts(int deviceId, int orderId,int parentOrderId)
        {
            InitializeComponent();
            accessoryDataGridView.AutoGenerateColumns = false;
            this.deviceId = deviceId;
            this.orderId = orderId;
            this.parentOrderId = parentOrderId;
            //accessoryDataGridView.DataSource=AccessoryBLL.GetAccessoriesByPtyValue(deviceId, propertyName, propertyValueCode);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dataRow in accessoryDataGridView.Rows)
            {
                if (dataRow.Cells[0].Value != null)
                {
                    //AccessoryBLL.InsertIntoAccessory(dataRow.Cells[0].Value.ToString(), dataRow.Cells[1].Value.ToString(),
                    //                       dataRow.Cells[2].Value.ToString(), Convert.ToDecimal(dataRow.Cells[3].Value.ToString()), deviceId, orderId);
                    OrderDetailBLL.InsertOD1(0, parentOrderId, orderId, dataRow.Cells[1].Value.ToString(), dataRow.Cells[2].Value.ToString(), 8, 8, Convert.ToInt32(dataRow.Cells[3].Value.ToString()));
                }


            }
            MessageBox.Show("导入成功");
            this.Close();
        }

    }
}
