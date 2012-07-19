using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Property
{
    public class Property
    {
        public int PropertyID { get; set; }
        public string PropertyName { get; set; }
        public int PropertyParentID { get; set; }
        public string CatalogName { get; set; }
        //默认PropertyValue值
        //public string PropertyDefaultValue { get; set; }
        //默认PropertyValue值的Id
        public int PropertyDefaultValueID { get; set; }

        public string PropertyType { get; set; }
        //public virtual ICollection<PropertyValue> PropertyValues { get; set; }
        //属性所属的设备ID.
        public int DeviceID { get; set; }
    }
}
