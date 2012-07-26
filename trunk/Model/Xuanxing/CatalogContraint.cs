using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Xuanxing
{
    /// <summary>
    /// 属性约束表
    /// </summary>
    public class CatalogConstraint
    {
        public int CatalogConstraintID { get; set; }
        /// <summary>
        /// 主动属性名称
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// 被动属性名称
        /// </summary>
        public string InfluencedPropertyName { get; set; }
        /// <summary>
        /// 约束所属的设备Id
        /// </summary>
        public int DeviceId { get; set; }
    }
}
