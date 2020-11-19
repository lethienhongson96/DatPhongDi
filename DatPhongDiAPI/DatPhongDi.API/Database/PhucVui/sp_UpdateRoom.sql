USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateRoom]    Script Date: 19/11/2020 09:26:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Phúc Vui
-- Create date: 17/11/2020
-- Description:	Update Room
-- Status : 1 - Hoạt động; 2 - Không hoạt động; 3 - Trống; 4 - Không trống
-- =============================================
ALTER PROCEDURE [dbo].[sp_UpdateRoom]
	@Id		INT,
	@Name	VARCHAR(50),
	@PricePerNight INT,
	@AmountAdult INT,
	@AmountChild INT,
	@Status	INT,
	@TypeOfRoomId INT
	
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = N'Đã xảy ra lỗi, vui lòng thử lại sau !'
	BEGIN TRY
			IF(NOT EXISTS(SELECT * FROM [dbo].[Room] WHERE Id = @Id))
			BEGIN
				SET @Message = N'Không tìm thấy phòng '
			END
			ELSE
			BEGIN
				IF(NOT EXISTS(SELECT TOP(1) * FROM Room
					 WHERE Id != @Id AND
					 LOWER(RTRIM(LTRIM(Name))) = LOWER(RTRIM(LTRIM(@Name)))))
				BEGIN
					IF(@Status =  1 OR @Status = 2 OR @Status = 3 OR @Status = 4)
					BEGIN
						UPDATE [dbo].[Room]
						   SET [Name] = @Name
							,[PricePerNight] = @PricePerNight
							,[AmountAdult] = @AmountAdult
							,[AmountChild] = @AmountChild
							,[Status] = @Status
							,[TypeOfRoomId] = @TypeOfRoomId
						 WHERE Id = @Id
						 SET @Message = N'Cập nhật thành công !'
					END
					ELSE
					BEGIN
						SET @Message = N'Trạng thái không đúng'
					END
				END
				ELSE
				BEGIN
					SET @Message = N'Tên phòng đã tồn tại'
				END
			END			
		SELECT @Message AS [Message], @Id AS Id
	END TRY
	BEGIN CATCH
		SELECT @Message AS [Message], @Id AS Id
	END CATCH
END