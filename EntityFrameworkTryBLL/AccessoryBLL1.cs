using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Device;
using DataContext;

namespace EntityFrameworkTryBLL
{
    public class AccessoryBLL1
    {
        //根据设备ID,属性名称，属性值获得当前的附件，如果没有返回为空
        public static List<Accessory> GetAccessoriesByPtyValue(int deviceid,string propertyName, int propertyValueCodeId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    //找到对应的属性id
                    int ptyId = context.Properties
                        .Where(s => s.PropertyName == propertyName)
                        .Select(s => s.PropertyID)
                        .First();

                    //返回所需要的附件
                    var accessories = context.Accessories
                        .Where(s => s.PropertyID == ptyId
                        &&s.DeviceID==deviceid
                        &&s.PropertyValueCodeId==propertyValueCodeId);
                    return accessories.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        #region 附件表增删改操作
        /// <summary>
        /// 插入附件表
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="propertyId"></param>
        /// <param name="propertyValueCode"></param>
        /// <param name="accessoryName"></param>
        /// <param name="accessoryDescription"></param>
        /// <param name="accessoryPrice"></param>
        /// <param name="accessoryNo"></param>
        /// <returns></returns>
        public static int InsertIntoAccessory(int deviceId, int propertyId, int propertyValueCodeId,
            string accessoryName, string accessoryDescription, decimal accessoryPrice, string accessoryNo)
        {
            var accessory = new Accessory
            {
                DeviceID = deviceId,
                PropertyID = propertyId,
                PropertyValueCodeId = propertyValueCodeId,
                AccessoryName = accessoryName,
                AccessoryDescription = accessoryDescription,
                AcessoryPrice = accessoryPrice,
                AccessoryNo = accessoryNo
            };
            using (var context = new AnnonContext())
            {
                try
                {
                    context.Accessories.Add(accessory);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }


        /// <summary>
        /// 更新附件的值
        /// </summary>
        /// <param name="accessoryId"></param>
        /// <param name="deviceId"></param>
        /// <param name="propertyId"></param>
        /// <param name="propertyValueCode"></param>
        /// <param name="accessoryName"></param>
        /// <param name="accessoryDescription"></param>
        /// <param name="accessoryPrice"></param>
        /// <param name="accessoryNo"></param>
        /// <returns></returns>
        public static int UpdateAccessory(int accessoryId, int deviceId, int propertyId, int propertyValueCodeId,
            string accessoryName, string accessoryDescription, decimal accessoryPrice, string accessoryNo)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var accessory = context.Accessories
                        .Where(s => s.AccessoryID == accessoryId)
                        .First();

                    accessory.DeviceID = deviceId;
                    accessory.PropertyID = propertyId;
                    accessory.PropertyValueCodeId = propertyValueCodeId;
                    accessory.AccessoryName = accessoryName;
                    accessory.AccessoryDescription = accessoryDescription;
                    accessory.AcessoryPrice = accessoryPrice;
                    accessory.AccessoryNo = accessoryNo;

                    return context.SaveChanges();

                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 根据附件id删除附件
        /// </summary>
        /// <param name="accessoryId"></param>
        /// <returns></returns>
        public static int DeleteAccessory(int accessoryId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var accessory = context.Accessories
                        .Where(s => s.AccessoryID == accessoryId)
                        .First();
                    context.Accessories.Remove(accessory);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        } 
        #endregion


    }
}
