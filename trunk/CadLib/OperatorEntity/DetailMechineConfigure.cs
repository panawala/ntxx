using System;
using System.Collections.Generic;
using System.Linq;
using Model.Zutu;
namespace CadLib.OperatorEntity
{
   public class DetailMechineConfigure
    {
        public DetailMechineConfigure(List<PictureBoxInfo> imageNameList, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space, double barHeight, double barWidth)
        {
            this.imageNameList = imageNameList;
            this.DxfText = DxfText;
            this.height = height;
            this.width = width;
            this.outer_mid_space = outer_mid_space;
            this.outer_in_space = outer_in_space;
            this.barHeight = barHeight;
            this.barWidth = barWidth;
        }
        
        public List<PictureBoxInfo> imageNameList
        {
            get;
            set;
        }
        public string [] DxfText
        {
            get;
            set;
        }

        public double height
        {
            get;
            set;
        }

        public double width
        {
            set;
            get;
        }

        public double outer_mid_space
        {
            get;
            set;
        }

        public double outer_in_space
        {
            get;
            set;
        }

        public double barHeight
        {
            get;
            set;
        }

        public double barWidth
        {
            get;
            set;
        }
    }
}
