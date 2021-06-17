
IF NOT EXISTS (SELECT dbo.syscolumns.name FROM dbo.syscolumns, dbo.sysobjects WHERE
	dbo.sysobjects.name = 'MA_Items' AND dbo.sysobjects.id = dbo.syscolumns.id
	AND dbo.syscolumns.name = 'ComicsCollection')
BEGIN
ALTER TABLE [dbo].[MA_Items]
	ADD [ComicsCollection] [varchar] (20) NULL CONSTRAINT DF_Items_ComicsColl_00 DEFAULT ('')
END
GO


UPDATE [dbo].[MA_Items] SET [dbo].[MA_Items].[ComicsCollection] = '' WHERE [dbo].[MA_Items].[ComicsCollection] IS NULL
GO
