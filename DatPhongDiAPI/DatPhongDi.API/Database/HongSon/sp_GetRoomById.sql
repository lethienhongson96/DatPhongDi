USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRoom]    Script Date: 11/19/2020 9:16:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		 Hong Son
-- Create date: 11/18/2020
-- Description:	Get all sources with status is actived
-- status: 1: inprocess, 2: granded, 3: deleted
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetRoom] @Id INT
AS
BEGIN

	SELECT r.[Id]
		  ,r.[Name]
		  ,r.[PricePerNight]
		  ,r.[AmountAdult]
		  ,r.[AmountChild]
		  ,r.[Status]
		  ,r.[TypeOfRoomId]
		  ,r.[CreateDate]
		  ,r.[ModifiedDate]
		  ,FORMAT(r.[CreateDate],'MMM dd yyyy') AS CreateDateStr
		  ,FORMAT(r.[ModifiedDate],'MMM dd yyyy') AS ModifiedDateStr
		  ,(SELECT TOP(1) StatusName FROM [dbo].[Status] WHERE TableId = 2 AND [Status] = r.[Status] AND IsDelete = 0) AS 'StatusName'
		  ,(SELECT [Name] FROM [dbo].[TypeOfRoom] WHERE [dbo].[TypeOfRoom].Id=r.[Id]) as 'TypeOfRoomName'
	FROM  [dbo].[Room] AS r
	WHERE [Status] IN (1,2) AND r.[Id] = @Id
END
