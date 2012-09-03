using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.Report;

namespace Annon.Report
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

            List<Performance> orderList = new List<Performance> { 
              new Performance(){

                  count=1
                }
            };
            var resultSet2 = orderList;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Annon.Report.Report8.rdlc";
            //ReportParameter rp = new ReportParameter("content", this.textBox1.Text);
            //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet2));
            this.reportViewer1.RefreshReport();
        }
    }
}
