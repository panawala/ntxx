using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Zutu.ImageModel;
using DataContext;

namespace EntityFrameworkTryBLL.ZutuManager
{
    public class ImageModelBLL
    {
        /// <summary>
        /// 插入数据库一列数据
        /// </summary>
        /// <param name="imageModels"></param>
        /// <returns></returns>
        public static int insertList(List<ImageModel> imageModels)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    foreach (var imageModel in imageModels)
                    {
                        context.ImageModels.Add(imageModel);
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
        /// 根据订单号，得到imagemodel的列表
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<ImageModel> getImageModels(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var imageModels = context.ImageModels
                        .Where(s => s.OrderId == orderId)
                        .ToList();
                    return imageModels;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }


    }
}
