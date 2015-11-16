using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCBookBorrowSystem.Model;
using TCBookBorrowSystem.Model.ServiceModel;
using TCBookBorrowSystem.Service;

namespace TCBookBorrowSystem.MvcWebUI.Controllers
{
    public class BookController : Controller
    {
        private BusinessService service = new BusinessService();

        //<TSearch,TResult>
        public ActionResult Index(BookSearchModel searchModel)
        {
            var books = service.Index(searchModel);
            return View(books);
        }

        [HttpGet]
        public ActionResult Create()
        {
            string serialId = service.GetNextMaxBookSerialId();
            BookContract book = new BookContract { SerialId = serialId };
            return View(book);
        }

        [HttpPost]
        public ActionResult Create(BookContract book)
        {
            service.AddBook(book);
            return View();
        }

        [HttpGet]
        public ActionResult Borrow(long bookId)
        {
            BorrowLogContract borrowLog = new BorrowLogContract {BookId = bookId, BorrowTime = DateTime.Now};
            return View(borrowLog);
        }

        [HttpPost]
        public ActionResult Borrow(BorrowLogContract borrowLog)
        {
            service.Borrow(borrowLog);
            return View();
        }

        public void Return(long bookId)
        {
            service.Rerturn(bookId);
        }

        public ActionResult IndexBorrowLog(long bookId)
        {
            List<BorrowLogContract> borrowLogs = service.IndexBookLog(bookId);
            return View(borrowLogs);
        }

        public void Delete(long bookId)
        {
            //考虑返回Json表示删除是否成功，前端再判断、显示
            service.DeleteBook(bookId);
        }

        //public ActionResult BookBorrowLog(long bookId)
        //{
        //    service.IndexBookLog(new BookSearchModel {});
        //}
    }
}
