using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using EntityFrameworkTryBLL;

namespace Annon.Xuanxing
{
    public partial class AttributeInput : Form
    {
        private int propertyId=-1;
        private string strPropertyName=null;
        public AttributeInput()
        {
            InitializeComponent();
            dataGridView1Binding();
            dataGridVeiw3Binding();
        }

        private void excelPumpData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if(""==openFileDialog.FileName){
                return;
            }
            string fileExt = System.IO.Path.GetExtension(openFileDialog.FileName);
            //if (".xls" != fileExt || ".xlsx" != fileExt)
            //{
            //    MessageBox.Show("你输入的不是xls文件!");
            //    return;
            //}
            
            string filePath = openFileDialog.FileName;
            DataTable dt = new DataTable();
            dt = CallExcel(filePath);
            if (saveExcelToDataBase(dt))
            {
                MessageBox.Show("数据导入成功!");
            }
        }

        public Boolean saveExcelToDataBase(DataTable dt)
        {
            try
            {
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{

                //  // PropertyBLL.InsertIntoProperty(dt.Rows[i]["PropertyName"].ToString(), 0, dt.Rows[i]["PropertyDefaultValue"].ToString(), dt.Rows[i]["PropertyType"].ToString());
                //    //PropertyBLL.InsertIntoPropertyValue(dt.Rows[i]["PropertyName"].ToString(), dt.Rows[i]["ValueCode"].ToString(), Convert.ToInt32(dt.Rows[i]["Price"].ToString()), dt.Rows[i]["ValueDescription"].ToString(), 1, dt.Rows[i]["PropertyValueType"].ToString());
                //    PropertyBLL.InsertIntoPropertyValue(Convert.ToInt32(dt.Rows[i]["PropertyID"].ToString()), Convert.ToInt32(dt.Rows[i]["ValueCodeID"].ToString()), dt.Rows[i]["ValueCode"].ToString(), Convert.ToInt32(dt.Rows[i]["Price"].ToString()), dt.Rows[i]["ValueDescription"].ToString(), 1, dt.Rows[i]["PropertyValueType"].ToString());
                //}
                PropertyBLL.DeleteAllPropertyValues();
                PropertyBLL.InsertIntoPropertyValueFromExcel(dt);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex.Message);
                return false;
            }
        }

        protected DataTable CallExcel(string filepath)
        {
            try
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0");
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1';");
                con.Open();
                string sql = "select * from [propertyValue$]";//选择第一个数据SHEET
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();
                con.Dispose();
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            return null;
        }

        private void addDefaultItems()
        {
            
        }

        private void dataGridView1Binding()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = PropertyBLL.GetPropertiesByDeviceId(1);

