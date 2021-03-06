USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveRoom]    Script Date: 02/12/2020 10:30:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_SaveRoom]
	   @Id int,
	   @Name varchar(50),      
	   @Status int,
	   @TypeOfRoomId int,
		@Description nvarchar(100),
		@Size int 
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = N'Đã xảy ra lỗi, vui lòng thử lại sau!'
	BEGIN TRY
		-- Create
		--IF(@CourseId IS NULL OR @CourseId = 0)
		IF(ISNULL(@Id,0) = 0)
			BEGIN
				IF(NOT EXISTS(SELECT * FROM [dbo].[Room] WHERE LOWER(RTRIM(LTRIM([Name]))) = LOWER(RTRIM(LTRIM(@Name)))))
					BEGIN
						IF(@Status =  1 OR @Status = 2 OR @Status = 3)
						BEGIN

							INSERT INTO [dbo].[Room]
									   ([Name]									  
									   ,[Status]
									   ,[TypeOfRoomId]
									   ,[Description]
									   ,[Size]
									   ,[CreateDate]
									   ,[ModifiedDate])
								 VALUES
									   (@Name									   
									   ,@Status
									   ,@TypeOfRoomId
									   ,@Description
										,@Size 
									   ,GETDATE()
									   ,null)

							SET @Message = N'Phòng đã được tạo thành công'
							SET @Id = SCOPE_IDENTITY()
						END
						ELSE
						BEGIN
							SET @Message = N'Trạng thái không hợp lệ'
						END
					END
				ELSE
					BEGIN
						SET @Message = N'Tên phòng đã tồn tại'
					END
			END


		ELSE --Update
		BEGIN
			IF(NOT EXISTS(SELECT * FROM [dbo].[Room] WHERE [Id] = @Id))
			BEGIN
				SET @Message = N'Không tìm thấy phòng này'
			END
			ELSE
			BEGIN
				IF(NOT EXISTS(SELECT TOP(1) * FROM [dbo].[Room]
					 WHERE [Id] != @Id AND
					 LOWER(RTRIM(LTRIM([Name]))) = LOWER(RTRIM(LTRIM(@Name)))))
				BEGIN
					IF(@Status =  1 OR @Status = 2 OR @Status = 3)
					BEGIN
						
						UPDATE [dbo].[Room]
						   SET [Name] = @Name							
							  ,[Status] = @Status
							  ,[TypeOfRoomId] = @TypeOfRoomId
							  ,[Description] = @Description
							  ,[Size] = @Size
							  ,[ModifiedDate]=GETDATE()
						 WHERE [Id]=@Id

					 SET @Message = N'Phòng đã được cập nhật thành công'
						
					END
					ELSE
					BEGIN
						SET @Message = N'Trạng thái không hợp lệ'
					END
				END
				ELSE
				BEGIN
					SET @Message = N'Tên phòng đã tồn tại'
				END
			END
		END
		SELECT @Message AS [Message], @Id AS Id
	END TRY
	BEGIN CATCH
		SELECT @Message AS [Message], @Id AS Id
	END CATCH
END
