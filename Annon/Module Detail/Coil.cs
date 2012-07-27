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
    public partial class Coil : Form
    {
        public Coil()
        {
            InitializeComponent();
        }

        private void Coil_Load(object sender, EventArgs e)
        {
            //根据图块，决定controlTab的不可用的tabPage
            if (ChangedOveroad.Type == "CBB")
            {
                tabControlCoi.TabPages.Remove(tabPage2);
            }
        }
        //获取窗体的数据，更新订单信息
        string guid;
        int cooling;
        string imageName;
        int order;
        ImageModel ChangedOveroad;//用于更改数据后，重新加载数据

        //初始化时显示的详细配置名字
        private void FirstShowName()
        {
            coilName.Text = ChangedOveroad.Name + "-" + ChangedOveroad.ModuleTag.Substring(0, 3) + "-" + "P" + "-" + cbBoxCT.Text
                + "-" + cbBoxDP.Text + "-" + cbBoxSp.Text;
        }
        //更改配置后显示的图块详细配置名字
        private void LaterShowName()
        {
            string cbBoxCT_text;
            if (cbBoxCT.SelectedValue == null)
                cbBoxCT_text = cbBoxCT.Text;
            else
                cbBoxCT_text = cbBoxCT.SelectedValue.ToString();

            string cbBoxDP_text;
            if (cbBoxDP.SelectedValue == null)
                cbBoxDP_text = cbBoxDP.Text;
            else
                cbBoxDP_text = cbBoxDP.SelectedValue.ToString();

            string cbBoxSp_text;
            if (cbBoxSp.SelectedValue == null)
                cbBoxSp_text = cbBoxSp.Text;
            else
                cbBoxSp_text = cbBoxSp.SelectedValue.ToString();

            coilName.Text = ChangedOveroad.Name + "-" + ChangedOveroad.ModuleTag.Substring(0, 3) + "-" + "P" + "-"
                + cbBoxCT_text + "-"
                + cbBoxDP_text + "-"
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
            textBoxTag.Text = textBoxTag.Text = imgItem.ModuleTag;
            List<ContentPropertyValue> cbBoxCT_Data =  ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name,"COOLING TYPE", imgItem.Guid);
            cbBoxCT.SelectedIndexChanged -= new EventHandler(cbBoxCT_SelectedIndexChanged);
            cbBoxCT.DataSource = cbBoxCT_Data;
            cbBoxCT.DisplayMember = "ValueDescription";
            cbBoxCT.SelectedIndex = -1;
            cbBoxCT.ValueMember = "Value";
            cbBoxCT.Text = cbBoxCT_Data.First().Default;
            cbBoxCT.SelectedIndexChanged+=new EventHandler(cbBoxCT_SelectedIndexChanged);

            List<ContentPropertyValue> cbBoxDP_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "DRAIN PAN", imgItem.Guid);
            cbBoxDP.DataSource = cbBoxDP_Data;
            cbBoxDP.SelectedIndexChanged -= new EventHandler(cbBoxDP_SelectedIndexChanged);
            cbBoxDP.DisplayMember = "ValueDescription";
            cbBoxDP.SelectedIndex = -1;
            cbBoxDP.ValueMember = "Value";
            cbBoxDP.Text = cbBoxDP_Data.First().Default;
            cbBoxDP.SelectedIndexChanged+=new EventHandler(cbBoxDP_SelectedIndexChanged);

            List<ContentPropertyValue> cbBoxSp_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "TYPE", imgItem.Guid);
            cbBoxSp.SelectedIndexChanged -= new EventHandler(cbBoxSp_SelectedIndexChanged);
            cbBoxSp.DataSource = cbBoxSp_Data;
            cbBoxSp.DisplayMember = "ValueDescription";
            cbBoxSp.SelectedIndex = -1;
            cbBoxSp.ValueMember = "Value";
            cbBoxSp.Text = cbBoxSp_Data.First().Default;
            cbBoxSp.SelectedIndexChanged+=new EventHandler(cbBoxSp_SelectedIndexChanged);

            if (ChangedOveroad.Type=="CBA")//根据图块的属性判断是否显示数据
            {
                List<ContentPropertyValue> cbBoxRoE_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "TYPE", imgItem.Guid);
                cbBoxRoE.SelectedIndexChanged -= new EventHandler(cbBoxRoE_SelectedIndexChanged);
                cbBoxRoE.DataSource = cbBoxRoE_Data;
                cbBoxRoE.DisplayMember = "ValueDescription";
                cbBoxRoE.SelectedIndex = -1;
                cbBoxRoE.ValueMember = "Value";
                cbBoxRoE.Text = cbBoxRoE_Data.First().Default;
                cbBoxRoE.SelectedIndexChanged += new EventHandler(cbBoxRoE_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxFPIE_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "TYPE", imgItem.Guid);
                cbBoxFPIE.SelectedIndexChanged -= new EventHandler(cbBoxFPIE_SelectedIndexChanged);
                cbBoxFPIE.DataSource = cbBoxFPIE_Data;
                cbBoxFPIE.DisplayMember = "ValueDescription";
                cbBoxFPIE.SelectedIndex = -1;
                cbBoxFPIE.ValueMember = "Value";
                cbBoxFPIE.Text = cbBoxFPIE_Data.First().Default;
                cbBoxFPIE.SelectedIndexChanged += new EventHandler(cbBoxFPIE_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxCirE_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "TYPE", imgItem.Guid);
                cbBoxCirE.SelectedIndexChanged -= new EventHandler(cbBoxCirE_SelectedIndexChanged);
                cbBoxCirE.DataSource = cbBoxCirE_Data;
                cbBoxCirE.DisplayMember = "ValueDescription";
                cbBoxCirE.SelectedIndex = -1;
                cbBoxCirE.ValueMember = "Value";
                cbBoxCirE.Text = cbBoxCirE_Data.First().Default;
                cbBoxCirE.SelectedIndexChanged += new EventHandler(cbBoxCirE_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxCoE_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "TYPE", imgItem.Guid);
                cbBoxCoE.SelectedIndexChanged -= new EventHandler(cbBoxCoE_SelectedIndexChanged);
                cbBoxCoE.DataSource = cbBoxCoE_Data;
                cbBoxCoE.DisplayMember = "ValueDescription";
                cbBoxCoE.SelectedIndex = -1;
                cbBoxCoE.ValueMember = "Value";
                cbBoxCoE.Text = cbBoxCoE_Data.First().Default;
                cbBoxCoE.SelectedIndexChanged += new EventHandler(cbBoxCoE_SelectedIndexChanged);
            }

            if (ChangedOveroad.Type == "CBB")//根据图块的属性判断是否显示数据
            {
                List<ContentPropertyValue> cbBoxRH_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "TYPE", imgItem.Guid);
                cbBoxRH.SelectedIndexChanged -= new EventHandler(cbBoxRH_SelectedIndexChanged);
                cbBoxRH.DataSource = cbBoxRH_Data;
                cbBoxRH.DisplayMember = "ValueDescription";
                cbBoxRH.SelectedIndex = -1;
                cbBoxRH.ValueMember = "Value";
                cbBoxRH.Text = cbBoxRH_Data.First().Default;
                cbBoxRH.SelectedIndexChanged += new EventHandler(cbBoxRH_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxFPIH_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "TYPE", imgItem.Guid);
                cbBoxFPIH.SelectedIndexChanged -= new EventHandler(cbBoxFPIH_SelectedIndexChanged);
                cbBoxFPIH.DataSource = cbBoxFPIH_Data;
                cbBoxFPIH.DisplayMember = "ValueDescription";
                cbBoxFPIH.SelectedIndex = -1;
                cbBoxFPIH.ValueMember = "Value";
                cbBoxFPIH.Text = cbBoxFPIH_Data.First().Default;
                cbBoxFPIH.SelectedIndexChanged += new EventHandler(cbBoxFPIH_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxCirH_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "TYPE", imgItem.Guid);
                cbBoxCirH.SelectedIndexChanged -= new EventHandler(cbBoxCirH_SelectedIndexChanged);
                cbBoxCirH.DataSource = cbBoxCirH_Data;
                cbBoxCirH.DisplayMember = "ValueDescription";
                cbBoxCirH.SelectedIndex = -1;
                cbBoxCirH.ValueMember = "Value";
                cbBoxCirH.Text = cbBoxCirH_Data.First().Default;
                cbBoxCirH.SelectedIndexChanged += new EventHandler(cbBoxCirH_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxCoH_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "TYPE", imgItem.Guid);
                cbBoxCoH.SelectedIndexChanged -= new EventHandler(cbBoxCoH_SelectedIndexChanged);
                cbBoxCoH.DataSource = cbBoxCoH_Data;
                cbBoxCoH.DisplayMember = "ValueDescription";
                cbBoxCoH.SelectedIndex = -1;
                cbBoxCoH.ValueMember = "Value";
                cbBoxCoH.Text = cbBoxCoH_Data.First().Default;
                cbBoxCoH.SelectedIndexChanged += new EventHandler(cbBoxCoH_SelectedIndexChanged);
            }
            if (ChangedOveroad.Type == "CBC")//根据图块的属性判断是否显示数据
            {
                List<ContentPropertyValue> cbBoxRC_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "TYPE", imgItem.Guid);
                cbBoxRC.SelectedIndexChanged -= new EventHandler(cbBoxRC_SelectedIndexChanged);
                cbBoxRC.DataSource = cbBoxRC_Data;
                cbBoxRC.DisplayMember = "ValueDescription";
                cbBoxRC.SelectedIndex = -1;
                cbBoxRC.ValueMember = "Value";
                cbBoxRC.Text = cbBoxRC_Data.First().Default;
                cbBoxRC.SelectedIndexChanged += new EventHandler(cbBoxRC_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxFPIC_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "TYPE", imgItem.Guid);
                cbBoxFPIC.SelectedIndexChanged -= new EventHandler(cbBoxFPIC_SelectedIndexChanged);
                cbBoxFPIC.DataSource = cbBoxFPIC_Data;
                cbBoxFPIC.DisplayMember = "ValueDescription";
                cbBoxFPIC.SelectedIndex = -1;
                cbBoxFPIC.ValueMember = "Value";
                cbBoxFPIC.Text = cbBoxFPIC_Data.First().Default;
                cbBoxFPIC.SelectedIndexChanged += new EventHandler(cbBoxFPIC_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxCirC_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "TYPE", imgItem.Guid);
                cbBoxCirC.SelectedIndexChanged -= new EventHandler(cbBoxCirC_SelectedIndexChanged);
                cbBoxCirC.DataSource = cbBoxCirC_Data;
                cbBoxCirC.DisplayMember = "ValueDescription";
                cbBoxCirC.SelectedIndex = -1;
                cbBoxCirC.ValueMember = "Value";
                cbBoxCirC.Text = cbBoxCirC_Data.First().Default;
                cbBoxCirC.SelectedIndexChanged += new EventHandler(cbBoxCirC_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxCoC_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "TYPE", imgItem.Guid);
                cbBoxCoC.SelectedIndexChanged -= new EventHandler(cbBoxCoC_SelectedIndexChanged);
                cbBoxCoC.DataSource = cbBoxCoC_Data;
                cbBoxCoC.DisplayMember = "ValueDescription";
                cbBoxCoC.SelectedIndex = -1;
                cbBoxCoC.ValueMember = "Value";
                cbBoxCoC.Text = cbBoxCoC_Data.First().Default;
                cbBoxCoC.SelectedIndexChanged += new EventHandler(cbBoxCoC_SelectedIndexChanged);
               }
            FirstShowName();


        }

        public void BoundValue(List<ContentPropertyValue> boundData)
        {

            //textBoxTag.Text = textBoxTag.Text = imgItem.ModuleTag;
            foreach (ContentPropertyValue propertyname in boundData)
            {
                if (propertyname.PropertyName.Trim() == "COOLING TYPE")
                {
                    List<ContentPropertyValue> cbBoxCT_Data = boundData;
                    cbBoxCT.SelectedIndexChanged -= new EventHandler(cbBoxCT_SelectedIndexChanged);
                    cbBoxCT.DataSource = cbBoxCT_Data;
                    cbBoxCT.DisplayMember = "ValueDescription";
                    cbBoxCT.SelectedIndex = -1;
                    cbBoxCT.ValueMember = "Value";
                    if (!cbBoxCT_Data.Select(s => s.Value).Contains(cbBoxCT_Data.First().Default))
                        cbBoxCT.Text = cbBoxCT_Data.First().Value;
                    else
                        cbBoxCT.Text = cbBoxCT_Data.First().Default;
                    cbBoxCT.SelectedIndexChanged += new EventHandler(cbBoxCT_SelectedIndexChanged);
                }
                if (propertyname.PropertyName.Trim() == "DRAIN PAN")
                {
                    List<ContentPropertyValue> cbBoxDP_Data = boundData;
                    cbBoxDP.DataSource = cbBoxDP_Data;
                    cbBoxDP.SelectedIndexChanged -= new EventHandler(cbBoxDP_SelectedIndexChanged);
                    cbBoxDP.DisplayMember = "ValueDescription";
                    cbBoxDP.SelectedIndex = -1;
                    cbBoxDP.ValueMember = "Value";
                    if (!cbBoxDP_Data.Select(s => s.Value).Contains(cbBoxDP_Data.First().Default))
                        cbBoxDP.Text = cbBoxDP_Data.First().Value;
                    else
                        cbBoxDP.Text = cbBoxDP_Data.First().Default;
                    cbBoxDP.SelectedIndexChanged += new EventHandler(cbBoxDP_SelectedIndexChanged);
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


                if (ChangedOveroad.Type == "CBA")//根据图块的属性判断是否显示数据
                {
                    //if (propertyname.PropertyName = "")
                    {
                        List<ContentPropertyValue> cbBoxRoE_Data = boundData;
                        cbBoxRoE.SelectedIndexChanged -= new EventHandler(cbBoxRoE_SelectedIndexChanged);
                        cbBoxRoE.DataSource = cbBoxRoE_Data;
                        cbBoxRoE.DisplayMember = "ValueDescription";
                        cbBoxRoE.SelectedIndex = -1;
                        cbBoxRoE.ValueMember = "Value";
                        if (!cbBoxRoE_Data.Select(s => s.Value).Contains(cbBoxRoE_Data.First().Default))
                            cbBoxRoE.Text = cbBoxRoE_Data.First().Value;
                        else
                            cbBoxRoE.Text = cbBoxRoE_Data.First().Default;
                        cbBoxRoE.SelectedIndexChanged += new EventHandler(cbBoxRoE_SelectedIndexChanged);
                    }

                    List<ContentPropertyValue> cbBoxFPIE_Data = boundData;
                    cbBoxFPIE.SelectedIndexChanged -= new EventHandler(cbBoxFPIE_SelectedIndexChanged);
                    cbBoxFPIE.DataSource = cbBoxFPIE_Data;
                    cbBoxFPIE.DisplayMember = "ValueDescription";
                    cbBoxFPIE.SelectedIndex = -1;
                    cbBoxFPIE.ValueMember = "Value";
                    if (!cbBoxFPIE_Data.Select(s => s.Value).Contains(cbBoxFPIE_Data.First().Default))
                        cbBoxFPIE.Text = cbBoxFPIE_Data.First().Value;
                    else
                        cbBoxFPIE.Text = cbBoxFPIE_Data.First().Default;
                    cbBoxFPIE.SelectedIndexChanged += new EventHandler(cbBoxFPIE_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxCirE_Data = boundData;
                    cbBoxCirE.SelectedIndexChanged -= new EventHandler(cbBoxCirE_SelectedIndexChanged);
                    cbBoxCirE.DataSource = cbBoxCirE_Data;
                    cbBoxCirE.DisplayMember = "ValueDescription";
                    cbBoxCirE.SelectedIndex = -1;
                    cbBoxCirE.ValueMember = "Value";
                    if (!cbBoxCirE_Data.Select(s => s.Value).Contains(cbBoxCirE_Data.First().Default))
                        cbBoxCirE.Text = cbBoxCirE_Data.First().Value;
                    else
                        cbBoxCirE.Text = cbBoxCirE_Data.First().Default;
                    cbBoxCirE.SelectedIndexChanged += new EventHandler(cbBoxCirE_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxCoE_Data = boundData;
                    cbBoxCoE.SelectedIndexChanged -= new EventHandler(cbBoxCoE_SelectedIndexChanged);
                    cbBoxCoE.DataSource = cbBoxCoE_Data;
                    cbBoxCoE.DisplayMember = "ValueDescription";
                    cbBoxCoE.SelectedIndex = -1;
                    cbBoxCoE.ValueMember = "Value";
                    if (!cbBoxCoE_Data.Select(s => s.Value).Contains(cbBoxCoE_Data.First().Default))
                        cbBoxCoE.Text = cbBoxCoE_Data.First().Value;
                    else
                        cbBoxCoE.Text = cbBoxCoE_Data.First().Default;
                    cbBoxCoE.SelectedIndexChanged += new EventHandler(cbBoxCoE_SelectedIndexChanged);
                }

                if (ChangedOveroad.Type == "CBB")//根据图块的属性判断是否显示数据
                {
                    List<ContentPropertyValue> cbBoxRH_Data = boundData;
                    cbBoxRH.SelectedIndexChanged -= new EventHandler(cbBoxRH_SelectedIndexChanged);
                    cbBoxRH.DataSource = cbBoxRH_Data;
                    cbBoxRH.DisplayMember = "ValueDescription";
                    cbBoxRH.SelectedIndex = -1;
                    cbBoxRH.ValueMember = "Value";
                    if (!cbBoxRH_Data.Select(s => s.Value).Contains(cbBoxRH_Data.First().Default))
                        cbBoxRH.Text = cbBoxRH_Data.First().Value;
                    else
                        cbBoxRH.Text = cbBoxRH_Data.First().Default;
                    cbBoxRH.SelectedIndexChanged += new EventHandler(cbBoxRH_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxFPIH_Data = boundData;
                    cbBoxFPIH.SelectedIndexChanged -= new EventHandler(cbBoxFPIH_SelectedIndexChanged);
                    cbBoxFPIH.DataSource = cbBoxFPIH_Data;
                    cbBoxFPIH.DisplayMember = "ValueDescription";
                    cbBoxFPIH.SelectedIndex = -1;
                    cbBoxFPIH.ValueMember = "Value";
                    if (!cbBoxFPIH_Data.Select(s => s.Value).Contains(cbBoxFPIH_Data.First().Default))
                        cbBoxFPIH.Text = cbBoxFPIH_Data.First().Value;
                    else
                        cbBoxFPIH.Text = cbBoxFPIH_Data.First().Default;
                    cbBoxFPIH.SelectedIndexChanged += new EventHandler(cbBoxFPIH_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxCirH_Data = boundData;
                    cbBoxCirH.SelectedIndexChanged -= new EventHandler(cbBoxCirH_SelectedIndexChanged);
                    cbBoxCirH.DataSource = cbBoxCirH_Data;
                    cbBoxCirH.DisplayMember = "ValueDescription";
                    cbBoxCirH.SelectedIndex = -1;
                    cbBoxCirH.ValueMember = "Value";
                    if (!cbBoxCirH_Data.Select(s => s.Value).Contains(cbBoxCirH_Data.First().Default))
                        cbBoxCirH.Text = cbBoxCirH_Data.First().Value;
                    else
                        cbBoxCirH.Text = cbBoxCirH_Data.First().Default;
                    cbBoxCirH.SelectedIndexChanged += new EventHandler(cbBoxCirH_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxCoH_Data = boundData;
                    cbBoxCoH.SelectedIndexChanged -= new EventHandler(cbBoxCoH_SelectedIndexChanged);
                    cbBoxCoH.DataSource = cbBoxCoH_Data;
                    cbBoxCoH.DisplayMember = "ValueDescription";
                    cbBoxCoH.SelectedIndex = -1;
                    cbBoxCoH.ValueMember = "Value";
                    if (!cbBoxCoH_Data.Select(s => s.Value).Contains(cbBoxCoH_Data.First().Default))
                        cbBoxCoH.Text = cbBoxCoH_Data.First().Value;
                    else
                        cbBoxCoH.Text = cbBoxCoH_Data.First().Default;
                    cbBoxCoH.SelectedIndexChanged += new EventHandler(cbBoxCoH_SelectedIndexChanged);
                }
                if (ChangedOveroad.Type == "CBC")//根据图块的属性判断是否显示数据
                {
                    List<ContentPropertyValue> cbBoxRC_Data = boundData;
                    cbBoxRC.SelectedIndexChanged -= new EventHandler(cbBoxRC_SelectedIndexChanged);
                    cbBoxRC.DataSource = cbBoxRC_Data;
                    cbBoxRC.DisplayMember = "ValueDescription";
                    cbBoxRC.SelectedIndex = -1;
                    cbBoxRC.ValueMember = "Value";
                    if (!cbBoxRC_Data.Select(s => s.Value).Contains(cbBoxRC_Data.First().Default))
                        cbBoxRC.Text = cbBoxRC_Data.First().Value;
                    else
                        cbBoxRC.Text = cbBoxRC_Data.First().Default;
                    cbBoxRC.SelectedIndexChanged += new EventHandler(cbBoxRC_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxFPIC_Data = boundData;
                    cbBoxFPIC.SelectedIndexChanged -= new EventHandler(cbBoxFPIC_SelectedIndexChanged);
                    cbBoxFPIC.DataSource = cbBoxFPIC_Data;
                    cbBoxFPIC.DisplayMember = "ValueDescription";
                    cbBoxFPIC.SelectedIndex = -1;
                    cbBoxFPIC.ValueMember = "Value";
                    if (!cbBoxFPIC_Data.Select(s => s.Value).Contains(cbBoxFPIC_Data.First().Default))
                        cbBoxFPIC.Text = cbBoxFPIC_Data.First().Value;
                    else
                        cbBoxFPIC.Text = cbBoxFPIC_Data.First().Default;
                    cbBoxFPIC.SelectedIndexChanged += new EventHandler(cbBoxFPIC_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxCirC_Data = boundData;
                    cbBoxCirC.SelectedIndexChanged -= new EventHandler(cbBoxCirC_SelectedIndexChanged);
                    cbBoxCirC.DataSource = cbBoxCirC_Data;
                    cbBoxCirC.DisplayMember = "ValueDescription";
                    cbBoxCirC.SelectedIndex = -1;
                    cbBoxCirC.ValueMember = "Value";
                    if (!cbBoxCirC_Data.Select(s => s.Value).Contains(cbBoxCirC_Data.First().Default))
                        cbBoxCirC.Text = cbBoxCirC_Data.First().Value;
                    else
                        cbBoxCirC.Text = cbBoxCirC_Data.First().Default;
                    cbBoxCirC.SelectedIndexChanged += new EventHandler(cbBoxCirC_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxCoC_Data = boundData;
                    cbBoxCoC.SelectedIndexChanged -= new EventHandler(cbBoxCoC_SelectedIndexChanged);
                    cbBoxCoC.DataSource = cbBoxCoC_Data;
                    cbBoxCoC.DisplayMember = "ValueDescription";
                    cbBoxCoC.SelectedIndex = -1;
                    cbBoxCoC.ValueMember = "Value";
                    if (!cbBoxCoC_Data.Select(s => s.Value).Contains(cbBoxCoC_Data.First().Default))
                        cbBoxCoC.Text = cbBoxCoC_Data.First().Value;
                    else
                        cbBoxCoC.Text = cbBoxCoC_Data.First().Default;
                    cbBoxCoC.SelectedIndexChanged += new EventHandler(cbBoxCoC_SelectedIndexChanged);
                }
            }
        }

        private void cbBoxCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxCT.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxCT.Tag.ToString(), cbBoxCT.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("TYPE", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData != null && BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                LaterShowName();
            }
        }

        private void cbBoxDP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxDP.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxDP.Tag.ToString(), cbBoxDP.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("TYPE", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
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

        private void cbBoxRoE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbBoxFPIE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbBoxCirE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbBoxCoE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbBoxRH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbBoxFPIH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbBoxCirH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbBoxCoH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbBoxRC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbBoxFPIC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbBoxCirC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbBoxCoC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
