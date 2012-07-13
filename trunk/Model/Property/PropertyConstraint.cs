using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Property
{
    public class PropertyConstraint
    {
        public int PropertyConstraintID { get; set; }
        //属性约束为某种设备下的约束
        public int DeviceID { get; set; }
        public int PropertyID { get; set; }
        //public string PropertyValueRange { get; set; }
        public string PropertyValueIdRange { get; set; }
        public int InfluencedPtyID { get; set; }
        //public string InfluencedPtyValueRange { get; set; }
        public string InfluencedPtyValueIdRange { get; set; }
        public string ConstraintRules { get; set; }
        //被影响属性的默认值，可以是推荐值
        public string InfluencedPtyDefaultValue { get; set; }
    }

    public class PropertyConstraintLogic
    {
        public int PropertyConstraintID { get; set; }
        //属性约束为某种设备下的约束
        public int DeviceID { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValueRange { get; set; }
        public string InfluencedPtyName { get; set; }
        public string InfluencedPtyValueRange { get; set; }
        public string ConstraintRules { get; set; }
        //被影响属性的默认值，可以是推荐值
        public string InfluencedPtyDefaultValue { get; set; }
    }
}
