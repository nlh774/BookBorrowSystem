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

        public void SubmitForm(BookEntity entity, string keyValue)
        {
            if (!keyValue.IsEmpty())
            {
                entity.Modify(keyValue);
                service.Update(entity);
            }
            else
            {
                entity.Create();
                service.Insert(entity);
            }
        }

        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.F_Id == keyValue);
        }
    }
}
