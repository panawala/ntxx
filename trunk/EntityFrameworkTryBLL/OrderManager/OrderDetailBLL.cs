using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Order;
using DataContext;

namespace EntityFrameworkTryBLL.OrderManager
{
   public class OrderDetailBLL
    {

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

        //复制详细订单信息;
        public static int CopyOrderDetail(int OrderDtIfID)
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
                        OrderDetailNo = od1.OrderDetailNo + 1,
                        Qty = od1.Qty,
                        custPrice = od1.custPrice,
                        listPrice = od1.listPrice,
                        RepPrice = od1.RepPrice,
                        tag = od1.tag,
                        ProDes = od1.ProDes
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
        public static int InsertOD(int OrderID, int OrderDID, string proDes,int type=2)
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
                        od.ProDes = proDes;
                        od.OrderInfoType = type;

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
        public static int InsertOD1(int OrderID, int OrderDID, string proDes,string qty,int type)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    orderDetailInfo od = new orderDetailInfo();

                    od.OrderInfoId = OrderID;
                    od.OrderDetailNo = OrderDID;
                    od.ProDes = proDes;
                    od.Qty = qty;
                    od.OrderInfoType = type;

                    context.orderDetailInfoes.Add(od);
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
