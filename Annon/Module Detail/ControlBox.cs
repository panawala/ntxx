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
            controlBoxName.Text = ChangedOveroad.Name + "-" + ChangedOveroad.ModuleTag.Substring(0, 3) + "-" + "P" + "-" + cbBoxSf.Text
                + "-" + cbBoxSp.Text;
        }

        //更改配置后显示的图块详细配置名字
        private void LaterShowName()
        {
            string cbBoxSf_text;
            if (cbBoxSf.SelectedValue == null)
                cbBoxSf_text = cbBoxSf.Text;
            else
                cbBoxSf_text = cbBoxSf.SelectedValue.ToString();

            string cbBoxSp_text;
            if (cbBoxSp.SelectedValue == null)
                cbBoxSp_text = cbBoxSp.Text;
            else
                cbBoxSp_text = cbBoxSp.SelectedValue.ToString();

            controlBoxName.Text = ChangedOveroad.Name + "-" + ChangedOveroad.ModuleTag.Substring(0, 3) + "-" + "P" + "-"
                + cbBoxSf_text + "-"
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
            FirstShowName();


        }

        //重新绑定数据
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
                LaterShowName();
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
                LaterShowName();
            }
        }
    }
}
