-- Regions
TRUNCATE TABLE [aspnet-Kladr-20170327060528].[dbo].[Regions]
GO

INSERT INTO [aspnet-Kladr-20170327060528].[dbo].[Regions] (Name, [Index])
SELECT [NAME] + ' ' + [SOCR] AS 'Name', [INDEX] AS 'Index'
FROM [kladr].[dbo].[KLADR]
WHERE (SOCR = 'а.обл.' OR SOCR = 'а.окр.' OR
	SOCR = 'Аобл' OR
	SOCR = 'край' OR SOCR = 'обл' OR
	SOCR = 'округ' OR SOCR = 'Респ') AND CODE != 5900000000001
ORDER BY NAME
GO

-- Settlements
TRUNCATE TABLE [aspnet-Kladr-20170327060528].[dbo].[Settlements]
GO

INSERT INTO [aspnet-Kladr-20170327060528].[dbo].[Settlements] (Name, RegionName, [Index])
SELECT
	[kladr].[dbo].[KLADR].[NAME] AS 'Name',
	regionName + ' ' + regionSocr AS 'RegionName',
	[kladr].[dbo].[KLADR].[INDEX] AS 'Index'
FROM [kladr].[dbo].[KLADR]
	INNER JOIN (SELECT CONVERT(NVARCHAR(4), CODE) AS regionCode, NAME AS regionName, SOCR AS regionSocr
	FROM [kladr].[dbo].[KLADR]
	WHERE (SOCR = 'а.обл.' OR SOCR = 'а.окр.' OR
			SOCR = 'Аобл' OR
			SOCR = 'край' OR SOCR = 'обл' OR
			SOCR = 'округ' OR SOCR = 'Респ') AND CODE != 5900000000001
	) AS regions ON CONVERT(NVARCHAR(4), CODE) = regions.regionCode
WHERE [SOCR]='г' OR [SOCR]='г.ф.з.'
ORDER BY Name
GO

-- Streets
TRUNCATE TABLE [aspnet-Kladr-20170327060528].[dbo].[Streets]
GO

INSERT INTO [aspnet-Kladr-20170327060528].[dbo].[Streets] (Name, SettlementName, RegionName, [Index])
SELECT
	streetsTable.SOCR + ' ' + streetsTable.[NAME] AS 'Name',
	settlementsTable.Name AS 'SettlementName',
	settlementsTable.RegionName AS 'RegionName',
	streetsTable.[INDEX] AS 'Index'
FROM [kladr].[dbo].[STREET] streetsTable
	INNER JOIN kladr.dbo.KLADR kladrTable ON kladrTable.CODE = CONVERT(NVARCHAR(13), streetsTable.CODE)
	INNER JOIN [aspnet-Kladr-20170327060528].[dbo].[Settlements] settlementsTable ON settlementsTable.Name = kladrTable.Name collate Cyrillic_General_CI_AS
ORDER BY streetsTable.NAME
GO

-- Houses
TRUNCATE TABLE [aspnet-Kladr-20170327060528].[dbo].[Houses]
GO

INSERT INTO [aspnet-Kladr-20170327060528].[dbo].[Houses]
(Number, StreetName, SettlementName, RegionName, [Index])
SELECT
	doma.NAME AS 'Number',
	streets.Name AS 'StreetName',
	streets.SettlementName AS 'SettlementName',
	streets.RegionName AS 'RegionName',
	doma.[INDEX] AS 'Index'
FROM kladr.dbo.DOMA doma
INNER JOIN kladr.dbo.STREET ON doma.OCATD = STREET.OCATD
INNER JOIN [aspnet-Kladr-20170327060528].dbo.Streets streets ON streets.Name = STREET.SOCR + ' ' + STREET.NAME collate Cyrillic_General_CI_AS
WHERE RegionName = 'Свердловская обл'
GO
