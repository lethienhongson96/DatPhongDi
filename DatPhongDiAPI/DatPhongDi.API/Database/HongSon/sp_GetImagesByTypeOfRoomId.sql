USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetImagesByTypeOfRoomId]    Script Date: 12/2/2020 2:05:03 PM ******/
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

	END
	ELSE
	BEGIN
		SET @Message = N'Không tìm thấy ảnh cho loại phòng này'
		SELECT @Message AS [Message], @Id as [Id]
	END
	
END




