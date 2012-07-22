using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Zutu.ImageModel
{
  public class ImageModel
    {
        public int ImageModelId { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public int coolingType { get; set; }
        public double FirstDance { get; set; }
        public double SecondDance { get; set; }
        public string ModuleTag { get; set; }
        public int OrderId { get; set; }
        public bool IsSelected { get; set;}
        public string ParentName { get; set; }
    }
}
