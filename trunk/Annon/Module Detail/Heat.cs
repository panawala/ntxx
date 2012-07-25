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
    public partial class Heat : Form
    {
        public Heat()
        {
            InitializeComponent();
        }

        private void Heat_Load(object sender, EventArgs e)
        {

        }
        public void InitialValue(ImageModel imgItem, int type)
        {


            textBoxTag.Text = imgItem.ModuleTag;
            textBoxDA.Text = ".2";//没有绑定数据，暂时固定，待修改

            if (type != 1)
            {
                List<ContentPropertyValue> cbBoxFun_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "FUNCTION", imgItem.Guid);
                cbBoxFun.SelectedIndexChanged -= new EventHandler(cbBoxFun_SelectedIndexChanged);
                cbBoxFun.DataSource = cbBoxFun_Data;
                cbBoxFun.DisplayMember = "ValueDescription";
                cbBoxFun.SelectedIndex = -1;
                cbBoxFun.ValueMember = "Value";
                cbBoxFun.Text = cbBoxFun_Data.First().Default;
                cbBoxFun.SelectedIndexChanged += new EventHandler(cbBoxFun_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxFi_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "FILTERS", imgItem.Guid);
                cbBoxFi.SelectedIndexChanged -= new EventHandler(cbBoxFi_SelectedIndexChanged);
                cbBoxFi.DataSource = cbBoxFi_Data;
                cbBoxFi.DisplayMember = "ValueDescription";
                cbBoxFi.SelectedIndex = -1;
                cbBoxFi.ValueMember = "Value";
                cbBoxFi.Text = cbBoxFi_Data.First().Default;
                cbBoxFi.SelectedIndexChanged += new EventHandler(cbBoxFi_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxFO_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "FILTER OPTIONS ", imgItem.Guid);
                cbBoxFO.SelectedIndexChanged -= new EventHandler(cbBoxFO_SelectedIndexChanged);
                cbBoxFO.DataSource = cbBoxFO_Data;
                cbBoxFO.DisplayMember = "ValueDescription";
                cbBoxFO.SelectedIndex = -1;
                cbBoxFO.ValueMember = "Value";
                cbBoxFO.Text = cbBoxFO_Data.First().Default;
                cbBoxFO.SelectedIndexChanged += new EventHandler(cbBoxFO_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxSp_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "TYPE", imgItem.Guid);
                cbBoxSp.SelectedIndexChanged -= new EventHandler(cbBoxSp_SelectedIndexChanged);
                cbBoxSp.DataSource = cbBoxSp_Data;
                cbBoxSp.DisplayMember = "ValueDescription";
                cbBoxSp.SelectedIndex = -1;
                cbBoxSp.ValueMember = "Value";
                cbBoxSp.Text = cbBoxSp_Data.First().Default;
                cbBoxSp.SelectedIndexChanged += new EventHandler(cbBoxSp_SelectedIndexChanged);
            }
            heatName.Text = "";
            //保存窗体信息
            guid = imgItem.Guid;
            cooling = imgItem.coolingType;
            imageName = imgItem.Name;
            order = imgItem.OrderId;

        }

        public void BoundValue(List<ContentPropertyValue> boundData)
        {


            //textBoxTag.Text = imgItem.ModuleTag;
            //textBoxDA.Text = ".2";//没有绑定数据，暂时固定，待修改

            foreach (ContentPropertyValue propertyname in boundData)
            {
                if (propertyname.PropertyName == "FUNCTION")
                {
                    List<ContentPropertyValue> cbBoxFun_Data = boundData;
                    cbBoxFun.SelectedIndexChanged -= new EventHandler(cbBoxFun_SelectedIndexChanged);
                    cbBoxFun.DataSource = cbBoxFun_Data;
                    cbBoxFun.DisplayMember = "ValueDescription";
                    cbBoxFun.SelectedIndex = -1;
                    cbBoxFun.ValueMember = "Value";
                    cbBoxFun.Text = cbBoxFun_Data.First().Default;
                    cbBoxFun.SelectedIndexChanged += new EventHandler(cbBoxFun_SelectedIndexChanged);
                }
                if (propertyname.PropertyName == "FILTERS")
                {
                    List<ContentPropertyValue> cbBoxFi_Data = boundData;
                    cbBoxFi.SelectedIndexChanged -= new EventHandler(cbBoxFi_SelectedIndexChanged);
                    cbBoxFi.DataSource = cbBoxFi_Data;
                    cbBoxFi.DisplayMember = "ValueDescription";
                    cbBoxFi.SelectedIndex = -1;
                    cbBoxFi.ValueMember = "Value";
                    cbBoxFi.Text = cbBoxFi_Data.First().Default;
                    cbBoxFi.SelectedIndexChanged += new EventHandler(cbBoxFi_SelectedIndexChanged);
                }
                if (propertyname.PropertyName == "FILTER OPTIONS")
                {
                    List<ContentPropertyValue> cbBoxFO_Data = boundData;
                    cbBoxFO.SelectedIndexChanged -= new EventHandler(cbBoxFO_SelectedIndexChanged);
                    cbBoxFO.DataSource = cbBoxFO_Data;
                    cbBoxFO.DisplayMember = "ValueDescription";
                    cbBoxFO.SelectedIndex = -1;
                    cbBoxFO.ValueMember = "Value";
                    cbBoxFO.Text = cbBoxFO_Data.First().Default;
                    cbBoxFO.SelectedIndexChanged += new EventHandler(cbBoxFO_SelectedIndexChanged);
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

        private void cbBoxFun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxFun.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxFun.Tag.ToString(), cbBoxFun.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("FUNCTION", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData != null && BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
            }
        }

        private void cbBoxFi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxFi.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxFi.Tag.ToString(), cbBoxFi.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("FILTERS", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData != null && BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
            }
        }

        private void cbBoxFO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxFO.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxFO.Tag.ToString(), cbBoxFO.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("FILTER OPTIONS", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData != null && BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
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
            }
        }
    }
}
