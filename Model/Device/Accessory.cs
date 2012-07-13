using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Device
{
    public class Accessory
    {
        public int AccessoryID { get; set; }
        public string AccessoryNo { get; set; }
        public string AccessoryName { get; set; }
        public string AccessoryDescription { get; set; }
        public decimal AcessoryPrice { get; set;}
        //对应设备信息
        public int DeviceID { get; set; }
        public int PropertyID { get; set; }
        //public string PropertyValueCode { get; set; }
        public int PropertyValueCodeId { get; set; }
    }
}
