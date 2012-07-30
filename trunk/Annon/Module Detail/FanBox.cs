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
    public partial class FanBox : Form
    {
        public FanBox()
        {
            InitializeComponent();
        }

        private void FanBox_Load(object sender, EventArgs e)
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
            fanBoxName.Text = ChangedOveroad.Name + "-" + ChangedOveroad.ModuleTag.Substring(0, 3) + "-" + "P" + "-" + cbBoxMS.Text
                + "-" + cbBoxMT.Text + "-" + cbBoxSC.Text + "-" + cbBoxSp.Text;
        }

        //更改配置后显示的图块详细配置名字
        private void LaterShowName()
        {
            string cbBoxMS_text;
            if (cbBoxMS.SelectedValue == null)
                cbBoxMS_text = cbBoxMS.Text;
            else
                cbBoxMS_text = cbBoxMS.SelectedValue.ToString();

            string cbBoxMT_text;
            if (cbBoxMT.SelectedValue == null)
                cbBoxMT_text = cbBoxMT.Text;
            else
                cbBoxMT_text = cbBoxMT.SelectedValue.ToString();


            string cbBoxSC_text;
            if (cbBoxSC.SelectedValue == null)
                cbBoxSC_text = cbBoxSC.Text;
            else
                cbBoxSC_text = cbBoxSC.SelectedValue.ToString();

            string cbBoxSp_text;
            if (cbBoxSp.SelectedValue == null)
                cbBoxSp_text = cbBoxSp.Text;
            else
                cbBoxSp_text = cbBoxSp.SelectedValue.ToString();
            fanBoxName.Text = ChangedOveroad.Name + "-" + ChangedOveroad.ModuleTag.Substring(0, 3) + "-" + "P" + "-"
                + cbBoxMS_text + "-"
                + cbBoxMT_text + "-"
                + cbBoxSC_text + "-"
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
            List<ContentPropertyValue> cbBoxMS_Data =  ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "MOTOR SIZE", imgItem.Guid);
            cbBoxMS.SelectedIndexChanged -= new EventHandler(cbBoxMS_SelectedIndexChanged);
            cbBoxMS.DataSource = cbBoxMS_Data;
            cbBoxMS.DisplayMember = "ValueDescription";
            cbBoxMS.SelectedIndex = -1;
            cbBoxMS.ValueMember = "Value";
            cbBoxMS.Text = cbBoxMS_Data.First().Default;
            cbBoxMS.SelectedIndexChanged += new EventHandler(cbBoxMS_SelectedIndexChanged);

            List<ContentPropertyValue> cbBoxMT_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "MOTOR TYPE", imgItem.Guid);
            cbBoxMT.SelectedIndexChanged -= new EventHandler(cbBoxMT_SelectedIndexChanged);
            cbBoxMT.DataSource = cbBoxMT_Data;
            cbBoxMT.DisplayMember = "ValueDescription";
            cbBoxMT.SelectedIndex = -1;
            cbBoxMT.ValueMember = "Value";
            cbBoxMT.Text = cbBoxMT_Data.First().Default;
            cbBoxMT.SelectedIndexChanged += new EventHandler(cbBoxMT_SelectedIndexChanged);

            List<ContentPropertyValue> cbBoxSC_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "SAFETY CONTROL", imgItem.Guid);
            cbBoxSC.SelectedIndexChanged -= new EventHandler(cbBoxSC_SelectedIndexChanged);
            cbBoxSC.DataSource = cbBoxSC_Data;
            cbBoxSC.DisplayMember = "ValueDescription";
            cbBoxSC.SelectedIndex = -1;
            cbBoxSC.ValueMember = "Value";
            cbBoxSC.Text = cbBoxSC_Data.First().Default;
            cbBoxSC.SelectedIndexChanged += new EventHandler(cbBoxSC_SelectedIndexChanged);

            List<ContentPropertyValue> cbBoxSp_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "TYPE", imgItem.Guid);
            cbBoxSp.SelectedIndexChanged -= new EventHandler(cbBoxSp_SelectedIndexChanged);
            cbBoxSp.DataSource = cbBoxSp_Data;
            cbBoxSp.DisplayMember = "ValueDescription";
            cbBoxSp.SelectedIndex = -1;
            cbBoxSp.ValueMember = "Value";
            cbBoxSp.Text = cbBoxSp_Data.First().Default;
            cbBoxSp.SelectedIndexChanged += new EventHandler(cbBoxSp_SelectedIndexChanged);

            FirstShowName();


        }

        //重新绑定数据
        public void BoundValue(List<ContentPropertyValue> boundData)
        {

            //textBoxTag.Text = imgItem.ModuleTag;
            foreach (ContentPropertyValue propertyname in boundData)
            {
                if (propertyname.PropertyName.Trim() == "MOTOR SIZE")
                {
                    List<ContentPropertyValue> cbBoxMS_Data = boundData;
                    cbBoxMS.SelectedIndexChanged -= new EventHandler(cbBoxMS_SelectedIndexChanged);
                    cbBoxMS.DataSource = cbBoxMS_Data;
                    cbBoxMS.DisplayMember = "ValueDescription";
                    cbBoxMS.SelectedIndex = -1;
                    cbBoxMS.ValueMember = "Value";
                    if (!cbBoxMS_Data.Select(s => s.Value).Contains(cbBoxMS_Data.First().Default))
                        cbBoxMS.Text = cbBoxMS_Data.First().Value;
                    else
                        cbBoxMS.Text = cbBoxMS_Data.First().Default;
                    cbBoxMS.SelectedIndexChanged += new EventHandler(cbBoxMS_SelectedIndexChanged);
                }
                if (propertyname.PropertyName.Trim() == "MOTOR TYPE")
                {
                    List<ContentPropertyValue> cbBoxMT_Data = boundData;
                    cbBoxMT.SelectedIndexChanged -= new EventHandler(cbBoxMT_SelectedIndexChanged);
                    cbBoxMT.DataSource = cbBoxMT_Data;
                    cbBoxMT.DisplayMember = "ValueDescription";
                    cbBoxMT.SelectedIndex = -1;
                    cbBoxMT.ValueMember = "Value";
                    if (!cbBoxMT_Data.Select(s => s.Value).Contains(cbBoxMT_Data.First().Default))
                        cbBoxMT.Text = cbBoxMT_Data.First().Value;
                    else
                        cbBoxMT.Text = cbBoxMT_Data.First().Default;
                    cbBoxMT.SelectedIndexChanged += new EventHandler(cbBoxMT_SelectedIndexChanged);
                }
                if (propertyname.PropertyName.Trim() == "SAFETY CONTROL")
                {
                    List<ContentPropertyValue> cbBoxSC_Data = boundData;
                    cbBoxSC.SelectedIndexChanged -= new EventHandler(cbBoxSC_SelectedIndexChanged);
                    cbBoxSC.DataSource = cbBoxSC_Data;
                    cbBoxSC.DisplayMember = "ValueDescription";
                    cbBoxSC.SelectedIndex = -1;
                    cbBoxSC.ValueMember = "Value";
                    if (!cbBoxSC_Data.Select(s => s.Value).Contains(cbBoxSC_Data.First().Default))
                        cbBoxSC.Text = cbBoxSC_Data.First().Value;
                    else
                        cbBoxSC.Text = cbBoxSC_Data.First().Default;
                    cbBoxSC.SelectedIndexChanged += new EventHandler(cbBoxSC_SelectedIndexChanged);
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
        
        private void cbBoxMS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxMS.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxMS.Tag.ToString(), cbBoxMS.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("MOTOR SIZE", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData!=null&& BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                LaterShowName();
            }
        }

        private void cbBoxMT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxMT.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxMT.Tag.ToString(), cbBoxMT.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("MOTOR TYPE", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData != null&&BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                LaterShowName();
            }
        }

        private void cbBoxSC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxSC.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxSC.Tag.ToString(), cbBoxSC.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("SAFETY CONTROL", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData != null && BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                LaterShowName();
            }
        }

        private void cbBoxSp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxSp.SelectedIndex != -1)
            {
                if (cbBoxSp.SelectedValue.ToString().Trim() == "X")
                {
                    SPA.Visible = true;
                    SpecialForm specialForm = new SpecialForm();
                    specialForm.Show();
                }
                else
                {
                    SPA.Visible = false;
                }
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxSp.Tag.ToString(), cbBoxSp.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("TYPE", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData != null && BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                LaterShowName();
            }
        }

        private void SPA_Click(object sender, EventArgs e)
        {
            SpecialForm specialForm = new SpecialForm();
            specialForm.Show();
        }
    }
}
