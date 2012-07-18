using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Annon.Xuanxing
{
    public partial class orderImformation : Form
    {
     
        public orderImformation()
        {
            InitializeComponent();
            billing bill = new billing();
            bill.TopLevel = false;
            bill.Parent = orderImformationPanel;
            bill.Dock = DockStyle.Fill;
            bill.Show();
        }

        private void orderImformation_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            orderImformationPanel.Controls.Clear();
            //billing_button.Font = new Font(billing_button.Font.FontFamily, billing_button.Font.Size-2, FontStyle.Bold);   
            billing bill = new billing();
            bill.TopLevel = false;
            bill.Parent = orderImformationPanel;
            bill.Dock = DockStyle.Fill;
            bill.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            orderImformationPanel.Controls.Clear();
            shipping ship = new shipping();
            ship.TopLevel = false;
            ship.Parent = orderImformationPanel;
            ship.Dock = DockStyle.Fill;
            ship.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            orderImformationPanel.Controls.Clear();
            notes note = new notes();
            note.TopLevel = false;
            note.Parent = orderImformationPanel;
            note.Dock = DockStyle.Fill;
            note.Show();

        }

        private void pricing_button_Click(object sender, EventArgs e)
        {
            orderImformationPanel.Controls.Clear();
            pricing price = new pricing();
            price.TopLevel = false;
            price.Parent = orderImformationPanel;
            price.Dock = DockStyle.Fill;
            price.Show();
        }


        private void OK_button_Click(object sender, EventArgs e)
        {

        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public struct orderDetialInfo
    {
        private string job_No;   //订单编号
        private string job_Name; //订单名称
        private string job_Des;  //订单描述
        public int No;           //订单顺序编号
        public int site_num;     
        public string sold_name; //客户名称
        public string now_date;  //建立订单日期

    }
}
