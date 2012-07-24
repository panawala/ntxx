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
    public partial class MixingBox : Form
    {
        public MixingBox()
        {
            InitializeComponent();
        }

        private void MixingBox_Load(object sender, EventArgs e)
        {

        }

        public void InitialValue(ImageModel imgItem, int type)
        {

            textBoxTag.Text = imgItem.ModuleTag;
            textBoxDA.Text = "0";//没有绑定数据，暂时固定，待修改

            if (type != 1)
            {
                List<ContentPropertyValue> cbBoxAT_Data =  ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "ACTUATOR ", imgItem.ModuleTag);
                cbBoxAT.SelectedIndexChanged -= new EventHandler(cbBoxAT_SelectedIndexChanged);
                cbBoxAT.DataSource = cbBoxAT_Data;
                cbBoxAT.DisplayMember = "ValueDescription";
                cbBoxAT.SelectedIndex = -1;
                cbBoxAT.ValueMember = "Value";
                cbBoxAT.Text = cbBoxAT_Data.First().Default;
                cbBoxAT.SelectedIndexChanged += new EventHandler(cbBoxAT_SelectedIndexChanged);


                List<ContentPropertyValue> cbBoxFS_Data =  ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "FILTERS", imgItem.ModuleTag);
                cbBoxFS.SelectedIndexChanged -= new EventHandler(cbBoxFS_SelectedIndexChanged);
                cbBoxFS.DataSource = cbBoxFS_Data;
                cbBoxFS.DisplayMember = "ValueDescription";
                cbBoxFS.SelectedIndex = -1;
                cbBoxFS.ValueMember = "Value";
                cbBoxFS.Text = cbBoxFS_Data.First().Default;
                cbBoxFS.SelectedIndexChanged += new EventHandler(cbBoxFS_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxSf_Data =  ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "SAFETY CONTROL", imgItem.ModuleTag);
                cbBoxSf.SelectedIndexChanged -= new EventHandler(cbBoxSf_SelectedIndexChanged);
                cbBoxSf.DataSource = cbBoxSf_Data;
                cbBoxSf.DisplayMember = "ValueDescription";
                cbBoxSf.SelectedIndex = -1;
                cbBoxSf.ValueMember = "Value";
                cbBoxSf.Text = cbBoxSf_Data.First().Default;
                cbBoxSf.SelectedIndexChanged += new EventHandler(cbBoxSf_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxFO_Data =  ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name,"FILTER OPTIONS", imgItem.ModuleTag);
                cbBoxFO.SelectedIndexChanged -= new EventHandler(cbBoxFO_SelectedIndexChanged);
                cbBoxFO.DataSource = cbBoxFO_Data;
                cbBoxFO.DisplayMember = "ValueDescription";
                cbBoxFO.SelectedIndex = -1;
                cbBoxFO.ValueMember = "Value";
                cbBoxFO.Text = cbBoxFO_Data.First().Default;
                cbBoxFO.SelectedIndexChanged += new EventHandler(cbBoxFO_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxSp_Data =  ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name,"TYPE", imgItem.ModuleTag);
                cbBoxSp.SelectedIndexChanged -= new EventHandler(cbBoxSp_SelectedIndexChanged);
                cbBoxSp.DataSource = cbBoxSp_Data;
                cbBoxSp.DisplayMember = "ValueDescription";
                cbBoxSp.SelectedIndex = -1;
                cbBoxSp.ValueMember = "Value";
                cbBoxSp.Text = cbBoxSp_Data.First().Default;
                cbBoxSp.SelectedIndexChanged += new EventHandler(cbBoxSp_SelectedIndexChanged);
            }

            mixingBoxName.Text = cbBoxAT.Text + "-" + cbBoxFS.Text + "-" + cbBoxSf.Text + "-" + cbBoxFO.Text + "-" + cbBoxSp.Text;
            //保存窗体信息
            moduleTag = imgItem.ModuleTag;
            cooling = imgItem.coolingType;
            imageName = imgItem.Name;
            order = imgItem.OrderId;

        }


        public void BoundValue(List<ContentPropertyValue> boundData)
        {

            //textBoxTag.Text = imgItem.ModuleTag;
            //textBoxDA.Text = "0";//没有绑定数据，暂时固定，待修改

            foreach (ContentPropertyValue propertyname in boundData)
            {
                if (propertyname.PropertyName == "ACTUATOR")
                {
                    List<ContentPropertyValue> cbBoxAT_Data = boundData;
                    cbBoxAT.SelectedIndexChanged -= new EventHandler(cbBoxAT_SelectedIndexChanged);
                    cbBoxAT.DataSource = cbBoxAT_Data;
                    cbBoxAT.DisplayMember = "ValueDescription";
                    cbBoxAT.SelectedIndex = -1;
                    cbBoxAT.ValueMember = "Value";
                    cbBoxAT.Text = cbBoxAT_Data.First().Default;
                    cbBoxAT.SelectedIndexChanged += new EventHandler(cbBoxAT_SelectedIndexChanged);
                }
                if (propertyname.PropertyName == "FILTERS")
                {
                    List<ContentPropertyValue> cbBoxFS_Data = boundData;
                    cbBoxFS.SelectedIndexChanged -= new EventHandler(cbBoxFS_SelectedIndexChanged);
                    cbBoxFS.DataSource = cbBoxFS_Data;
                    cbBoxFS.DisplayMember = "ValueDescription";
                    cbBoxFS.SelectedIndex = -1;
                    cbBoxFS.ValueMember = "Value";
                    cbBoxFS.Text = cbBoxFS_Data.First().Default;
                    cbBoxFS.SelectedIndexChanged += new EventHandler(cbBoxFS_SelectedIndexChanged);
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
        string moduleTag;
        int cooling;
        string imageName;
        int order;

        private void cbBoxAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxAT.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxAT.Tag.ToString(), cbBoxAT.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("ACTUATOR", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                mixingBoxName.Text = "";
                mixingBoxName.Text = cbBoxAT.Text + "-" + cbBoxFS.Text + "-" + cbBoxSf.Text + "-" + cbBoxFO.Text + "-" + cbBoxSp.Text;
            }
        }

        private void cbBoxFS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxFS.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxFS.Tag.ToString(), cbBoxFS.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("FILTERS", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                mixingBoxName.Text = "";
                mixingBoxName.Text = cbBoxAT.Text + "-" + cbBoxFS.Text + "-" + cbBoxSf.Text + "-" + cbBoxFO.Text + "-" + cbBoxSp.Text;
            }
        }

        private void cbBoxSf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxSf.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxSf.Tag.ToString(), cbBoxSf.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("ASAFETY CONTROL", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                mixingBoxName.Text = "";
                mixingBoxName.Text = cbBoxAT.Text + "-" + cbBoxFS.Text + "-" + cbBoxSf.Text + "-" + cbBoxFO.Text + "-" + cbBoxSp.Text;
            }
        }

        private void cbBoxFO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxFO.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxFO.Tag.ToString(), cbBoxFO.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("FILTER OPTIONS", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                mixingBoxName.Text = "";
                mixingBoxName.Text = cbBoxAT.Text + "-" + cbBoxFS.Text + "-" + cbBoxSf.Text + "-" + cbBoxFO.Text + "-" + cbBoxSp.Text;
            }
        }

        private void cbBoxSp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxFO.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxFO.Tag.ToString(), cbBoxFO.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("TYPE", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                mixingBoxName.Text = "";
                mixingBoxName.Text = cbBoxAT.Text + "-" + cbBoxFS.Text + "-" + cbBoxSf.Text + "-" + cbBoxFO.Text + "-" + cbBoxSp.Text;
            }
        }
    }
}
