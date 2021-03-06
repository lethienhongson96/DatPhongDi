USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllRoom]    Script Date: 02/12/2020 10:27:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Minh Tan
-- Create date: 01/12/2020
-- Description:	Get all Room
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetAllRoom]
AS
BEGIN
		SELECT[Id]
		  ,[Name]		 
		  ,[Status]
		  ,[TypeOfRoomId]
		  ,FORMAT(c.[CreateDate],'MMM dd yyyy') AS CreateDateStr
		  ,FORMAT(c.[ModifiedDate],'MMM dd yyyy') AS ModifiedDateStr
		  ,[Description]
		  ,[Size]
		 ,(SELECT TOP(1) StatusName FROM [dbo].[Status] WHERE TableId = 2 AND [Status] = c.[Status] AND IsDelete = 0) AS 'StatusName'
		 		 ,(SELECT [Name] FROM [dbo].[TypeOfRoom] WHERE [dbo].[TypeOfRoom].Id =c.[TypeOfRoomId]) AS 'TypeOfRoomName'		
	  FROM [dbo].[Room] AS c
	WHERE [Status] in (1,2)

END
