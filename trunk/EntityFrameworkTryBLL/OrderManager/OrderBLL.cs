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
        //查找订单数据;

        public static List<ordersinfo> FindOrderByJobName(string ss)
        {
            using (var context = new AnnonContext())
            {
            try
            {
                var od = context.ordersinfoes
                    .Where(s=>s.JobName==ss)
                    .ToList();
                return od;
            }
            catch (System.Exception ex)
            {
                return null;
            }
            }
        }

        public static List<ordersinfo> FindOrderByJobNumber(string ss)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var od = context.ordersinfoes
                        .Where(s => s.JobNum == ss)
                        .ToList();
                    return od;
                }
                catch (System.Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<ordersinfo> FindOrderByDescription(string ss)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var od = context.ordersinfoes
                        .Where(s => s.JobDes == ss)
                        .ToList();
                    return od;
                }
                catch (System.Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<ordersinfo> FindOrderByAAon(string ss)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var od = context.ordersinfoes
                        .Where(s => s.AAonCon == ss)
                        .ToList();
                    return od;
                }
                catch (System.Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<ordersinfo> FindOrderByCustName(string ss)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var od = context.ordersinfoes
                        .Where(s => s.Customer == ss)
                        .ToList();
                    return od;
                }
                catch (System.Exception ex)
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

        //修改订单的排列序号；
        public static int ModifyNum(int OrderID)
        {
            using (var context = new AnnonContext())
            {
            try
            {
                var od = context.ordersinfoes
                    .Where(s => s.ordersinfoID > OrderID)
                    .ToList();
                    
                foreach (var ord in od)
                {
                    ord.OrderNo--;
                }

                return context.SaveChanges();
            }
            catch (System.Exception ex)
            {

                return -1;
            }
            }
        }

        //返回最后条订单序号;
        public static int ReturnLastNum()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var od = context.ordersinfoes
                        .ToList();

                    return od[od.Count - 1].OrderNo;
                }
                catch (System.Exception ex)
                {
                    return -1;
                }
            }
        }
        //返回最后一条订单ID
        public static int ReturnLastID()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var od = context.ordersinfoes
                        .ToList();
                    return od[od.Count - 1].ordersinfoID;

                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }
        //插入订单数据;
        public static int InsertIntoOrder(int OrderNO, string jobNum, string jobName, string jobDes, int site, string customer, string activity, string aaonCon)
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
                        OrderNo=ReturnLastNum()+1,
                        JobNum = ois.JobNum,
                        JobName = ois.JobName,
                        JobDes = ois.JobDes,
                        Site = ois.Site,
                        Customer = ois.Customer,
                        Activity = ois.Activity,
                        AAonCon = ois.AAonCon,
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
