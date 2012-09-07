using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Report
{
    /// <summary>
    /// 数据报表格式
    /// </summary>
    public class OrderForm
    {
        public int Quantity { get; set; }
        public string Part { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public string Mark { get; set; }
        public decimal ListPrice { get; set; }
        public decimal SumPrice { get; set; }
    }
}
