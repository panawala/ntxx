using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Device
{
    public class CurrentDevice
    {
        public int CurrentDeviceID { get; set; }
        public int DeviceID { get; set; }
        public int PropertyID { get; set;}
        public string PropertyValueArray { get; set; }

        //对应的订单详情ID
        public int OrderDetailID { get; set; }

        //当前属性的默认值代码
        //public string PropertyRecommandValue { get; set; }
        //当前选中属性值的代码
        //public string PropertyValueCode { get; set; }
        public int PropertyValueId { get; set; }
    }
}
