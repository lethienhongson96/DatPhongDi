USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllTypeOfRoom]    Script Date: 10/12/2020 08:58:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Minh Tan
-- Create date: 17/11/2020
-- Description:	Get all Type Of Room and image in type of room
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetTypeOfRoomAndImage]
AS
BEGIN
	SELECT c.[Id]
		  ,c.[Name]
		  ,c.[Status]
		 ,(SELECT TOP(1) StatusName FROM [dbo].[Status] WHERE TableId = 1 AND [Status] = c.[Status] AND IsDelete = 0) AS 'StatusName'
		  ,c.[AmountAdults]
		  ,c.[AmountChild]
		  ,c.[PricePerNight]
		  ,(SELECT TOP(1)ImagePath FROM [dbo].[Image] WHERE [TypeOfRoomId] =C.Id) AS Image
		  ,(SELECT TOP(1)Size FROM [dbo].[Room] WHERE [TypeOfRoomId] =C.Id) AS Size
	  FROM [dbo].[TypeOfRoom] AS c
	WHERE [Status] =1

END


