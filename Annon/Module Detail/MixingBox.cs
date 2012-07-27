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

        //用于更改数据后，重新加载数据
        ImageModel ChangedOveroad;
        //获取窗体的数据，更新订单信息
        string guid;
        int cooling;
        string imageName;
        int order;

        //初始化时显示的详细配置名字
        private void FirstShowName()
        {
            mixingBoxName.Text = ChangedOveroad.Name + "-" + ChangedOveroad.ModuleTag.Substring(0, 3) + "-" + "P" + "-" + cbBoxAT.Text
                + "-" + cbBoxFS.Text + "-" + cbBoxSf.Text + "-" + cbBoxFO.Text + "-" + cbBoxSp.Text;
        }

        //更改配置后显示的图块详细配置名字
        private void LaterShowName()
        {
            string cbBoxAT_text;
            if (cbBoxAT.SelectedValue == null)
                cbBoxAT_text = cbBoxAT.Text;
            else
                cbBoxAT_text = cbBoxAT.SelectedValue.ToString();

            string cbBoxFS_text;
            if (cbBoxFS.SelectedValue == null)
                cbBoxFS_text = cbBoxFS.Text;
            else
                cbBoxFS_text = cbBoxFS.SelectedValue.ToString();


            string cbBoxSf_text;
            if (cbBoxSf.SelectedValue == null)
                cbBoxSf_text = cbBoxSf.Text;
            else
                cbBoxSf_text = cbBoxSf.SelectedValue.ToString();

            string cbBoxFO_text;
            if (cbBoxFO.SelectedValue == null)
                cbBoxFO_text = cbBoxFO.Text;
            else
                cbBoxFO_text = cbBoxFO.SelectedValue.ToString();

            string cbBoxSp_text;
            if (cbBoxSp.SelectedValue == null)
                cbBoxSp_text = cbBoxSp.Text;
            else
                cbBoxSp_text = cbBoxSp.SelectedValue.ToString();

            mixingBoxName.Text = ChangedOveroad.Name + "-" + ChangedOveroad.ModuleTag.Substring(0, 3) + "-" + "P" + "-"
                + cbBoxAT_text + "-"
                + cbBoxFS_text + "-"
                + cbBoxSf_text + "-"
                + cbBoxFO_text + "-"
                + cbBoxSp_text;
        }

        //初始化窗体数据
        public void InitialValue(ImageModel imgItem)
        {
            //保存窗体信息
            guid = imgItem.Guid;
            cooling = imgItem.coolingType;
            imageName = imgItem.Name;
            order = imgItem.OrderId;

            ChangedOveroad = imgItem;
            textBoxTag.Text = imgItem.ModuleTag;
            textBoxDA.Text = "0";//没有绑定数据，暂时固定，待修改
            List<ContentPropertyValue> cbBoxAT_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "ACTUATOR ", imgItem.Guid);
            cbBoxAT.SelectedIndexChanged -= new EventHandler(cbBoxAT_SelectedIndexChanged);
            cbBoxAT.DataSource = cbBoxAT_Data;
            cbBoxAT.DisplayMember = "ValueDescription";
            cbBoxAT.SelectedIndex = -1;
            cbBoxAT.ValueMember = "Value";
            cbBoxAT.Text = cbBoxAT_Data.First().Default;
            cbBoxAT.SelectedIndexChanged += new EventHandler(cbBoxAT_SelectedIndexChanged);


            List<ContentPropertyValue> cbBoxFS_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "FILTERS", imgItem.Guid);
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

            //显示名字
            FirstShowName();           
        }

        //重新绑定窗体数据
        public void BoundValue(List<ContentPropertyValue> boundData)
        {

            //textBoxTag.Text = imgItem.ModuleTag;
            //textBoxDA.Text = "0";//没有绑定数据，暂时固定，待修改

            foreach (ContentPropertyValue propertyname in boundData)
            {
                if (propertyname.PropertyName.Trim() == "ACTUATOR")
                {
                    List<ContentPropertyValue> cbBoxAT_Data = boundData;
                    cbBoxAT.SelectedIndexChanged -= new EventHandler(cbBoxAT_SelectedIndexChanged);
                    cbBoxAT.DataSource = cbBoxAT_Data;
                    cbBoxAT.DisplayMember = "ValueDescription";
                    cbBoxAT.SelectedIndex = -1;
                    cbBoxAT.ValueMember = "Value";
                    if (!cbBoxAT_Data.Select(s => s.Value).Contains(cbBoxAT_Data.First().Default))
                        cbBoxAT.Text = cbBoxAT_Data.First().Value;
                    else
                        cbBoxAT.Text = cbBoxAT_Data.First().Default;
                    cbBoxAT.SelectedIndexChanged += new EventHandler(cbBoxAT_SelectedIndexChanged);
                }
                if (propertyname.PropertyName.Trim() == "FILTERS")
                {
                    List<ContentPropertyValue> cbBoxFS_Data = boundData;
                    cbBoxFS.SelectedIndexChanged -= new EventHandler(cbBoxFS_SelectedIndexChanged);
                    cbBoxFS.DataSource = cbBoxFS_Data;
                    cbBoxFS.DisplayMember = "ValueDescription";
                    cbBoxFS.SelectedIndex = -1;
                    cbBoxFS.ValueMember = "Value";
                    if (!cbBoxFS_Data.Select(s => s.Value).Contains(cbBoxFS_Data.First().Default))
                        cbBoxFS.Text = cbBoxFS_Data.First().Value;
                    else
                        cbBoxFS.Text = cbBoxFS_Data.First().Default;
                    cbBoxFS.SelectedIndexChanged += new EventHandler(cbBoxFS_SelectedIndexChanged);
                }
                if (propertyname.PropertyName.Trim() == "SAFETY CONTROL")
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
                if (propertyname.PropertyName.Trim() == "FILTER OPTIONS")
                {
                    List<ContentPropertyValue> cbBoxFO_Data = boundData;
                    cbBoxFO.SelectedIndexChanged -= new EventHandler(cbBoxFO_SelectedIndexChanged);
                    cbBoxFO.DataSource = cbBoxFO_Data;
                    cbBoxFO.DisplayMember = "ValueDescription";
                    cbBoxFO.SelectedIndex = -1;
                    cbBoxFO.ValueMember = "Value";
                    if (!cbBoxFO_Data.Select(s => s.Value).Contains(cbBoxFO_Data.First().Default))
                        cbBoxFO.Text = cbBoxFO_Data.First().Value;
                    else
                        cbBoxFO.Text = cbBoxFO_Data.First().Default;
                    cbBoxFO.SelectedIndexChanged += new EventHandler(cbBoxFO_SelectedIndexChanged);
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

        private void cbBoxAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxAT.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxAT.Tag.ToString(), cbBoxAT.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("ACTUATOR", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData != null && BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                LaterShowName();
            }
        }

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
                LaterShowName();
            }
        }

        private void cbBoxSf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxSf.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxSf.Tag.ToString(), cbBoxSf.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("ASAFETY CONTROL", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData != null && BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                LaterShowName();
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
                LaterShowName();
            }
        }

        private void cbBoxSp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxFO.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxFO.Tag.ToString(), cbBoxFO.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("TYPE", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData != null && BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                LaterShowName();
            }
        }
    }
}
