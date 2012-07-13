using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using netDxf;
using Model.Zutu;

namespace DxfLib.OperatorEntity
{
   public class TopViewConfigure
    {

        public TopViewConfigure(List<String> imageNameList, DxfDocument dxf, Location location, string[] text, float height, float width, float outer_mid_space, float outer_in_space, float barHeight, float barWidth)
        {
            this.imageNameList = imageNameList;
            this.dxf = dxf;
            this.location = location;
            this.text = text;
            this.height = height;
            this.width = width;
            this.outer_mid_space = outer_mid_space;
            this.outer_in_space = outer_in_space;
            this.barHeight = barHeight;
            this.barWidth = barWidth;
        }

        public List<string> imageNameList
        {
            get;
            set;
        }

        public DxfDocument dxf
        {
            get;
            set;
        }

        public Location location
        {
            get;
            set;
        }

        public string[] text
        {
            get;
            set;
        }

        public float height
        {
            get;
            set;
        }


        public float width
        {
            get;
            set;
        }

        public float outer_mid_space
        {
            get;
            set;
        }

        public float outer_in_space
        {
            get;
            set;
        }

        public float barHeight
        {
            get;
            set;
        }

        public float barWidth
        {
            get;
            set;
        }
    }
}
