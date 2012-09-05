using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Annon.Report
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<facility> FacilityList = new List<facility> { 
            new facility(){
            Type="A",
            Option="dd",
            Code="6ERM",
            Desc="123"
            },
            new facility(){
            Type="A",
            Option="dd",
            Code="6ERM",
            Desc="123"
            },   
            new facility(){
            Type="A",
            Option="dd",
            Code="6ERM",
            Desc="123"
            },  
            new facility(){
            Type="A",
            Option="dd",
            Code="6ERM",
            Desc="123"
            }
            };
            var resultSet2 = FacilityList;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Annon.Report.Report4.rdlc";
            //ReportParameter rp = new ReportParameter("content", this.textBox1.Text);
            //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet2));
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
 
        }
    }
}
