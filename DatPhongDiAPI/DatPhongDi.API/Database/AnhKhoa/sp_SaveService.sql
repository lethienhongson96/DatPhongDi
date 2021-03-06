USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveService]    Script Date: 11/20/2020 3:24:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Khoa Hoang
-- Create date: 19/11/2020
-- Description:	Create or Update Service
-- =============================================
ALTER PROCEDURE [dbo].[sp_SaveService]
	  @Id INT,
	  @Name NVARCHAR(50),
	  @Icon NVARCHAR(150),
	  @Status INT
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = N'Có gì đó sai , vui lòng thử lại sau!'
	BEGIN TRY
		IF(ISNULL(@Id,0) = 0)
		BEGIN
			IF(NOT EXISTS(SELECT * FROM [dbo].[Service] WHERE LOWER(RTRIM(LTRIM([Name]))) = LOWER(RTRIM(LTRIM(@Name)))))
			BEGIN
				IF(@Status = 1)
				BEGIN
					INSERT INTO [dbo].[Service]
						   ([Name]
						   ,[Icon]
						   ,[Status])
					 VALUES
						   (@Name
						   ,@Icon
						   ,@Status)
					SET @Message = N'Dịch vụ đã được thêm vào cơ sở dữ liệu'
					SET @Id = SCOPE_IDENTITY()
				END
				ELSE
				BEGIN
					SET @Message = N'Trạng thái không đúng'
				END
			END
			ELSE
			BEGIN
				SET @Message = N'Đã có dịch vụ này trong cơ sở dữ liệu'
			END
		END
		ELSE --Update
		BEGIN
			IF(NOT EXISTS(SELECT * FROM [dbo].[Service] WHERE [Id] = @Id))
			BEGIN
				SET @Message = N'Không tìm thấy loại hàng này!'
			END
			ELSE
			BEGIN
				IF(NOT EXISTS(SELECT TOP(1) * FROM [dbo].[Service]
					 WHERE [Id] != @Id AND 
					 LOWER(RTRIM(LTRIM([Name]))) = LOWER(RTRIM(LTRIM(@Name)))))
				BEGIN
					IF(@Status = 1)
						BEGIN
							UPDATE [dbo].[Service]
								   SET [Name] = @Name
									  ,[Icon] = @Icon
								 WHERE [Id] = @Id

								 SET @Message = N'Dịch vụ đã được cập nhật thành công!'
						END
					ELSE
						BEGIN
							SET @Message = N'Trạng thái không đúng'
						END
				END
				ELSE
				BEGIN
					SET @Message = N'Dịch vụ này bị khùng khớp trong cơ sở dữ liệu!'
				END
			END
		END
		SELECT @Message AS [Message], @Id AS Id
	END TRY
	BEGIN CATCH
		SELECT @Message AS [Message], @Id AS Id
	END CATCH
END
