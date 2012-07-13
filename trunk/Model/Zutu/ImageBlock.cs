﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Zutu
{
    /// <summary>
    /// 组图中图块实体类
    /// </summary>
    public class ImageBlock
    {
        public int ImageBlockId { get; set; }

        //所属的属性名
        public string ParentName { get; set; }
        /// <summary>
        ///冷量取值范围
        /// </summary>
        public int CoolingPower { get; set; }
        public string ImageName { get; set; }
        public float ImageLength { get; set; }
        public float ImageWidth { get; set; }
        public float ImageHeight { get; set; }
    }
}
