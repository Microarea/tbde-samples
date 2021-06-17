if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CO_TmpLoadComics]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[CO_TmpLoadComics] (
    [EntryId] [int] NOT NULL,
	[SubId] [int] NOT NULL,
	[BoxNo] [varchar] (8) NOT NULL,
	[Item] [varchar] (21) NULL CONSTRAINT DF_TmpCFum_Item_00 DEFAULT(''),
	[Description] [varchar] (128) NULL CONSTRAINT DF_TmpCFum_Descri_00 DEFAULT (''),
	[Collection] [varchar] (20) NULL CONSTRAINT DF_TmpCFum_Coll_00 DEFAULT (''),
	[InvEntryDate] [datetime] NULL CONSTRAINT DF_TmpCFum_IEDate_00 DEFAULT('17991231'),
   CONSTRAINT [PK_TmpLoadComics] PRIMARY KEY NONCLUSTERED 
    (
        [EntryId],
        [SubId],
		[BoxNo]
    ) ON [PRIMARY]
) ON [PRIMARY]

END
GO
