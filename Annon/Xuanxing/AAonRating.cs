using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityFrameworkTryBLL.OrderManager;
using Model.Order;

namespace Annon.Xuanxing
{
    public partial class AAonRating : Form
    {
        int findclicktimes = 0;
        public static AAonRating aaon; //获得这个类对象的实例
        orders order = new orders();//新建一个order的对象;
       
        public ordersinfo OrderInfo = new ordersinfo();
        public List<ordersinfo> ll = new List<ordersinfo>();

        public bool AddOrder = true;//true 的时候添加订单，false的时候修改订单;
        public int RowIndex;// 双击datagridview1的行号;


        public AAonRating()
        {
            InitializeComponent();
            aaon = this; //获得AAonRating的实例对象 用于窗口间交互
            dataGridView1.AutoGenerateColumns = false;
            panel3.Visible = false;
            panel4.Top = panel1.Top + panel1.Height;

            panel7.Controls.Clear();
            orders order = new orders();
            order.TopLevel = false;
            order.Parent = panel7;
            order.Dock = DockStyle.Fill;
            order.Show();
            panel7.Dock = DockStyle.Fill;
            button9.Dock = DockStyle.Bottom;
            this.button8.Dock = DockStyle.Top;

            this.Height = panel1.Top + panel1.Height + panel2.Height + panel4.Height;

            chose_comboBox.SelectedIndex = 0;

            //显示初始订单信息;
            ll = OrderBLL.GetAllOrder();
            dataGridView1.DataSource = ll;

            //OrderInfo.OrderNo = 0;
            //OrderInfo.ordersinfoID = 0;
        }


        private void hBMasterSpecsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
               // this.textbox.text = this.openFileDialog1.FileName;
            }  

        }

        private void aboutAAONEcat32ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex.ToString();
            comboBox1.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tmp;
            tmp = chose_comboBox.SelectedItem.ToString();
            if(tmp!="Search In")
                chose_textBox.Text = chose_comboBox.SelectedItem.ToString();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            panel7.Controls.Clear();
            order.TopLevel = false;
            order.Parent = panel7;
            order.Dock = DockStyle.Fill;
            order.Show();

            panel7.Dock = DockStyle.Fill;
            button8.Dock = DockStyle.Top;
            this.button9.Dock = DockStyle.Bottom;

           

        }

        private void button9_Click(object sender, EventArgs e)
        {

            panel7.Controls.Clear();
            ordersummary ordersum = new ordersummary();
            ordersum.TopLevel = false;
            ordersum.Parent = panel7;
            ordersum.Show();

            panel7.Dock = DockStyle.Fill;
            button9.Dock = DockStyle.Top;
            this.button8.Dock = DockStyle.Top;
 
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //RowIndex = dataGridView1.CurrentCell.RowIndex;//得到双击的Row的index;
            label3.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            AddOrder = false;
            List<ordersinfo> TmpOrder = new List<ordersinfo>();
            orderImformation NewOrdInfo = new orderImformation();
            
            TmpOrder = OrderBLL.getOrders(RowIndex+1);

            

            NewOrdInfo.Jobno_textBox.Text = TmpOrder.First().JobNum;
            NewOrdInfo.JobName_textBox.Text = TmpOrder.First().JobName;
            NewOrdInfo.jobDes_textBox.Text = TmpOrder.First().JobDes;
            NewOrdInfo.Name_comboBox.Text = TmpOrder.First().Customer;
            NewOrdInfo.site_numericUpDown.Value = TmpOrder.First().Site;
            NewOrdInfo.AAONContact_comboBox.Text = TmpOrder.First().AAonCon;

            NewOrdInfo.Show();
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowIndex = dataGridView1.CurrentCell.RowIndex;
            //AddOrder = false;
            label3.Text = RowIndex + "";
        }

        private void btn_find_Click_1(object sender, EventArgs e)
        {
            findclicktimes++;
            int tmp = panel4.Top;

            if (findclicktimes % 2 == 1)
            {
                panel3.Visible = true;
                panel4.Top = tmp + panel3.Height;
            }
            else
            {
                panel3.Visible = false;
                panel4.Top = tmp - panel3.Height;
            }
        }


    }
       

        
}
