using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.Zutu.Content;
using EntityFrameworkTryBLL.UnitManager;
using Annon.Zutu;
using Model.Zutu.Unit;
using Annon.Zutu.FrontPhoto;

namespace Annon.Xuanxing
{
    public partial class ModAHUnit : Form
    {

        public int OrderIDToMod { get; set; }//接收父窗体传过来的大订单号
        public ModAHUnit()
        {
            InitializeComponent();

        }
        public Form parentForm;
        int orderID;//窗体间传递订单用

        // 用于窗体调用，根据新建或者编辑订单而初始化本窗体控件数据
        public void InitialForm(int orderNum,Form parent)
        {
            this.parentForm = parent;
            if (orderNum == 0&&parent==null)
            {
                orderID = UnitBLL.initialNewOrder();
                InitialValue(orderID);
            }
            else
            {
                InitialValue(orderNum);
                orderID = orderNum;
            }
        }

        
        private void NewUnitForm_Load(object sender, EventArgs e)
        {

        }

        //初始化窗体控件数据
        public void InitialValue(int orderid)
        {
            List<UnitModel> unitType_Data = UnitBLL.getAllModels("Type",orderid);
            unitType.SelectedIndexChanged -= new EventHandler(unitType_SelectedIndexChanged);
            unitType.DataSource = unitType_Data;
            unitType.DisplayMember = "ValueDescription";
            unitType.SelectedIndex = -1;
            unitType.ValueMember = "Value";
            unitType.Text = unitType_Data.First().Default;
            unitType.Enabled = false;
            unitType.SelectedIndexChanged += new EventHandler(unitType_SelectedIndexChanged);

            List<UnitModel> unitSize_Data = UnitBLL.getAllModels("Unit Size",orderid);
            unitSize.SelectedIndexChanged -= new EventHandler(unitSize_SelectedIndexChanged);
            unitSize.DataSource = unitSize_Data;
            unitSize.DisplayMember = "ValueDescription";
            unitSize.SelectedIndex = -1;
            unitSize.ValueMember = "Value";
            unitSize.Text = unitSize_Data.First().Default;
            unitSize.SelectedIndexChanged += new EventHandler(unitSize_SelectedIndexChanged);

            List<UnitModel> SupplyAiFl_Data = UnitBLL.getAllModels("Supply Air Flow",orderid);
            SupplyAiFl.SelectedIndexChanged -= new EventHandler(SupplyAiFl_SelectedIndexChanged);
            SupplyAiFl.DataSource = SupplyAiFl_Data;
            SupplyAiFl.DisplayMember = "ValueDescription";
            SupplyAiFl.SelectedIndex = -1;
            SupplyAiFl.ValueMember = "Value";
            SupplyAiFl.Text = SupplyAiFl_Data.First().Default;
            SupplyAiFl.SelectedIndexChanged += new EventHandler(SupplyAiFl_SelectedIndexChanged);

            List<UnitModel> voltage_Data = UnitBLL.getAllModels("Voltage", orderid);
            voltage.SelectedIndexChanged -= new EventHandler(voltage_SelectedIndexChanged);
            voltage.DataSource = voltage_Data;
            voltage.DisplayMember = "ValueDescription";
            voltage.SelectedIndex = -1;
            voltage.ValueMember = "Value";
            voltage.Text = voltage_Data.First().Default;
            voltage.SelectedIndexChanged += new EventHandler(voltage_SelectedIndexChanged);

            List<UnitModel> assembly_Data = UnitBLL.getAllModels("Assembly", orderid);
            assembly.SelectedIndexChanged -= new EventHandler(assembly_SelectedIndexChanged);
            assembly.DataSource = assembly_Data;
            assembly.DisplayMember = "ValueDescription";
            assembly.SelectedIndex = -1;
            assembly.ValueMember = "Value";
            assembly.Text = assembly_Data.First().Default;
            assembly.SelectedIndexChanged += new EventHandler(assembly_SelectedIndexChanged);

            List<UnitModel> wiring_Data = UnitBLL.getAllModels("Wiring", orderid);
            wiring.SelectedIndexChanged -= new EventHandler(wiring_SelectedIndexChanged);
            wiring.DataSource = wiring_Data;
            wiring.DisplayMember = "ValueDescription";
            wiring.SelectedIndex = -1;
            wiring.ValueMember = "Value";
            wiring.Text = wiring_Data.First().Default;
            wiring.SelectedIndexChanged += new EventHandler(wiring_SelectedIndexChanged);

            List<UnitModel> painting_Data = UnitBLL.getAllModels("painting", orderid);
            painting.SelectedIndexChanged -= new EventHandler(painting_SelectedIndexChanged);
            painting.DataSource = painting_Data;
            painting.DisplayMember = "ValueDescription";
            painting.SelectedIndex = -1;
            painting.ValueMember = "Value";
            painting.Text = painting_Data.First().Default;
            painting.SelectedIndexChanged += new EventHandler(painting_SelectedIndexChanged);

            List<UnitModel> baseRail_Data = UnitBLL.getAllModels("Base Rail", orderid);
            baseRail.SelectedIndexChanged -= new EventHandler(baseRail_SelectedIndexChanged);
            baseRail.DataSource = baseRail_Data;
            baseRail.DisplayMember = "ValueDescription";
            baseRail.SelectedIndex = -1;
            baseRail.ValueMember = "Value";
            baseRail.Text = baseRail_Data.First().Default;
            baseRail.SelectedIndexChanged += new EventHandler(baseRail_SelectedIndexChanged);

            List<UnitModel> unitSpec_Data = UnitBLL.getAllModels("Special", orderid);
            unitSpec.SelectedIndexChanged -= new EventHandler(unitSpec_SelectedIndexChanged);
            unitSpec.DataSource = unitSpec_Data;
            unitSpec.DisplayMember = "ValueDescription";
            unitSpec.SelectedIndex = -1;
            unitSpec.ValueMember = "Value";
            unitSpec.Text = unitSpec_Data.First().Default;
            unitSpec.SelectedIndexChanged += new EventHandler(unitSpec_SelectedIndexChanged);

        }

