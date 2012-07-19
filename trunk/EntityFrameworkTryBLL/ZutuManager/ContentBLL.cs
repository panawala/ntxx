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
        /// <summary>
        /// 根据冷量，图块名称，属性名，返回图块属性值信息
        /// </summary>
        /// <param name="coolingPower"></param>
        /// <param name="imageName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public List<ContentPropertyValue> getPtyValue(int coolingPower, string imageName, string propertyName)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var contentPtyValues = context.ContentPropertyValues
                        .Where(s => s.CoolingPower == coolingPower
                        && s.ImageName == imageName
                        && s.PropertyName == propertyName);
                    return contentPtyValues.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }


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
                            ValueCodeID=Convert.ToInt32(dataRow["ValueCodeID"].ToString()),
                            Value = dataRow["Value"].ToString(),
                            ValueDescription = dataRow["ValueDescription"].ToString(),
                            Price = Convert.ToDecimal(dataRow["Price"].ToString()),
                            Type = dataRow["Type"].ToString(),
                            Default=dataRow["Default"].ToString(),
                            IsReadOnly=dataRow["IsReadOnly"].ToString()
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


    }
}
