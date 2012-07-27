using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Model.Xuanxing;
using EntityFrameworkTryBLL.XuanxingManager;

namespace Annon.Module_Detail
{
    class BSF
    {
        ArrayList parentVisted =new ArrayList();//记录已经访问的属性名称
       public  List<CatalogModel> savecatalogModel = new List<CatalogModel>();
        Queue<CatalogModel> queue = new Queue<CatalogModel>();//记录属性详细值
        public void Traverse(List<CatalogModel> test)
        {
            if (test!= null)
            {
                foreach (CatalogModel v in test)
                {

                    //if (parentVisted.IndexOf(v.PropertyName)==0) //如果属性未被访问
                    //{
                    queue.Enqueue(v);
                    savecatalogModel.Add(v);
                    parentVisted.Add(v.PropertyName);
                    //}
                }
                while (queue.Count > 0)
                {
                    CatalogModel objG = queue.Dequeue();
                    //parentVisted.Add(objG.PropertyGroupName);
                    Traverse(CatalogBLL.getAllByCondition(objG.PropertyName, 21, 1));
                }
            }
        }
    }

    class DSF
    {
        ArrayList parentVisted = new ArrayList();//记录已经访问的属性名称
        public List<CatalogModel> savecatalogModel = new List<CatalogModel>();
        Queue<CatalogModel> queue = new Queue<CatalogModel>();//记录属性详细值
        public void Traverse(List<CatalogModel> test)
        {
            if (test != null)
            {
                foreach (CatalogModel v in test)
                {
                    queue.Enqueue(v);
                    if (parentVisted.IndexOf(v.PropertyName) != 0)
                    {
                        parentVisted.Add(v);
                        savecatalogModel.Add(v);
                        while (queue.Count > 0)
                        {

                            Traverse(CatalogBLL.getAllByCondition(v.PropertyName, 39, 1));
                            queue.Dequeue();
                        }                       
                    }                   
                }
                parentVisted.Remove(parentVisted.ToArray().Last().ToString());
            }
        }
    }
}

