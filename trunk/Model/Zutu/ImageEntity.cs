using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Model.Zutu
{
    [Serializable]
    public class ImageEntity
    {
        /// <summary>
        /// 图块名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 图块矩形区域
        /// </summary>
        /// rect里面的width实际上是length
        public Rectangle Rect { get; set; }

        public int imageWidth { get; set; }
        /// <summary>
        /// 图块对应url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 图块对应类型
        /// </summary>
        public string Type { get; set; }

        public string Text
        {
            set;
            get;
        }
        public int coolingType { get; set; }
        public double firstDistance
        {get;set;}
        public double secondDistance
        { get; set;}
        public string moduleTag { set; get; }
        public int orderId { set; get; }

        public bool isSelected {set;get;}

        public string parentName { set; get; }

        public bool HitTest(Point point)
        {
            Region region = new Region(Rect);
            if (region.IsVisible(point))
                return true;
            return false;
        }

        public string Guid { get;set; }
        public double thirdDistance { get; set; }
        public double topViewFirstDistance { get; set; }
        public double topViewSecondDistance { get; set; }
    }
}
