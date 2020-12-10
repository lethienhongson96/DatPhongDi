USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTypeOfRoomService]    Script Date: 09/12/2020 09:28:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_DeleteTypeOfRoomService]
	@Id	INT

AS
BEGIN
	DECLARE @Message NVARCHAR(100) = N'Có gì đó sai , vui lòng thử lại sau!'
	IF(NOT EXISTS(SELECT * FROM [dbo].[TypeOfRoom] WHERE [Id] = @Id))
	BEGIN
		SET @Message = N'Id không tồn tại'
	END
	ELSE
	BEGIN
		                 DELETE FROM [dbo].[TypeOfRoomService]
								 WHERE [TypeOfRoomId] = @Id
		SET @Message = N'Đã xóa thành công'
	END
	SELECT @Message AS [Message], @Id AS Id
END
