using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataContext;
using Model.Property;
using Model.Device;
using System.Collections;
using System.Data;

namespace EntityFrameworkTryBLL
{
    public class DeviceBLL
    {
        /// <summary>
        /// 返回所有设备类型
        /// </summary>
        /// <returns></returns>
        public static List<Device> GetAllDevices()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    //var devices = from u in context.Devices
                    //              select u;
                    var devices = context.Devices.ToList();
                    return devices.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// 根据当前的订单详情信息，设备信息，属性信息返回当前选中的属性值的valueCode
        /// </summary>
        /// <param name="orderDetailedId"></param>
        /// <param name="deviceId"></param>
        /// <param name="propertyId"></param>
        /// <returns></returns>
        //public static string GetCurrentSelectedValue(int orderDetailedId, int deviceId, int propertyId)
        //{
        //    using (var context = new NorthwindContext())
        //    {
        //        try
        //        {
        //            var currentDevice = context.CurrentDevices
        //                .Where(s => s.OrderDetailID == orderDetailedId && s.DeviceID == deviceId && s.PropertyID == propertyId)
        //                .First();
        //            return currentDevice.PropertyValueId;
        //        }
        //        catch (Exception e)
        //        {
        //            return string.Empty;
        //        }
        //    }

        //}
        /// <summary>
        /// 根据当前订单详情和设备Id初始化所有属性极其值的列表
        /// </summary>
        /// <param name="orderDetailId"></param>
        /// <param name="deviceId"></param>
        //public static void InitialDevices(int orderDetailId, int deviceId)
        //{
        //    using (var context = new NorthwindContext())
        //    {
        //        try
        //        {
        //            //var devices = from u in context.Devices
        //            //              select u;
        //            var device = context.Devices
        //                .Where(s => s.DeviceID == deviceId)
        //                .First();
        //            //得到所有的属性列表
        //            string[] properties = device.PropertyArray.Split(',');
        //            //所有属性对应的属性默认值列表
        //            string[] propertyValuesArray = device.PropertyValueArray.Split(',');
        //            int i = 0;
        //            //对每个属性进行操作
        //            foreach (var property in properties)
        //            {

        //                int propertyId = Convert.ToInt32(property);
        //                //得到每个属性对应的属性值列表
        //                var propertyValues = context.PropertyValues.AsEnumerable()
        //                    .Where(s => s.DeviceID == deviceId && s.PropertyID == propertyId);

        //                string propertyArray = string.Empty;
        //                string propertyRecommandValue = string.Empty;
        //                //遍历每个属性的值的遍历
        //                foreach (var propertyValue in propertyValues)
        //                {
        //                    //得到每个属性的值的代码
        //                    propertyArray += propertyValue.ValueCode;
        //                    propertyArray += ",";
        //                }
        //                propertyArray = propertyArray.Substring(0, propertyArray.LastIndexOf(','));
        //                //逐个添加到CurrentDevice表中
        //                context.CurrentDevices.Add(new CurrentDevice
        //                {
        //                    PropertyID = Convert.ToInt32(property),
        //                    PropertyValueArray = propertyArray,
        //                    OrderDetailID = orderDetailId,
        //                    DeviceID = deviceId,
        //                    //将默认值设进数据库
        //                    //PropertyRecommandValue=propertyValuesArray[i],
        //                    //默认选中值如上，用户自行修改，会显示到数据库中
        //                    PropertyValueCode = propertyValuesArray[i]
        //                });
        //                i++;

        //            }
        //            context.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {

        //        }
        //    }



        //    using (var context = new NorthwindContext())
        //    {
        //        try
        //        {
        //            var currentDevices = context.CurrentDevices
        //                .Where(s => s.DeviceID == deviceId
        //                && s.OrderDetailID == orderDetailId);
        //            foreach (var currentDevice in currentDevices)
        //            {
        //                PropertyBLL.SetCurrentPtyValues(currentDevice.DeviceID, currentDevice.PropertyID, currentDevice.OrderDetailID, currentDevice.PropertyValueCode);
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //        }
        //    }


        //}


