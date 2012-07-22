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
        public static List<ordersinfo> getOrders(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var ordersinfoes = context.ordersinfoes
                        .Where(s => s.OrderNo == orderId)
                        .ToList();

                    return ordersinfoes;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

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

        public static int InsertIntoOrder(int orderId, int orderNo, string jobNum, string jobName, string jobDes, int site, string customer, string activity, string aaonCon)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    ordersinfo oi = new ordersinfo
                    {
                        OrderNo = orderNo,
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


        public static int DeleteOrder(int orderID)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var ois = context.ordersinfoes
                        .Where(s => s.OrderNo == orderID)
                        .First();
                   context.ordersinfoes.Remove(ois);
                   return context.SaveChanges(); 
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

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

        public static int ModifyOrder(int orderId, int orderNo, string jobNum, string jobName, string jobDes, int site, string customer, string activity, string aaonCon)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var ois = context.ordersinfoes
                        .Where(s => s.OrderNo == orderId)
                        .First();

                    ois.JobNum = jobNum;
                    ois.JobName = jobName;
                    ois.JobDes = jobDes;
                    ois.Site = site;
                    ois.Customer = customer;
                    ois.AAonCon = aaonCon;
                    ois.Activity = activity;
                    ois.ordersinfoID = orderId;
  
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
