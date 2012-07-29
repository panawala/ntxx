using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Xuanxing
{
    public class CatalogModel
    {
        /// <summary>
        /// 属性名
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>
        public string Value { get; set; }

        public string Type { get; set; }
        /// <summary>
        /// 属性号
        /// </summary>
        public int SequenceNo { get; set; }



        /// <summary>
        /// 用于判断该属性是否可选（于）
        /// </summary>
        public bool IsSelected { get; set; }
        /// <summary>
        /// 用于判断最终时候可以选取的属性值(于）
        /// </summary>
        public bool ResultValue { get; set; }
        ///// <summary>
        /// 记录其父亲节点（于）
        /// </summary>
        public CatalogModel ParentNode { get; set; }
        /// <summary>
        /// 节点名字（于）
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 父亲节点名字（于）
        /// </summary>
        public string ParentName { get; set; }
    }
}
