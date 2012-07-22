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
    public partial class HRWheel : Form
    {
        public HRWheel()
        {
            InitializeComponent();
        }

        private void HRWheel_Load(object sender, EventArgs e)
        {

        }

        public List<ContentPropertyValue> GetData(int Cooling, string ImgageName, int orderId, string propertyName, string ModuleTag)
        {
            int coolingID = Cooling;
            string ImgID = ImgageName;
            int OrderID = orderId;
            string moduletag = ModuleTag;
            List<ContentPropertyValue> DetailData = ContentBLL.getPtyValue(coolingID, ImgID, orderId, propertyName,ModuleTag);
            return DetailData;
        }

        public void InitialValue(ImgItem imgItem,int type)
        {


            textBoxTag.Text = imgItem.ModuleTag;

            if (type != 1)
            {
                List<ContentPropertyValue> cbBoxWS_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "WHEEL SIZE", imgItem.ModuleTag);
                cbBoxWS.SelectedIndexChanged -= new EventHandler(cbBoxWS_SelectedIndexChanged);
                cbBoxWS.DataSource = cbBoxWS_Data;
                cbBoxWS.DisplayMember = "ValueDescription";
                cbBoxWS.SelectedIndex = -1;
                cbBoxWS.ValueMember = "Value";
                cbBoxWS.Text = cbBoxWS_Data.First().Default;
                cbBoxWS.SelectedIndexChanged -= new EventHandler(cbBoxWS_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxSp_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "TYPE", imgItem.ModuleTag);
                cbBoxSp.SelectedIndexChanged -= new EventHandler(cbBoxSp_SelectedIndexChanged);
                cbBoxSp.DataSource = cbBoxSp_Data;
                cbBoxSp.DisplayMember = "ValueDescription";
                cbBoxSp.SelectedIndex = -1;
                cbBoxSp.ValueMember = "Value";
                cbBoxSp.Text = cbBoxSp_Data.First().Default;
                cbBoxSp.SelectedIndexChanged -= new EventHandler(cbBoxSp_SelectedIndexChanged);
            }


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
                if (propertyname.PropertyName == "WHEEL SIZE")
                {
                    List<ContentPropertyValue> cbBoxWS_Data = boundData;
                    cbBoxWS.SelectedIndexChanged -= new EventHandler(cbBoxWS_SelectedIndexChanged);
                    cbBoxWS.DataSource = cbBoxWS_Data;
                    cbBoxWS.DisplayMember = "ValueDescription";
                    cbBoxWS.SelectedIndex = -1;
                    cbBoxWS.ValueMember = "Value";
                    cbBoxWS.Text = cbBoxWS_Data.First().Default;
                    cbBoxWS.SelectedIndexChanged -= new EventHandler(cbBoxWS_SelectedIndexChanged);
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
                    cbBoxSp.SelectedIndexChanged -= new EventHandler(cbBoxSp_SelectedIndexChanged);
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

        private void cbBoxWS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxWS.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxWS.Tag.ToString(), cbBoxWS.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("WHEEL SIZE", ChangedOveroad.OrderID, ChangedOveroad.CoolingPower, ChangedOveroad.ImgageName, ChangedOveroad.ModuleTag);
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
