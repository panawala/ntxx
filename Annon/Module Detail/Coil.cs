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
        public List<ContentPropertyValue> GetData(int Cooling, string ImgageName, int orderId, string propertyName, string ModuleTag)
        {
            int coolingID = Cooling;
            string ImgID = ImgageName;
            int OrderID = orderId;
            string moduletag = ModuleTag;
            List<ContentPropertyValue> DetailData = ContentBLL.getPtyValue(coolingID, ImgID, orderId,propertyName, ModuleTag);
            return DetailData;
        }
        public void InitialValue(ImgItem imgItem,int type)
        {

            textBoxTag.Text = textBoxTag.Text = imgItem.ModuleTag;
            if (type != 1)
            {
                List<ContentPropertyValue> cbBoxCT_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "COOLING TYPE", imgItem.ModuleTag);
                cbBoxCT.SelectedIndexChanged -= new EventHandler(cbBoxCT_SelectedIndexChanged);
                cbBoxCT.DataSource = cbBoxCT_Data;
                cbBoxCT.DisplayMember = "ValueDescription";
                cbBoxCT.SelectedIndex = -1;
                cbBoxCT.ValueMember = "Value";
                cbBoxCT.Text = cbBoxCT_Data.First().Default;
                cbBoxCT.SelectedIndexChanged+=new EventHandler(cbBoxCT_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxDP_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "DRAIN PAN", imgItem.ModuleTag);
                cbBoxDP.DataSource = cbBoxDP_Data;
                cbBoxDP.SelectedIndexChanged -= new EventHandler(cbBoxDP_SelectedIndexChanged);
                cbBoxDP.DisplayMember = "ValueDescription";
                cbBoxDP.SelectedIndex = -1;
                cbBoxDP.ValueMember = "Value";
                cbBoxDP.Text = cbBoxDP_Data.First().Default;
                cbBoxDP.SelectedIndexChanged+=new EventHandler(cbBoxDP_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxSp_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "TYPE", imgItem.ModuleTag);
                cbBoxSp.SelectedIndexChanged -= new EventHandler(cbBoxSp_SelectedIndexChanged);
                cbBoxSp.DataSource = cbBoxSp_Data;
                cbBoxSp.DisplayMember = "ValueDescription";
                cbBoxSp.SelectedIndex = -1;
                cbBoxSp.ValueMember = "Value";
                cbBoxSp.Text = cbBoxSp_Data.First().Default;
                cbBoxSp.SelectedIndexChanged+=new EventHandler(cbBoxSp_SelectedIndexChanged);

                if (ChangedOveroad.Type=="CBA")//根据图块的属性判断是否显示数据
                {
                    List<ContentPropertyValue> cbBoxRoE_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "TYPE", imgItem.ModuleTag);
                    cbBoxRoE.SelectedIndexChanged -= new EventHandler(cbBoxRoE_SelectedIndexChanged);
                    cbBoxRoE.DataSource = cbBoxRoE_Data;
                    cbBoxRoE.DisplayMember = "ValueDescription";
                    cbBoxRoE.SelectedIndex = -1;
                    cbBoxRoE.ValueMember = "Value";
                    cbBoxRoE.Text = cbBoxRoE_Data.First().Default;
                    cbBoxRoE.SelectedIndexChanged += new EventHandler(cbBoxRoE_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxFPIE_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "TYPE", imgItem.ModuleTag);
                    cbBoxFPIE.SelectedIndexChanged -= new EventHandler(cbBoxFPIE_SelectedIndexChanged);
                    cbBoxFPIE.DataSource = cbBoxFPIE_Data;
                    cbBoxFPIE.DisplayMember = "ValueDescription";
                    cbBoxFPIE.SelectedIndex = -1;
                    cbBoxFPIE.ValueMember = "Value";
                    cbBoxFPIE.Text = cbBoxFPIE_Data.First().Default;
                    cbBoxFPIE.SelectedIndexChanged += new EventHandler(cbBoxFPIE_SelectedIndexChanged);
 
                    List<ContentPropertyValue> cbBoxCirE_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "TYPE", imgItem.ModuleTag);
                    cbBoxCirE.SelectedIndexChanged -= new EventHandler(cbBoxCirE_SelectedIndexChanged);
                    cbBoxCirE.DataSource = cbBoxCirE_Data;
                    cbBoxCirE.DisplayMember = "ValueDescription";
                    cbBoxCirE.SelectedIndex = -1;
                    cbBoxCirE.ValueMember = "Value";
                    cbBoxCirE.Text = cbBoxCirE_Data.First().Default;
                    cbBoxCirE.SelectedIndexChanged += new EventHandler(cbBoxCirE_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxCoE_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "TYPE", imgItem.ModuleTag);
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
                    List<ContentPropertyValue> cbBoxRH_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "TYPE", imgItem.ModuleTag);
                    cbBoxRH.SelectedIndexChanged -= new EventHandler(cbBoxRH_SelectedIndexChanged);
                    cbBoxRH.DataSource = cbBoxRH_Data;
                    cbBoxRH.DisplayMember = "ValueDescription";
                    cbBoxRH.SelectedIndex = -1;
                    cbBoxRH.ValueMember = "Value";
                    cbBoxRH.Text = cbBoxRH_Data.First().Default;
                    cbBoxRH.SelectedIndexChanged += new EventHandler(cbBoxRH_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxFPIH_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "TYPE", imgItem.ModuleTag);
                    cbBoxFPIH.SelectedIndexChanged -= new EventHandler(cbBoxFPIH_SelectedIndexChanged);
                    cbBoxFPIH.DataSource = cbBoxFPIH_Data;
                    cbBoxFPIH.DisplayMember = "ValueDescription";
                    cbBoxFPIH.SelectedIndex = -1;
                    cbBoxFPIH.ValueMember = "Value";
                    cbBoxFPIH.Text = cbBoxFPIH_Data.First().Default;
                    cbBoxFPIH.SelectedIndexChanged += new EventHandler(cbBoxFPIH_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxCirH_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "TYPE", imgItem.ModuleTag);
                    cbBoxCirH.SelectedIndexChanged -= new EventHandler(cbBoxCirH_SelectedIndexChanged);
                    cbBoxCirH.DataSource = cbBoxCirH_Data;
                    cbBoxCirH.DisplayMember = "ValueDescription";
                    cbBoxCirH.SelectedIndex = -1;
                    cbBoxCirH.ValueMember = "Value";
                    cbBoxCirH.Text = cbBoxCirH_Data.First().Default;
                    cbBoxCirH.SelectedIndexChanged += new EventHandler(cbBoxCirH_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxCoH_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "TYPE", imgItem.ModuleTag);
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
                    List<ContentPropertyValue> cbBoxRC_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "TYPE", imgItem.ModuleTag);
                    cbBoxRC.SelectedIndexChanged -= new EventHandler(cbBoxRC_SelectedIndexChanged);
                    cbBoxRC.DataSource = cbBoxRC_Data;
                    cbBoxRC.DisplayMember = "ValueDescription";
                    cbBoxRC.SelectedIndex = -1;
                    cbBoxRC.ValueMember = "Value";
                    cbBoxRC.Text = cbBoxRC_Data.First().Default;
                    cbBoxRC.SelectedIndexChanged += new EventHandler(cbBoxRC_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxFPIC_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "TYPE", imgItem.ModuleTag);
                    cbBoxFPIC.SelectedIndexChanged -= new EventHandler(cbBoxFPIC_SelectedIndexChanged);
                    cbBoxFPIC.DataSource = cbBoxFPIC_Data;
                    cbBoxFPIC.DisplayMember = "ValueDescription";
                    cbBoxFPIC.SelectedIndex = -1;
                    cbBoxFPIC.ValueMember = "Value";
                    cbBoxFPIC.Text = cbBoxFPIC_Data.First().Default;
                    cbBoxFPIC.SelectedIndexChanged += new EventHandler(cbBoxFPIC_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxCirC_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "TYPE", imgItem.ModuleTag);
                    cbBoxCirC.SelectedIndexChanged -= new EventHandler(cbBoxCirC_SelectedIndexChanged);
                    cbBoxCirC.DataSource = cbBoxCirC_Data;
                    cbBoxCirC.DisplayMember = "ValueDescription";
                    cbBoxCirC.SelectedIndex = -1;
                    cbBoxCirC.ValueMember = "Value";
                    cbBoxCirC.Text = cbBoxCirC_Data.First().Default;
                    cbBoxCirC.SelectedIndexChanged += new EventHandler(cbBoxCirC_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxCoC_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "TYPE", imgItem.ModuleTag);
                    cbBoxCoC.SelectedIndexChanged -= new EventHandler(cbBoxCoC_SelectedIndexChanged);
                    cbBoxCoC.DataSource = cbBoxCoC_Data;
                    cbBoxCoC.DisplayMember = "ValueDescription";
                    cbBoxCoC.SelectedIndex = -1;
                    cbBoxCoC.ValueMember = "Value";
                    cbBoxCoC.Text = cbBoxCoC_Data.First().Default;
                    cbBoxCoC.SelectedIndexChanged += new EventHandler(cbBoxCoC_SelectedIndexChanged);
                }


            }
            coilName.Text = cbBoxCT.Text + "-" + cbBoxDP.Text + "-" + cbBoxSp.Text;

            //保存窗体信息
            moduleTag = imgItem.ModuleTag;
            cooling = imgItem.CoolingPower;
            imageName = imgItem.ImgageName;
            order = imgItem.OrderID;
        }


        public void BoundValue(List<ContentPropertyValue> boundData)
        {

            //textBoxTag.Text = textBoxTag.Text = imgItem.ModuleTag;
            foreach (ContentPropertyValue propertyname in boundData)
            {
                if (propertyname.PropertyName == "COOLING TYPE")
                {
                    List<ContentPropertyValue> cbBoxCT_Data = boundData;
                    cbBoxCT.SelectedIndexChanged -= new EventHandler(cbBoxCT_SelectedIndexChanged);
                    cbBoxCT.DataSource = cbBoxCT_Data;
                    cbBoxCT.DisplayMember = "ValueDescription";
                    cbBoxCT.SelectedIndex = -1;
                    cbBoxCT.ValueMember = "Value";
                    cbBoxCT.Text = cbBoxCT_Data.First().Default;
                    cbBoxCT.SelectedIndexChanged += new EventHandler(cbBoxCT_SelectedIndexChanged);
                }
                if (propertyname.PropertyName == "DRAIN PAN")
                {
                    List<ContentPropertyValue> cbBoxDP_Data = boundData;
                    cbBoxDP.DataSource = cbBoxDP_Data;
                    cbBoxDP.SelectedIndexChanged -= new EventHandler(cbBoxDP_SelectedIndexChanged);
                    cbBoxDP.DisplayMember = "ValueDescription";
                    cbBoxDP.SelectedIndex = -1;
                    cbBoxDP.ValueMember = "Value";
                    cbBoxDP.Text = cbBoxDP_Data.First().Default;
                    cbBoxDP.SelectedIndexChanged += new EventHandler(cbBoxDP_SelectedIndexChanged);
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
                        cbBoxRoE.Text = cbBoxRoE_Data.First().Default;
                        cbBoxRoE.SelectedIndexChanged += new EventHandler(cbBoxRoE_SelectedIndexChanged);
                    }

                    List<ContentPropertyValue> cbBoxFPIE_Data = boundData;
                    cbBoxFPIE.SelectedIndexChanged -= new EventHandler(cbBoxFPIE_SelectedIndexChanged);
                    cbBoxFPIE.DataSource = cbBoxFPIE_Data;
                    cbBoxFPIE.DisplayMember = "ValueDescription";
                    cbBoxFPIE.SelectedIndex = -1;
                    cbBoxFPIE.ValueMember = "Value";
                    cbBoxFPIE.Text = cbBoxFPIE_Data.First().Default;
                    cbBoxFPIE.SelectedIndexChanged += new EventHandler(cbBoxFPIE_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxCirE_Data = boundData;
                    cbBoxCirE.SelectedIndexChanged -= new EventHandler(cbBoxCirE_SelectedIndexChanged);
                    cbBoxCirE.DataSource = cbBoxCirE_Data;
                    cbBoxCirE.DisplayMember = "ValueDescription";
                    cbBoxCirE.SelectedIndex = -1;
                    cbBoxCirE.ValueMember = "Value";
                    cbBoxCirE.Text = cbBoxCirE_Data.First().Default;
                    cbBoxCirE.SelectedIndexChanged += new EventHandler(cbBoxCirE_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxCoE_Data = boundData;
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
                    List<ContentPropertyValue> cbBoxRH_Data = boundData;
                    cbBoxRH.SelectedIndexChanged -= new EventHandler(cbBoxRH_SelectedIndexChanged);
                    cbBoxRH.DataSource = cbBoxRH_Data;
                    cbBoxRH.DisplayMember = "ValueDescription";
                    cbBoxRH.SelectedIndex = -1;
                    cbBoxRH.ValueMember = "Value";
                    cbBoxRH.Text = cbBoxRH_Data.First().Default;
                    cbBoxRH.SelectedIndexChanged += new EventHandler(cbBoxRH_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxFPIH_Data = boundData;
                    cbBoxFPIH.SelectedIndexChanged -= new EventHandler(cbBoxFPIH_SelectedIndexChanged);
                    cbBoxFPIH.DataSource = cbBoxFPIH_Data;
                    cbBoxFPIH.DisplayMember = "ValueDescription";
                    cbBoxFPIH.SelectedIndex = -1;
                    cbBoxFPIH.ValueMember = "Value";
                    cbBoxFPIH.Text = cbBoxFPIH_Data.First().Default;
                    cbBoxFPIH.SelectedIndexChanged += new EventHandler(cbBoxFPIH_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxCirH_Data = boundData;
                    cbBoxCirH.SelectedIndexChanged -= new EventHandler(cbBoxCirH_SelectedIndexChanged);
                    cbBoxCirH.DataSource = cbBoxCirH_Data;
                    cbBoxCirH.DisplayMember = "ValueDescription";
                    cbBoxCirH.SelectedIndex = -1;
                    cbBoxCirH.ValueMember = "Value";
                    cbBoxCirH.Text = cbBoxCirH_Data.First().Default;
                    cbBoxCirH.SelectedIndexChanged += new EventHandler(cbBoxCirH_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxCoH_Data = boundData;
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
                    List<ContentPropertyValue> cbBoxRC_Data = boundData;
                    cbBoxRC.SelectedIndexChanged -= new EventHandler(cbBoxRC_SelectedIndexChanged);
                    cbBoxRC.DataSource = cbBoxRC_Data;
                    cbBoxRC.DisplayMember = "ValueDescription";
                    cbBoxRC.SelectedIndex = -1;
                    cbBoxRC.ValueMember = "Value";
                    cbBoxRC.Text = cbBoxRC_Data.First().Default;
                    cbBoxRC.SelectedIndexChanged += new EventHandler(cbBoxRC_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxFPIC_Data = boundData;
                    cbBoxFPIC.SelectedIndexChanged -= new EventHandler(cbBoxFPIC_SelectedIndexChanged);
                    cbBoxFPIC.DataSource = cbBoxFPIC_Data;
                    cbBoxFPIC.DisplayMember = "ValueDescription";
                    cbBoxFPIC.SelectedIndex = -1;
                    cbBoxFPIC.ValueMember = "Value";
                    cbBoxFPIC.Text = cbBoxFPIC_Data.First().Default;
                    cbBoxFPIC.SelectedIndexChanged += new EventHandler(cbBoxFPIC_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxCirC_Data = boundData;
                    cbBoxCirC.SelectedIndexChanged -= new EventHandler(cbBoxCirC_SelectedIndexChanged);
                    cbBoxCirC.DataSource = cbBoxCirC_Data;
                    cbBoxCirC.DisplayMember = "ValueDescription";
                    cbBoxCirC.SelectedIndex = -1;
                    cbBoxCirC.ValueMember = "Value";
                    cbBoxCirC.Text = cbBoxCirC_Data.First().Default;
                    cbBoxCirC.SelectedIndexChanged += new EventHandler(cbBoxCirC_SelectedIndexChanged);

                    List<ContentPropertyValue> cbBoxCoC_Data = boundData;
                    cbBoxCoC.SelectedIndexChanged -= new EventHandler(cbBoxCoC_SelectedIndexChanged);
                    cbBoxCoC.DataSource = cbBoxCoC_Data;
                    cbBoxCoC.DisplayMember = "ValueDescription";
                    cbBoxCoC.SelectedIndex = -1;
                    cbBoxCoC.ValueMember = "Value";
                    cbBoxCoC.Text = cbBoxCoC_Data.First().Default;
                    cbBoxCoC.SelectedIndexChanged += new EventHandler(cbBoxCoC_SelectedIndexChanged);
                }
            }
        }
        public void OveroadForm(ImgItem item)
        {
            ChangedOveroad = item;
        }
        //获取窗体的数据，更新订单信息
        string moduleTag;
        int cooling;
        string imageName;
        int order;
        ImgItem ChangedOveroad;//用于更改数据后，重新加载数据

        private void cbBoxCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxCT.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxCT.Tag.ToString(), cbBoxCT.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("TYPE", ChangedOveroad.OrderID, ChangedOveroad.CoolingPower, ChangedOveroad.ImgageName, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                coilName.Text = "";
                coilName.Text = cbBoxCT.Text + "-" + cbBoxDP.Text + "-" + cbBoxSp.Text;
            }
        }

        private void cbBoxDP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxDP.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxDP.Tag.ToString(), cbBoxDP.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("TYPE", ChangedOveroad.OrderID, ChangedOveroad.CoolingPower, ChangedOveroad.ImgageName, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                coilName.Text = "";
                coilName.Text = cbBoxCT.Text + "-" + cbBoxDP.Text + "-" + cbBoxSp.Text;
            }
        }

        private void cbBoxSp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxSp.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxSp.Tag.ToString(), cbBoxSp.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("TYPE", ChangedOveroad.OrderID, ChangedOveroad.CoolingPower, ChangedOveroad.ImgageName, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                coilName.Text = "";
                coilName.Text = cbBoxCT.Text + "-" + cbBoxDP.Text + "-" + cbBoxSp.Text;
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
