using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Annon.Module_Detail
{
   public  class definName
    {
       public string ImgDetailName(int stPosition,int endPosition,string str)
       {
           string imgDeplayName="";
           string starName="";
           string midName="";
           string endName="";
           starName=imgDeplayName.Substring(0, stPosition);
           endName = imgDeplayName.Substring(endPosition, imgDeplayName.Length - endPosition);
           midName.Replace(imgDeplayName.Substring(stPosition, endPosition - stPosition), str);
           imgDeplayName = starName + midName + endName;
           return imgDeplayName;
       }
    }
}
