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
    public partial class Heat : Form
    {
        public Heat()
        {
            InitializeComponent();
        }

        private void Heat_Load(object sender, EventArgs e)
        {

        }

        public List<ContentPropertyValue> GetData(int Cooling, string ImgageName, int orderId, string propertyName, string ModuleTag)
        {
            int coolingID = Cooling;
            string ImgID = ImgageName;
            int OrderID = orderId;
            string moduletag = ModuleTag;
            List<ContentPropertyValue> DetailData = ContentBLL.getPtyValue(coolingID, ImgID, orderId,  propertyName,ModuleTag);
            return DetailData;
        }

        public void InitialValue(ImgItem imgItem,int type)
        {


            textBoxTag.Text = imgItem.ModuleTag;
            textBoxDA.Text = ".2";//没有绑定数据，暂时固定，待修改

            if (type != 1)
            {
                List<ContentPropertyValue> cbBoxFun_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "FUNCTION", imgItem.ModuleTag);
                cbBoxFun.SelectedIndexChanged -= new EventHandler(cbBoxFun_SelectedIndexChanged);
                cbBoxFun.DataSource = cbBoxFun_Data;
                cbBoxFun.DisplayMember = "ValueDescription";
                cbBoxFun.SelectedIndex = -1;
                cbBoxFun.ValueMember = "Value";
                cbBoxFun.Text = cbBoxFun_Data.First().Default;
                cbBoxFun.SelectedIndexChanged += new EventHandler(cbBoxFun_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxFi_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "FILTERS", imgItem.ModuleTag);
                cbBoxFi.SelectedIndexChanged -= new EventHandler(cbBoxFi_SelectedIndexChanged);
                cbBoxFi.DataSource = cbBoxFi_Data;
                cbBoxFi.DisplayMember = "ValueDescription";
                cbBoxFi.SelectedIndex = -1;
                cbBoxFi.ValueMember = "Value";
                cbBoxFi.Text = cbBoxFi_Data.First().Default;
                cbBoxFi.SelectedIndexChanged += new EventHandler(cbBoxFi_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxFO_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "FILTER OPTIONS ", imgItem.ModuleTag);
                cbBoxFO.SelectedIndexChanged -= new EventHandler(cbBoxFO_SelectedIndexChanged);
                cbBoxFO.DataSource = cbBoxFO_Data;
                cbBoxFO.DisplayMember = "ValueDescription";
                cbBoxFO.SelectedIndex = -1;
                cbBoxFO.ValueMember = "Value";
                cbBoxFO.Text = cbBoxFO_Data.First().Default;
                cbBoxFO.SelectedIndexChanged += new EventHandler(cbBoxFO_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxSp_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "TYPE", imgItem.ModuleTag);
                cbBoxSp.SelectedIndexChanged -= new EventHandler(cbBoxSp_SelectedIndexChanged);
                cbBoxSp.DataSource = cbBoxSp_Data;
                cbBoxSp.DisplayMember = "ValueDescription";
                cbBoxSp.SelectedIndex = -1;
                cbBoxSp.ValueMember = "Value";
                cbBoxSp.Text = cbBoxSp_Data.First().Default;
                cbBoxSp.SelectedIndexChanged += new EventHandler(cbBoxSp_SelectedIndexChanged);
            }
            
            //保存窗体信息
            moduleTag = imgItem.ModuleTag;
            cooling = imgItem.CoolingPower;
            imageName = imgItem.ImgageName;
            order = imgItem.OrderID;

        }

        public void BoundValue(List<ContentPropertyValue> boundData)
        {


            //textBoxTag.Text = imgItem.ModuleTag;
            //textBoxDA.Text = ".2";//没有绑定数据，暂时固定，待修改

            foreach (ContentPropertyValue propertyname in boundData)
            {
                if (propertyname.PropertyName == "FUNCTION")
                {
                    List<ContentPropertyValue> cbBoxFun_Data = boundData;
                    cbBoxFun.SelectedIndexChanged -= new EventHandler(cbBoxFun_SelectedIndexChanged);
                    cbBoxFun.DataSource = cbBoxFun_Data;
                    cbBoxFun.DisplayMember = "ValueDescription";
                    cbBoxFun.SelectedIndex = -1;
                    cbBoxFun.ValueMember = "Value";
                    cbBoxFun.Text = cbBoxFun_Data.First().Default;
                    cbBoxFun.SelectedIndexChanged += new EventHandler(cbBoxFun_SelectedIndexChanged);
                }
                if (propertyname.PropertyName == "FILTERS")
                {
                    List<ContentPropertyValue> cbBoxFi_Data = boundData;
                    cbBoxFi.SelectedIndexChanged -= new EventHandler(cbBoxFi_SelectedIndexChanged);
                    cbBoxFi.DataSource = cbBoxFi_Data;
                    cbBoxFi.DisplayMember = "ValueDescription";
                    cbBoxFi.SelectedIndex = -1;
                    cbBoxFi.ValueMember = "Value";
                    cbBoxFi.Text = cbBoxFi_Data.First().Default;
                    cbBoxFi.SelectedIndexChanged += new EventHandler(cbBoxFi_SelectedIndexChanged);
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

        ImgItem ChangedOveroad;//用于更改数据后，重新加载数据
        public void OveroadForm(ImgItem item)
        {
            ChangedOveroad = item;
        }
        //获取窗体的数据，更新订单信息
        string moduleTag;
        int cooling;
        string imageName;
        int order;

        private void cbBoxFun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxFun.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxFun.Tag.ToString(), cbBoxFun.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("FUNCTION", ChangedOveroad.OrderID, ChangedOveroad.CoolingPower, ChangedOveroad.ImgageName, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
            }
        }

        private void cbBoxFi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxFi.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxFi.Tag.ToString(), cbBoxFi.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("FILTERS", ChangedOveroad.OrderID, ChangedOveroad.CoolingPower, ChangedOveroad.ImgageName, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
            }
        }

        private void cbBoxFO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxFO.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxFO.Tag.ToString(), cbBoxFO.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("FILTER OPTIONS", ChangedOveroad.OrderID, ChangedOveroad.CoolingPower, ChangedOveroad.ImgageName, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
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
            }
        }
    }
}
