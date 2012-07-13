using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Property
{
    //记录属性值
    public class PropertyValue
    {
        public int PropertyValueID { get; set; }
        //对应Property外键,两者为一对多的关系
        public int PropertyID { get; set; }
        //public virtual Property Property { get; set; }

        //每个属性值的ID，一个属性的值里面有多个同样的valueCode
        public int ValueCodeID { get; set; }
        public string ValueCode { get; set; }
        public string ValueDescription { get; set; }
        public decimal Price { get; set; }
        //对应设备的标识
        public int DeviceID { get; set; }
        public string PropertyValueType { get; set; }
    }
}
