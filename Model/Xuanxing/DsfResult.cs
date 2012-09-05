using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Xuanxing
{
    /// <summary>
    /// 保存递归结果
    /// </summary>
    public class DsfResult
    {
        public int DsfResultID { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public string InfluenceProperty { get; set; }
    }
}
