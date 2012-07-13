using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Zutu
{
    public class Location
    {
        public Location(float x=0, float y=0, float z=0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        /// <summary>
        /// Y坐标
        /// </summary>
        public float Y
        {
            get { return y; }
            set { y = value; }
        }
        private float y = 0;


        /// <summary>
        /// Z坐标
        /// </summary>
        public float Z
        {
            get { return z; }
            set { z = value; }
        }
        private float z = 0;

        /// <summary>
        /// X坐标
        /// </summary>
        public float X
        {
            get { return x; }
            set { x = value; }
        }
        private float x = 0;

    }
}
