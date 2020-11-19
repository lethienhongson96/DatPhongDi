USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllTypeOfRoom]    Script Date: 19/11/2020 08:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Minh Tan
-- Create date: 17/11/2020
-- Description:	Get all Type Of Room
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetAllTypeOfRoom]
AS
BEGIN
	SELECT c.[Id]
		  ,c.[Name]
		  ,c.[Status]
		 ,(SELECT TOP(1) StatusName FROM [dbo].[Status] WHERE TableId = 1 AND [Status] = c.[Status] AND IsDelete = 0) AS 'StatusName'
	  FROM [dbo].[TypeOfRoom] AS c
	WHERE [Status] =1

END
