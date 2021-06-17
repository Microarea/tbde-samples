if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CO_Boxes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[CO_Boxes] (
    [BoxNo] [varchar] (8) NOT NULL,
	[CreationDate] [datetime] NULL CONSTRAINT DF_Boxes_DataCreaz_00 DEFAULT('17991231'),
	[ClosingDate] [datetime] NULL CONSTRAINT DF_Boxes_DataChius_00 DEFAULT('17991231'),
    [IsClosed] [char] (1) NULL CONSTRAINT DF_Boxes_IsClosed_00 DEFAULT ('0'),
	[LastName] [varchar] (64) NULL CONSTRAINT DF_Boxes_LastName_00 DEFAULT (''),
    [Name] [varchar] (32) NULL CONSTRAINT DF_Boxes_Name_00 DEFAULT (''),
	[Telephone1] [varchar] (20) NULL CONSTRAINT DF_Boxes_Tel1_00 DEFAULT (''),
	[Telephone2] [varchar] (20) NULL CONSTRAINT DF_Boxes_Tel2_00 DEFAULT (''),
	[Mail] [varchar] (64) NULL CONSTRAINT DF_Boxes_Mail_00 DEFAULT (''),
	[Discount] [float] NULL CONSTRAINT DF_Boxes_Discount_00 DEFAULT(0.00),
	[Notes] [varchar] (128) NULL CONSTRAINT DF_Boxes_Note_00 DEFAULT (''),
    CONSTRAINT [PK_Boxes] PRIMARY KEY NONCLUSTERED 
    (
        [BoxNo]
    ) ON [PRIMARY]
) ON [PRIMARY]

END
GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CO_CollectionsBox]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[CO_CollectionsBox] (
    [BoxNo] [varchar] (8) NOT NULL,
	[Collection] [varchar] (20) NOT NULL,
	[CreationDate] [datetime] NULL CONSTRAINT DF_CollBox_DataCreaz_00 DEFAULT('17991231'),
	[FromNumber] [varchar] (3) NULL CONSTRAINT DF_CollBox_DalNum_00 DEFAULT (''),
	[LastReceiptNumber] [varchar] (3) NULL CONSTRAINT DF_CollBox_UNumRic_00 DEFAULT (''),
	[LastIssuedNumber] [varchar] (3) NULL CONSTRAINT DF_CollBox_UNumCons_00 DEFAULT (''),
	[LastReceiptDate] [datetime] NULL CONSTRAINT DF_CollBox_DataURic_00 DEFAULT('17991231'),
	[LastIssuedDate] [datetime] NULL CONSTRAINT DF_CollBox_DataUCons_00 DEFAULT('17991231'),
	[ClosingDate] [datetime] NULL CONSTRAINT DF_CollBox_DataChius_00 DEFAULT('17991231'),
	[IsClosed] [char] (1) NULL CONSTRAINT DF_CollBox_IsClosed_00 DEFAULT ('0'),
	[Notes] [varchar] (128) NULL CONSTRAINT DF_CollBox_Note_00 DEFAULT (''),
    CONSTRAINT [PK_CollectionsBox] PRIMARY KEY NONCLUSTERED 
    (
        [BoxNo],
		[Collection]
    ) ON [PRIMARY],
   CONSTRAINT [FK_CollectionsBox_00] FOREIGN KEY
	(
		[BoxNo]
	) REFERENCES [dbo].[CO_Boxes] (
		[BoxNo]
	)
) ON [PRIMARY]

END
GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CO_ReceiptsBox]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[CO_ReceiptsBox] (
    [BoxNo] [varchar] (8) NOT NULL,
	[Item] [varchar] (21) NOT NULL,
	[ReceiptDate] [datetime] NULL CONSTRAINT DF_MovBox_DataCreaz_00 DEFAULT('17991231'),
    CONSTRAINT [PK_ReceiptsBox] PRIMARY KEY NONCLUSTERED 
    (
        [BoxNo],
		[Item]
    ) ON [PRIMARY],
   CONSTRAINT [FK_ReceiptsBox_00] FOREIGN KEY
	(
		[BoxNo]
	) REFERENCES [dbo].[CO_Boxes] (
		[BoxNo]
	)
) ON [PRIMARY]

END
GO