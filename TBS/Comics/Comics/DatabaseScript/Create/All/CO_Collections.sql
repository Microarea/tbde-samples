if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CO_Collections]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[CO_Collections] (
    [Collection] [varchar] (20) NOT NULL,
    [Description] [varchar] (32) NULL CONSTRAINT DF_Collections_Descri_00 DEFAULT (''),
    [Notes] [varchar] (128) NULL CONSTRAINT DF_Collections_Note_00 DEFAULT (''),
	[Disabled] [char] (1) NULL CONSTRAINT DF_Collections_Disab_00 DEFAULT ('0'),
    CONSTRAINT [PK_Collections] PRIMARY KEY NONCLUSTERED 
    (
        [Collection]
    ) ON [PRIMARY]
) ON [PRIMARY]

END
GO
