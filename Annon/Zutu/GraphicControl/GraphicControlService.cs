using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Annon.ZuTu.GraphicControl
{
    class GraphicControlService
    {
        public static List<string> getGraphicText(string classification)
        {
            string graphicPath = "../../image/" + classification;
            if (Directory.Exists(graphicPath))
            {
                string[] imagePathArray = Directory.GetFiles(graphicPath);
                List<string> tempImageFileNameList = getimageFileName(imagePathArray);
                return tempImageFileNameList;
            }
            return null;
        }

        //提取图评路径中文件的名称
        private static List<string> getimageFileName(string[] pathArray)
        {
            List<string> imageFileName = new List<string>();
            foreach (string str in pathArray)
            {
                string strTemp = str.Substring(str.LastIndexOf("\\") + 1, str.LastIndexOf(".") - str.LastIndexOf("\\") - 1);
                imageFileName.Add(strTemp);
            }
            return imageFileName;
        }

        public static List<GraphicText> initBlankBox()
        {
            List<string> graphicTextList = getGraphicText("blankbox");
            List<GraphicText> tempBlankBoxList = new List<GraphicText>();
            for (int i = 0, len = graphicTextList.Count; i < len; i++)
            {
                GraphicText gc = new GraphicText();
                gc.classification = "blankbox";
                gc.realLetterAndNumName =graphicTextList.ElementAt(i);
                gc.virtualTextName = "pblankbox" + i;
                tempBlankBoxList.Add(gc);
            }
            return tempBlankBoxList;
        }

        public static List<GraphicText> initCoil()
        {
            List<string> graphicTextList = getGraphicText("coil");
            List<GraphicText> tempBlankBoxList = new List<GraphicText>();
            for (int i = 0, len = graphicTextList.Count; i < len; i++)
            {
                GraphicText gc = new GraphicText();
                gc.classification = "coil";
                gc.realLetterAndNumName = graphicTextList.ElementAt(i);
                gc.virtualTextName = "pcoil" + i;
                tempBlankBoxList.Add(gc);
            }
            return tempBlankBoxList;
        }

        public static List<GraphicText> initControlBox()
        {
            List<string> graphicTextList = getGraphicText("controlbox");
            List<GraphicText> tempBlankBoxList = new List<GraphicText>();
            for (int i = 0, len = graphicTextList.Count; i < len; i++)
            {
                GraphicText gc = new GraphicText();
                gc.classification = "controlbox";
                gc.realLetterAndNumName = graphicTextList.ElementAt(i);
                gc.virtualTextName = "pcontrolbox" + i;
                tempBlankBoxList.Add(gc);
            }
            return tempBlankBoxList;
        }

        public static List<GraphicText> initFanBox()
        {
            List<string> graphicTextList = getGraphicText("fanbox");
            List<GraphicText> tempBlankBoxList = new List<GraphicText>();
            for (int i = 0, len = graphicTextList.Count; i < len; i++)
            {
                GraphicText gc = new GraphicText();
                gc.classification = "fanbox";
                gc.realLetterAndNumName = graphicTextList.ElementAt(i);
                gc.virtualTextName = "pfanbox" + i;
                tempBlankBoxList.Add(gc);
            }
            return tempBlankBoxList;
        }

        public static List<GraphicText> initFilter()
        {
            List<string> graphicTextList = getGraphicText("filter");
            List<GraphicText> tempBlankBoxList = new List<GraphicText>();
            for (int i = 0, len = graphicTextList.Count; i < len; i++)
            {
                GraphicText gc = new GraphicText();
                gc.classification = "filter";
                gc.realLetterAndNumName = graphicTextList.ElementAt(i);
                gc.virtualTextName = "pfilter" + i;
                tempBlankBoxList.Add(gc);
            }
            return tempBlankBoxList;
        }

        public static List<GraphicText> initHeat()
        {
            List<string> graphicTextList = getGraphicText("heat");
            List<GraphicText> tempBlankBoxList = new List<GraphicText>();
            for (int i = 0, len = graphicTextList.Count; i < len; i++)
            {
                GraphicText gc = new GraphicText();
                gc.classification = "heat";
                gc.realLetterAndNumName = graphicTextList.ElementAt(i);
                gc.virtualTextName = "pheat" + i;
                tempBlankBoxList.Add(gc);
            }
            return tempBlankBoxList;
        }

        public static List<GraphicText> initHrWheel()
        {
            List<string> graphicTextList = getGraphicText("hrwheel");
            List<GraphicText> tempBlankBoxList = new List<GraphicText>();
            for (int i = 0, len = graphicTextList.Count; i < len; i++)
            {
                GraphicText gc = new GraphicText();
                gc.classification = "hrwheel";
                gc.realLetterAndNumName = graphicTextList.ElementAt(i);
                gc.virtualTextName = "phrwheel" + i;
                tempBlankBoxList.Add(gc);
            }
            return tempBlankBoxList;
        }

        public static List<GraphicText> initMixBox()
        {
            List<string> graphicTextList = getGraphicText("mixbox");
            List<GraphicText> tempBlankBoxList = new List<GraphicText>();
            for (int i = 0, len = graphicTextList.Count; i < len; i++)
            {
                GraphicText gc = new GraphicText();
                gc.classification = "mixbox";
                gc.realLetterAndNumName = graphicTextList.ElementAt(i);
                gc.virtualTextName = "pmixbox" + i;
                tempBlankBoxList.Add(gc);
            }
            return tempBlankBoxList;
        }

        public static List<string> getGraphicTextList(string classification)
        {
            List<GraphicText> tempList = initLeftGraphicText(classification);
            List<string> tempList2 = new List<string>();
            for (int i = 0, len = tempList.Count; i < len; i++)
            {
                tempList2.Add(tempList.ElementAt(i).realLetterAndNumName.ToString());
            }
            return tempList2;
        }

        public static List<GraphicText> initLeftGraphicText(string classification)
        {
            switch (classification){
                case "blankbox": return initBlankBox();
                case "coil": return initCoil();
                case "controlbox": return initControlBox();
                case "fanbox": return initFanBox();
                case "filter": return initFilter();
                case "heat": return initHeat();
                case "hrwheel": return initHrWheel();
                case "mixbox": return initMixBox();
                default: return null;
            }
        }
    }
}
