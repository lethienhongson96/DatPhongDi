USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_ChangeStatusService]    Script Date: 11/23/2020 11:51:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Khoa Hoang
-- Create date: 19/11/2020
-- Description: Thay đổi trạng thái loại hàng
-- =============================================
ALTER PROCEDURE [dbo].[sp_ChangeStatusService]
	@Id INT,
	@Status INT
AS
BEGIN
	DECLARE @Message NVARCHAR(200) = N'Có gì đó sai, vui lòng thử lại sau!'
	BEGIN TRY
	IF(EXISTS(SELECT * FROM Room WHERE @Id = Id) and @Status in (1,2))
		BEGIN
			UPDATE Room SET [Status] = @Status
			WHERE @Id = [Id]
			SET @Message = (CASE @Status
					WHEN 1 THEN N'Loại hàng đã được chuyển sang trạng thái đang hoạt động.'
					ELSE  N'Loại hàng đã bị xóa'
				End)
			SELECT @Id AS [Id], @Message AS [Message]
		END
	ELSE IF (@Status in (1,2))
		BEGIN
			SET @Id = 0
			SET @Message = N'Loại hàng không được tìm thấy'
			SELECT @Id AS [Id], @Message AS [Message]
		END
	ELSE IF (@Status not in (1,2))
		BEGIN
			SET @Message = N'Trạng thái không đúng'
			SELECT @Id AS [Id], @Message AS [Message]
		END	
	END TRY
	BEGIN CATCH
		SET @Id = 0
		SELECT @Id AS [Id], @Message AS [Message]
	END CATCH
END

exec [dbo].[sp_ChangeStatusService] 1,1

