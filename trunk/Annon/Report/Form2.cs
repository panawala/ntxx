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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
            var resultSet2 =FacilityBLL.getOrderDetail(2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Annon.Report.Report2.rdlc";
            var ordersInfo = FacilityBLL.getFirstOrderInfo(2);
            try
            {
                ReportParameter rp = new ReportParameter("Latitute", ordersInfo.SiteAltitude.ToString()+"m");
                ReportParameter rpTag = new ReportParameter("CustomerName", string.IsNullOrEmpty(ordersInfo.CustCont) ? "无" : ordersInfo.CustCont);
                ReportParameter rpProjectName = new ReportParameter("ProjectName", ordersInfo.JobName);
                ReportParameter rpProjectNo = new ReportParameter("ProjectNo", ordersInfo.JobNo);
                ReportParameter rpSeller = new ReportParameter("AnnonContact", ordersInfo.AAonCont);
                ReportParameter rpOrderDate = new ReportParameter("DealDate", ordersInfo.DealDate == null ? "无" : ordersInfo.DealDate);
                ReportParameter rpJobDes = new ReportParameter("JobDescription", ordersInfo.JobDescription);
                ReportParameter rpCustomerNote = new ReportParameter("CustomerNote", ordersInfo.CustNotes );
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp, rpTag, rpProjectName, rpProjectNo, rpSeller, rpOrderDate,rpJobDes,rpCustomerNote });
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet2));
                this.reportViewer1.RefreshReport();
                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            }
            catch (Exception ee)
            {
 
            }
            
 
        }
    }
}
