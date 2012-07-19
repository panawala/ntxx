using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Zutu.Model
{
    /// <summary>
    /// 图块选型前期model选型的约束
    /// </summary>
    public class ModelConstraint
    {
        public int ModelConstraintID { get; set; }
        //主动属性的名称
        public string PropertyName { get; set; }
        //主动属性的值的valueCodeId的范围
        public string ValueCodeIDRange { get; set; }

        //被动属性值名称
        public string InfluencedPropertyName { get; set; }
        //被动属性的值的valueCodeId
        public int ValueCodeID { get; set; }

        //属性约束规则
        public string ConstraintRule { get; set; }
    }
}
