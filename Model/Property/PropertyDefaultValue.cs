using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Property
{
    public class PropertyDefaultValue
    {
        public int PropertyDefaultValueID { get; set; }
        //属性所属的设备ID
        public int DeviceID { get; set; }
        //属性名字
        public string PropertyName { get; set; }
        //属性值ID
        public int ValueCodeID { get; set; }

    }
}
