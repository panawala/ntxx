using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataContext;
using Model.Device;

namespace EntityFrameworkTryBLL.XuanxingManager
{
    public class AccessoryBLL
    {
        /// <summary>
        /// 插入一条附件记录
        /// </summary>
        /// <param name="accessoryNo"></param>
        /// <param name="accessoryName"></param>
        /// <param name="quantity"></param>
        /// <param name="accessoryPrice"></param>
        /// <param name="deviceId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static int InsertIntoAccessory(string accessoryNo, string accessoryName,
            string quantity, decimal accessoryPrice, int deviceId,int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var accessory = new Accessory()
                    {
                        AccessoryNo = accessoryNo,
                        AccessoryName = accessoryName,
                        AccessoryDescription = quantity,
                        AcessoryPrice = accessoryPrice,
                        DeviceID = deviceId,
                        PropertyID = orderId
                    };
                    context.Accessories.Add(accessory);
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
