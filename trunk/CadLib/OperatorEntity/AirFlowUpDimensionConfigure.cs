using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CadLib.OperatorEntity
{
    class AirFlowUpDimensionConfigure
    {
        private static List<AirFlowUpDimension> airFlowList = new List<AirFlowUpDimension>();

        public static List<AirFlowUpDimension> getAirFlowList(){
             airFlowList.Add(new AirFlowUpDimension{coolingType=5,imageName="PEC",topLeftDimension=5,topRightDimension=12,rightDownDimension=5,rightUpDimension=35});
             airFlowList.Add(new AirFlowUpDimension{coolingType=5,imageName="SFC",topLeftDimension=17,topRightDimension=14,rightDownDimension=5,rightUpDimension=35});
             airFlowList.Add(new AirFlowUpDimension{coolingType=8,imageName="PEC",topLeftDimension=5,topRightDimension=16,rightDownDimension=5,rightUpDimension=40});
             airFlowList.Add(new AirFlowUpDimension{coolingType=8,imageName="SFC",topLeftDimension=21,topRightDimension=16,rightDownDimension=5,rightUpDimension=40});
             airFlowList.Add(new AirFlowUpDimension{coolingType=11,imageName="PEC",topLeftDimension=6,topRightDimension=20,rightDownDimension=6,rightUpDimension=50});
             airFlowList.Add(new AirFlowUpDimension{coolingType=11,imageName="SFC",topLeftDimension=16,topRightDimension=20,rightDownDimension=6,rightUpDimension=50});
             airFlowList.Add(new AirFlowUpDimension{coolingType=14,imageName="PEC",topLeftDimension=6,topRightDimension=20,rightDownDimension=6,rightUpDimension=50});
             airFlowList.Add(new AirFlowUpDimension{coolingType=14,imageName="SFC",topLeftDimension=16,topRightDimension=20,rightDownDimension=6,rightUpDimension=50});
             airFlowList.Add(new AirFlowUpDimension{coolingType=18,imageName="EDD",topLeftDimension=4,topRightDimension=20,rightDownDimension=6,rightUpDimension=72});
             airFlowList.Add(new AirFlowUpDimension{coolingType=18,imageName="SDD",topLeftDimension=38,topRightDimension=20,rightDownDimension=6,rightUpDimension=72});
             airFlowList.Add(new AirFlowUpDimension{coolingType=22,imageName="EDD",topLeftDimension=4,topRightDimension=20,rightDownDimension=5,rightUpDimension=74});
             airFlowList.Add(new AirFlowUpDimension{coolingType=22,imageName="SDD",topLeftDimension=4,topRightDimension=20,rightDownDimension=5,rightUpDimension=74});
             airFlowList.Add(new AirFlowUpDimension{coolingType=26,imageName="EDD",topLeftDimension=4,topRightDimension=22,rightDownDimension=5,rightUpDimension=74});
             airFlowList.Add(new AirFlowUpDimension{coolingType=26,imageName="SDD",topLeftDimension=48,topRightDimension=22,rightDownDimension=5,rightUpDimension=74});
            return airFlowList;
        }
        
    }

    class AirFlowUpDimension
    {
        public  int coolingType{get;set;}
        public  string imageName{get;set;}
        public  double topLeftDimension { get; set; }
        public  double topRightDimension { get; set; }
        public  double rightDownDimension { get; set; }
        public  double rightUpDimension { get; set; }

    }
}
