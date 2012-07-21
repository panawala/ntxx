using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Order
{
    //每条订单详细信息;
    public class orderDetailInfo
    {
        public int orderDetailInfoID { get; set; }
        public string Qty { get; set; }
        public string ProDes { get; set; }
        public string tag { get; set; }
        public string listPrice { get; set; }
        public string RepPrice { get; set; }
        public string custPrice { get; set; }

    }
}
