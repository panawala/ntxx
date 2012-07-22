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
    public partial class Filter : Form
    {
        public Filter()
        {
            InitializeComponent();
        }

        private void Filter_Load(object sender, EventArgs e)
        {

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

            textBoxTag.Text = imgItem.ModuleTag;
            textBoxFT.Text ="P=Pleated Filter";//没有绑定数据，暂时固定，需要修改
            textBoxDA.Text = ".2";//没有绑定数据，暂时固定，需要修改

            if (type != 1)
            {
                List<ContentPropertyValue> cbBoxFS_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "FILTERS ", imgItem.ModuleTag);
                cbBoxFS.SelectedIndexChanged -= new EventHandler(cbBoxFS_SelectedIndexChanged);
                cbBoxFS.DataSource = cbBoxFS_Data;
                cbBoxFS.DisplayMember = "ValueDescription";
                cbBoxFS.SelectedIndex = -1;
                cbBoxFS.ValueMember = "Value";
                cbBoxFS.Text = cbBoxFS_Data.First().Default;
                cbBoxFS.SelectedIndexChanged += new EventHandler(cbBoxFS_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxSf_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "SAFETY CONTROL", imgItem.ModuleTag);
                cbBoxSf.SelectedIndexChanged -= new EventHandler(cbBoxSf_SelectedIndexChanged);
                cbBoxSf.DataSource = cbBoxSf_Data;
                cbBoxSf.DisplayMember = "ValueDescription";
                cbBoxSf.SelectedIndex = -1;
                cbBoxSf.ValueMember = "Value";
                cbBoxSf.Text = cbBoxSf_Data.First().Default;
                cbBoxSf.SelectedIndexChanged += new EventHandler(cbBoxSf_SelectedIndexChanged);

                List<ContentPropertyValue> cbBox2FT_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "SECOND FILTER TYPE", imgItem.ModuleTag);
                cbBox2FT.SelectedIndexChanged -= new EventHandler(cbBox2FT_SelectedIndexChanged);
                cbBox2FT.DataSource = cbBox2FT_Data;
                cbBox2FT.DisplayMember = "ValueDescription";
                cbBox2FT.SelectedIndex = -1;
                cbBox2FT.ValueMember = "Value";
                cbBox2FT.Text = cbBox2FT_Data.First().Default;
                cbBox2FT.SelectedIndexChanged += new EventHandler(cbBox2FT_SelectedIndexChanged);

                List<ContentPropertyValue> cbBox2FS_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "SECOND FILTERS", imgItem.ModuleTag);
                cbBox2FS.SelectedIndexChanged -= new EventHandler(cbBox2FS_SelectedIndexChanged);
                cbBox2FS.DataSource = cbBox2FS_Data;
                cbBox2FS.DisplayMember = "ValueDescription";
                cbBox2FS.SelectedIndex = -1;
                cbBox2FS.ValueMember = "Value";
                cbBox2FS.Text = cbBox2FS_Data.First().Default;
                cbBox2FS.SelectedIndexChanged += new EventHandler(cbBox2FS_SelectedIndexChanged);

                List<ContentPropertyValue> cbBoxFO_Data = GetData(imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID, "FILTER OPTIONS", imgItem.ModuleTag);
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

        private void cbBoxFS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxFS.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxFS.Tag.ToString(), cbBoxFS.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("FILTERS", ChangedOveroad.OrderID, ChangedOveroad.CoolingPower, ChangedOveroad.ImgageName, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
            }
        }

        private void cbBoxSf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxSf.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBoxSf.Tag.ToString(), cbBoxSf.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("SAFETY CONTROL", ChangedOveroad.OrderID, ChangedOveroad.CoolingPower, ChangedOveroad.ImgageName, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
            }
        }

        private void cbBox2FT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBox2FT.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBox2FT.Tag.ToString(), cbBox2FT.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("SECOND FILTER TYPE", ChangedOveroad.OrderID, ChangedOveroad.CoolingPower, ChangedOveroad.ImgageName, ChangedOveroad.ModuleTag);
                if (BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
            }
        }

        private void cbBox2FS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBox2FS.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(moduleTag, cooling, imageName, order, cbBox2FS.Tag.ToString(), cbBox2FS.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("SECOND FILTERS", ChangedOveroad.OrderID, ChangedOveroad.CoolingPower, ChangedOveroad.ImgageName, ChangedOveroad.ModuleTag);
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
