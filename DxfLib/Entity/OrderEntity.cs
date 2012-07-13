using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DxfLib.Entity
{
    public class OrderEntity
    {

        public OrderEntity(string jobName, string unitTag)
        {
            this.jobName = jobName;
            this.unitTag = unitTag;
        }

        public string JobName
        {
            get { return jobName; }
            set { jobName = value; }
        }
        private string jobName = "JOB 1";

        public string UnitTag
        {
            get { return unitTag; }
            set { unitTag = value; }
        }
        private string unitTag = "UnitTag";


        public string Purchaser
        {
            get { return purchaser; }
            set { purchaser = value; }
        }
        private string purchaser = "purchaser";

        public string Preparer
        {
            get { return preparer; }
            set { preparer = value; }
        }
        private string preparer = "preparer";


        public string PurchaseOrder
        {
            get { return purchaseOrder; }
            set { purchaseOrder = value; }
        }
        private string purchaseOrder = "purchaseOrder";

        public string Engineer
        {
            get { return engineer; }
            set { engineer = value; }
        }
        private string engineer = "engineer";

        public string SeriaNo
        {
            get { return seriaNo; }
            set { seriaNo = value; }
        }
        private string seriaNo = "seriaNo";

        public string ShipOrderNo
        {
            get { return shipOrderNo; }
            set { shipOrderNo = value; }
        }
        private string shipOrderNo = "shipOrderNo";

    }
}
