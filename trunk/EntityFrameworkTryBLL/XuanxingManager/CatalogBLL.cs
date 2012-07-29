using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Xuanxing;
using DataContext;

namespace EntityFrameworkTryBLL.XuanxingManager
{
    public class CatalogBLL
    {
        /// <summary>
        /// 选中属性时，得到右边的列表
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="orderId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static List<CatalogPropertyValue> getAvaliableOptions(string propertyName, int orderId, int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<CatalogPropertyValue> rtCataModels = new List<CatalogPropertyValue>();
                    //得到影响当前属性的的所有主动属性;
                    List<string> ptyNames = getPtyNames(propertyName, deviceId);
                    //得到相应主动属性列表的取值的组合;
                    List<string> conditionStrList = generateCondition(ptyNames, orderId, deviceId);
                    
                    //遍历当前属性的所有值;
                    var catCurrentValues = context.CatalogPropertyValues
                        .Where(s => s.DeviceId == deviceId
                        && s.PropertyName == propertyName);
                    foreach (var catModel in catCurrentValues)
                    {
                        if (string.IsNullOrEmpty(catModel.Condition) || catModel.Condition.Equals("ALL"))
                        {
                            rtCataModels.Add(catModel);
                            continue;
                        }
                        bool flag = false;
                        foreach (var cs in conditionStrList)
                        {
                            if (!catModel.Condition.Contains(cs))
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            rtCataModels.Add(catModel);
                        }
                    }
                    return rtCataModels;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 递归遍历得到结果
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="orderId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static List<CatalogModel> getAllByCondition(string propertyName, int orderId, int deviceId)
        {
            var catalogModels = getAllByCon(propertyName, orderId, deviceId);
            if (catalogModels == null)
                return null;
            DSF dsf = new DSF();
            dsf.Traverse(catalogModels,orderId,deviceId);
            return dsf.savecatalogModel;
        }

