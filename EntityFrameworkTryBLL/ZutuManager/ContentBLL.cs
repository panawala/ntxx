﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Zutu.Content;
using DataContext;
using System.Data;
using System.Collections;

namespace EntityFrameworkTryBLL.ZutuManager
{
    public class ContentBLL
    {

       /// <summary>
        /// 得到受影响属性的所有数据
       /// </summary>
       /// <param name="propertyName"></param>
       /// <param name="orderId"></param>
       /// <param name="coolingPower"></param>
       /// <param name="imageName"></param>
       /// <param name="guid"></param>
       /// <returns></returns>
        public static List<ContentPropertyValue> getAllByCondition(string propertyName, int orderId,int coolingPower,string imageName,string guid)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<ContentPropertyValue> rtUnitModels = new List<ContentPropertyValue>();
                    //首先得到受影响的属性的名称
                    List<string> influencedPtyNames = getInfluencedPties(propertyName,imageName,coolingPower);
                    if (influencedPtyNames.Count == 0)
                        return null;
                    //遍历受影响的属性
                    foreach (var ifn in influencedPtyNames)
                    {
                        //得到主动属性列表
                        var ptyNames = getPtyNames(ifn,imageName,coolingPower);
                        //得到影响当前属性取值的所有的条件的string组合
                        var conditionStrList = generateCondition(ptyNames, orderId, guid, coolingPower);
                        var unitModels = context.ContentPropertyValues
                            .Where(s => s.PropertyName == ifn
                            &&s.ImageName==imageName
                            &&s.CoolingPower==coolingPower);
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

                        string options = string.Empty;
                        //得到当前受影响属性的所有选项
                        foreach (var rtu in rtUnitModels.Where(s=>s.PropertyName.Trim()==ifn))
                        {
                            options += rtu.Value + ",";
                        }
                        //options = options.Substring(0, options.Length - 1);
                        saveOptions(ifn, orderId, coolingPower, imageName, guid, options);

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
        /// 保存选项
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="orderId"></param>
        /// <param name="coolingPower"></param>
        /// <param name="imageName"></param>
        /// <param name="guid"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        private static int saveOptions(string propertyName, int orderId, int coolingPower, string imageName, string guid,string options)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var contentCurrentValue = context.ContentCurrentValues
                        .Where(s => s.OrderID == orderId
                        && s.ImageName == imageName
                        && s.PropertyName == propertyName
                        && s.Guid == guid)
                        .First();
                    if (!options.Split(',').Contains(contentCurrentValue.Value))
                        contentCurrentValue.Value = options.Split(',').First();
                    contentCurrentValue.Items = options;
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 根据一列属性名得到属性的取值配对,这里通过订单号和moduleTag定位一个图块
        /// </summary>
        /// <param name="propertyNames"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        private static List<string> generateCondition(List<string> propertyNames, int orderId,string guid,int coolingPower)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<string> ptyValues = new List<string>();
                    foreach (var propertyName in propertyNames)
                    {
                        var unitValue = context.ContentCurrentValues
                        .Where(s => s.OrderID == orderId
                        && s.PropertyName == propertyName
                        &&s.Guid==guid
                        &&s.CoolingPower==coolingPower)
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
        /// 根据约束表，查看受一个属性影响的所有的被动属性,这里约束可以作用到每个图块
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private static List<string> getInfluencedPties(string propertyName,string imageName,int coolingPower)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<string> propertyNames = context.ContentConstraints
                        .Where(s => s.PropertyName == propertyName
                        &&s.ImageName==imageName
                        &&s.CoolingPower==coolingPower)
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
        /// 根据被动属性，得到主动属性的列表,约束作用到每个图块
        /// </summary>
        /// <param name="influencedPropertyName"></param>
        /// <returns></returns>
        private static List<string> getPtyNames(string influencedPropertyName, string imageName,int coolingPower)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<string> propertyNames = context.ContentConstraints.AsEnumerable()
                        .Where(s => s.InfluencedPropertyName == influencedPropertyName
                        && s.ImageName == imageName
                        &&s.CoolingPower==coolingPower)
                        .Select(s => s.PropertyName.Trim())
                        .ToList();
                    return propertyNames;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }




        #region 图块属性值操作
        /// <summary>
        /// 根据冷量，图块名称，属性名，返回图块属性值信息
        /// </summary>
        /// <param name="coolingPower"></param>
        /// <param name="imageName"></param>
        /// <param name="propertyName"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static List<ContentPropertyValue> getPtyValue(int coolingPower, string imageName, string propertyName, string guid)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    List<ContentPropertyValue> cdvs = new List<ContentPropertyValue>();
                    var options=getOptions(coolingPower,imageName,propertyName,guid);
                    var contentPtyValues = context.ContentPropertyValues.AsEnumerable()
                        .Where(s => s.CoolingPower == coolingPower
                        && s.ImageName == imageName
                        && s.PropertyName.Trim() == propertyName.Trim()
                        && options.Split(',').Contains(s.Value));
                    foreach (var contentPtyValue in contentPtyValues)
                    {
                        var value = GetValueByOrder(guid, coolingPower, propertyName, imageName);
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
        /// 得到当前某个属性的选项
        /// </summary>
        /// <param name="coolingPower"></param>
        /// <param name="imageName"></param>
        /// <param name="propertyName"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        private static string getOptions(int coolingPower, string imageName, string propertyName, string guid)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var currentValue = context.ContentCurrentValues
                        .Where(s => s.CoolingPower == coolingPower
                        && s.ImageName == imageName
                        && s.PropertyName == propertyName
                        && s.Guid == guid)
                        .First()
                        .Items;
                    return currentValue;
                }
                catch (Exception e)
                {
                    return string.Empty;
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
        /// 删除某个orderId的订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static int DeleteCurrentValues(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var currentValues = context.ContentCurrentValues
                        .Where(s => s.OrderID==orderId);
                    foreach (var cv in currentValues)
                    {
                        context.ContentCurrentValues.Remove(cv);
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
        /// 初始化一个图块的订单，每次初始化都要先删除相同orderID的已存在的记录,
        /// 每次初始化如果已经存在，则更新moudleTag,       如果不存在则增加订单
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="coolingPower"></param>
        /// <param name="imageName"></param>
        /// <param name="orderId"></param>
        /// <param name="moduleTag"></param>
        /// <returns></returns>
        public static int InitialImageOrder(string guid, int coolingPower, string imageName, int orderId,string moduleTag)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var imageOrders = context.ContentCurrentValues
                        .Where(s => s.Guid == guid
                        &&s.CoolingPower==coolingPower
                        &&s.ImageName==imageName
                        &&s.OrderID==orderId);
                    //如果存在此订单，则更新moduleTag，如果不存在则增加
                    if(imageOrders.Count()!=0)
                    {
                        foreach (var io in imageOrders)
                        {
                            io.ModuleTag = moduleTag;
                        }
                        return context.SaveChanges();
                    }
                        
                    //如果不存在则新增
                    var contentPropertyValues = context.ContentPropertyValues
                        .Where(s => s.CoolingPower == coolingPower
                        && s.ImageName == imageName)
                        .Select(s => new
                        {
                            PropertyName = s.PropertyName,
                            Default = s.Default,
                            Value = s.Value
                        });

                    //得到所有选项
                    string options = string.Empty;
                    Hashtable hashTable = new Hashtable();
                    foreach (var cpv in contentPropertyValues)
                    {
                        if (hashTable.Contains(cpv.PropertyName))
                            hashTable[cpv.PropertyName] += cpv.Value + ",";
                        else
                            hashTable[cpv.PropertyName] = cpv.Value + ",";
                    }
                    //options = options.Substring(0, options.Length - 1);

                    var cotentPtyValues = contentPropertyValues
                        .Select(s => new { PropertyName = s.PropertyName, Default = s.Default })
                        .Distinct();

                    foreach (var cpv in cotentPtyValues)
                    {
                        var contentCurrentValue = new ContentCurrentValue
                        {
                            Guid = guid,
                            PropertyName = cpv.PropertyName,
                            //当前选中为默认值
                            Value = cpv.Default,
                            ImageName = imageName,
                            CoolingPower = coolingPower,
                            OrderID = orderId,
                            Items=hashTable[cpv.PropertyName].ToString(),
                            ModuleTag=moduleTag
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
        /// 图块内容保存订单,此时moudletag不会在变
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="coolingPower"></param>
        /// <param name="imageName"></param>
        /// <param name="orderId"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int SaveImageOrder(string guid, int coolingPower, string imageName, int orderId, string propertyName, string value)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var contentCurrentValue = context.ContentCurrentValues
                        .Where(s => s.Guid==guid
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
        /// 查找订单当前的值，根据订单的guid
        /// </summary>
        /// <param name="moduleTag"></param>
        /// <param name="coolingPower"></param>
        /// <param name="imageName"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        private static string GetValueByOrder(string guid,int coolingPower,string propertyName,string imageName)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var contentCurrentValue = context.ContentCurrentValues
                        .Where(s => s.Guid==guid
                        &&s.CoolingPower==coolingPower
                        &&s.PropertyName==propertyName
                        &&s.ImageName==imageName)
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

        /// <summary>
        /// 将临时表复制到订单表中，在最终需要到订单时保存时需要
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static int copyCurrentToOrder(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    //先要删除对应orderId的订单
                    deleteOrder(orderId);
                    var contentCurrentValues = context.ContentCurrentValues
                        .Where(s => s.OrderID == orderId);
                    //将临时表数据复制到订单中
                    foreach (var ccv in contentCurrentValues)
                    {
                        context.ContentOrders.Add(new ContentOrder
                            {
                                ModuleTag = ccv.ModuleTag,
                                PropertyName = ccv.PropertyName,
                                Value = ccv.Value,
                                ImageName = ccv.ImageName,
                                CoolingPower = ccv.CoolingPower,
                                OrderID = ccv.OrderID,
                                Guid=ccv.Guid,
                                Price=ccv.Price,
                                Items=ccv.Items
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
        /// 把订单信息复制给临时表，以供修改，在打开已有项目时需要，
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static int copyOrderToCurrentValue(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    //先要删除临时表
                    DeleteCurrentValues(orderId);
                    var contentOrders = context.ContentOrders
                        .Where(s => s.OrderID == orderId);
                    //将临时表数据复制到订单中
                    foreach (var ccv in contentOrders)
                    {
                        context.ContentCurrentValues.Add(new ContentCurrentValue
                        {
                            ModuleTag = ccv.ModuleTag,
                            PropertyName = ccv.PropertyName,
                            Value = ccv.Value,
                            ImageName = ccv.ImageName,
                            CoolingPower = ccv.CoolingPower,
                            OrderID = ccv.OrderID,
                            Guid=ccv.Guid,
                            Price=ccv.Price
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
        /// 删除某个orderId的订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static int deleteOrder(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var unitOrders = context.ContentOrders
                        .Where(s => s.OrderID == orderId);
                    foreach (var unitOrder in unitOrders)
                    {
                        context.ContentOrders.Remove(unitOrder);
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
        /// 拷贝订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="newOrderId"></param>
        /// <returns></returns>
        public static int copyOrder(int orderId,int newOrderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var catlogOrders = context.ContentOrders
                        .Where(s => s.OrderID == orderId);
                    foreach (var catlog in catlogOrders)
                    {
                        context.ContentOrders.Add(new ContentOrder
                        {
                            PropertyName = catlog.PropertyName,
                            OrderID=newOrderId,
                            Value = catlog.Value,
                            ModuleTag=catlog.ModuleTag,
                            ImageName=catlog.ImageName,
                            CoolingPower=catlog.CoolingPower,
                            Price=catlog.Price,
                            Guid=catlog.Guid,
                            Items=catlog.Items
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
        /// 删除对应的订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static int deleteRespondOrder(int orderId)
        {
            DeleteCurrentValues(orderId);
            return deleteOrder(orderId);
        }

        /// <summary>
        /// 根据订单号得到图块内容订单列表
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<ContentOrder> getContentOrders(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var contentOrders = context.ContentOrders
                        .Where(s => s.OrderID == orderId);
                    return contentOrders.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
    }
}
