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
                    deleteOrder(imageModels.First().OrderId);
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
        /// 删除某个订单号的订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static int deleteOrder(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var imageModels = context.ImageModels
                        .Where(s => s.OrderId == orderId);
                    if (imageModels != null && imageModels.Count() != 0)
                    {
                        foreach (var imageModel in imageModels)
                        {
                            context.ImageModels.Remove(imageModel);
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

        /// <summary>
        /// 拷贝订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="newOrderId"></param>
        /// <returns></returns>
        public static int copyOrder(int orderId, int newOrderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var imageModels = context.ImageModels
                        .Where(s => s.OrderId == orderId);
                    foreach (var imageModel in imageModels)
                    {
                        context.ImageModels.Add(new ImageModel
                        {
                            Name=imageModel.Name,
                            X=imageModel.X,
                            Y=imageModel.Y,
                            Width=imageModel.Width,
                            Height=imageModel.Height,
                            Url=imageModel.Url,
                            Type=imageModel.Type,
                            Text=imageModel.Text,
                            coolingType=imageModel.coolingType,
                            FirstDance=imageModel.FirstDance,
                            SecondDance=imageModel.SecondDance,
                            ModuleTag=imageModel.ModuleTag,
                            OrderId=newOrderId,
                            IsSelected=imageModel.IsSelected,
                            ParentName=imageModel.ParentName,
                            Guid=imageModel.Guid
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
        /// 根据订单号得到组图的订单列表
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<ImageModel> getImageModel(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var imageModels = context.ImageModels
                        .Where(s => s.OrderId == orderId);
                    return imageModels.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
    }
}
