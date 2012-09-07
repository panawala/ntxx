using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Device
{
    /// <summary>
    /// 附件订单
    /// </summary>
    public class AccessoryOrder
    {
        public int AccessoryOrderID { get; set; }
        /// <summary>
        /// 订单Id
        /// </summary>
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public string PartNo { get; set; }
        public string PartDescription { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal ListPrice { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal Price { get; set; }
    }
}
