using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Device;
using Model.Property;
using DataContext;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace EntityFrameworkTryBLL
{
    public class PropertyBLL
    {
       



        //根据设备的Id和属性的名称返回属性值列表
        public static List<PropertyValue> GetPtyValuesByDeviceandPtyName(int deviceId, string propertyName)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    //var ptyValues=(from u in context.PropertyValues
                    //                   where u.PropertyID==propertyId && u.DeviceID == deviceId
                    //                   select u);
                    var propertyId = context.Properties
                        .Where(s => s.PropertyName == propertyName)
                        .First().PropertyID;
                    return GetPtyValuesByDeviceandPtyId(deviceId,propertyId);

                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        //根据设备的Id和属性的Id返回属性值列表
        public static List<PropertyValue> GetPtyValuesByDeviceandPtyId(int deviceId,int propertyId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var ptyValues = context.PropertyValues
                        .Where(s => s.PropertyID == propertyId && s.DeviceID == deviceId);
                    return ptyValues.ToList();

                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public static int GetCurrentSelectedPtyValue(int deviceId, string propertyName, int orderDetailId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    int ptyId = context.Properties
                        .Where(s => s.PropertyName == propertyName)
                        .Select(s => s.PropertyID)
                        .First();
                    int currSelectedPtyValueId = context.CurrentDevices
                        .Where(s => s.PropertyID == ptyId
                        && s.DeviceID == deviceId
                        && s.OrderDetailID == orderDetailId)
                        .Select(s => s.PropertyValueId)
                        .First();

                    //int currSelectedPtyValue = context.PropertyValues
                    //    .Where(s => s.DeviceID == deviceId
                    //    && s.PropertyID == ptyId
                    //    && s.PropertyValueID == currSelectedPtyValueId)
                    //    .Select(s => s.ValueCodeID)
                    //    .First();

                    //return currSelectedPtyValue;
                    return currSelectedPtyValueId;
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 根据设备信息和属性信息和订单信息得到属性值列表
        /// </summary>
        /// <param name="deviceId">设备ID</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="orderDetailId">订单ID</param>
        /// <returns></returns>
        public static List<PropertyValue> GetCurrentPtyValues(int deviceId, string propertyName, int orderDetailId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    int propertyId = context.Properties
                        .Where(s => s.PropertyName == propertyName)
                        .First().PropertyID;
                    var propertyValuesString = context.CurrentDevices
                        .Where(s => s.DeviceID == deviceId && s.PropertyID == propertyId && s.OrderDetailID == orderDetailId)
                        .First().PropertyValueArray.Split(',');
                    List<PropertyValue> propertyValues = new List<PropertyValue>();
                    foreach (var propertyValueCode in propertyValuesString)
                    {
                        //CurrentDevice中属性值列表存储的是valueCode
                        var propertyValue = context.PropertyValues
                            .Where(s => s.ValueCode == propertyValueCode && s.DeviceID == deviceId)
                            .First();
                        propertyValues.Add(propertyValue);
                    }
                    return propertyValues;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
 
        }


        /// <summary>
        /// 根据设备属性名字。属性设置被影响属性和保存当前属性选中值
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="orderDetailId">订单详情</param>
        /// <param name="propertyValueCode">属性值代码</param>
        /// <returns></returns>
        //public static  List<PropertyModel> SetCurrentPtyValues(int deviceId, string propertyName, int orderDetailId, string propertyValueCode)
        //{
        //    using (var context = new NorthwindContext())
        //    {
        //        try
        //        {
        //            int propertyId = context.Properties
        //                .Where(s => s.PropertyName == propertyName)
        //                .Select(s => s.PropertyID)
        //                .First();
        //            return SetCurrentPtyValues(deviceId, propertyId, orderDetailId, propertyValueCode);
        //        }
        //        catch (Exception e)
        //        {
        //            return null;
        //        }
        //    }
        //}
            //int propertyId=0;
            //List<PropertyModel> propertyModels = new List<PropertyModel>();
            //using (var context = new NorthwindContext())
            //{
            //    try
            //    {
            //        //得到某个属性名对应的属性Id
            //        propertyId = context.Properties
            //            .Where(s => s.PropertyName == propertyName)
            //            .First().PropertyID;
            //        //修改当前属性的值的属性值代码
            //        var currentDevice = context.CurrentDevices
            //            .Where(s => s.DeviceID == deviceId
            //            && s.OrderDetailID == orderDetailId
            //            && s.PropertyID == propertyId)
            //            .First();
            //        currentDevice.PropertyValueCode = propertyValueCode;
            //        context.SaveChanges();
            //    }
            //    catch(Exception ex)
            //    {}
            //}
            //using(var context=new NorthwindContext())
            //{
            //    try
            //    {
            //    //遍历所有的约束条件，一般情况下为一个
            //        var propertyConstraints = context.PropertyConstraints.AsEnumerable()
            //            .Where(s => s.DeviceID == deviceId && s.PropertyID == propertyId && s.PropertyValueRange.Split(',').Contains(propertyValueCode));
            //        foreach (var propertyConstraint in propertyConstraints)
            //        {
            //            //得到被影响属性的Id
            //            int ptyId = propertyConstraint.InfluencedPtyID;
            //            //得到被影响属性的取值范围
            //            string propertyValueString = DeviceBLL.GetPropertyValueString(ptyId, deviceId, orderDetailId);

            //            //得到当前被影响属性的名字
            //            var currentPropertyName = context.Properties
            //                .Where(s => s.PropertyID == ptyId)
            //                .First().PropertyName;

            //            //得到当前被影响属性的信息
            //            var currentDevice = context.CurrentDevices
            //                .Where(s => s.DeviceID == deviceId 
            //                    && s.PropertyID == ptyId
            //                    &&s.OrderDetailID==orderDetailId)
            //                .First();


            //            //得到被影响属性的建议取值
            //            string propertyRecomandValue = GetRecommandValueByValueString(deviceId, ptyId, propertyValueString);
            //            //得到当前被影响属性的当前取值不满足序列
            //            //如果不满足则取出属性值中的价格小的
            //            var currentValue = currentDevice.PropertyValueCode;
            //            if (!propertyValueString.Split(',').Contains(currentValue))
            //            {
            //                propertyModels.Add(new PropertyModel
            //                {
            //                    PropertyName = currentPropertyName,
            //                    PropertyValueCode = propertyRecomandValue
            //                });
            //                //并且修改当前被影响属性的属性值取值范围，和当前建议值
            //                currentDevice.PropertyValueCode = propertyRecomandValue;
            //            }
                        
            //            //不管建议值是否一样，总是要修改当前的范围
            //            currentDevice.PropertyValueArray = propertyValueString;
            //        }
            //        context.SaveChanges();

            //        return propertyModels;
            //    }
            //    catch (Exception e)
            //    {
            //        return null;
            //    }

            //}

        //}


        /// <summary>
        /// 根据设备属性名字。属性设置被影响属性和保存当前属性选中值
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="orderDetailId">订单详情</param>
        /// <param name="propertyValueCode">属性值代码</param>
        /// <returns></returns>
        //public static List<PropertyModel> SetCurrentPtyValues(int deviceId, int propertyId, int orderDetailId, string propertyValueCode)
        //{
        //    //int propertyId = 0;
        //    List<PropertyModel> propertyModels = new List<PropertyModel>();
        //    using (var context = new NorthwindContext())
        //    {
        //        try
        //        {
        //            //得到某个属性名对应的属性Id
        //            //propertyId = context.Properties
        //            //    .Where(s => s.PropertyName == propertyName)
        //            //    .First().PropertyID;
        //            //修改当前属性的值的属性值代码
        //            var currentDevice = context.CurrentDevices
        //                .Where(s => s.DeviceID == deviceId
        //                && s.OrderDetailID == orderDetailId
        //                && s.PropertyID == propertyId)
        //                .First();
        //            currentDevice.PropertyValueCode = propertyValueCode;
        //            context.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        { }
        //    }
        //    using (var context = new NorthwindContext())
        //    {
        //        try
        //        {
        //            //遍历所有的约束条件，一般情况下为一个
        //            var propertyConstraints = context.PropertyConstraints.AsEnumerable()
        //                .Where(s => s.DeviceID == deviceId && s.PropertyID == propertyId && s.PropertyValueRange.Split(',').Contains(propertyValueCode));
        //            foreach (var propertyConstraint in propertyConstraints)
        //            {
        //                //得到被影响属性的Id
        //                int ptyId = propertyConstraint.InfluencedPtyID;

        //                //得到当前被影响属性的信息
        //                var currentDevice = context.CurrentDevices
        //                    .Where(s => s.DeviceID == deviceId
        //                        && s.PropertyID == ptyId
        //                        && s.OrderDetailID == orderDetailId)
        //                    .First();


        //                //得到当前被影响属性的名字
        //                var currentPropertyName = context.Properties
        //                    .Where(s => s.PropertyID == ptyId)
        //                    .First().PropertyName;

        //                string propertyValueString = string.Empty;
        //                string propertyRecomandValue = string.Empty;
        //                //以下为计算取值序列和建议值
        //                //如果为交集类型这样求
        //                if (propertyConstraint.ConstraintRules.Equals("交集"))
        //                {
        //                    //得到被影响属性的取值范围,用到交集，将所有对其有影响的属性的影响合并起来，得到取值序列
        //                    propertyValueString = DeviceBLL.GetPropertyValueString(ptyId, deviceId, orderDetailId);
        //                    //得到被影响属性的建议取值，按照价格和字典序
        //                    propertyRecomandValue = GetRecommandValueByValueString(deviceId, ptyId, propertyValueString);
        //                }
        //                //如果是单一影响
        //                else
        //                {
        //                    var propertyInfluencedInfo= context.PropertyConstraints.AsEnumerable()
        //                        .Where(s => s.InfluencedPtyID == ptyId
        //                        && s.DeviceID == deviceId
        //                        && s.PropertyID == propertyId
        //                        && s.PropertyValueRange.Split(',').Contains(propertyValueCode))
        //                        .First();
        //                    propertyValueString = propertyInfluencedInfo.InfluencedPtyValueIdRange;
        //                    propertyRecomandValue = propertyInfluencedInfo.InfluencedPtyDefaultValue;
        //                }
                        
                      
                        
        //                //得到当前被影响属性的当前取值不满足序列
        //                //如果不满足则取出属性值中的价格小的
        //                var currentValue = currentDevice.PropertyValueCode;
        //                if (!propertyValueString.Split(',').Contains(currentValue))
        //                {
        //                    propertyModels.Add(new PropertyModel
        //                    {
        //                        PropertyName = currentPropertyName,
        //                        PropertyValueCode = propertyRecomandValue
        //                    });
        //                    //并且修改当前被影响属性的属性值取值范围，和当前建议值
        //                    currentDevice.PropertyValueCode = propertyRecomandValue;
        //                }

        //                //不管建议值是否一样，总是要修改当前的范围
        //                currentDevice.PropertyValueArray = propertyValueString;
        //            }
        //            context.SaveChanges();

        //            return propertyModels;
        //        }
        //        catch (Exception e)
        //        {
        //            return null;
        //        }

        //    }

        //}





        public static string GetRecommandValueByValueString(int deviceId, int propertyId, string valueString)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    string[] values=valueString.Split(',');
                    var recommandValue = context.PropertyValues
                        .Where(s => s.DeviceID == deviceId
                        && s.PropertyID == propertyId
                        && values.Contains(s.ValueCode))
                        //先按照价格排序
                        .OrderBy(s => s.Price)
                        //如果价格相同按照valueCode排序
                        .OrderBy(s=>s.ValueCode)
                        .First();
                    return recommandValue.ValueCode;
                }
                catch (Exception e)
                {
                    return string.Empty;
                }
            }
        }

        //根据设备的Id和属性的Id和属性的值，返回收到该属性约束的属性和属性值代码
        //public static List<InfluencedProperty> GetPtyContsByDeviceandPtyId(int deviceId, int propertyId,string valueCode)
        //{
        //    using (var context = new NorthwindContext())
        //    {
        //        try
        //        {
        //            //var ptyConstraints = (from u in context.PropertyConstraints.AsEnumerable()
        //            //                      where u.DeviceID == deviceId && u.PropertyID == propertyId
        //            //                          //主动属性列表中包含
        //            //                      && u.PropertyValueRange.Split(',').Contains<string>(valueCode)
        //            //                      select u);
        //            var ptyConstraints = context.PropertyConstraints.AsEnumerable()
        //                .Where(u => u.DeviceID == deviceId && u.PropertyID == propertyId
        //                && u.PropertyValueRange.Split(',').Contains<string>(valueCode));


        //            List<InfluencedProperty> influencedProperties = new List<InfluencedProperty>();
        //            foreach (var ptyConstraint in ptyConstraints)
        //            {
        //                //Property property = (from u in context.Properties
        //                //                     //根据被影响属性ID筛选
        //                //                     where u.PropertyID == ptyConstraint.InfluencedPtyID
        //                //                     select u).First();
        //                Property property = context.Properties
        //                    .Where(s => s.PropertyID == ptyConstraint.InfluencedPtyID)
        //                    .First();
        //                //IEnumerable<PropertyValue> propertyValues = (from u in context.PropertyValues.AsEnumerable()
        //                //                                             //根据被影响属性的值的ID
        //                //                                             where ptyConstraint.InfluencedPtyValueRange.Split(',').Contains(u.PropertyValueID.ToString())
        //                //                                             select u);
        //                IEnumerable<PropertyValue> propertyValues = context.PropertyValues.AsEnumerable()
        //                    .Where(s => ptyConstraint.InfluencedPtyValueIdRange.Split(',').Contains(s.PropertyValueID.ToString()));
        //                influencedProperties.Add(new InfluencedProperty
        //                {
        //                    Property = property,
        //                    PropertyValues = propertyValues
        //                });
        //            }
        //            return influencedProperties;
        //        }
        //        catch (Exception e)
        //        {
        //            return null;
        //        }
        //    }
        //}

       //修改属性值的价格
        //可用
        public static void UpdatePrice(int deviceId, int propertyId, int valueCodeId, decimal price)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var propertyValue = context.PropertyValues
                        .Where(s => s.PropertyID == propertyId
                        && s.DeviceID == deviceId
                        && s.ValueCodeID == valueCodeId)
                        .First();
                    propertyValue.Price = price;
                    context.SaveChanges();
                }
                catch (Exception e)
                { 
                }

            }
        }


        /// <summary>
        /// 设置价格关联的价格
        /// 可用
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="propertyId"></param>
        /// <param name="valueCodeId"></param>
        public static void SetRelativePrice(int deviceId,int propertyId, int valueCodeId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    string valueCodeStr=valueCodeId.ToString();
                    var propertyPriceContraints = context.PropertyPriceConstraints
                        .Where(s => s.PropertyID == propertyId
                        && s.PropertyValue == valueCodeStr);
                    foreach (var propertyPriceConstraint in propertyPriceContraints)
                    {
                        UpdatePrice(deviceId, propertyPriceConstraint.InfluencedPtyID,
                            Convert.ToInt32(propertyPriceConstraint.InfluencedPtyValue),
                            propertyPriceConstraint.InfluencedPtyPrice);
                    }

                }
                catch (Exception e)
                { 

                }
            }
        }

        /// <summary>
        /// 根据属性和属性值。和设备编号得到价格
        /// </summary>
        /// <param name="propertyId"></param>
        /// <param name="valueCodeId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static decimal getPriceByPtyIdandValue(int propertyId, int valueCodeId, int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var price = context.PropertyValues
                        .Where(s => s.PropertyID == propertyId
                        && s.ValueCodeID == valueCodeId
                        && s.DeviceID == deviceId)
                        .Select(s => s.Price)
                        .First();
                    return price;
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 根据属性名称得到属性的默认值
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        //public static string GetPtyDefaultValueByPropertyName(string propertyName)
        //{
        //    using (var context = new NorthwindContext())
        //    {
        //        try
        //        {
        //            var ptyDefaultValue = context.Properties
        //                .Where(s=>s.PropertyName==propertyName)
        //                .First().PropertyDefaultValue;
        //            return ptyDefaultValue;
        //        }
        //        catch (Exception e)
        //        {
        //            return string.Empty;
        //        }
        //    }
        //}

        /// <summary>
        /// 根据属性值代码和属性id得到属性值id
        /// </summary>
        /// <param name="valueCode"></param>
        /// <param name="propertyId"></param>
        /// <returns></returns>
        //public static int GetPtyValueIdByValueCode(string valueCode,int propertyId)
        //{
        //    using (var context = new NorthwindContext())
        //    {
        //        try
        //        {
        //            //var ptyValueId = (from u in context.PropertyValues
        //            //                  where u.ValueCode == valueCode
        //            //                  select u).First().PropertyValueID;
        //            var ptyValueId = context.PropertyValues
        //                .Where(s => s.ValueCode == valueCode&&s.PropertyID==propertyId)
        //                .First().PropertyValueID;
        //            return ptyValueId;
        //        }
        //        catch (Exception e)
        //        {
        //            return -1;
        //        }
        //    }
        //}


 


        
    

        /// <summary>
        /// 根据一个属性值的变化，得到首次变红的几个属性
        /// 可用
        /// </summary>
        /// <param name="deviceId">设备ID</param>
        /// <param name="ptyId">属性ID</param>
        /// <param name="ptyValueId">属性值ID</param>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public static List<PropertyModel> GetDirectRedPtyModels(int deviceId, int ptyId,string ptyValueId ,int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<PropertyModel> propertyRedModels = new List<PropertyModel>();
                    List<PropertyModel> propertyModels = new List<PropertyModel>();

                    //得到所有被影响的属性的Id和valueId
                    var influencedPropertyModelsArray = context.PropertyConstraints.AsEnumerable()
                        .Where(s => s.PropertyID == ptyId
                        && s.PropertyValueIdRange.Split(',').Contains(ptyValueId))
                        .Select(s => new { InfluencedPtyID = s.InfluencedPtyID, InfluencedPtyValueIdRange = s.InfluencedPtyValueIdRange })
                        .Distinct();

                    
                    //对每个被动属性的ID和值Value进行判断处理
                    foreach (var influencedPtyIdValue in influencedPropertyModelsArray)
                    {
                        //对每个属性ID和值Value进行处理，判定影响其值的主动属性的的Id和取值的列表
                        var ptyIdValueArray = context.PropertyConstraints
                            .Where(s => s.DeviceID == deviceId
                            && s.InfluencedPtyID == influencedPtyIdValue.InfluencedPtyID
                            && s.InfluencedPtyValueIdRange == influencedPtyIdValue.InfluencedPtyValueIdRange)
                            .Select(s => new { s.PropertyID, s.PropertyValueIdRange })
                            .Distinct();
                        bool flag = false;
                        //得到每个主动属性的当前选择的值
                        foreach (var ptyIdValue in ptyIdValueArray)
                        {
                            var currentPtyValue = context.CurrentDevices
                                .Where(s => s.PropertyID == ptyIdValue.PropertyID
                                && s.OrderDetailID == orderId
                                && s.DeviceID == deviceId)
                                .Select(s => s.PropertyValueId)
                                .First();
                            //如果主动属性有一个不满足。则将flag设置true表示该条属性不符合,即该被动属性不满足要求
                            if (!ptyIdValue.PropertyValueIdRange.Split(',').Contains(currentPtyValue.ToString()))
                            {
                                flag = true;
                                break;
                            }
                        }
                        //如果flag依然是false。证明该条被动属性的值满足要求
                        if (!flag)
                        {
                            //表示该条被动属性可以添加进去，最终得到被影响的属性的取值范围
                            propertyModels.Add(new PropertyModel
                            {
                                PropertyId = influencedPtyIdValue.InfluencedPtyID,
                                PropertyValueId = Convert.ToInt32(influencedPtyIdValue.InfluencedPtyValueIdRange)
                            });
                        }
                    }

                    //得到被影响后的属性的ID的集合
                    var ptyIdsArray= propertyModels.Select(s=>s.PropertyId).Distinct();

                    int j = 0;
                    int ii=influencedPropertyModelsArray.Select(s => s.InfluencedPtyID).Distinct().Count();
                    int jj=ptyIdsArray.Count();
                    if ( ii!= jj)
                        j = 1;

                    foreach (var ptyIde in ptyIdsArray)
                    {
                        //得到当前的属性的取值
                        var ptyIdValue = context.CurrentDevices
                            .Where(s => s.DeviceID == deviceId
                            && s.OrderDetailID == orderId
                            && s.PropertyID == ptyIde)
                            .Select(s => new PropertyModel { PropertyId = s.PropertyID, PropertyValueId = s.PropertyValueId })
                            .First();
                        var ptyModel = IsModelInArray(propertyModels, ptyIdValue);
                        if (ptyModel != null)
                            propertyRedModels.Add(ptyModel);
                    }

                    return propertyRedModels;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// 重载版本
        /// 可用
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="propertyName"></param>
        /// <param name="ptyValueId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<PropertyModelLogic> GetDirectRedPtyModelsLogic(int deviceId, string propertyName, string ptyValueId, int orderId)
        {
            int propertyId = GetPtyIdByPtyName(propertyName);
            return GetDirectRedPtyModelsLogic(deviceId,propertyId,ptyValueId,orderId);
        }
        /// <summary>
        /// 根据一个属性值的变化，得到首次变红的几个属性
        /// 可用
        /// </summary>
        /// <param name="deviceId">设备ID</param>
        /// <param name="ptyId">属性ID</param>
        /// <param name="ptyValueId">属性值ID</param>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public static List<PropertyModelLogic> GetDirectRedPtyModelsLogic(int deviceId, int ptyId, string ptyValueId, int orderId)
        {
            //先将已选择的属性值保存起来
            using (var context = new AnnonContext())
            {
                try
                {
                    var currentDevice = context.CurrentDevices
                        .Where(s => s.DeviceID == deviceId
                        && s.PropertyID == ptyId
                        && s.OrderDetailID == orderId)
                        .First();
                    currentDevice.PropertyValueId = Convert.ToInt32(ptyValueId);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                }
            }


            //var ptyModels = GetDirectRedPtyModels(deviceId, ptyId, ptyValueId, orderId);
            ////将变红的属性全部保存
            //using (var context = new NorthwindContext())
            //{
            //    try
            //    {
            //        foreach (var ptyModel in ptyModels)
            //        {
            //            var currentDevice = context.CurrentDevices
            //                .Where(s => s.DeviceID == deviceId
            //                && s.OrderDetailID == orderId
            //                && s.PropertyID == ptyModel.PropertyId)
            //                .First();
            //            currentDevice.PropertyValueId = ptyModel.PropertyValueId;
            //        }
            //        context.SaveChanges();
            //    }
            //    catch (Exception e)
            //    { 
            //    }
            //}

            ////临时保存变红属性
            //List<PropertyModel> tempPtyModels = new List<PropertyModel>();
            //foreach (var ptyModel in ptyModels)
            //{
            //    tempPtyModels.Add(new PropertyModel
            //        {
            //            PropertyId = ptyModel.PropertyId,
            //            PropertyValueId = ptyModel.PropertyValueId
            //        });
            //}

            ////以上当前属性和变红属性都已经保存。
            //foreach (var ptyModel in tempPtyModels)
            //{
            //    var ptySubModels = GetDirectRedPtyModels(deviceId, ptyModel.PropertyId, ptyModel.PropertyValueId.ToString(), orderId);
            //    foreach (var model in ptySubModels)
            //    {
            //        ptyModels.Add(new PropertyModel
            //        {
            //            PropertyId=model.PropertyId,
            //            PropertyValueId=model.PropertyValueId
            //        });
            //    }
            //}

            var ptyModels = GetRedPtyModels(deviceId, ptyId, ptyValueId, orderId);

            List<PropertyModelLogic> propertyModelLogics = new List<PropertyModelLogic>();
            using (var context = new AnnonContext())
            {
                try
                {
                    foreach (var ptyModel in ptyModels)
                    {
                        string propertyName=context.Properties
                            .Where(s=>s.PropertyID==ptyModel.PropertyId)
                            .Select(s=>s.PropertyName)
                            .First();
                        var propertyModelLogic = context.PropertyValues
                            .Where(s => s.DeviceID == deviceId
                            && s.PropertyID == ptyModel.PropertyId
                            && s.ValueCodeID == ptyModel.PropertyValueId)
                            .Select(s => new PropertyModelLogic 
                            { 
                                PropertyName = propertyName, 
                                ValueCode = s.ValueCode 
                            })
                            .First();
                         
                        propertyModelLogics.Add(propertyModelLogic);
                    }
                    return propertyModelLogics;
                }
                catch (Exception e)
                {
                    return null;
                }
                
            }
            
        }

        /// <summary>
        /// 得到变红的属性
        /// </summary>
        /// <param name="deviceId">设备ID</param>
        /// <param name="ptyId">属性ID</param>
        /// <param name="ptyValueId">属性值ID</param>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public static List<PropertyModel> GetRedPtyModels(int deviceId, int ptyId, string ptyValueId, int orderId)
        {
            var ptyModels = GetDirectRedPtyModels(deviceId, ptyId, ptyValueId, orderId);
            /******************************************************************************************/
            //将变红的属性全部保存
            /******************************************************************************************/
            using (var context = new AnnonContext())
            {
                try
                {
                    foreach (var ptyModel in ptyModels)
                    {
                        var currentDevice = context.CurrentDevices
                            .Where(s => s.DeviceID == deviceId
                            && s.OrderDetailID == orderId
                            && s.PropertyID == ptyModel.PropertyId)
                            .First();
                        currentDevice.PropertyValueId = ptyModel.PropertyValueId;
                    }
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            /******************************************************************************************/
            //临时保存变红属性
            /******************************************************************************************/
            List<PropertyModel> tempPtyModels = new List<PropertyModel>();
            foreach (var ptyModel in ptyModels)
            {
                tempPtyModels.Add(new PropertyModel
                {
                    PropertyId = ptyModel.PropertyId,
                    PropertyValueId = ptyModel.PropertyValueId
                });
            }

            /******************************************************************************************/
            //以上当前属性和变红属性都已经保存。
            /******************************************************************************************/
            foreach (var ptyModel in tempPtyModels)
            {
                var ptySubModels = GetRedPtyModels(deviceId, ptyModel.PropertyId, ptyModel.PropertyValueId.ToString(), orderId);
                foreach (var model in ptySubModels)
                {
                    ptyModels.Add(new PropertyModel
                    {
                        PropertyId = model.PropertyId,
                        PropertyValueId = model.PropertyValueId
                    });
                }
            }

            return ptyModels;
        }

        /// <summary>
        /// 处理约束关系。20120610
        /// 得到当前选择的属性和属性的取值范围
        /// </summary>
        /// <param name="deviceId"></param>
        public static List<PropertyModel> GetAvailablePtyModels(int deviceId,int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<PropertyModel> propertyModels = new List<PropertyModel>();
                    //得到每个设备的被动属性ID和值的列表
                    var influencedPtyIdValueArray = context.PropertyConstraints
                        .Where(s => s.DeviceID == deviceId)
                        .Select(s => new { InfluencedPtyID = s.InfluencedPtyID, InfluencedPtyValueIdRange = s.InfluencedPtyValueIdRange })
                        .Distinct();
                    //对每个被动属性进行判断处理
                    foreach (var influencedPtyIdValue in influencedPtyIdValueArray)
                    {
                        //对每个属性ID和值进行处理，判定影响其值的主动属性的的Id和取值的列表
                        var ptyIdValueArray = context.PropertyConstraints
                            .Where(s => s.DeviceID == deviceId
                            && s.InfluencedPtyID == influencedPtyIdValue.InfluencedPtyID
                            && s.InfluencedPtyValueIdRange == influencedPtyIdValue.InfluencedPtyValueIdRange)
                            .Select(s => new { s.PropertyID, s.PropertyValueIdRange })
                            .Distinct();

                        bool flag=false;
                        //得到每个属性的当前选择的值
                        foreach (var ptyIdValue in ptyIdValueArray)
                        {
                            var currentPtyValue = context.CurrentDevices
                                .Where(s => s.PropertyID == ptyIdValue.PropertyID
                                && s.OrderDetailID == orderId
                                && s.DeviceID == deviceId)
                                .Select(s => s.PropertyValueId)
                                .First();
                            //如果主动属性有一个不满足。则将flag设置true表示该条属性不符合
                            if (!ptyIdValue.PropertyValueIdRange.Split(',').Contains(currentPtyValue.ToString()))
                                flag = true;
                        }
                        //如果flag依然是false。证明该条被动属性的值满足要求
                        if (!flag)
                        {
                            //表示该条被动属性可以添加进去
                            propertyModels.Add(new PropertyModel
                            {
                                PropertyId = influencedPtyIdValue.InfluencedPtyID,
                                PropertyValueId = Convert.ToInt32(influencedPtyIdValue.InfluencedPtyValueIdRange)
                            });
                        }

                    }
                    return propertyModels;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 根据当前设备和订单号获取变红的属性和属性值
        /// </summary>
        /// <param name="deviceId">设备Id</param>
        /// <param name="orderId">订单Id</param>
        /// <returns></returns>
        public static PropertyModel GetRedPropertyModel(int deviceId,int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    //根据当前的所有属性的选择的值，得到所有可选值的列表
                    var propertyModels = GetAvailablePtyModels(deviceId, orderId);

                    //得到当前设备的属性和属性值取值
                    var propertyModelArray = context.CurrentDevices
                        .Where(s => s.DeviceID == deviceId
                        && s.OrderDetailID == orderId)
                        .Select(s => new PropertyModel { PropertyId = s.PropertyID, PropertyValueId = s.PropertyValueId });

                    PropertyModel ptyRedModel = null;
                    //对每个当前取值进行判断
                    foreach (var propertyModel in propertyModelArray)
                    {
                        var ptyModel=IsModelInArray(propertyModels, propertyModel);
                        //如果当前取值不满足。则修改当前的取值，只对第一个不满足的进行判定
                        if (ptyModel!=null)
                        {
                            //返回当前取值范围的第一个
                            ptyRedModel = ptyModel;
                            var currentPtyModel = context.CurrentDevices
                                .Where(s => s.DeviceID == deviceId
                                && s.OrderDetailID == orderId
                                && s.PropertyID == propertyModel.PropertyId)
                                .First();
                            currentPtyModel.PropertyValueId = ptyModel.PropertyValueId;
                            break;
                        }
                    }
                    context.SaveChanges();
                    return ptyRedModel;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 内含判断
        /// 可用
        /// </summary>
        /// <param name="propertyModels">propertyModel列表</param>
        /// <param name="propertyModel">propertyModel类</param>
        /// <returns></returns>
        private static PropertyModel IsModelInArray(List<PropertyModel> propertyModels, PropertyModel propertyModel)
        {
            //如果存在返回null
            foreach (var ptyModel in propertyModels)
            {
                if (ptyModel.PropertyId == propertyModel.PropertyId
                    && ptyModel.PropertyValueId == propertyModel.PropertyValueId)
                    return null;
            }
            //如果不存在相等的。则返回第一个默认的
            foreach (var ptyModel in propertyModels)
            {
                if (ptyModel.PropertyId == propertyModel.PropertyId)
                    return ptyModel;
            }
            return null;
        }

       


        #region 属性值操作
        /// <summary>
        /// 插入属性值
        /// 可用
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="valueCode"></param>
        /// <param name="price"></param>
        /// <param name="valueDescription"></param>
        /// <param name="deviceId"></param>
        /// <param name="propertyValueType"></param>
        /// <returns></returns>
        public static int InsertIntoPropertyValue(string propertyName, string valueCode, decimal price, string valueDescription, int deviceId, string propertyValueType)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    int propertyId = context.Properties
                        .Where(s => s.PropertyName == propertyName)
                        .First().PropertyID;
                    return InsertIntoPropertyValue(propertyId, valueCode, price, valueDescription, deviceId, propertyValueType);
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 插入属性值数据库
        /// 可用
        /// </summary>
        /// <param name="propertyID"></param>
        /// <param name="valueCode"></param>
        /// <param name="valueDescription"></param>
        /// <param name="deviceId"></param>
        /// <param name="propertyValueType"></param>
        /// <returns></returns>
        public static int InsertIntoPropertyValue(int propertyID, string valueCode, decimal price, string valueDescription, int deviceId, string propertyValueType)
        {
            int currentValueCodeId = 0;
            using (var context = new AnnonContext())
            {
                currentValueCodeId = context.PropertyValues
                    .Select(s => s.ValueCodeID)
                    .Max() + 1;
            }
            var propertyValue = new PropertyValue
            {
                PropertyID = propertyID,
                ValueCodeID=currentValueCodeId,
                ValueCode = valueCode,
                ValueDescription = valueDescription,
                DeviceID = deviceId,
                Price = price,
                PropertyValueType = propertyValueType
            };
            using (var context = new AnnonContext())
            {
                try
                {
                    context.PropertyValues.Add(propertyValue);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }



        /// <summary>
        /// 从datatable将数据导入
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static int InsertIntoPropertyValueFromExcel(DataTable dataTable)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        var propertyValue = new PropertyValue
                        {
                            PropertyID = Convert.ToInt32(dataRow["PropertyID"].ToString()),
                            Price=Convert.ToDecimal(dataRow["Price"].ToString()),
                            ValueCodeID = Convert.ToInt32(dataRow["ValueCodeID"].ToString()),
                            ValueCode=dataRow["ValueCode"].ToString(),
                            DeviceID=Convert.ToInt32(dataRow["DeviceID"].ToString()),
                            PropertyValueType = dataRow["PropertyValueType"].ToString(),
                            ValueDescription = dataRow["ValueDescription"].ToString()
                        };
                        context.PropertyValues.Add(propertyValue);
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
        /// 删除约束中的所有内容
        /// </summary>
        /// <returns></returns>
        public static int DeleteAllPropertyValues()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var propertyValues = context.PropertyValues;
                    foreach (var propertyValue in propertyValues)
                    {
                        context.PropertyValues.Remove(propertyValue);
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
        /// 插入属性值数据库
        /// 可用
       /// </summary>
       /// <param name="propertyID"></param>
       /// <param name="valueCodeId"></param>
       /// <param name="valueCode"></param>
       /// <param name="price"></param>
       /// <param name="valueDescription"></param>
       /// <param name="deviceId"></param>
       /// <param name="propertyValueType"></param>
       /// <returns></returns>
        public static int InsertIntoPropertyValue(int propertyID, int valueCodeId,string valueCode, decimal price, string valueDescription, int deviceId, string propertyValueType)
        {
            var propertyValue = new PropertyValue
            {
                PropertyID = propertyID,
                ValueCodeID = valueCodeId,
                ValueCode = valueCode,
                ValueDescription = valueDescription,
                DeviceID = deviceId,
                Price = price,
                PropertyValueType = propertyValueType
            };
            using (var context = new AnnonContext())
            {
                try
                {
                    context.PropertyValues.Add(propertyValue);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 根据属性ID,属性值codeID删除当前属性值
        /// 可用
        /// </summary>
        /// <param name="properytID"></param>
        /// <param name="valueCodeID">属性值ID</param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static int DeleteFromPropertyValue(int properytID, int valueCodeID, int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var propertyValue = context.PropertyValues
                        .Where(s => s.PropertyID == properytID
                        && s.ValueCodeID == valueCodeID
                        && s.DeviceID == deviceId)
                        .First();
                    context.PropertyValues.Remove(propertyValue);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }

        }

        /// <summary>
        /// 更新属性值表
        /// 可用
        /// </summary>
        /// <param name="propertyID">属性ID</param>
        /// <param name="valueCodeID">属性值ID</param>
        /// <param name="valueCode">属性值</param>
        /// <param name="valueDescription"></param>
        /// <param name="price"></param>
        /// <param name="deviceId"></param>
        /// <param name="propertyValueType"></param>
        /// <returns></returns>
        public static int UpdatePropertyValue(int propertyID, int valueCodeID,string valueCode, string valueDescription, decimal price, int deviceId, string propertyValueType)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var propertyValue = context.PropertyValues
                        .Where(s => s.DeviceID == deviceId
                        && s.PropertyID == propertyID
                        && s.ValueCodeID == valueCodeID)
                        .First();

                    propertyValue.Price = price;
                    propertyValue.PropertyValueType = propertyValueType;
                    propertyValue.ValueDescription = valueDescription;

                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }



        /// <summary>
        /// 
        /// 根据当前的属性ID得到当前的取值范围。在某个点击了某个属性后出现该值的取值范围,
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="ptyId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<PropertyModel> GetAvaliableValueRange(int deviceId, int ptyId, int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<PropertyModel> propertyModels = new List<PropertyModel>();
                    //得到影响该属性的所有因子
                    var ptyModelsArray = context.PropertyConstraints
                        .Where(s => s.DeviceID == deviceId
                        && s.InfluencedPtyID == ptyId)
                        .Select(s => new { InfluencedPtyID = s.InfluencedPtyID, InfluencedPtyValueIdRange = s.InfluencedPtyValueIdRange })
                        .Distinct();
                    //对每个被动属性进行判断处理
                    foreach (var influencedPtyIdValue in ptyModelsArray)
                    {
                        //对每个属性ID和值Value进行处理，判定影响其值的主动属性的的Id和取值的列表
                        var ptyIdValueArray = context.PropertyConstraints
                            .Where(s => s.DeviceID == deviceId
                            && s.InfluencedPtyID == influencedPtyIdValue.InfluencedPtyID
                            && s.InfluencedPtyValueIdRange == influencedPtyIdValue.InfluencedPtyValueIdRange)
                            .Select(s => new { s.PropertyID, s.PropertyValueIdRange })
                            .Distinct();

                        bool flag = false;
                        //得到每个属性的当前选择的值
                        foreach (var ptyIdValue in ptyIdValueArray)
                        {
                            var currentPtyValue = context.CurrentDevices
                                .Where(s => s.PropertyID == ptyIdValue.PropertyID
                                && s.OrderDetailID == orderId
                                && s.DeviceID == deviceId)
                                .Select(s => s.PropertyValueId)
                                .First();
                            //如果主动属性有一个不满足。则将flag设置true表示该条属性不符合
                            if (!ptyIdValue.PropertyValueIdRange.Split(',').Contains(currentPtyValue.ToString()))
                            {
                                flag = true;
                                break;
                            }

                        }
                        //如果flag依然是false。证明该条被动属性的值满足要求
                        if (!flag)
                        {
                            //表示该条被动属性可以添加进去
                            propertyModels.Add(new PropertyModel
                            {
                                PropertyId = influencedPtyIdValue.InfluencedPtyID,
                                PropertyValueId = Convert.ToInt32(influencedPtyIdValue.InfluencedPtyValueIdRange)
                            });
                        }
                    }
                    return propertyModels;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// 得到当前属性的取值范围，根据设备ID,属性ID和订单ID
        /// 可用
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="propertyName"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<PropertyValue> GetAvaliablePtyValueRange(int deviceId, string propertyName, int orderId)
        {
            var propertyId = GetPtyIdByPtyName(propertyName);
            return GetAvaliablePtyValueRange(deviceId, propertyId, orderId);
        }

        /// <summary>
        /// 得到当前属性的取值范围，根据设备ID,属性ID和订单ID
        /// 可用
        /// </summary>
        /// <param name="deviceId">设备ID</param>
        /// <param name="ptyId">属性ID</param>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public static List<PropertyValue> GetAvaliablePtyValueRange(int deviceId, int ptyId, int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<PropertyValue> propertyValueArray = new List<PropertyValue>();
                    //得到影响该属性的所有属性的值，包括属性ID,和值ID的列表
                    var ptyModelsArray = context.PropertyConstraints
                        .Where(s => s.DeviceID == deviceId
                        && s.InfluencedPtyID == ptyId)
                        .Select(s => new
                        {
                            InfluencedPtyID = s.InfluencedPtyID, 
                            InfluencedPtyValueIdRange = s.InfluencedPtyValueIdRange 
                        })
                        .Distinct();
                    //将该属性当作被动属性，对每个被动属性进行约束判断处理
                    foreach (var influencedPtyIdValue in ptyModelsArray)
                    {
                        //对每个属性ID和值Value进行处理，判定影响其值的主动属性的的Id和取值的列表
                        var ptyIdValueArray = context.PropertyConstraints
                            .Where(s => s.DeviceID == deviceId
                            && s.InfluencedPtyID == influencedPtyIdValue.InfluencedPtyID
                            && s.InfluencedPtyValueIdRange == influencedPtyIdValue.InfluencedPtyValueIdRange)
                            .Select(s => new { s.PropertyID, s.PropertyValueIdRange })
                            .Distinct();

                        bool flag = false;
                        //得到每个主动属性的当前选择的值
                        foreach (var ptyIdValue in ptyIdValueArray)
                        {
                            var currentPtyValue = context.CurrentDevices
                                .Where(s => s.PropertyID == ptyIdValue.PropertyID
                                && s.OrderDetailID == orderId
                                && s.DeviceID == deviceId)
                                .Select(s => s.PropertyValueId)
                                .First();
                            //如果主动属性有一个不满足。则将flag设置true表示该条属性不符合
                            if (!ptyIdValue.PropertyValueIdRange.Split(',').Contains(currentPtyValue.ToString()))
                            {
                                flag = true;
                                break;
                            }
                        }
                        //如果flag依然是false。证明该条被动属性的值满足要求，即该条被动属性ID和值ID满足条件
                        if (!flag)
                        {
                            propertyValueArray.Add(context.PropertyValues.AsEnumerable()
                                .Where(s => s.DeviceID == deviceId
                                && s.PropertyID == influencedPtyIdValue.InfluencedPtyID
                                && s.ValueCodeID == Convert.ToInt32(influencedPtyIdValue.InfluencedPtyValueIdRange))
                                .First());
                        }
                    }
                    //属性值按照valueCode排序，默认数字在前。字母在后
                    propertyValueArray = propertyValueArray.OrderBy(s => s.ValueCode).ToList();
                    return propertyValueArray;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }



        #endregion

        #region 属性约束操作。增删改

        public static int GetPtyIdByPtyName(string propertyName)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    return context.Properties
                        .Where(s => s.PropertyName == propertyName)
                        .First().PropertyID;
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        public static string GetPtyNameByPtyID(int propertyId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    return context.Properties
                        .Where(s => s.PropertyID==propertyId)
                        .First().PropertyName;
                }
                catch (Exception e)
                {
                    return string.Empty;
                }
            }
        }
        //返回业务类约束列表
        //public static List<PropertyConstraintLogic> GetPropertyConstraintsByDeviceId(int deviceId)
        //{
        //    using (var context = new NorthwindContext())
        //    {
        //        try
        //        {
        //            var propertyConstraintsLogic = new List<PropertyConstraintLogic>();
        //            var propertyConstraints = context.PropertyConstraints;
        //            foreach (var propertyConstraint in propertyConstraints)
        //            {
        //                propertyConstraintsLogic.Add(new PropertyConstraintLogic
        //                    {
        //                        PropertyConstraintID = propertyConstraint.PropertyConstraintID,
        //                        DeviceID = propertyConstraint.DeviceID,
        //                        PropertyName = GetPtyNameByPtyID(propertyConstraint.PropertyID),
        //                        PropertyValueRange = propertyConstraint.PropertyValueRange,

        //                        InfluencedPtyName = GetPtyNameByPtyID(propertyConstraint.InfluencedPtyID),
        //                        InfluencedPtyValueRange = propertyConstraint.InfluencedPtyValueIdRange,
        //                        ConstraintRules = propertyConstraint.ConstraintRules,
        //                        InfluencedPtyDefaultValue = propertyConstraint.InfluencedPtyDefaultValue
        //                    });
        //            }
        //            return propertyConstraintsLogic;
        //        }
        //        catch (Exception e)
        //        {
        //            return null;
        //        }
        //    }
        //}



        /// <summary>
        /// 重载版本
        /// 可用
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="propertyValueRange"></param>
        /// <param name="influencedPtyName"></param>
        /// <param name="influencePtyValueRange"></param>
        /// <param name="constraintRules"></param>
        /// <param name="influencePtyDefaultValue"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static int InsertIntoPropertyConstraint(string propertyName, string propertyValueRange,
            string influencedPtyName, string influencePtyValueRange, string constraintRules, string influencePtyDefaultValue, int deviceId)
        {
            int propertyID, influencedPtyID = 0;
            using (var context = new AnnonContext())
            {
                propertyID = context.Properties
                    .Where(s => s.PropertyName == propertyName)
                    .First()
                    .PropertyID;
                influencedPtyID = context.Properties
                    .Where(s => s.PropertyName == influencedPtyName)
                    .First()
                    .PropertyID;
            }
            var propertyConstraint = new PropertyConstraint
            {
                PropertyID = propertyID,
                PropertyValueIdRange = propertyValueRange,
                InfluencedPtyID = influencedPtyID,
                InfluencedPtyValueIdRange = influencePtyValueRange,
                ConstraintRules = constraintRules,
                InfluencedPtyDefaultValue = influencePtyDefaultValue,
                DeviceID = deviceId
            };
            using (var context = new AnnonContext())
            {
                try
                {
                    context.PropertyConstraints.Add(propertyConstraint);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 从datatable将数据导入
        /// 可用
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static int InsertIntoPropertyConstraintFromExcel(DataTable dataTable)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        var propertyConstraint = new PropertyConstraint
                        {
                            PropertyID = Convert.ToInt32(dataRow["PropertyID"].ToString()),
                            PropertyValueIdRange = dataRow["PropertyValueIdRange"].ToString(),
                            InfluencedPtyID = Convert.ToInt32(dataRow["InfluencedPtyID"].ToString()),
                            InfluencedPtyValueIdRange = dataRow["InfluencedPtyValueIdRange"].ToString(),
                            ConstraintRules = dataRow["ConstraintRules"].ToString(),
                            InfluencedPtyDefaultValue = dataRow["InfluencedPtyDefaultValue"].ToString(),
                            DeviceID = Convert.ToInt32(dataRow["DeviceID"].ToString())
                        };
                        context.PropertyConstraints.Add(propertyConstraint);
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
        /// 删除约束中的所有内容
        /// 可用
        /// </summary>
        /// <returns></returns>
        public static int DeleteAll()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var propertyConstraints = context.PropertyConstraints;
                    foreach (var propertyConstraint in propertyConstraints)
                    {
                        context.PropertyConstraints.Remove(propertyConstraint);
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
        /// 插入属性约束
        /// 可用
        /// </summary>
        /// <param name="propertyID"></param>
        /// <param name="propertyValueRange"></param>
        /// <param name="influencedPtyID"></param>
        /// <param name="influencePtyValueRange"></param>
        /// <param name="constraintRules"></param>
        /// <param name="influencePtyDefaultValue"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static int InsertIntoPropertyConstraint(int propertyID, string propertyValueRange,
            int influencedPtyID, string influencePtyValueRange, string constraintRules, string influencePtyDefaultValue, int deviceId)
        {
            var propertyConstraint = new PropertyConstraint
            {
                PropertyID = propertyID,
                PropertyValueIdRange = propertyValueRange,
                InfluencedPtyID = influencedPtyID,
                InfluencedPtyValueIdRange = influencePtyValueRange,
                ConstraintRules = constraintRules,
                InfluencedPtyDefaultValue = influencePtyDefaultValue,
                DeviceID = deviceId
            };
            using (var context = new AnnonContext())
            {
                try
                {
                    context.PropertyConstraints.Add(propertyConstraint);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }




        /// <summary>
        /// 从datatable将数据导入
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static int InsertIntoPropertyFromExcel(DataTable dataTable)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        var property = new Property
                        {
                            PropertyName = dataRow["PropertyName"].ToString(),
                            PropertyParentID = Convert.ToInt32(dataRow["PropertyParentID"].ToString()),
                            CatalogName = dataRow["CatalogName"].ToString(),
                            PropertyDefaultValueID = Convert.ToInt32(dataRow["PropertyDefaultValueID"].ToString()),
                            PropertyType = dataRow["PropertyType"].ToString()
                        };
                        context.Properties.Add(property);
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
        /// 删除约束中的所有内容
        /// </summary>
        /// <returns></returns>
        public static int DeleteAllProperties()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var properties = context.Properties;
                    foreach (var property in properties)
                    {
                        context.Properties.Remove(property);
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
        /// 批量导入PropertyConstraint
        /// </summary>
        /// <param name="dt"></param>
        public static void BulkInsertIntoPropertyConstraint(DataTable dt,string desTableName)
        {
            string ConnectionNew = ConfigurationManager.ConnectionStrings["NorthwindContext"].ToString();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnectionNew))
            {
                bulkCopy.DestinationTableName = desTableName;
                try
                {
                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // Close the SqlDataReader. The SqlBulkCopy
                    // object is automatically closed at the end
                    // of the using block.
                }
            }
        }


        /// <summary>
        /// 重载方法,根据propertyConstraintID更新约束信息
        /// 可用
        /// </summary>
        /// <param name="propertyConstraintID"></param>
        /// <param name="propertyName"></param>
        /// <param name="propertyValueRange"></param>
        /// <param name="influencedPtyName"></param>
        /// <param name="influencePtyValueRange"></param>
        /// <param name="constraintRules"></param>
        /// <param name="influencePtyDefaultValue"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static int UpdatePropertyConstraint(int propertyConstraintID, string propertyName, string propertyValueRange,
            string influencedPtyName, string influencePtyValueRange, string constraintRules, string influencePtyDefaultValue, int deviceId)
        {
            int propertyId = GetPtyIdByPtyName(propertyName);
            int influencedPtyId = GetPtyIdByPtyName(influencedPtyName);
            return UpdatePropertyConstraint(propertyConstraintID, propertyId, propertyValueRange, influencedPtyId,
                influencePtyValueRange, constraintRules, influencePtyDefaultValue, deviceId);
        }

        /// <summary>
        /// 根据propertyConstraintID更新约束信息
        /// 可用
        /// </summary>
        /// <param name="propertyConstraintID"></param>
        /// <param name="propertyID"></param>
        /// <param name="propertyValueRange"></param>
        /// <param name="influencedPtyID"></param>
        /// <param name="influencePtyValueRange"></param>
        /// <param name="constraintRules"></param>
        /// <param name="influencePtyDefaultValue"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static int UpdatePropertyConstraint(int propertyConstraintID, int propertyID, string propertyValueRange,
            int influencedPtyID, string influencePtyValueRange, string constraintRules, string influencePtyDefaultValue, int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var propertyConstraint = context.PropertyConstraints
                        .Where(s => s.PropertyConstraintID == propertyConstraintID)
                        .First();

                    propertyConstraint.PropertyID = propertyID;
                    propertyConstraint.PropertyValueIdRange = propertyValueRange;
                    propertyConstraint.InfluencedPtyID = influencedPtyID;
                    propertyConstraint.InfluencedPtyValueIdRange = influencePtyValueRange;
                    propertyConstraint.InfluencedPtyDefaultValue = influencePtyDefaultValue;
                    propertyConstraint.ConstraintRules = constraintRules;
                    propertyConstraint.DeviceID = deviceId;

                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        //根据约束条件的ID删除约束关系
        public static int DeletePropertyConstraint(int propertyConstraintID)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var propertyConstraint = context.PropertyConstraints
                        .Where(s => s.PropertyConstraintID == propertyConstraintID)
                        .First();
                    context.PropertyConstraints.Remove(propertyConstraint);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        } 
        #endregion

        #region 价格约束
        /// <summary>
        /// 插入属性价格约束
        /// </summary>
        /// <param name="propertyID"></param>
        /// <param name="propertyValue"></param>
        /// <param name="influencedPtyID"></param>
        /// <param name="influencedPtyPrice"></param>
        /// <returns></returns>
        public static int InsertIntoPropertyPriceConstraint(int propertyID, string propertyValue, int influencedPtyID, decimal influencedPtyPrice)
        {
            var propertyPriceConstraint = new PropertyPriceConstraint
            {
                PropertyID = propertyID,
                PropertyValue = propertyValue,
                InfluencedPtyID = influencedPtyID,
                InfluencedPtyPrice = influencedPtyPrice
            };
            using (var context = new AnnonContext())
            {
                try
                {
                    context.PropertyPriceConstraints.Add(propertyPriceConstraint);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 更新价格约束
        /// </summary>
        /// <param name="propertyPriceConstraintID"></param>
        /// <param name="propertyID"></param>
        /// <param name="propertyValue"></param>
        /// <param name="influencedPtyID"></param>
        /// <param name="influencedPtyPrice"></param>
        /// <returns></returns>
        public static int UpdatePropertyPriceConstraint(int propertyPriceConstraintID, int propertyID, string propertyValue, int influencedPtyID, decimal influencedPtyPrice)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var propertyPriceConstraint = context.PropertyPriceConstraints
                        .Where(s => s.PropertyPriceConstraintID == propertyPriceConstraintID)
                        .First();
                    propertyPriceConstraint.PropertyID = propertyID;
                    propertyPriceConstraint.PropertyValue = propertyValue;
                    propertyPriceConstraint.InfluencedPtyID = influencedPtyID;
                    propertyPriceConstraint.InfluencedPtyPrice = influencedPtyPrice;

                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 根据价格约束ID删除价格约束
        /// </summary>
        /// <param name="propertyPriceConstraintID"></param>
        /// <returns></returns>
        public static int DeletePropertyPriceConstraint(int propertyPriceConstraintID)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var propertyPriceConstraint = context.PropertyPriceConstraints
                    .Where(s => s.PropertyPriceConstraintID == propertyPriceConstraintID)
                    .First();
                    context.PropertyPriceConstraints.Remove(propertyPriceConstraint);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }

        } 
        #endregion

        #region 属性操作
        
        /// <summary>
        /// 可用
        /// 插入数据表中数据，可以用来将属性数据导入数据库
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="propertyParentID">属性值的父ID</param>
        /// <param name="propertyDefaultValueID">属性值默认值</param>
        /// <param name="propertyType">属性类型</param>
        /// <returns></returns>
        public static int InsertIntoProperty(string propertyName, int propertyParentID, int propertyDefaultValueID, string propertyType)
        {
            var property = new Property
            {
                PropertyName = propertyName,
                PropertyParentID = propertyParentID,
                PropertyDefaultValueID = propertyDefaultValueID,
                PropertyType = propertyType
            };
            using (var context = new AnnonContext())
            {
                try
                {
                    context.Properties.Add(property);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }


        /// <summary>
        /// 可用
        /// 根据设备的Id返回设备对应的属性列表
        /// </summary>
        /// <param name="deviceId">设备ID</param>
        /// <returns></returns>
        public static List<Property> GetPropertiesByDeviceId(int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    //得到该设备的属性数组字符串
                    string propertyStr = (from u in context.Devices
                                          where u.DeviceID == deviceId
                                          select u).First<Device>().PropertyArray;

                    string[] properyArray = propertyStr.Split(',');
                    List<Property> properties = new List<Property>();
                    foreach (var propertyId in properyArray)
                    {
                        int ptyId = Convert.ToInt32(propertyId);
                        Property property = context.Properties
                            .Where(s => s.PropertyID == ptyId)
                            .First();
                        properties.Add(property);
                    }
                    return properties.ToList();

                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// 重载,根据设备的Id和属性类型返回设备对应的属性列表
        /// 可用
        /// </summary>
        /// <param name="deviceId">设备ID</param>
        /// <param name="typeId">属性类型</param>
        /// <returns></returns>
        public static List<Property> GetPropertiesByDeviceId(int deviceId,int typeId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    //得到该设备的属性数组字符串
                    string propertyStr = (from u in context.Devices
                                          where u.DeviceID == deviceId
                                          select u).First<Device>().PropertyArray;

                    string[] properyArray = propertyStr.Split(',');
                    List<Property> properties = new List<Property>();
                    foreach (var propertyId in properyArray)
                    {
                        int ptyId = Convert.ToInt32(propertyId);
                        var property = context.Properties
                            .Where(s => s.PropertyID == ptyId
                            &&s.PropertyParentID==typeId);
                        if (property.Count()>0)
                            properties.Add(property.First());
                    }
                    return properties.ToList();

                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }



        #endregion

    }
}
