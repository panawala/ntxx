using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using EntityFrameworkTryBLL.ReportManager;


namespace Annon.Report
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            List<Order> orderList = new List<Order> { 
            new Order(){
            OrderId=1,
            OrderCount=2,
            OrderDescription="hello",
            OrderPrice=123,
            OrderTag="tag"
            },
            new Order(){
            OrderId=2,
            OrderCount=2,
            OrderDescription="hello",
            OrderPrice=123,
            OrderTag="tag"
            },
            new Order(){
            OrderId=3,
            OrderCount=2,
            OrderDescription="hello",
            OrderPrice=123,
            OrderTag="tag"
            },
            new Order(){
            OrderId=4,
            OrderCount=2,
            OrderDescription="hello",
            OrderPrice=123,
            OrderTag="tag"
            }
            };
            //ReportParameter rp = new ReportParameter("content", this.textBox1.Text);
            //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
            var resultSet = FacilityBLL.getFacility(1, 1, "model");
            var resultSet1 = FacilityBLL.getFacility(1, 1, "feature");
            var productDescription = FacilityBLL.getDescription(1);
            var ordersInfo = FacilityBLL.getOrderInfo(1);

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Annon.Report.Report3.rdlc";
            ReportParameter rp = new ReportParameter("ProductDescription", "6ERM-" + productDescription);
            ReportParameter rpTag = new ReportParameter("AnnonContact", "Annon.contact");
            ReportParameter rpProjectName = new ReportParameter("ProjectName", ordersInfo.JobName);
            ReportParameter rpProjectNo = new ReportParameter("ProjectNo", ordersInfo.JobNum);
            ReportParameter rpOrderDate = new ReportParameter("OrderDate", ordersInfo.Activity);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] {rp, rpTag, rpProjectName, rpProjectNo, rpOrderDate });
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet));
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", resultSet1));
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
        }
    }
}
