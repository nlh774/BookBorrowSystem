/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using NFine.Code;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepository.SystemManage;
using NFine.Repository.SystemManage;
using System.Collections.Generic;
using System.Linq;

namespace NFine.Application.SystemManage
{
    public class BookApp
    {
        private IBookRepository service = new BookRepository();

        
        public List<BookEntity> GetList(string keyword = "")
        {
            var expression = ExtLinq.True<BookEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.Name.Contains(keyword));
            }
            expression = expression.And(t => !t.IsDel);
            return service.IQueryable(expression).ToList();
        }

        public BookEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        #region 修改、删除、新增方法暂未开放
        //public void DeleteForm(string keyValue)
        //{
        //    service.DeleteForm(keyValue);
        //}
        //public void SubmitForm(RoleEntity roleEntity, string[] permissionIds, string keyValue)
        //{
        //    if (!string.IsNullOrEmpty(keyValue))
        //    {
        //        roleEntity.F_Id = keyValue;
        //    }
        //    else
        //    {
        //        roleEntity.F_Id = Common.GuId();
        //    }
        //    var moduledata = moduleApp.GetList();
        //    var buttondata = moduleButtonApp.GetList();
        //    List<RoleAuthorizeEntity> roleAuthorizeEntitys = new List<RoleAuthorizeEntity>();
        //    foreach (var itemId in permissionIds)
        //    {
        //        RoleAuthorizeEntity roleAuthorizeEntity = new RoleAuthorizeEntity();
        //        roleAuthorizeEntity.F_Id = Common.GuId();
        //        roleAuthorizeEntity.F_ObjectType = 1;
        //        roleAuthorizeEntity.F_ObjectId = roleEntity.F_Id;
        //        roleAuthorizeEntity.F_ItemId = itemId;
        //        if (moduledata.Find(t => t.F_Id == itemId) != null)
        //        {
        //            roleAuthorizeEntity.F_ItemType = 1;
        //        }
        //        if (buttondata.Find(t => t.F_Id == itemId) != null)
        //        {
        //            roleAuthorizeEntity.F_ItemType = 2;
        //        }
        //        roleAuthorizeEntitys.Add(roleAuthorizeEntity);
        //    }
        //    service.SubmitForm(roleEntity, roleAuthorizeEntitys, keyValue);
        //} 
        #endregion
    }
}
