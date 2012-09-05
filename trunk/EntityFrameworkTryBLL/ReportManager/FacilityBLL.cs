using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Report;
using DataContext;
using Model.Order;
using Model.OrderInformation;

namespace EntityFrameworkTryBLL.ReportManager
{
    public class FacilityBLL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="deviceId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        //public static List<Facility> getFacility(int orderId, int deviceId, string type)
        //{
        //    using (var context = new AnnonContext())
        //    {
        //        try
        //        {
        //            var facilityList = from x in context.CatalogOrders
        //                               join y in context.CatalogPropertyValues
        //                               on new { K1 = x.PropertyName, K2 = x.Value }
        //                               equals new { K1 = y.PropertyName, K2 = y.Value }
        //                               where x.OrderId == orderId && y.DeviceId == deviceId && x.Type == type
        //                               orderby x.SequenceNo
        //                               select new Facility
        //                               {
        //                                   PropertyName= y.PropertyName,
        //                                   Value= y.Value,
        //                                   PropertyParent= y.PropertyParent,
        //                                   ValueDescription= y.ValueDescription
        //                               };

        //            return facilityList.ToList();
        //        }
        //        catch (Exception e)
        //        {
        //            return null;
        //        }
        //    }
        //}

        public static List<Facility> getFacility(int orderId, int deviceId, string type)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var facilityList =
                        context.CatalogCurrentValues
                        .Where(s => s.DeviceId == deviceId
                            && s.OrderId == orderId
                            && s.Type == type)
                            .Select(y => new Facility
                            {
                                PropertyName = y.PropertyName,
                                Value = y.Value,
                                PropertyParent = y.PropertyParent,
                                ValueDescription = y.ValueDescription
                            });

                    return facilityList.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderDetailId"></param>
        /// <returns></returns>
        public static string getDescription(int orderDetailId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var orderDetailInfo = context.orderDetailInfoes
                        .Where(s => s.OrderDetailNo == orderDetailId)
                        .First()
                        .ProDes;
                    return orderDetailInfo;
                }
                catch (Exception e)
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// 得到订单详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<orderDetailInfo> getOrderDetail(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var orderDetailInfo = context.orderDetailInfoes
                        .Where(s => s.OrderInfoId == orderId);
                    return orderDetailInfo.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 根据订单ID得到订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static ordersinfo getOrderInfo(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var ordersInfo = context.ordersinfoes
                        .Where(s => s.ordersinfoID == orderId)
                        .First();
                    return ordersInfo;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 根据订单id得到订单详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<OrderInformationData> getOrderInformation(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var orderInfo = context.OrderInformationDatas
                        .Where(s => s.OrderID == orderId);
                    return orderInfo.ToList();

                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }





        //public static List<Facility> getFacility(int orderId, int deviceId)
        //{
        //    using (var context = new AnnonContext())
        //    {
        //        try
        //        {
        //            var facilityList = from x in context.CatalogOrders
        //                               join y in context.CatalogPropertyValues
        //                               on new { K1 = x.PropertyName, K2 = x.Value }
        //                               equals new { K1 = y.PropertyName, K2 = y.Value }
        //                               where x.OrderId == orderId && y.DeviceId == deviceId
        //                               orderby x.SequenceNo
        //                               select new Facility
        //                               {
        //                                   PropertyName = y.PropertyName,
        //                                   Value = y.Value,
        //                                   PropertyParent = y.PropertyParent,
        //                                   ValueDescription = y.ValueDescription,
        //                                   Type=y.Type
        //                               };

        //            return facilityList.ToList();
        //        }
        //        catch (Exception e)
        //        {
        //            return null;
        //        }
        //    }
        //}
        
    }
}
