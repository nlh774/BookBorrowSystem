using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TCBookBorrowSystem.Model
{
    [Table("BorrowLog")]
    public class BorrowLogContract:BaseContract
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public long Id { get; set; }
        
        public long BookId { get; set; }

        public string BorrowerName { get; set; }

        public DateTime BorrowTime { get; set; }

        public DateTime ReturnTime { get; set; }

        [ForeignKey("BookId")]
        public virtual BookContract Book { get; set; }
    }
}
