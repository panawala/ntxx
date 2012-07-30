using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Zutu;

namespace Model.Zutu
{
  public  class PictureBoxInfo
    {
        public string name
        {
            get;
            set;
        }

        public Location location
        {
            get;
            set;
        }

        public DLocation DLocation
        {
            get;
            set;
        }

        public int height
        {
            get;
            set;
        }
      //相当于实际的length
        public int width
        {
            get;
            set;
        }
        public string [] text
        {
            get;
            set;
        }
        public double topViewHeight { set; get; }
        public int coolingType { get; set; }
        public double firstDistance { get; set;}
        public double secondDistance { get; set;}

        public double thirdDistance { get; set; }
        public double topViewFirstDistance { get; set; }
        public double topViewSecondDistance { get; set; }
    }

}
