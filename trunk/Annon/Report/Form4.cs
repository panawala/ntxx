using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityFrameworkTryBLL.ReportManager;
using Microsoft.Reporting.WinForms;

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


            var resultSet = FacilityBLL.getFacility(1, 1, "model");
            var resultSet1 = FacilityBLL.getFacility(1, 1, "feature");
            var productDescription = FacilityBLL.getDescription(1);
            var ordersInfo = FacilityBLL.getOrderInfo(1);

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Annon.Report.Report4.rdlc";
            ReportParameter rp = new ReportParameter("ProductDescription", "6ERM-"+productDescription);
            ReportParameter rpTag = new ReportParameter("Tag", "6ERM");
            ReportParameter rpProjectName = new ReportParameter("ProjectName", ordersInfo.JobName);
            ReportParameter rpProjectNo = new ReportParameter("ProjectNo", ordersInfo.JobNum);
            ReportParameter rpSeller = new ReportParameter("Seller", "ordersInfo.AAonCon");
            ReportParameter rpOrderDate = new ReportParameter("OrderDate", ordersInfo.Activity);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp,rpTag,rpProjectName,rpProjectNo,rpSeller,rpOrderDate });
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet));
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", resultSet1));
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;



        }


        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
    
}