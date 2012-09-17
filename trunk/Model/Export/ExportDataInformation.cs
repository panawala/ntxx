using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Order;
using Model.OrderInformation;
using Model.Zutu.ImageModel;
using Model.Xuanxing;
using Model.Zutu.Unit;
using Model.Zutu.Content;

namespace Model.Export
{
    [Serializable]
  public class ExportDataInformation
    {
        public ordersinfo ordersInfo {get;set;}
        public OrderInformationData  orderInformationData{get;set;}
        public List<orderDetailInfo> orderdetailInfoList { get; set; }
        public List<ImageModel> imageModelList { get; set; }
        public List<CatalogOrder> catalogOrderList { get; set; }
        public List<UnitOrder> unitOrderList { get; set; }
        public List<ContentOrder> contentOrderList { get; set; }
    }
}
