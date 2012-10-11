using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataContext;
using Model.Device;
using System.Data;
using EntityFrameworkTryBLL.OrderManager;

namespace EntityFrameworkTryBLL.XuanxingManager
{
    public class AccessoryBLL
    {
        /// <summary>
        /// 插入一条附件记录
        /// </summary>
        /// <param name="accessory"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public static int insertIntoAccessoryOrder(Accessory accessory,int quantity)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var accessoryOrder = new AccessoryOrder
                    {
                        Quantity = quantity,
                        PartNo = accessory.PartNo,
                        PartDescription = accessory.PartDescription,
                        ListPrice=accessory.ListPrice,
                        Price = accessory.ListPrice * quantity
                    };
                    context.AccessoryOrders.Add(accessoryOrder);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        public static int InsertUnitConstraintFromExcel(DataTable dataTable)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        var accessory = new Accessory
                        {
                            Unit = dataRow["Unit"].ToString(),
                            PartNo = dataRow["PartNo"].ToString(),
                            PartDescription = dataRow["PartDescription"].ToString(),
                            Model = dataRow["Model"].ToString(),
                            Heat = dataRow["Heat"].ToString(),
                            Cool = dataRow["Cool"].ToString(),
                            SystemSwitching = dataRow["SystemSwitching"].ToString(),
                            FanSwitching = dataRow["FanSwitching"].ToString(),
                            Application = dataRow["Application"].ToString(),
                            ChangeOver = dataRow["ChangeOver"].ToString(),
                            Use = dataRow["Use"].ToString(),
                            ListPrice = Convert.ToDecimal(dataRow["ListPrice"].ToString()),
                            Type = dataRow["Type"].ToString()

                        };
                        context.Accessories.Add(accessory);
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
        /// 删除所有数据
        /// </summary>
        /// <returns></returns>
        public static int deleteAll()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var accessories = context.Accessories;
                    if (accessories != null && accessories.Count() != 0)
                    {
                        foreach (var accessory in accessories)
                        {
                            context.Accessories.Remove(accessory);
                        }
                        return context.SaveChanges();
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
        /// 插入附件订单
        /// </summary>
        /// <param name="aaonPart"></param>
        /// <param name="description"></param>
        /// <param name="quantity"></param>
        /// <param name="listPrice"></param>
        /// <returns></returns>
        public static int insertIntoAccessoryOrder(int orderId,string aaonPart, string description, int quantity, decimal listPrice)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var accessoryOrder = new AccessoryOrder
                    {
                        OrderId=orderId,
                        Quantity = quantity,
                        PartNo = aaonPart,
                        PartDescription = description,
                        ListPrice=listPrice,
                        Price = quantity * listPrice
                    };
                    context.AccessoryOrders.Add(accessoryOrder);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }


        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="accessoryOrderId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public static int modifyOrder(int accessoryOrderId, int quantity)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var accessoryOrder = context.AccessoryOrders
                        .Where(s => s.AccessoryOrderID == accessoryOrderId)
                        .First();
                    accessoryOrder.Quantity = quantity;
                    accessoryOrder.Price = quantity * accessoryOrder.ListPrice;
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 删除制定订单
        /// </summary>
        /// <param name="accessoryId"></param>
        /// <returns></returns>
        public static int deleteOrder(int accessoryId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var accessoryOrder = context.AccessoryOrders
                        .Where(s => s.AccessoryOrderID == accessoryId)
                        .First();
                    context.AccessoryOrders.Remove(accessoryOrder);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 得到制定订单的所有附件
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<AccessoryOrder> getAccessoryOrders(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var accessoryOrders = context.AccessoryOrders
                        .Where(s => s.OrderId == orderId);
                    return accessoryOrders.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// 根据类型得到所有的附件
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<Accessory> getAccessories(string type)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var accessories = context.Accessories
                        .Where(s => s.Type.Equals(type));
                    return accessories.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 将附件订单插入订单详情中
        /// </summary>
        /// <param name="accessoryOrders">附件订单列表</param>
        /// <param name="orderDetailId">订单详情Id</param>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public static int insertAccessories(List<AccessoryOrder> accessoryOrders,int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var taccessoryOrders = accessoryOrders
                        .Where(s => s.OrderId == orderId);
                    foreach (var accessoryOrder in taccessoryOrders)
                    {
                        OrderDetailBLL.InsertOD1(0, orderId,accessoryOrder.OrderId, accessoryOrder.PartDescription, accessoryOrder.Quantity.ToString(), 8, 8,accessoryOrder.ListPrice);
                    }
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
