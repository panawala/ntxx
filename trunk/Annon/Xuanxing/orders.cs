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
        }


        private void orders_Load(object sender, EventArgs e)
        {
            
        }

        void odInfo_OrderInfoDelegateEvent(List<ordersinfo> Orderll)
        {
            //throw new NotImplementedException();
            
        }

        //用于调试测验，可以把数据库中全部订单删除;
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    OrderBLL.DeleteAllOrder();
        //    List<ordersinfo> tmpList = new List<ordersinfo>();
        //    tmpList = OrderBLL.GetAllOrder();
        //    AAonRating.aaon.dataGridView1.DataSource = tmpList;
        //}
        //点击增加订单按钮;
        private void btn_add_Click(object sender, EventArgs e)
        {
            orderImformation odInfo = new orderImformation();
            AAonRating.aaon.OrderInfo.ordersinfoID++;//订单ID增加

            //判断是否有delete订单 有的话从删除掉的订单号开始增加;
            if (AAonRating.aaon.DelOrder==true&&AAonRating.aaon.DelOrderNum>0)
            {
                AAonRating.aaon.OrderRowNo =(int)AAonRating.aaon.DelOrderList[AAonRating.aaon.DelOrderNum-1];
                AAonRating.aaon.DelOrderList.RemoveAt(AAonRating.aaon.DelOrderNum - 1);
                AAonRating.aaon.DelOrderNum--;

            }
            
            else
            {
                AAonRating.aaon.DelOrder = false;
                AAonRating.aaon.DelOrderNum = 0;
                //AAonRating.aaon.OrderRowNo = AAonRating.aaon.MaxOrderRowNo;
                AAonRating.aaon.OrderRowNo++;
            }
            odInfo.Show(); 
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            AAonRating.aaon.AddOrder = false;
            //List<ordersinfo> TmpOrder = new List<ordersinfo>();
            orderImformation NewOrdInfo = new orderImformation();
            

            //得到选定行的订单信息并显示在对话框上;
            NewOrdInfo.TmpOrder = OrderBLL.getOrders(AAonRating.aaon.RowIndex);
            NewOrdInfo.Jobno_textBox.Text = NewOrdInfo.TmpOrder.First().JobNum;
            NewOrdInfo.JobName_textBox.Text = NewOrdInfo.TmpOrder.First().JobName;
            NewOrdInfo.jobDes_textBox.Text = NewOrdInfo.TmpOrder.First().JobDes;
            NewOrdInfo.Name_comboBox.Text = NewOrdInfo.TmpOrder.First().Customer;
            NewOrdInfo.site_numericUpDown.Value = NewOrdInfo.TmpOrder.First().Site;
            NewOrdInfo.AAONContact_comboBox.Text = NewOrdInfo.TmpOrder.First().AAonCon;
            NewOrdInfo.Show();
            ////获取修改信息修改订单
            //if (OrderBLL.ModifyOrder(NewOrdInfo.TmpOrder.First().ordersinfoID, TmpOrder.First().OrderNo, NewOrdInfo.Jobno_textBox.Text, NewOrdInfo.JobName_textBox.Text, NewOrdInfo.jobDes_textBox.Text, (int)(NewOrdInfo.site_numericUpDown.Value), NewOrdInfo.Name_comboBox.Text, TmpOrder.First().Activity, NewOrdInfo.AAONContact_comboBox.Text) != -1)
            //{
            //    TmpOrder = OrderBLL.GetAllOrder();
            //    AAonRating.aaon.dataGridView1.DataSource = TmpOrder;
                
            //}
            

        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            OrderBLL.CopyOrder(AAonRating.aaon.RowIndex);

            List<ordersinfo> tmpList = new List<ordersinfo>();
            tmpList = OrderBLL.GetAllOrder();
            AAonRating.aaon.dataGridView1.DataSource = tmpList;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            AAonRating.aaon.DelOrder = true;

            AAonRating.aaon.DelOrderList.Add(AAonRating.aaon.TmpRowIndex);
            AAonRating.aaon.DelOrderList.Sort();
            AAonRating.aaon.DelOrderList.Reverse();
            AAonRating.aaon.DelOrderNum++;
            
            OrderBLL.DeleteOrder(AAonRating.aaon.RowIndex);
            List<ordersinfo> tmpList = new List<ordersinfo>();
            tmpList = OrderBLL.GetAllOrder();
            AAonRating.aaon.dataGridView1.DataSource = tmpList;
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            SaveFileDialog op = new SaveFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                // this.textbox.text = this.openFileDialog1.FileName;
            }  
        }

        private void btn_imput_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                // this.textbox.text = this.openFileDialog1.FileName;
            }  
        }


    }
}
