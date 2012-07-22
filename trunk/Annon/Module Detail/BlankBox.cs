using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Model.Zutu.Content;
using EntityFrameworkTryBLL.ZutuManager;

namespace Annon.Module_Detail
{
    public partial class BlankBox : Form
    {
        public BlankBox()
        {
            InitializeComponent();
        }

        private void BlankBox_Load(object sender, EventArgs e)
        {

        }

        public List<ContentPropertyValue> GetData(int Cooling, string ImgageName, int orderId, string propertyName, string ModuleTag)
        {
            int coolingID = Cooling;
            string ImgID = ImgageName;
            int OrderID = orderId;
            string moduletag = ModuleTag;
            List<ContentPropertyValue> DetailData = ContentBLL.getPtyValue(coolingID, ImgID,orderId, propertyName,ModuleTag);
            return DetailData;
        }


        public void InitialValue(ImgItem imgItem,int type)
        {
            //保存窗体信息


            textBoxTag.Text = imgItem.ModuleTag;

            if (type != 1)
            {
                List<ContentPropertyValue> cbBoxAW_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "AIRWAY TYPE", imgItem.ModuleTag);
                cbBoxAW.SelectedIndexChanged -= new EventHandler(cbBoxAW_SelectedIndexChanged);
                cbBoxAW.DataSource = cbBoxAW_Data;
                cbBoxAW.DisplayMember = "ValueDescription";
                cbBoxAW.SelectedIndex = -1;
                cbBoxAW.ValueMember = "Value"; ;
                cbBoxAW.Text = cbBoxAW_Data.First().Default;
                cbBoxAW.SelectedIndexChanged += new EventHandler(cbBoxAW_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxSf_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "SAFETY CONTROL", imgItem.ModuleTag);
                cbBoxSf.SelectedIndexChanged -= new EventHandler(cbBoxSf_SelectedIndexChanged);
                cbBoxSf.DataSource = cbBoxSf_Data;
                cbBoxSf.DisplayMember = "ValueDescription";
                cbBoxSf.SelectedIndex = -1;
                cbBoxSf.ValueMember = "Value";
                cbBoxSf.Text = cbBoxSf_Data.First().Default;
                cbBoxSf.SelectedIndexChanged += new EventHandler(cbBoxSf_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxDP_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "DRAIN PAN TYPE", imgItem.ModuleTag);
                cbBoxDP.SelectedIndexChanged -= new EventHandler(cbBoxDP_SelectedIndexChanged);
                cbBoxDP.DataSource = cbBoxDP_Data;
                cbBoxDP.DisplayMember = "ValueDescription";
                cbBoxDP.SelectedIndex = -1;
                cbBoxDP.ValueMember = "Value";
                cbBoxDP.Text = cbBoxDP_Data.First().Default;
                cbBoxDP.SelectedIndexChanged += new EventHandler(cbBoxDP_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxSp_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "TYPE", imgItem.ModuleTag);
                cbBoxSp.SelectedIndexChanged -= new EventHandler(cbBoxSp_SelectedIndexChanged);
                cbBoxSp.DataSource = cbBoxSp_Data;
                cbBoxSp.DisplayMember = "ValueDescription";
                cbBoxSp.SelectedIndex = -1;
                cbBoxSp.ValueMember = "Value";
                cbBoxSp.Text = cbBoxSp_Data.First().Default;
                cbBoxSp.SelectedIndexChanged += new EventHandler(cbBoxSp_SelectedIndexChanged);
            }

            moduleTag = imgItem.ModuleTag;
            cooling = imgItem.CoolingPower;
            imageName = imgItem.ImgageName;
            order = imgItem.OrderID;
        }

