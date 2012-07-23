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
        public static int DeleteOrderDetail(int OrderInfoID)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var od = context.orderDetailInfoes
                    .Where(s => s.orderDetailInfoID == OrderInfoID)
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

        //插入详细订单信息;
        public static int InsertOrderDetail(int OrderDInfoID, int OrderID, int OrderNO, string qty, string proDes, string Tag, string LPrice, string RPrince, string CPrice)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    orderDetailInfo od = new orderDetailInfo
                    {
                        orderDetailInfoID = OrderDInfoID,
                        OrderInfoId = OrderID,
                        OrderDetailNo = OrderNO,
                        Qty = qty,
                        tag = Tag,
                        ProDes = proDes,
                        listPrice = LPrice,
                        RepPrice = RPrince,
                        custPrice = CPrice
                    };
                    context.orderDetailInfoes.Add(od);
                    return context.SaveChanges();
                }
                catch (Exception e)
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
                        .Last();

                    orderDetailInfo od2 = new orderDetailInfo
                    {
                        orderDetailInfoID = od1.orderDetailInfoID + 1,
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

        //模拟  插入详细订单信息;
        public static int InsertOD(int OrderID, int OrderDID, string proDes)
        {
            using (var context = new AnnonContext()) 
            {
                try
                {
                    orderDetailInfo od = new orderDetailInfo();

                    od.OrderInfoId = OrderID;
                    od.OrderDetailNo = OrderDID;
                    od.ProDes = proDes;

                    context.orderDetailInfoes.Add(od);
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
