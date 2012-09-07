using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Device
{
    /// <summary>
    /// 附件表
    /// </summary>
    public class Accessory
    {
        public int AccessoryID { get; set; }
        public string Unit { get; set; }
        public string PartNo { get; set; }
        public string PartDescription { get; set; }
        public string Model { get; set; }
        public string Heat { get; set; }
        public string Cool { get; set; }
        public string SystemSwitching { get; set; }
        public string FanSwitching { get; set; }
        public string Application { get; set; }
        public string ChangeOver { get; set; }
        public string Use { get; set; }
        public decimal ListPrice { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
    }
}
