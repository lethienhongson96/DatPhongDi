USE [DatPhongDiDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_SaveRoom]    Script Date: 11/19/2020 9:25:50 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_SaveRoom]
	   @Id int,
	   @Name varchar(50),
       @PricePerNight int,
	   @AmountAdult int,
	   @AmountChild int,
	   @Status int,
	   @TypeOfRoomId int
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = N'đả xảy ra lỗi, vui lòng thử lại sau!'
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
									   ,[PricePerNight]
									   ,[AmountAdult]
									   ,[AmountChild]
									   ,[Status]
									   ,[TypeOfRoomId]
									   ,[CreateDate]
									   ,[ModifiedDate])
								 VALUES
									   (@Name
									   ,@PricePerNight
									   ,@AmountAdult
									   ,@AmountChild
									   ,@Status
									   ,@TypeOfRoomId
									   ,GETDATE()
									   ,null)


							SET @Message = N'Phòng đả được tạo thành công'
							SET @Id = SCOPE_IDENTITY()
						END
						ELSE
						BEGIN
							SET @Message = N'Status không hợp lệ'
						END
					END
				ELSE
					BEGIN
						SET @Message = N'Tên phòng đả tồn tại'
					END
			END


		ELSE --Update
		BEGIN
			IF(NOT EXISTS(SELECT * FROM [dbo].[Room] WHERE [Id] = @Id))
			BEGIN
				SET @Message = N'không tìm thấy phòng này'
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
							  ,[PricePerNight] = @PricePerNight
							  ,[AmountAdult] = @AmountAdult
							  ,[AmountChild] = @AmountChild
							  ,[Status] = @Status
							  ,[TypeOfRoomId] = @TypeOfRoomId
							  ,[ModifiedDate]=GETDATE()
						 WHERE [Id]=@Id

					 SET @Message = N'phòng đả được cập nhật thành công'
						
					END
					ELSE
					BEGIN
						SET @Message = N'IStatus không hợp lệ'
					END
				END
				ELSE
				BEGIN
					SET @Message = N'Tên phòng đả tồn tại'
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

