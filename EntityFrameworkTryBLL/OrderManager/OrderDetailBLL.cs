using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Order;
using DataContext;
using EntityFrameworkTryBLL.ZutuManager;
using EntityFrameworkTryBLL.XuanxingManager;
using EntityFrameworkTryBLL.UnitManager;
using Model.Device;

namespace EntityFrameworkTryBLL.OrderManager
{
   public class OrderDetailBLL
    {

       /// <summary>
       /// 根据订单ID得到订单详情
       /// </summary>
       /// <param name="orderInfoId"></param>
       /// <returns></returns>
       public static orderDetailInfo getOrderDetailById(int orderInfoId)
       {
           using (var context = new AnnonContext())
           {
               try
               {
                   var orderDetail = context.orderDetailInfoes
                       .Where(s => s.orderDetailInfoID == orderInfoId)
                       .First();
                   return orderDetail;
               }
               catch (Exception e)
               {
                   return null;
               }
           }
       }



        //获取一个订单下的所有OrderDetail信息;
       public static List<orderDetailInfo> GetOrderDetail(int OrderInfoID)
       {
           using (var context = new AnnonContext())
           {
               try
               {
                   var od = context.orderDetailInfoes
                       .Where(s => s.OrderInfoId == OrderInfoID)
                       .ToList();

                   return od;
               }
               catch (Exception e)
               {
                   return null;
               }
           }
       }

       /// <summary>
       /// 获取所有附件,deviceID=8
       /// </summary>
       /// <param name="OrderInfoID"></param>
       /// <returns></returns>
       public static List<AccessoryOrder> GetAccessoryDetail(int OrderInfoID)
       {
           using (var context = new AnnonContext())
           {
               try
               {
                   var orderDetails = context.orderDetailInfoes
                       .Where(s => s.OrderInfoId == OrderInfoID
                       &&s.DeviceId==8);
                   List<AccessoryOrder> accessoryOrders = new List<AccessoryOrder>();
                   foreach (var orderDetail in orderDetails)
                   {
                       accessoryOrders.Add(new AccessoryOrder
                       {
                           OrderId = orderDetail.OrderInfoId,
                           PartNo = "partno",
                           PartDescription = orderDetail.ProDes,
                           ListPrice = Convert.ToDecimal(orderDetail.listPrice)/Convert.ToInt32(orderDetail.Qty),
                           Quantity = Convert.ToInt32(orderDetail.Qty),
                           Price = Convert.ToDecimal(orderDetail.listPrice)
                       });
                   }

                   return accessoryOrders;
               }
               catch (Exception e)
               {
                   return null;
               }
           }
       }


        //获取所有订单下的所有OrderDetail信息;
        public static List<orderDetailInfo> GetAllOrderDetail()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var od = context.orderDetailInfoes
                        .ToList();

                    return od;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

       //获取Oder相关的deviceID
        public static List<orderDetailInfo> GetOrderDtlDeviceID(int OrderID,int DeviceID)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var OdDtl = context.orderDetailInfoes
                        .Where(s => s.DeviceId == DeviceID&&s.OrderInfoId==OrderID)
                        .ToList();
                    return OdDtl;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        //删除一条订单详细信息;
        public static int DeleteOrderDetail(int OrderDalInfoID)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var od = context.orderDetailInfoes
                    .Where(s => s.orderDetailInfoID == OrderDalInfoID)
                    .First();

