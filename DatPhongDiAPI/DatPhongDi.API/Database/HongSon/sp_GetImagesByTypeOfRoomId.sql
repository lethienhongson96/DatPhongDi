USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetImagesByTypeOfRoomId]    Script Date: 12/1/2020 8:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		 HongSon
-- Create date: 1/12/2020
-- Description:	Get Images by TypeOfRoomId
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetImagesByTypeOfRoomId] 
	@Id int
AS
BEGIN
DECLARE @Message Nvarchar(50) = N'Đả xảy ra lỗi, vui lòng thử lại'
	IF(EXISTS(SELECT * FROM [dbo].[TypeOfRoom] WHERE [Id] = @Id))
	BEGIN
		SELECT [ImageId]
			  ,[ImagePath]
			  ,[TypeOfRoomId]
		  FROM [dbo].[Image]
		  WHERE [TypeOfRoomId]=@Id

		SET @Message = N'Thao tác thành công'
	END
	ELSE
	BEGIN
		SET @Message = N'Không tìm thấy ảnh thuộc loại phòng này'
	END
	SELECT @Message AS [Message], @Id as [Id]
END


