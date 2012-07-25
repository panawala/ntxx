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
using Model.Zutu.ImageModel;

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

        public void InitialValue(ImageModel imgItem, int type)
        {


            textBoxTag.Text = imgItem.ModuleTag;

            if (type != 1)
            {
                List<ContentPropertyValue> cbBoxWS_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "WHEEL SIZE", imgItem.Guid);
                cbBoxWS.SelectedIndexChanged -= new EventHandler(cbBoxWS_SelectedIndexChanged);
                cbBoxWS.DataSource = cbBoxWS_Data;
                cbBoxWS.DisplayMember = "ValueDescription";
                cbBoxWS.SelectedIndex = -1;
                cbBoxWS.ValueMember = "Value";
                cbBoxWS.Text = cbBoxWS_Data.First().Default;
                cbBoxWS.SelectedIndexChanged -= new EventHandler(cbBoxWS_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxSp_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "TYPE", imgItem.Guid);
                cbBoxSp.SelectedIndexChanged -= new EventHandler(cbBoxSp_SelectedIndexChanged);
                cbBoxSp.DataSource = cbBoxSp_Data;
                cbBoxSp.DisplayMember = "ValueDescription";
                cbBoxSp.SelectedIndex = -1;
                cbBoxSp.ValueMember = "Value";
                cbBoxSp.Text = cbBoxSp_Data.First().Default;
                cbBoxSp.SelectedIndexChanged -= new EventHandler(cbBoxSp_SelectedIndexChanged);
            }

            HRwName.Text = cbBoxWS.Name + "-" + cbBoxSp.Name;
            //保存窗体信息
            guid = imgItem.Guid;
            cooling = imgItem.coolingType;
            imageName = imgItem.Name;
            order = imgItem.OrderId;

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

        ImageModel ChangedOveroad;//用于更改数据后，重新加载数据
        public void OveroadForm(ImageModel item)
        {
            ChangedOveroad = item;
        }
        //获取窗体的数据，更新订单信息
        string guid;
        int cooling;
        string imageName;
        int order;

        private void cbBoxWS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxWS.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxWS.Tag.ToString(), cbBoxWS.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("WHEEL SIZE", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData != null && BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                HRwName.Text = "";
                HRwName.Text = cbBoxWS.Name + "-" + cbBoxSp.Name;
            }
        }

        private void cbBoxSp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxSp.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxSp.Tag.ToString(), cbBoxSp.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("TYPE", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData!=null&&BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                HRwName.Text = "";
                HRwName.Text = cbBoxWS.Name + "-" + cbBoxSp.Name;
            }
        }
    }
}
