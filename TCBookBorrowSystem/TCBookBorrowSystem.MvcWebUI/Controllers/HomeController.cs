using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCBookBorrowSystem.Model.ServiceModel;
using TCBookBorrowSystem.Service;

namespace TCBookBorrowSystem.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        private BusinessService service = new BusinessService();

        public ActionResult Index()
        {
            var books = service.Index(new BookSearchModel());
            return View(books);
        }

        //public ActionResult BookBorrowLog(long bookId)
        //{
        //    service.IndexBookLog(new BookSearchModel {});
        //}
    }
}
