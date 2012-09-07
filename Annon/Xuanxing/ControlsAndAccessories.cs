using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityFrameworkTryBLL.XuanxingManager;
using Model.Device;

namespace Annon.Xuanxing
{
    public partial class ControlsAndAccessories : Form
    {

        private int orderID;
        private int accessoryOrderID;

        public ControlsAndAccessories()
        {
            InitializeComponent();
            hideDataGridView1Column("SubBase");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CustomLineItems customLineItems = new CustomLineItems();
            customLineItems.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text=comboBox1.Text;
            switch (text)
            {
                case "SubBase":
                {
                    btnTheme.Text = text;
                    hideDataGridView1Column(text);
                }break;
                case "Themostats":
                 {
                        btnTheme.Text = text;
                        hideDataGridView1Column(text);
                        
                 } break;
                case "Additional Control Accessories":
                 {
                        btnTheme.Text = text;
                        hideDataGridView1Column(text);
                 } break;
                case "Additional Curb Accessories":
                 {
                        btnTheme.Text = text;
                        hideDataGridView1Column(text);
                 } break;
                case "Optional Accessories":
                 {
                        btnTheme.Text = text;
                        hideDataGridView1Column(text);
                 } break;
            }
        }

        public void hideDataGridView1Column(string text)
        {
            switch (text)
            {
                case "SubBase":
                    {
                        recoveryDataGridViewColumn();
                        dataGridView1.Columns["TDescription"].Visible = false;
                        dataGridView1.Columns["THeat"].Visible = false;
                        dataGridView1.Columns["TCool"].Visible = false;
                        dataGridView1.Columns["TApplication"].Visible = false;
                        dataGridView1.Columns["TChangeOver"].Visible = false;
                        dataGridView1.Columns["TUsewSubbase"].Visible = false;

                        dataGridView1Bingding(text);

                    } break;
                case "Themostats":
                    {
                        recoveryDataGridViewColumn();
                        dataGridView1.Columns["TSystemSwitching"].Visible = false;
                        dataGridView1.Columns["TFanSwitching"].Visible = false;
                        dataGridView1.Columns["TDescription"].Visible = false;
                        dataGridView1.Columns["TUsewThemostat"].Visible = false;
                        dataGridView1Bingding(text);

                    } break;
                case "Additional Control Accessories":
                    {
                        recoveryDataGridViewColumn();
                        dataGridView1.Columns["TSystemSwitching"].Visible = false;
                        dataGridView1.Columns["TFanSwitching"].Visible = false;
                        dataGridView1.Columns["THeat"].Visible = false;
                        dataGridView1.Columns["TCool"].Visible = false;
                        dataGridView1.Columns["TApplication"].Visible = false;
                        dataGridView1.Columns["TChangeOver"].Visible = false;
                        dataGridView1.Columns["TUsewSubbase"].Visible = false;
                        dataGridView1.Columns["TUsewThemostat"].Visible = false;
                        dataGridView1Bingding(text);
                    } break;
                case "Additional Curb Accessories":
                    {
                        recoveryDataGridViewColumn();
                        dataGridView1.Columns["TSystemSwitching"].Visible = false;
                        dataGridView1.Columns["TFanSwitching"].Visible = false;
                        dataGridView1.Columns["THeat"].Visible = false;
                        dataGridView1.Columns["TCool"].Visible = false;
                        dataGridView1.Columns["TApplication"].Visible = false;
                        dataGridView1.Columns["TChangeOver"].Visible = false;
                        dataGridView1.Columns["TUsewSubbase"].Visible = false;
                        dataGridView1.Columns["TUsewThemostat"].Visible = false;
                        dataGridView1.Columns["TModel"].Visible = false;
                        dataGridView1Bingding(text);
                    } break;
                case "Optional Accessories":
                    {
                        recoveryDataGridViewColumn();
                        dataGridView1.Columns["TSystemSwitching"].Visible = false;
                        dataGridView1.Columns["TFanSwitching"].Visible = false;
                        dataGridView1.Columns["THeat"].Visible = false;
                        dataGridView1.Columns["TCool"].Visible = false;
                        dataGridView1.Columns["TApplication"].Visible = false;
                        dataGridView1.Columns["TChangeOver"].Visible = false;
                        dataGridView1.Columns["TUsewSubbase"].Visible = false;
                        dataGridView1.Columns["TUsewThemostat"].Visible = false;
                        dataGridView1Bingding(text);
                    } break;
            }
        }

        public void recoveryDataGridViewColumn()
        {
            foreach (var column in dataGridView1.Columns)
            {
                DataGridViewColumn eachColumn = (DataGridViewColumn)column;
                eachColumn.Visible = true;
            }
        }

        public void dataGridView1Bingding(string text)
        {
            dataGridView1.DataSource = AccessoryBLL.getAccessories(text);
        }

        public void dataGridView2Binding(int orderID)
        {
            dataGridView2.DataSource = AccessoryBLL.getAccessoryOrders(orderID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AccessoryBLL.modifyOrder(orderID,Convert.ToInt32(textBox1.Text));
            dataGridView2Binding(orderID);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView2.Rows.Count>0)
            AccessoryBLL.deleteOrder(accessoryOrderID);
            if(dataGridView2.Rows.Count>0)
            accessoryOrderID =Convert.ToInt32(dataGridView2.Rows[0].Cells[0].Value);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            accessoryOrderID = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value);
        }
    }
}
