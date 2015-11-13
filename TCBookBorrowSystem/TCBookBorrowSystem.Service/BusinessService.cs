using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCBookBorrowSystem.Model;
using System.Data.Entity;
using TCBookBorrowSystem.Model.ServiceModel;
using CommTools;
namespace TCBookBorrowSystem.Service
{
    public class BusinessService
    {
        /// <summary>
        /// 查询书本信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BookContract> Index(BookSearchModel model)
        {
            using (BookBorrowContext context = new BookBorrowContext())
            {
                IQueryable<BookContract> query = context.Book.Where(t => t.IsDel == false);
                if (model.BookId!=0)
                {
                    query = context.Book.Where(t => t.Id == model.BookId);
                }
                if (model.Name.IsNotNullOrWhiteSpace())
                {
                    query = context.Book.Where(t => t.Name.Contains(model.Name));
                }
                if (model.SerialId.IsNotNullOrWhiteSpace())
                {
                    query = context.Book.Where(t => t.SerialId.Contains(model.SerialId));
                }

                return query.ToList();
            }
        }

        /// <summary>
        /// 查询书本、以及借阅历史信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //public List<BookContract> IndexBookLog(BookSearchModel model)
        //{
        //    //可以不联查表,若是BookId可以直接查log表，若是BookName\SerialId，先查book,再查log
        //    using (BookBorrowContext context = new BookBorrowContext())
        //    {
        //        IQueryable<BookContract> query = context.Book.Include(t => t.BorrowLogs).Where(t => t.IsDel == false);
        //        if (model.BookId != 0)
        //        {
        //            query = context.Book.Where(t => t.Id == model.BookId);
        //        }
        //        if (model.Name.IsNotNullOrWhiteSpace())
        //        {
        //            query = context.Book.Where(t => t.Name.Contains(model.Name));
        //        }
        //        if (model.SerialId.IsNotNullOrWhiteSpace())
        //        {
        //            query = context.Book.Where(t => t.SerialId.Contains(model.SerialId));
        //        }
        //        if (model.BorrowerName.IsNotNullOrWhiteSpace())
        //        {
        //            query = context.Book.Where(t => t.BorrowLogs.Any(log => log.BorrowerName.Contains(model.BorrowerName)));    //是否存在
        //        }

        //        return query.ToList();
        //    }
        //}
    }
}
