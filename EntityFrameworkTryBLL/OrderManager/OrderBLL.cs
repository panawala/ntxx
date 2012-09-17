using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Order;
using DataContext;
using Model.OrderInformation;
using Model.Xuanxing;
using Model.Zutu.Unit;
using Model.Zutu.Content;
using Model.Zutu.ImageModel;

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



        /// <summary>
        /// 根据订单ID得到订单详情ID
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<orderDetailInfo> getOrderDetails(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var orderDetailInfos = context.orderDetailInfoes
                        .Where(s => s.OrderInfoId == orderId)
                        .ToList();
                    return orderDetailInfos;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 根据订单详情得到选型list
        /// </summary>
        /// <param name="orderDetailInfo"></param>
        /// <returns></returns>
        public static List<CatalogOrder> getCatalogOrders(List<orderDetailInfo> orderDetailInfo)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<int> orderDetailNos = orderDetailInfo
                        .Select(s => s.OrderDetailNo)
                        .ToList();
                    var catalogOrders = context.CatalogOrders
                        .Where(s => orderDetailNos.Contains(s.OrderId)
                        &&s.DeviceId==1)
                        .ToList();
                    return catalogOrders;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// 根据订单详情列表得到unit窗口数据
        /// </summary>
        /// <param name="orderDetailInfo"></param>
        /// <returns></returns>
        public static List<UnitOrder> getUnitOrders(List<orderDetailInfo> orderDetailInfo)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<int> orderDetailNos = orderDetailInfo
                        .Select(s => s.OrderDetailNo)
                        .ToList();
                    var unitOrders = context.UnitOrders
                        .Where(s => orderDetailNos.Contains(s.OrderId))
                        .ToList();
                    return unitOrders;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 根据订单详情列表得到内容订单
        /// </summary>
        /// <param name="orderDetailInfo"></param>
        /// <returns></returns>
        public static List<ContentOrder> getContentOrders(List<orderDetailInfo> orderDetailInfo)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<int> orderDetailNos = orderDetailInfo
                        .Select(s => s.OrderDetailNo)
                        .ToList();
                    var contentOrders = context.ContentOrders
                        .Where(s => orderDetailNos.Contains(s.OrderID))
                        .ToList();
                    return contentOrders;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 根据订单详情列表得到图块选型数据库
        /// </summary>
        /// <param name="orderDetailInfo"></param>
        /// <returns></returns>
        public static List<ImageModel> getImageModels(List<orderDetailInfo> orderDetailInfo)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<int> orderDetailNos = orderDetailInfo
                        .Select(s => s.OrderDetailNo)
                        .ToList();
                    var imageModels = context.ImageModels
                        .Where(s => orderDetailNos.Contains(s.OrderId))
                        .ToList();
                    return imageModels;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// 根据新订单ID，导入订单详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderDetailInfos"></param>
        /// <returns></returns>
        public static int insertInfoOrderDetail(int orderId, List<orderDetailInfo> orderDetailInfos,List<CatalogOrder> catalogOrders
            ,List<ImageModel> imageModels,List<UnitOrder> unitOrders,List<ContentOrder> contentOrders)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    foreach (var orderDetailInfo in orderDetailInfos)
                    {
                        var oderDetailTemp = orderDetailInfo;
                        oderDetailTemp.OrderInfoId = orderId;
                        //保存之前的orderId
                        int oldOrderId = oderDetailTemp.OrderDetailNo;
                        oderDetailTemp.OrderDetailNo = getNewOrderDetailId(orderDetailInfo.DeviceId);
                        //如果设备为1，插入选型
                        if (oderDetailTemp.DeviceId == 1)
                        {
                            InsertIntoCatalogOrders(oldOrderId, oderDetailTemp.OrderDetailNo, catalogOrders);
                        }
                        //如果设备为2，插入选图
                        else if (oderDetailTemp.DeviceId == 2)
                        {
                            InsertIntoXuantuOrders(oldOrderId, oderDetailTemp.OrderDetailNo, imageModels, unitOrders, contentOrders);
                        }
                       
                        context.orderDetailInfoes.Add(oderDetailTemp);
                    }
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }




        /// <summary>
        /// 根据订单详情得到新的选型或者选图的订单Id
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        private static int getNewOrderDetailId(int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    //如果是选型
                    if (deviceId == 1)
                    {
                        int orderId = 1;
                        var currentOrder = context.CatalogOrders
                            .Select(s => s.OrderId);
                        if (currentOrder.Count() != 0)
                            orderId = currentOrder.Max() + 1;
                        return orderId;
                    }
                    //如果是选图
                    else if (deviceId == 2)
                    {
                        int currentOrderId = 1;
                        //得到当前orderId
                        var orderId = context.UnitOrders
                            .Select(s => s.OrderId);
                        if (orderId.Count() != 0)
                            currentOrderId = orderId.Max() + 1;
                        return currentOrderId;
                    }
                    return 0;
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }


        /// <summary>
        /// 根据新旧ID导入选型数据库
        /// </summary>
        /// <param name="oldOrderId"></param>
        /// <param name="newOrderId"></param>
        /// <param name="catalogOrders"></param>
        /// <returns></returns>
        public static int InsertIntoCatalogOrders(int oldOrderId, int newOrderId, List<CatalogOrder> catalogOrders)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    //筛选出来订单ID等于旧订单ID的订单
                    var newCatalogOrders = catalogOrders
                        .Where(s => s.OrderId == oldOrderId);
                    foreach (var nco in newCatalogOrders)
                    {
                        nco.OrderId = newOrderId;
                        context.CatalogOrders.Add(nco);
                    }
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }

        }

        /// <summary>
        /// 插入选图数据库
        /// </summary>
        /// <param name="oldOrderId"></param>
        /// <param name="newOrderId"></param>
        /// <param name="imageModels"></param>
        /// <param name="unitOrders"></param>
        /// <param name="contentOrders"></param>
        /// <returns></returns>
        public static int InsertIntoXuantuOrders(int oldOrderId, int newOrderId, List<ImageModel> imageModels, List<UnitOrder> unitOrders, List<ContentOrder> contentOrders)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    //筛选出来订单ID等于旧订单ID的订单
                    var newImageModels = imageModels
                        .Where(s => s.OrderId == oldOrderId);
                    foreach (var im in imageModels)
                    {
                        im.OrderId = newOrderId;
                        context.ImageModels.Add(im);
                    }

                    //插入unit数据库
                    var newUnitOrders = unitOrders
                        .Where(s => s.OrderId == oldOrderId);
                    foreach (var nuo in newUnitOrders)
                    {
                        nuo.OrderId = newOrderId;
                        context.UnitOrders.Add(nuo);
                    }

                    //插入内容数据库
                    var newContentOrders = contentOrders
                        .Where(s => s.OrderID == oldOrderId);
                    foreach (var nco in newContentOrders)
                    {
                        nco.OrderID = newOrderId;
                        context.ContentOrders.Add(nco);
                    }

                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
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
