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
	[kladr].[dbo].[KLADR].[NAME] + ' ' + regionName AS 'Name',
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

-- Add Moscow
INSERT INTO [aspnet-Kladr-20170327060528].[dbo].[Settlements] (Name, RegionName, [Index])
VALUES ('Москва Московская', 'Московская обл', NULL)
GO

-- Delete settlements with the same names but different index values
DELETE FROM [aspnet-Kladr-20170327060528].[dbo].[Settlements]
WHERE Id = 1 OR Id = 9 OR Id = 25 OR Id = 37 OR Id = 39 OR Id = 47 OR Id = 54 OR Id = 57 OR Id = 66 OR Id = 71 OR
		Id = 89 OR Id = 105 OR Id = 107 OR Id = 119 OR Id = 126 OR Id = 128 OR Id = 140 OR Id = 152 OR Id = 161 OR
		Id = 175 OR Id = 180 OR Id = 184 OR Id = 187 OR Id = 192 OR Id = 195 OR Id = 211 OR Id = 218 OR Id = 220 OR
		Id = 238 OR Id = 246 OR Id = 274 OR Id = 286 OR Id = 293 OR Id = 340 OR Id = 385 OR Id = 409 OR Id = 413 OR
		Id = 436 OR Id = 444 OR Id = 476 OR Id = 499 OR Id = 530 OR Id = 538 OR Id = 557 OR Id = 563 OR Id = 567 OR
		Id = 585 OR Id = 587 OR Id = 606 OR Id = 608 OR Id = 614 OR Id = 639 OR Id = 671 OR Id = 686 OR Id = 688 OR
		Id = 715 OR Id = 724 OR Id = 753 OR Id = 814
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
	INNER JOIN [aspnet-Kladr-20170327060528].[dbo].[Settlements] settlementsTable ON settlementsTable.Name LIKE kladrTable.Name + ' ' + CONVERT(NVARCHAR(2), settlementsTable.RegionName) + '%' collate Cyrillic_General_CI_AS
ORDER BY streetsTable.NAME
GO

-- FOR Moscow
INSERT INTO [aspnet-Kladr-20170327060528].[dbo].[Streets] (Name, SettlementName, RegionName, [Index])
SELECT
	streetsTable.SOCR + ' ' + streetsTable.[NAME] AS 'Name',
	'Москва Московская' AS SettlementName,
	'Московская обл' AS RegioinName,
	streetsTable.[INDEX] AS 'Index'
FROM [kladr].[dbo].[STREET] streetsTable
	INNER JOIN kladr.dbo.KLADR kladrTable ON kladrTable.CODE = CONVERT(NVARCHAR(13), streetsTable.CODE) AND kladrTable.NAME = 'Москва' AND kladrTable.SOCR = 'г'
ORDER BY streetsTable.NAME
GO

-- Houses of Ekaterinburg and Moscow
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
WHERE doma.[INDEX] IS NOT NULL AND (streets.SettlementName LIKE 'Екатеринбург%')
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
WHERE doma.[INDEX] IS NOT NULL AND (streets.SettlementName LIKE 'Москва%')
GO
