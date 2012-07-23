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
    public partial class ordersummary : Form
    {
        DataTable dt = new DataTable();
        private int NO = 0;

        public ordersummary()
        {
            InitializeComponent();

        }

        private void ordersummary_Load(object sender, EventArgs e)
        {

        }

        private void btn_addNew_Click(object sender, EventArgs e)
        {
            AddNewUnit ANU = new AddNewUnit();
            ANU.OrderSale = AAonRating.aaon.RowIndex;
            ANU.Show();
        }

        //修改详细订单信息;
        private void btn_editDetail_Click(object sender, EventArgs e)
        {
            
        }

        //复制一条详细订单信息;
        private void btn_cpyDetail_Click(object sender, EventArgs e)
        {
            OrderDetailBLL.CopyOrderDetail(AAonRating.aaon.RowIndexDGV2);

            List<orderDetailInfo> od = new List<orderDetailInfo>();
            od = OrderDetailBLL.GetAllOrderDetail();
            AAonRating.aaon.dataGridView2.DataSource = od;
        }

        //删除详细订单信息;
        private void btn_DelDetail_Click(object sender, EventArgs e)
        {
         
            if (MessageBox.Show("Are you sure you would like to delete the Item?", "Delete Item Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
            {
                OrderDetailBLL.DeleteOrderDetail(AAonRating.aaon.RowIndexDGV2);

                List<orderDetailInfo> od = new List<orderDetailInfo>();
                od = OrderDetailBLL.GetAllOrderDetail();
                AAonRating.aaon.dataGridView2.DataSource = od;

            }
        }


    }
}
