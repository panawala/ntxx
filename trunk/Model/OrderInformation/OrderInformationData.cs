using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.OrderInformation
{
    public class OrderInformationData
    {
        public int OrderInformationDataID { get; set; }
        public int OrderID { get; set; }
        
        /// <summary>
        /// 项目编号
        /// </summary>
        public string JobNo { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string JobName { get; set; }
        

        /// <summary>
        /// 项目交易时间
        /// </summary>
        public string DealDate { get; set; }

        /// <summary>
        ///项目总价 
        /// </summary>
        public decimal TotalPrice { get; set; }


        public string CustomerPONo { get; set; }
        public string CustomerNo { get; set; }
        /// <summary>
        /// 艺龙联系人
        /// </summary>
        public string AAonCont { get; set; }
        public string ShopOrderNo { get; set; }
        public string CustCont { get; set; }
        public string rep1 { get; set; }
        public string rep2 { get; set; }
        public string rep3 { get; set; }
        public string rep4 { get; set; }
        public string MarketCode { get; set; }

        /// <summary>
        /// 海拔高度
        /// </summary>
        public decimal SiteAltitude { get; set; }
        public string RepCont { get; set; }
        public string OrderBy { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string SoldName { get; set; }
        public string SoldAddress1 { get; set; }
        public string SoldAddress2 { get; set; }
        public string SoldCity { get; set; }
        public string SoldCountry { get; set; }
        public string SoldState { get; set; }
        public string SoldZipCode { get; set; }

        //运输信息
        public string RepShipDate { get; set; }
        public string ShipZone { get; set; }
        /// <summary>
        /// 行为，Hold For Approval或者Release To Production
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 是否允许海运，值为Allowed或者PPD&Add Actual或者Collect
        /// </summary>
        public string Ship { get; set; }

        /// <summary>
        /// 运送方式
        /// </summary>
        public string ShipVia { get; set; }

        /// <summary>
        /// 备注：textbox+48 hours before delivery@Tel # 2324
        /// </summary>
        public string Notify { get; set; }

        /// <summary>
        /// 小时数
        /// </summary>
        public string Hours { get; set; }

        /// <summary>
        /// 通知电话
        /// </summary>
        public string NotifyTel { get; set; }

        public string ManualEntry { get; set; }

        /// <summary>
        /// 运送到达名称
        /// </summary>
        public string ShipName { get; set; }
        public string ShipAddress1 { get; set; }
        public string ShipAddress2 { get; set; }
        public string ShipCity { get; set; }
        public string ShipState { get; set; }
        public string ShipCountry { get; set; }
        public string ShipZipCode { get; set; }

        //注意事项
        /// <summary>
        /// 项目描述
        /// </summary>
        public string JobDescription { get; set; }

        /// <summary>
        /// 客户注意事项
        /// </summary>
        public string CustNotes { get; set; }

        //价格信息
        public string RepMult { get; set; }
        public string CommissionRep1 { get; set; }
        public string CommissionRep2 { get; set; }
        public string CommissionRep3 { get; set; }
        public string CommissionRep4 { get; set; }
        public string MarkUp { get; set; }
        public string Commission { get; set; }
        public string OrderTotal { get; set; }
        
        /// <summary>
        /// 税务信息
        /// </summary>
        public string IsTaxable { get; set; }

        public string IDNo { get; set; }

        public string Des1 { get; set; }
        public string Des2 { get; set; }
        public string Des3 { get; set; }
        public string Des4 { get; set; }
        public string Amount1 { get; set; }
        public string Amount2 { get; set; }
        public string Amount3 { get; set; }
        public string Amount4 { get; set; }
    }
}
