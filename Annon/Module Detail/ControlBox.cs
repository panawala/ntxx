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
    public partial class ControlBox : Form
    {
        public ControlBox()
        {
            InitializeComponent();
        }

        private void ControlBox_Load(object sender, EventArgs e)
        {

        }

        public void InitialValue(ImageModel imgItem, int type)
        {

            textBoxTag.Text = imgItem.ModuleTag;

            if (type != 1)
            {
                List<ContentPropertyValue> cbBoxSf_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "SAFETY OPTIONS", imgItem.Guid);
                cbBoxSf.SelectedIndexChanged -= new EventHandler(cbBoxSf_SelectedIndexChanged);
                cbBoxSf.DataSource = cbBoxSf_Data;
                cbBoxSf.DisplayMember = "ValueDescription";
                cbBoxSf.SelectedIndex = -1;
                cbBoxSf.ValueMember = "Value";
                cbBoxSf.Text = cbBoxSf_Data.First().Default;
                cbBoxSf.SelectedIndexChanged += new EventHandler(cbBoxSf_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxSp_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "TYPE", imgItem.Guid);
                cbBoxSp.SelectedIndexChanged -= new EventHandler(cbBoxSp_SelectedIndexChanged);
                cbBoxSp.DataSource = cbBoxSp_Data;
                cbBoxSp.DisplayMember = "ValueDescription";
                cbBoxSp.SelectedIndex = -1;
                cbBoxSp.ValueMember = "Value";
                cbBoxSp.Text = cbBoxSp_Data.First().Default;
                cbBoxSp.SelectedIndexChanged += new EventHandler(cbBoxSp_SelectedIndexChanged);
            }
            controlBoxName.Text = cbBoxSf.Text + "-" + cbBoxSp.Text;
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
                if (propertyname.PropertyName.Trim() == "SAFETY OPTIONS")
                {
                    List<ContentPropertyValue> cbBoxSf_Data = boundData;
                    cbBoxSf.SelectedIndexChanged -= new EventHandler(cbBoxSf_SelectedIndexChanged);
                    cbBoxSf.DataSource = cbBoxSf_Data;
                    cbBoxSf.DisplayMember = "ValueDescription";
                    cbBoxSf.SelectedIndex = -1;
                    cbBoxSf.ValueMember = "Value";
                    if (!cbBoxSf_Data.Select(s => s.Value).Contains(cbBoxSf_Data.First().Default))
                        cbBoxSf.Text = cbBoxSf_Data.First().Value;
                    else
                        cbBoxSf.Text = cbBoxSf_Data.First().Default;
                    cbBoxSf.SelectedIndexChanged += new EventHandler(cbBoxSf_SelectedIndexChanged);
                }

                if (propertyname.PropertyName.Trim() == "TYPE")
                {
                    List<ContentPropertyValue> cbBoxSp_Data = boundData;
                    cbBoxSp.SelectedIndexChanged -= new EventHandler(cbBoxSp_SelectedIndexChanged);
                    cbBoxSp.DataSource = cbBoxSp_Data;
                    cbBoxSp.DisplayMember = "ValueDescription";
                    cbBoxSp.SelectedIndex = -1;
                    cbBoxSp.ValueMember = "Value";
                    if (!cbBoxSp_Data.Select(s => s.Value).Contains(cbBoxSp_Data.First().Default))
                        cbBoxSp.Text = cbBoxSp_Data.First().Value;
                    else
                        cbBoxSp.Text = cbBoxSp_Data.First().Default;
                    cbBoxSp.SelectedIndexChanged += new EventHandler(cbBoxSp_SelectedIndexChanged);
                }
            }

        }

        public void OveroadForm(ImageModel item)
        {
            ChangedOveroad = item;
        }

        //获取窗体的数据，更新订单信息
        string guid;
        int cooling;
        string imageName;
        int order;
        ImageModel ChangedOveroad;//用于更改数据后，重新加载数据
        private void cbBoxSp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxSp.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxSp.Tag.ToString(), cbBoxSp.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("SAFETY OPTIONS", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData != null && BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                controlBoxName.Text = "";
                controlBoxName.Text = cbBoxSf.Text + "-" + cbBoxSp.Text;
            }
        }

        private void cbBoxSf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxSf.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxSf.Tag.ToString(), cbBoxSf.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("TYPE", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData != null && BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }   
                controlBoxName.Text = "";
                controlBoxName.Text = cbBoxSf.Text + "-" + cbBoxSp.Text;
            }
        }
    }
}
