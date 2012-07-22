using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WW.Cad.Model;
using WW.Cad.IO;
using System.IO;

namespace Annon.Zutu
{
    public partial class DxfViewer : Form
    {
        public DxfViewer()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string filename = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "AutoCad files (*.dxf, *.dwg)|*.dxf;*.dwg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filename = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message);
                    Environment.Exit(1);
                }
            }
            else
            {
                Environment.Exit(0);
            }


            DxfModel model;
            string extension = Path.GetExtension(filename);
            if (string.Compare(extension, ".dwg", true) == 0)
            {
                model = DwgReader.Read(filename);
            }
            else
            {
                model = DxfReader.Read(filename);
            }


            viewControl1.Model = model;
        }

        public void setDxfFile(string fileName)
        {
            DxfModel model = DxfReader.Read(fileName);
            viewControl1.Model = model;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            viewControl1.PrintDwf();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //string localFilePath, fileNameExt, newFileName, FilePath; 
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型 
            sfd.Filter = "PDF文件（*.pdf）|*.pdf";
            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;
            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                viewControl1.Export(sfd.FileName);
            }
        }
    }
}
