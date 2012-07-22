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

namespace Annon.Xuanxing
{
    public partial class ModAHUnit : Form
    {
        public ModAHUnit()
        {
            InitializeComponent();
            //unitType.Text = "H";
            //unitSize.Text = "008[2000-4 400CFM]";
            //SupplyAiFl.Text = "R = Right Hand Flow";
            //voltage.Text = "2=230V / 3P / 60HZ";
            //assembly.Text = "A= Factory Assembled";
            //wiring.Text = "A = Ctl Wired in Fan Box";
            //painting.Text = "0";
            //baseRail.Text = "C = 6 inches High";
            //unitSpec.Text = "0 = None";
        }

        private void NewUnitForm_Load(object sender, EventArgs e)
        {
            orderID = UnitBLL.initialNewOrder();
            InitialValue();
            

        }
        int orderID=1;
        //初始化数据
        public void InitialValue()
        {
            
            List<Model.Zutu.Unit.UnitModel> unitType_Data = UnitBLL.getAllModels("Type");
            unitType.SelectedIndexChanged -= new EventHandler(unitType_SelectedIndexChanged);
            unitType.DataSource = unitType_Data;
            unitType.DisplayMember = "ValueDescription";
            unitType.SelectedIndex = -1;
            unitType.ValueMember = "Value";
            unitType.Text = unitType_Data.First().Default;
            unitType.Enabled = false;
            unitType.SelectedIndexChanged += new EventHandler(unitType_SelectedIndexChanged);

            List<Model.Zutu.Unit.UnitModel> unitSize_Data = UnitBLL.getAllModels("Unit Size");
            unitSize.SelectedIndexChanged -= new EventHandler(unitSize_SelectedIndexChanged);
            unitSize.DataSource = unitSize_Data;
            unitSize.DisplayMember = "ValueDescription";
            unitSize.SelectedIndex = -1;
            unitSize.ValueMember = "Value";
            unitSize.Text = unitSize_Data.First().Default;
            unitSize.SelectedIndexChanged += new EventHandler(unitSize_SelectedIndexChanged);

            List<Model.Zutu.Unit.UnitModel> SupplyAiFl_Data = UnitBLL.getAllModels("Supply Air Flow");
            SupplyAiFl.SelectedIndexChanged -= new EventHandler(SupplyAiFl_SelectedIndexChanged);
            SupplyAiFl.DataSource = SupplyAiFl_Data;
            SupplyAiFl.DisplayMember = "ValueDescription";
            SupplyAiFl.SelectedIndex = -1;
            SupplyAiFl.ValueMember = "Value";
            SupplyAiFl.Text = SupplyAiFl_Data.First().Default;
            SupplyAiFl.SelectedIndexChanged += new EventHandler(SupplyAiFl_SelectedIndexChanged);

            List<Model.Zutu.Unit.UnitModel> voltage_Data = UnitBLL.getAllModels("Voltage");
            voltage.SelectedIndexChanged -= new EventHandler(voltage_SelectedIndexChanged);
            voltage.DataSource = voltage_Data;
            voltage.DisplayMember = "ValueDescription";
            voltage.SelectedIndex = -1;
            voltage.ValueMember = "Value";
            voltage.Text = voltage_Data.First().Default;
            voltage.SelectedIndexChanged += new EventHandler(voltage_SelectedIndexChanged);

            List<Model.Zutu.Unit.UnitModel> assembly_Data = UnitBLL.getAllModels("Assembly");
            assembly.SelectedIndexChanged -= new EventHandler(assembly_SelectedIndexChanged);
            assembly.DataSource = assembly_Data;
            assembly.DisplayMember = "ValueDescription";
            assembly.SelectedIndex = -1;
            assembly.ValueMember = "Value";
            assembly.Text = assembly_Data.First().Default;
            assembly.SelectedIndexChanged += new EventHandler(assembly_SelectedIndexChanged);

            List<Model.Zutu.Unit.UnitModel> wiring_Data = UnitBLL.getAllModels("Wiring");
            wiring.SelectedIndexChanged -= new EventHandler(wiring_SelectedIndexChanged);
            wiring.DataSource = wiring_Data;
            wiring.DisplayMember = "ValueDescription";
            wiring.SelectedIndex = -1;
            wiring.ValueMember = "Value";
            wiring.Text = wiring_Data.First().Default;
            wiring.SelectedIndexChanged += new EventHandler(wiring_SelectedIndexChanged);

            List<Model.Zutu.Unit.UnitModel> painting_Data = UnitBLL.getAllModels("painting");
            painting.SelectedIndexChanged -= new EventHandler(painting_SelectedIndexChanged);
            painting.DataSource = painting_Data;
            painting.DisplayMember = "ValueDescription";
            painting.SelectedIndex = -1;
            painting.ValueMember = "Value";
            painting.Text = painting_Data.First().Default;
            painting.SelectedIndexChanged += new EventHandler(painting_SelectedIndexChanged);

            List<Model.Zutu.Unit.UnitModel> baseRail_Data = UnitBLL.getAllModels("Base Rail");
            baseRail.SelectedIndexChanged -= new EventHandler(baseRail_SelectedIndexChanged);
            baseRail.DataSource = baseRail_Data;
            baseRail.DisplayMember = "ValueDescription";
            baseRail.SelectedIndex = -1;
            baseRail.ValueMember = "Value";
            baseRail.Text = baseRail_Data.First().Default;
            baseRail.SelectedIndexChanged += new EventHandler(baseRail_SelectedIndexChanged);

            List<Model.Zutu.Unit.UnitModel> unitSpec_Data = UnitBLL.getAllModels("Special");
            unitSpec.SelectedIndexChanged -= new EventHandler(unitSpec_SelectedIndexChanged);
            unitSpec.DataSource = unitSpec_Data;
            unitSpec.DisplayMember = "ValueDescription";
            unitSpec.SelectedIndex = -1;
            unitSpec.ValueMember = "Value";
            unitSpec.Text = unitSpec_Data.First().Default;
            unitSpec.SelectedIndexChanged += new EventHandler(unitSpec_SelectedIndexChanged);

        }

