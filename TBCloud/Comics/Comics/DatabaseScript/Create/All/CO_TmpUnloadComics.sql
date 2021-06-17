if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CO_TmpUnloadComics]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[CO_TmpUnloadComics] (
    [SaleDocId] [int] NOT NULL,
	[Line] [smallint] NULL CONSTRAINT DF_TmpSFum_Line_00 DEFAULT (0),
	[SubId] [int] NULL CONSTRAINT DF_TmpSFum_SubId_00 DEFAULT(0),
	[BoxNo] [varchar] (8) NOT NULL,
	[LastName] [varchar] (64) NULL CONSTRAINT DF_TmpSFum_LastN_00 DEFAULT (''),
    [Name] [varchar] (32) NULL CONSTRAINT DF_TmpSFum_Name_00 DEFAULT (''),
	[Item] [varchar] (21) NOT NULL,
	[Collection] [varchar] (20) NULL CONSTRAINT DF_TmpSFum_Coll_00 DEFAULT (''),
	[ReceiptDate] [datetime] NULL CONSTRAINT DF_TmpSFum_IEDate_00 DEFAULT('17991231'),
   CONSTRAINT [PK_TmpUnloadComics] PRIMARY KEY NONCLUSTERED 
    (
        [SaleDocId],
		[BoxNo],
		[Item]
    ) ON [PRIMARY]
) ON [PRIMARY]

END
GO
