USE [DatPhongDiDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetTypeOfRoomById]    Script Date: 19/11/2020 09:28:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetTypeOfRoomById] 
	@Id int
AS
BEGIN
	SELECT t.[Id]
		  ,t.[Name]
		  ,t.[Status]
		  , st.StatusName
	  FROM [dbo].[TypeOfRoom] t
	  INNER JOIN [dbo].[Status] st on st.[Status] = t.[Status]
	WHERE @Id = t.Id AND TableId = 1
ENd


GO

