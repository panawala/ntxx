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





    }
}