            dataGridView1.Columns[0].DataPropertyName = "PropertyName";
            dataGridView1.Columns[1].DataPropertyName = "PropertyType";
            dataGridView1.Columns[2].DataPropertyName = "PropertyID";
        } 
        
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string str_valuecode = dataGridView2.Rows[e.RowIndex].Cells["ValueCode"].Value.ToString();
            string str_description = dataGridView2.Rows[e.RowIndex].Cells["Description"].Value.ToString();
            string str_valuetype = dataGridView2.Rows[e.RowIndex].Cells["ValueType"].Value.ToString();
            decimal str_price = Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells["Price"].Value.ToString());
          

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            propertyId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["PropertyId"].Value.ToString());
            strPropertyName = (String)dataGridView1.Rows[e.RowIndex].Cells["PropertyName"].Value;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = PropertyBLL.GetPtyValuesByDeviceandPtyId(1, propertyId);
            dataGridView2.Columns[0].DataPropertyName = "ValueCode";
            dataGridView2.Columns[1].DataPropertyName = "ValueDescription";
            dataGridView2.Columns[2].DataPropertyName = "PropertyValueType";
            dataGridView2.Columns[3].DataPropertyName = "Price";
            dataGridView2.Columns[4].DataPropertyName = "ValueCodeID";
            string selectedValueCode = string.Empty;//PropertyBLL.GetPtyDefaultValueByPropertyName(strPropertyName);
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                if ((string)dataGridView2.Rows[i].Cells["ValueCode"].Value == selectedValueCode)
                {
                    dataGridView2.Rows[i].Selected = true;
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strDeleteValueCode = (string)dataGridView2.SelectedRows[0].Cells["ValueCode"].Value;
            if (null != strDeleteValueCode && strDeleteValueCode != "")
            {
                //if (propertyId!=-1&&PropertyBLL.DeleteFromPropertyValue(propertyId, strDeleteValueCode, 1) > 0)
                {
                    if (strPropertyName != null)
                    {
                        dataGridView2.DataSource = PropertyBLL.GetPtyValuesByDeviceandPtyId(1,propertyId);
                        dataGridView2.AutoGenerateColumns = false;
                        dataGridView2.Columns[0].DataPropertyName = "ValueCode";
                        dataGridView2.Columns[1].DataPropertyName = "ValueDescription";
                        dataGridView2.Columns[3].DataPropertyName = "PropertyValueType";
                    } 
                }
            }
        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dataGridView2_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add("","","","");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btn_AddAttribute.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
        }

        private void btn_AddAttribute_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                if (propertyId != -1)
                {
                    PropertyBLL.InsertIntoPropertyValue(propertyId, textBox1.Text, Convert.ToDecimal(textBox4.Text.Trim()), textBox2.Text, 1, textBox3.Text);
                    dataGridView2.DataSource = PropertyBLL.GetPtyValuesByDeviceandPtyId(1, propertyId);
                    dataGridView2.AutoGenerateColumns = false;
                    dataGridView2.Columns[0].DataPropertyName = "ValueCode";
                    dataGridView2.Columns[1].DataPropertyName = "ValueDescription";
                    dataGridView2.Columns[3].DataPropertyName = "PropertyValueType";
                }
                else
                {
                    MessageBox.Show("请选择属性名称！");
                }                    
            }
            else
            {
                MessageBox.Show("添加的属性值不能为空！");
            }
        }

        private void dataGridVeiw3Binding()
        {
            dataGridView3.AutoGenerateColumns = false;
            //dataGridView3.DataSource = PropertyBLL.GetPropertyConstraintsByDeviceId(1);
            dataGridView3.Columns[0].DataPropertyName = "PropertyName";
            dataGridView3.Columns[1].DataPropertyName = "PropertyValueRange";
            dataGridView3.Columns[2].DataPropertyName = "InfluencedPtyName";
            dataGridView3.Columns[3].DataPropertyName = "InfluencedPtyValueRange";
            dataGridView3.Columns[4].DataPropertyName = "ConstraintRules";
            dataGridView3.Columns[5].DataPropertyName = "InfluencedPtyDefaultValue";
            dataGridView3.Columns[6].DataPropertyName = "PropertyConstraintID";
            
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            if(textBox5.Text!=""&&textBox6.Text!=""&&textBox7.Text!=""&&textBox8.Text!=""&&textBox9.Text!=""&&textBox10.Text!="")
            {
                //PropertyBLL.InsertIntoPropertyConstraint(textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, 1);
                dataGridVeiw3Binding();
            }
            else
            {
                MessageBox.Show("设置的值不能为空!");
            }
        }

        private void dataGridView3_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string str_PropertyConstraintsID = dataGridView3.Rows[e.RowIndex].Cells["PropertyConstraintsID"].Value.ToString();
            string str_PropertyName = dataGridView3.Rows[e.RowIndex].Cells["pName"].Value.ToString();
            string str_PropertyValueRange = dataGridView3.Rows[e.RowIndex].Cells["PropertyValueRange"].Value.ToString();
            string str_InfluencedPtyName = dataGridView3.Rows[e.RowIndex].Cells["InfluencedPtyName"].Value.ToString();
            string str_InfluencedPtyValueRange = dataGridView3.Rows[e.RowIndex].Cells["InfluencedPtyValueRange"].Value.ToString();
            string str_ConstraintRules = dataGridView3.Rows[e.RowIndex].Cells["ConstraintRules"].Value.ToString();
            string str_InfluencedPtyDefaultValue = dataGridView3.Rows[e.RowIndex].Cells["InfluencedPtyDefaultValue"].Value.ToString();
            //PropertyBLL.UpdatePropertyConstraint(Convert.ToInt32(str_PropertyConstraintsID), str_PropertyName, str_PropertyValueRange, str_InfluencedPtyName, str_InfluencedPtyValueRange, str_ConstraintRules, str_InfluencedPtyDefaultValue,1);
            dataGridVeiw3Binding();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string str_PropertyConstraintsID = dataGridView3.SelectedRows[0].Cells["PropertyConstraintsID"].Value.ToString();
                PropertyBLL.DeletePropertyConstraint(Convert.ToInt32(str_PropertyConstraintsID));
                dataGridVeiw3Binding();
            }
            catch (Exception ex)
            {
                MessageBox.Show("请正确操作！");
            }
            
        }

        private void button_PropertyConstraint_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if ("" == openFileDialog.FileName)
            {
                return;
            }
            string fileExt = System.IO.Path.GetExtension(openFileDialog.FileName);
            //if (".xls" != fileExt || ".xlsx" != fileExt)
            //{
            //    MessageBox.Show("你输入的不是xls文件!");
            //    return;
            //}

            string filePath = openFileDialog.FileName;
            DataTable dt = new DataTable();
            dt = CallExcel_PropertyConstraint(filePath);
            if (saveExcelToDataBasePropertyConstraint(dt))
            {
                MessageBox.Show("数据导入成功!");
            }
        }

        private DataTable CallExcel_PropertyConstraint(string filepath)
        {
            try
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1';");
                con.Open();
                string sql = "select * from [propertyConstraint$]";//选择第一个数据SHEET
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();
                con.Dispose();
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            return null;
        }

        private Boolean saveExcelToDataBasePropertyConstraint(DataTable dt)
        {
            try
            {
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{

                //    // PropertyBLL.InsertIntoProperty(dt.Rows[i]["PropertyName"].ToString(), 0, dt.Rows[i]["PropertyDefaultValue"].ToString(), dt.Rows[i]["PropertyType"].ToString());
                //    //PropertyBLL.InsertIntoPropertyValue(dt.Rows[i]["PropertyName"].ToString(), dt.Rows[i]["ValueCode"].ToString(), Convert.ToInt32(dt.Rows[i]["Price"].ToString()), dt.Rows[i]["ValueDescription"].ToString(), 1, dt.Rows[i]["PropertyValueType"].ToString());
                //    //PropertyBLL.InsertIntoPropertyValue(Convert.ToInt32(dt.Rows[i]["PropertyID"].ToString()), Convert.ToInt32(dt.Rows[i]["ValueCodeID"].ToString()), dt.Rows[i]["ValueCode"].ToString(), Convert.ToInt32(dt.Rows[i]["Price"].ToString()), dt.Rows[i]["ValueDescription"].ToString(), 1, dt.Rows[i]["PropertyValueType"].ToString());
                //    PropertyBLL.InsertIntoPropertyConstraint(Convert.ToInt32(dt.Rows[i]["PropertyID"].ToString()), dt.Rows[i]["PropertyValueIdRange"].ToString(), Convert.ToInt32(dt.Rows[i]["InfluencedPtyID"].ToString()), dt.Rows[i]["InfluencedPtyValueIdRange"].ToString(), dt.Rows[i]["ConstraintRules"].ToString(), dt.Rows[i]["InfluencedPtyDefaultValue"].ToString(), Convert.ToInt32(dt.Rows[i]["DeviceID"].ToString()));

                //}
                PropertyBLL.DeleteAll();
                PropertyBLL.InsertIntoPropertyConstraintFromExcel(dt);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                return false;
            }
        }
    }
}
