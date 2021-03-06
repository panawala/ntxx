﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using netDxf;
using Model.Zutu;
namespace DxfLib.OperatorEntity
{
   public class DetailMechineConfigure
    {
        public DetailMechineConfigure(List<PictureBoxInfo> imageNameList, string[] text, float height, float width, float outer_mid_space, float outer_in_space, float barHeight, float barWidth)
        {
            this.imageNameList = imageNameList;
            this.text = text;
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
        public string [] text
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
            set;
            get;
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
