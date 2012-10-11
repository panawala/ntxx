using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Order
{
    //每条订单详细信息;
    [Serializable]
    public class orderDetailInfo
    {
        public int OdDetlNum { get; set; }  //订单排序号;
        public string Qty { get; set; }
        public string ProDes { get; set; }
        public string tag { get; set; }
        public string listPrice { get; set; }
        public string RepPrice { get; set; }
        public string custPrice { get; set; }
        /// <summary>
        /// 订单详情ID
        /// </summary>
        public int orderDetailInfoID { get; set; }//订单详细信息类自身唯一ID
        /// <summary>
        /// 订单详情中保存的组图和选型的订单ID
        /// </summary>
        public int OrderDetailNo { get; set; }
        /// <summary>
        /// 父订单ID
        /// </summary>
        public int OrderInfoId { get; set; }//对应订单的ID
        public int OrderInfoType { get; set; }//1的时候选型，2的时候选图

        //选型设备ID和类型
        public int DeviceId { get; set; }
        public string DeviceType { get; set; }
    }
}
