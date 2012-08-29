using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Pintu
{
   public class SPLINE
    {
       public string LName { get; set; }

       public string lwidth { get; set; }

       public string colornum { get; set; }

       public int Flag { get; set; }

       public int  Count { get; set; }

       public double[] throughpx { get; set; }

       public double [] throughpy { get; set; }

       public double SVertorX { get; set; }

       public double SVertorY { get; set; }

       public double EVertorX { get; set; }

       public double EVertorY { get; set; }
    }
}
