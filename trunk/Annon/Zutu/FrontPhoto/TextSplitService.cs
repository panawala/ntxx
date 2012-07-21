using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Annon.Zutu.FrontPhoto
{
    class TextSplitService
    {
        public static string[] textSplit(string text)
        {
            if (text != null)
            {
                string[] tempText = text.Split(' ');
                return tempText;
            }
            else
            {
                return new string[] {"DataBase","can't","text,please","check your","database" };
            }
            
        }
    }
}
