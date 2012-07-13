using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Annon.Zutu
{
    class LeftImageInstrustion
    {

        
        public List<string> getLeftImageInstrustion(string strClassfy,int imageNum)
        {
            List<string> tempList = new List<string>();
            for (int i = 0; i < imageNum; i++)
            {
                tempList.Add("(FAT) Small Flat");
            }
            return tempList;
        }

        //public List<String> getLeftImageInstrustion(string str 
    }
}