        //存在约束条件时，重新绑定数据
        public void BoundData( List<UnitModel> boundData )
        {
            foreach (UnitModel propertyName in boundData)
            {
                if (propertyName.Property == "Type")
                {
                    List<UnitModel> unitType_Data = boundData;
                    unitType.DataSource = unitType_Data;
                    unitType.DisplayMember = "ValueDescription";
                    unitType.SelectedIndex = 0;
                    unitType.ValueMember = "Value";
                    unitType.Text = unitType.SelectedValue.ToString();
                }
                if (propertyName.Property == "Unit Size")
                {
                    List<UnitModel> unitSize_Data = boundData;
                    unitSize.DataSource = unitSize_Data;
                    unitSize.DisplayMember = "ValueDescription";
                    unitSize.SelectedIndex = 0;
                    unitSize.ValueMember = "Value";
                    unitSize.Text = unitSize.SelectedValue.ToString();

                }

                if (propertyName.Property == "Supply Air Flow")
                {
                    List<UnitModel> SupplyAiFl_Data = boundData;
                    SupplyAiFl.DataSource = SupplyAiFl_Data;
                    SupplyAiFl.DisplayMember = "ValueDescription";
                    SupplyAiFl.SelectedIndex = 0;
                    SupplyAiFl.ValueMember = "Value";
                    SupplyAiFl.Text = SupplyAiFl.SelectedValue.ToString();
                }

                if (propertyName.Property == "Voltage")
                {
                    List<UnitModel> voltage_Data = boundData;
                    voltage.DataSource = voltage_Data;
                    voltage.DisplayMember = "ValueDescription";
                    voltage.SelectedIndex = 0;
                    voltage.ValueMember = "Value";
                    voltage.Text = voltage.SelectedValue.ToString() ;
                }

                if (propertyName.Property == "Assembly")
                {
                    List<UnitModel> assembly_Data = boundData;
                    assembly.DataSource = assembly_Data;
                    assembly.DisplayMember = "ValueDescription";
                    assembly.SelectedIndex = 0;
                    assembly.ValueMember = "Value";
                    assembly.Text = assembly.SelectedValue.ToString();
                }

                if (propertyName.Property == "Wiring")
                {
                    List<UnitModel> wiring_Data = boundData;
                    wiring.DataSource = wiring_Data;
                    wiring.DisplayMember = "ValueDescription";
                    wiring.SelectedIndex = 0;
                    wiring.ValueMember = "Value";
                    wiring.Text = wiring.SelectedValue.ToString();
                }

                if (propertyName.Property == "Painting")
                {
                    List<UnitModel> painting_Data = boundData;
                    painting.DataSource = painting_Data;
                    painting.DisplayMember = "ValueDescription";
                    painting.SelectedIndex = 0;
                    painting.ValueMember = "Value";
                    painting.Text = painting.SelectedValue.ToString();
                }

                if (propertyName.Property == "Base Rail")
                {
                    List<UnitModel> baseRail_Data = boundData;
                    baseRail.DataSource = baseRail_Data;
                    baseRail.DisplayMember = "ValueDescription";
                    baseRail.SelectedIndex = 0;
                    baseRail.ValueMember = "Value";
                    baseRail.Text = baseRail.SelectedValue.ToString();
                }

                if (propertyName.Property == "Special")
                {
                    List<UnitModel> unitSpec_Data = boundData;
                    unitSpec.DataSource = unitSpec_Data;
                    unitSpec.DisplayMember = "ValueDescription";
                    unitSpec.SelectedIndex = 0;
                    unitSpec.ValueMember = "Value";
                    unitSpec.Text = unitSpec.SelectedValue.ToString();
                }
            }

        }

