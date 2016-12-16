using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TCBookBorrowSystem.Model
{
    public enum BookStatus
    {
        [Description("可借")]
        Avalable,

        [Description("不可借")]
        UnAvalable,
    }
}
