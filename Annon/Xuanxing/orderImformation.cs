using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.Order;
using EntityFrameworkTryBLL.OrderManager;
using Model.OrderInformation;
using EntityFrameworkTryBLL.OrderInformation;

namespace Annon.Xuanxing
{
    public partial class orderImformation : Form
    {
        public List<ordersinfo> TmpOrder = new List<ordersinfo>();
        public orderImformation()
        {
            InitializeComponent();
            hours_comboBox.Text = 48+"";
            //rep4_comboBox.BackColor = Color.LightGray;
            //rep4_label.BackColor = Color.LightGray;
            RTP_radioButton.Checked = true;
            allow_radioButton.Checked = true;

            site_numericUpDown.Value = 100;
            site_numericUpDown.Maximum = 10000000;
            site_numericUpDown.Minimum = -10000000;
            site_numericUpDown.Increment = 50;

            ID_textBox.Enabled = false;
            ID_textBox.BackColor = Color.LightGray;

            shipdate_dateTimePicker.Format = DateTimePickerFormat.Custom;
            shipdate_dateTimePicker.CustomFormat = "yyyy-MM-dd";

            rep1_textBox.BackColor = Color.LightGray;
            rep1_textBox.Text = 100+"";
            rep2_textBox.BackColor = Color.LightGray;
            rep2_textBox.Text = 0 + "";
            rep3_textBox.BackColor = Color.LightGray;
            rep3_textBox.Text = 0 + "";
            rep4_textBox.BackColor = Color.LightGray;
            rep4_textBox.Text = 0 + "";

            repMul_textBox.Text= 1.0 + "";

            tax_radioButton.Checked = true;

            commission_textBox.BackColor = Color.LightGoldenrodYellow;
            orderTotal_textBox.BackColor = Color.LightGoldenrodYellow;
            //markup_textBox.BackColor = Color.LightGoldenrodYellow;
        }

        private void orderImformation_Load(object sender, EventArgs e)
        {

        }

