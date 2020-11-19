USE [DatPhongDiDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_ChangeStatusRoom]    Script Date: 19/11/2020 09:29:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Phúc Vui
-- Create date: 18/11/2020
-- Description:	Change status for Room
-- =============================================
CREATE PROCEDURE [dbo].[sp_ChangeStatusRoom]	
	@Id int,
	@Status int
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = N'Đã xảy ra lỗi'
	if(exists(select * from [dbo].[Room] where @Id = Id and @Status in (1,2,3,4)))
	begin
		UPDATE [dbo].[Room]
		SET [Status] = @Status
		WHERE Id = @Id
		set @Message = N'Cập nhật trạng thái thành công'
	end
	SELECT @Message AS [Message], @Id AS Id
END
GO

