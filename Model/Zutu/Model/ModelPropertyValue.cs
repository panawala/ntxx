using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Zutu.Model
{
    /// <summary>
    /// 图块选型前期model选型，此为属性值表，无属性表，因属性不需要动态维护
    /// </summary>
    public class ModelPropertyValue
    {
        public int ModelPropertyValueID { get; set; }
        //属性名
        public string PropertyName { get; set; }
        //属性值代码Id,作为值的唯一标识
        public int ValueCodeID { get; set; }
        //值代码
        public string ValueCode { get; set; }
        //值描述
        public string ValueDescription { get; set; }
    }
}
