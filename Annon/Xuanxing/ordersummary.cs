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
using EntityFrameworkTryBLL.XuanxingManager;
using Annon.Zutu.FrontPhoto;
using Model.Zutu.ImageModel;
using EntityFrameworkTryBLL.ZutuManager;
using Model.Zutu;
using Model.Xuanxing;
using EntityFrameworkTryBLL.UnitManager;
using Annon.Zutu;

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
            AAonRating.aaon.RowIndexDGV2++;
            AddNewUnit ANU = new AddNewUnit();
            
            ANU.OrderSale = AAonRating.aaon.RowIndex;
            ANU.Show();
        }

        //修改详细订单信息;
        private void btn_editDetail_Click(object sender, EventArgs e)
        {
            //设置datagridview2的默认行
            foreach (DataGridViewRow dvg in AAonRating.aaon.dataGridView2.Rows)
            {
                if (dvg.Selected == true)
                {
                    AAonRating.aaon.RowIndexDGV2 = (int)dvg.Cells[7].Value;
                    AAonRating.aaon.XuanXingType = (int)dvg.Cells[10].Value;
                }
            }

            //弹出选型窗口
            if (AAonRating.aaon.XuanXingType == 1)
            {
                int ModelID = AAonRating.aaon.ModelOdId;
                CatalogBLL.copyOrderToCurrent(ModelID, 1);
                XuanxingUI XxUI = new XuanxingUI(ModelID);
                XxUI.tb_qty.Text = AAonRating.aaon.qty_text;
                AAonRating.aaon.AddOrderDetail = false;
                XxUI.Show();
            }

            //弹出选图窗口
            if (AAonRating.aaon.XuanXingType == 2) 
            {
                FrontPhotoImageModelService.route = "AAnonRating";
                List<ImageModel> imageModelList = ImageModelBLL.getImageModels(AAonRating.aaon.ModelOdId);
                List<ImageEntity> imageBoxList = FrontPhotoImageModelService.getImageEntityFromDataBase(imageModelList);
                FrontPhotoImageModelService.imageEntityFromAAonRatingList = imageBoxList;
                FrontPhotoImageModelService.orderId = AAonRating.aaon.ModelOdId;
                List<CatalogModel> catalogModelList = UnitBLL.getPropertyModels(AAonRating.aaon.ModelOdId);
                OperatePhotoNeedData tempOperatePhotoNeedData = new OperatePhotoNeedData();
                for (int i = 0; i < catalogModelList.Count; i++)
                {
                    CatalogModel catalogModel = catalogModelList.ElementAt(i);
                    if (catalogModel.PropertyName.Equals("Unit Size"))
                    {
                        tempOperatePhotoNeedData.unitSize = catalogModel.Value;
                    }
                    else if (catalogModel.PropertyName.Equals("Base Rail"))
                    {
                        tempOperatePhotoNeedData.baseRail = catalogModel.Value;
                    }
                    else if (catalogModel.PropertyName.Equals("Painting"))
                    {
                        tempOperatePhotoNeedData.paining = catalogModel.Value;
                    }
                    else if (catalogModel.PropertyName.Equals("Special"))
                    {
                        tempOperatePhotoNeedData.uniteSpecial = catalogModel.Value;
                    }
                    else if (catalogModel.PropertyName.Equals("Supply Air Flow"))
                    {
                        tempOperatePhotoNeedData.supplyAirFlow = catalogModel.Value;
                    }
                    else if (catalogModel.PropertyName.Equals("Type"))
                    {
                        tempOperatePhotoNeedData.unitType = catalogModel.Value;
                    }
                    else if (catalogModel.PropertyName.Equals("Voltage"))
                    {
                        tempOperatePhotoNeedData.voltage = catalogModel.Value;
                    }
                    else if (catalogModel.PropertyName.Equals("Wiring"))
                    {
                        tempOperatePhotoNeedData.wring = catalogModel.Value;
                    }
                }
                FrontPhotoImageModelService.operatePhotoNeedData = tempOperatePhotoNeedData;
                OperatePhoto operatePhoto = new OperatePhoto();
                operatePhoto.setOperatePhotoNeedData(tempOperatePhotoNeedData, AAonRating.aaon.ModelOdId);
                operatePhoto.ShowDialog();

            }
        }

        //复制一条详细订单信息;
        private void btn_cpyDetail_Click(object sender, EventArgs e)
        {

            //设置datagridview2的默认行
            foreach (DataGridViewRow dvg in AAonRating.aaon.dataGridView2.Rows)
            {
                if (dvg.Selected == true){
                    AAonRating.aaon.RowIndexDGV2 = (int)dvg.Cells[7].Value;
                    AAonRating.aaon.XuanXingType=(int)dvg.Cells[10].Value;
                }
            }

            //选型的copy
            if (AAonRating.aaon.XuanXingType == 1)
            {
                int newOrderID = CatalogBLL.copyOrder(AAonRating.aaon.ModelOdId);
                //CatalogBLL.copyOrder(AAonRating.aaon.ModelOdId)
                OrderDetailBLL.CopyOrderDetail(AAonRating.aaon.RowIndexDGV2, newOrderID);
            }

            //选图的copy
            if (AAonRating.aaon.XuanXingType == 2)
            {
                int newOrderID = UnitBLL.copyOrder(AAonRating.aaon.ModelOdId);
                OrderDetailBLL.CopyOrderDetail(AAonRating.aaon.RowIndexDGV2, newOrderID);
                ImageModelBLL.copyOrder(AAonRating.aaon.ModelOdId, newOrderID);
                ContentBLL.copyOrder(AAonRating.aaon.ModelOdId, newOrderID);
            }

            List<orderDetailInfo> od = new List<orderDetailInfo>();
            od = OrderDetailBLL.GetOrderDetail(AAonRating.aaon.RowIndex);
            AAonRating.aaon.dataGridView2.DataSource = od;

        }

        //删除详细订单信息;
        private void btn_DelDetail_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you would like to delete the Item?", "Delete Item Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
            {
                OrderDetailBLL.DeleteOrderDetail(AAonRating.aaon.RowIndexDGV2);

                List<orderDetailInfo> od = new List<orderDetailInfo>();
                od = OrderDetailBLL.GetOrderDetail(AAonRating.aaon.RowIndex);
                AAonRating.aaon.dataGridView2.DataSource = od;
                //设置datagridview2的默认选中行
                foreach (DataGridViewRow dvg in AAonRating.aaon.dataGridView2.Rows)
                {
                    if (dvg.Selected == true)
                        AAonRating.aaon.RowIndexDGV2 = (int)dvg.Cells[7].Value;
                }
            }

        }


    }
}
