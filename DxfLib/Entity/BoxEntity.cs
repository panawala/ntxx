using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DxfLib.Entity
{
    /// <summary>
    /// 框架信息，俯视图和侧视图的长宽等信息
    /// </summary>
    public class BoxEntity
    {
        public float Width { get; set; }
        public float TopViewHeight { get; set; }
        public float UpHeight { get; set; }
        public float DownHeight { get; set; }
        /// <summary>
        /// 是否靠左
        /// </summary>
        public bool IsLeft { get; set; }
    }
}