        //重新绑定数据
        public void BoundValue(List<ContentPropertyValue> boundData)
        {
                //textBoxTag.Text = ChangedOveroad.ModuleTag;
               foreach (ContentPropertyValue propertyname in boundData)
               {
                   if (propertyname.PropertyName == "AIRWAY TYPE")
                   {
                       List<ContentPropertyValue> cbBoxAW_Data = boundData;
                       cbBoxAW.SelectedIndexChanged -= new EventHandler(cbBoxAW_SelectedIndexChanged);
                       cbBoxAW.DataSource = cbBoxAW_Data;
                       cbBoxAW.DisplayMember = "ValueDescription";
                       cbBoxAW.SelectedIndex = -1;
                       cbBoxAW.ValueMember = "Value"; ;
                       cbBoxAW.Text = cbBoxAW_Data.First().Default;
                       cbBoxAW.SelectedIndexChanged += new EventHandler(cbBoxAW_SelectedIndexChanged);
                   }
                   if (propertyname.PropertyName == "SAFETY CONTROL")
                   {

                       List<ContentPropertyValue> cbBoxSf_Data = boundData;
                       cbBoxSf.SelectedIndexChanged -= new EventHandler(cbBoxSf_SelectedIndexChanged);
                       cbBoxSf.DataSource = cbBoxSf_Data;
                       cbBoxSf.DisplayMember = "ValueDescription";
                       cbBoxSf.SelectedIndex = -1;
                       cbBoxSf.ValueMember = "Value";
                       cbBoxSf.Text = cbBoxSf_Data.First().Default;
                       cbBoxSf.SelectedIndexChanged += new EventHandler(cbBoxSf_SelectedIndexChanged);
                   }
                   if (propertyname.PropertyName == "DRAIN PAN TYPE")
                   {

                       List<ContentPropertyValue> cbBoxDP_Data = boundData;
                       cbBoxDP.SelectedIndexChanged -= new EventHandler(cbBoxDP_SelectedIndexChanged);
                       cbBoxDP.DataSource = cbBoxDP_Data;
                       cbBoxDP.DisplayMember = "ValueDescription";
                       cbBoxDP.SelectedIndex = -1;
                       cbBoxDP.ValueMember = "Value";
                       cbBoxDP.Text = cbBoxDP_Data.First().Default;
                       cbBoxDP.SelectedIndexChanged += new EventHandler(cbBoxDP_SelectedIndexChanged);
                   }

                   if (propertyname.PropertyName == "TYPE")
                   {
                       List<ContentPropertyValue> cbBoxSp_Data = boundData;
                       cbBoxSp.SelectedIndexChanged -= new EventHandler(cbBoxSp_SelectedIndexChanged);
                       cbBoxSp.DataSource = cbBoxSp_Data;
                       cbBoxSp.DisplayMember = "ValueDescription";
                       cbBoxSp.SelectedIndex = -1;
                       cbBoxSp.ValueMember = "Value";
                       cbBoxSp.Text = cbBoxSp_Data.First().Default;
                       cbBoxSp.SelectedIndexChanged += new EventHandler(cbBoxSp_SelectedIndexChanged);
                   }
               }

        }

        ImgItem ChangedOveroad;//用于更改数据后，重新加载数据
        public void OveroadForm(ImgItem item)
        {
            ChangedOveroad = item;
        }

        //获取窗体的数据，更新订单信息
        string moduleTag;
        int cooling;
        string imageName;
        int order;

        private void cbBoxAW_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbBoxAW.SelectedIndex!= -1)
            {
                ContentBLL.SaveImageOrder(moduleTag,cooling,imageName,order,cbBoxAW.Tag.ToString(),cbBoxAW.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData=ContentBLL.getAllByCondition("AIRWAY TYPE",ChangedOveroad.OrderID,ChangedOveroad.CoolingPower,ChangedOveroad.ImgageName,ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
            }
            
        }

        private void cbBoxSf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxSf.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxSf.Tag.ToString(), cbBoxSf.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("SAFETY CONTROL", 1, 5,"BBA", "102-113");
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
            }
        }

        private void cbBoxDP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxDP.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxDP.Tag.ToString(), cbBoxDP.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("DRAIN PAN TYPE", ChangedOveroad.OrderID, ChangedOveroad.CoolingPower, ChangedOveroad.ImgageName, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
            }
        }

        private void cbBoxSp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxSp.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxSp.Tag.ToString(), cbBoxSp.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("TYPE", ChangedOveroad.OrderID, ChangedOveroad.CoolingPower, ChangedOveroad.ImgageName, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
            }
        }
 
    }
}
