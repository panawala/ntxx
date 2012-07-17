using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Zutu
{
    public class DLocation
    {
        public DLocation(double x = 0, double y = 0, double z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        /// <summary>
        /// Y坐标
        /// </summary>
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        private double y = 0;


        /// <summary>
        /// Z坐标
        /// </summary>
        public double Z
        {
            get { return z; }
            set { z = value; }
        }
        private double z = 0;

        /// <summary>
        /// X坐标
        /// </summary>
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        private double x = 0;

    }
}