        public void BoundData( List<Model.Zutu.Unit.UnitModel> boundData )
        {
            foreach (Model.Zutu.Unit.UnitModel propertyName in boundData)
            {
                if (propertyName.Property == "Type")
                {
                    List<Model.Zutu.Unit.UnitModel> unitType_Data = boundData;
                    unitType.DataSource = unitType_Data;
                    unitType.DisplayMember = "ValueDescription";
                    unitType.SelectedIndex = -1;
                    unitType.ValueMember = "Value";
                    unitType.Text = unitType_Data.First().Default;
                }
                if (propertyName.Property == "Unit Size")
                {
                    List<Model.Zutu.Unit.UnitModel> unitSize_Data = boundData;
                    unitSize.DataSource = unitSize_Data;
                    unitSize.DisplayMember = "ValueDescription";
                    unitSize.SelectedIndex = -1;
                    unitSize.ValueMember = "Value";
                    unitSize.Text = unitSize_Data.First().Default;

                }

                if (propertyName.Property == "Supply Air Flow")
                {
                    List<Model.Zutu.Unit.UnitModel> SupplyAiFl_Data = boundData;
                    SupplyAiFl.DataSource = SupplyAiFl_Data;
                    SupplyAiFl.DisplayMember = "ValueDescription";
                    SupplyAiFl.SelectedIndex = -1;
                    SupplyAiFl.ValueMember = "Value";
                    SupplyAiFl.Text = SupplyAiFl_Data.First().Default;
                }

                if (propertyName.Property == "Voltage")
                {
                    List<Model.Zutu.Unit.UnitModel> voltage_Data = boundData;
                    voltage.DataSource = voltage_Data;
                    voltage.DisplayMember = "ValueDescription";
                    voltage.SelectedIndex = -1;
                    voltage.ValueMember = "Value";
                    voltage.Text = voltage_Data.First().Default;
                }

                if (propertyName.Property == "Assembly")
                {
                    List<Model.Zutu.Unit.UnitModel> assembly_Data = boundData;
                    assembly.DataSource = assembly_Data;
                    assembly.DisplayMember = "ValueDescription";
                    assembly.SelectedIndex = -1;
                    assembly.ValueMember = "Value";
                    assembly.Text = assembly_Data.First().Default;
                }

                if (propertyName.Property == "Wiring")
                {
                    List<Model.Zutu.Unit.UnitModel> wiring_Data = boundData;
                    wiring.DataSource = wiring_Data;
                    wiring.DisplayMember = "ValueDescription";
                    wiring.SelectedIndex = -1;
                    wiring.ValueMember = "Value";
                    wiring.Text = wiring_Data.First().Default;
                }

                if (propertyName.Property == "Painting")
                {
                    List<Model.Zutu.Unit.UnitModel> painting_Data = boundData;
                    painting.DataSource = painting_Data;
                    painting.DisplayMember = "ValueDescription";
                    painting.SelectedIndex = -1;
                    painting.ValueMember = "Value";
                    painting.Text = painting_Data.First().Default;
                }

                if (propertyName.Property == "Base Rail")
                {
                    List<Model.Zutu.Unit.UnitModel> baseRail_Data = boundData;
                    baseRail.DataSource = baseRail_Data;
                    baseRail.DisplayMember = "ValueDescription";
                    baseRail.SelectedIndex = -1;
                    baseRail.ValueMember = "Value";
                    baseRail.Text = baseRail_Data.First().Default;
                }

                if (propertyName.Property == "Special")
                {
                    List<Model.Zutu.Unit.UnitModel> unitSpec_Data = boundData;
                    unitSpec.DataSource = unitSpec_Data;
                    unitSpec.DisplayMember = "ValueDescription";
                    unitSpec.SelectedIndex = -1;
                    unitSpec.ValueMember = "Value";
                    unitSpec.Text = unitSpec_Data.First().Default;
                }
            }


        }
        private void cancel_button_Click(object sender, EventArgs e)
        {
            UnitBLL.deleteOrder(orderID);
            this.Close();
        }

