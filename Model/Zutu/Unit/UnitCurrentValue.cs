using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Zutu.Unit
{
    /// <summary>
    /// 属性的当前选中值
    /// </summary>
    public class UnitCurrentValue
    {
        public int UnitCurrentValueID { get; set; }
            
        public string PropertyName { get; set; }
        public string Value { get; set; }
        /// <summary>
        /// 属性值选择的订单号
        /// </summary>
        public int OrderId { get; set; }
    }
}
