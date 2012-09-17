using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Order;
using DataContext;
using Model.OrderInformation;

namespace EntityFrameworkTryBLL.OrderManager
{
    public class OrderBLL
    {
        //
        public static int ReturnID()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var od = context.ordersinfoes
                        .ToList();
                    return od.Last().ordersinfoID;
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }


        #region 导入导出用
        /// <summary>
        /// 根据订单号得到订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static ordersinfo getOrdersInfo(int orderId)
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
        /// 插入一条订单信息，并且返回其最新orderId
        /// </summary>
        /// <param name="ordersInfo"></param>
        /// <returns></returns>
        public static int ImportIntoOrdersInfo(ordersinfo ordersInfo)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    context.ordersinfoes.Add(ordersInfo);
                    context.SaveChanges();
                    return ordersInfo.ordersinfoID;
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 插入订单信息表，根据新的订单ID
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderInformationData"></param>
        /// <returns></returns>
        public static int ImportOrderInformation(int orderId,OrderInformationData orderInformationData)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var orderInformation = orderInformationData;
                    orderInformation.OrderID = orderId;
                    context.OrderInformationDatas.Add(orderInformation);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }


        /// <summary>
        /// 根据订单ID得到订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static OrderInformationData getOrderInformation(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var orderInformation = context.OrderInformationDatas
                        .Where(s => s.OrderID == orderId)
                        .First();
                    return orderInformation;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }









        #endregion



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
                    //if (ord.OrderNo > 0)
                        ord.OrderNo--;
                    //else
                    //{
                    //    ord.OrderNo = 1;
                    //}
                }

                return context.SaveChanges();
            }
            catch (System.Exception ex)
            {

                return 0;
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
                    //if (od.Count() > 0)
                        return od[od.Count - 1].OrderNo;
                    //else
                    //    return 1;
                }
                catch (System.Exception ex)
                {
                    return 0;
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
        //返回第一天订单ID
        public static int ReturnFirstID()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var od = context.ordersinfoes
                        .ToList();
                    
                    return od[0].ordersinfoID;
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
