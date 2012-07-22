using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Zutu.ImageModel;
using Model.Zutu;

namespace Annon.Zutu.FrontPhoto
{
    public class FrontPhotoImageModelService
    {
        public static int orderId = 0;
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
                imageModelList.Add(imageModel);

            }
            return imageModelList;
        }
    }
}
