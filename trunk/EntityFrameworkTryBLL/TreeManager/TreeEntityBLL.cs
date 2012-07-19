using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataContext;

namespace EntityFrameworkTryBLL.TreeManager
{
    public class TreeEntityBLL
    {
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
                    //。添加进来
                    treeEntity.SubTreeEntities.Add(te);
                    te.parentTreeEntity = treeEntity;
                    TreeEntity tempTreeEntity = new TreeEntity(treeEntity.PropertyId);
                    tempTreeEntity.parentTreeEntity = treeEntity.parentTreeEntity;
                    tempTreeEntity.ParentTreePath = treeEntity.ParentTreePath;
                    tempTreeEntity.SubTreeEntities = treeEntity.SubTreeEntities;

                    te.ParentTreePath.Add(tempTreeEntity);
                    while (tempTreeEntity.parentTreeEntity != null)
                    {
                        tempTreeEntity = tempTreeEntity.parentTreeEntity;
                        te.ParentTreePath.Add(tempTreeEntity);
                    }

                    //如果该节点与父路径中的某个节点重复。则不可添加
                    if (!isEntityAlreadyInParent(te))
                        return te;

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
        /// 判断一个节点能否加入到当前的节点的子节点中
        /// </summary>
        /// <param name="treeEntity"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool isEntityAlreadyInParent(TreeEntity entity)
        {
            try
            {
                //如果是根节点，则返回true，
                if (entity.parentTreeEntity == null)
                    return true;

                //遍历父节点
                foreach (var tpE in entity.ParentTreePath)
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
                        TreeEntity te = new TreeEntity(ptyId.ToString());
                        te.parentTreeEntity = treeEntity;
                        treeEntities.Add(te);
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
