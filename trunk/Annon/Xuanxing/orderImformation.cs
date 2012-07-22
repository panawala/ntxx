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
    public partial class orderImformation : Form
    {
        public List<ordersinfo> TmpOrder = new List<ordersinfo>();
        public orderImformation()
        {
            InitializeComponent();
            hours_comboBox.Text = 48+"";
            site_numericUpDown.Value = 100;
        }

        private void orderImformation_Load(object sender, EventArgs e)
        {
                
        }

        private void OK_button_Click(object sender, EventArgs e)
        {
           

            AAonRating.aaon.OrderInfo.JobNum = Jobno_textBox.Text;
            AAonRating.aaon.OrderInfo.JobName = JobName_textBox.Text;
            AAonRating.aaon.OrderInfo.JobDes = jobDes_textBox.Text;
            AAonRating.aaon.OrderInfo.Customer = Name_comboBox.Text;
            AAonRating.aaon.OrderInfo.Site = (int)site_numericUpDown.Value;
            //OrderInfo.OrderTotal =orderTotal_textBox.Text;
            AAonRating.aaon.OrderInfo.Activity = DateTime.Now.ToString("dd-MM-yyyy");
            AAonRating.aaon.OrderInfo.AAonCon = AAONContact_comboBox.Text;

           

            //新增订单信息传入数据库;
            if (AAonRating.aaon.AddOrder)
            {
                
                OrderBLL.InsertIntoOrder(AAonRating.aaon.OrderInfo.ordersinfoID,AAonRating.aaon.OrderRowNo ,AAonRating.aaon.OrderInfo.JobNum, AAonRating.aaon.OrderInfo.JobName, AAonRating.aaon.OrderInfo.JobDes, AAonRating.aaon.OrderInfo.Site, AAonRating.aaon.OrderInfo.Customer, AAonRating.aaon.OrderInfo.Activity, AAonRating.aaon.OrderInfo.AAonCon);

            }

            //修改订单信息;
            if (!AAonRating.aaon.AddOrder)
            {
                OrderBLL.ModifyOrder(TmpOrder.First().ordersinfoID, TmpOrder.First().OrderNo,Jobno_textBox.Text,JobName_textBox.Text,jobDes_textBox.Text, (int)(site_numericUpDown.Value),Name_comboBox.Text, TmpOrder.First().Activity,AAONContact_comboBox.Text);
                AAonRating.aaon.AddOrder = true;
            }

            //从数据库获取订单信息;

            AAonRating.aaon.ll = OrderBLL.GetAllOrder();
            AAonRating.aaon.dataGridView1.DataSource = AAonRating.aaon.ll;
           // ll2 = OrderBLL.GetAllOrder();

           
            this.Close();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            //Font newFont, oldFont;
            //oldFont = tabPage1.Font;
            //if (oldFont.Bold)
            //    newFont = new Font(oldFont, oldFont.Style ^ FontStyle.Bold);
            //else
            //    newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);
            //tabPage1.Font = newFont;
            //tabPage1.Focus();
        }

    }

    

}
