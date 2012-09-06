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
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Annon.Report
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            string deviceInfo = "<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>";
            byte[] bytes = reportViewer1.LocalReport.Render(
            "Pdf", deviceInfo, out mimeType, out encoding, out extension,
            out streamids, out warnings);

            FileStream fs = new FileStream(@"c:\output.pdf", FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
            FileStream fs1 = new FileStream(@"c:\output1.pdf", FileMode.Create);
            fs1.Write(bytes, 0, bytes.Length);
            fs1.Close();

           

            mergePDF();

            MessageBox.Show("Report exported to output.pdf", "Info");
        }
    
        private void mergePDFFiles(string[] fileList, string outMergeFile)
        {
            try
            {
                PdfReader reader;
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outMergeFile, FileMode.Create));
                document.Open();
                PdfContentByte cb = writer.DirectContent;
                PdfImportedPage newPage;
                for (int i = 0; i < fileList.Length; i++)
                {
                    reader = new PdfReader(fileList[i]);
                    int iPageNum = reader.NumberOfPages;
                    for (int j = 1; j <= iPageNum; j++)
                    {
                        document.NewPage();
                        newPage = writer.GetImportedPage(reader, j);
                        cb.AddTemplate(newPage, 0, 0);
                    }
                }
                document.Close();
            }
            catch (Exception e)
            {
 
            }
        }


        public string MergeMultiplePDFsToPDF(string[] fileList, string outMergeFile)
        {
            string returnStr = "";
            try
            {
                int f = 0;
                // we create a reader for a certain document
                PdfReader reader = new PdfReader(fileList[f]);
                // we retrieve the total number of pages
                int n = reader.NumberOfPages; //There are " + n + " pages in the original file.
                // step 1: creation of a document-object
                Document document = new Document(reader.GetPageSizeWithRotation(1));
                // step 2: we create a writer that listens to the document
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outMergeFile, FileMode.Create));
                // step 3: we open the document
                document.Open();
                PdfContentByte cb = writer.DirectContent;
                PdfImportedPage page;
                int rotation;
                // step 4: we add content
                while (f < fileList.Length)
                {
                    int i = 0;
                    while (i < n)
                    {
                        i++;
                        document.SetPageSize(reader.GetPageSizeWithRotation(i));
                        document.NewPage();
                        page = writer.GetImportedPage(reader, i);
                        rotation = reader.GetPageRotation(i);
                        if (rotation == 90 || rotation == 270)
                        {
                            cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                        }
                        else
                        {
                            cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                        }
                        //Processed page i
                    }
                    f++;
                    if (f < fileList.Length)
                    {
                        reader = new PdfReader(fileList[f]);
                        // we retrieve the total number of pages
                        n = reader.NumberOfPages; //There are " + n + " pages in the original file.
                    }
                }
                // step 5: we close the document
                document.Close();
                returnStr = "Succeed!";
            }
            catch (Exception e)
            {
                returnStr += e.Message + "<br />";
                returnStr += e.StackTrace;
            }
            return returnStr;
        }

        private void mergePDF()
        {
            string[] pdflist = new string[2];
            pdflist[0] = @"c:\output.pdf";
            pdflist[1] = @"c:\output1.pdf";
            MergeMultiplePDFsToPDF(pdflist, @"c:\newpdf.pdf");
            //mergePDFFiles(pdflist, @"c:\newpdf.pdf");
        }





    }
}
