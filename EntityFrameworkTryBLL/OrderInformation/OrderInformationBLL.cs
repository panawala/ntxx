using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.OrderInformation;
using DataContext;

namespace EntityFrameworkTryBLL.OrderInformation
{
    public class OrderInformationBLL
    {
        public static int InsertInformationData(OrderInformationData odif)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    OrderInformationData OdIfData = new OrderInformationData();
                    OdIfData.OrderID = odif.OrderID;
                    OdIfData.JobNo = odif.JobNo;
                    OdIfData.JobName = odif.JobName;
                    OdIfData.DealDate = odif.DealDate;
                    OdIfData.TotalPrice = odif.TotalPrice;

                    OdIfData.CustomerPONo = odif.CustomerPONo;
                    OdIfData.CustomerNo = odif.CustomerNo;
                    OdIfData.AAonCont = odif.AAonCont;
                    OdIfData.ShopOrderNo = odif.ShopOrderNo;
                    OdIfData.CustCont = odif.CustCont;


                    OdIfData.rep1 = odif.rep1;
                    OdIfData.rep2 = odif.rep2;
                    OdIfData.rep3 = odif.rep3;
                    OdIfData.rep4 = odif.rep4;
                    OdIfData.MarketCode = odif.MarketCode;

                    OdIfData.SiteAltitude = odif.SiteAltitude;
                    OdIfData.RepCont = odif.RepCont;
                    OdIfData.OrderBy = odif.OrderBy;


                    OdIfData.SoldName = odif.SoldName;
                    OdIfData.SoldAddress1 = odif.SoldAddress1;
                    OdIfData.SoldAddress2 = odif.SoldAddress2;
                    OdIfData.SoldCity = odif.SoldCity;
                    OdIfData.SoldCountry = odif.SoldCountry;
                    OdIfData.SoldState = odif.SoldState;
                    OdIfData.SoldZipCode = odif.SoldZipCode;


                    OdIfData.ShipName = odif.ShipName;
                    OdIfData.ShipState = odif.ShipState;
                    OdIfData.ShipVia = odif.ShipVia;
                    OdIfData.ShipZipCode = odif.ShipZipCode;
                    OdIfData.ShipZone = odif.ShipZone;
                    OdIfData.ShopOrderNo = odif.ShopOrderNo;

                    OdIfData.RepShipDate = odif.RepShipDate;
                    OdIfData.ShipZone = odif.ShipZone;

                    OdIfData.Action = odif.Action;

                    OdIfData.Ship = odif.Ship;
                    OdIfData.ShipVia = odif.ShipVia;
                    OdIfData.Notify = odif.Notify;
                    OdIfData.Hours = odif.Hours;
                    OdIfData.NotifyTel = odif.NotifyTel;
                    OdIfData.ManualEntry = odif.ManualEntry;


                    OdIfData.ShipName = odif.ShipName;
                    OdIfData.ShipAddress1 = odif.ShipAddress1;
                    OdIfData.ShipAddress2 = odif.ShipAddress2;
                    OdIfData.ShipCity = odif.ShipCity;
                    OdIfData.ShipCountry = odif.ShipCountry;
                    OdIfData.ShipZipCode = odif.ShipZipCode;

                    OdIfData.JobDescription = odif.JobDescription;
                    OdIfData.CustNotes = odif.CustNotes;


                    OdIfData.RepMult = odif.RepMult;
                    OdIfData.CommissionRep1 = odif.CommissionRep1;
                    OdIfData.CommissionRep2 = odif.CommissionRep2;
                    OdIfData.CommissionRep3 = odif.CommissionRep3;
                    OdIfData.CommissionRep4 = odif.CommissionRep4;
                    OdIfData.MarkUp = odif.MarkUp;
                    OdIfData.Commission = odif.Commission;
                    OdIfData.OrderTotal = odif.OrderTotal;

                    OdIfData.IsTaxable = odif.IsTaxable;
                    OdIfData.IDNo = odif.IDNo;
                    OdIfData.Des1 = odif.Des1;
                    OdIfData.Des2 = odif.Des2;
                    OdIfData.Des3 = odif.Des3;
                    OdIfData.Des4 = odif.Des4;


                    OdIfData.Amount1 = odif.Amount1;
                    OdIfData.Amount2 = odif.Amount2;
                    OdIfData.Amount3 = odif.Amount3;
                    OdIfData.Amount4 = odif.Amount4;
                    
