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
using EntityFrameworkTryBLL.TreeManager;
using System.Data.Entity;
using DataContext;
using EntityFrameworkTryBLL.ZutuManager;
using EntityFrameworkTryBLL.UnitManager;

namespace Annon.Xuanxing
{
    public partial class InputCurrentDataFromExcel : Form
    {
        public InputCurrentDataFromExcel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0");
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1';");
                con.Open();
                string sql = "select * from [currentDevices$]";//选择第一个数据SHEET
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
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CurrentDeviceBLL.InsertIntoCurrentDevice(Convert.ToInt32(dt.Rows[i]["DeviceID"].ToString()), Convert.ToInt32(dt.Rows[i]["PropertyID"].ToString()), dt.Rows[i]["PropertyValueArray"].ToString(), Convert.ToInt32(dt.Rows[i]["OrderDetailID"].ToString()), Convert.ToInt32(dt.Rows[i]["PropertyValueID"].ToString()));
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                return false;
            }
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            //DeviceBLL.DeleteAllCurrentDevices(1,1);
            //DeviceBLL.InitialDevices(1, 1);
            //以上两行可用
            (new ModelAndFeature()).Show();
        }

        private void btnDataImport_Click(object sender, EventArgs e)
        {
            (new AttributeInput()).Show();
        }

        private void btnConstraint_Click(object sender, EventArgs e)
        {
            var entity = TreeEntityBLL.addToParentEntity(new TreeEntity("44"));
            if (entity != null)
                MessageBox.Show("发生冲突在:" + entity.PropertyId);
        }

        private void btnOrderDetail_Click(object sender, EventArgs e)
        {
            (new OrderForm()).Show();
        }

  

        private void btnInitalDB_Click(object sender, EventArgs e)
        {
            Database.SetInitializer<AnnonContext>(new AnnonInitializer());
        }

        private void btnImageImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if ("" == openFileDialog.FileName)
            {
                return;
            }
            string fileExt = System.IO.Path.GetExtension(openFileDialog.FileName);

            string filePath = openFileDialog.FileName;
            DataTable dt = new DataTable();
            dt = CallExcel_ImageBlock(filePath);
            if (saveExcelToDataBaseImageBlock(dt))
            {
                MessageBox.Show("数据导入成功!");
            }
        }



        private DataTable CallExcel_ImageBlock(string filepath)
        {
            try
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1';");
                con.Open();
                string sql = "select * from [ImageBlocks$]";//选择第一个数据SHEET
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

        private Boolean saveExcelToDataBaseImageBlock(DataTable dt)
        {
            try
            {
                ImageBlockBLL.DeleteAll();
                ImageBlockBLL.InsertIntoPropertyFromExcel(dt);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                return false;
            }
        }

        private void btnContentImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if ("" == openFileDialog.FileName)
            {
                return;
            }

            string filePath = openFileDialog.FileName;
            DataTable dt = new DataTable();
            dt = CallExcel_ContentPropertyValue(filePath);
            ContentBLL.DeleteAll();
            if (ContentBLL.InsertFromExcel(dt)>1)
            {
                MessageBox.Show("数据导入成功!");
            }
        }
        private DataTable CallExcel_ContentPropertyValue(string filepath)
        {
            try
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0");
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1';");
                con.Open();
                string sql = "select * from [ContentPropertyValues$]";//选择第一个数据SHEET
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

        private void btnUnit_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if ("" == openFileDialog.FileName)
            {
                return;
            }

            string filePath = openFileDialog.FileName;
            DataTable dt = new DataTable();
            dt = CallExcel_UnitModel(filePath);
            UnitBLL.DeleteAll();
            if (UnitBLL.InsertFromExcel(dt) > 1)
            {
                MessageBox.Show("数据导入成功!");
            }
        }
        private DataTable CallExcel_UnitModel(string filepath)
        {
            try
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0");
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1';");
                con.Open();
                string sql = "select * from [UnitModels$]";//选择第一个数据SHEET
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



    }
}
