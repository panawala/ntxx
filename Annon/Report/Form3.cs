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

            var resultSet = FacilityBLL.getFacility(2, 1, "model");
            var resultSet1 = FacilityBLL.getFacility(2, 1, "feature");
            var productDescription = FacilityBLL.getDescription(1);
            var ordersInfo = FacilityBLL.getFirstOrderInfo(1);

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Annon.Report.Report3.rdlc";
            ReportParameter rp = new ReportParameter("ProductDescription", "6ERM-" + productDescription);
            ReportParameter rpTag = new ReportParameter("AnnonContact", ordersInfo.AAonCont);
            ReportParameter rpProjectName = new ReportParameter("ProjectName", ordersInfo.JobName);
            ReportParameter rpProjectNo = new ReportParameter("ProjectNo", ordersInfo.JobNo);
            ReportParameter rpOrderDate = new ReportParameter("OrderDate", ordersInfo.DealDate==null?"无":ordersInfo.DealDate);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] {rp, rpTag, rpProjectName, rpProjectNo, rpOrderDate });
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet));
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", resultSet1));
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
        }
    }
}
