﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Order
{
    //订单信息;
    public class ordersinfo
    {
        public int ordersinfoID { get; set; }
        public int OrderNo { get; set; }//订单排列编号;l
        public string JobNum { get; set; }  //订单编号;
        public string JobName { get; set; }  //订单名称;
        public string JobDes { get; set; }  //订单描述;
        //public int OrderID { get; set; }            //订单唯一ID
        public int Site { get; set; }
        public string Customer { get; set; }  //客户名称;
        public string Activity { get; set; }   //建立订单日期;
        public float OrderTotal { get; set; }
        public string AAonCon { get; set; }
    }
}
