using System;
using System.Collections.Generic;
using System.Linq;

namespace CadLib.Entity
{
    /// <summary>
    /// 框架信息，俯视图和侧视图的长宽等信息
    /// </summary>
    public class BoxEntity
    {
        public double Width { get; set; }
        public double TopViewHeight { get; set; }
        public double UpHeight { get; set; }
        public double DownHeight { get; set; }
        /// <summary>
        /// 是否靠左
        /// </summary>
        public bool IsLeft { get; set; }
    }
}
