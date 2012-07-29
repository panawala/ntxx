using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Xuanxing
{
    /// <summary>
    /// 属性的表
    /// </summary>
    public class CatalogPropertyValue
    {
        public int CatalogPropertyValueID { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public int SequenceNo { get; set; }
        /// <summary>
        /// 属性父节点
        /// </summary>
        public string PropertyParent { get; set; }
        /// <summary>
        /// 属性名
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 属性值描述
        /// </summary>
        public string ValueDescription { get; set; }
        /// <summary>
        /// 属性值的条件
        /// </summary>
        public string Condition { get; set; }
        /// <summary>
        /// 属性值的默认值
        /// </summary>
        public string Default { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 属性所属的类型
        /// </summary>
        public int DeviceId { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public string DeviceType { get; set; }

        /// <summary>
        /// 属性的类型，
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 约束类型,关于价格约束等信息
        /// </summary>
        public string ConstraintType { get; set; }
    }
}
