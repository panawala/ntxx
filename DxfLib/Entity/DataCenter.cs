using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DxfLib.OperatorEntity;

namespace DxfLib.Entity
{
    public class DataCenter
    {
        public OrderEntity OrderEntity { get; set; }
        public SectionEntity SectionEntity { get; set; }
        public List<string> Configurations { get; set; }
        public DetailMechineConfigure detailMechineConfigure { get; set; }
        public TopViewConfigure topViewConfigure{get;set;}
    }
}
