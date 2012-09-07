using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Zutu.ImageModel;
using Model.Zutu;
using Annon.Xuanxing;

namespace Annon.Zutu.FrontPhoto
{
    public class FrontPhotoImageModelService
    {
        public static int orderSale=0;
        public static int orderId = 0;
        public static OperatePhotoNeedData operatePhotoNeedData;

        public static int currentTagIndex = 0;

        //由于判断进入operatePhoto的路径
        public static string route = "unitBasic";

        public static List<ImageEntity> imageEntityFromAAonRatingList;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageBoxList"></param>
        /// <returns></returns>
        public static List<ImageModel> getImageModelList(List<ImageEntity> imageBoxList)
        {
            imageBoxList = FrontPhotoService.zoomOutImageEntity(imageBoxList, 1 / FrontPhotoService.factor); 
            List<ImageModel> imageModelList = new List<ImageModel>();
            for (int i = 0; i < imageBoxList.Count;i++ )
            {
                ImageModel imageModel = new ImageModel();
                imageModel.Name = imageBoxList.ElementAt(i).Name;
                imageModel.X = imageBoxList.ElementAt(i).Rect.X;
                imageModel.Y = imageBoxList.ElementAt(i).Rect.Y;
                imageModel.Height = imageBoxList.ElementAt(i).Rect.Height;
                imageModel.Width = imageBoxList.ElementAt(i).Rect.Width;
                imageModel.Url = imageBoxList.ElementAt(i).Url;
                imageModel.Text = imageBoxList.ElementAt(i).Text;
                imageModel.ParentName = imageBoxList.ElementAt(i).parentName;
                imageModel.FirstDance = imageBoxList.ElementAt(i).firstDistance;
                imageModel.SecondDance = imageBoxList.ElementAt(i).secondDistance;
                imageModel.Type = imageBoxList.ElementAt(i).Type;
                imageModel.IsSelected = imageBoxList.ElementAt(i).isSelected;
                imageModel.OrderId = orderId;
                imageModel.ModuleTag = imageBoxList.ElementAt(i).moduleTag;
                imageModel.coolingType = imageBoxList.ElementAt(i).coolingType;
                imageModel.Guid = imageBoxList.ElementAt(i).Guid;
                imageModel.ThirdDistance = imageBoxList.ElementAt(i).thirdDistance;
                imageModel.TopViewFirstDistance = imageBoxList.ElementAt(i).topViewFirstDistance;
                imageModel.TopViewSecondDistance = imageBoxList.ElementAt(i).topViewSecondDistance;
                imageModel.ImageWidth = imageBoxList.ElementAt(0).imageWidth;
                imageModelList.Add(imageModel);

            }         
            return imageModelList;
        }
        /// <summary>
        /// 用于双击
        /// </summary>
        /// <param name="imageBoxList"></param>
        /// <returns></returns>
        public static List<ImageModel> getDoubleClickImageModelList(List<ImageEntity> imageBoxList)
        {
            List<ImageModel> imageModelList = new List<ImageModel>();
            for (int i = 0; i < imageBoxList.Count; i++)
            {
                ImageModel imageModel = new ImageModel();
                imageModel.Name = imageBoxList.ElementAt(i).Name;
                imageModel.X = imageBoxList.ElementAt(i).Rect.X;
                imageModel.Y = imageBoxList.ElementAt(i).Rect.Y;
                imageModel.Height = imageBoxList.ElementAt(i).Rect.Height;
                imageModel.Width = imageBoxList.ElementAt(i).Rect.Width;
                imageModel.Url = imageBoxList.ElementAt(i).Url;
                imageModel.Text = imageBoxList.ElementAt(i).Text;
                imageModel.ParentName = imageBoxList.ElementAt(i).parentName;
                imageModel.FirstDance = imageBoxList.ElementAt(i).firstDistance;
                imageModel.SecondDance = imageBoxList.ElementAt(i).secondDistance;
                imageModel.Type = imageBoxList.ElementAt(i).Type;
                imageModel.IsSelected = imageBoxList.ElementAt(i).isSelected;
                imageModel.OrderId = orderId;
                imageModel.ModuleTag = imageBoxList.ElementAt(i).moduleTag;
                imageModel.coolingType = imageBoxList.ElementAt(i).coolingType;
                imageModel.Guid = imageBoxList.ElementAt(i).Guid;
                imageModel.ThirdDistance = imageBoxList.ElementAt(i).thirdDistance;
                imageModel.TopViewFirstDistance = imageBoxList.ElementAt(i).topViewFirstDistance;
                imageModel.TopViewSecondDistance = imageBoxList.ElementAt(i).topViewSecondDistance;
                imageModel.ImageWidth = imageBoxList.ElementAt(0).imageWidth;
                imageModelList.Add(imageModel);

            }
            return imageModelList;
        }
        /// <summary>
        /// 从订单页面打开时，要调用这个函数
        /// </summary>
        /// <param name="imageModelList"></param>
        /// <returns></returns>
        public static List<ImageEntity> getImageEntityFromDataBase(List<ImageModel> imageModelList)
        {
            List<ImageEntity> imageList = new List<ImageEntity>();
            //int height = 0;
            //int width = 0;
            for (int i = 0; i < imageModelList.Count;i++ )
            {
                ImageEntity imageEntity = new ImageEntity();
                ImageModel imageModel=imageModelList.ElementAt(i);
                imageEntity.coolingType = imageModel.coolingType;
                imageEntity.firstDistance = imageModel.FirstDance;
                imageEntity.isSelected = imageModel.IsSelected;
                imageEntity.moduleTag = imageModel.ModuleTag;
                imageEntity.Name = imageModel.Name;
                imageEntity.orderId = imageModel.OrderId;
                imageEntity.parentName = imageModel.ParentName;
                //if (imageModel.Name.Equals("HRA"))
                //{
                //    height = Convert.ToInt32((imageModel.Height - 2) * FrontPhotoService.factor + 2);
                //    width = Convert.ToInt32(imageModel.Width*FrontPhotoService.factor);
                //}
                //else
                //{
                //    height =Convert.ToInt32(imageModel.Height*FrontPhotoService.factor);
                //    width = Convert.ToInt32(imageModel.Width * FrontPhotoService.factor);
                //}
                imageEntity.Rect = new System.Drawing.Rectangle(imageModel.X, imageModel.Y, imageModel.Width, imageModel.Height);
                imageEntity.secondDistance = imageModel.SecondDance;
                imageEntity.Text = imageModel.Text;
                imageEntity.Type = imageModel.Type;
                imageEntity.Url = imageModel.Url;
                imageEntity.Guid = imageModel.Guid;
                imageEntity.thirdDistance = imageModel.ThirdDistance;
                imageEntity.topViewFirstDistance = imageModel.TopViewFirstDistance;
                imageEntity.topViewSecondDistance = imageModel.TopViewSecondDistance;
                imageEntity.imageWidth =Convert.ToInt32(imageModel.ImageWidth);
                imageList.Add(imageEntity);
            }
            imageList = FrontPhotoService.zoomInImangeEntity(imageList,FrontPhotoService.factor);
            return imageList;
        }
        /// <summary>
        /// 2012-9-4
        /// 陈志东
        /// 对图块设备进行排序编号
        /// </summary>
        /// <param name="imageList"></param>
        /// <returns></returns>
        public static List<ImageEntity> getTagModuleImageList(List<ImageEntity> imageList)
        {
            int j = 0;
            List<ImageEntity> downList = new List<ImageEntity>();
            List<ImageEntity> upList = new List<ImageEntity>();

            for (int i = 0; i < imageList.Count; i++)
            {
                if (i == 0)
                {
                    imageList.ElementAt(0).moduleTag = "101-" + imageList.ElementAt(0).parentName;
                    downList.Add(imageList.ElementAt(0));

                }
                else
                {
                    ImageEntity firstDownElement = imageList.ElementAt(0);
                    if ((firstDownElement.Rect.Y == imageList.ElementAt(i).Rect.Y || Math.Abs(firstDownElement.Rect.Y - imageList.ElementAt(i).Rect.Y) < 0.6 * imageList.ElementAt(i).Rect.Height || firstDownElement.Rect.Y - imageList.ElementAt(i).Rect.Y < 0 || imageList.ElementAt(i).Name == "virtualHRA" || FrontPhotoConstraintService.onlyExistDownLayerElement.Contains(imageList.ElementAt(i).Name)) && imageList.ElementAt(i).Name != "HRA")
                    {
                        imageList.ElementAt(i).moduleTag = "1" + (i < 10 ? "0" + (i + 1) + "-" : i + "-") +imageList.ElementAt(i).parentName;
                        downList.Add(imageList.ElementAt(i));
                    }
                    else
                    {
                        j++;
                        imageList.ElementAt(i).moduleTag = "2" + (j < 10 ? "0" + j + "-" : j + "-") + imageList.ElementAt(i).parentName;
                        upList.Add(imageList.ElementAt(i));
                    }
                }             
            }

            //清空imageList
            imageList.Clear();
            for (int i = 0; i < downList.Count; i++)
            {
                imageList.Add(downList.ElementAt(i));
            }
            for (int i = 0; i < upList.Count; i++)
            {
                imageList.Add(upList.ElementAt(i));
            }

            return imageList;
        }

    }
}
