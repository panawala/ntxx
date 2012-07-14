using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataContext;
using System.Data;
using Model.Zutu;


namespace EntityFrameworkTryBLL.ZutuManager
{
    public class ImageBlockBLL
    {

        /// <summary>
        /// 从datatable将数据导入
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static int InsertIntoPropertyFromExcel(DataTable dataTable)
        {
            using (var context = new NorthwindContext())
            {
                try
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        var imageBlock = new ImageBlock
                        {
                            CoolingPower=Convert.ToInt32(dataRow["CoolingPower"]),
                            ParentName=dataRow["ParentName"].ToString(),
                            ImageName=dataRow["ImageName"].ToString(),
                            ImageLength=float.Parse(dataRow["ImageLength"].ToString()),
                            ImageWidth=float.Parse(dataRow["ImageWidth"].ToString()),
                            ImageHeight=float.Parse(dataRow["ImageHeight"].ToString())
                        };
                        context.ImageBlocks.Add(imageBlock);
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
        /// 删除数据库中所有的图块信息
        /// </summary>
        /// <returns></returns>
        public static int DeleteAll()
        {
            using (var context = new NorthwindContext())
            {
                try
                {
                    var imageBlocks = context.ImageBlocks;
                    foreach (var imageBlock in imageBlocks)
                    {
                        context.ImageBlocks.Remove(imageBlock);
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
        /// 根据冷量和图块的名得到所有的满足条件的图块信息
        /// </summary>
        /// <param name="names"></param>
        /// <param name="coolingPower"></param>
        /// <returns></returns>
        public static List<ImageBlock> getImageBlocksByNames(List<PictureBoxInfo> pictureBoxInfos, int coolingPower)
        {
            using (var context = new NorthwindContext())
            {
                try
                {
                    List<ImageBlock> imageBlocks = new List<ImageBlock>();
                    foreach (var pictureBoxInfo in pictureBoxInfos)
                    {
                        var imageBlock = context.ImageBlocks
                            .Where(s => s.ImageName == pictureBoxInfo.name
                            && s.CoolingPower == coolingPower)
                            .First();
                        imageBlocks.Add(imageBlock);
                    }
                    return imageBlocks;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 重载版本，多了一个宽度
        /// </summary>
        /// <param name="pictureBoxInfos"></param>
        /// <param name="coolingPower"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static List<ImageBlock> getImageBlocksByNames(List<PictureBoxInfo> pictureBoxInfos, int coolingPower, int endPosition)
        {
            using (var context = new NorthwindContext())
            {
                try
                {
                    List<ImageBlock> imageBlocks = new List<ImageBlock>();
                    for (int i = 0; i<=endPosition;i++ )
                    {
                        string name=pictureBoxInfos[i].name;
                        var imageBlock = context.ImageBlocks
                        .Where(s => s.CoolingPower == coolingPower
                        && s.ImageName == name)
                        .First();
                        imageBlocks.Add(imageBlock);
                    }
                    return imageBlocks.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

    }
}
