USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_ChangeStatusRoom]    Script Date: 11/23/2020 10:48:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hồng Sơn
-- Create date: 11/23/2020
-- Description:	Change status for booking
-- =============================================
ALTER PROCEDURE [dbo].[sp_ChangeStatusBooking]	
	@Id int,
	@Status int
AS
BEGIN
	DECLARE @Message NVARCHAR(200) = N'Có gì đó sai, vui lòng thử lại sau!'
	BEGIN TRY
	IF(EXISTS(SELECT * FROM [dbo].[Booking] WHERE Id = @Id) and @Status in (1,2,3,4))
		BEGIN
			UPDATE [dbo].[Booking] SET [Status] = @Status
			WHERE @Id = [Id]
			SET @Message = (CASE @Status
					WHEN 1 THEN N'Booking này đã được chuyển sang trạng thái Chưa xử lý'
					WHEN 2 THEN N'Phòng này đã được chuyển sang trạng thái đã xác nhận'
					WHEN 3 THEN N'Phòng này đã được chuyển sang trạng thái đã Đả nhận phòng'
					ELSE N'Phòng này đã được chuyển sang trạng thái đả hủy'
				End)
			SELECT @Id AS [Id], @Message AS [Message]
		END
	ELSE IF (@Status in (1,2,3,4))
		BEGIN
			SET @Id = 0
			SET @Message = N'Phòng này không được tìm thấy'
			SELECT @Id AS Id, @Message AS [Message]
		END
	ELSE IF (@Status not in (1,2,3,4))
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

