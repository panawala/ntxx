using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Model.Export;
using EntityFrameworkTryBLL.OrderManager;

namespace Annon.ExportData
{
   public class ExportDataInformationService
    {
      public  static void ReserializeMethod(string fileName){       
            //反序列化          
          using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {                
                BinaryFormatter bf = new BinaryFormatter();
                List<ExportDataInformation> list = bf.Deserialize(fs) as List<ExportDataInformation>; 
                if (list != null) 
                {
                    //for (int i = 0; i < list.Count;i++ )
                    //{
                    //    //list[i].SayHi();     
                    //} 
                    foreach (var exportData in list)
                    {
                        ExportDataInformation exportDataInformation = (ExportDataInformation)exportData;
                       int orderId = OrderBLL.ImportIntoOrdersInfo(exportDataInformation.ordersInfo);
                       OrderBLL.ImportOrderInformation(orderId, exportDataInformation.orderInformationData);
                       OrderBLL.insertInfoOrderDetail(orderId, exportDataInformation.orderdetailInfoList,
                           exportDataInformation.catalogOrderList,
                           exportDataInformation.imageModelList,
                           exportDataInformation.unitOrderList,
                           exportDataInformation.contentOrderList
                           );

                    }
                }           
            }        
        }
       public  static void SerializeMethod(List<ExportDataInformation> listPers,string fileName="1.bin") 
        {          
            //序列化       
            using (FileStream fs = new FileStream(fileName, FileMode.Create))      
            {               
                BinaryFormatter bf = new BinaryFormatter();  
                bf.Serialize(fs, listPers);    
            }    
        }  
    }

}
