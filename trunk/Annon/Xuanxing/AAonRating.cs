using System;
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
using EntityFrameworkTryBLL.XuanxingManager;
using Model.Xuanxing;
using EntityFrameworkTryBLL.ZutuManager;
using Model.Zutu.ImageModel;
using Annon.Zutu.FrontPhoto;
using Model.Zutu;
using Annon.Zutu;
using EntityFrameworkTryBLL.UnitManager;


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
        public bool AddOrderDetail = true;//true的时候添加订单详情，false的时候修改订单详情

        public int RowIndex;//保存订单ID号
        public int RowIndexDGV2;//保存详细订单ID号，即datagridview2订单的ID号
        public int ModelOdId;
        public string qty_text;
        public int XuanXingType;//判断选型或选图,1为选型，2为选图
        public int DeviceID;

        public List<CatalogModel> CatModelList = new List<CatalogModel>();

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
            //OrderDtlRowNo = 1;
        }
        
        private void openDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputCurrentDataFromExcel icdfe = new InputCurrentDataFromExcel();
            icdfe.Show();
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
                //NewOrdInfo.AAONContact_comboBox.Text = NewOrdInfo.TmpOrder.First().AAonCon;

                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    if (row.Selected == true)
                //        RowIndex = (int)row.Cells[9].Value;
                //}
                NewOrdInfo.ShowInfoData(RowIndex);
                NewOrdInfo.Show();
            }
        }

        //datagridview1中单击选中一行;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
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
            AddOrder = true;
            AddOrderDetail = true;
            //显示初始订单信息;
            ll = OrderBLL.GetAllOrder();
            dataGridView1.DataSource = ll;
            //返回最新添加的订单ID号
            if (ll.Count != 0)
            {
                OrderRowNo = ll.Last().OrderNo;
            }


            //设置datagridview1的默认选中行
            foreach (DataGridViewRow dvg in dataGridView1.Rows)
            {
                if (dvg.Selected == true)
                {
                    RowIndex = (int)dvg.Cells[9].Value;
                    
                }
            }

            //显示初始的订单详情信息;
            llDtl = OrderDetailBLL.GetOrderDetail(RowIndex);
            dataGridView2.DataSource = llDtl;
            //返回最新添加的订单详情ID
            if (llDtl.Count != 0)
            {
                OrderDtlRowNo = llDtl.Last().OdDetlNum;
            }
            
            //设置datagridview2的默认选中行
            foreach(DataGridViewRow dvg in dataGridView2.Rows)
            {
                if (dvg.Selected == true)
                {
                    RowIndexDGV2 = (int)dvg.Cells[7].Value;
                    ModelOdId = (int)dvg.Cells[8].Value;
                }
            }
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
                ModelOdId = (int)dataGridView2.Rows[e.RowIndex].Cells[8].Value;
                //qty_text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                qty_text = "0";
                XuanXingType = (int)dataGridView2.Rows[e.RowIndex].Cells[10].Value;
            }
        }
        //datagridview2双击事件;
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (XuanXingType == 1)
                {
                    int ModelOrder = ModelOdId;
                    List<orderDetailInfo> OdDtl = new List<orderDetailInfo>();
                    CatalogBLL.copyOrderToCurrent(ModelOrder, 1);
                    XuanxingUI XuanXingUIForm = new XuanxingUI(ModelOrder);
                    XuanXingUIForm.tb_qty.Text = qty_text;
                    AddOrderDetail = false;
                    XuanXingUIForm.Show();
                }
                if (XuanXingType == 2)
                {
                    UnitBLL.copyOrderToCurrent(ModelOdId);
                    FrontPhotoImageModelService.route = "AAnonRating";
                    List<ImageModel> imageModelList = ImageModelBLL.getImageModels(ModelOdId);
                    List<ImageEntity> imageBoxList = FrontPhotoImageModelService.getImageEntityFromDataBase(imageModelList);
                    FrontPhotoImageModelService.imageEntityFromAAonRatingList = imageBoxList;
                    FrontPhotoImageModelService.orderId=ModelOdId;
                    List<CatalogModel> catalogModelList = UnitBLL.getPropertyModels(ModelOdId);
                    OperatePhotoNeedData tempOperatePhotoNeedData=new OperatePhotoNeedData();
                    for(int i=0;i<catalogModelList.Count;i++){
                       CatalogModel catalogModel=catalogModelList.ElementAt(i);
                       if(catalogModel.PropertyName.Equals("Unit Size")){
                           tempOperatePhotoNeedData.unitSize=catalogModel.Value;
                       }
                        else if(catalogModel.PropertyName.Equals("Base Rail")){
                            tempOperatePhotoNeedData.baseRail=catalogModel.Value;
                       }
                         else if(catalogModel.PropertyName.Equals("Painting")){
                             tempOperatePhotoNeedData.paining=catalogModel.Value;
                       }
                         else if(catalogModel.PropertyName.Equals("Special")){
                             tempOperatePhotoNeedData.uniteSpecial=catalogModel.Value;
                       }
                         else if(catalogModel.PropertyName.Equals("Supply Air Flow")){
                             tempOperatePhotoNeedData.supplyAirFlow=catalogModel.Value;
                       }
                         else if(catalogModel.PropertyName.Equals("Type")){
                             tempOperatePhotoNeedData.unitType=catalogModel.Value;
                       }
                         else if(catalogModel.PropertyName.Equals("Voltage")){
                             tempOperatePhotoNeedData.voltage=catalogModel.Value;
                       }
                         else if(catalogModel.PropertyName.Equals("Wiring")){
                             tempOperatePhotoNeedData.wring=catalogModel.Value;
                       }
                       else if (catalogModel.PropertyName.Equals("Assembly"))
                       {
                           tempOperatePhotoNeedData.assembly = catalogModel.Value;
                       }
                    }
                    tempOperatePhotoNeedData.orderID = ModelOdId;
                    FrontPhotoImageModelService.operatePhotoNeedData = tempOperatePhotoNeedData;
                    OperatePhoto operatePhoto = new OperatePhoto();
                    operatePhoto.setOperatePhotoNeedData(tempOperatePhotoNeedData, RowIndex);
                    operatePhoto.ShowDialog();
                }
            }

            //if (RowIndex <= 0)
            //{
            //    RowIndex = 1;
                
            //}
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
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected == true)
                    RowIndex = (int)row.Cells[9].Value;
            }
            List<orderDetailInfo> odl = new List<orderDetailInfo>();
            odl = OrderDetailBLL.GetOrderDetail(RowIndex);
            dataGridView2.DataSource = odl;
        }

        //查找订单内容;
        private void btn_findNow_Click(object sender, EventArgs e)
        {
            string s = chose_comboBox.SelectedItem.ToString();
            btn_clear.Enabled = true;
            List<ordersinfo> odlist = new List<ordersinfo>();
            List<orderDetailInfo> odl = new List<orderDetailInfo>();
           // odl = OrderDetailBLL.GetOrderDetail(odlist.First().ordersinfoID);
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

        private void btn_allDtl_Click(object sender, EventArgs e)
        {
            List<orderDetailInfo> odDtl = new List<orderDetailInfo>();
            odDtl = OrderDetailBLL.GetOrderDetail(RowIndex);
            dataGridView2.DataSource = odDtl;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btn_RmDTL_Click(object sender, EventArgs e)
        {

            List<orderDetailInfo> OdDtl = new List<orderDetailInfo>();
            OdDtl = OrderDetailBLL.GetOrderDtlDeviceID(RowIndex,1);
            dataGridView2.DataSource = OdDtl;
        }

        private void btn_M2Dtl_Click(object sender, EventArgs e)
        {
            List<orderDetailInfo> OdDtl = new List<orderDetailInfo>();
            OdDtl = OrderDetailBLL.GetOrderDtlDeviceID(RowIndex,2);
            dataGridView2.DataSource = OdDtl;
        }

    }
  
}
