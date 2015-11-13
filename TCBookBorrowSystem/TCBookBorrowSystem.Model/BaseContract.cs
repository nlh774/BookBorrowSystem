using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCBookBorrowSystem.Model
{
    public class BaseContract
    {
        public BaseContract()
        {
            CreatedOn = DateTime.Now;
            IsDel = false;
            Remark = "";
        }

        public DateTime CreatedOn { get; set; }

        public bool IsDel { get; set; }

        public string Remark { get; set; }
    }
}
