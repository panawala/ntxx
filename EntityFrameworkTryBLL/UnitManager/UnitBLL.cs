using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Zutu.Unit;
using DataContext;
using System.Data;
using Model.Property;
using Model.Xuanxing;

namespace EntityFrameworkTryBLL.UnitManager
{
    public class UnitBLL
    {
        /// <summary>
        /// 返回所有结果
        /// </summary>
        /// <returns></returns>
        public static List<UnitModel> getAllModels(string property)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    return context.UnitModels
                        .Where(s => s.Property == property)
                        .ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 根据订单ID，返回当前已保存的属性值组合，
        /// </summary>
        /// <param name="property"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<UnitModel> getAllModels(string property,int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<UnitModel> rtUnitModels = new List<UnitModel>();
                    var unitModels= context.UnitModels
                        .Where(s => s.Property == property);
                    foreach (var um in unitModels)
                    {
                        um.Default = getValue(um.Property, orderId);
                        rtUnitModels.Add(um);
                    }
                    return rtUnitModels;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 根据订单ID和属性名获得当前选择值
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        private static string getValue(string propertyName, int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var order = context.UnitCurrentValues
                        .Where(s => s.OrderId == orderId
                        && s.PropertyName == propertyName)
                        .First();
                    return order.Value;
                }
                catch (Exception e)
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// 得到受影响属性的所有数据
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<UnitModel> getAllByCondition(string propertyName, int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<UnitModel> rtUnitModels = new List<UnitModel>();
                    //首先得到受影响的属性的名称
                    List<string> influencedPtyNames = getInfluencedPties(propertyName);
                    //遍历受影响的属性
                    foreach (var ifn in influencedPtyNames)
                    {
                        //得到主动属性列表
                        var ptyNames = getPtyNames(ifn);
                        //得到影响当前属性取值的所有的条件的string组合
                        var conditionStrList = generateCondition(ptyNames, orderId);
                        var unitModels = context.UnitModels
                            .Where(s => s.Property == ifn);
                        foreach (var unitModel in unitModels)
                        {
                            if (string.IsNullOrEmpty(unitModel.Condition) || unitModel.Condition.Equals("ALL"))
                            {
                                rtUnitModels.Add(unitModel);
                                continue;
                            }
                            bool flag = false;
                            foreach (var cs in conditionStrList)
                            {
                                if (!unitModel.Condition.Contains(cs))
                                {
                                    flag = true;
                                    break;
                                }
                            }
                            if (!flag)
                            {
                                rtUnitModels.Add(unitModel);
                            }
                        }
                    }
                    return rtUnitModels;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 根据一列属性名得到属性的取值配对
        /// </summary>
        /// <param name="propertyNames"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        private static List<string> generateCondition(List<string> propertyNames, int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<string> ptyValues = new List<string>();
                    foreach (var propertyName in propertyNames)
                    {
                        var unitValue = context.UnitCurrentValues
                        .Where(s => s.OrderId == orderId
                        && s.PropertyName == propertyName)
                        .Select(s => s.Value)
                        .First();
                        string ptyValue = propertyName + ":" + unitValue;
                        //生成字符串类似与“name:value”
                        ptyValues.Add(ptyValue);
                    }
                    return ptyValues;
                }
                catch (Exception e)
                {
                    return null;
                }
            }

        }


        /// <summary>
        /// 根据约束表，查看受一个属性影响的所有的被动属性
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private static List<string> getInfluencedPties(string propertyName)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<string> propertyNames = context.UnitConstraints
                        .Where(s => s.PropertyName == propertyName)
                        .Select(s => s.InfluencedPropertyName)
                        .ToList();
                    return propertyNames;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 根据被动属性，得到主动属性的列表
        /// </summary>
        /// <param name="influencedPropertyName"></param>
        /// <returns></returns>
        private static List<string> getPtyNames(string influencedPropertyName)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<string> propertyNames = context.UnitConstraints
                        .Where(s => s.InfluencedPropertyName == influencedPropertyName)
                        .Select(s => s.PropertyName)
                        .ToList();
                    return propertyNames;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }


        public static int DeleteAll()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var unitModels = context.UnitModels;
                    foreach (var unitModel in unitModels)
                    {
                        context.UnitModels.Remove(unitModel);
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
        /// 从excel导入
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static int InsertFromExcel(DataTable dataTable)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        var unitModel = new UnitModel
                        {
                            Property = dataRow["Property"].ToString(),
                            Value = dataRow["Value"].ToString(),
                            ValueDescription = dataRow["Value"].ToString() + "=" + dataRow["ValueDescription"].ToString(),
                            Condition = dataRow["Condition"].ToString(),
                            Default=dataRow["Default"].ToString(),
                            IsReadOnly = dataRow["IsReadOnly"].ToString()
                        };
                        context.UnitModels.Add(unitModel);
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
        /// 初始化新订单，
        /// </summary>
        /// <returns></returns>
        public static int initialNewOrder()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    int currentOrderId=1;
                    //得到当前orderId
                    var orderId = context.UnitCurrentValues
                        .Select(s => s.OrderId);
                    if (orderId.Count()!=0)
                        currentOrderId = orderId.Max() + 1;

                    var tempUnitModels = context.UnitModels
                        .Select(s => new { PropertyName = s.Property, Default = s.Default })
                        .Distinct();
                    foreach (var unitModel in tempUnitModels)
                    {
                        var orderModel = new UnitCurrentValue
                        {
                            PropertyName=unitModel.PropertyName,
                            Value=unitModel.Default,
                            OrderId = currentOrderId
                        };
                        context.UnitCurrentValues.Add(orderModel);
                    }
                    context.SaveChanges();
                    return currentOrderId;
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 保存订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int saveOrder(int orderId, string propertyName, string value)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var currentUnit = context.UnitCurrentValues
                        .Where(s => s.OrderId == orderId
                        && s.PropertyName == propertyName)
                        .First();
                    currentUnit.Value = value;
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 根据订单编号删除订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static int deleteOrder(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var unitCurrentValues = context.UnitOrders
                        .Where(s => s.OrderId == orderId);
                    if (unitCurrentValues != null && unitCurrentValues.Count() != 0)
                    {
                        foreach (var ucv in unitCurrentValues)
                        {
                            context.UnitOrders.Remove(ucv);
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
        /// 将订单表复制到临时表，编辑时使用
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static int copyOrderToCurrent(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var unitOrders = context.UnitOrders
                        .Where(s => s.OrderId == orderId);
                    foreach (var unitOrder in unitOrders)
                    {
                        context.UnitCurrentValues.Add(new UnitCurrentValue
                        {
                            PropertyName = unitOrder.PropertyName,
                            Value = unitOrder.Value,
                            OrderId = unitOrder.OrderId
                        });
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
        /// 将临时表中的数据复制到订单中
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static int copyCurrentToOrder(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    //先删除已有orderId的订单
                    deleteOrder(orderId);
                    var unitOrders = context.UnitCurrentValues
                        .Where(s => s.OrderId == orderId);
                    //将临时表中的数据复制到订单表中
                    foreach (var unitOrder in unitOrders)
                    {
                        context.UnitOrders.Add(new UnitOrder
                        {
                            PropertyName = unitOrder.PropertyName,
                            Value = unitOrder.Value,
                            OrderId = unitOrder.OrderId,
                        });
                    }
                    ////删除临时表中的数据
                    //foreach (var uo in unitOrders)
                    //{
                    //    context.UnitCurrentValues.Remove(uo);
                    //}
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 拷贝订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static int copyOrder(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    int newOrderId = 1;
                    var currentOrder = context.UnitOrders
                        .Select(s => s.OrderId);
                    if (currentOrder.Count() != 0)
                        newOrderId = currentOrder.Max() + 1;

                    var catlogOrders = context.UnitOrders
                        .Where(s => s.OrderId == orderId);
                    foreach (var catlog in catlogOrders)
                    {
                        context.UnitOrders.Add(new UnitOrder
                        {
                            PropertyName = catlog.PropertyName,
                            OrderId = newOrderId,
                            Value = catlog.Value
                        });
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
        /// 根据订单Id得到订单属性值对
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<CatalogModel> getPropertyModels(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var orderModels = context.UnitOrders
                        .Where(s => s.OrderId == orderId)
                        .Select(s => new CatalogModel
                        {
                            PropertyName = s.PropertyName,
                            Value = s.Value
                        });
                    return orderModels.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }

        }
    }
}
