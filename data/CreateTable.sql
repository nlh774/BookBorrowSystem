USE [TCBookBorrowSystem]
GO
/****** 对象:  Table [dbo].[Book]    脚本日期: 11/21/2015 16:02:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SerialId] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[Name] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[BookStatus] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[IsDel] [bit] NULL,
	[Remark] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_dbo.Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]


USE [TCBookBorrowSystem]
GO
/****** 对象:  Table [dbo].[BorrowLog]    脚本日期: 11/21/2015 16:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorrowLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BookId] [bigint] NULL,
	[BorrowerName] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[BorrowTime] [datetime] NULL,
	[ReturnTime] [datetime] NULL,
	[CreatedOn] [datetime] NULL,
	[IsDel] [bit] NULL,
	[Remark] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_dbo.BorrowLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [TCBookBorrowSystem]
GO
ALTER TABLE [dbo].[BorrowLog]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BorrowLog_dbo.Book_Book_Id] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([Id])
ON DELETE CASCADE