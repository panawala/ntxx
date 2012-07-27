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
    public partial class BlankBox : Form
    {
        public BlankBox()
        {
            InitializeComponent();
        }

        private void BlankBox_Load(object sender, EventArgs e)
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
            blankBoxName.Text = ChangedOveroad.Name + "-" + ChangedOveroad.ModuleTag.Substring(0, 3) + "-" + "P" + "-" + cbBoxAW.Text
                + "-" + cbBoxSf.Text + "-" + cbBoxDP.Text + "-" + cbBoxSp.Text;
        }
        //更改配置后显示的图块详细配置名字
        private void LaterShowName()
        {
            string cbBoxAW_text;
            if (cbBoxAW.SelectedValue == null)
                cbBoxAW_text = cbBoxAW.Text;
            else
                cbBoxAW_text = cbBoxAW.SelectedValue.ToString();

            string cbBoxSf_text;
            if (cbBoxSf.SelectedValue == null)
                cbBoxSf_text = cbBoxSf.Text;
            else
                cbBoxSf_text = cbBoxSf.SelectedValue.ToString();

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
            blankBoxName.Text = ChangedOveroad.Name + "-" + ChangedOveroad.ModuleTag.Substring(0, 3) + "-" + "P" + "-"
                + cbBoxAW_text + "-"
                + cbBoxSf_text + "-"
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

            //初始化数据
            textBoxTag.Text = imgItem.ModuleTag;

            List<ContentPropertyValue> cbBoxAW_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "AIRWAY TYPE", imgItem.Guid);
            cbBoxAW.SelectedIndexChanged -= new EventHandler(cbBoxAW_SelectedIndexChanged);
            cbBoxAW.DataSource = cbBoxAW_Data;
            cbBoxAW.DisplayMember = "ValueDescription";
            cbBoxAW.SelectedIndex = -1;
            cbBoxAW.ValueMember = "Value"; ;
            cbBoxAW.Text = cbBoxAW_Data.First().Default;
            cbBoxAW.SelectedIndexChanged += new EventHandler(cbBoxAW_SelectedIndexChanged);

            List<ContentPropertyValue> cbBoxSf_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "SAFETY CONTROL", imgItem.Guid);
            cbBoxSf.SelectedIndexChanged -= new EventHandler(cbBoxSf_SelectedIndexChanged);
            cbBoxSf.DataSource = cbBoxSf_Data;
            cbBoxSf.DisplayMember = "ValueDescription";
            cbBoxSf.SelectedIndex = -1;
            cbBoxSf.ValueMember = "Value";
            cbBoxSf.Text = cbBoxSf_Data.First().Default;
            cbBoxSf.SelectedIndexChanged += new EventHandler(cbBoxSf_SelectedIndexChanged);

            List<ContentPropertyValue> cbBoxDP_Data = ContentBLL.getPtyValue(imgItem.coolingType, imgItem.Name, "DRAIN PAN TYPE", imgItem.Guid);
            cbBoxDP.SelectedIndexChanged -= new EventHandler(cbBoxDP_SelectedIndexChanged);
            cbBoxDP.DataSource = cbBoxDP_Data;
            cbBoxDP.DisplayMember = "ValueDescription";
            cbBoxDP.SelectedIndex = -1;
            cbBoxDP.ValueMember = "Value";
            cbBoxDP.Text = cbBoxDP_Data.First().Default;
            cbBoxDP.SelectedIndexChanged += new EventHandler(cbBoxDP_SelectedIndexChanged);

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
               foreach (ContentPropertyValue propertyname in boundData)
               {
                   if (propertyname.PropertyName.Trim() == "AIRWAY TYPE")
                   {
                       List<ContentPropertyValue> cbBoxAW_Data = boundData;
                       cbBoxAW.SelectedIndexChanged -= new EventHandler(cbBoxAW_SelectedIndexChanged);
                       cbBoxAW.DataSource = cbBoxAW_Data;
                       cbBoxAW.DisplayMember = "ValueDescription";
                       cbBoxAW.SelectedIndex = -1;
                       cbBoxAW.ValueMember = "Value"; ;
                       if (!cbBoxAW_Data.Select(s => s.Value).Contains(cbBoxAW_Data.First().Default))
                           cbBoxAW.Text = cbBoxAW_Data.First().Value;
                       else
                           cbBoxAW.Text = cbBoxAW_Data.First().Default;
                       cbBoxAW.SelectedIndexChanged += new EventHandler(cbBoxAW_SelectedIndexChanged);
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
                   if (propertyname.PropertyName.Trim() == "DRAIN PAN TYPE")
                   {

                       List<ContentPropertyValue> cbBoxDP_Data = boundData;
                       cbBoxDP.SelectedIndexChanged -= new EventHandler(cbBoxDP_SelectedIndexChanged);
                       cbBoxDP.DataSource = cbBoxDP_Data;
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
               }

        }

        private void cbBoxAW_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbBoxAW.SelectedIndex!= -1)
            {
                ContentBLL.SaveImageOrder(guid,cooling,imageName,order,cbBoxAW.Tag.ToString(),cbBoxAW.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData=ContentBLL.getAllByCondition("AIRWAY TYPE",ChangedOveroad.OrderId,ChangedOveroad.coolingType,ChangedOveroad.Name,ChangedOveroad.ModuleTag);
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

        private void cbBoxDP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxDP.SelectedIndex != -1)
            {
                ContentBLL.SaveImageOrder(guid, cooling, imageName, order, cbBoxDP.Tag.ToString(), cbBoxDP.SelectedValue.ToString());
                List<ContentPropertyValue> BoundData = ContentBLL.getAllByCondition("DRAIN PAN TYPE", ChangedOveroad.OrderId, ChangedOveroad.coolingType, ChangedOveroad.Name, ChangedOveroad.Guid);
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
                if (BoundData != null && BoundData.Count > 0)
                {
                    BoundValue(BoundData);//重新加载数据
                }
                LaterShowName();
            }
        }
 
    }
}
