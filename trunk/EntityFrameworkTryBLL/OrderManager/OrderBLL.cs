using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Order;
using DataContext;

namespace EntityFrameworkTryBLL.OrderManager
{
    public class OrderBLL
    {
        //获取某一个订单数据;
        public static List<ordersinfo> getOrders(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var ordersinfoes = context.ordersinfoes
                        .Where(s => s.ordersinfoID == orderId)
                        .ToList();

                    return ordersinfoes;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        //得到所有的订单数据;
        public static List<ordersinfo> GetAllOrder()
        {
            using (var context =new AnnonContext())
            {
                try
                {
                    var ordersinfoes = context.ordersinfoes
                          .ToList();

                    return ordersinfoes;

                    
       
                }
                catch (System.Exception ex)
                {
                    return null;
                }
            }
        }

        //插入订单数据;
        public static int InsertIntoOrder(int orderId,int OrderNO, string jobNum, string jobName, string jobDes, int site, string customer, string activity, string aaonCon)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    ordersinfo oi = new ordersinfo
                    {
                        OrderNo=OrderNO,
                        JobNum = jobNum,
                        JobName = jobName,
                        JobDes = jobDes,
                        Site = site,
                        Customer = customer,
                        Activity = activity,
                        AAonCon = aaonCon,
                     ordersinfoID = orderId
                    };
                    context.ordersinfoes.Add(oi);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        //删除订单信息;
        public static int DeleteOrder(int orderID)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var ois = context.ordersinfoes
                        .Where(s => s.ordersinfoID == orderID)
                        .ToList();
                   context.ordersinfoes.Remove(ois.First());
                   return context.SaveChanges(); 
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        //删除所有订单数据;
        public static int DeleteAllOrder()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var ois = context.ordersinfoes;

                    foreach (var os in ois)
                    {
                        context.ordersinfoes.Remove(os);
                    }
                    //context.ordersinfoes.Remove(ois);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        //复制一条订单;
        public static int CopyOrder(int orderID)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var ois = context.ordersinfoes
                        .Where(s => s.ordersinfoID == orderID)
                        .First();

                    ordersinfo oi = new ordersinfo
                    {
                        OrderNo=ois.OrderNo,
                        JobNum = ois.JobNum,
                        JobName = ois.JobName,
                        JobDes = ois.JobDes,
                        Site = ois.Site,
                        Customer = ois.Customer,
                        Activity = ois.Activity,
                        AAonCon = ois.AAonCon,
                        ordersinfoID = ois.ordersinfoID+1
                    };
                    context.ordersinfoes.Add(oi);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }
        //修改订单信息;
        public static int ModifyOrder(int orderId, int OrderNo,string jobNum, string jobName, string jobDes, int site, string customer, string activity, string aaonCon)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var ois = context.ordersinfoes
                        .Where(s => s.ordersinfoID == orderId)
                        .First();
                    
                    ois.JobNum = jobNum;
                    ois.JobName = jobName;
                    ois.JobDes = jobDes;
                    ois.Site = site;
                    ois.Customer = customer;
                    ois.AAonCon = aaonCon;
                    ois.Activity = activity;
  
                    return context.SaveChanges();
                   
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

    }
}
