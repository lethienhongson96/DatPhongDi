USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteImageByImageId]    Script Date: 12/2/2020 1:53:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		HongSon
-- Create date: 01/12/2020
-- Description:	Delete Image by ImageId
-- =============================================
ALTER PROCEDURE [dbo].[sp_DeleteImageByImageId]
	-- Add the parameters for the stored procedure here
	@ImageId int
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = N'Đả xảy ra lỗi, vui lòng thử lại sau !'
	BEGIN TRY

		IF(NOT EXISTS(SELECT * FROM [dbo].[Image] WHERE [ImageId] = @ImageId))
			BEGIN
				SET @Message = N'Thao tác xóa thất bại... Không tìm thấy Ảnh này !'
				SET @ImageId = 0
			END
		ELSE
			BEGIN
				DELETE FROM [dbo].[Image]
			    WHERE ImageId=@ImageId

				SET @Message = N'Đả xóa thành công !'
			END

		SELECT @Message AS [Message], @ImageId AS ImageId
	END TRY
	BEGIN CATCH
		SELECT @Message AS [Message], @ImageId AS ImageId
	END CATCH
END
