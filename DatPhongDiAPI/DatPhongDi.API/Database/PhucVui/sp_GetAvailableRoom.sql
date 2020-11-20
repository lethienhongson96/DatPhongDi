USE [DatPhongDiDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetAvailableRoom]    Script Date: 20/11/2020 09:10:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Phuc Vui
-- Create date: 20/11/2020
-- Description:	Get Available Room 
-- =============================================
Create PROCEDURE [dbo].[sp_GetAvailableRoom]
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
	WHERE [Status] =1

END
GO

