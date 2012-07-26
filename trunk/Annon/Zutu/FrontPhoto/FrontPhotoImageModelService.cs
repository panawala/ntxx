﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Zutu.ImageModel;
using Model.Zutu;

namespace Annon.Zutu.FrontPhoto
{
    public class FrontPhotoImageModelService
    {
        public static int orderSale=0;
        public static int orderId = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageBoxList"></param>
        /// <returns></returns>
        public static List<ImageModel> getImageModelList(List<ImageEntity> imageBoxList)
        {
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
                imageEntity.Rect = new System.Drawing.Rectangle(imageModel.X, imageModel.Y, imageModel.Width, imageModel.Height);
                imageEntity.secondDistance = imageModel.SecondDance;
                imageEntity.Text = imageModel.Text;
                imageEntity.Type = imageModel.Type;
                imageEntity.Url = imageModel.Url;
                imageList.Add(imageEntity);
            }
            return imageList;
        }

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