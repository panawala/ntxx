using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Zutu;

namespace Model.Pintu
{
   public class TextValue
    {
       public string text { get; set; }
       public DLocation textPosition { get; set; }
       public string value { get; set; }
       public DLocation valuePosition { get; set; }
       public double height { get; set; }
    }
}
