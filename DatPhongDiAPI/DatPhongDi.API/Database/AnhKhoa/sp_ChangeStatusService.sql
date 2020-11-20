USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_ThayDoiTrangThaiLoaiHang]    Script Date: 11/20/2020 4:44:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Khoa Hoang
-- Create date: 19/11/2020
-- Description: Thay đổi trạng thái loại hàng
-- =============================================
CREATE PROCEDURE [dbo].[sp_ChangeStatusService]
	@Id INT,
	@Status INT
AS
BEGIN
	DECLARE @Message NVARCHAR(200) = N'Có gì đó sai, vui lòng thử lại sau!'
	BEGIN TRY
	IF(EXISTS(SELECT * FROM [dbo].[Service] WHERE @Id = Id) and @Status in (1,2))
		BEGIN
			UPDATE [dbo].[Service] SET [Status] = @Status
			WHERE @Id = [Id]
			SET @Message = (CASE @Status
					WHEN 1 THEN N'Dịch vụ này đã được chuyển sang trạng thái đang hoạt động.'
					ELSE  N'Dịch vụ này đã được chuyển sang trạng thái không hoạt động'
				End)
			SELECT @Id AS [Id], @Message AS [Message]
		END
	ELSE IF (@Status in (1,2))
		BEGIN
			SET @Id = 0
			SET @Message = N'Dịch vụ này không được tìm thấy'
			SELECT @Id AS Id, @Message AS [Message]
		END
	ELSE IF (@Status not in (1,2))
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

