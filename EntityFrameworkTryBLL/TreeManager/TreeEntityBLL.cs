using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataContext;

namespace EntityFrameworkTryBLL.TreeManager
{
    public class TreeEntityBLL
    {
        //public static TreeEntity getConstraintEntity(TreeEntity rootTreeEntity,string propertyId)
        //{
        //    //得到父节点的子节点
        //    List<string> subEntitityString = getSubTreeEntities(rootTreeEntity);
        //    while (subEntitityString.Count > 0)
        //    {
 
        //        foreach (var ses in subEntitityString)
        //        {
        //            if (!isEntityInTree(rootTreeEntity, ses))
        //                return rootTreeEntity;
        //            rootTreeEntity.SubTreeEntities.Add(new TreeEntity(ses));
        //        }
        //        subEntitityString=getConstraintEntity()
        //    }
        //    return null;
        //}

        /// <summary>
        /// 把子节点添加给父节点
        /// </summary>
        /// <param name="treeEntity"></param>
        public static TreeEntity addToParentEntity(TreeEntity treeEntity)
        {
            List<TreeEntity> entityStrs = getSubTreeEntities(treeEntity);
            if (entityStrs.Count > 0)
            {
                foreach (var te in entityStrs)
                {
                    //如果该节点与父路径中的某个节点重复。则不可添加
                    if (!isEntityInTree(treeEntity, te))
                        return te;
                    //否则。添加进来
                    treeEntity.SubTreeEntities.Add(te);
                    te.ParentTreePath.Add(treeEntity);
                }
            }
            //遍历子节点
            foreach (var te in entityStrs)
            {
                var entity = addToParentEntity(te);
                if (entity != null)
                    return entity;
            }
            return null;
        }

        /// <summary>
        /// 判定某个节点能否加入到父节点
        /// </summary>
        /// <param name="treeEntity"></param>
        /// <param name="propertyId"></param>
        /// <returns></returns>
        public static bool isEntityInTree(TreeEntity treeEntity,string propertyId)
        {
            foreach (var tpE in treeEntity.ParentTreePath)
            {
                //如果父路径已存在该节点。则返回false
                if (tpE.PropertyId.Equals(propertyId))
                    return false;
            }
            return true;
        }

        public static bool isEntityInTree(TreeEntity treeEntity, TreeEntity entity)
        {
            try
            {
                if (treeEntity.ParentTreePath== null)
                    return true;
                //遍历父节点
                foreach (var tpE in treeEntity.ParentTreePath)
                {
                    //如果父路径已存在该节点。则返回false
                    if (tpE.PropertyId.Equals(entity.PropertyId))
                        return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        /// <summary>
        /// 得到每个节点的子节点
        /// </summary>
        /// <param name="treeEntity"></param>
        /// <returns></returns>
        public static List<TreeEntity> getSubTreeEntities(TreeEntity treeEntity)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    int propertyId = Convert.ToInt32(treeEntity.PropertyId);
                    var propertyIds = context.PropertyConstraints
                        .Where(s => s.PropertyID == propertyId)
                        .Select(s => s.InfluencedPtyID)
                        .Distinct();
                    List<TreeEntity> treeEntities = new List<TreeEntity>();
                    foreach (var ptyId in propertyIds)
                    {
                        treeEntities.Add(new TreeEntity(ptyId.ToString()));
                    }
                    return treeEntities;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
    }
}
