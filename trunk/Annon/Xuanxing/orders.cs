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
        private void button1_Click(object sender, EventArgs e)
        {
          
        }
        //点击增加订单按钮;
        private void btn_add_Click(object sender, EventArgs e)
        {
            orderImformation odInfo = new orderImformation();
            AAonRating.aaon.OrderRowNo++;
            odInfo.Show(); 
        }

        //修改订单信息;
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
        }

        //复制订单信息;
        private void btn_copy_Click(object sender, EventArgs e)
        {
            OrderBLL.CopyOrder(AAonRating.aaon.RowIndex);
            List<ordersinfo> tmpList = new List<ordersinfo>();
            tmpList = OrderBLL.GetAllOrder();
            AAonRating.aaon.dataGridView1.DataSource = tmpList;
        }   

        //删除订单信息;
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you would like to delete the Order?", "Delete Order Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
            {
                if (OrderBLL.ModifyNum(AAonRating.aaon.RowIndex) != -1)
                {
                    OrderBLL.DeleteOrder(AAonRating.aaon.RowIndex);
                    List<ordersinfo> tmpList = new List<ordersinfo>();
                    tmpList = OrderBLL.GetAllOrder();
                    AAonRating.aaon.dataGridView1.DataSource = tmpList;
                    AAonRating.aaon.OrderRowNo = OrderBLL.ReturnLastNum();

                    //删除相应的订单详情信息;
                    List<orderDetailInfo> OrderDTL = new List<orderDetailInfo>();
                    if (OrderDetailBLL.DeleteOneOrderAllDetail(AAonRating.aaon.RowIndex) != -1)
                    {
                        OrderDTL = OrderDetailBLL.GetAllOrderDetail();
                        AAonRating.aaon.dataGridView2.DataSource = OrderDTL;
                    }
                }
            }
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
