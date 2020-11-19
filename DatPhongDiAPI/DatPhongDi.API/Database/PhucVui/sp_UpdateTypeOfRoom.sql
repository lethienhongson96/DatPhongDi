USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateTypeOfRoom]    Script Date: 19/11/2020 09:24:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Phúc Vui
-- Create date: 17/11/2020
-- Description:	Update Type of Room
-- Status : 1 - Hoạt động; 2 - Không hoạt động; 
-- =============================================
ALTER PROCEDURE [dbo].[sp_UpdateTypeOfRoom]
	@Id		INT,
	@Name	NVARCHAR(50),
	@Status	INT
	
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = N'Đã xảy ra lỗi, vui lòng thử lại sau'
	BEGIN TRY
			IF(NOT EXISTS(SELECT * FROM [dbo].[TypeOfRoom] WHERE Id = @Id))
			BEGIN
				SET @Message = N'Loại phòng không tìm thấy'
			END
			ELSE
			BEGIN
				IF(NOT EXISTS(SELECT TOP(1) * FROM TypeOfRoom
					 WHERE Id != @Id AND
					 LOWER(RTRIM(LTRIM(Name))) = LOWER(RTRIM(LTRIM(@Name)))))
				BEGIN
					IF(@Status =  1 OR @Status = 2)
					BEGIN
						UPDATE [dbo].[TypeOfRoom]
						   SET [Name] = @Name							  
							  ,[Status] = @Status
						 WHERE Id = @Id
						 SET @Message = N'Cập nhật thành công'
					END
					ELSE
					BEGIN
						SET @Message = N'Trạng thái không đúng'
					END
				END
				ELSE
				BEGIN
					SET @Message = N'Tên đã tồn tại'
				END
			END			
		SELECT @Message AS [Message], @Id AS Id
	END TRY
	BEGIN CATCH
		SELECT @Message AS [Message], @Id AS Id
	END CATCH
END