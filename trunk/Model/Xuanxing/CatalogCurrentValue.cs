using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Xuanxing
{
   
    public class CatalogCurrentValue
    {
        public int CatalogCurrentValueID { get; set; }
        /// <summary>
        /// 属性名
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>
        public string Value { get; set; }

        
        //所属设备Id
        public int DeviceId { get; set; }

        /// <summary>
        /// 订单Id
        /// </summary>
        public int OrderId { get; set; }
    }
}
