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
        ImageModel ChangedOveroad;//用于更改数据后，重新加载数据
        //获取窗体的数据，更新订单信息
        string guid;
        int cooling;
        string imageName;
        int order;

        //初始化时显示的详细配置名字
        private void FirstShowName()
        {
            heatName.Text = ChangedOveroad.Name + "-" + ChangedOveroad.ModuleTag.Substring(0, 3) + "-" + "P" + "-" + cbBoxFun.Text
                + "-" + cbBoxFi.Text + "-" + cbBoxFO.Text + "-" + cbBoxSp.Text ;
        }
        //更改配置后显示的图块详细配置名字
        private void LaterShowName()
        {
            string cbBoxFun_text;
            if (cbBoxFun.SelectedValue == null)
                cbBoxFun_text = cbBoxFun.Text;
            else
                cbBoxFun_text = cbBoxFun.SelectedValue.ToString();

            string cbBoxFi_text;
            if (cbBoxFi.SelectedValue == null)
                cbBoxFi_text = cbBoxFi.Text;
            else
                cbBoxFi_text = cbBoxFi.SelectedValue.ToString();


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

            heatName.Text = ChangedOveroad.Name + "-" + ChangedOveroad.ModuleTag.Substring(0, 3) + "-" + "P" + "-"
                + cbBoxFun_text + "-"
                + cbBoxFi_text + "-"
                + cbBoxFO_text + "-"
                + cbBoxSp_text;
        }
        public void InitialValue(ImageModel imgItem)
        {
            //保存窗体信息
            guid = imgItem.Guid;
            cooling = imgItem.coolingType;
            imageName = imgItem.Name;
            order = imgItem.OrderId;

            ChangedOveroad = imgItem;
            textBoxTag.Text = imgItem.ModuleTag;
            textBoxDA.Text = ".2";//没有绑定数据，暂时固定，待修改

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
            heatName.Text = "";

            FirstShowName();
        }

        public void BoundValue(List<ContentPropertyValue> boundData)
        {


            //textBoxTag.Text = imgItem.ModuleTag;
            //textBoxDA.Text = ".2";//没有绑定数据，暂时固定，待修改

            foreach (ContentPropertyValue propertyname in boundData)
            {
                if (propertyname.PropertyName.Trim() == "FUNCTION")
                {
                    List<ContentPropertyValue> cbBoxFun_Data = boundData;
                    cbBoxFun.SelectedIndexChanged -= new EventHandler(cbBoxFun_SelectedIndexChanged);
                    cbBoxFun.DataSource = cbBoxFun_Data;
                    cbBoxFun.DisplayMember = "ValueDescription";
                    cbBoxFun.SelectedIndex = -1;
                    cbBoxFun.ValueMember = "Value";
                    if (!cbBoxFun_Data.Select(s => s.Value).Contains(cbBoxFun_Data.First().Default))
                        cbBoxFun.Text = cbBoxFun_Data.First().Value;
                    else
                        cbBoxFun.Text = cbBoxFun_Data.First().Default;
                    cbBoxFun.SelectedIndexChanged += new EventHandler(cbBoxFun_SelectedIndexChanged);
                }
                if (propertyname.PropertyName.Trim() == "FILTERS")
                {
                    List<ContentPropertyValue> cbBoxFi_Data = boundData;
                    cbBoxFi.SelectedIndexChanged -= new EventHandler(cbBoxFi_SelectedIndexChanged);
                    cbBoxFi.DataSource = cbBoxFi_Data;
                    cbBoxFi.DisplayMember = "ValueDescription";
                    cbBoxFi.SelectedIndex = -1;
                    cbBoxFi.ValueMember = "Value";
                    if (!cbBoxFi_Data.Select(s => s.Value).Contains(cbBoxFi_Data.First().Default))
                        cbBoxFi.Text = cbBoxFi_Data.First().Value;
                    else
                        cbBoxFi.Text = cbBoxFi_Data.First().Default;
                    cbBoxFi.SelectedIndexChanged += new EventHandler(cbBoxFi_SelectedIndexChanged);
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
                LaterShowName();
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
            if (cbBoxSp.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxSp.Tag.ToString(), cbBoxSp.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("TYPE", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData!=null&&BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                LaterShowName();
            }
        }
    }
}
