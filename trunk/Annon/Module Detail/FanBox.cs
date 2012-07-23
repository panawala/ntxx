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
    public partial class FanBox : Form
    {
        public FanBox()
        {
            InitializeComponent();
        }

        private void FanBox_Load(object sender, EventArgs e)
        {

        }
        public List<ContentPropertyValue> GetData(int Cooling, string ImgageName, int orderId, string propertyName, string ModuleTag)
        {
            int coolingID = Cooling;
            string ImgID = ImgageName;
            int OrderID = orderId;
            string moduletag = ModuleTag;
            List<ContentPropertyValue> DetailData = ContentBLL.getPtyValue(coolingID, ImgID, orderId, propertyName, ModuleTag);
            return DetailData;
        }

        public void InitialValue(ImgItem imgItem,int type)
        {

            textBoxTag.Text = imgItem.ModuleTag;
            if (type != 1)
            {
                List<ContentPropertyValue> cbBoxMS_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "MOTOR SIZE", imgItem.ModuleTag);
                cbBoxMS.SelectedIndexChanged -= new EventHandler(cbBoxMS_SelectedIndexChanged);
                cbBoxMS.DataSource = cbBoxMS_Data;
                cbBoxMS.DisplayMember = "ValueDescription";
                cbBoxMS.SelectedIndex = -1;
                cbBoxMS.ValueMember = "Value";
                cbBoxMS.Text = cbBoxMS_Data.First().Default;
                cbBoxMS.SelectedIndexChanged += new EventHandler(cbBoxMS_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxMT_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "MOTOR TYPE", imgItem.ModuleTag);
                cbBoxMT.SelectedIndexChanged -= new EventHandler(cbBoxMT_SelectedIndexChanged);
                cbBoxMT.DataSource = cbBoxMT_Data;
                cbBoxMT.DisplayMember = "ValueDescription";
                cbBoxMT.SelectedIndex = -1;
                cbBoxMT.ValueMember = "Value";
                cbBoxMT.Text = cbBoxMT_Data.First().Default;
                cbBoxMT.SelectedIndexChanged += new EventHandler(cbBoxMT_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxSC_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "SAFETY CONTROL", imgItem.ModuleTag);
                cbBoxSC.SelectedIndexChanged -= new EventHandler(cbBoxSC_SelectedIndexChanged);
                cbBoxSC.DataSource = cbBoxSC_Data;
                cbBoxSC.DisplayMember = "ValueDescription";
                cbBoxSC.SelectedIndex = -1;
                cbBoxSC.ValueMember = "Value";
                cbBoxSC.Text = cbBoxSC_Data.First().Default;
                cbBoxSC.SelectedIndexChanged += new EventHandler(cbBoxSC_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxSp_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "TYPE", imgItem.ModuleTag);
                cbBoxSp.SelectedIndexChanged -= new EventHandler(cbBoxSp_SelectedIndexChanged);
                cbBoxSp.DataSource = cbBoxSp_Data;
                cbBoxSp.DisplayMember = "ValueDescription";
                cbBoxSp.SelectedIndex = -1;
                cbBoxSp.ValueMember = "Value";
                cbBoxSp.Text = cbBoxSp_Data.First().Default;
                cbBoxSp.SelectedIndexChanged += new EventHandler(cbBoxSp_SelectedIndexChanged);
            }

            fanBoxName.Text = cbBoxMS.Text + "-" + cbBoxMT.Text + "-" + cbBoxSC.Text + "-" + cbBoxSp.Text;
            //保存窗体信息
            moduleTag = imgItem.ModuleTag;
            cooling = imgItem.CoolingPower;
            imageName = imgItem.ImgageName;
            order = imgItem.OrderID;

        }

        public void BoundValue(List<ContentPropertyValue> boundData)
        {

            //textBoxTag.Text = imgItem.ModuleTag;
            foreach (ContentPropertyValue propertyname in boundData)
            {
                if (propertyname.PropertyName == "MOTOR SIZE")
                {
                    List<ContentPropertyValue> cbBoxMS_Data = boundData;
                    cbBoxMS.SelectedIndexChanged -= new EventHandler(cbBoxMS_SelectedIndexChanged);
                    cbBoxMS.DataSource = cbBoxMS_Data;
                    cbBoxMS.DisplayMember = "ValueDescription";
                    cbBoxMS.SelectedIndex = -1;
                    cbBoxMS.ValueMember = "Value";
                    cbBoxMS.Text = cbBoxMS_Data.First().Default;
                    cbBoxMS.SelectedIndexChanged += new EventHandler(cbBoxMS_SelectedIndexChanged);
                }
                if (propertyname.PropertyName == "MOTOR TYPE")
                {
                    List<ContentPropertyValue> cbBoxMT_Data = boundData;
                    cbBoxMT.SelectedIndexChanged -= new EventHandler(cbBoxMT_SelectedIndexChanged);
                    cbBoxMT.DataSource = cbBoxMT_Data;
                    cbBoxMT.DisplayMember = "ValueDescription";
                    cbBoxMT.SelectedIndex = -1;
                    cbBoxMT.ValueMember = "Value";
                    cbBoxMT.Text = cbBoxMT_Data.First().Default;
                    cbBoxMT.SelectedIndexChanged += new EventHandler(cbBoxMT_SelectedIndexChanged);
                }
                if (propertyname.PropertyName == "SAFETY CONTROL")
                {
                    List<ContentPropertyValue> cbBoxSC_Data = boundData;
                    cbBoxSC.SelectedIndexChanged -= new EventHandler(cbBoxSC_SelectedIndexChanged);
                    cbBoxSC.DataSource = cbBoxSC_Data;
                    cbBoxSC.DisplayMember = "ValueDescription";
                    cbBoxSC.SelectedIndex = -1;
                    cbBoxSC.ValueMember = "Value";
                    cbBoxSC.Text = cbBoxSC_Data.First().Default;
                    cbBoxSC.SelectedIndexChanged += new EventHandler(cbBoxSC_SelectedIndexChanged);
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
        
        private void cbBoxMS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxMS.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxMS.Tag.ToString(), cbBoxMS.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("MOTOR SIZE", ChangedOveroad.OrderID, ChangedOveroad.CoolingPower, ChangedOveroad.ImgageName, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                fanBoxName.Text = "";
                fanBoxName.Text = cbBoxMS.Text + "-" + cbBoxMT.Text + "-" + cbBoxSC.Text + "-" + cbBoxSp.Text;
            }
        }

        private void cbBoxMT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxMT.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxMT.Tag.ToString(), cbBoxMT.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("MOTOR TYPE", ChangedOveroad.OrderID, ChangedOveroad.CoolingPower, ChangedOveroad.ImgageName, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                fanBoxName.Text = "";
                fanBoxName.Text = cbBoxMS.Text + "-" + cbBoxMT.Text + "-" + cbBoxSC.Text + "-" + cbBoxSp.Text;
            }
        }

        private void cbBoxSC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxSC.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxSC.Tag.ToString(), cbBoxSC.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("SAFETY CONTROL", ChangedOveroad.OrderID, ChangedOveroad.CoolingPower, ChangedOveroad.ImgageName, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                fanBoxName.Text = "";
                fanBoxName.Text = cbBoxMS.Text + "-" + cbBoxMT.Text + "-" + cbBoxSC.Text + "-" + cbBoxSp.Text;
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
                fanBoxName.Text = "";
                fanBoxName.Text = cbBoxMS.Text + "-" + cbBoxMT.Text + "-" + cbBoxSC.Text + "-" + cbBoxSp.Text;
            }
        }
    }
}
