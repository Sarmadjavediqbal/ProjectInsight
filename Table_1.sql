/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Table1
	(
	id int NOT NULL,
	uniqueId uniqueidentifier NOT NULL,
	sensor_data float(53) NULL,
	sensor_name nvarchar(50) NULL,
	created_at datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Table1 SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
