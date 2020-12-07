USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetServiceByTypeOfRoomId]    Script Date: 07/12/2020 09:28:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		 Phúc Vui
-- Create date: 18/11/2020
-- Description:	Get Customer by Id 
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetServiceByTypeOfRoomId] 
	@Id int
AS
BEGIN
	SELECT s.[Id]
		  ,s.[Name]
		  ,s.[Status]
		  ,s.[Icon]
	  FROM [dbo].[Service] s
	  INNER JOIN [dbo].[TypeOfRoomService] ts on s.[Id]=ts.[ServiceId]
	  where ts.[TypeOfRoomId]=@Id
END
