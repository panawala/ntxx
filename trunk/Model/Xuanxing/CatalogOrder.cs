using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Xuanxing
{
    [Serializable]
    public class CatalogOrder
    {
        public int CatalogOrderID { get; set; }
        /// <summary>
        /// 属性名
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>
        public string Value { get; set; }


        /// <summary>
        /// 属性所属catalog
        /// </summary>
        public string PropertyParent { get; set; }
        /// <summary>
        /// 属性值描述
        /// </summary>
        public string ValueDescription { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 所属类型是model还是feature 
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 顺序号
        /// </summary>
        public int SequenceNo { get; set; }

        //所属设备Id
        public int DeviceId { get; set; }

        /// <summary>
        /// 订单Id
        /// </summary>
        public int OrderId { get; set; }
    }
}
