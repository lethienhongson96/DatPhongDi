USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_ChangeTypeOfRoomStatus]    Script Date: 11/24/2020 10:17:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hong Son
-- Create date: 11/18/2020
-- Description:	Change Module's status
-- =============================================
ALTER PROCEDURE [dbo].[sp_ChangeTypeOfRoomStatus]
	-- Add the parameters for the stored procedure here
	@Id int,@Status int
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = N'Có gì đó sai, vui lòng thử lại'
	IF(exists(select * from [dbo].[TypeOfRoom] where @Id = [Id] and @Status in (1,2)))
		BEGIN
			UPDATE [dbo].[TypeOfRoom]
			SET [Status] = @Status
			WHERE [Id] = @Id
			set @Message = N'Thay đổi status thành công'
		END
	ELSE
		BEGIN
			set @Message = N'không tìm thấy loại phòng hoặc status không hợp lệ'
		END
	SELECT @Message AS [Message], @Id AS Id
END

