USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveCustomer]    Script Date: 1/1/2021 2:28:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_SaveCustomer]
	   @Id int,
	   @Name nvarchar(150),      
	   @PhoneNum varchar(50),
	   @Email varchar(100),
	   @Country nvarchar(50),
	   @Passport varchar(50),
	   @Address nvarchar(250)
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = N'Đã xảy ra lỗi, vui lòng thử lại sau!'
	BEGIN TRY
		-- Create
		--IF(@CourseId IS NULL OR @CourseId = 0)
		IF(ISNULL(@Id,0) = 0)
			BEGIN	

				INSERT INTO [dbo].[Customer]
						   ([Name]
						   ,[PhoneNum]
						   ,[Email]
						   ,[Country]
						   ,[Passport]
						   ,[Address])
					 VALUES
						   (@Name
						   ,@PhoneNum
						   ,@Email
						   ,@Country
						   ,@Passport
						   ,@Address)

				SET @Message = N'khách hàng đã được tạo thành công'
				SET @Id = SCOPE_IDENTITY()
			END


		ELSE --Update
		BEGIN
			IF(NOT EXISTS(SELECT * FROM [dbo].[Customer] WHERE [Id] = @Id))
			BEGIN
				SET @Message = N'Không tìm thấy khách hàng này'
			END
			ELSE
			BEGIN	

				UPDATE [dbo].[Customer]
				   SET [Name] = @Name
					  ,[PhoneNum] = @PhoneNum
					  ,[Email] = @Email
					  ,[Country] = @Country
					  ,[Passport] = @Passport
					  ,[Address] = @Address
				 WHERE Id=@Id

					 SET @Message = N'khách hàng đã được cập nhật thành công'
						
			END
		END
		SELECT @Message AS [Message], @Id AS Id
	END TRY
	BEGIN CATCH
		SELECT @Message AS [Message], @Id AS Id
	END CATCH
END
