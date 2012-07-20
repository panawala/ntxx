using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Zutu.Content;
using DataContext;
using System.Data;

namespace EntityFrameworkTryBLL.ZutuManager
{
    public class ContentBLL
    {
        #region 图块属性值操作
       /// <summary>
        /// 根据冷量，图块名称，属性名，返回图块属性值信息
       /// </summary>
       /// <param name="coolingPower"></param>
       /// <param name="imageName"></param>
       /// <param name="orderId"></param>
       /// <param name="moduleTag"></param>
       /// <returns></returns>
        public static List<ContentPropertyValue> getPtyValue(int coolingPower, string imageName, int orderId,string propertyName,string moduleTag)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<ContentPropertyValue> cdvs = new List<ContentPropertyValue>();
                    var contentPtyValues = context.ContentPropertyValues
                        .Where(s => s.CoolingPower == coolingPower
                        && s.ImageName == imageName
                        &&s.PropertyName==propertyName);
                    foreach (var contentPtyValue in contentPtyValues)
                    {
                        var value = GetValueByOrder(moduleTag, coolingPower, imageName, orderId);
                        contentPtyValue.Default = value;
                        cdvs.Add(contentPtyValue);
                    }

                    return cdvs;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 删除所有图块内容
        /// </summary>
        /// <returns></returns>
        public static int DeleteAll()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var contentPtyValues = context.ContentPropertyValues;
                    foreach (var contentptyValue in contentPtyValues)
                    {
                        context.ContentPropertyValues.Remove(contentptyValue);
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
        /// 从excel导数据进来
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
                        var propertyValue = new ContentPropertyValue
                        {
                            CoolingPower = Convert.ToInt32(dataRow["CoolingPower"].ToString()),
                            ImageName = dataRow["ImageName"].ToString(),
                            PropertyName = dataRow["PropertyName"].ToString(),
                            ValueCodeID = Convert.ToInt32(dataRow["ValueCodeID"].ToString()),
                            Value = dataRow["Value"].ToString(),
                            ValueDescription = dataRow["Value"].ToString() + "=" + dataRow["ValueDescription"].ToString(),
                            Price = Convert.ToDecimal(dataRow["Price"].ToString()),
                            Type = dataRow["Type"].ToString(),
                            Default = dataRow["Default"].ToString(),
                            IsReadOnly = dataRow["IsReadOnly"].ToString()
                        };
                        context.ContentPropertyValues.Add(propertyValue);
                    }
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }

        } 
        #endregion


        #region 图块内容操作
        /// <summary>
        /// 初始化一个图块的订单
        /// </summary>
        /// <param name="moduleTag"></param>
        /// <param name="coolingPower"></param>
        /// <param name="imageName"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static int InitialImageOrder(string moduleTag, int coolingPower, string imageName, int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var contentProperyValues = context.ContentPropertyValues
                        .Where(s => s.CoolingPower == coolingPower
                        && s.ImageName == imageName)
                        .Distinct();

                    foreach (var cpv in contentProperyValues)
                    {
                        var contentCurrentValue = new ContentCurrentValue
                        {
                            ModuleTag = moduleTag,
                            PropertyName = cpv.PropertyName,
                            //当前选中为默认值
                            Value = cpv.Default,
                            ImageName = imageName,
                            CoolingPower = coolingPower,
                            OrderID = orderId
                        };
                        context.ContentCurrentValues.Add(contentCurrentValue);
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
        /// 图块内容保存订单
        /// </summary>
        /// <param name="moduleTag"></param>
        /// <param name="coolingPower"></param>
        /// <param name="imageName"></param>
        /// <param name="orderId"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int SaveImageOrder(string moduleTag, int coolingPower, string imageName, int orderId, string propertyName, string value)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var contentCurrentValue = context.ContentCurrentValues
                        .Where(s => s.ModuleTag == moduleTag
                        && s.CoolingPower == coolingPower
                        && s.ImageName == imageName
                        && s.OrderID == orderId
                        && s.PropertyName == propertyName)
                        .First();
                    contentCurrentValue.Value = value;
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 查找订单当前的值
        /// </summary>
        /// <param name="moduleTag"></param>
        /// <param name="coolingPower"></param>
        /// <param name="imageName"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static string GetValueByOrder(string moduleTag, int coolingPower, string imageName, int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var contentCurrentValue = context.ContentCurrentValues
                        .Where(s => s.ModuleTag == moduleTag
                        && s.CoolingPower == coolingPower
                        && s.ImageName == imageName
                        && s.OrderID == orderId)
                        .First()
                        .Value;
                    return contentCurrentValue;
                }
                catch (Exception e)
                {
                    return string.Empty;
                }
            }
        }
        #endregion
    }
}
