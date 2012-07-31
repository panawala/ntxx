using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Xuanxing;
using DataContext;
using System.Data;

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
        public static List<CatalogPropertyValue> getAvaliableOptions(string propertyName, int orderId, int deviceId,string boolCondition="1")
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
                        && s.PropertyName == propertyName
                        &&s.BoolCondition==boolCondition);
                    foreach (var catModel in catCurrentValues)
                    {
                        if (string.IsNullOrEmpty(catModel.Condition) || catModel.Condition.Equals("ALL"))
                        {
                            rtCataModels.Add(catModel);
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
                            rtCataModels.Add(catModel);
                        }
                    }

                    //返回前过滤下价格
                    foreach (var catamodel in rtCataModels)
                    {
                        int coolingPower=getCoolingPower(orderId,deviceId);
                        var priceConstraints= context.CatalogPriceConstraints
                            .Where(s => s.DeviceId == deviceId
                            && s.CoolingPower == coolingPower
                            && s.Value == catamodel.Value
                            && s.PropertyName == catamodel.PropertyName);
                        if(priceConstraints!=null&&priceConstraints.Count()!=0)
                        {
                            var price = priceConstraints.First().Price;
                            catamodel.Price = price;
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
        /// 得到当前选择的冷量大小
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        private static int getCoolingPower(int orderId,int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var currentValue = context.CatalogCurrentValues
                        .Where(s => s.DeviceId == deviceId
                        && s.OrderId == orderId
                        && s.PropertyName == "冷量")
                        .First()
                        .Value;
                    return Convert.ToInt32(currentValue);
                }
                catch (Exception e)
                {
                    return -1;
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
            ////DSF dsf = new DSF();
            NewDSF newdsf = new NewDSF();
            newdsf.Traverse(catalogModels, orderId, deviceId, "Root");
            return newdsf.savecatalogModel;
        }

        /// <summary>
        /// 根据属性名得到直接的变红的属性;
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<CatalogModel> getAllByCon(string propertyName, int orderId, int deviceId,string boolCondition="1")
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    int coolingPower = getCoolingPower(orderId, deviceId);
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
                            && s.DeviceId == deviceId
                            &&s.BoolCondition==boolCondition);
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
                            var tempCatModels = catalogModels.Where(s => s.PropertyName == ifn);
                            if (tempCatModels != null && tempCatModels.Count()!=0)
                            {
                                var value = catalogModels.Where(s => s.PropertyName == ifn).First().Value;
                               //加入价格约束的判断
                                var priceConstraints = context.CatalogPriceConstraints
                                    .Where(s => s.DeviceId == deviceId
                                    && s.CoolingPower == coolingPower
                                    && s.Value == value
                                    && s.PropertyName == ifn);
                                if (priceConstraints != null && priceConstraints.Count() != 0)
                                {
                                    var price = priceConstraints.First().Price;
                                    currentValue.Price = price;
                                }
                                //修改选项
                                currentValue.Value = value;
                                context.SaveChanges();
                                rtcatalogModels.Add(new CatalogModel
                                {
                                    PropertyName = ifn,
                                    Value = currentValue.Value,
                                    SequenceNo = currentValue.SequenceNo,
                                    Type = currentValue.Type
                                });
                            }
                            
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
        /// 刷新订单中的价格
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static int refreshPriceConstraint(int orderId,int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var catPtyValues = context.CatalogCurrentValues
                        .Where(s => s.DeviceId == deviceId
                        && s.OrderId == orderId);
                    foreach (var catptyVal in catPtyValues)
                    {
                        var Price = context.CatalogPropertyValues
                            .Where(s => s.DeviceId == deviceId
                            && s.PropertyName == catptyVal.PropertyName
                            && s.Value == catptyVal.Value)
                            .First()
                            .Price;
                        catptyVal.Price = Price;
                    }
                    context.SaveChanges();

                    //取得当前的冷量大小
                    int coolingPower = getCoolingPower(orderId,deviceId);
                    var propertyValueDics = context.CatalogCurrentValues.AsEnumerable()
                        .Where(s => s.OrderId == orderId
                            && s.DeviceId == 1)
                            .Select(s => new
                            {
                                PropertyName = s.PropertyName,
                                Value = s.Value
                            })
                            .Intersect
                            (context.CatalogPriceConstraints.AsEnumerable()
                            .Where(s => s.CoolingPower == coolingPower
                                && s.DeviceId == 1)
                                .Select(s => new
                                {
                                    PropertyName = s.PropertyName,
                                    Value = s.Value
                                }));
                    if (propertyValueDics != null && propertyValueDics.Count() != 0)
                    {
                        foreach (var dic in propertyValueDics)
                        {
                            //得到当前的约束价格
                            var price = context.CatalogPriceConstraints
                                .Where(s => s.DeviceId == deviceId
                                && s.PropertyName == dic.PropertyName
                                && s.Value == dic.Value
                                && s.CoolingPower == coolingPower)
                                .First()
                                .Price;
                            var currentValue = context.CatalogCurrentValues
                                .Where(s => s.OrderId == orderId
                                && s.PropertyName == dic.PropertyName
                                && s.Value == dic.Value
                                && s.DeviceId == deviceId)
                                .First();
                            currentValue.Price = price;
                        }
                        return context.SaveChanges();
                    }
                    return -1;
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
        /// 重载版本，包括价格
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="orderId"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static int saveOrder(int deviceId, int orderId, string propertyName, string value,decimal price)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var currentValue = context.CatalogCurrentValues
                        .Where(s => s.DeviceId == deviceId
                        && s.OrderId == orderId
                        && s.PropertyName == propertyName)
                        .First();
                    currentValue.Value = value;
                    currentValue.Price = price;
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
                    deleteCurrentValues(orderId);
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
                                Type=order.Type,
                                Price=order.Price
                            });
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
        /// <param name="orderId"></param>
        /// <returns></returns>
        private static int deleteCurrentValues(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var currentValues = context.CatalogCurrentValues
                        .Where(s => s.OrderId == orderId);
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
            //首先刷新下价格
            refreshPriceConstraint(orderId, deviceId);
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
                            Type=currentValue.Type,
                            Price=currentValue.Price
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
                            Type=catlog.Type,
                            Price=catlog.Price
                        });
                    }
                    context.SaveChanges();
                    return newOrderId;
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


        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static int deleteRespondOrder(int orderId)
        {
            deleteCurrentValues(orderId);
            return deleteOrder(orderId);
        }



        /// <summary>
        /// 根据订单编号得到订单列表
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<CatalogOrder> getCatalogOrders(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var catalogOrders = context.CatalogOrders
                        .Where(s => s.OrderId == orderId);
                    return catalogOrders.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }




        /// <summary>
        /// 删除所有数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteAll()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var catalogPtyValues=context.CatalogPropertyValues;
                    foreach (var catPtyVal in catalogPtyValues)
                    {
                        context.CatalogPropertyValues.Remove(catPtyVal);
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
        /// 从datatable插入数据库
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
                        var catPtyVal = new CatalogPropertyValue
                        {
                            SequenceNo=Convert.ToInt32(dataRow["SequenceNo"].ToString()),
                            PropertyParent = dataRow["PropertyParent"].ToString(),
                            PropertyName = dataRow["PropertyName"].ToString(),
                            Value = dataRow["Value"].ToString(),
                            ValueDescription = dataRow["ValueDescription"].ToString(),
                            Condition =analyseCondition( dataRow["Condition"].ToString()),
                            Default = dataRow["Default"].ToString(),
                            Price = Convert.ToDecimal(dataRow["Price"].ToString()),
                            DeviceId=Convert.ToInt32(dataRow["DeviceId"].ToString()),
                            DeviceType=dataRow["DeviceType"].ToString(),
                            Type=dataRow["Type"].ToString(),
                            ConstraintType = dataRow["ConstraintType"].ToString(),
                            BoolCondition = dataRow["BoolCondition"].ToString()
                        };
                        context.CatalogPropertyValues.Add(catPtyVal);
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
        /// 分析字符串
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string analyseCondition(string condition)
        {
            if (string.IsNullOrEmpty(condition))
                return string.Empty;
            string rtRealValue = string.Empty;
            string[] conditionList = condition.Split('~');
            foreach (var conStr in conditionList)
            {
                string propertyName = conStr.Substring(0, conStr.LastIndexOf(':'));
                if (propertyName.Equals("冷量"))
                {
                    string realValue = string.Empty;
                    string valueStr = conStr.Substring(conStr.LastIndexOf(':') + 1);
                    string[] valueList = valueStr.Split(';');
                    foreach (var value in valueList)
                    {
                        realValue += propertyName + ":" + value + ";";
                    }
                    rtRealValue+= realValue;
                }
                else
                {
                    string realValue = string.Empty;
                    string valueStr = conStr.Substring(conStr.LastIndexOf(':') + 1);
                    string[] valueList = new string[valueStr.Length];
                    for (int i = 0; i < valueStr.Length; i++)
                    {
                        valueList[i] = valueStr.Substring(i, 1);
                    }
                    foreach (var value in valueList)
                    {
                        realValue += propertyName + ":" + value + ";";
                    }
                    rtRealValue+= realValue;
                }
            }
            rtRealValue = rtRealValue.Substring(0, rtRealValue.Length - 1);
            return rtRealValue;
        }

        /// <summary>
        /// 删除所有的约束
        /// </summary>
        /// <returns></returns>
        public static int DeleteAllConstraints()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var constraints = context.CatalogConstraints;
                    foreach (var contraint in constraints)
                    {
                        context.CatalogConstraints.Remove(contraint);
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
        /// 插入约束
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static int InsertConstraintsFromExcel(DataTable dataTable)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        var constraint = new CatalogConstraint
                        {
                            PropertyName = dataRow["PropertyName"].ToString(),
                            InfluencedPropertyName = dataRow["InfluencedPropertyName"].ToString(),
                            DeviceId = Convert.ToInt32(dataRow["DeviceId"].ToString())
                        };
                        context.CatalogConstraints.Add(constraint);
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
        /// 删除所有价格约束
        /// </summary>
        /// <returns></returns>
        public static int DeleteAllPriceConstraints()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var priceConstraints = context.CatalogPriceConstraints.ToList();
                    foreach (var priceConstraint in priceConstraints)
                    {
                        context.CatalogPriceConstraints.Remove(priceConstraint);
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
        /// 导入到价格约束
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static int InsertPriceConstraintsFromExcel(DataTable dataTable)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        var priceConstraint = new CatalogPriceConstraint
                        {
                            CoolingPower = Convert.ToInt32(dataRow["CoolingPower"].ToString()),
                            PropertyName = dataRow["PropertyName"].ToString(),
                            Value=dataRow["Value"].ToString(),
                            Price=Convert.ToDecimal(dataRow["Price"].ToString()),
                            DeviceId=Convert.ToInt32(dataRow["DeviceId"].ToString()),
                            DeviceType = dataRow["DeviceType"].ToString()
                        };
                        context.CatalogPriceConstraints.Add(priceConstraint);
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
