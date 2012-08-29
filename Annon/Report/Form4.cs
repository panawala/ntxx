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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            List<Facility2> orderList = new List<Facility2> { 
            new Facility2(){
           Type="A",
           Option="aad",
           Code="dfd",
           Describe="df",
           StandPrice=12,
           AgentPrice=21,
           ClientPrice=232
            },
            new Facility2(){
           Type="A",
           Option="aad",
           Code="dfd",
           Describe="df",
           StandPrice=12,
           AgentPrice=21,
           ClientPrice=232
            },
            new Facility2(){
           Type="A",
           Option="aad",
           Code="dfd",
           Describe="df",
           StandPrice=12,
           AgentPrice=21,
           ClientPrice=232
            }
           };

            var resultSet = orderList;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Annon.Report.Report4.rdlc";
            //ReportParameter rp = new ReportParameter("content", this.textBox1.Text);
            //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet));
            this.reportViewer1.RefreshReport();
           

        
        }
    }
}