        /// <summary>
        /// 根据当前订单ID和设备ID设置初始化当前的设备选择
        /// 初始化
        /// </summary>
        /// <param name="orderDetailId"></param>
        /// <param name="deviceId"></param>
        public static void InitialDevices(int orderDetailId, int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var device = context.Devices
                        .Where(s => s.DeviceID == deviceId)
                        .First();
                    //得到所有的属性列表
                    string[] properties = device.PropertyArray.Split(',');
                    //所有属性对应的属性默认值列表
                    string[] propertyValuesArray = device.PropertyValueArray.Split(',');
                    int i = 0;
                    //对每个属性进行操作
                    foreach (var property in properties)
                    {
                        //得到每个属性对应的属性值列表
                        context.CurrentDevices.Add(new CurrentDevice
                        {
                            PropertyID = Convert.ToInt32(property),
                            OrderDetailID = orderDetailId,
                            DeviceID = deviceId,
                            PropertyValueId = Convert.ToInt32(propertyValuesArray[i])
                        });
                        i++;
                    }
                    context.CurrentDevices.Add(new CurrentDevice 
                    { 
                        PropertyID=44,
                        OrderDetailID=orderDetailId,
                        DeviceID=deviceId,
                        PropertyValueId=547
                    });
                    context.SaveChanges();
                }
                catch (Exception e)
                {

                }
            }

        }


        public static DataTable getOderDetail()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var orderDetailIds = context.CurrentDevices
                        .Select(s => s.OrderDetailID)
                        .Distinct();
                    
                    DataTable dataTable = new DataTable("OderDetail");
                    dataTable.Columns.Add("OrderId",System.Type.GetType("System.String"));
                    dataTable.Columns.Add("DeviceType", System.Type.GetType("System.String"));
                    dataTable.Columns.Add("DeviceId", System.Type.GetType("System.String"));
                    dataTable.Columns.Add("OrderDetail", System.Type.GetType("System.String"));
                    dataTable.Columns.Add("SumPrice", System.Type.GetType("System.Decimal"));
                    
                    foreach (var orderDetailId in orderDetailIds)
                    {
                        string orderStr = string.Empty;
                        decimal sumPrice = 0;
                        var ptyValueArray = context.CurrentDevices
                            .Where(s => s.OrderDetailID == orderDetailId)
                            .Distinct();
                        foreach (var ptyValue in ptyValueArray)
                        {
                            orderStr += ptyValue.PropertyValueId;
                            orderStr += ",";
                            sumPrice += PropertyBLL.getPriceByPtyIdandValue(ptyValue.PropertyID, ptyValue.PropertyValueId, 1);
                        }
                        orderStr = orderStr.Substring(0, orderStr.Length - 1);
                        DataRow dataRow=dataTable.NewRow();
                        dataRow["OrderId"]=orderDetailId;
                        dataRow["DeviceType"] = "设备";
                        dataRow["DeviceId"] = "1";
                        dataRow["OrderDetail"]=orderStr;
                        dataRow["SumPrice"] = sumPrice;
                        dataTable.Rows.Add(dataRow);
                    }
                    return dataTable;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }


        public static void DeleteAllCurrentDevices(int orderId, int deviceId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var currentDevices = context.CurrentDevices
                        .Where(s => s.DeviceID == deviceId
                        && s.OrderDetailID == orderId);
                    foreach (var currentDevice in currentDevices)
                    {
                        context.CurrentDevices.Remove(currentDevice);
                    }
                    context.SaveChanges();
                }
                catch (Exception e)
                { 
                }
            }
        }

       /// <summary>
        /// 在后台配置一台新的设备时。通过给定的deviceId，通过给定的
       /// </summary>
       /// <param name="deviceId"></param>
       /// <param name="deviceName"></param>
       /// <param name="deviceType"></param>
        public static void InitialDeviceConfig(string deviceName,string deviceType)
        {
            //先在设备中增加一条设备记录
            using (var context = new AnnonContext())
            {
                try
                {
                    var devices = context.Devices
                        .Where(s => s.DeviceID == 0);
                    foreach (var device in devices)
                    {
                        device.DeviceName = deviceName;
                        device.DeviceType = deviceType;
                        context.Devices.Add(device);
                        context.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                }
            }

            //初始化设备属性值
            using (var context = new AnnonContext())
            {
                try
                {
                    //得到当前最大的deviceId
                    var deviceId = context.Devices
                        .Select(s => s.DeviceID)
                        .Max();
                    var propertyValues = context.PropertyValues
                        .Where(s => s.DeviceID == 0);
                    foreach (var propertyValue in propertyValues)
                    {
                        propertyValue.DeviceID = deviceId;
                        context.PropertyValues.Add(propertyValue);
                        context.SaveChanges();
                    }
                }
                catch (Exception e)
                { 
                }
            }
        }

        /// <summary>
        /// 根据设备Id，和属性名字得到属性的默认值
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static string GetPtyDefaultValByPtyName(int deviceId, string propertyName)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var propertyId = context.Properties
                        .Where(s => s.PropertyName == propertyName)
                        .First()
                        .PropertyID;

                    var device = context.Devices
                        .Where(s => s.DeviceID == deviceId)
                        .First();

                    var propertyArray = device.PropertyArray.Split(',');
                    var propertyValueArray = device.PropertyValueArray.Split(',');
                    int i = 0;
                    foreach (var property in propertyArray)
                    {
                        if (property.Equals(propertyId))
                        {
                            return propertyValueArray[i];
                        }
                        i++;
                    }
                    return null;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }


        //查找被影响的当前属性的取值范围。交集
        //public static string GetPropertyValueString(int influencedPropertyId,int deviceId,int orderDetailId)
        //{
        //    using (var context = new NorthwindContext())
        //    {
        //        try
        //        {
        //            var propertyIds = context.PropertyConstraints
        //                .Where(s => s.InfluencedPtyID == influencedPropertyId
        //                &&s.DeviceID==deviceId)
        //                .Distinct()
        //                .Select(u => u.PropertyID);

        //            //得到所有当前主动ID的选中值
        //            var currentProperties = context.CurrentDevices.AsEnumerable()
        //                .Where(s => propertyIds.Contains(s.PropertyID)
        //                    &&s.OrderDetailID==orderDetailId
        //                    &&s.DeviceID==deviceId);

        //            List<string> propertyValueStrings = new List<string>();
        //            //在里面寻找所需要的PropertyValueArray
        //            foreach (var currentProperty in currentProperties)
        //            {
        //                var propertyValueArray = context.PropertyConstraints.AsEnumerable()
        //                    .Where(s => s.PropertyID == currentProperty.PropertyID
        //                        &&s.DeviceID==deviceId
        //                        && s.InfluencedPtyID==influencedPropertyId
        //                        && s.PropertyValueRange.Split(',').Contains(currentProperty.PropertyValueCode))
        //                    .Select(u => u.InfluencedPtyValueIdRange)
        //                    .First();
        //                propertyValueStrings.Add(propertyValueArray);
        //            }

        //            //合并交集
        //            string resultString = propertyValueStrings[0];
        //            for (int i = 1; i < propertyValueStrings.Count; i++)
        //            {
        //                resultString = Intersect(resultString, propertyValueStrings[i]);
        //            }
        //            return resultString;
        //        }
        //        catch (Exception e)
        //        {
        //            return string.Empty;
        //        }
        //    }
        //}



        //求两个数组的交集 
        public static string Intersect(string arr1str, string arr2str)
        {
            string[] arr1 = arr1str.Split(',');
            string[] arr2 = arr2str.Split(',');
            Dictionary<string,bool> map=new Dictionary<string,bool>();
            List<string> list = new List<string>();
            foreach (var str in arr1)
            {
                if (!map.Keys.Contains(str))
                {
                    map.Add(str, false);
                }
            }
            foreach (var str in arr2)
            {
                if (map.Keys.Contains(str))
                {
                    map.Remove(str);
                    map.Add(str, true);
                }
            }
            string result = string.Empty;
            foreach (var entry in map)
            {
                if (entry.Value == true)
                {
                    result += entry.Key;
                    result += ",";
                    list.Add(entry.Key);
                }
            }

            return result.Substring(0, result.LastIndexOf(','));

        }


        /// <summary>
        /// 插入设备数据
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="deviceType"></param>
        /// <param name="propertyArray"></param>
        /// <param name="propertyValueArray"></param>
        /// <returns></returns>
        public static int InsertIntoDevice(string deviceName,string deviceType,string propertyArray,string propertyValueArray)
        {
            var device = new Device
            {
                DeviceName = deviceName,
                DeviceType = deviceType,
                PropertyArray = propertyArray,
                PropertyValueArray = propertyValueArray
            };
            using (var context = new AnnonContext())
            {
                try
                {
                    context.Devices.Add(device);
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