        private void OK_button_Click(object sender, EventArgs e)
        {

            AAonRating.aaon.OrderInfo.JobNum = Jobno_textBox.Text;
            AAonRating.aaon.OrderInfo.JobName = JobName_textBox.Text;
            AAonRating.aaon.OrderInfo.JobDes = jobDes_textBox.Text;
            AAonRating.aaon.OrderInfo.Customer = Name_comboBox.Text;
            AAonRating.aaon.OrderInfo.Site = (int)site_numericUpDown.Value;
            //OrderInfo.OrderTotal =orderTotal_textBox.Text;
            AAonRating.aaon.OrderInfo.Activity = DateTime.Now.ToString("dd-MM-yyyy");
            AAonRating.aaon.OrderInfo.AAonCon = AAONContact_comboBox.Text;

           

            //新增订单信息传入数据库;
            if (AAonRating.aaon.AddOrder)
            {
                AAonRating.aaon.OrderRowNo++;
                OrderBLL.InsertIntoOrder(AAonRating.aaon.OrderRowNo ,AAonRating.aaon.OrderInfo.JobNum, AAonRating.aaon.OrderInfo.JobName, AAonRating.aaon.OrderInfo.JobDes, AAonRating.aaon.OrderInfo.Site, AAonRating.aaon.OrderInfo.Customer, AAonRating.aaon.OrderInfo.Activity, AAonRating.aaon.OrderInfo.AAonCon);
                AAonRating.aaon.RowIndex = OrderBLL.ReturnLastID();
                InsertInfoData(AAonRating.aaon.RowIndex);
            }

            //修改订单信息;
            if (!AAonRating.aaon.AddOrder)
            {
                if (TmpOrder.Count > 0)
                {
                    OrderBLL.ModifyOrder(TmpOrder.First().ordersinfoID, TmpOrder.First().OrderNo, Jobno_textBox.Text, JobName_textBox.Text, jobDes_textBox.Text, (int)(site_numericUpDown.Value), Name_comboBox.Text, TmpOrder.First().Activity, AAONContact_comboBox.Text);
                    AAonRating.aaon.AddOrder = true;
                    ModifyInfoData(AAonRating.aaon.RowIndex);
                }
            }

            //从数据库获取订单信息;

            AAonRating.aaon.ll = OrderBLL.GetAllOrder();
            AAonRating.aaon.dataGridView1.DataSource = AAonRating.aaon.ll;
           // ll2 = OrderBLL.GetAllOrder();

           
            this.Close();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tax_radioButton_MouseClick(object sender, MouseEventArgs e)
        {
            ID_textBox.Enabled = false;
            ID_textBox.BackColor = Color.LightGray;
        }

        private void nonTax_radioButton_MouseClick(object sender, MouseEventArgs e)
        {
            ID_textBox.Enabled = true;
            ID_textBox.BackColor = Color.White;
        }

        private void markup_textBox_MouseClick(object sender, MouseEventArgs e)
        {
            commission_textBox.BackColor = Color.LightGoldenrodYellow;
            commission_textBox.Clear();
            orderTotal_textBox.BackColor = Color.LightGoldenrodYellow;
            orderTotal_textBox.Clear();
            markup_textBox.BackColor = Color.White;
            
        }

        private void commission_textBox_MouseClick(object sender, MouseEventArgs e)
        {
            commission_textBox.BackColor = Color.White;
            orderTotal_textBox.BackColor = Color.LightGoldenrodYellow;
            orderTotal_textBox.Clear();
            markup_textBox.BackColor = Color.LightGoldenrodYellow;
            markup_textBox.Clear();
        }

        private void orderTotal_textBox_MouseClick(object sender, MouseEventArgs e)
        {
            commission_textBox.BackColor = Color.LightGoldenrodYellow;
            commission_textBox.Clear();
            orderTotal_textBox.BackColor = Color.White;
            markup_textBox.BackColor = Color.LightGoldenrodYellow;
            markup_textBox.Clear();
            
        }

        private void markup_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void InsertInfoData(int orderid)
        {
            OrderInformationData OdIfData = new OrderInformationData();

            OdIfData.DealDate = DateTime.Now.ToString("dd-MM-yyyy");
            OdIfData.OrderID = orderid;
            OdIfData.JobNo = Jobno_textBox.Text;
            OdIfData.CustomerPONo = Cust_No_textBox.Text;
            OdIfData.JobName = JobName_textBox.Text;
            OdIfData.CustomerNo = CustNo_textBox.Text;
            OdIfData.AAonCont = AAONContact_comboBox.Text;

            OdIfData.ShopOrderNo = shopOrderNo_textBox.Text;
            OdIfData.CustCont = CustContact_comboBox.Text;
            OdIfData.rep1 = rep1_comboBox.Text;
            OdIfData.rep2 = rep2_comboBox.Text;
            OdIfData.rep3 = rep3_comboBox.Text;
            OdIfData.rep4 = rep4_comboBox.Text;

            OdIfData.MarketCode = market_textBox.Text;
            OdIfData.SiteAltitude = site_numericUpDown.Value;
            OdIfData.RepCont = repContact_comboBox.Text;
            OdIfData.OrderBy = OrderBy_comboBox.Text;

            OdIfData.SoldName = Name_comboBox.Text;
            OdIfData.SoldAddress1 = Address1_textBox.Text;
            OdIfData.SoldAddress2 = Address2_textBox.Text;
            OdIfData.SoldCity = city_textBox.Text;
            OdIfData.SoldCountry = country_textBox.Text;
            OdIfData.SoldState = state_comboBox.Text;
            OdIfData.SoldZipCode = zipCode_textBox.Text;



            OdIfData.RepShipDate = shipdate_dateTimePicker.Text;
            OdIfData.ShipZone = shipZone_textBox.Text;

            if (HFA_radioButton.Checked == true)
            {
                OdIfData.Action = HFA_radioButton.Text;
            }
            else
            {
                OdIfData.Action = RTP_radioButton.Text;
            }

            OdIfData.ShipVia = ShipVIA_comboBox.Text;

            if (allow_radioButton.Checked == true)
            {
                OdIfData.Ship = allow_radioButton.Text;
            }
            else if (PPD_radioButton.Checked == true)
            {
                OdIfData.Ship = PPD_radioButton.Text;
            }
            else
            {
                OdIfData.Ship = collect_radioButton.Text;
            }

            OdIfData.Notify = notify_textBox.Text;
            OdIfData.Hours = hours_comboBox.Text;
            OdIfData.NotifyTel = tel_textBox.Text;
            OdIfData.ManualEntry = ManEnter_textBox.Text;
            OdIfData.ShipName = comboBox2.Text;
            OdIfData.ShipAddress1 = textBox5.Text;
            OdIfData.ShipAddress2 = textBox4.Text;
            OdIfData.ShipCity = textBox3.Text;
            OdIfData.ShipState = comboBox1.Text;
            OdIfData.ShipCountry = textBox2.Text;
            OdIfData.ShipZipCode = textBox1.Text;


            OdIfData.JobDescription = jobDes_textBox.Text;
            OdIfData.CustNotes = custNote_textBox.Text;


            OdIfData.RepMult = repMul_textBox.Text;
            OdIfData.CommissionRep1 = rep1_textBox.Text;
            OdIfData.CommissionRep2 = rep2_textBox.Text;
            OdIfData.CommissionRep3 = rep3_textBox.Text;
            OdIfData.CommissionRep4 = rep4_textBox.Text;

            OdIfData.MarkUp = markup_textBox.Text;
            OdIfData.Commission = commission_textBox.Text;
            OdIfData.OrderTotal = orderTotal_textBox.Text;


            if (nonTax_radioButton.Checked == true)
            {
                OdIfData.IsTaxable = tax_radioButton.Text;
            }
            else
            {
                OdIfData.IsTaxable = nonTax_radioButton.Text + ID_textBox.Text;
            }

            OdIfData.Des1 = Des1_textBox.Text;
            OdIfData.Des2 = Des2_textBox.Text;
            OdIfData.Des3 = Des3_textBox.Text;
            OdIfData.Des4 = Des4_textBox.Text;
            OdIfData.Amount1 = Amount1_textBox.Text;
            OdIfData.Amount2 = Amount2_textBox.Text;
            OdIfData.Amount3 = Amount3_textBox.Text;
            OdIfData.Amount4 = Amount4_textBox.Text;

            OrderInformationBLL.InsertInformationData(OdIfData);
        }

        public void ModifyInfoData(int orderid)
        {
            OrderInformationData OdIfData = new OrderInformationData();
            OdIfData.OrderID = orderid;
            OdIfData.JobNo = Jobno_textBox.Text;
            OdIfData.CustomerPONo = Cust_No_textBox.Text;
            OdIfData.JobName = JobName_textBox.Text;
            OdIfData.CustomerNo = CustNo_textBox.Text;
            OdIfData.AAonCont = AAONContact_comboBox.Text;

            OdIfData.ShopOrderNo = shopOrderNo_textBox.Text;
            OdIfData.CustCont = CustContact_comboBox.Text;
            OdIfData.rep1 = rep1_comboBox.Text;
            OdIfData.rep2 = rep2_comboBox.Text;
            OdIfData.rep3 = rep3_comboBox.Text;
            OdIfData.rep4 = rep4_comboBox.Text;

            OdIfData.MarketCode = market_textBox.Text;
            OdIfData.SiteAltitude = site_numericUpDown.Value;
            OdIfData.RepCont = repContact_comboBox.Text;
            OdIfData.OrderBy = OrderBy_comboBox.Text;

            OdIfData.SoldName = Name_comboBox.Text;
            OdIfData.SoldAddress1 = Address1_textBox.Text;
            OdIfData.SoldAddress2 = Address2_textBox.Text;
            OdIfData.SoldCity = city_textBox.Text;
            OdIfData.SoldCountry = country_textBox.Text;
            OdIfData.SoldState = state_comboBox.Text;
            OdIfData.SoldZipCode = zipCode_textBox.Text;
            OdIfData.RepShipDate = shipdate_dateTimePicker.Text;
            OdIfData.ShipZone = shipZone_textBox.Text;

            if (HFA_radioButton.Checked == true)
            {
                OdIfData.Action = HFA_radioButton.Text;
            }
            else
            {
                OdIfData.Action = RTP_radioButton.Text;
            }

            OdIfData.ShipVia = ShipVIA_comboBox.Text;

            if (allow_radioButton.Checked == true)
            {
                OdIfData.Ship = allow_radioButton.Text;
            }
            else if (PPD_radioButton.Checked == true)
            {
                OdIfData.Ship = PPD_radioButton.Text;
            }
            else
            {
                OdIfData.Ship = collect_radioButton.Text;
            }

            OdIfData.Notify = notify_textBox.Text;
            OdIfData.Hours = hours_comboBox.Text;
            OdIfData.NotifyTel = tel_textBox.Text;
            OdIfData.ManualEntry = ManEnter_textBox.Text;
            OdIfData.ShipName = comboBox2.Text;
            OdIfData.ShipAddress1 = textBox5.Text;
            OdIfData.ShipAddress2 = textBox4.Text;
            OdIfData.ShipCity = textBox3.Text;
            OdIfData.ShipState = comboBox1.Text;
            OdIfData.ShipCountry = textBox2.Text;
            OdIfData.ShipZipCode = textBox1.Text;


            OdIfData.JobDescription = jobDes_textBox.Text;
            OdIfData.CustNotes = custNote_textBox.Text;


            OdIfData.RepMult = repMul_textBox.Text;
            OdIfData.CommissionRep1 = rep1_textBox.Text;
            OdIfData.CommissionRep2 = rep2_textBox.Text;
            OdIfData.CommissionRep3 = rep3_textBox.Text;
            OdIfData.CommissionRep4 = rep4_textBox.Text;

            OdIfData.MarkUp = markup_textBox.Text;
            OdIfData.Commission = commission_textBox.Text;
            OdIfData.OrderTotal = orderTotal_textBox.Text;


            if (tax_radioButton.Checked == true)
            {
                OdIfData.IsTaxable = tax_radioButton.Text;
            }
            else
            {
                OdIfData.IsTaxable = nonTax_radioButton.Text;
                OdIfData.IDNo = ID_textBox.Text;
            }

            OdIfData.Des1 = Des1_textBox.Text;
            OdIfData.Des2 = Des2_textBox.Text;
            OdIfData.Des3 = Des3_textBox.Text;
            OdIfData.Des4 = Des4_textBox.Text;
            OdIfData.Amount1 = Amount1_textBox.Text;
            OdIfData.Amount2 = Amount2_textBox.Text;
            OdIfData.Amount3 = Amount3_textBox.Text;
            OdIfData.Amount4 = Amount4_textBox.Text;

            OrderInformationBLL.ModifyInformationData(OdIfData,OdIfData.OrderID);
        }

        public void ShowInfoData(int orderid)
        {
            List<OrderInformationData> OdIfData = new List<OrderInformationData>();
            OdIfData = OrderInformationBLL.ShowInformationData(orderid);
            Jobno_textBox.Text = OdIfData.First().JobNo;
            Cust_No_textBox.Text = OdIfData.First().CustomerPONo;
            JobName_textBox.Text = OdIfData.First().JobName;
            CustNo_textBox.Text = OdIfData.First().CustomerNo;
            AAONContact_comboBox.Text = OdIfData.First().AAonCont;
            AAONContact_comboBox.Items.Add(OdIfData.First().AAonCont);
            shopOrderNo_textBox.Text = OdIfData.First().ShopOrderNo;
            CustContact_comboBox.Text = OdIfData.First().CustCont;

            rep1_textBox.Text = OdIfData.First().rep1;
            rep2_textBox.Text = OdIfData.First().rep2;
            rep3_textBox.Text = OdIfData.First().rep3;
            rep4_textBox.Text = OdIfData.First().rep4;

            market_textBox.Text = OdIfData.First().MarketCode;
            site_numericUpDown.Value = OdIfData.First().SiteAltitude;
            repContact_comboBox.Text = OdIfData.First().RepCont;
            OrderBy_comboBox.Text = OdIfData.First().OrderBy;

            Name_comboBox.Text = OdIfData.First().SoldName;
            Address1_textBox.Text = OdIfData.First().SoldAddress1;
            Address2_textBox.Text = OdIfData.First().SoldAddress2;
            city_textBox.Text = OdIfData.First().SoldCity;
            country_textBox.Text = OdIfData.First().SoldCountry;
            state_comboBox.Text = OdIfData.First().SoldState;
            zipCode_textBox.Text = OdIfData.First().SoldZipCode;

            shipdate_dateTimePicker.Text = OdIfData.First().RepShipDate;
            shipZone_textBox.Text = OdIfData.First().ShipZone;
            if (OdIfData.First().Action.Contains("Hold"))
            {
                HFA_radioButton.Checked = true;
            }
            else
            {
                RTP_radioButton.Checked = true;
            }

            ShipVIA_comboBox.Text = OdIfData.First().ShipVia;
            if (OdIfData.First().Ship.Equals("Allowed"))
            {
                allow_radioButton.Checked = true;
            }
            else if (OdIfData.First().Ship.Contains("PPD"))
            {
                PPD_radioButton.Checked = true;
            }
            else
            {
                collect_radioButton.Checked = true;
            }

            notify_textBox.Text = OdIfData.First().Notify;
            hours_comboBox.Text = OdIfData.First().Hours;
            tel_textBox.Text = OdIfData.First().NotifyTel;

            ManEnter_textBox.Text = OdIfData.First().ManualEntry;


            textBox5.Text = OdIfData.First().ShipAddress1;
            textBox4.Text = OdIfData.First().ShipAddress2;
            textBox3.Text = OdIfData.First().ShipCity;
            textBox2.Text = OdIfData.First().ShipCountry;
            comboBox2.Text = OdIfData.First().ShipName;
            comboBox2.Items.Add(OdIfData.First().ShipName);
            comboBox1.Text = OdIfData.First().ShipState;
            textBox1.Text = OdIfData.First().ShipZipCode;


            jobDes_textBox.Text = OdIfData.First().JobDescription;
            custNote_textBox.Text = OdIfData.First().CustNotes;


            repMul_textBox.Text = OdIfData.First().RepMult;
            rep1_textBox.Text = OdIfData.First().CommissionRep1;
            rep2_textBox.Text = OdIfData.First().CommissionRep2;
            rep3_textBox.Text = OdIfData.First().CommissionRep3;
            rep4_textBox.Text = OdIfData.First().CommissionRep4;

            markup_textBox.Text = OdIfData.First().MarkUp;
            commission_textBox.Text = OdIfData.First().Commission;
            orderTotal_textBox.Text = OdIfData.First().OrderTotal;

            if (OdIfData.First().IsTaxable.Equals("Taxable"))
            {
                tax_radioButton.Checked = true;
            }
            else
            {
                nonTax_radioButton.Checked = true;
                ID_textBox.Text = OdIfData.First().IDNo;
            }

            Des1_textBox.Text = OdIfData.First().Des1;
            Des2_textBox.Text = OdIfData.First().Des2;
            Des3_textBox.Text = OdIfData.First().Des3;
            Des4_textBox.Text = OdIfData.First().Des4;


            Amount1_textBox.Text = OdIfData.First().Amount1;
            Amount2_textBox.Text = OdIfData.First().Amount2;
            Amount3_textBox.Text = OdIfData.First().Amount3;
            Amount4_textBox.Text = OdIfData.First().Amount4;
            
        }

    }
}
