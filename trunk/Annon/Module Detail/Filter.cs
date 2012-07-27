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
            imgDetailName.Text = ChangedOveroad.Name + "-" + ChangedOveroad.ModuleTag.Substring(0, 3) + "-" + "P" + "-" + cbBoxFS.Text 
                + "-" + cbBoxSf.Text + "-" + cbBox2FT.Text + "-" + cbBox2FS.Text + "-" + cbBoxFO.Text + "-" + cbBoxSp.Text;
        }

        //更改配置后显示的图块详细配置名字
        private void LaterShowName()
        {
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
       

            string cbBox2FT_text;
            if (cbBox2FT.SelectedValue == null)
                cbBox2FT_text = cbBox2FT.Text;
            else
                cbBox2FT_text = cbBox2FT.SelectedValue.ToString(); 

            string cbBox2FS_text;
            if (cbBox2FS.SelectedValue == null)
                cbBox2FS_text = cbBox2FS.Text;
            else
                cbBox2FS_text = cbBox2FS.SelectedValue.ToString();

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

            imgDetailName.Text = ChangedOveroad.Name + "-" + ChangedOveroad.ModuleTag.Substring(0, 3) + "-" + "P" + "-"
                +cbBoxFS_text+"-"
                +cbBoxSf_text +"-"
                +cbBox2FT_text+"-"
                +cbBox2FS_text +"-"
                +cbBoxFO_text +"-"
                +cbBoxSp_text;
        }

        //初始化函数调用
        public void InitialValue(ImageModel imgItem)
        {
            ChangedOveroad = imgItem;
            //保存窗体信息
            guid = imgItem.Guid;
            cooling = imgItem.coolingType;
            imageName = imgItem.Name;
            order = imgItem.OrderId;

            textBoxTag.Text = imgItem.ModuleTag;
            textBoxFT.Text ="P=Pleated Filter";//没有绑定数据，暂时固定，需要修改
            textBoxDA.Text = ".2";//没有绑定数据，暂时固定，需要修改
            
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

            //显示名字
            FirstShowName();
        }

        //绑定函数调用
        public void BoundValue(List<ContentPropertyValue> boundData)
        {

            //textBoxTag.Text = imgItem.ModuleTag;
            //textBoxFT.Text = "P=Pleated Filter";//没有绑定数据，暂时固定，需要修改
            //textBoxDA.Text = ".2";//没有绑定数据，暂时固定，需要修改

            foreach (ContentPropertyValue propertyname in boundData)
            {
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
                if (propertyname.PropertyName.Trim() == "SECOND FILTER TYPE")
                {
                    List<ContentPropertyValue> cbBox2FT_Data = boundData;
                    cbBox2FT.SelectedIndexChanged -= new EventHandler(cbBox2FT_SelectedIndexChanged);
                    cbBox2FT.DataSource = cbBox2FT_Data;
                    cbBox2FT.DisplayMember = "ValueDescription";
                    cbBox2FT.SelectedIndex = -1;
                    cbBox2FT.ValueMember = "Value";
                    if (!cbBox2FT_Data.Select(s => s.Value).Contains(cbBox2FT_Data.First().Default))
                        cbBox2FT.Text = cbBox2FT_Data.First().Value;
                    else
                        cbBox2FT.Text = cbBox2FT_Data.First().Default;
                    cbBox2FT.SelectedIndexChanged += new EventHandler(cbBox2FT_SelectedIndexChanged);
                }
                if (propertyname.PropertyName.Trim() == "SECOND FILTERS")
                {
                    List<ContentPropertyValue> cbBox2FS_Data = boundData;
                    cbBox2FS.SelectedIndexChanged -= new EventHandler(cbBox2FS_SelectedIndexChanged);
                    cbBox2FS.DataSource = cbBox2FS_Data;
                    cbBox2FS.DisplayMember = "ValueDescription";
                    cbBox2FS.SelectedIndex = -1;
                    cbBox2FS.ValueMember = "Value";
                    if (!cbBox2FS_Data.Select(s => s.Value).Contains(cbBox2FS_Data.First().Default))
                        cbBox2FS.Text = cbBox2FS_Data.First().Value;
                    else
                        cbBox2FS.Text = cbBox2FS_Data.First().Default;
                    cbBox2FS.SelectedIndexChanged += new EventHandler(cbBox2FS_SelectedIndexChanged);
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

        // 下拉列表更改后，进行数据的重新绑定，保存数据到临时表，和配置详细名字的更新
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
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("SAFETY CONTROL", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
                if (BoundData != null && BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                LaterShowName();
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
                LaterShowName();
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
