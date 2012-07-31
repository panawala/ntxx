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
            //rep4_comboBox.BackColor = Color.LightGray;
            //rep4_label.BackColor = Color.LightGray;
            RTP_radioButton.Checked = true;
            allow_radioButton.Checked = true;

            site_numericUpDown.Value = 100;
            site_numericUpDown.Maximum = 10000000;
            site_numericUpDown.Minimum = -10000000;
            site_numericUpDown.Increment = 50;

            ID_textBox.Enabled = false;
            ID_textBox.BackColor = Color.LightGray;

            shipdate_dateTimePicker.Format = DateTimePickerFormat.Custom;
            shipdate_dateTimePicker.CustomFormat = "yyyy-MM-dd";

            rep1_textBox.BackColor = Color.LightGray;
            rep1_textBox.Text = 100+"";
            rep2_textBox.BackColor = Color.LightGray;
            rep2_textBox.Text = 0 + "";
            rep3_textBox.BackColor = Color.LightGray;
            rep3_textBox.Text = 0 + "";
            rep4_textBox.BackColor = Color.LightGray;
            rep4_textBox.Text = 0 + "";

            repMul_textBox.Text= 1.0 + "";

            tax_radioButton.Checked = true;

            commission_textBox.BackColor = Color.LightGoldenrodYellow;
            orderTotal_textBox.BackColor = Color.LightGoldenrodYellow;
            //markup_textBox.BackColor = Color.LightGoldenrodYellow;
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
                AAonRating.aaon.OrderRowNo++;
                OrderBLL.InsertIntoOrder(AAonRating.aaon.OrderRowNo ,AAonRating.aaon.OrderInfo.JobNum, AAonRating.aaon.OrderInfo.JobName, AAonRating.aaon.OrderInfo.JobDes, AAonRating.aaon.OrderInfo.Site, AAonRating.aaon.OrderInfo.Customer, AAonRating.aaon.OrderInfo.Activity, AAonRating.aaon.OrderInfo.AAonCon);

            }

            //修改订单信息;
            if (!AAonRating.aaon.AddOrder)
            {
                if (TmpOrder.Count > 0)
                {
                    OrderBLL.ModifyOrder(TmpOrder.First().ordersinfoID, TmpOrder.First().OrderNo, Jobno_textBox.Text, JobName_textBox.Text, jobDes_textBox.Text, (int)(site_numericUpDown.Value), Name_comboBox.Text, TmpOrder.First().Activity, AAONContact_comboBox.Text);
                    AAonRating.aaon.AddOrder = true;
                }
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

        private void tax_radioButton_MouseClick(object sender, MouseEventArgs e)
        {
            ID_textBox.Enabled = false;
            ID_textBox.BackColor = Color.LightGray;
        }

        private void nonTax_radioButton_MouseClick(object sender, MouseEventArgs e)
        {
            ID_textBox.Enabled = true;
            ID_textBox.BackColor = Color.White;
        }

        private void markup_textBox_MouseClick(object sender, MouseEventArgs e)
        {
            commission_textBox.BackColor = Color.LightGoldenrodYellow;
            commission_textBox.Clear();
            orderTotal_textBox.BackColor = Color.LightGoldenrodYellow;
            orderTotal_textBox.Clear();
            markup_textBox.BackColor = Color.White;
            
        }

        private void commission_textBox_MouseClick(object sender, MouseEventArgs e)
        {
            commission_textBox.BackColor = Color.White;
            orderTotal_textBox.BackColor = Color.LightGoldenrodYellow;
            orderTotal_textBox.Clear();
            markup_textBox.BackColor = Color.LightGoldenrodYellow;
            markup_textBox.Clear();
        }

        private void orderTotal_textBox_MouseClick(object sender, MouseEventArgs e)
        {
            commission_textBox.BackColor = Color.LightGoldenrodYellow;
            commission_textBox.Clear();
            orderTotal_textBox.BackColor = Color.White;
            markup_textBox.BackColor = Color.LightGoldenrodYellow;
            markup_textBox.Clear();
            
        }

        private void markup_textBox_TextChanged(object sender, EventArgs e)
        {

        }

    }

    

}
