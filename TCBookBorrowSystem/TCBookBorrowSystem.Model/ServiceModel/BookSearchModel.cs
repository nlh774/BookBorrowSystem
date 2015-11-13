using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCBookBorrowSystem.Model.ServiceModel
{
    public class BookSearchModel
    {
        public long BookId { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        public string SerialId { get; set; }

        public string Name { get; set; }

        public string BorrowerName { get; set; }
    }
}
