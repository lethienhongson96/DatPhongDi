USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllRoom]    Script Date: 19/11/2020 08:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Minh Tan
-- Create date: 17/11/2020
-- Description:	Get all Room
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetAllRoom]
AS
BEGIN
		SELECT[Id]
		  ,[Name]
		  ,[PricePerNight]
		  ,[AmountAdult]
		  ,[AmountChild]
		  ,[Status]
		  ,[TypeOfRoomId]
		  ,FORMAT(c.[CreateDate],'MMM dd yyyy') AS CreateDateStr
		  ,FORMAT(c.[ModifiedDate],'MMM dd yyyy') AS ModifiedDateStr
		 ,(SELECT TOP(1) StatusName FROM [dbo].[Status] WHERE TableId = 2 AND [Status] = c.[Status] AND IsDelete = 0) AS 'StatusName'
		 		 ,(SELECT [Name] FROM [dbo].[TypeOfRoom] WHERE [dbo].[TypeOfRoom].Id =c.[TypeOfRoomId]) AS 'TypeOfRoomName'

	  FROM [dbo].[Room] AS c
	WHERE [Status] in (1,2,3)

END
