ALTER TABLE [dbo].[Book] ADD
    [F_DeleteMark]       BIT            NULL,
    [F_EnabledMark]      BIT            NULL,
    [F_Description]      NVARCHAR (500) NULL,
    [F_CreatorTime]      DATETIME       NULL,
    [F_CreatorUserId]    NVARCHAR (50)  NULL,
    [F_LastModifyTime]   DATETIME       NULL,
    [F_LastModifyUserId] NVARCHAR (50)  NULL,
    [F_DeleteTime]       DATETIME       NULL,
    [F_DeleteUserId]     NVARCHAR (50)  NULL