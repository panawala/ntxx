using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Model.Zutu;

namespace Annon.Zutu.FrontPhoto
{
    class ImageBoxService
    {
        //根据图片名字获取，图片路径
        public static string getImageUrl(string imageName)
        {
            List<string> classificationList = new List<string>() {"blankbox","coil","controlbox","fanbox","filter","heat","hrwheel","mixbox"};
            for (int i = 0; i < classificationList.Count;i++ )
            {
                string graphicPath = "../../image/" + classificationList.ElementAt(i);
                if (Directory.Exists(graphicPath))
                {
                    string[] imagePathArray = Directory.GetFiles(graphicPath);
                    List<string> tempImageFileNameList = getimageFileName(imagePathArray);
                    for (int j = 0; j < tempImageFileNameList.Count;j++ )
                    {
                        if(tempImageFileNameList.ElementAt(j).Contains(imageName)){
                            return graphicPath + "/" + tempImageFileNameList.ElementAt(j)+".JPG";
                        }
                    }
                }
            }
            
            return null;
        }

        private static List<string> getimageFileName(string[] pathArray)
        {
            List<string> imageFileName = new List<string>();
            foreach (string str in pathArray)
            {
                string strTemp = str.Substring(str.LastIndexOf("\\") + 1, str.LastIndexOf(".") - str.LastIndexOf("\\") - 1);
                imageFileName.Add(strTemp);
            }
            return imageFileName;
        }
    }
}
