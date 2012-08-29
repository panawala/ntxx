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

            List<Command> orderList = new List<Command> { 
            new Command(){
          Count=1,
        Describe="123",
        Price=123,
        SumPrice=456,
        Describe2="333"
         
            },   
            new Command(){
          Count=1,
        Describe="123",
        Price=123,
        SumPrice=456,
         Describe2="333"
            },
               new Command(){
          Count=1,
        Describe="123",
        Price=123,
        SumPrice=456,
         Describe2="333"
            }
           
           };

            var resultSet = orderList;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Annon.Report.Report5.rdlc";
            //ReportParameter rp = new ReportParameter("content", this.textBox1.Text);
            //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet));
            this.reportViewer1.RefreshReport();
           
        }
    }
}