        private void unitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (unitType.SelectedIndex != -1)
            {
                UnitBLL.saveOrder(orderID, "Type", unitType.SelectedValue.ToString());
                List<Model.Zutu.Unit.UnitModel> Bound_Data = UnitBLL.getAllByCondition("Type", orderID);
                if (Bound_Data.Count > 0)
                {
                    BoundData(Bound_Data);
                }
            }
        }

        private void unitSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (unitSize.SelectedIndex != -1)
            {
                UnitBLL.saveOrder(orderID, "Unit Size", unitSize.SelectedValue.ToString());
                List<Model.Zutu.Unit.UnitModel> Bound_Data = UnitBLL.getAllByCondition("Unit Size", orderID);
                if (Bound_Data.Count > 0)
                {
                    BoundData(Bound_Data);
                }
            }
            
        }

        private void SupplyAiFl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SupplyAiFl.SelectedIndex != -1)
            {
                UnitBLL.saveOrder(orderID, "upply Air Flow", SupplyAiFl.SelectedValue.ToString());
                List<Model.Zutu.Unit.UnitModel> Bound_Data = UnitBLL.getAllByCondition("Supply Air Flow", orderID);
                if (Bound_Data.Count > 0)
                {
                    BoundData(Bound_Data);
                }
            }
        }

        private void voltage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (voltage.SelectedIndex != -1)
            {
                UnitBLL.saveOrder(orderID, "Voltage", voltage.SelectedValue.ToString());
                List<Model.Zutu.Unit.UnitModel> Bound_Data = UnitBLL.getAllByCondition("Voltage", orderID);
                if (Bound_Data.Count > 0)
                {
                    BoundData(Bound_Data);
                }
            }
        }

        private void assembly_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (assembly.SelectedIndex != -1)
            {
                List<Model.Zutu.Unit.UnitModel> Bound_Data = UnitBLL.getAllByCondition("Assembly", orderID);
                if (Bound_Data.Count > 0)
                {
                    BoundData(Bound_Data);
                }
            }
        }

        private void wiring_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (wiring.SelectedIndex != -1)
            {
                List<Model.Zutu.Unit.UnitModel> Bound_Data = UnitBLL.getAllByCondition("Wiring", orderID);
                if (Bound_Data.Count > 0)
                {
                    BoundData(Bound_Data);
                }
            }
        }

        private void painting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (painting.SelectedIndex != -1)
            {
                List<Model.Zutu.Unit.UnitModel> Bound_Data = UnitBLL.getAllByCondition("Painting", orderID);
                if (Bound_Data.Count > 0)
                {
                    BoundData(Bound_Data);
                }
            }
        }

        private void baseRail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (baseRail.SelectedIndex != -1)
            {
                List<Model.Zutu.Unit.UnitModel> Bound_Data = UnitBLL.getAllByCondition("Base Rail", orderID);
                if (Bound_Data.Count > 0)
                {
                    BoundData(Bound_Data);
                }
            }
        }

        private void unitSpec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (unitSpec.SelectedIndex != -1)
            {
                List<Model.Zutu.Unit.UnitModel> Bound_Data = UnitBLL.getAllByCondition("Special", orderID);
                if (Bound_Data.Count > 0)
                {
                    BoundData(Bound_Data);
                }
            }
        }
    }
}
