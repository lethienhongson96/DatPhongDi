USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetImageByTypeOfRoomId]    Script Date: 01/12/2020 20:05:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Minh Tan
-- Create date: 01/12/2020
-- Description:	Get image by type of room id
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetImageByTypeOfRoomId]
@Id int
AS
BEGIN
	SELECT	I.[ImagePath] AS ImagePath,
			T.[Name] AS TypeofRoomName
	
	FROM [dbo].[Image] AS I INNER JOIN [dbo].[TypeOfRoom] AS T
										ON I.[TypeOfRoomId] = T.Id
											WHERE I.[TypeofRoomId] = @Id
										

END



