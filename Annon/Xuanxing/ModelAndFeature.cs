using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityFrameworkTryBLL;
using Model.Property;

namespace Annon.Xuanxing
{
    public partial class ModelAndFeature : Form
    {
        public string valueCode { set; get; }
        public string propertyName { set; get; }
        public ModelAndFeature()
        {
            InitializeComponent();


            //DeviceBLL.InitialDevices(1, 1);

            leftDataGridView_Load(null,null);
            //6-19注销
            //rightDataGridView_Load(null, null);
        }

        private void leftDataGridView_Load(object sender, EventArgs e)
        {
            this.c.Columns.Add("CatalogName", "");

            this.c.Columns.Add("PropertyName", "");





            for (int j = 0; j < this.c.ColumnCount; j++)
            {
                if (j == 0)
                    this.c.Columns[j].Width = 100;
                else if (j == 1)
                {
                    this.c.Columns[j].Width = 262;
                }

            }

            this.c.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            this.c.ColumnHeadersHeight = this.c.ColumnHeadersHeight * 2;

            this.c.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            this.c.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);

            this.c.Paint += new PaintEventHandler(dataGridView1_Paint);

        }
        void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

            string[] monthes = { "特征操作" };

            for (int j = 0; j < monthes.Length; )
            {

                Rectangle r1 = this.c.GetCellDisplayRectangle(j, -1, true); //get the column header cell

                r1.X += 1;

                r1.Y += 1;

                r1.Width = (r1.Width + this.c.GetCellDisplayRectangle(j + 1, -1, true).Width) - 2;

                r1.Height = r1.Height / 2 - 2;

                e.Graphics.FillRectangle(new SolidBrush(this.c.ColumnHeadersDefaultCellStyle.BackColor), r1);

                StringFormat format = new StringFormat();

                format.Alignment = StringAlignment.Center;

                format.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(monthes[j / 2],

                    this.c.ColumnHeadersDefaultCellStyle.Font,

                    new SolidBrush(this.c.ColumnHeadersDefaultCellStyle.ForeColor),

                    r1,

                    format);

                j += 2;

            }

        }

        void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {

                e.PaintBackground(e.CellBounds, false);



                Rectangle r2 = e.CellBounds;

                r2.Y += e.CellBounds.Height / 2;

                r2.Height = e.CellBounds.Height / 2;

                e.PaintContent(r2);

                e.Handled = true;

            }

        }


        private void rightDataGridView_Load(object sender, EventArgs e)
        {
            this.dataGridView_PropertyValue.Columns.Add("ValueCode", "代码");
            this.dataGridView_PropertyValue.Columns.Add("ValueDescription", "描述");
            this.dataGridView_PropertyValue.Columns.Add("Price", "价格");
            this.dataGridView_PropertyValue.Columns.Add("PropertyValueType", "类型");
         



            for (int j = 0; j < this.dataGridView_PropertyValue.ColumnCount; j++)
            {
                if (j == 0)
                    this.dataGridView_PropertyValue.Columns[j].Width = 80;
                else if (j == 1)
                {
                    this.dataGridView_PropertyValue.Columns[j].Width = 552;
                }
                else if (j == 2)
                {
                    this.dataGridView_PropertyValue.Columns[j].Width = 100;
                }

            }

            this.dataGridView_PropertyValue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            this.dataGridView_PropertyValue.ColumnHeadersHeight = this.dataGridView_PropertyValue.ColumnHeadersHeight * 2;

            this.dataGridView_PropertyValue.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            this.dataGridView_PropertyValue.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView2_CellPainting);

            this.dataGridView_PropertyValue.Paint += new PaintEventHandler(dataGridView2_Paint);

        }
        /// <summary>
        /// 暂时注销，6-19
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dataGridView2_Paint(object sender, PaintEventArgs e)
        {
            //string[] monthes = { "电压" };

            //for (int j = 0; j < monthes.Length; )
            //{

            //    Rectangle r1 = this.dataGridView_PropertyValue.GetCellDisplayRectangle(j, -1, true); //get the column header cell

            //    r1.X += 1;

            //    r1.Y += 1;

            //    r1.Width = (r1.Width + this.dataGridView_PropertyValue.GetCellDisplayRectangle(j + 1, -1, true).Width + this.dataGridView_PropertyValue.GetCellDisplayRectangle(j + 2, -1, true).Width) - 2;

            //    r1.Height = r1.Height / 2 - 2;

            //    e.Graphics.FillRectangle(new SolidBrush(this.dataGridView_PropertyValue.ColumnHeadersDefaultCellStyle.BackColor), r1);

            //    StringFormat format = new StringFormat();

            //    format.Alignment = StringAlignment.Center;

            //    format.LineAlignment = StringAlignment.Center;

            //    e.Graphics.DrawString(monthes[j / 2],

            //        this.dataGridView_PropertyValue.ColumnHeadersDefaultCellStyle.Font,

            //        new SolidBrush(this.dataGridView_PropertyValue.ColumnHeadersDefaultCellStyle.ForeColor),

            //        r1,

            //        format);

            //    j += 2;

            //}

        }



        void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {

                e.PaintBackground(e.CellBounds, false);



                Rectangle r2 = e.CellBounds;

                r2.Y += e.CellBounds.Height / 2;

                r2.Height = e.CellBounds.Height / 2;

                e.PaintContent(r2);

                e.Handled = true;

            }

        }
       
        //模型按钮事件
        private void btn_Model_Click(object sender, EventArgs e)
        {
            try
            {
                

                c.AutoGenerateColumns = false;
                c.DataSource = PropertyBLL.GetPropertiesByDeviceId(1,0);
                c.Columns[0].DataPropertyName = "CatalogName";
                c.Columns[1].DataPropertyName = "PropertyName";
                if (c.Rows.Count > 0)
                {
                    String strPropertyName = (String)c.Rows[0].Cells["PropertyName"].Value;
                    propertyName = strPropertyName;
                }
                cellStyleChanged(this.c);


                dataGridView_PropertyValue.AutoGenerateColumns = false;
                //dataGridView_PropertyValue.DataSource = PropertyBLL.GetPtyValuesByDeviceandPtyId(1, 4);
                dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, propertyName, 1);
                
                dataGridView_PropertyValue.Columns[0].DataPropertyName = "ValueCode";
                dataGridView_PropertyValue.Columns[1].DataPropertyName = "ValueDescription";
                dataGridView_PropertyValue.Columns[2].DataPropertyName = "Price";
                dataGridView_PropertyValue.Columns[3].DataPropertyName = "PropertyValueType";//其实没隐藏
                dataGridView_PropertyValue.Columns[4].DataPropertyName = "ValueCodeID";
                dataGridView_PropertyValue.CurrentCell = dataGridView_PropertyValue.Rows[0].Cells["ValueCodeID"];
                //dataGridView_PropertyValue.Columns[3].Visible = false;
                
               
                cellStyleChanged(this.dataGridView_PropertyValue);
                //设置默认值
                setDefaultSelectedValue(propertyName);

            }
            catch (Exception ex)
            {
                Console.WriteLine(""+ex.Message);
            }
            
        }
        //dataGridview事件
        private void dataGridView_Property_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex==-1)return;
            String str=(String)c.Rows[e.RowIndex].Cells["PropertyName"].Value;
            dataGridView_PropertyValue.AutoGenerateColumns = false;
            //dataGridView_PropertyValue.DataSource = PropertyBLL.GetPtyValuesByDeviceandPtyName(1,str);
           // dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, str, 1);
            dataGridView_PropertyValue.DataSource = PropertyBLL.GetAvaliablePtyValueRange(1, str, 1);
            String strPropertyName = (String)c.Rows[e.RowIndex].Cells["PropertyName"].Value;
            propertyName = strPropertyName;
            cellStyleChanged(this.dataGridView_PropertyValue);

            

            //最上面面板值变化
            //更新面板label颜色
            label_ChangedByPropertyName(propertyName);
            //设置默认值;
            setDefaultSelectedValue(propertyName);

        }

      
        //dataGridview事件
        private void dataGridView_PropertyValue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            String strValueCode = (String)dataGridView_PropertyValue.Rows[e.RowIndex].Cells["ValueCode"].Value;
            valueCode = strValueCode;
            string strValueID = "" + (int)dataGridView_PropertyValue.Rows[e.RowIndex].Cells["ValueCodeID"].Value;
            
            //设置属性值的gridview的选中后，设置其他的属性的值
            var propertyModels = PropertyBLL.GetDirectRedPtyModelsLogic(1, propertyName, strValueID, 1);



            //单击时最上面面板值变化
            set_ShowResultPanel(propertyName,valueCode);

            //label变红时
            set_LabelRedAndValue(propertyModels);
            //获得附件列表
           if(dataGridView_PropertyValue.Rows[e.RowIndex].Cells["PropertyValueType"].Value.ToString().Equals("附件")){
              new RequiredControllerParts(1,propertyName,valueCode).Show();
           }
           else if (dataGridView_PropertyValue.Rows[e.RowIndex].Cells["PropertyValueType"].Value.ToString().Equals("价格计算"))
           {
               new QuotedPriceSpecialInformation().Show();
           }
           else if (dataGridView_PropertyValue.Rows[e.RowIndex].Cells["PropertyValueType"].Value.ToString().Equals("价格关联"))
           {
               int propertyId = PropertyBLL.GetPtyIdByPtyName(propertyName);
               int valueCodeId = Convert.ToInt32(strValueID);
               PropertyBLL.SetRelativePrice(1, propertyId, valueCodeId);
           }
           else if (dataGridView_PropertyValue.Rows[e.RowIndex].Cells["PropertyValueType"].Value.ToString().Equals("特殊价格授权"))
           {
               QuotedPriceSpecialInformation qpsi = new QuotedPriceSpecialInformation();
               int propertyId = PropertyBLL.GetPtyIdByPtyName(propertyName);
               qpsi.setPrice(propertyId, Convert.ToInt32(strValueID));
               qpsi.Show();
           }

        }

        //label响应事件BEGIN
        private void unit_Size_Click(object sender, EventArgs e)
        {
            label_Changed(unit_Size.Name);
            if (c.Rows.Count >= 1)
            label_DataBing(unit_Size);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(unit_Size.Text);
        }
        private void unit_Size_MouseHover(object sender, EventArgs e)
        {
            unit_Size.Cursor = Cursors.IBeam;
     
        }


        private void voltage_Click(object sender, EventArgs e)
        {
            label_Changed(voltage.Name);
            if(c.Rows.Count>=1)
            label_DataBing(voltage);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(voltage.Text);
        }
        private void voltage_MouseHover(object sender, EventArgs e)
        {
            voltage.Cursor = Cursors.IBeam;
        }


        private void internal_Protection_Click(object sender, EventArgs e)
        {
            label_Changed(internal_Protection.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(internal_Protection);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(internal_Protection.Text);
        }
        private void internal_Protection_MouseHover(object sender, EventArgs e)
        {
            internal_Protection.Cursor = Cursors.IBeam;
        }


        private void cooling_Style_Click(object sender, EventArgs e)
        {
            label_Changed(cooling_Style.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(cooling_Style);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(cooling_Style.Text);
        }
        private void cooling_Style_MouseHover(object sender, EventArgs e)
        {
            cooling_Style.Cursor = Cursors.IBeam;
        }


        private void cooling_Configuration_Click(object sender, EventArgs e)
        {
            label_Changed(cooling_Configuration.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(cooling_Configuration);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(cooling_Configuration.Text);
        }
        private void cooling_Configuration_MouseHover(object sender, EventArgs e)
        {
            cooling_Configuration.Cursor = Cursors.IBeam;
        }

        private void coil_anticorrosion_Click(object sender, EventArgs e)
        {
            label_Changed(coil_anticorrosion.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(coil_anticorrosion);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(coil_anticorrosion.Text);
        }

        private void coil_anticorrosion_MouseHover(object sender, EventArgs e)
        {
            coil_anticorrosion.Cursor = Cursors.IBeam;
        }

        private void heatPumpSeries_Click(object sender, EventArgs e)
        {
            label_Changed(heatPumpSeries.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(heatPumpSeries);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(heatPumpSeries.Text);
        }

        private void heatPumpSeries_MouseHover(object sender, EventArgs e)
        {
            heatPumpSeries.Cursor = Cursors.IBeam;
        }

        private void heatingMethod_Click(object sender, EventArgs e)
        {
            label_Changed(heatingMethod.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(heatingMethod);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(heatingMethod.Text);
        }

        private void heatingMethod_MouseHover(object sender, EventArgs e)
        {
            heatingMethod.Cursor = Cursors.IBeam;
        }

        private void heatingCombination_Click(object sender, EventArgs e)
        {
            label_Changed(heatingCombination.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(heatingCombination);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(heatingCombination.Text);
        }

        private void heatingCombination_MouseHover(object sender, EventArgs e)
        {
            heatingCombination.Cursor = Cursors.IBeam;
        }

        private void heatingSeries_Click(object sender, EventArgs e)
        {
            label_Changed(heatingSeries.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(heatingSeries);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(heatingSeries.Text);
        }

        private void heatingSeries_MouseHover(object sender, EventArgs e)
        {
            heatingSeries.Cursor = Cursors.IBeam;
        }


        //特征
        private void newReturnWind_Click(object sender, EventArgs e)
        {
            label_Changed(newReturnWind.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(newReturnWind);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(newReturnWind.Text);
        }
        //特征
        private void newReturnWind_MouseHover(object sender, EventArgs e)
        {
            newReturnWind.Cursor = Cursors.IBeam;
        }

        private void returnWindMachine_Click(object sender, EventArgs e)
        {
            label_Changed(returnWindMachine.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(returnWindMachine);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(returnWindMachine.Text);
        }
        private void returnWindMachine_MouseHover(object sender, EventArgs e)
        {
            returnWindMachine.Cursor = Cursors.IBeam;
        }

        private void returnWindMachineLeaf_Click(object sender, EventArgs e)
        {
            label_Changed(returnWindMachineLeaf.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(returnWindMachineLeaf);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(returnWindMachineLeaf.Text);
        }

        private void returnWindMachineLeaf_MouseHover(object sender, EventArgs e)
        {
            returnWindMachineLeaf.Cursor = Cursors.IBeam;
        }

        private void returnWindMachineElectronic_Click(object sender, EventArgs e)
        {
            label_Changed(returnWindMachineElectronic.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(returnWindMachineElectronic);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(returnWindMachineElectronic.Text);
        }

        private void returnWindMachineElectronic_MouseHover(object sender, EventArgs e)
        {
            returnWindMachineElectronic.Cursor = Cursors.IBeam;
        }

        private void newWindControlOption_Click(object sender, EventArgs e)
        {
            label_Changed(newWindControlOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(newWindControlOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(newWindControlOption.Text);
        }

        private void newWindControlOption_MouseHover(object sender, EventArgs e)
        {
            newWindControlOption.Cursor = Cursors.IBeam;
        }

        private void heatingOption_Click(object sender, EventArgs e)
        {
            label_Changed(heatingOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(heatingOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(heatingOption.Text);
        }

        private void heatingOption_MouseHover(object sender, EventArgs e)
        {
            heatingOption.Cursor = Cursors.IBeam;
        }

        private void maintenanceOption_Click(object sender, EventArgs e)
        {
            label_Changed(maintenanceOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(maintenanceOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(maintenanceOption.Text);
        }

        private void maintenanceOption_MouseHover(object sender, EventArgs e)
        {
            maintenanceOption.Cursor = Cursors.IBeam;
        }

        private void blowerCombinationOptions_Click(object sender, EventArgs e)
        {
            label_Changed(blowerCombinationOptions.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(blowerCombinationOptions);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(blowerCombinationOptions.Text);
        }

        private void blowerCombinationOptions_MouseHover(object sender, EventArgs e)
        {
            blowerCombinationOptions.Cursor = Cursors.IBeam;
        }

        private void blowerImpellerOption_Click(object sender, EventArgs e)
        {
            label_Changed(blowerImpellerOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(blowerImpellerOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(blowerImpellerOption.Text);
        }

        private void blowerImpellerOption_MouseHover(object sender, EventArgs e)
        {
            blowerImpellerOption.Cursor = Cursors.IBeam;
        }

        private void blowerMotorOption_Click(object sender, EventArgs e)
        {
            label_Changed(blowerMotorOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(blowerMotorOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(blowerMotorOption.Text);
        }

        private void blowerMotorOptionn_MouseHover(object sender, EventArgs e)
        {
            blowerMotorOption.Cursor = Cursors.IBeam;
        }

        private void earlyFilterOption_Click(object sender, EventArgs e)
        {
            label_Changed(earlyFilterOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(earlyFilterOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(earlyFilterOption.Text);
        }

        private void earlyFilterOption_MouseHover(object sender, EventArgs e)
        {
            earlyFilterOption.Cursor = Cursors.IBeam;
        }

        private void unitFilterOption_Click(object sender, EventArgs e)
        {
            label_Changed(unitFilterOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(unitFilterOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(unitFilterOption.Text);
        }

        private void unitFilterOption_MouseHover(object sender, EventArgs e)
        {
            unitFilterOption.Cursor = Cursors.IBeam;
        }

        private void filtersAccessoriesOption_Click(object sender, EventArgs e)
        {
            label_Changed(filtersAccessoriesOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(filtersAccessoriesOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(filtersAccessoriesOption.Text);
        }

        private void filtersAccessoriesOption_MouseHover(object sender, EventArgs e)
        {
            filtersAccessoriesOption.Cursor = Cursors.IBeam;
        }

        private void coolingSystemProtectionOption_Click(object sender, EventArgs e)
        {
            label_Changed(coolingSystemProtectionOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(coolingSystemProtectionOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(coolingSystemProtectionOption.Text);
        }

        private void coolingSystemProtectionOption_MouseHover(object sender, EventArgs e)
        {
            coolingSystemProtectionOption.Cursor = Cursors.IBeam;
        }

        private void coolingSystemOption_Click(object sender, EventArgs e)
        {
            label_Changed(coolingSystemOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(coolingSystemOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(coolingSystemOption.Text);
        }

        private void coolingSystemOption_MouseHover(object sender, EventArgs e)
        {
            coolingSystemOption.Cursor = Cursors.IBeam;
        }

        private void coolingAccessoriesOption_Click(object sender, EventArgs e)
        {
            label_Changed(coolingAccessoriesOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(coolingAccessoriesOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(coolingAccessoriesOption.Text);
        }

        private void coolingAccessoriesOption_MouseHover(object sender, EventArgs e)
        {
            coolingAccessoriesOption.Cursor = Cursors.IBeam;
        }

        private void airSwitchOption_Click(object sender, EventArgs e)
        {
            label_Changed(airSwitchOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(airSwitchOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(airSwitchOption.Text);
        }

        private void airSwitchOption_MouseHover(object sender, EventArgs e)
        {
            airSwitchOption.Cursor = Cursors.IBeam;
        }

        private void securityOption_Click(object sender, EventArgs e)
        {
            label_Changed(securityOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(securityOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(securityOption.Text);
        }

        private void securityOption_MouseHover(object sender, EventArgs e)
        {
            securityOption.Cursor = Cursors.IBeam;
        }

        private void unitControlOption_Click(object sender, EventArgs e)
        {
            label_Changed(unitControlOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(unitControlOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(unitControlOption.Text);
        }

        private void unitControlOption_MouseHover(object sender, EventArgs e)
        {
            unitControlOption.Cursor = Cursors.IBeam;
        }

        private void specialControlOption_Click(object sender, EventArgs e)
        {
            label_Changed(specialControlOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(specialControlOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(specialControlOption.Text);
        }

        private void specialControlOption_MouseHover(object sender, EventArgs e)
        {
            specialControlOption.Cursor = Cursors.IBeam;
        }

        private void newWindPreheatingOption_Click(object sender, EventArgs e)
        {

            label_Changed(newWindPreheatingOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(newWindPreheatingOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(newWindPreheatingOption.Text);
        }

        private void newWindPreheatingOption_MouseHover(object sender, EventArgs e)
        {
            newWindPreheatingOption.Cursor = Cursors.IBeam;
        }

        private void preheatAmountOption_Click(object sender, EventArgs e)
        {
            label_Changed(preheatAmountOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(preheatAmountOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(preheatAmountOption.Text);
        }

        private void preheatAmountOption_MouseHover(object sender, EventArgs e)
        {
            preheatAmountOption.Cursor = Cursors.IBeam;
        }

        private void humidificationOption_Click(object sender, EventArgs e)
        {
            label_Changed(humidificationOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(humidificationOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(humidificationOption.Text);
        }

        private void humidificationOption_MouseHover(object sender, EventArgs e)
        {
            humidificationOption.Cursor = Cursors.IBeam;
        }

        private void humidificationAmountOption_Click(object sender, EventArgs e)
        {
            label_Changed(humidificationAmountOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(humidificationAmountOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(humidificationAmountOption.Text);
        }

        private void humidificationAmountOption_MouseHover(object sender, EventArgs e)
        {
            humidificationAmountOption.Cursor = Cursors.IBeam;
        }

        private void humidificationControlOption_Click(object sender, EventArgs e)
        {
            label_Changed(humidificationControlOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(humidificationControlOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(humidificationControlOption.Text);
        }

        private void humidificationControlOption_MouseHover(object sender, EventArgs e)
        {
            humidificationControlOption.Cursor = Cursors.IBeam;
        }

        private void boxOption_Click(object sender, EventArgs e)
        {
            label_Changed(boxOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(boxOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(boxOption.Text);
        }

        private void boxOption_MouseHover(object sender, EventArgs e)
        {
            boxOption.Cursor = Cursors.IBeam;
        }

        private void authenticationOption_Click(object sender, EventArgs e)
        {
            label_Changed(authenticationOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(authenticationOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(authenticationOption.Text);
        }

        private void authenticationOption_MouseHover(object sender, EventArgs e)
        {
            authenticationOption.Cursor = Cursors.IBeam;
        }

        private void packagingOption_Click(object sender, EventArgs e)
        {
            label_Changed(packagingOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(packagingOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(packagingOption.Text);
        }

        private void packagingOption_MouseHover(object sender, EventArgs e)
        {
            packagingOption.Cursor = Cursors.IBeam;
        }

        private void waterCooledCondenserOption_Click(object sender, EventArgs e)
        {
            label_Changed(waterCooledCondenserOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(waterCooledCondenserOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(waterCooledCondenserOption.Text);
        }

        private void waterCooledCondenserOption_MouseHover(object sender, EventArgs e)
        {
            waterCooledCondenserOption.Cursor = Cursors.IBeam;
        }

        private void controllerBrandingOption_Click(object sender, EventArgs e)
        {
            label_Changed(controllerBrandingOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(controllerBrandingOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(controllerBrandingOption.Text);
        }

        private void controllerBrandingOption_MouseHover(object sender, EventArgs e)
        {
            controllerBrandingOption.Cursor = Cursors.IBeam;
        }

        private void otherOption_Click(object sender, EventArgs e)
        {
            label_Changed(otherOption.Name);
            if (c.Rows.Count >= 1)
                label_DataBing(otherOption);
            cellStyleChanged(dataGridView_PropertyValue);
            setDefaultSelectedValueBySelectLabel(otherOption.Text);
        }

        private void otherOption_MouseHover(object sender, EventArgs e)
        {
            otherOption.Cursor = Cursors.IBeam;
        }

        //label响应事件END


        /* 颜色设置事件BEGIN
         * 
         *
         * */
        //当前label颜色控制（根据label的属性，应用于label_click类型事件）
        private void label_Changed(string label_Name)
        {
            if (label_Name == "unit_Size")
            {
                unit_Size.BackColor = Color.Yellow;
                clear_current_label(unit_Size);
            }
            else if (label_Name == "voltage")
            {
                voltage.BackColor = Color.Yellow;
                clear_current_label(voltage);
            }
            else if (label_Name == "internal_Protection")
            {

                internal_Protection.BackColor = Color.Yellow;
                clear_current_label(internal_Protection);
            }
            else if (label_Name == "cooling_Style")
            {
                cooling_Style.BackColor = Color.Yellow;
                clear_current_label(cooling_Style);
            }
            else if (label_Name == "cooling_Configuration")
            {
                cooling_Configuration.BackColor = Color.Yellow;
                clear_current_label(cooling_Configuration);
            }
            else if (label_Name == "coil_anticorrosion")
            {
                coil_anticorrosion.BackColor = Color.Yellow;
                clear_current_label(coil_anticorrosion);
            }
            else if (label_Name == "heatPumpSeries")
            {
                heatPumpSeries.BackColor = Color.Yellow;
                clear_current_label(heatPumpSeries);
            }
            else if (label_Name == "heatingSeries")
            {
                heatingSeries.BackColor = Color.Yellow;
                clear_current_label(heatingSeries);
            }
            else if (label_Name == "heatingMethod")
            {
                heatingMethod.BackColor = Color.Yellow;
                clear_current_label(heatingMethod);
            }
            else if (label_Name == "heatingCombination")
            {
                heatingCombination.BackColor = Color.Yellow;
                clear_current_label(heatingCombination);
            }
                //特征
            else if (label_Name == "newReturnWind")
            {
                newReturnWind.BackColor = Color.Yellow;
                clear_current_label(newReturnWind);
            }
            else if (label_Name == "returnWindMachine")
            {
                returnWindMachine.BackColor = Color.Yellow;
                clear_current_label(returnWindMachine);
            }
            else if (label_Name == "returnWindMachineLeaf")
            {
                returnWindMachineLeaf.BackColor = Color.Yellow;
                clear_current_label(returnWindMachineLeaf);
            }
            else if (label_Name == "returnWindMachineElectronic")
            {
                returnWindMachineElectronic.BackColor = Color.Yellow;
                clear_current_label(returnWindMachineElectronic);
            }
            else if (label_Name == "newWindControlOption")
            {
                newWindControlOption.BackColor = Color.Yellow;
                clear_current_label(newWindControlOption);
            }
            else if (label_Name == "heatingOption")
            {
                heatingOption.BackColor = Color.Yellow;
                clear_current_label(heatingOption);
            }
            else if (label_Name == "maintenanceOption")
            {
                maintenanceOption.BackColor = Color.Yellow;
                clear_current_label(maintenanceOption);
            }
            else if (label_Name == "blowerCombinationOptions")
            {
                blowerCombinationOptions.BackColor = Color.Yellow;
                clear_current_label(blowerCombinationOptions);
            }
            else if (label_Name == "blowerImpellerOption")
            {
                blowerImpellerOption.BackColor = Color.Yellow;
                clear_current_label(blowerImpellerOption);
            }
            else if (label_Name == "blowerMotorOption")
            {
                blowerMotorOption.BackColor = Color.Yellow;
                clear_current_label(blowerMotorOption);
            }
            else if (label_Name == "earlyFilterOption")
            {
                earlyFilterOption.BackColor = Color.Yellow;
                clear_current_label(earlyFilterOption);
            }
            else if (label_Name == "unitFilterOption")
            {
                unitFilterOption.BackColor = Color.Yellow;
                clear_current_label(unitFilterOption);
            }
            else if (label_Name == "filtersAccessoriesOption")
            {
                filtersAccessoriesOption.BackColor = Color.Yellow;
                clear_current_label(filtersAccessoriesOption);
            }
            else if (label_Name == "coolingSystemProtectionOption")
            {
                filtersAccessoriesOption.BackColor = Color.Yellow;
                clear_current_label(coolingSystemProtectionOption);
            }
            else if (label_Name == "coolingSystemOption")
            {
                coolingSystemOption.BackColor = Color.Yellow;
                clear_current_label(coolingSystemOption);
            }
            else if (label_Name == "coolingAccessoriesOption")
            {
                coolingAccessoriesOption.BackColor = Color.Yellow;
                clear_current_label(coolingAccessoriesOption);
            }
            else if (label_Name == "airSwitchOption")
            {
                airSwitchOption.BackColor = Color.Yellow;
                clear_current_label(airSwitchOption);
            }
            else if (label_Name == "securityOption")
            {
                securityOption.BackColor = Color.Yellow;
                clear_current_label(securityOption);
            }
            else if (label_Name == "unitControlOption")
            {
                unitControlOption.BackColor = Color.Yellow;
                clear_current_label(unitControlOption);
            }
            else if (label_Name == "specialControlOption")
            {
                specialControlOption.BackColor = Color.Yellow;
                clear_current_label(specialControlOption);
            }
            else if (label_Name == "newWindPreheatingOption")
            {
                newWindPreheatingOption.BackColor = Color.Yellow;
                clear_current_label(newWindPreheatingOption);
            }
            else if (label_Name == "preheatAmountOption")
            {
                preheatAmountOption.BackColor = Color.Yellow;
                clear_current_label(preheatAmountOption);
            }
            else if (label_Name == "humidificationOption")
            {
                humidificationOption.BackColor = Color.Yellow;
                clear_current_label(humidificationOption);
            }
            else if (label_Name == "humidificationAmountOption")
            {
                humidificationAmountOption.BackColor = Color.Yellow;
                clear_current_label(humidificationAmountOption);
            }
            else if (label_Name == "humidificationControlOption")
            {
                humidificationControlOption.BackColor = Color.Yellow;
                clear_current_label(humidificationControlOption);
            }
            else if (label_Name == "boxOption")
            {
                boxOption.BackColor = Color.Yellow;
                clear_current_label(boxOption);
            }
            else if (label_Name == "authenticationOption")
            {
                authenticationOption.BackColor = Color.Yellow;
                clear_current_label(authenticationOption);
            }
            else if (label_Name == "packagingOption")
            {
                packagingOption.BackColor = Color.Yellow;
                clear_current_label(packagingOption);
            }
            else if (label_Name == "waterCooledCondenserOption")
            {
                waterCooledCondenserOption.BackColor = Color.Yellow;
                clear_current_label(waterCooledCondenserOption);
            }
            else if (label_Name == "controllerBrandingOption")
            {
                controllerBrandingOption.BackColor = Color.Yellow;
                clear_current_label(controllerBrandingOption);
            }
            else if (label_Name == "otherOption")
            {
                otherOption.BackColor = Color.Yellow;
                clear_current_label(otherOption);
            }
        }
        //根据属性名称修改label颜色（应用于datagridview事件）
        private void label_ChangedByPropertyName(string strName)
        {
            if (strName == PropertyNameConfig.UNITSIZE)
            {
                unit_Size.BackColor = Color.Yellow;
                clear_current_label(unit_Size);
            }
            else if (strName == PropertyNameConfig.VOLTAGE)
            {
                voltage.BackColor = Color.Yellow;
                clear_current_label(voltage);
            }
            else if (strName == PropertyNameConfig.INTERNALPROTECTION)
            {
                internal_Protection.BackColor = Color.Yellow;
                clear_current_label(internal_Protection);
            }
            else if (strName == PropertyNameConfig.COOLINGSTYLE)
            {
                cooling_Style.BackColor = Color.Yellow;
                clear_current_label(cooling_Style);
            }
            else if (strName == PropertyNameConfig.COOLINGCONFIGURATION)
            {
                cooling_Configuration.BackColor = Color.Yellow;
                clear_current_label(cooling_Configuration);
            }
            else if (strName == PropertyNameConfig.COILANTICORROSION)
            {
                coil_anticorrosion.BackColor = Color.Yellow;
                clear_current_label(coil_anticorrosion);
            }
            else if (strName == PropertyNameConfig.HEATPUMPSERIES)
            {
                heatPumpSeries.BackColor = Color.Yellow;
                clear_current_label(heatPumpSeries);
            }
            else if (strName == PropertyNameConfig.HEATINGMETHOD)
            {
                heatingMethod.BackColor = Color.Yellow;
                clear_current_label(heatingMethod);
            }
            else if (strName == PropertyNameConfig.HEATINGSERIES)
            {
                heatingSeries.BackColor = Color.Yellow;
                clear_current_label(heatingSeries);
            }
            else if (strName == PropertyNameConfig.HEATINGCOMBINATION)
            {
                heatingCombination.BackColor = Color.Yellow;
                clear_current_label(heatingCombination);
            }
                //特征
            else if (strName == PropertyNameConfig.NEWRETRUNWIND)
            {
                newReturnWind.BackColor = Color.Yellow;
                clear_current_label(newReturnWind);
            }
            else if (strName == PropertyNameConfig.RETURNWINDMACHINE)
            {
                returnWindMachine.BackColor = Color.Yellow;
                clear_current_label(returnWindMachine);
            }
            else if (strName == PropertyNameConfig.RETURNWINDMACHINELEAF)
            {
                returnWindMachineLeaf.BackColor = Color.Yellow;
                clear_current_label(returnWindMachineLeaf);
            }
            else if (strName == PropertyNameConfig.RETURNWINDMACHINEELECTRONIC)
            {
                returnWindMachineElectronic.BackColor = Color.Yellow;
                clear_current_label(returnWindMachineElectronic);
            }
            else if (strName == PropertyNameConfig.NEWWINDCONTROLOPTION)
            {
                newWindControlOption.BackColor = Color.Yellow;
                clear_current_label(newWindControlOption);
            }
            else if (strName == PropertyNameConfig.HEATINGOPTION)
            {
                heatingOption.BackColor = Color.Yellow;
                clear_current_label(heatingOption);
            }
            else if (strName == PropertyNameConfig.MAINTENANCEOPTION)
            {
                maintenanceOption.BackColor = Color.Yellow;
                clear_current_label(maintenanceOption);
            }
            else if (strName == PropertyNameConfig.BLOWERCOMBINATIONOPTIONS)
            {
                blowerCombinationOptions.BackColor = Color.Yellow;
                clear_current_label(blowerCombinationOptions);
            }
            else if (strName == PropertyNameConfig.BLOWERIMPELLEROPTION)
            {
                blowerImpellerOption.BackColor = Color.Yellow;
                clear_current_label(blowerImpellerOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                blowerMotorOption.BackColor = Color.Yellow;
                clear_current_label(blowerMotorOption);
            }
            /***********************************/
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                earlyFilterOption.BackColor = Color.Yellow;
                clear_current_label(earlyFilterOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                unitFilterOption.BackColor = Color.Yellow;
                clear_current_label(unitFilterOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                filtersAccessoriesOption.BackColor = Color.Yellow;
                clear_current_label(filtersAccessoriesOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                coolingSystemProtectionOption.BackColor = Color.Yellow;
                clear_current_label(coolingSystemProtectionOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                coolingSystemOption.BackColor = Color.Yellow;
                clear_current_label(coolingSystemOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                coolingAccessoriesOption.BackColor = Color.Yellow;
                clear_current_label(coolingAccessoriesOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                airSwitchOption.BackColor = Color.Yellow;
                clear_current_label(airSwitchOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                securityOption.BackColor = Color.Yellow;
                clear_current_label(securityOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                unitControlOption.BackColor = Color.Yellow;
                clear_current_label(unitControlOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                specialControlOption.BackColor = Color.Yellow;
                clear_current_label(specialControlOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                newWindPreheatingOption.BackColor = Color.Yellow;
                clear_current_label(newWindPreheatingOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                humidificationOption.BackColor = Color.Yellow;
                clear_current_label(humidificationOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                preheatAmountOption.BackColor = Color.Yellow;
                clear_current_label(preheatAmountOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                humidificationAmountOption.BackColor = Color.Yellow;
                clear_current_label(humidificationAmountOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                humidificationControlOption.BackColor = Color.Yellow;
                clear_current_label(humidificationControlOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                boxOption.BackColor = Color.Yellow;
                clear_current_label(boxOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                authenticationOption.BackColor = Color.Yellow;
                clear_current_label(authenticationOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                packagingOption.BackColor = Color.Yellow;
                clear_current_label(packagingOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                waterCooledCondenserOption.BackColor = Color.Yellow;
                clear_current_label(waterCooledCondenserOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                controllerBrandingOption.BackColor = Color.Yellow;
                clear_current_label(controllerBrandingOption);
            }
            else if (strName == PropertyNameConfig.BLOWERMOTOROPTION)
            {
                otherOption.BackColor = Color.Yellow;
                clear_current_label(otherOption);
            }
        }

        //清除label颜色
        private void clear_current_label(Label label)
        {
            //模型
            string str = label.Name;
            if (!str.Equals("unit_Size"))
            {
                unit_Size.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("voltage"))
            {
                voltage.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("internal_Protection"))
            {

                internal_Protection.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("cooling_Style"))
            {
                cooling_Style.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("cooling_Configuration"))
            {
                cooling_Configuration.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("coil_anticorrosion"))
            {
                coil_anticorrosion.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("heatPumpSeries"))
            {
                heatPumpSeries.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("heatingMethod"))
            {
                heatingMethod.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("heatingSeries"))
            {
                heatingSeries.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("heatingCombination"))
            {
                heatingCombination.BackColor = showResultPanel.BackColor;
            }
            //特征
            if (!str.Equals("newReturnWind"))
            {
                newReturnWind.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("returnWindMachine"))
            {
                returnWindMachine.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("returnWindMachineLeaf"))
            {
                returnWindMachineLeaf.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("returnWindMachineElectronic"))
            {
                returnWindMachineElectronic.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("newWindControlOption"))
            {
                newWindControlOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("heatingOption"))
            {
                heatingOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("maintenanceOption"))
            {
                maintenanceOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("blowerCombinationOptions"))
            {
                blowerCombinationOptions.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("blowerImpellerOption"))
            {
                blowerImpellerOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("blowerMotorOption"))
            {
                blowerMotorOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("earlyFilterOption"))
            {
                earlyFilterOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("unitFilterOption"))
            {
                unitFilterOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("filtersAccessoriesOption"))
            {
                filtersAccessoriesOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("coolingSystemProtectionOption"))
            {
                coolingSystemProtectionOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("coolingSystemOption"))
            {
                coolingSystemOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("coolingAccessoriesOption"))
            {
                coolingAccessoriesOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("airSwitchOption"))
            {
                airSwitchOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("securityOption"))
            {
                securityOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("unitControlOption"))
            {
                unitControlOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("specialControlOption"))
            {
                specialControlOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("newWindPreheatingOption"))
            {
                newWindPreheatingOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("preheatAmountOption"))
            {
                preheatAmountOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("humidificationOption"))
            {
                humidificationOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("humidificationAmountOption"))
            {
                humidificationAmountOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("humidificationControlOption"))
            {
                humidificationControlOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("boxOption"))
            {
                boxOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("authenticationOption"))
            {
                authenticationOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("packagingOption"))
            {
                packagingOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("waterCooledCondenserOption"))
            {
                waterCooledCondenserOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("controllerBrandingOption"))
            {
                controllerBrandingOption.BackColor = showResultPanel.BackColor;
            }
            if (!str.Equals("otherOption"))
            {
                otherOption.BackColor = showResultPanel.BackColor;
            }

            
        }
        //设置面板那些label变红
        private void set_LabelRedAndValue(List<PropertyModelLogic> redPropertyList )
        {
            for (int i = 0; i < redPropertyList.Count;i++ )
            {
                PropertyModelLogic pm = (PropertyModelLogic)redPropertyList.ElementAt(i);
                //模型
                if (pm.PropertyName == PropertyNameConfig.UNITSIZE)
                {
                    set_LabelRed(unit_Size);
                    set_LabelRedValue(pm, unit_Size);
                }
                else if (pm.PropertyName == PropertyNameConfig.VOLTAGE)
                {
                    set_LabelRed(voltage);
                    set_LabelRedValue(pm, voltage);
                }
                else if (pm.PropertyName == PropertyNameConfig.INTERNALPROTECTION)
                {
                    set_LabelRed(internal_Protection);
                    set_LabelRedValue(pm, internal_Protection);
                }
                else if (pm.PropertyName == PropertyNameConfig.COOLINGSTYLE)
                {
                    set_LabelRed(cooling_Style);
                    set_LabelRedValue(pm, cooling_Style);
                }
                else if (pm.PropertyName == PropertyNameConfig.COOLINGCONFIGURATION)
                {
                    set_LabelRed(cooling_Configuration);
                    set_LabelRedValue(pm, cooling_Configuration);
                }
                else if (pm.PropertyName == PropertyNameConfig.COILANTICORROSION)
                {
                    set_LabelRed(coil_anticorrosion);
                    set_LabelRedValue(pm, coil_anticorrosion);
                }
                else if (pm.PropertyName == PropertyNameConfig.HEATPUMPSERIES)
                {
                    set_LabelRed(heatPumpSeries);
                    set_LabelRedValue(pm, heatPumpSeries);
                }
                else if (pm.PropertyName == PropertyNameConfig.HEATINGMETHOD)
                {
                    set_LabelRed(heatingMethod);
                    set_LabelRedValue(pm, heatingMethod);
                }
                else if (pm.PropertyName == PropertyNameConfig.HEATINGSERIES)
                {
                    set_LabelRed(heatingSeries);
                    set_LabelRedValue(pm, heatingSeries);
                }
                else if (pm.PropertyName == PropertyNameConfig.HEATINGCOMBINATION)
                {
                    set_LabelRed(heatingCombination);
                    set_LabelRedValue(pm, heatingCombination);
                }
                    //特征
                else if (pm.PropertyName == PropertyNameConfig.NEWRETRUNWIND)
                {

                    set_LabelRed(newReturnWind);
                    set_LabelRedValue(pm, newReturnWind);
                }
                else if (pm.PropertyName == PropertyNameConfig.RETURNWINDMACHINE)
                {

                    set_LabelRed(returnWindMachine);
                    set_LabelRedValue(pm, returnWindMachine);
                }
                else if (pm.PropertyName == PropertyNameConfig.RETURNWINDMACHINELEAF)
                {

                    set_LabelRed(returnWindMachineLeaf);
                    set_LabelRedValue(pm, returnWindMachineLeaf);
                }
                else if (pm.PropertyName == PropertyNameConfig.RETURNWINDMACHINEELECTRONIC)
                {

                    set_LabelRed(returnWindMachineElectronic);
                    set_LabelRedValue(pm, returnWindMachineElectronic);
                }
                else if (pm.PropertyName == PropertyNameConfig.NEWWINDCONTROLOPTION)
                {

                    set_LabelRed(newWindControlOption);
                    set_LabelRedValue(pm, newWindControlOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.HEATINGOPTION)
                {

                    set_LabelRed(heatingOption);
                    set_LabelRedValue(pm, heatingOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.MAINTENANCEOPTION)
                {

                    set_LabelRed(maintenanceOption);
                    set_LabelRedValue(pm, maintenanceOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.BLOWERCOMBINATIONOPTIONS)
                {

                    set_LabelRed(blowerCombinationOptions);
                    set_LabelRedValue(pm, blowerCombinationOptions);
                }
                else if (pm.PropertyName == PropertyNameConfig.BLOWERIMPELLEROPTION)
                {

                    set_LabelRed(blowerImpellerOption);
                    set_LabelRedValue(pm, blowerImpellerOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.BLOWERMOTOROPTION)
                {

                    set_LabelRed(blowerMotorOption);
                    set_LabelRedValue(pm, blowerMotorOption);
                }
                /*****************************/
                else if (pm.PropertyName == PropertyNameConfig.EARLYFILTEROPTION)
                {

                    set_LabelRed(earlyFilterOption);
                    set_LabelRedValue(pm, earlyFilterOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.UNITFILTEROPTION)
                {

                    set_LabelRed(unitFilterOption);
                    set_LabelRedValue(pm, unitFilterOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.FILTERSACCESSORIESOPTION)
                {

                    set_LabelRed(filtersAccessoriesOption);
                    set_LabelRedValue(pm, filtersAccessoriesOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.COOLINGSYSTEMPROTECTIONOPTION)
                {

                    set_LabelRed(coolingSystemProtectionOption);
                    set_LabelRedValue(pm, coolingSystemProtectionOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.COOLINGSYSTEMOPTION)
                {

                    set_LabelRed(coolingSystemOption);
                    set_LabelRedValue(pm, coolingSystemOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.COOLINGACCESSORIESOPTION)
                {

                    set_LabelRed(coolingAccessoriesOption);
                    set_LabelRedValue(pm, coolingAccessoriesOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.AIRSWITCHOPTION)
                {

                    set_LabelRed(airSwitchOption);
                    set_LabelRedValue(pm, airSwitchOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.SECURITYOPTION)
                {

                    set_LabelRed(securityOption);
                    set_LabelRedValue(pm, securityOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.UNITCONTROLOPTION)
                {

                    set_LabelRed(unitControlOption);
                    set_LabelRedValue(pm, unitControlOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.SPECIALCONTROLOPTION)
                {

                    set_LabelRed(specialControlOption);
                    set_LabelRedValue(pm, specialControlOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.NEWWINDPREHEATINGOPTION)
                {

                    set_LabelRed(newWindPreheatingOption);
                    set_LabelRedValue(pm, newWindPreheatingOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.PREHEATAMOUNTOPTION)
                {

                    set_LabelRed(preheatAmountOption);
                    set_LabelRedValue(pm, preheatAmountOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.HUMIDIFICATIONOPTION)
                {

                    set_LabelRed(humidificationOption);
                    set_LabelRedValue(pm, humidificationOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.HUMIDIFICATIONAMOUNTOPTION)
                {

                    set_LabelRed(humidificationAmountOption);
                    set_LabelRedValue(pm, humidificationAmountOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.HUMIDIFICATIONCONTROLOPTION)
                {

                    set_LabelRed(humidificationControlOption);
                    set_LabelRedValue(pm, humidificationControlOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.BOXOPTION)
                {

                    set_LabelRed(boxOption);
                    set_LabelRedValue(pm, boxOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.AUTHENTICATIONOPTION)
                {

                    set_LabelRed(authenticationOption);
                    set_LabelRedValue(pm, authenticationOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.PACKAGEINGOPTION)
                {

                    set_LabelRed(packagingOption);
                    set_LabelRedValue(pm, packagingOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.WATERCOOLERCONDENSEROPTION)
                {

                    set_LabelRed(waterCooledCondenserOption);
                    set_LabelRedValue(pm, waterCooledCondenserOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.CONTROLLERBRANDINGOPTION)
                {

                    set_LabelRed(controllerBrandingOption);
                    set_LabelRedValue(pm, controllerBrandingOption);
                }
                else if (pm.PropertyName == PropertyNameConfig.OTHEROPTION)
                {

                    set_LabelRed(otherOption);
                    set_LabelRedValue(pm, otherOption);
                }
            }
        }
        //标签label变红
        private void set_LabelRed(Label label)
        {
            label.BackColor = Color.Red;
        }
        //标签label变红后值也变化
        private void set_LabelRedValue(PropertyModelLogic pm,Label label){
            if (null != pm.ValueCode)
                label.Text = pm.ValueCode;
            else
                remindMessage(pm.PropertyName);
        }
      
         /* 
         * 颜色设置事件END
         * 
         * 
         * */

        //设置面板值
        private void set_ShowResultPanel(string strName,string valueCode)
        {
            //模型
            if (strName.Equals(PropertyNameConfig.UNITSIZE))
            {
                unit_Size.Text = valueCode;
                unit_Size.BackColor = Color.Yellow;
                clear_current_label(unit_Size);
            }
            if (strName.Equals(PropertyNameConfig.VOLTAGE))
            {
                voltage.Text = valueCode;
                voltage.BackColor = Color.Yellow;
                clear_current_label(voltage);
            }
            if (strName.Equals(PropertyNameConfig.INTERNALPROTECTION))
            {
                internal_Protection.Text = valueCode;
                internal_Protection.BackColor = Color.Yellow;
                clear_current_label(internal_Protection);
            }
            if (strName.Equals(PropertyNameConfig.COOLINGSTYLE))
            {
                cooling_Style.Text = valueCode;
                cooling_Style.BackColor = Color.Yellow;
                clear_current_label(cooling_Style);
            }
            if (strName.Equals(PropertyNameConfig.COOLINGCONFIGURATION))
            {
                cooling_Configuration.Text = valueCode;
                cooling_Configuration.BackColor = Color.Yellow;
                clear_current_label(cooling_Configuration);
            }
            if (strName.Equals(PropertyNameConfig.COILANTICORROSION))
            {
                coil_anticorrosion.Text = valueCode;
                coil_anticorrosion.BackColor = Color.Yellow;
                clear_current_label(coil_anticorrosion);
            }
            if (strName.Equals(PropertyNameConfig.HEATPUMPSERIES))
            {
                heatPumpSeries.Text = valueCode;
                heatPumpSeries.BackColor = Color.Yellow;
                clear_current_label(heatPumpSeries);
            }
            if (strName.Equals(PropertyNameConfig.HEATINGMETHOD))
            {
                heatingMethod.Text = valueCode;
                heatingMethod.BackColor = Color.Yellow;
                clear_current_label(heatingMethod);
            }
            if (strName.Equals(PropertyNameConfig.HEATINGCOMBINATION))
            {
                heatingCombination.Text = valueCode;
                heatingCombination.BackColor = Color.Yellow;
                clear_current_label(heatingCombination);
            }
            if (strName.Equals(PropertyNameConfig.HEATINGSERIES))
            {
                heatingSeries.Text = valueCode;
                heatingSeries.BackColor = Color.Yellow;
                clear_current_label(heatingSeries);
            }
            //特征
            if (strName.Equals(PropertyNameConfig.NEWRETRUNWIND))
            {
                newReturnWind.Text = valueCode;
                newReturnWind.BackColor = Color.Yellow;
                clear_current_label(newReturnWind);
            }
            if (strName.Equals(PropertyNameConfig.RETURNWINDMACHINE))
            {
                returnWindMachine.Text = valueCode;
                returnWindMachine.BackColor = Color.Yellow;
                clear_current_label(returnWindMachine);
            }
            if (strName.Equals(PropertyNameConfig.RETURNWINDMACHINELEAF))
            {
                returnWindMachineLeaf.Text = valueCode;
                returnWindMachineLeaf.BackColor = Color.Yellow;
                clear_current_label(returnWindMachineLeaf);
            }
            if (strName.Equals(PropertyNameConfig.RETURNWINDMACHINEELECTRONIC))
            {
                returnWindMachineElectronic.Text = valueCode;
                returnWindMachineElectronic.BackColor = Color.Yellow;
                clear_current_label(returnWindMachineElectronic);
            }
            if (strName.Equals(PropertyNameConfig.NEWWINDCONTROLOPTION))
            {
                newWindControlOption.Text = valueCode;
                newWindControlOption.BackColor = Color.Yellow;
                clear_current_label(newWindControlOption);
            }
            if (strName.Equals(PropertyNameConfig.HEATINGOPTION))
            {
                heatingOption.Text = valueCode;
                heatingOption.BackColor = Color.Yellow;
                clear_current_label(heatingOption);
            }
            if (strName.Equals(PropertyNameConfig.MAINTENANCEOPTION))
            {
                maintenanceOption.Text = valueCode;
                maintenanceOption.BackColor = Color.Yellow;
                clear_current_label(maintenanceOption);
            }
            if (strName.Equals(PropertyNameConfig.BLOWERCOMBINATIONOPTIONS))
            {
                blowerCombinationOptions.Text = valueCode;
                blowerCombinationOptions.BackColor = Color.Yellow;
                clear_current_label(blowerCombinationOptions);
            }
            if (strName.Equals(PropertyNameConfig.BLOWERIMPELLEROPTION))
            {
                blowerImpellerOption.Text = valueCode;
                blowerImpellerOption.BackColor = Color.Yellow;
                clear_current_label(blowerImpellerOption);
            }
            if (strName.Equals(PropertyNameConfig.BLOWERMOTOROPTION))
            {
                blowerMotorOption.Text = valueCode;
                blowerMotorOption.BackColor = Color.Yellow;
                clear_current_label(blowerMotorOption);
            }    
            /*******************************************/
            if (strName.Equals(PropertyNameConfig.EARLYFILTEROPTION))
            {
                earlyFilterOption.Text = valueCode;
                earlyFilterOption.BackColor = Color.Yellow;
                clear_current_label(earlyFilterOption);
            }
            if (strName.Equals(PropertyNameConfig.UNITFILTEROPTION))
            {
                
                unitFilterOption.Text = valueCode;
                unitFilterOption.BackColor = Color.Yellow;
                clear_current_label(unitFilterOption);
            }
            if (strName.Equals(PropertyNameConfig.FILTERSACCESSORIESOPTION))
            {
                filtersAccessoriesOption.Text = valueCode;
                filtersAccessoriesOption.BackColor = Color.Yellow;
                clear_current_label(filtersAccessoriesOption);
            }
            if (strName.Equals(PropertyNameConfig.COOLINGSYSTEMPROTECTIONOPTION))
            {
                coolingSystemProtectionOption.Text = valueCode;
                coolingSystemProtectionOption.BackColor = Color.Yellow;
                clear_current_label(coolingSystemProtectionOption);
            }
            if (strName.Equals(PropertyNameConfig.COOLINGSYSTEMOPTION))
            {
                coolingSystemOption.Text = valueCode;
                coolingSystemOption.BackColor = Color.Yellow;
                clear_current_label(coolingSystemOption);
            }
            if (strName.Equals(PropertyNameConfig.COOLINGACCESSORIESOPTION))
            {
                coolingAccessoriesOption.Text = valueCode;
                coolingAccessoriesOption.BackColor = Color.Yellow;
                clear_current_label(coolingAccessoriesOption);
            }
            if (strName.Equals(PropertyNameConfig.AIRSWITCHOPTION))
            {
                airSwitchOption.Text = valueCode;
                airSwitchOption.BackColor = Color.Yellow;
                clear_current_label(airSwitchOption);
            }
            if (strName.Equals(PropertyNameConfig.SECURITYOPTION))
            {
                securityOption.Text = valueCode;
                securityOption.BackColor = Color.Yellow;
                clear_current_label(securityOption);

            }
            if (strName.Equals(PropertyNameConfig.UNITCONTROLOPTION))
            {
                unitControlOption.Text = valueCode;
                unitControlOption.BackColor = Color.Yellow;
                clear_current_label(unitControlOption);
            }
            if (strName.Equals(PropertyNameConfig.SPECIALCONTROLOPTION))
            {
                specialControlOption.Text = valueCode;
                specialControlOption.BackColor = Color.Yellow;
                clear_current_label(specialControlOption);
            }
            if (strName.Equals(PropertyNameConfig.NEWWINDPREHEATINGOPTION))
            {
                newWindPreheatingOption.Text = valueCode;
                newWindPreheatingOption.BackColor = Color.Yellow;
                clear_current_label(newWindPreheatingOption);
            }
            if (strName.Equals(PropertyNameConfig.PREHEATAMOUNTOPTION))
            {
                preheatAmountOption.Text = valueCode;
                preheatAmountOption.BackColor = Color.Yellow;
                clear_current_label(preheatAmountOption);
            }
            if (strName.Equals(PropertyNameConfig.HUMIDIFICATIONOPTION))
            {
                humidificationOption.Text = valueCode;
                humidificationOption.BackColor = Color.Yellow;
                clear_current_label(humidificationOption);
            }
            if (strName.Equals(PropertyNameConfig.HUMIDIFICATIONAMOUNTOPTION))
            {
                humidificationAmountOption.Text = valueCode;
                humidificationAmountOption.BackColor = Color.Yellow;
                clear_current_label(humidificationAmountOption);
            }
            if (strName.Equals(PropertyNameConfig.HUMIDIFICATIONCONTROLOPTION))
            {
                humidificationControlOption.Text = valueCode;
                humidificationControlOption.BackColor = Color.Yellow;
                clear_current_label(humidificationControlOption);
            }
            if (strName.Equals(PropertyNameConfig.BOXOPTION))
            {
                boxOption.Text = valueCode;
                boxOption.BackColor = Color.Yellow;
                clear_current_label(boxOption);
            }
            if (strName.Equals(PropertyNameConfig.AUTHENTICATIONOPTION))
            {
                authenticationOption.Text = valueCode;
                authenticationOption.BackColor = Color.Yellow;
                clear_current_label(authenticationOption);
            }
            if (strName.Equals(PropertyNameConfig.PACKAGEINGOPTION))
            {
                packagingOption.Text = valueCode;
                packagingOption.BackColor = Color.Yellow;
                clear_current_label(packagingOption);
            }
            if (strName.Equals(PropertyNameConfig.WATERCOOLERCONDENSEROPTION))
            {
                waterCooledCondenserOption.Text = valueCode;
                waterCooledCondenserOption.BackColor = Color.Yellow;
                clear_current_label(waterCooledCondenserOption);
            }
            if (strName.Equals(PropertyNameConfig.CONTROLLERBRANDINGOPTION))
            {
                controllerBrandingOption.Text = valueCode;
                controllerBrandingOption.BackColor = Color.Yellow;
                clear_current_label(controllerBrandingOption);
            }
            if (strName.Equals(PropertyNameConfig.OTHEROPTION))
            {
                otherOption.Text = valueCode;
                otherOption.BackColor = Color.Yellow;
                clear_current_label(otherOption);
            }
        }

        //根据点击面板上label标签，来绑定数据源
        private void label_DataBing(Label label)
        {
            string strName=label.Name;
            if (c.Rows.Count >= 1 && c.Rows[0].Cells["PropertyName"].Value != null)
            {
                if (strName.Equals("unit_Size"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.UNITSIZE, 1);
                }
                else if (strName.Equals("voltage"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.VOLTAGE, 1);
                }
                else if (strName.Equals("internal_Protection"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.INTERNALPROTECTION, 1);
                }
                else if (strName.Equals("cooling_Style"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.COOLINGSTYLE, 1);
                }
                else if (strName.Equals("cooling_Configuration"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.COOLINGCONFIGURATION, 1);
                }
                else if (strName.Equals("coil_anticorrosion"))
                {
                    
                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.COILANTICORROSION, 1);
                }
                else if (strName.Equals("heatPumpSeries"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.HEATPUMPSERIES, 1);
                }
                else if (strName.Equals("heatingMethod"))
                {
                    
                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.HEATPUMPSERIES, 1);
                }
                else if (strName.Equals("heatingCombination"))
                {
                    
                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.HEATINGCOMBINATION, 1);
                }
                else if (strName.Equals("heatingSeries"))
                {
                    
                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.HEATINGSERIES, 1);
                }

                    //特征
                else if (strName.Equals("newReturnWind"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.NEWRETRUNWIND, 1);
                }
                else if (strName.Equals("returnWindMachine"))
                {
                    
                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.RETURNWINDMACHINE, 1);
                }
                else if (strName.Equals(" returnWindMachineLeaf"))
                {
                   
                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.RETURNWINDMACHINELEAF, 1);
                }
                else if (strName.Equals(" returnWindMachineElectronic"))
                {
                    
                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.RETURNWINDMACHINEELECTRONIC, 1);
                }
                else if (strName.Equals(" newWindControlOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.NEWWINDCONTROLOPTION, 1);
                }
                else if (strName.Equals(" heatingOption"))
                {
                    
                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.HEATINGOPTION, 1);
                }
                else if (strName.Equals(" maintenanceOption"))
                {
                    
                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.MAINTENANCEOPTION, 1);
                }
                else if (strName.Equals(" blowerCombinationOptions"))
                {
                    
                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.BLOWERCOMBINATIONOPTIONS, 1);
                }
                else if (strName.Equals(" blowerImpellerOption"))
                {
                    
                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.BLOWERIMPELLEROPTION, 1);
                }
                else if (strName.Equals(" blowerMotorOption"))
                {
                    
                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.BLOWERMOTOROPTION, 1);
                }

                /**************************************************************/
                else if (strName.Equals(" earlyFilterOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.EARLYFILTEROPTION, 1);
                }
                else if (strName.Equals(" unitFilterOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.UNITFILTEROPTION, 1);
                }
                else if (strName.Equals(" filtersAccessoriesOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.FILTERSACCESSORIESOPTION, 1);
                }
                else if (strName.Equals(" coolingSystemProtectionOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.COOLINGSYSTEMPROTECTIONOPTION, 1);
                }
                else if (strName.Equals(" coolingSystemOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.COOLINGSYSTEMOPTION, 1);
                }
                else if (strName.Equals(" airSwitchOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.AIRSWITCHOPTION, 1);
                }
                else if (strName.Equals(" securityOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.SECURITYOPTION, 1);
                }
                else if (strName.Equals(" unitControlOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.UNITCONTROLOPTION, 1);
                }
                else if (strName.Equals(" specialControlOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.SPECIALCONTROLOPTION, 1);
                }
                else if (strName.Equals(" newWindPreheatingOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.NEWWINDPREHEATINGOPTION, 1);
                }
                else if (strName.Equals(" preheatAmountOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.PREHEATAMOUNTOPTION, 1);
                }
                else if (strName.Equals(" humidificationOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.HUMIDIFICATIONOPTION, 1);
                }
                else if (strName.Equals(" humidificationAmountOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.HUMIDIFICATIONAMOUNTOPTION, 1);
                }
                else if (strName.Equals(" humidificationControlOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.HUMIDIFICATIONCONTROLOPTION, 1);
                }
                else if (strName.Equals(" boxOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.BOXOPTION, 1);
                }
                else if (strName.Equals(" authenticationOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.AUTHENTICATIONOPTION, 1);
                }
                else if (strName.Equals(" packagingOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.PACKAGEINGOPTION, 1);
                }
                else if (strName.Equals(" waterCooledCondenserOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.WATERCOOLERCONDENSEROPTION, 1);
                }
                else if (strName.Equals(" controllerBrandingOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.CONTROLLERBRANDINGOPTION, 1);
                }
                else if (strName.Equals(" otherOption"))
                {

                    dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, PropertyNameConfig.OTHEROPTION, 1);
                }

            }
            cellStyleChanged(dataGridView_PropertyValue);
        }

        //设置默认选中的值
        private void setDefaultSelectedValue(string strTempPropertyName)
        {
            int strTemp = PropertyBLL.GetCurrentSelectedPtyValue(1,strTempPropertyName,1);
            int count=dataGridView_PropertyValue.Rows.Count;
            int tempValueID;
            for (int i = 0; i < count; i++)
            {
                
                tempValueID =Convert.ToInt32(dataGridView_PropertyValue.Rows[i].Cells["ValueCodeID"].Value.ToString());
                if (strTemp.Equals(tempValueID))
               {
                  string tempValue = dataGridView_PropertyValue.Rows[i].Cells["ValueCode"].Value.ToString();
                   dataGridView_PropertyValue.Rows[i].Selected = true;
                   set_ShowResultPanel(strTempPropertyName,tempValue);
               }
               else
               {
                   dataGridView_PropertyValue.Rows[i].Selected = false;
               }
            }
        }
        //通过label设置默认值
        private void setDefaultSelectedValueBySelectLabel(string strTempValueCode)
        {
            int count = dataGridView_PropertyValue.Rows.Count;
            string tempValue = null;
            for (int i = 0; i < count; i++)
            {
                tempValue = (string)dataGridView_PropertyValue.Rows[i].Cells["ValueCode"].Value;
                if (strTempValueCode.Equals(tempValue))
                {
                    dataGridView_PropertyValue.Rows[i].Selected = true;
                }
                else
                {
                    dataGridView_PropertyValue.Rows[i].Selected = false;
                }
            }
        }

        //画datagridview的conlum的格式
        private void cellStyleChanged(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count != 0)
            {
                for (int i = 0; i < dataGridView.Rows.Count; )
                {
                    dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                    i += 2;
                }
            }
        }

        //信息提示框
        private void remindMessage(string strTemp)
        {
            MessageBox.Show(strTemp+"属性已经为空,请重新选择");
        }

        private void condition_Click(object sender, EventArgs e)
        {
            new UnitConditions().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {


                c.AutoGenerateColumns = false;
                c.DataSource = PropertyBLL.GetPropertiesByDeviceId(1, 1);
                c.Columns[0].DataPropertyName = "CatalogName";
                c.Columns[1].DataPropertyName = "PropertyName";
                if (c.Rows.Count > 0)
                {
                    String strPropertyName = (String)c.Rows[0].Cells["PropertyName"].Value;
                    propertyName = strPropertyName;
                }
                cellStyleChanged(this.c);


                dataGridView_PropertyValue.AutoGenerateColumns = false;
                //dataGridView_PropertyValue.DataSource = PropertyBLL.GetPtyValuesByDeviceandPtyId(1, 4);
                dataGridView_PropertyValue.DataSource = PropertyBLL.GetCurrentPtyValues(1, propertyName, 1);

                dataGridView_PropertyValue.Columns[0].DataPropertyName = "ValueCode";
                dataGridView_PropertyValue.Columns[1].DataPropertyName = "ValueDescription";
                dataGridView_PropertyValue.Columns[2].DataPropertyName = "Price";
                dataGridView_PropertyValue.Columns[3].DataPropertyName = "PropertyValueType";//其实没隐藏
                dataGridView_PropertyValue.Columns[4].DataPropertyName = "ValueCodeID";
                dataGridView_PropertyValue.CurrentCell = dataGridView_PropertyValue.Rows[0].Cells["ValueCodeID"];
                //dataGridView_PropertyValue.Columns[3].Visible = false;


                cellStyleChanged(this.dataGridView_PropertyValue);
                //设置默认值
                setDefaultSelectedValue(propertyName);

            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex.Message);
            }
        } 
     
    }

}
