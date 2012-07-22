using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Zutu.Unit
{
    /// <summary>
    /// Unit模型类
    /// </summary>
    public class UnitModel
    {
        public int UnitModelID { get; set; }
        /// <summary>
        /// 属性名
        /// </summary>
        public string Property { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 属性值描述
        /// </summary>
        public string ValueDescription { get; set; }
        /// <summary>
        /// 条件字符串，符合一定格式
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string Default { get; set; }

        /// <summary>
        /// 值是否锁定
        /// </summary>
        public string IsReadOnly { get; set; }
    }
}
