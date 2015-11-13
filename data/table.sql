USE [TCBookBorrowSystem]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 11/13/2015 17:13:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SerialId] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[BookStatus] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[IsDel] [bit] NULL,
	[Remark] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BorrowLog]    Script Date: 11/13/2015 17:13:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorrowLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BorrowerName] [nvarchar](max) NULL,
	[BorrowTime] [datetime] NULL,
	[RerurnName] [datetime] NULL,
	[CreatedOn] [datetime] NULL,
	[IsDel] [bit] NULL,
	[Remark] [nvarchar](max) NULL,
	[BookId] [bigint] NULL,
 CONSTRAINT [PK_dbo.BorrowLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_dbo.BorrowLog_dbo.Book_Book_Id]    Script Date: 11/13/2015 17:13:35 ******/
ALTER TABLE [dbo].[BorrowLog]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BorrowLog_dbo.Book_Book_Id] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BorrowLog] CHECK CONSTRAINT [FK_dbo.BorrowLog_dbo.Book_Book_Id]
GO
