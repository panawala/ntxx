using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Xuanxing
{
    /// <summary>
    /// 价格约束表
    /// </summary>
    public class CatalogPriceConstraint
    {
        public int CatalogPriceConstraintID { get; set; }
        /// <summary>
        /// 冷量值
        /// </summary>
        public int CoolingPower { get; set; }
        /// <summary>
        /// 属性名
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 受影响的价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 设备ID
        /// </summary>
        public int DeviceId { get; set; }
        /// <summary>
        /// 设备类型
        /// </summary>
        public string DeviceType { get; set; }
    }
}
