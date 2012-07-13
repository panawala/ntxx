using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Property
{
    public class PropertyPriceConstraint
    {
        public int PropertyPriceConstraintID { get; set; }
        public int PropertyID { get; set; }
        public string PropertyValue { get; set; }
        public int InfluencedPtyID { get; set;}
        public string InfluencedPtyValue { get; set; }
        //被影响的价格
        public decimal InfluencedPtyPrice { get; set; }
    }
}
