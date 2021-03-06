USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetsTypeOfRoomService]    Script Date: 01/12/2020 20:05:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetsTypeOfRoomService]
@Id int
AS
BEGIN
	SELECT	T.[Name] AS TypeofRoomName,
			S.[Name] AS ServiceName
	
	FROM [dbo].[TypeOfRoomService] AS ST INNER JOIN [dbo].[Service] AS S
										ON ST.[ServiceId] = S.Id
										INNER JOIN [dbo].[TypeOfRoom] AS T
										ON ST.[TypeOfRoomId] = T.Id
										WHERE ST.[TypeOfRoomId] = @Id
END
