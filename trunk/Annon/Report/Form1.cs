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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“northwindDataSet.Customers”中。您可以根据需要移动或删除它。
         

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
           
            var resultSet =FacilityBLL.getOrderDetail(2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Annon.Report.Report1.rdlc";

            var ordersInfo = FacilityBLL.getFirstOrderInfo(2);

            ReportParameter rp = new ReportParameter("Latitute", ordersInfo.SiteAltitude.ToString()+"m");
            ReportParameter rpTag = new ReportParameter("CustomerName", ordersInfo.CustCont);
            ReportParameter rpProjectName = new ReportParameter("ProjectName", ordersInfo.JobName);
            ReportParameter rpProjectNo = new ReportParameter("ProjectNo", ordersInfo.JobNo);
            ReportParameter rpSeller = new ReportParameter("AnnonContact", ordersInfo.AAonCont);
            ReportParameter rpOrderDate = new ReportParameter("DealDate", ordersInfo.DealDate);
            ReportParameter rpCustomerNote = new ReportParameter("CustomerNote", ordersInfo.CustNotes);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp, rpTag, rpProjectName, rpProjectNo, rpSeller, rpOrderDate,rpCustomerNote });

            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet));
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;








        }


        }
    }

