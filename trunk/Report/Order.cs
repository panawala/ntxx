using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Report
{
    public class Order
    {
        public int OrderId { get; set; }
        public int OrderCount { get; set; }
        public string OrderDescription { get; set; }
        public string OrderTag { get; set; }
        public decimal OrderPrice { get; set; }
    }
}
