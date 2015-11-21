using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TCBookBorrowSystem.Model
{
    [Table("BorrowLog")]
    public class BorrowLogContract : BaseContract
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public long Id { get; set; }

        public long BookId { get; set; }

        public string BorrowerName { get; set; }

        public DateTime BorrowTime { get; set; }

        /// <summary>
        /// 逻辑上的归还时间，主要用于显示,不对应DB
        /// 若书本未归还，则返回空
        /// </summary>
        [NotMapped]
        public string LoginReturnTime
        {
            get
            {
                if (ReturnTime == new DateTime(1900, 1, 1))
                    return null;
                else return
                    ReturnTime.ToShortTimeString();
            }
        }

        public DateTime ReturnTime { get; set; }

        [ForeignKey("BookId")]
        public virtual BookContract Book { get; set; }
    }
}