                    context.orderDetailInfoes.Remove(od);
                    return context.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    return -1;
                }
            }
        }
        //删除所有详细订单信息;
        public static int DeleteAllOrderDetail()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var od = context.orderDetailInfoes;

                    foreach (var odd in od)
                    {
                        context.orderDetailInfoes.Remove(odd);
                    }
                    return context.SaveChanges();

                }
                catch (System.Exception ex)
                {
                    return -1;
                }
            }
        }

        //删除某一条订单下的所有订单详情；
        public static int DeleteOneOrderAllDetail(int OrderID)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var od = context.orderDetailInfoes
                        .Where(s => s.OrderInfoId == OrderID)
                        .ToList();

                    foreach (var ord in od)
                    {
                        context.orderDetailInfoes.Remove(ord);
                    }

                    return context.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    return -1;
                }
            }
        }

        //每一个订单详情的Num都减1
        public static int ModifyNum(int OrderDtlID)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var od = context.orderDetailInfoes
                        .Where(s => s.orderDetailInfoID >= OrderDtlID)
                        .ToList();

                    foreach (var odd in od)
                    {
                        odd.OdDetlNum--;
                    }
                    return context.SaveChanges();
                }
                catch (Exception E)
                {
                    return 0;
                }
            }
        }
        //修改详细订单信息;
        public static int EditOrderDetail(int OrderDInfoID, int OrderID, int OrderNO, string qty, string proDes, string Tag, string LPrice, string RPrince, string CPrice)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var od = context.orderDetailInfoes
                        .Where(s => s.orderDetailInfoID == OrderDInfoID)
                        .First();
                    od.ProDes = proDes;
                    od.Qty = qty;
                    od.tag = Tag;
                    od.listPrice = LPrice;
                    od.RepPrice = RPrince;
                    od.custPrice = CPrice;

                    return context.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    return -1;
                }
            }
        }
        //复制一条订单下的所有订单详情
        //public static int CopyOrderAllOrderDtl(int OrderID)
        //{
        //    using (var context = new AnnonContext())
        //    {
        //        try
        //        {
        //            var OdDtl = context.orderDetailInfoes
        //                .Where(s => s.OrderInfoId == OrderID)
        //                .ToList();
                    
        //            foreach(var LL in OdDtl)
        //            {
        //                orderDetailInfo od = new orderDetailInfo 
        //                { 
        //                    listPrice=LL.listPrice,
        //                    custPrice=LL.custPrice,
        //                    OrderInfoType=LL.OrderInfoType,
        //                    ProDes=LL.ProDes,
        //                    Qty=LL.Qty,
        //                    RepPrice=LL.RepPrice,
        //                    tag=LL.tag,
        //                    OrderDetailNo
        //                };
        //            }
        //            return context.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            return -1;
        //        }
        //    }
        //}

        //返回最后一个订单ID
        public static int ReturnLastNum()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var odDtl = context.orderDetailInfoes
                        .ToList();
                    return odDtl.Last().OdDetlNum;
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
        }
        //复制详细订单信息;
        public static int CopyOrderDetail(int OrderDtIfID,int newOrderID)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var od1 = context.orderDetailInfoes
                        .Where(s => s.orderDetailInfoID == OrderDtIfID)
                        .First();

                    orderDetailInfo od2 = new orderDetailInfo
                    {
                        OrderInfoId = od1.OrderInfoId,
                        OrderDetailNo = newOrderID,
                        Qty = od1.Qty,
                        custPrice = od1.custPrice,
                        listPrice = od1.listPrice,
                        RepPrice = od1.RepPrice,
                        tag = od1.tag,
                        ProDes = od1.ProDes,
                        OrderInfoType=od1.OrderInfoType,
                        OdDetlNum=ReturnLastNum()+1,
                        DeviceId=od1.DeviceId
                    };

                    context.orderDetailInfoes.Add(od2);
                    return context.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    return -1;
                }
            }
        }

        //插入详细订单信息;
        public static int InsertOD(int OrderNum,int OrderID, int OrderDID, string proDes,int DeviceDtlID,int type=2)
        {
            using (var context = new AnnonContext()) 
            {
                try
                {
                    var od1 = context.orderDetailInfoes
                        .Where(s=>s.OrderDetailNo==OrderDID);
                        
                    if(od1!=null&&od1.Count()!=0)
                    {
                        od1.First().ProDes = proDes;
                    }
                    else
                    {
                        orderDetailInfo od = new orderDetailInfo();

                        od.OrderInfoId = OrderID;
                        od.OrderDetailNo = OrderDID;
                        od.OdDetlNum = OrderNum;
                        od.ProDes = proDes;
                        od.OrderInfoType = type;
                        od.DeviceId = DeviceDtlID;

                        context.orderDetailInfoes.Add(od);
                    }
                    return context.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    return -1;
                }
            }
        }
        //插入详细订单信息;
       /// <summary>
       ///插入订单详情
       /// </summary>
       /// <param name="OrderNum">订单排序号，废弃</param>
       /// <param name="OrderID">对应订单ID</param>
       /// <param name="OrderDID">对应组图和选型的ID</param>
       /// <param name="proDes">详情描述</param>
       /// <param name="qty">详情数量</param>
        /// <param name="type">对应的订单详情类型，//1的时候选型，2的时候选图，8的时候附件</param>
       /// <param name="DeviceID">对应的设备类型ID,8为附件</param>
       /// <returns></returns>
        public static int InsertOD1(int OrderNum, int OrderID, int OrderDID, string proDes, string qty, int type, int DeviceID,decimal listprice=0)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    orderDetailInfo od = new orderDetailInfo();

                    od.OrderInfoId = OrderID;
                    od.OrderDetailNo = OrderDID;
                    od.ProDes = proDes;
                    od.OdDetlNum = OrderNum;
                    od.Qty = qty;
                    od.OrderInfoType = type;
                    od.DeviceId = DeviceID;

                    od.listPrice = (listprice*Convert.ToInt32(qty)).ToString();
                    od.RepPrice = (listprice * Convert.ToInt32(qty)).ToString();
                    od.custPrice = (listprice * Convert.ToInt32(qty)).ToString();
          

                    context.orderDetailInfoes.Add(od);
                    return context.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    return -1;
                }
            }
        }


       /// <summary>
       /// 更新价格
       /// </summary>
       /// <param name="orderId"></param>
       /// <param name="listPrice"></param>
       /// <param name="rep"></param>
       /// <returns></returns>
        public static int updateOD(int orderId, decimal listPrice, double rep)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var orderDetail = context.orderDetailInfoes
                        .Where(s => s.OrderDetailNo == orderId)
                        .First();
                    orderDetail.listPrice = (listPrice*Convert.ToInt32(orderDetail.Qty)).ToString();
                    orderDetail.RepPrice = (Convert.ToDouble(listPrice) * Convert.ToInt32(orderDetail.Qty)*rep).ToString();
                    orderDetail.custPrice = orderDetail.RepPrice;
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

       /// <summary>
       /// 得到订单的总价总价
       /// </summary>
       /// <param name="orderId"></param>
       /// <returns></returns>
        public static decimal getTotalPrice(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var totalPrice = context.CatalogCurrentValues
                        .Where(s => s.OrderId == orderId)
                        .Sum(s => s.Price);
                    return totalPrice;
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
        }

        //修改详细订单信息;
        public static int EditOD(int OrderID, int OrderDInfoID, string proDes, string qty,string tag)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var od = context.orderDetailInfoes
                        .Where(s => s.orderDetailInfoID == OrderDInfoID)
                        .First();
                    od.ProDes = proDes;
                    od.Qty = qty;
                    od.tag = tag;
                    //od.listPrice = LPrice;
                    //od.RepPrice = RPrince;
                    //od.custPrice = CPrice;

                    return context.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    return -1;
                }
            }
        }

        //修改详细订单信息;
        public static int EditOD(int OrderID, int OrderDInfoID, string proDes, string qty)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var od = context.orderDetailInfoes
                        .Where(s => s.orderDetailInfoID == OrderDInfoID)
                        .First();
                    od.ProDes = proDes;
                    od.Qty = qty;
                    //od.tag = Tag;
                    //od.listPrice = LPrice;
                    //od.RepPrice = RPrince;
                    //od.custPrice = CPrice;

                    return context.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    return -1;
                }
            }
        }
    }
}
