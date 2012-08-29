using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Pintu
{
   public class LWPOLYLINE
    {
       public string LName { get; set; }

       public string lwidth { get; set; }

       public string colornum { get; set; }

       public int PointCount { get; set; }

       public int Flag { get; set; }

       public double[] pointx { get; set; }

       public double[] pointy { get; set; }

       public double[] converxity { get; set; }
    }
}
