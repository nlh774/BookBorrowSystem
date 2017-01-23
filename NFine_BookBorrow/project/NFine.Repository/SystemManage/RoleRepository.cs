/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using NFine.Data;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepository.SystemManage;
using NFine.Repository.SystemManage;
using System.Collections.Generic;

namespace NFine.Repository.SystemManage
{
    public class BookRepository : RepositoryBase<BookEntity>, IBookRepository
    {
        int IRepositoryBase<BookEntity>.Insert(BookEntity entity)
        {
            throw new System.NotImplementedException();
        }

        int IRepositoryBase<BookEntity>.Insert(List<BookEntity> entitys)
        {
            throw new System.NotImplementedException();
        }

        int IRepositoryBase<BookEntity>.Update(BookEntity entity)
        {
            throw new System.NotImplementedException();
        }

        int IRepositoryBase<BookEntity>.Delete(BookEntity entity)
        {
            throw new System.NotImplementedException();
        }

        int IRepositoryBase<BookEntity>.Delete(System.Linq.Expressions.Expression<System.Func<BookEntity, bool>> predicate)
        {
            throw new System.NotImplementedException();
        }

        BookEntity IRepositoryBase<BookEntity>.FindEntity(object keyValue)
        {
            throw new System.NotImplementedException();
        }

        BookEntity IRepositoryBase<BookEntity>.FindEntity(System.Linq.Expressions.Expression<System.Func<BookEntity, bool>> predicate)
        {
            throw new System.NotImplementedException();
        }

        System.Linq.IQueryable<BookEntity> IRepositoryBase<BookEntity>.IQueryable()
        {
            throw new System.NotImplementedException();
        }

        System.Linq.IQueryable<BookEntity> IRepositoryBase<BookEntity>.IQueryable(System.Linq.Expressions.Expression<System.Func<BookEntity, bool>> predicate)
        {
            throw new System.NotImplementedException();
        }

        List<BookEntity> IRepositoryBase<BookEntity>.FindList(string strSql)
        {
            throw new System.NotImplementedException();
        }

        List<BookEntity> IRepositoryBase<BookEntity>.FindList(string strSql, System.Data.Common.DbParameter[] dbParameter)
        {
            throw new System.NotImplementedException();
        }

        List<BookEntity> IRepositoryBase<BookEntity>.FindList(Code.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        List<BookEntity> IRepositoryBase<BookEntity>.FindList(System.Linq.Expressions.Expression<System.Func<BookEntity, bool>> predicate, Code.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }
    }
}
