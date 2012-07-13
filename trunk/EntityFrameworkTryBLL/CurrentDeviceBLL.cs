using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Device;
using DataContext;

namespace EntityFrameworkTryBLL
{
    public class CurrentDeviceBLL
    {
        /// <summary>
        /// 添加当前设备
        /// </summary>
        /// <param name="deviceId">设备ID</param>
        /// <param name="propertyId">属性ID</param>
        /// <param name="propertyValueArray">属性值列表</param>
        /// <param name="orderDetailId">订单ID</param>
        /// <param name="propertyValueId">属性当前取值</param>
        public static void InsertIntoCurrentDevice(int deviceId,int propertyId,string propertyValueArray,int orderDetailId,int propertyValueId)
        {
            var currentDevice = new CurrentDevice
            {
                DeviceID = deviceId,
                PropertyID = propertyId,
                PropertyValueArray = propertyValueArray,
                OrderDetailID = orderDetailId,
                PropertyValueId = propertyValueId
            };
            using (var context = new NorthwindContext())
            {
                try
                {
                    context.CurrentDevices.Add(currentDevice);
                    context.SaveChanges();
                }
                catch (Exception e)
                { 
                }
                
            }
 
        }
    }
}
