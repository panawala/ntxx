using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Annon.Module_Detail
{
   public  class definName
    {
       public string ImgDetailName(string befStr,int stPosition,int endPosition,string str)
       {
           string imgDeplayName=befStr;
           string starName="";
           string midName="";
           string endName="";
 
           starName=imgDeplayName.Substring(0, stPosition);
           endName = imgDeplayName.Substring(endPosition, imgDeplayName.Length - endPosition);
           midName=imgDeplayName.Substring(stPosition, endPosition - stPosition);
           midName=midName.Replace(midName, str);
           imgDeplayName = starName + midName + endName;
           return imgDeplayName;
       }
    }
}
