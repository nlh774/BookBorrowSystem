using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TCBookBorrowSystem.Model
{
    [Table("Book")]
    public class BookContract:BaseContract
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        public string SerialId { get; set; }

        public string Name { get; set; }

        public BookStatus BookStatus { get; set; }

        public virtual ICollection<BorrowLogContract> BorrowLogs { get; set; }
    }
}
