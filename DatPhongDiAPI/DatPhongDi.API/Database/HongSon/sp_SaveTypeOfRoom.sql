USE [DatPhongDiDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_SaveTypeOfRoom]    Script Date: 11/19/2020 9:24:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_SaveTypeOfRoom]
	   @Id int,
	   @Name nvarchar(50),
	   @Status int
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = N'đả xảy ra lỗi, vui lòng thử lại sau!'
	BEGIN TRY
		-- Create
		--IF(@CourseId IS NULL OR @CourseId = 0)
		IF(ISNULL(@Id,0) = 0)
			BEGIN
				IF(NOT EXISTS(SELECT * FROM [dbo].[TypeOfRoom] WHERE LOWER(RTRIM(LTRIM([Name]))) = LOWER(RTRIM(LTRIM(@Name)))))
					BEGIN
						IF(@Status =  1 OR @Status = 2)
						BEGIN
							INSERT INTO [dbo].[TypeOfRoom]
									   ([Name]
									   ,[Status])
								 VALUES
									   (@Name
									   ,@Status)

							SET @Message = N'Loại Phòng đả được tạo thành công'
							SET @Id = SCOPE_IDENTITY()
						END
						ELSE
						BEGIN
							SET @Message = N'Status không hợp lệ'
						END
					END
				ELSE
					BEGIN
						SET @Message = N'Tên Loại phòng đả tồn tại'
					END
			END


		ELSE --Update
		BEGIN
			IF(NOT EXISTS(SELECT * FROM [dbo].[TypeOfRoom] WHERE [Id] = @Id))
			BEGIN
				SET @Message = N'không tìm thấy loại phòng này'
			END
			ELSE
			BEGIN
				IF(NOT EXISTS(SELECT TOP(1) * FROM [dbo].[TypeOfRoom] WHERE [Id] != @Id AND LOWER(RTRIM(LTRIM([Name]))) = LOWER(RTRIM(LTRIM(@Name)))))
					BEGIN
						IF(@Name!=null or @Name!='')
							BEGIN
								IF(@Status =  1 OR @Status = 2)
									BEGIN
										UPDATE [dbo].[TypeOfRoom]
										   SET [Name] = @Name
											  ,[Status] = @Status
										 WHERE [Id]=@Id

										SET @Message = N'loại phòng đả được cập nhật thành công'
						
									END
							END
						ELSE
							BEGIN
								SET @Message = N'Status không hợp lệ hoặc tên loại phòng không hợp lệ'
							END
					END
				ELSE
					BEGIN
						SET @Message = N'Tên loại đả tồn tại'
					END
			END
		END
		SELECT @Message AS [Message], @Id AS Id
	END TRY
	BEGIN CATCH
		SELECT @Message AS [Message], @Id AS Id
	END CATCH
END
GO

