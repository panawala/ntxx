using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DxfLib.Entity
{
    public class DataCenter
    {
        public OrderEntity OrderEntity { get; set; }
        public SectionEntity SectionEntity { get; set; }
        public List<string> Configurations { get; set; }

    }
}
