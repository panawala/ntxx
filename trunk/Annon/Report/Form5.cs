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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

            
            //var resultSet = orderList;
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "Annon.Report.Report5.rdlc";
            //reportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(LocalReport_SubreportProcessing);   
            ////ReportParameter rp = new ReportParameter("content", this.textBox1.Text);
            ////this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
            //this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet));
            //reportViewer1.Dock = DockStyle.Fill;
            //this.Controls.Add(reportViewer1);
            //this.reportViewer1.RefreshReport();

           
        }
        private void LocalReport_SubreportProcessing(object sender, Microsoft.Reporting.WinForms.SubreportProcessingEventArgs e)
        {
            
            //e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet2));
        }   
  

    }
}
