USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveImage]    Script Date: 12/1/2020 8:18:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		HongSon
-- Create date: 01/12/2020
-- Description:	Create or Update Image
-- =============================================
ALTER PROCEDURE [dbo].[sp_SaveImage]
	-- Add the parameters for the stored procedure here
	@ImageId int,
	@ImagePath nvarchar(250),
	@TypeOfRoomId int

AS
BEGIN

	DECLARE @Message NVARCHAR(100) = N'Đả xảy ra lỗi, vui lòng thử lại sau!'
	

	--hai tham số truyền vào @ImagePath không thể bằng null hoặc = ''. và @TypeOfRoomId không thể bằng 0
	IF(ISNULL(@ImagePath,'')='' or ISNULL(@TypeOfRoomId,0) = 0)
		BEGIN
			SET @Message = N'ImagePath hoặc TypeOfRoom không thể để trống'
			SELECT @Message AS [Message], @ImageId AS ImageId
		END
	ELSE
		BEGIN
			BEGIN TRY
				--nếu @ImageId truyền vào bằng 0 hoặc null thì tạo mới 1 bản record vào bảng Image
				IF(ISNULL(@ImageId,0) = 0)
					BEGIN

						INSERT INTO [dbo].[Image]
								   ([ImagePath]
								   ,[TypeOfRoomId])
							 VALUES
								   (@ImagePath
								   ,@TypeOfRoomId)

						SET @Message = N'Tạo thành công'
						SET @ImageId = SCOPE_IDENTITY()
					END
				--nếu @ImageId truyền vào KHÁC 0 hoặc null thì update dử liệu cho bản record mà ImageId = @ImageId
				ELSE
					BEGIN
						IF(NOT EXISTS(SELECT * FROM [dbo].[Image] WHERE [ImageId] = @ImageId))
							BEGIN
								SET @Message = N'Không Tìm Thấy !'
							END
						ELSE
							BEGIN
								UPDATE [dbo].[Image]
								   SET 
									   [ImagePath] = @ImagePath
									  ,[TypeOfRoomId] = [TypeOfRoomId]
								 WHERE ImageId = @ImageId

								 SET @Message = N'Cập nhật thành công'
							END
					END
				SELECT @Message AS [Message], @ImageId AS ImageId
			END TRY

			BEGIN CATCH
				SELECT @Message AS [Message], @ImageId AS ImageId
			END CATCH
		END
END

