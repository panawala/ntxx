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
    public partial class Filter : Form
    {
        public Filter()
        {
            InitializeComponent();
        }

        private void Filter_Load(object sender, EventArgs e)
        {

        }

        public void InitialValue(ImageModel imgItem, int type)
        {

            textBoxTag.Text = imgItem.ModuleTag;
            textBoxFT.Text ="P=Pleated Filter";//没有绑定数据，暂时固定，需要修改
            textBoxDA.Text = ".2";//没有绑定数据，暂时固定，需要修改

            if (type != 1)
            {
                List<ContentPropertyValue> cbBoxFS_Data =  ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "FILTERS ", imgItem.Guid);
                cbBoxFS.SelectedIndexChanged -= new EventHandler(cbBoxFS_SelectedIndexChanged);
                cbBoxFS.DataSource = cbBoxFS_Data;
                cbBoxFS.DisplayMember = "ValueDescription";
                cbBoxFS.SelectedIndex = -1;
                cbBoxFS.ValueMember = "Value";
                cbBoxFS.Text = cbBoxFS_Data.First().Default;
                cbBoxFS.SelectedIndexChanged += new EventHandler(cbBoxFS_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxSf_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "SAFETY CONTROL", imgItem.Guid);
                cbBoxSf.SelectedIndexChanged -= new EventHandler(cbBoxSf_SelectedIndexChanged);
                cbBoxSf.DataSource = cbBoxSf_Data;
                cbBoxSf.DisplayMember = "ValueDescription";
                cbBoxSf.SelectedIndex = -1;
                cbBoxSf.ValueMember = "Value";
                cbBoxSf.Text = cbBoxSf_Data.First().Default;
                cbBoxSf.SelectedIndexChanged += new EventHandler(cbBoxSf_SelectedIndexChanged);

                List<ContentPropertyValue> cbBox2FT_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "SECOND FILTER TYPE", imgItem.Guid);
                cbBox2FT.SelectedIndexChanged -= new EventHandler(cbBox2FT_SelectedIndexChanged);
                cbBox2FT.DataSource = cbBox2FT_Data;
                cbBox2FT.DisplayMember = "ValueDescription";
                cbBox2FT.SelectedIndex = -1;
                cbBox2FT.ValueMember = "Value";
                cbBox2FT.Text = cbBox2FT_Data.First().Default;
                cbBox2FT.SelectedIndexChanged += new EventHandler(cbBox2FT_SelectedIndexChanged);

                List<ContentPropertyValue> cbBox2FS_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "SECOND FILTERS", imgItem.Guid);
                cbBox2FS.SelectedIndexChanged -= new EventHandler(cbBox2FS_SelectedIndexChanged);
                cbBox2FS.DataSource = cbBox2FS_Data;
                cbBox2FS.DisplayMember = "ValueDescription";
                cbBox2FS.SelectedIndex = -1;
                cbBox2FS.ValueMember = "Value";
                cbBox2FS.Text = cbBox2FS_Data.First().Default;
                cbBox2FS.SelectedIndexChanged += new EventHandler(cbBox2FS_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxFO_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "FILTER OPTIONS", imgItem.Guid);
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

            //保存窗体信息
            guid = imgItem.Guid;
            cooling = imgItem.coolingType;
            imageName = imgItem.Name;
            order = imgItem.OrderId;


            //显示名字
            label12.Text = cbBoxFS.Text+"-"+ cbBoxSf.Text+"-"+cbBox2FT.Text+"-"+cbBox2FS.Text+"-"+cbBoxFO.Text;

        }

        public void BoundValue(List<ContentPropertyValue> boundData)
        {

            //textBoxTag.Text = imgItem.ModuleTag;
            //textBoxFT.Text = "P=Pleated Filter";//没有绑定数据，暂时固定，需要修改
            //textBoxDA.Text = ".2";//没有绑定数据，暂时固定，需要修改

            foreach (ContentPropertyValue propertyname in boundData)
            {
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
                if (propertyname.PropertyName == "SECOND FILTER TYPE")
                {
                    List<ContentPropertyValue> cbBox2FT_Data = boundData;
                    cbBox2FT.SelectedIndexChanged -= new EventHandler(cbBox2FT_SelectedIndexChanged);
                    cbBox2FT.DataSource = cbBox2FT_Data;
                    cbBox2FT.DisplayMember = "ValueDescription";
                    cbBox2FT.SelectedIndex = -1;
                    cbBox2FT.ValueMember = "Value";
                    cbBox2FT.Text = cbBox2FT_Data.First().Default;
                    cbBox2FT.SelectedIndexChanged += new EventHandler(cbBox2FT_SelectedIndexChanged);
                }
                if (propertyname.PropertyName == "SECOND FILTERS")
                {
                    List<ContentPropertyValue> cbBox2FS_Data = boundData;
                    cbBox2FS.SelectedIndexChanged -= new EventHandler(cbBox2FS_SelectedIndexChanged);
                    cbBox2FS.DataSource = cbBox2FS_Data;
                    cbBox2FS.DisplayMember = "ValueDescription";
                    cbBox2FS.SelectedIndex = -1;
                    cbBox2FS.ValueMember = "Value";
                    cbBox2FS.Text = cbBox2FS_Data.First().Default;
                    cbBox2FS.SelectedIndexChanged += new EventHandler(cbBox2FS_SelectedIndexChanged);
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

        private void cbBoxFS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxFS.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxFS.Tag.ToString(), cbBoxFS.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("FILTERS", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData != null && BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                label12.Text = "";
                label12.Text = cbBoxFS.Text + "-" + cbBoxSf.Text + "-" + cbBox2FT.Text + "-" + cbBox2FS.Text + "-" + cbBoxFO.Text;
            }
        }

        private void cbBoxSf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxSf.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxSf.Tag.ToString(), cbBoxSf.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("SAFETY CONTROL", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData != null && BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                label12.Text = "";
                label12.Text = cbBoxFS.Text + "-" + cbBoxSf.Text + "-" + cbBox2FT.Text + "-" + cbBox2FS.Text + "-" + cbBoxFO.Text;
            }
        }

        private void cbBox2FT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBox2FT.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBox2FT.Tag.ToString(), cbBox2FT.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("SECOND FILTER TYPE", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData != null && BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                label12.Text = "";
                label12.Text = cbBoxFS.Text + "-" + cbBoxSf.Text + "-" + cbBox2FT.Text + "-" + cbBox2FS.Text + "-" + cbBoxFO.Text;
            }
        }

        private void cbBox2FS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBox2FS.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBox2FS.Tag.ToString(), cbBox2FS.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("SECOND FILTERS", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData != null && BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                label12.Text = "";
                label12.Text = cbBoxFS.Text + "-" + cbBoxSf.Text + "-" + cbBox2FT.Text + "-" + cbBox2FS.Text + "-" + cbBoxFO.Text;
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
                label12.Text = "";
                label12.Text = cbBoxFS.Text + "-" + cbBoxSf.Text + "-" + cbBox2FT.Text + "-" + cbBox2FS.Text + "-" + cbBoxFO.Text;
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
                label12.Text = "";
                label12.Text = cbBoxFS.Text + "-" + cbBoxSf.Text + "-" + cbBox2FT.Text + "-" + cbBox2FS.Text + "-" + cbBoxFO.Text;
            }
        }
    }
}
