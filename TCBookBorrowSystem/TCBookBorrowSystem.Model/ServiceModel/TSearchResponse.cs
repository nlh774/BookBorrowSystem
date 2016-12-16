using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCBookBorrowSystem.Model.ServiceModel
{
    public class TSearchResponse<TSearch,TResult>
    {
        public TSearch Search { get; set; }

        public TResult Result { get; set; }
    }
}
