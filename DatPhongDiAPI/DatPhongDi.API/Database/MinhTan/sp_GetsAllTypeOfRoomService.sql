USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetsAllTypeOfRoomService]    Script Date: 07/12/2020 09:05:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetsAllTypeOfRoomService]

AS
BEGIN
	SELECT	ST.[Id],
			T.[Name] AS TypeofRoomName,
			S.[Name] AS ServiceName
	
	FROM [dbo].[TypeOfRoomService] AS ST INNER JOIN [dbo].[Service] AS S
										ON ST.[ServiceId] = S.Id
										INNER JOIN [dbo].[TypeOfRoom] AS T
										ON ST.[TypeOfRoomId] = T.Id
END