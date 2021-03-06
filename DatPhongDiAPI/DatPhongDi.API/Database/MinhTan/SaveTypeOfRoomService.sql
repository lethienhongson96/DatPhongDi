USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveTypeOfRoomService]    Script Date: 01/12/2020 20:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Khoa Hoang
-- Create date: 19/11/2020
-- Description:	Create or Update Service
-- =============================================
ALTER PROCEDURE [dbo].[sp_SaveTypeOfRoomService]
	  @Id INT,
	  @ServiceId INT,
	  @TypeofRoomId INT
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = N'Có gì đó sai , vui lòng thử lại sau!'
	BEGIN TRY
		IF(ISNULL(@Id,0) = 0)
		BEGIN
			IF(NOT EXISTS(SELECT * FROM [dbo].[TypeOfRoomService] WHERE @TypeofRoomId = [TypeOfRoomId] and [ServiceId]=@ServiceId ))
			BEGIN
					INSERT INTO [dbo].[TypeOfRoomService]
						   ([ServiceId]
						   ,[TypeOfRoomId])
					 VALUES
						   (@ServiceId
						   ,@TypeofRoomId)
					SET @Message = N'Dịch vụ đã được thêm vào cơ sở dữ liệu'
					SET @Id = SCOPE_IDENTITY()
				END
				ELSE
			BEGIN
				SET @Message = N'Đã có dịch vụ này trong cơ sở dữ liệu'
			END
		END
		ELSE --Update
		BEGIN
			IF(NOT EXISTS(SELECT * FROM [dbo].[ServiceTypeofroom] WHERE [Id] = @Id))
			BEGIN
				SET @Message = N'Không tìm thấy loại hàng này!'
			END
			ELSE
			BEGIN
				IF(NOT EXISTS(SELECT TOP(1) * FROM [dbo].[ServiceTypeofroom]
					 WHERE [Id] <>  @Id AND 
					 [ServiceId] = [TypeofRoomId]))
				BEGIN
					
						BEGIN
							UPDATE [dbo].[ServiceTypeofroom]
								   SET [ServiceId] = @ServiceId
									  ,[TypeofRoomId] = @TypeofRoomId
								 WHERE [Id] = @Id

								 SET @Message = N'Dịch vụ đã được cập nhật thành công!'
						END
				
						BEGIN
							SET @Message = N'Trạng thái không đúng'
						END
				END
				ELSE
				BEGIN
					SET @Message = N'Dịch vụ này đã tồn tại trong cơ sở dữ liệu!'
				END
			END
	 	END
		SELECT @Message AS [Message], @Id AS Id
	END TRY
	BEGIN CATCH
		SELECT @Message AS [Message], @Id AS Id
	END CATCH
END