using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Device
{
    public class Device
    {
        public int DeviceID { get; set; }
        //设备名称
        public string DeviceName { get; set; }
        //设备描述
        public string DeviceDescription { get; set; }
        public string DeviceType { get; set; }
        //保存每类设备 的属性，默认为43种属性，（数量可变）
        public string PropertyArray { get; set; }

        //保存每个属性对应的默认值，默认43种（数量可变）
        public string PropertyValueArray { get; set; }
    }
}
