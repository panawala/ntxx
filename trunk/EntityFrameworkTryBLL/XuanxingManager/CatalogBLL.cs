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

        public static List<CatalogPropertyValue> getAvaliableOptions(string propertyName, int orderId, int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<CatalogPropertyValue> rtCataModels = new List<CatalogPropertyValue>();
                    //得到影响当前属性的的所有主动属性
                    List<string> ptyNames = getPtyNames(propertyName, deviceId);
                    //得到相应主动属性列表的取值的组合
                    List<string> conditionStrList = generateCondition(ptyNames, orderId, deviceId);
                    
                    //遍历当前属性的所有值
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
        /// 根据属性名得到直接的变红的属性
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<CatalogModel> getAllByCondition(string propertyName, int orderId,int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<CatalogModel> rtcatalogModels = new List<CatalogModel>();
                    List<CatalogModel> catalogModels = new List<CatalogModel>();
                    //首先得到受影响的属性的名称
                    List<string> influencedPtyNames = getInfluencedPties(propertyName,deviceId);
                    if (influencedPtyNames.Count == 0)
                        return null;
                    //遍历受影响的属性
                    foreach (var ifn in influencedPtyNames)
                    {
                        //得到影响该属性的主动属性列表
                        var ptyNames = getPtyNames(ifn,deviceId);
                        //得到影响当前属性取值的所有的条件的string组合
                        var conditionStrList = generateCondition(ptyNames, orderId,deviceId);
                        var catPtyModels = context.CatalogPropertyValues
                            .Where(s => s.PropertyName == ifn
                            && s.DeviceId == deviceId);
                        //遍历该属性的值列表，
                        foreach (var catModel in catPtyModels)
                        {
                            if (string.IsNullOrEmpty(catModel.Condition) || catModel.Condition.Equals("ALL"))
                            {
                                catalogModels.Add(new CatalogModel
                                {
                                PropertyName=catModel.PropertyName,
                                Value=catModel.Value
                                });
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
                                catalogModels.Add(new CatalogModel
                                {
                                PropertyName=catModel.PropertyName,
                                Value=catModel.Value
                                });
                            }
                        }

                        //如果当前值不在其中，更改订单中的当前值
                        var currentValue = context.CatalogCurrentValues
                        .Where(s => s.PropertyName == ifn
                        && s.OrderId == orderId
                        && s.DeviceId == deviceId)
                        .First();
                        //如果当前取值不满足。则修改订单
                        if (!catalogModels
                            .Where(s => s.PropertyName == ifn)
                            .Select(s => s.Value).Contains(currentValue.Value))
                        {
                            currentValue.Value = catalogModels.First().Value;
                            context.SaveChanges();
                            rtcatalogModels.Add(new CatalogModel
                            {
                                PropertyName=ifn,
                                Value=currentValue.Value
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
        /// 保存订单
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
        /// 得到当前取值的组合
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
        /// 根据被动属性名得到主动属性名
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
        /// 得到约束中的被动属性列表
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
                    if (currentOrder != null)
                        orderId = currentOrder.Max() + 1;

                    var catPtyValues = context.CatalogPropertyValues
                        .Where(s => s.DeviceId == deviceId)
                        .Select(s => new { PropertyName = s.PropertyName, Default = s.Default })
                        .Distinct();
                    foreach (var catptyVal in catPtyValues)
                    {
                        context.CatalogCurrentValues.Add(new CatalogCurrentValue
                        {
                            PropertyName=catptyVal.PropertyName,
                            Value=catptyVal.Default,
                            DeviceId=deviceId,
                            OrderId=orderId
                        });
                    }
                    context.SaveChanges();
                    return orderId;
                }
                catch (Exception e)
                { 
                    return =-1;
                }
            }
        }


        public List<CatalogModel> getInitialLabels(int deviceId, int orderId)
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
                            Value = s.Value
                        });
                    return currentValues.ToList();
                }
                catch (Exception e)
                { 
                    return null
                }
            }
        }

    }
}