        /// <summary>
        /// 根据属性名得到直接的变红的属性;
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<CatalogModel> getAllByCon(string propertyName, int orderId, int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<CatalogModel> rtcatalogModels = new List<CatalogModel>();
                    List<CatalogModel> catalogModels = new List<CatalogModel>();
                    //首先得到受影响的属性的名称;
                    List<string> influencedPtyNames = getInfluencedPties(propertyName,deviceId);
                    if (influencedPtyNames.Count == 0)
                        return null;
                    //遍历受影响的属性;
                    foreach (var ifn in influencedPtyNames)
                    {
                        //得到影响该属性的主动属性列表;
                        var ptyNames = getPtyNames(ifn,deviceId);
                        //得到影响当前属性取值的所有的条件的string组合;
                        var conditionStrList = generateCondition(ptyNames, orderId,deviceId);
                        var catPtyModels = context.CatalogPropertyValues
                            .Where(s => s.PropertyName == ifn
                            && s.DeviceId == deviceId);
                        //遍历该属性的值列表，;
                        foreach (var catModel in catPtyModels)
                        {
                            if (string.IsNullOrEmpty(catModel.Condition) || catModel.Condition.Equals("ALL"))
                            {
                                catalogModels.Add(new CatalogModel
                                {
                                    PropertyName = catModel.PropertyName,
                                    Value = catModel.Value,
                                    Type=catModel.Type,
                                    SequenceNo=catModel.SequenceNo
                                });
                                continue;
                            }

                            string[] conList = catModel.Condition.Split(';');
                            for (int i = 0; i < conList.Length; i++)
                            {
                                conList[i] = conList[i].Substring(0, conList[i].LastIndexOf(':'));
                            }
                            bool flag = false;
                            foreach (var cs in conditionStrList)
                            {
                                if (!conList.Contains(cs.Substring(0, cs.LastIndexOf(':'))))
                                {
                                    continue;
                                }

                                if (!catModel.Condition.Contains(cs))
                                {
                                    flag = true;
                                    break;
                                }
                            }
                            if (!flag)
                            {
                                catalogModels.Add(new CatalogModel
                                {
                                    PropertyName = catModel.PropertyName,
                                    Value = catModel.Value,
                                    SequenceNo=catModel.SequenceNo,
                                    Type=catModel.Type
                                });
                            }
                        }

                        //如果当前值不在其中，更改订单中的当前值;
                        var currentValue = context.CatalogCurrentValues
                        .Where(s => s.PropertyName == ifn
                        && s.OrderId == orderId
                        && s.DeviceId == deviceId)
                        .First();
                        //如果当前取值不满足。则修改订单;
                        if (!catalogModels
                            .Where(s => s.PropertyName == ifn)
                            .Select(s => s.Value).Contains(currentValue.Value))
                        {
                            currentValue.Value = catalogModels.Where(s=>s.PropertyName==ifn).First().Value;
                            context.SaveChanges();
                            rtcatalogModels.Add(new CatalogModel
                            {
                                PropertyName=ifn,
                                Value=currentValue.Value,
                                SequenceNo=currentValue.SequenceNo,
                                Type=currentValue.Type
                            });
                        }
                        
                    }
                    return rtcatalogModels;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
       
        /// <summary>
        /// 保存订单;
        /// </summary>
        /// <param name="catalogModels"></param>
        /// <param name="orderId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        private static int saveOrder(List<CatalogModel> catalogModels, int orderId,int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    foreach (var catModel in catalogModels)
                    {
                        var currentValue = context.CatalogCurrentValues
                            .Where(s => s.DeviceId == deviceId
                            && s.PropertyName == catModel.PropertyName
                            && s.OrderId == orderId)
                            .First();
                        currentValue.Value = catModel.Value;
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
        /// 得到当前取值的组合;
        /// </summary>
        /// <param name="propertyNames"></param>
        /// <param name="orderId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        private static List<string> generateCondition(List<string> propertyNames, int orderId, int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<string> rtOptions = new List<string>();
                    foreach (var ptyName in propertyNames)
                    {
                        var catValue = context.CatalogCurrentValues
                            .Where(s => s.OrderId == orderId
                            && s.DeviceId == deviceId
                            && s.PropertyName == ptyName)
                            .Select(s => s.Value)
                            .First();
                        string ptyValue = ptyName + ":" + catValue;
                        rtOptions.Add(ptyValue);
                    }
                    return rtOptions;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// 根据被动属性名得到主动属性名;
        /// </summary>
        /// <param name="influencedPtyName"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        private static List<string> getPtyNames(string influencedPtyName, int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var ptyNames = context.CatalogConstraints
                        .Where(s => s.DeviceId == deviceId
                        && s.InfluencedPropertyName == influencedPtyName)
                        .Select(s => s.PropertyName)
                        .ToList();
                    return ptyNames;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 得到约束中的被动属性列表;
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        private static List<string> getInfluencedPties(string propertyName, int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var ips = context.CatalogConstraints
                        .Where(s => s.DeviceId == deviceId
                        && s.PropertyName == propertyName)
                        .Select(s => s.InfluencedPropertyName)
                        .ToList();
                    return ips;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 根据设备ID，初始化临时订单表
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static int initialOrder(int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    int orderId=1;
                    var currentOrder = context.CatalogCurrentValues
                        .Select(s => s.OrderId);
                    if (currentOrder.Count() != 0)
                        orderId = currentOrder.Max() + 1;

                    var catPtyValues = context.CatalogPropertyValues
                        .Where(s => s.DeviceId == deviceId)
                        .Select(s => new 
                        { 
                            PropertyName = s.PropertyName, 
                            Default = s.Default,
                            SequenceNo=s.SequenceNo,
                            Type=s.Type
                        })
                        .Distinct();
                    foreach (var catptyVal in catPtyValues)
                    {
                        context.CatalogCurrentValues.Add(new CatalogCurrentValue
                        {
                            PropertyName=catptyVal.PropertyName,
                            Value=catptyVal.Default,
                            DeviceId=deviceId,
                            OrderId=orderId,
                            SequenceNo=catptyVal.SequenceNo,
                            Type=catptyVal.Type
                        });
                    }
                    context.SaveChanges();
                    return orderId;
                }
                catch (Exception e)
                { 
                    return -1;
                }
            }
        }

        /// <summary>
        /// 根据订单号得到初始化label的值;
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<CatalogModel> getInitialLabels(int deviceId, int orderId)
         {
            using (var context = new AnnonContext())
            {
                try
                {
                    var currentValues = context.CatalogCurrentValues
                        .Where(s => s.DeviceId == deviceId
                        && s.OrderId == orderId)
                        .Select(s => new CatalogModel
                        {
                            PropertyName = s.PropertyName,
                            Value = s.Value,
                            SequenceNo=s.SequenceNo,
                            Type=s.Type
                        })
                        .OrderBy(s=>s.SequenceNo);
                    return currentValues.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 根据设备ID,得到所有属性
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static List<CatalogProperty> getProperties(int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var catPties = context.CatalogPropertyValues
                        .Where(s => s.DeviceId == deviceId)
                        .Select(s => new CatalogProperty
                        {
                            CatalogName = s.PropertyParent,
                            PropertyName = s.PropertyName,
                            SequenceNo=s.SequenceNo
                        })
                        .Distinct()
                        .OrderBy(s => s.SequenceNo)
                        .ToList();
                    return catPties;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        
        /// <summary>
        /// 根据设备ID和类型，得到属性列表
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<CatalogProperty> getProperties(int deviceId,string type)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var catPties = context.CatalogPropertyValues
                        .Where(s => s.DeviceId == deviceId
                        &&s.Type==type)
                        .Select(s => new CatalogProperty
                        {
                            CatalogName = s.PropertyParent,
                            PropertyName = s.PropertyName,
                            SequenceNo=s.SequenceNo
                        })
                        .Distinct()
                        .OrderBy(s => s.SequenceNo)
                        .ToList();
                    return catPties;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 保存单个订单
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="orderId"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int saveOrder(int deviceId, int orderId, string propertyName, string value)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var currentValue = context.CatalogCurrentValues
                        .Where(s => s.DeviceId==deviceId
                        && s.OrderId == orderId
                        && s.PropertyName == propertyName)
                        .First();
                    currentValue.Value = value;
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 将订单表复制到临时表
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static int copyOrderToCurrent(int orderId, int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    //先删除临时表数据
                    deleteCurrentValues(deviceId,orderId);
                    var orderList = context.CatalogOrders
                        .Where(s => s.OrderId == orderId
                        && s.DeviceId == deviceId);
                    if (orderList != null && orderList.Count() != 0)
                    {
                        foreach (var order in orderList)
                        {
                            context.CatalogCurrentValues.Add(new CatalogCurrentValue
                            {
                                PropertyName = order.PropertyName,
                                Value = order.Value,
                                DeviceId = order.DeviceId,
                                OrderId = order.OrderId,
                                SequenceNo=order.SequenceNo,
                                Type=order.Type
                            });
                            context.CatalogOrders.Remove(order);
                        }
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
        /// 根据订单id，删除临时表
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        private static int deleteCurrentValues(int deviceId, int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var currentValues = context.CatalogCurrentValues
                        .Where(s => s.DeviceId == deviceId
                        && s.OrderId == orderId);
                    foreach (var cv in currentValues)
                    {
                        context.CatalogCurrentValues.Remove(cv);
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
        /// 复制临时表到订单表
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static int copyCurrentToOrder(int orderId, int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    deleteOrder(orderId);
                    var currentValues = context.CatalogCurrentValues
                        .Where(s => s.OrderId == orderId
                        && s.DeviceId == deviceId);
                    foreach (var currentValue in currentValues)
                    {
                        context.CatalogOrders.Add(new CatalogOrder
                        {
                            PropertyName=currentValue.PropertyName,
                            OrderId=currentValue.OrderId,
                            DeviceId=currentValue.DeviceId,
                            Value=currentValue.Value,
                            SequenceNo=currentValue.SequenceNo,
                            Type=currentValue.Type
                        });
                    }
                    //foreach (var currentValue in currentValues)
                    //{
                    //    context.CatalogCurrentValues.Remove(currentValue);
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
        /// 判断约束冲突
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="firstProperty"></param>
        /// <param name="secondProperty"></param>
        /// <returns></returns>
        public static string testConstraint(int deviceId, string firstProperty, string secondProperty)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    string rtStr = string.Empty;
                    var firstConstraints = context.CatalogPropertyValues
                        .Where(s => s.DeviceId == deviceId
                        && s.PropertyName == firstProperty
                        && s.Condition != null
                        && s.Condition != "ALL")
                        .ToList();
                    var secondConstraints = context.CatalogPropertyValues
                        .Where(s => s.DeviceId == deviceId
                        && s.PropertyName == secondProperty
                        && s.Condition != null
                        && s.Condition != "ALL")
                        .ToList();
                    foreach (var firstConstraint in firstConstraints)
                    {
                        string condition = firstConstraint.Condition;
                        string conStr=firstConstraint.PropertyName+":"+firstConstraint.Value;
                        var tempConstraints=secondConstraints.AsEnumerable().Where(s=>s.Condition.Split(';').Contains(conStr)).ToList();
                        foreach (var secondConstraint in tempConstraints)
                        {
                            string secondConStr=secondConstraint.PropertyName+":"+secondConstraint.Value;
                            if (!condition.Split(';').Contains(secondConStr))
                            {
                                rtStr= secondConStr;
                                break;
                            }
                        }
                        if (!string.IsNullOrEmpty(rtStr))
                            break;
                    }
                    return rtStr;
                }
                catch (Exception e)
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// 得到相互冲突：A->B和B->A的冲突，并且约束有问题会返回
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static string getConstraints(int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var propertyNames = context.CatalogConstraints
                        .Select(s => new
                        {
                            PropertyName = s.PropertyName,
                            InfluencedPropertyName = s.InfluencedPropertyName,
                            DeviceId = s.DeviceId
                        })
                        .Intersect(context.CatalogConstraints
                        .Select(s => new
                        {
                            PropertyName = s.InfluencedPropertyName,
                            InfluencedPropertyName = s.PropertyName,
                            DeviceId = s.DeviceId
                        }));
                    if (propertyNames != null && propertyNames.Count() != 0)
                    {
                        foreach(var pn in propertyNames)
                        {
                            if (string.IsNullOrEmpty(testConstraint(pn.DeviceId, pn.PropertyName, pn.InfluencedPropertyName)))
                                continue;
                            else
                                return testConstraint(pn.DeviceId, pn.PropertyName, pn.InfluencedPropertyName);
                        }
                    }
                    return string.Empty;
                }
                catch (Exception e)
                {
                    return string.Empty;
                }
            }
        }


        /// <summary>
        /// 订单拷贝
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
                    var currentOrder = context.CatalogOrders
                        .Select(s => s.OrderId);
                    if (currentOrder.Count() != 0)
                        newOrderId = currentOrder.Max() + 1;

                    var catlogOrders = context.CatalogOrders
                        .Where(s => s.OrderId == orderId);
                    foreach (var catlog in catlogOrders)
                    {
                        context.CatalogOrders.Add(new CatalogOrder
                        {
                            PropertyName = catlog.PropertyName,
                            DeviceId = catlog.DeviceId,
                            OrderId = newOrderId,
                            Value = catlog.Value,
                            SequenceNo=catlog.SequenceNo,
                            Type=catlog.Type
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
        /// 删除数据库订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static int deleteOrder(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var catalogOrders = context.CatalogOrders
                          .Where(s => s.OrderId == orderId);
                    if (catalogOrders != null && catalogOrders.Count() != 0)
                    {
                        foreach (var catalogOrder in catalogOrders)
                        {
                            context.CatalogOrders.Remove(catalogOrder);
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
    }
}