        //取消按钮，同时删除已经建立的当前订单
        private void cancel_button_Click(object sender, EventArgs e)
        {
            //UnitBLL.deleteOrder(orderID);
            this.Close();
        }

        //对窗体控件数据进行选择时，依据约束重新绑定控件数据
        private void unitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (unitType.SelectedIndex != -1)
            {
                UnitBLL.saveOrder(orderID, "Type", unitType.SelectedValue.ToString());
                List<UnitModel> Bound_Data = UnitBLL.getAllByCondition("Type", orderID);
                if (Bound_Data.Count > 0)
                {
                    BoundData(Bound_Data);
                }
                UnitBLL.saveOrder(orderID, "Type", unitType.SelectedValue.ToString());
            }
        }

        private void unitSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (unitSize.SelectedIndex != -1)
            {
                UnitBLL.saveOrder(orderID, "Unit Size", unitSize.SelectedValue.ToString());
                List<UnitModel> Bound_Data = UnitBLL.getAllByCondition("Unit Size", orderID);
                if (Bound_Data.Count > 0)
                {
                    BoundData(Bound_Data);
                }
                UnitBLL.saveOrder(orderID, "Unit Size", unitSize.SelectedValue.ToString());
            }
            OperatePhoto operatePhoto = (OperatePhoto)parentForm;
            operatePhoto.refreshedByModAhUint(FrontPhotoImageModelService.currentTagIndex);
            operatePhoto.reFreshEdByReplace(FrontPhotoImageModelService.currentTagIndex);
            operatePhoto.reFreshRightPanelByCoolingType(Convert.ToInt32(unitSize.SelectedValue.ToString()));
            
        }

        private void SupplyAiFl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SupplyAiFl.SelectedIndex != -1)
            {
                UnitBLL.saveOrder(orderID, "upply Air Flow", SupplyAiFl.SelectedValue.ToString());
                List<UnitModel> Bound_Data = UnitBLL.getAllByCondition("Supply Air Flow", orderID);
                if (Bound_Data.Count > 0)
                {
                    BoundData(Bound_Data);
                }
                UnitBLL.saveOrder(orderID, "upply Air Flow", SupplyAiFl.SelectedValue.ToString());
            }
            OperatePhoto operatePhoto = (OperatePhoto)parentForm;
            if (SupplyAiFl.Text.Equals("L=Left Hand Flow"))
            {
                operatePhoto.leftMove_Click(sender, e);
            }
            else
            { 
                operatePhoto.rightMove_Click(sender, e);
            }
        }

        private void voltage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (voltage.SelectedIndex != -1)
            {
                UnitBLL.saveOrder(orderID, "Voltage", voltage.SelectedValue.ToString());
                List<UnitModel> Bound_Data = UnitBLL.getAllByCondition("Voltage", orderID);
                if (Bound_Data.Count > 0)
                {
                    BoundData(Bound_Data);
                }
                UnitBLL.saveOrder(orderID, "Voltage", voltage.SelectedValue.ToString());
            }
        }

        private void assembly_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (assembly.SelectedIndex != -1)
            {
                List<UnitModel> Bound_Data = UnitBLL.getAllByCondition("Assembly", orderID);
                if (Bound_Data.Count > 0)
                {
                    BoundData(Bound_Data);
                }
                UnitBLL.saveOrder(orderID, "Assembly", assembly.SelectedValue.ToString());
            }
        }

        private void wiring_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (wiring.SelectedIndex != -1)
            {
                List<UnitModel> Bound_Data = UnitBLL.getAllByCondition("Wiring", orderID);
                if (Bound_Data.Count > 0)
                {
                    BoundData(Bound_Data);
                }
                UnitBLL.saveOrder(orderID, "Wiring", wiring.SelectedValue.ToString());
            }
        }

        private void painting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (painting.SelectedIndex != -1)
            {
                List<UnitModel> Bound_Data = UnitBLL.getAllByCondition("Painting", orderID);
                if (Bound_Data.Count > 0)
                {
                    BoundData(Bound_Data);
                }
                UnitBLL.saveOrder(orderID, "Painting", painting.SelectedValue.ToString());
            }
        }

        private void baseRail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (baseRail.SelectedIndex != -1)
            {
                List<UnitModel> Bound_Data = UnitBLL.getAllByCondition("Base Rail", orderID);
                if (Bound_Data.Count > 0)
                {
                    BoundData(Bound_Data);
                }
                UnitBLL.saveOrder(orderID, "Base Rail", baseRail.SelectedValue.ToString());
            }
        }

        private void unitSpec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (unitSpec.SelectedIndex != -1)
            {
                List<UnitModel> Bound_Data = UnitBLL.getAllByCondition("Special", orderID);
                if (Bound_Data.Count > 0)
                {
                    BoundData(Bound_Data);
                }
                UnitBLL.saveOrder(orderID, "Special", unitSpec.SelectedValue.ToString());
            }
        }

        //将窗体数据传递给调用窗体
        private void ok_button_Click(object sender, EventArgs e)
        {
            OperatePhotoNeedData dataDeatil = new OperatePhotoNeedData();
            dataDeatil.orderID = orderID;
            if (unitType.SelectedIndex == -1)
                dataDeatil.unitType = unitType.Text.ToString();
            else
                dataDeatil.unitType = unitType.SelectedValue.ToString();
            
            if (unitSize.SelectedIndex == -1)
                dataDeatil.unitSize = unitSize.Text.ToString();
            else
                dataDeatil.unitSize = unitSize.SelectedValue.ToString();

            if (SupplyAiFl.SelectedIndex == -1)
                dataDeatil.supplyAirFlow = SupplyAiFl.Text.ToString();
            else
                dataDeatil.supplyAirFlow = SupplyAiFl.SelectedValue.ToString();

            if (voltage.SelectedIndex == -1)
                dataDeatil.voltage = voltage.Text.ToString();
            else
                dataDeatil.voltage = voltage.SelectedValue.ToString();

            if (assembly.SelectedIndex == -1)
                dataDeatil.assembly = assembly.Text.ToString();
            else
                dataDeatil.assembly = assembly.SelectedValue.ToString();

            if (wiring.SelectedIndex == -1)
                dataDeatil.wring = wiring.Text.ToString();
            else
                dataDeatil.wring = wiring.SelectedValue.ToString();

            if (painting.SelectedIndex == -1)
                dataDeatil.paining = painting.Text.ToString();
            else
                dataDeatil.paining = painting.SelectedValue.ToString();

            if (baseRail.SelectedIndex == -1)
                dataDeatil.baseRail = baseRail.Text.ToString();
            else
                dataDeatil.baseRail = baseRail.SelectedValue.ToString();

            if (unitSpec.SelectedIndex == -1)
                dataDeatil.uniteSpecial = unitSpec.Text.ToString();
            else
                dataDeatil.uniteSpecial = unitSpec.SelectedValue.ToString();

            if (radioButton1.Checked == true)
                dataDeatil.startUnitAs = "Basic Air Handler";
            else
                dataDeatil.startUnitAs = "Energy Recovery Wheel Air Handler";



            dataDeatil.unitTag = textBox1.Text;
            FrontPhotoImageModelService.operatePhotoNeedData = dataDeatil;
            FrontPhotoImageModelService.orderId = dataDeatil.orderID;
            FrontPhotoService.startUnitAs = dataDeatil.startUnitAs;
            if (this.parentForm == null)
            {

                FrontPhotoService.coolingType =Convert.ToInt32(dataDeatil.unitSize);
                OperatePhoto operatePhoto = new OperatePhoto(); 
                operatePhoto.setOperatePhotoNeedData(dataDeatil, OrderIDToMod);
                operatePhoto.ShowDialog();
                this.Close();
            }
            else
            {
                OperatePhoto operatePhoto = (OperatePhoto)parentForm;
                operatePhoto.setOperatePhotoNeedData(dataDeatil, OrderIDToMod);
                operatePhoto.refreshedByModAhUint(FrontPhotoImageModelService.currentTagIndex);
                operatePhoto.reFreshEdByReplace(FrontPhotoImageModelService.currentTagIndex);
                operatePhoto.reFreshRightPanelByCoolingType(Convert.ToInt32(dataDeatil.unitSize));
                this.Close();
            }
            
        }
    }
}
