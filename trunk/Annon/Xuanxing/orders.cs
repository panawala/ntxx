using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.Order;
using EntityFrameworkTryBLL.OrderManager;

namespace Annon.Xuanxing
{
    public partial class orders : Form
    {



        public orders()
        {
            InitializeComponent();
            //AAonRating.aaon.OrderInfo.ordersinfoID = 0;
           // AAonRating.aaon.OrderInfo.OrderNo = 0;
        }


        private void orders_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            orderImformation odInfo = new orderImformation();
            AAonRating.aaon.OrderInfo.ordersinfoID++;
            AAonRating.aaon.OrderInfo.OrderNo++;
            odInfo.Show();      
        }

        void odInfo_OrderInfoDelegateEvent(List<ordersinfo> Orderll)
        {
            //throw new NotImplementedException();
            
        }

      

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            orderImformation odInfo = new orderImformation();
            odInfo.Show();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SaveFileDialog op = new SaveFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                // this.textbox.text = this.openFileDialog1.FileName;
            }  
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                // this.textbox.text = this.openFileDialog1.FileName;
            }  
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //AAonRating.aaon.OrderInfo.OrderNo--;
           // OrderBLL.DeleteAllOrder();
            OrderBLL.DeleteOrder(AAonRating.aaon.RowIndex+1);
 
            List<ordersinfo> tmpList = new List<ordersinfo>();
            tmpList = OrderBLL.GetAllOrder();
            AAonRating.aaon.dataGridView1.DataSource = tmpList;
        }
 
    }
}
