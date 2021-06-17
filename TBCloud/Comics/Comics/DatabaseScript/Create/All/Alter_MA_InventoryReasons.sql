
IF NOT EXISTS (SELECT dbo.syscolumns.name FROM dbo.syscolumns, dbo.sysobjects WHERE
	dbo.sysobjects.name = 'MA_InventoryReasons' AND dbo.sysobjects.id = dbo.syscolumns.id
	AND dbo.syscolumns.name = 'ComicsLoadBox')
BEGIN
ALTER TABLE [dbo].[MA_InventoryReasons]
	ADD [ComicsLoadBox] [char] (1) NULL CONSTRAINT DF_InventoryR_CoLoadBox_00 DEFAULT ('0')
END
GO


UPDATE [dbo].[MA_InventoryReasons] SET [dbo].[MA_InventoryReasons].[ComicsLoadBox] = '0' WHERE [dbo].[MA_InventoryReasons].[ComicsLoadBox] IS NULL
GO