                    context.OrderInformationDatas.Add(OdIfData);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        public static int ModifyInformationData(OrderInformationData odif,int Orderid)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var OdIfData = context.OrderInformationDatas
                        .Where(s => s.OrderID == Orderid)
                        .First();

                    OdIfData.OrderID = odif.OrderID;
                    OdIfData.JobNo = odif.JobNo;
                    OdIfData.JobName = odif.JobName;
                    OdIfData.DealDate = odif.DealDate;
                    OdIfData.TotalPrice = odif.TotalPrice;

                    OdIfData.CustomerPONo = odif.CustomerPONo;
                    OdIfData.CustomerNo = odif.CustomerNo;
                    OdIfData.AAonCont = odif.AAonCont;
                    OdIfData.ShopOrderNo = odif.ShopOrderNo;
                    OdIfData.CustCont = odif.CustCont;


                    OdIfData.rep1 = odif.rep1;
                    OdIfData.rep2 = odif.rep2;
                    OdIfData.rep3 = odif.rep3;
                    OdIfData.rep4 = odif.rep4;
                    OdIfData.MarketCode = odif.MarketCode;

                    OdIfData.SiteAltitude = odif.SiteAltitude;
                    OdIfData.RepCont = odif.RepCont;
                    OdIfData.OrderBy = odif.OrderBy;


                    OdIfData.SoldName = odif.SoldName;
                    OdIfData.SoldAddress1 = odif.SoldAddress1;
                    OdIfData.SoldAddress2 = odif.SoldAddress2;
                    OdIfData.SoldCity = odif.SoldCity;
                    OdIfData.SoldCountry = odif.SoldCountry;
                    OdIfData.SoldState = odif.SoldState;
                    OdIfData.SoldZipCode = odif.SoldZipCode;


                    OdIfData.ShipName = odif.ShipName;
                    OdIfData.ShipState = odif.ShipState;
                    OdIfData.ShipVia = odif.ShipVia;
                    OdIfData.ShipZipCode = odif.ShipZipCode;
                    OdIfData.ShipZone = odif.ShipZone;
                    OdIfData.ShopOrderNo = odif.ShopOrderNo;

                    OdIfData.RepShipDate = odif.RepShipDate;
                    OdIfData.ShipZone = odif.ShipZone;

                    OdIfData.Action = odif.Action;

                    OdIfData.Ship = odif.Ship;
                    OdIfData.ShipVia = odif.ShipVia;
                    OdIfData.Notify = odif.Notify;
                    OdIfData.Hours = odif.Hours;
                    OdIfData.NotifyTel = odif.NotifyTel;
                    OdIfData.ManualEntry = odif.ManualEntry;


                    OdIfData.ShipName = odif.ShipName;
                    OdIfData.ShipAddress1 = odif.ShipAddress1;
                    OdIfData.ShipAddress2 = odif.ShipAddress2;
                    OdIfData.ShipCity = odif.ShipCity;
                    OdIfData.ShipCountry = odif.ShipCountry;
                    OdIfData.ShipZipCode = odif.ShipZipCode;

                    OdIfData.JobDescription = odif.JobDescription;
                    OdIfData.CustNotes = odif.CustNotes;


                    OdIfData.RepMult = odif.RepMult;
                    OdIfData.CommissionRep1 = odif.CommissionRep1;
                    OdIfData.CommissionRep2 = odif.CommissionRep2;
                    OdIfData.CommissionRep3 = odif.CommissionRep3;
                    OdIfData.CommissionRep4 = odif.CommissionRep4;
                    OdIfData.MarkUp = odif.MarkUp;
                    OdIfData.Commission = odif.Commission;
                    OdIfData.OrderTotal = odif.OrderTotal;

                    OdIfData.IsTaxable = odif.IsTaxable;
                    OdIfData.IDNo = odif.IDNo;
                    OdIfData.Des1 = odif.Des1;
                    OdIfData.Des2 = odif.Des2;
                    OdIfData.Des3 = odif.Des3;
                    OdIfData.Des4 = odif.Des4;


                    OdIfData.Amount1 = odif.Amount1;
                    OdIfData.Amount2 = odif.Amount2;
                    OdIfData.Amount3 = odif.Amount3;
                    OdIfData.Amount4 = odif.Amount4;

                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }
         
        public static List<OrderInformationData> ShowInformationData(int Orderid)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var OdIfData = context.OrderInformationDatas
                        .Where(s => s.OrderID == Orderid)
                        .ToList();

                    
                    return OdIfData;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
    }
}
