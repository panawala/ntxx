using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DxfLib.Entity
{
    public class SectionEntity
    {
        public SectionEntity(string filterValue, string coolValue)
        {
            this.filterValue = filterValue;
            this.coolValue = coolValue;
        }
        public string FilterValue
        {
            get { return filterValue; }
            set { filterValue = value; }
        }
        private string filterValue = "40";

        public string CoolValue
        {
            get { return coolValue; }
            set { coolValue = value; }
        }
        private string coolValue = "60";
    }
}
