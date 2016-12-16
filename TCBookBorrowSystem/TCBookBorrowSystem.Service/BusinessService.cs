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
        public bool AddBook(BookContract book)
        {
            using (BookBorrowContext context = new BookBorrowContext())
            {
                book.IsDel = false;
                book.BookStatus = BookStatus.Avalable;
                context.Book.Add(book);
                int effect = context.SaveChanges();
                return effect == 1;
            }
        }

        public bool AddBorrowLog(BorrowLogContract borrowLog)
        {
            using (BookBorrowContext context = new BookBorrowContext())
            {
                context.BorrowLog.Add(borrowLog);
                int effect = context.SaveChanges();
                return effect == 1;
            }
        }

        /// <summary>
        /// 查询书本信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BookContract> Index(BookSearchModel model)
        {
            using (BookBorrowContext context = new BookBorrowContext())
            {
                //按条件查询拼接linq（延迟加载），最终ToList() linq生成sql再到DB中立即查询数据
                IQueryable<BookContract> query = context.Book.Where(t => t.IsDel == false);
                if (model.BookId.HasValue && model.BookId != 0)
                {
                    query = context.Book.Where(t => t.Id == model.BookId);
                }
                if (model.Name.IsNotNullOrWhiteSpace())
                {
                    query = query.Where(t => t.Name.Contains(model.Name));
                }
                if (model.SerialId.IsNotNullOrWhiteSpace())
                {
                    query = query.Where(t => t.SerialId.Contains(model.SerialId));
                }

                return query.ToList();
            }
        }

        /// <summary>
        /// 查询书本的借阅历史信息、含书本信息
        /// </summary>
        /// <returns></returns>
        public List<BorrowLogContract> IndexBookLog(long bookId)
        {
            //可以不联查表,若是BookId可以直接查log表，若是BookName\SerialId，先查book,再查log
            using (BookBorrowContext context = new BookBorrowContext())
            {
                #region 旧代码，已废弃
                //IQueryable<BookContract> query = context.Book.Include(t => t.BorrowLogs).Where(t => t.IsDel == false);
                //if (model.BookId != 0)
                //{
                //    query = context.Book.Where(t => t.Id == model.BookId);
                //}
                //if (model.Name.IsNotNullOrWhiteSpace())
                //{
                //    query = context.Book.Where(t => t.Name.Contains(model.Name));
                //}
                //if (model.SerialId.IsNotNullOrWhiteSpace())
                //{
                //    query = context.Book.Where(t => t.SerialId.Contains(model.SerialId));
                //}
                //if (model.BorrowerName.IsNotNullOrWhiteSpace())
                //{
                //    query = context.Book.Where(t => t.BorrowLogs.Any(log => log.BorrowerName.Contains(model.BorrowerName)));    //是否存在
                //}
                //return query.ToList();
                #endregion
                BookContract book = context.Book.FirstOrDefault(t => t.IsDel == false && t.Id == bookId);
                if (book == null)
                    return null;
                else
                {
                    return context.BorrowLog.Include(t => t.Book).Where(t => t.BookId == book.Id).ToList();
                }
            }
        }

        /// <summary>
        /// 修改书本借阅状态为不可借、增加借阅记录
        /// 使用事务
        /// </summary>
        /// <param name="borrowLog"></param>
        /// <returns></returns>
        public bool Borrow(BorrowLogContract borrowLog)
        {
            using (BookBorrowContext context = new BookBorrowContext())
            {
                //修改书本借阅状态为不可借与增加借阅记录两个操作必须都完成才有效
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        var book = context.Book.FirstOrDefault(t => t.Id == borrowLog.BookId);
                        //if(book == null)  ;
                        book.BookStatus = BookStatus.UnAvalable;

                        borrowLog.ReturnTime = new DateTime(1900, 1, 1);
                        context.BorrowLog.Add(borrowLog);

                        context.SaveChanges();
                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        //记录 ex
                        return false;
                    }
                    //using()会释放的，不必再 trans.Dispose();
                }
            }
        }

        public bool Rerturn(long bookId)
        {
            using (BookBorrowContext context = new BookBorrowContext())
            {
                //修改书本借阅状态为可借与修改归还时间两个操作必须都完成才有效
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        var book = context.Book.FirstOrDefault(t => t.Id == bookId);
                        //if(book == null)  ;
                        book.BookStatus = BookStatus.Avalable;

                        //TODO:bug:应该只将归还人的借书记录设置为已归还，而不是FirstOrDefault(t => t.BookId == bookId)
                        var borrowLog = context.BorrowLog.FirstOrDefault(t => t.BookId == bookId);
                        borrowLog.ReturnTime = DateTime.Now;

                        context.SaveChanges();
                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        //记录 ex
                        return false;
                    }
                    //using()会释放的，不必再 trans.Dispose();
                }
            }
        }

        public bool DeleteBook(long bookId)
        {
            using (BookBorrowContext context = new BookBorrowContext())
            {
                var book = context.Book.FirstOrDefault(t => t.Id == bookId);
                book.IsDel = true;
                int effect = context.SaveChanges();
                return effect == 1;
            }
        }

        /// <summary>
        /// 返回最大的序列号
        /// </summary>
        /// <returns></returns>
        public string GetNextMaxBookSerialId()
        {
            string maxSerialId;     //形如 YFSJ0234，后期若书籍大于1万本则4位数字数字不够用。到时序列号末尾字母+1，如 YFSK0001。具体规则到时说
            using (BookBorrowContext context = new BookBorrowContext())
            {
                maxSerialId = context.Book.Max(t => t.SerialId);  //效率有问题，最好优化下。可以从DB中取出全部书本信息，在代码中找最大的。具体到时再说
            }

            string prefix = maxSerialId.Substring(0, 4);
            string postfixNum = maxSerialId.Substring(4);
            string newPostfixNum = (int.Parse(postfixNum) + 1).ToString("0000");
            return prefix + newPostfixNum;
        }


    }
}
