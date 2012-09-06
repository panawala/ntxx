using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityFrameworkTryBLL.ReportManager;
using Microsoft.Reporting.WinForms;
using System.Reflection;

namespace Annon.Report
{
    public partial class AllReports : Form
    {
        public AllReports()
        {
            InitializeComponent();

            this.MouseWheel += new MouseEventHandler(reportViewer1_MouseWheel);
        }
        //public void GetVerticalScrollPosition()
        //{
        //    BindingFlags bf = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
        //    FieldInfo fiwinRSviewer = reportViewer1.GetType().GetField("winRSviewer", bf);
        //    object objwinRSviewer = fiwinRSviewer.GetValue(reportViewer1);
        //    FieldInfo fireportPanel = objwinRSviewer.GetType().GetField("m_reportPanel", bf);
        //    object objreportPanel = fireportPanel.GetValue(objwinRSviewer);
        //    Panel panel = (Panel)(objreportPanel);
        //    panel.AutoScroll = true;
        //}
        List<string> SaveReportList =null;
        int i = 0;
        int FrontReportPageCount = 0;
        private void reportViewer1_MouseWheel(object sender, MouseEventArgs e)
        {
            BindingFlags bf = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            FieldInfo fiwinRSviewer = reportViewer1.GetType().GetField("winRSviewer", bf);
            object objwinRSviewer = fiwinRSviewer.GetValue(reportViewer1);
            FieldInfo fireportPanel = objwinRSviewer.GetType().GetField("m_reportPanel", bf);
            object objreportPanel = fireportPanel.GetValue(objwinRSviewer);
            Panel panel = (Panel)(objreportPanel);
            panel.AutoScroll = true;
            //panel.VerticalScroll.LargeChange = reportViewer1.Height;
            //panel.VerticalScroll.SmallChange = 30;
            //panel.VerticalScroll.
            int temp = reportViewer1.Height;
            if (reportViewer1.CurrentPage != reportViewer1.GetTotalPages())
            {
                if (panel.VerticalScroll.Value == 0)
                {
                    if (e.Delta > 0 && i > 0)
                    {
                        i--;                       
                        ShowAllReport(SaveReportList[i]);
                        int len = FrontReportPageCount;
                        //reportViewer1.CurrentPage = 2;
                        //reportViewer1.Refresh();
                    }
                }
            }
            else if(reportViewer1.CurrentPage == reportViewer1.GetTotalPages())
            {
                if (panel.VerticalScroll.Value >= panel.VerticalScroll.Maximum-panel.VerticalScroll.LargeChange-panel.VerticalScroll.SmallChange)
                {
                    if (e.Delta > 0 && i > 0)
                    {
                        i--;
                        ShowAllReport(SaveReportList[i]);
                    }
                    if (e.Delta < 0 && i < SaveReportList.Count - 1 && i >= 0)
                    {
                        i++;
                        ShowAllReport(SaveReportList[i]);
                    }
                }

                else if(panel.VerticalScroll.Value==0)
                {
                    if (e.Delta > 0 && i > 0)
                    {
                        i--;
                        ShowAllReport(SaveReportList[i]);
                    }
                    if (e.Delta < 0 && i < SaveReportList.Count - 1 && i >= 0)
                    {
                        i++;
                        ShowAllReport(SaveReportList[i]);
                    }
                }
            }

 
            

            //if (reportViewer1.CurrentPage != reportViewer1.GetTotalPages())
            //{
            //    if (reportViewer1.VerticalScroll.Value > reportViewer1.VerticalScroll.Maximum)
            //    {
            //        reportViewer1.VerticalScroll.Value = reportViewer1.VerticalScroll.Maximum;
            //        reportViewer1.CurrentPage++;
            //    }
            //    else
            //    {
            //        //this.reportViewer1.VerticalScroll.Value += (reportViewer1.Height / reportViewer1.VerticalScroll.Maximum) / 10;

            //    }

            //}
            //else
            //{
            //    if (reportViewer1.VerticalScroll.Value < reportViewer1.Height && reportViewer1.VerticalScroll.Value<reportViewer1.VerticalScroll.Maximum)
            //    {
            //        if (reportViewer1.Height == 446)
            //        {
            //            this.reportViewer1.VerticalScroll.Value += 7;
            //        }
            //        else
            //        {
            //            this.reportViewer1.VerticalScroll.Value += 5;
            //            //this.reportViewer1.siz
            //        }

            //    }
            //    else
            //    {
            //        if (e.Delta > 0 && i > 0)
            //        {
            //            i--;
            //            ShowAllReport(SaveReportList[i]);
            //        }
            //        if (e.Delta < 0 && i < SaveReportList.Count - 1 && i >= 0)
            //        {
            //            i++;
            //            ShowAllReport(SaveReportList[i]);
            //        }
            //    }
            //}
            FrontReportPageCount = reportViewer1.GetTotalPages();
        }
        public AllReports(List<string> reportList)

        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(reportViewer1_MouseWheel);
            SaveReportList = reportList;
        }
        public void ShowAllReport(string report)
        {
            switch (report)
                {
                    case "Report1.rdlc":
                        {
                            this.reportViewer1.Reset();
                            var resultSet = FacilityBLL.getOrderDetail(2);
                            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Annon.Report.Report1.rdlc";
                            var ordersInfo = FacilityBLL.getOrderInfo(1);
                            ReportParameter rp = new ReportParameter("Latitute", "200m");
                            ReportParameter rpTag = new ReportParameter("CustomerName", "ordersInfo.Customer");
                            ReportParameter rpProjectName = new ReportParameter("ProjectName", ordersInfo.JobName);
                            ReportParameter rpProjectNo = new ReportParameter("ProjectNo", ordersInfo.JobNum);
                            ReportParameter rpSeller = new ReportParameter("AnnonContact", "ordersInfo.AAonCon");
                            ReportParameter rpOrderDate = new ReportParameter("DealDate", ordersInfo.Activity);
                            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp, rpTag, rpProjectName, rpProjectNo, rpSeller, rpOrderDate });
                            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet));
                            this.reportViewer1.RefreshReport();
                            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                            this.reportViewer1.VerticalScroll.Value = 0;
                        }
                        break;

                    case "Report2.rdlc":
                        {
                            this.reportViewer1.Reset();
                            var resultSet2 = FacilityBLL.getOrderDetail(2);
                            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Annon.Report.Report2.rdlc";
                            var ordersInfo = FacilityBLL.getOrderInfo(1);

                            ReportParameter rp = new ReportParameter("Latitute", "200m");
                            ReportParameter rpTag = new ReportParameter("CustomerName", "ordersInfo.Customer");
                            ReportParameter rpProjectName = new ReportParameter("ProjectName", ordersInfo.JobName);
                            ReportParameter rpProjectNo = new ReportParameter("ProjectNo", ordersInfo.JobNum);
                            ReportParameter rpSeller = new ReportParameter("AnnonContact", "ordersInfo.AAonCon");
                            ReportParameter rpOrderDate = new ReportParameter("DealDate", ordersInfo.Activity);
                            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp, rpTag, rpProjectName, rpProjectNo, rpSeller, rpOrderDate });
                            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet2));
                            this.reportViewer1.RefreshReport();
                            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                            this.reportViewer1.VerticalScroll.Value = 0;
                        }
                        break;
                    case "Report3.rdlc":
                            {
                                
                                this.reportViewer1.Reset();
                                
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
                                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp, rpTag, rpProjectName, rpProjectNo, rpOrderDate });
                                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet));
                                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", resultSet1));
                                this.reportViewer1.RefreshReport();
                                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                                this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                                this.reportViewer1.VerticalScroll.Value = 0;
                            }
                            break;
                    case "Report4.rdlc":
                            {
                                this.reportViewer1.Reset();
                                var resultSet = FacilityBLL.getFacility(1, 1, "model");
                                var resultSet1 = FacilityBLL.getFacility(1, 1, "feature");
                                var productDescription = FacilityBLL.getDescription(1);
                                var ordersInfo = FacilityBLL.getOrderInfo(1);

                                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Annon.Report.Report4.rdlc";
                                ReportParameter rp = new ReportParameter("ProductDescription", "6ERM-" + productDescription);
                                ReportParameter rpTag = new ReportParameter("Tag", "6ERM");
                                ReportParameter rpProjectName = new ReportParameter("ProjectName", ordersInfo.JobName);
                                ReportParameter rpProjectNo = new ReportParameter("ProjectNo", ordersInfo.JobNum);
                                ReportParameter rpSeller = new ReportParameter("Seller", "ordersInfo.AAonCon");
                                ReportParameter rpOrderDate = new ReportParameter("OrderDate", ordersInfo.Activity);
                                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp, rpTag, rpProjectName, rpProjectNo, rpSeller, rpOrderDate });
                                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet));
                                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", resultSet1));
                                this.reportViewer1.RefreshReport();
                                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                                this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                                this.reportViewer1.VerticalScroll.Value = 0;
                            }
                            break;
                    case "Report5.rdlc":
                            {
                                this.reportViewer1.Reset();
                                var resultSet = FacilityBLL.getOrderDetail(1);
                                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Annon.Report.Report5.rdlc";
                                reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet));
                                reportViewer1.Dock = DockStyle.Fill;
                                this.Controls.Add(reportViewer1);
                                this.reportViewer1.RefreshReport();
                                this.reportViewer1.VerticalScroll.Value = 0;
                            }
                            break;
            }
        }

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            var orderDetail = FacilityBLL.getOrderDetail(2);
            e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet_OrderDetail", orderDetail));
            var orderInformation = FacilityBLL.getOrderInformation(1);
            e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", orderInformation));
        }
        private void AllReports_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void AllReports_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void reportViewer1_Scroll(object sender, ScrollEventArgs e)
        {
            int newPoint = e.NewValue;
            //int oldPoint = e.OldValue;
            //label1.Text = "oldvalue:" + e.OldValue + ";;newvalue:" + e.NewValue + "..max:" + reportViewer1.VerticalScroll.Maximum;
        }
    }
}
