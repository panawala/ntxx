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
    }

}
