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
                List<ContentPropertyValue> cbBoxSf_Data =  ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name,"SAFETY OPTIONS", imgItem.ModuleTag);
                cbBoxSf.SelectedIndexChanged -= new EventHandler(cbBoxSf_SelectedIndexChanged);
                cbBoxSf.DataSource = cbBoxSf_Data;
                cbBoxSf.DisplayMember = "ValueDescription";
                cbBoxSf.SelectedIndex = -1;
                cbBoxSf.ValueMember = "Value";
                cbBoxSf.Text = cbBoxSf_Data.First().Default;
                cbBoxSf.SelectedIndexChanged += new EventHandler(cbBoxSf_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxSp_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "TYPE", imgItem.ModuleTag);
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
            moduleTag = imgItem.ModuleTag;
            cooling = imgItem.coolingType;
            imageName = imgItem.Name;
            order = imgItem.OrderId;
        }

        public void BoundValue(List<ContentPropertyValue> boundData)
        {

            //textBoxTag.Text = imgItem.ModuleTag;
            foreach (ContentPropertyValue propertyname in boundData)
            {
                if (propertyname.PropertyName == "SAFETY OPTIONS")
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

        public void OveroadForm(ImageModel item)
        {
            ChangedOveroad = item;
        }

        //获取窗体的数据，更新订单信息
        string moduleTag;
        int cooling;
        string imageName;
        int order;
        ImageModel ChangedOveroad;//用于更改数据后，重新加载数据
        private void cbBoxSp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxSp.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxSp.Tag.ToString(), cbBoxSp.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("SAFETY OPTIONS", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
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
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxSf.Tag.ToString(), cbBoxSf.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("TYPE", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.ModuleTag);
                {
                    BoundValue(BoundData);//重新加载数据
                }
                controlBoxName.Text = "";
                controlBoxName.Text = cbBoxSf.Text + "-" + cbBoxSp.Text;
            }
        }
    }
}
