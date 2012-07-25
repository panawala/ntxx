﻿using System;
using System.Collections.Generic;
using System.Collections;
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
        public orderDetailInfo OrderInfoDtl = new orderDetailInfo();
        public List<ordersinfo> ll = new List<ordersinfo>();
        public List<orderDetailInfo> llDtl = new List<orderDetailInfo>();

        public int OrderRowNo;//订单在datagridview1的行号;
        public int TmpRowIndex;//当前订单行号;

        public int OrderDtlRowNo;//订单在datagridview2的行号;


        public bool AddOrder = true;//true 的时候添加订单，false的时候修改订单;

        public int RowIndex;//保存订单ID号
        public int RowIndexDGV2;//保存详细订单ID号，即datagridview2订单的ID号

        public bool DGV1BePush = false;//记录datagridview1是否被点击了;
        public bool DVG2BePush = false;//记录datagridview2是否被点击了;

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
            btn_ordersummary.Dock = DockStyle.Bottom;
            this.btn_order.Dock = DockStyle.Top;

            this.Height = panel1.Top + panel1.Height + panel3.Height + panel4.Height;

            chose_comboBox.SelectedIndex = 0;

            //显示初始订单信息;
            ll = OrderBLL.GetAllOrder();
            dataGridView1.DataSource = ll;
            //返回最新添加的订单ID号
            if (ll.Count != 0)
            {
                OrderRowNo = ll.Last().OrderNo;
            }
            //显示初始的订单详情信息;

            llDtl = OrderDetailBLL.GetAllOrderDetail();
            dataGridView2.DataSource = llDtl;

            if (llDtl.Count != 0)
            {
                OrderDtlRowNo = llDtl.Last().OdDetlNum;
            }
            
        }
        
        private void openDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
               // this.textbox.text = this.openFileDialog1.FileName;
            }  

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            cb_lookfor.SelectedIndex.ToString();
            cb_lookfor.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tmp;
            tmp = chose_comboBox.SelectedItem.ToString();
            if(tmp!="Search In")
                chose_textBox.Text = chose_comboBox.SelectedItem.ToString();
        }


        //双击datagridview1选中一行;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                RowIndex = (int)dataGridView1.Rows[e.RowIndex].Cells[9].Value;//通过设置一个不可见的datagridview单元格,得到双击行的ID号;
                AddOrder = false; //值为false时进行修改订单操作;
                orderImformation NewOrdInfo = new orderImformation();

                //获取选中行的订单信息;
                NewOrdInfo.TmpOrder = OrderBLL.getOrders(RowIndex);
                NewOrdInfo.Jobno_textBox.Text = NewOrdInfo.TmpOrder.First().JobNum;
                NewOrdInfo.JobName_textBox.Text = NewOrdInfo.TmpOrder.First().JobName;
                NewOrdInfo.jobDes_textBox.Text = NewOrdInfo.TmpOrder.First().JobDes;
                NewOrdInfo.Name_comboBox.Text = NewOrdInfo.TmpOrder.First().Customer;
                NewOrdInfo.site_numericUpDown.Value = NewOrdInfo.TmpOrder.First().Site;
                NewOrdInfo.AAONContact_comboBox.Text = NewOrdInfo.TmpOrder.First().AAonCon;

                NewOrdInfo.Show();
            }
        }

        //datagridview1中单击选中一行;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DGV1BePush = true;
                RowIndex = (int)dataGridView1.Rows[e.RowIndex].Cells[9].Value;//通过设置一个不可见的datagridview单元格,得到双击行的ID号;
                TmpRowIndex = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;//获得当前行的排序号
                show_datagridview2(RowIndex);
                label3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        //单击datagridview1选中一行，datagridview2中显示订单详细信息;
        public void show_datagridview2(int orderIdToDGV2) 
        {
            List<orderDetailInfo> OdDtalList = new List<orderDetailInfo>();
            OdDtalList = OrderDetailBLL.GetOrderDetail(orderIdToDGV2);
            dataGridView2.DataSource = OdDtalList;
        }

        //查找订单信息;
        private void btn_find_Click_1(object sender, EventArgs e)
        {
            findclicktimes++;
            int tmp = panel4.Top;

            if (findclicktimes % 2 == 1)
            {
                panel3.Visible = true;
                panel4.Top = tmp + panel3.Height;
                this.Height = panel4.Top + panel4.Height;
            }
            else
            {
                panel3.Visible = false;
                panel4.Top = tmp - panel3.Height;
                this.Height = panel4.Top + panel4.Height;
            }
        }

        private void AAonRating_Load(object sender, EventArgs e)
        {

        }
        //退出;
        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //选中order按钮,进行订单信息操作;
        private void btn_order_Click(object sender, EventArgs e)
        {
            panel7.Controls.Clear();
            order.TopLevel = false;
            order.Parent = panel7;
            order.Dock = DockStyle.Fill;
            order.Show();

            panel7.Dock = DockStyle.Fill;
            btn_order.Dock = DockStyle.Top;
            this.btn_ordersummary.Dock = DockStyle.Bottom;
        }

        //选中ordersummary按钮，进行订单详细信息操作;
        private void btn_ordersummary_Click(object sender, EventArgs e)
        {
            panel7.Controls.Clear();
            ordersummary ordersum = new ordersummary();
            ordersum.TopLevel = false;
            ordersum.Parent = panel7;
            ordersum.Show();

            panel7.Dock = DockStyle.Fill;
            btn_ordersummary.Dock = DockStyle.Top;
            this.btn_order.Dock = DockStyle.Top;
        }

        //单击datagridview2选中一行;
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                RowIndexDGV2 = (int)dataGridView2.Rows[e.RowIndex].Cells[7].Value;//等到详细订单在数据库的唯一ID;
                DVG2BePush = true;
            }
        }


        //获取鼠标点击；
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            panel7.Controls.Clear();
            order.TopLevel = false;
            order.Parent = panel7;
            order.Dock = DockStyle.Fill;
            order.Show();

            panel7.Dock = DockStyle.Fill;
            btn_order.Dock = DockStyle.Top;
            this.btn_ordersummary.Dock = DockStyle.Bottom;
        }

        //获取鼠标点击;
        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            panel7.Controls.Clear();
            ordersummary ordersum = new ordersummary();
            ordersum.TopLevel = false;
            ordersum.Parent = panel7;
            ordersum.Show();

            panel7.Dock = DockStyle.Fill;
            btn_ordersummary.Dock = DockStyle.Top;
            this.btn_order.Dock = DockStyle.Top;
        }

        //datagridview2双击事件;
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
        //清除查找内容;
        private void btn_clear_Click(object sender, EventArgs e)
        {
            cb_lookfor.Text = "";
            btn_clear.Enabled = false;

            //返回全部订单;
            List<ordersinfo> od = new List<ordersinfo>();
            od = OrderBLL.GetAllOrder();
            dataGridView1.DataSource = od;

            //返回全部订单信息;
            List<orderDetailInfo> odl = new List<orderDetailInfo>();
            odl = OrderDetailBLL.GetAllOrderDetail();
            dataGridView2.DataSource = odl;
        }

        //查找订单内容;
        private void btn_findNow_Click(object sender, EventArgs e)
        {
            string s = chose_comboBox.SelectedItem.ToString();
            btn_clear.Enabled = true;
            List<ordersinfo> odlist = new List<ordersinfo>();
            List<orderDetailInfo> odl = new List<orderDetailInfo>();
            odl = OrderDetailBLL.GetOrderDetail(odlist.First().ordersinfoID);
            if (s == "Job Number")
            {
                odlist = OrderBLL.FindOrderByJobNumber(cb_lookfor.Text);
                dataGridView1.DataSource = odlist;
            }

            if (s == "Job Name")
            {
                odlist = OrderBLL.FindOrderByJobName(cb_lookfor.Text);
                dataGridView1.DataSource = odlist;
            }

            if (s == "Descripition")
            {
                odlist = OrderBLL.FindOrderByDescription(cb_lookfor.Text);
                dataGridView1.DataSource = odlist;
            }

            if (s == "Customer Name")
            {
                odlist = OrderBLL.FindOrderByCustName(cb_lookfor.Text);
                dataGridView1.DataSource = odlist;
            }

            if (s == "AAON Contact")
            {
                odlist = OrderBLL.FindOrderByAAon(cb_lookfor.Text);
                dataGridView1.DataSource = odlist;
            }
            //if(s==null)
            //    return;
            
            //返回详细订单信息;
            
            dataGridView2.DataSource = odl;

            foreach (string ss in cb_lookfor.Items)
            {
                if (cb_lookfor.Text == ss)
                    return;
            }
            cb_lookfor.Items.Add(cb_lookfor.Text);
            
                
        }

    }
  
}