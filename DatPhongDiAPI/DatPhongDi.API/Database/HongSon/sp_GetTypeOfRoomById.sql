USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTypeOfRoomById]    Script Date: 11/23/2020 11:53:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_GetTypeOfRoomById] 
	@Id int
AS
BEGIN
DECLARE @Message Nvarchar(50) = N'Có gì đó sai, vui lòng thử lại'
	IF(EXISTS(SELECT * FROM [dbo].[TypeOfRoom] WHERE @Id = [Id] and [Status] != 2))
	BEGIN
		SELECT t.[Id]
		  ,t.[Name]
		  ,t.[Status]
		  , st.StatusName
	  FROM [dbo].[TypeOfRoom] t
	  INNER JOIN [dbo].[Status] st on st.[Status] = t.[Status]
	WHERE @Id = t.Id AND TableId = 1
	SET @Message = N'Tìm thấy thành công'
	END
	eLSE 
	BEGIN
		SET @Message = N'Không tìm thấy'
	END
	SELECT @Message AS [Message], @Id as [Id] 
ENd


