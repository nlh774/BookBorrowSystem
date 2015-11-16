using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace TCBookBorrowSystem.Model
{
    public class BookBorrowContext:DbContext
{
    public DbSet<BookContract> Book { get; set; }

    public DbSet<BorrowLogContract> BorrowLog { get; set; }


    public BookBorrowContext()
        : base(ConfigurationManager.ConnectionStrings["TCBookBorrowSystem"].ConnectionString)
    {
        //第一次运行需要建立DB架构，并插入测试数据。之后可删除
        //Database.CreateIfNotExists();

        //Book.Add(new BookContract{Name="11111",SerialId="",CreatedOn = DateTime.Now,IsDel=false,Remark="",BookStatus = BookStatus.Avalable});
        //BorrowLog.Add(new BorrowLogContract
        //{
        //    BorrowerName = "niulinhua",
        //    BorrowTime = DateTime.Now,
        //    BookId = 3,
        //    ReturnTime = DateTime.Now,
        //    Remark = "",
        //    CreatedOn=DateTime.Now,
        //    IsDel = false,
        //});
        //SaveChanges();
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //账号-消息，一对多关系
        modelBuilder.Entity<BookContract>()
            .HasMany(t => t.BorrowLogs).WithRequired(t => t.Book);
    }
}
}
