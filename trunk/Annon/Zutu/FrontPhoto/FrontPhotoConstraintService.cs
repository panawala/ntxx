using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Zutu;

namespace Annon.Zutu.FrontPhoto
{
    class FrontPhotoConstraintService
    {         
        //1、Coil 只能在第一层2、Heat 只能在第一层3、Fan Box中SFA、SFB、SFC（送风机）只能在第一层        
        private static string[] onlyExistLayerElement = { "CLB", "CLC", "CLD", "CLF", "CLG", "CLI", "CLM", "PHA", "PHB", "PHC", "PHD", "SFA","SFB","SFC" };
        public static List<string> onlyExistDownLayerElement = onlyExistLayerElement.ToList<string>();
        //1、【Control Box】不能放在端部
        public static List<string> controlBoxList = new List<string>() {"TRA","TRB","TRC","TRD","TRE" };
        //Heat部件
        public static List<string> heatList = new List<string>() { "PHA", "PHB", "PHC", "PHD"};
        //Mixing Box
        public static List<string> mixingBoxList = new List<string> {"MBA","MBB","MBC","MBD","MBE","MBF","MBH","MBI","MBJ","MBK" };
        //Fan Box
        public static List<string> fanBoxList = new List<string> { "PEA","PEC","RFA"};
        public static int getFirstElementPosition(List<ImageEntity> imageBoxList)
        {
            List<ImageEntity> downList = new List<ImageEntity>();
            List<ImageEntity> upList = new List<ImageEntity>();
            for (int i = 0; i < imageBoxList.Count; i++)
            {
                if (i == 0)
                {
                    downList.Add(imageBoxList.ElementAt(0));

                }
                else
                {
                    ImageEntity firstDownElement = imageBoxList.ElementAt(0);
                    if ((firstDownElement.Rect.Y == imageBoxList.ElementAt(i).Rect.Y && imageBoxList.ElementAt(i).Name != "HRA"))
                    {
                        downList.Add(imageBoxList.ElementAt(i));
                    }
                    else
                    {
                        upList.Add(imageBoxList.ElementAt(i));
                    }
                }
            }
            //如果存在上层，就记录下上层第一个元素的位置
            int upFirstElement=-1;
            if (upList.Count > 0)
            {
                upFirstElement = downList.Count;
                return upFirstElement;
            }
            else
            {
                upFirstElement = -1;
                return upFirstElement;
            }        
        }
        //ControlBox是否在端部
        public static bool isControlBoxStartEnd(List<ImageEntity> imageBoxList)
        {
            int upFirstElement = getFirstElementPosition(imageBoxList);
            if (upFirstElement != -1)
            {
                if (controlBoxList.Contains(imageBoxList.ElementAt(upFirstElement).Name))
                {
                    return true;
                }
                else if (controlBoxList.Contains(imageBoxList.ElementAt(upFirstElement - 1).Name))
                {
                    return true;
                }
                else if(controlBoxList.Contains(imageBoxList.ElementAt(0).Name)){
                    return true;
                }
                else if(controlBoxList.Contains(imageBoxList.ElementAt(imageBoxList.Count-1).Name)){
                    return true;
                }
                return false;
            }
            else
            {
                if (controlBoxList.Contains(imageBoxList.ElementAt(0).Name))
                {
                    return true;
                }
                else if (controlBoxList.Contains(imageBoxList.ElementAt(imageBoxList.Count - 1).Name))
                {
                    return true;
                }
               
                    return false; 
            }
        }
        //2、第二层端部模块的位置不能超出了第一层
        public static bool isUpLayerExceedDownLayer(List<ImageEntity> imageBoxList)
        {
            int upFirstElement = getFirstElementPosition(imageBoxList);
            if (upFirstElement != -1)
            {
                if (imageBoxList.ElementAt(upFirstElement).Rect.X < imageBoxList.ElementAt(0).Rect.X)
                {
                    return true;
                }
                else if(imageBoxList.ElementAt(imageBoxList.Count-1).Rect.X+imageBoxList.ElementAt(imageBoxList.Count-1).Rect.Width>imageBoxList.ElementAt(upFirstElement-1).Rect.X+imageBoxList.ElementAt(upFirstElement-1).Rect.Width)
                {
                    return true;
                }
                
            }
            return false;
        }
        //3、如果【Coil】选择了CLG，则只要系统中有【Heat】部件，则必须有【Control Box】模块
        public static bool isMustChoiceControlBox(List<ImageEntity> imageBoxList)
        {
            bool clgFlag=false ;
            bool heatFlag=false ;
            for (int i = 0; i < imageBoxList.Count; i++)
            {
                if (imageBoxList.ElementAt(i).Name.Equals("CLG"))
                {
                    clgFlag = true;
                }
                if (heatList.Contains(imageBoxList.ElementAt(i).Name))
                {
                    heatFlag = true;
                }
                if (clgFlag && heatFlag)
                {
                    return true;
                }
            }
            return false;
        }

        //1、 在送风方向由左向右，在第二层【Mixing Box】不建议放在【Fan Box】左边
        public static bool isMixingExistFanRight(List<ImageEntity> imageBoxList)
        {
            int upFirstElement = getFirstElementPosition(imageBoxList);
            int mixingBoxX=0;
            int fanBoxX=0;
            if (upFirstElement != -1)
            {
                for (int i = 0; i < imageBoxList.Count; i++)
                {
                    if (mixingBoxList.Contains(imageBoxList.ElementAt(i).Name))
                    {
                        mixingBoxX = imageBoxList.ElementAt(i).Rect.X;
                    }
                    else if(fanBoxList.Contains(imageBoxList.ElementAt(i).Name)){
                        fanBoxX = imageBoxList.ElementAt(i).Rect.X;
                    }
                }
                if (mixingBoxX < fanBoxX)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;   
        }
    }
}
