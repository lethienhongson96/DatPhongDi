USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_ChangeStatusRoom]    Script Date: 11/23/2020 11:50:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Phúc Vui
-- Create date: 18/11/2020
-- Description:	Change status for Room
-- =============================================
ALTER PROCEDURE [dbo].[sp_ChangeStatusRoom]	
	@Id int,
	@Status int
AS
BEGIN
	DECLARE @Message NVARCHAR(200) = N'Có gì đó sai, vui lòng thử lại sau!'
	BEGIN TRY
	IF(EXISTS(SELECT * FROM [dbo].[Room] WHERE @Id = Id) and @Status in (1,2,3))
		BEGIN
			UPDATE [dbo].[Room] SET [Status] = @Status
			WHERE @Id = [Id]
			SET @Message = (CASE @Status
					WHEN 1 THEN N'Phòng này đã được chuyển sang trạng thái phòng trống'
					WHEN 2 THEN N'Phòng này đã được chuyển sang trạng thái đã được thuê'
					ELSE N'Phòng này đã được chuyển sang trạng thái không hoạt động'
				End)
			SELECT @Id AS [Id], @Message AS [Message]
		END
	ELSE IF (@Status in (1,2,3))
		BEGIN
			SET @Id = 0
			SET @Message = N'Phòng này không được tìm thấy'
			SELECT @Id AS Id, @Message AS [Message]
		END
	ELSE IF (@Status not in (1,2,3))
		BEGIN
			SET @Message = N'Trạng thái không đúng'
			SELECT @Id AS Id, @Message AS [Message]
		END	
	END TRY
	BEGIN CATCH
		SET @Id = 0
		SELECT @Id AS Id, @Message AS [Message]
	END CATCH
END

exec [dbo].[sp_ChangeStatusRoom] 1,1
